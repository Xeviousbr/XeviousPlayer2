#region Usings

using PVS.MediaPlayer;
using System;
using System.Drawing;
using System.Security;
using System.Security.Permissions;
using System.Windows.Forms;

#endregion

namespace PVSPlayerExample
{
    public sealed partial class TilesOverlay : Form, IOverlay
    {
        /*
        
        PVS.MediaPlayer Display Overlay - Example 'Tiles'
        Displays video as tiles.

        This overlay copies the video from the player's display
        to a bitmap that is used to draw tiles on the overlay (using Win32 BitBlt).

        Something similar could be achieved by using PVS.MediaPlayer display clones.
        
        */

        // ******************************** Fields

        #region Fields

        // constants
        private const int   FPS60 = 17; // display refresh rate (frames per second) - timer interval values
        private const int   FPS50 = 20;
        private const int   FPS40 = 25;
        private const int   FPS30 = 33;
        private const int   FPS25 = 40;
        private const int   FPS20 = 50;
        private const int   FPS15 = 67;
        private const int   FPS10 = 100;
        private const int   FPS05 = 200;
        private const int   FPS02 = 500;
        private const int   FPS01 = 1000;

        private const int   STRETCH_HALFTONE = 4; // quality setting for StretchBlt

        // The player (from the main application)
        private MainWindow  _baseForm;
        private Player      _basePlayer;
        private bool        _videoBoundsMode = true;
        private Rectangle   _sourceBounds;

        // Timer
        private Timer       _timer;
        private const int   TIMER_INTERVAL = FPS25;
        private bool        _busy;

        // Bitmap
        private Bitmap      _bitmap1;

        // Graphics
        private Graphics    _sourceGraphics;
        private Graphics    _bitmapGraphics;
        private Graphics    _destinationGraphics;

        // Hdc - device contexts
        private IntPtr      _bitmapHdc = IntPtr.Zero;
        private IntPtr      _sourceHdc = IntPtr.Zero;
        private IntPtr      _destinationHdc = IntPtr.Zero;

        // BaseTile
        private int         _baseX;
        private int         _baseY;
        private int         _baseWidth;
        private int         _baseHeight;
        private bool        _baseFlipX;
        private bool        _baseFlipY;

        // Tiles
        private int         _horizontalTiles = 3;
        private int         _verticalTiles = 3;
        private int         _xPos;
        private int         _yPos;
        private int         _tileWidth;
        private int         _tileHeight;
        private int         _xPosDelta;
        private int         _yPosDelta;
        private bool        _flipX;
        private bool        _flipY;

        // Active display
        private bool        _running;
        private bool        _hasEvents;

        // Puzzle
        private bool        _puzzleOn;
        private int[]       _puzzleArray;
        private bool        _selectionOn;
        private bool        _indicatorsOn; // show correct positioned tiles
        private bool        _gridOn;
        private int         _selectedIndex;
        private bool        _solved;
        private Rectangle   _gridRect;
        private SolidBrush  _gridBrush;
        private Pen         _gridPen;
        private Pen         _indicatorPen;
        private Rectangle   _selectRect;
        private SolidBrush  _indicatorBrush;
        private SolidBrush  _selectBrush;
        private Pen         _selectPen;

        private bool        _disposed;

        #endregion

        // ******************************** Initializing / Form & Player eventhandling

        #region Initializing and Form & Player eventhandling

        public TilesOverlay(MainWindow baseForm, Player basePlayer)
        {
            InitializeComponent();

            _baseForm = baseForm;
            _basePlayer = basePlayer;

            _gridBrush = new SolidBrush(Color.FromArgb(18, 18, 18));
            _gridPen = new Pen(_gridBrush, 1);
            _indicatorBrush = new SolidBrush(UIColors.MenuTextEnabledColor);
            _indicatorPen = new Pen(_indicatorBrush, 1);
            _selectBrush = new SolidBrush(Color.Lime);
            _selectPen = new Pen(_selectBrush, 3);

            // Pass on drag and drop to main form (handled in source file: DragDrop.cs):
            AllowDrop = true;
            DragDrop += _baseForm.Form1_DragDrop;

            _timer = new Timer {Interval = TIMER_INTERVAL};
            _timer.Tick += TimerTick;
        }

        protected override bool ShowWithoutActivation
        {
            get { return true; }
        }

        // Form  don't activate form with mouse click
        protected override void WndProc(ref Message m)
        {
            const int WM_MOUSEACTIVATE  = 0x0021;
            const int MA_NOACTIVATE     = 0x0003;

            if (m.Msg == WM_MOUSEACTIVATE) m.Result = (IntPtr)MA_NOACTIVATE;
            else base.WndProc(ref m);
        }

        private void TileOverlay_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                _baseForm.SetWindowDrag(!_puzzleOn);

                if (!_hasEvents)
                {
                    _basePlayer.Events.MediaStarted             += BasePlayer_MediaStarted;
                    _basePlayer.Events.MediaDisplayModeChanged  += BasePlayer_MediaDisplayModeChanged;
                    if(!_puzzleOn) MouseDown                    += _basePlayer.Display.Drag_MouseDown;
                    _hasEvents = true;
                }
                if (!_running)
                {
                    if (_basePlayer.Video.Present)
                    {
                        SetBitmap(true);
                        _timer.Start();
                        _running = true;
                    }
                }

                _basePlayer.Overlay.Blend = OverlayBlend.Opaque;
            }
            else
            {
                if (_running)
                {
                    _timer.Stop();
                    _running = false;
                    SetBitmap(false);
                }
                if (_hasEvents)
                {
                    _basePlayer.Events.MediaStarted             -= BasePlayer_MediaStarted;
                    _basePlayer.Events.MediaDisplayModeChanged  -= BasePlayer_MediaDisplayModeChanged;
                    if (!_puzzleOn) MouseDown                   -= _basePlayer.Display.Drag_MouseDown;
                    _hasEvents = false;
                }

                _basePlayer.Overlay.Blend = OverlayBlend.None;
            }
        }

        private void TileOverlay_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized) _timer.Stop();
            else if (_running)
            {
                SetBitmap(true);
                if (!_timer.Enabled) _timer.Start();
                Invalidate();
            }
        }

        [PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_running)
                    {
                        _timer.Stop();
                        _running = false;
                        SetBitmap(false);
                    }

                    if (_hasEvents)
                    {
                        _basePlayer.Events.MediaStarted -= BasePlayer_MediaStarted;
                        _basePlayer.Events.MediaDisplayModeChanged -= BasePlayer_MediaDisplayModeChanged;
                        _hasEvents = false;
                    }

                    _timer.Dispose(); _timer = null;
                    if (_bitmap1 != null)
                    {
                        _bitmap1.Dispose();
                        _bitmap1 = null;
                    }
                    _basePlayer = null;

                    DragDrop -= _baseForm.Form1_DragDrop;
                    _baseForm = null;

                    _gridPen.Dispose();
                    _gridBrush.Dispose();
                    _indicatorPen.Dispose();
                    _indicatorBrush.Dispose();
                    _selectPen.Dispose();
                    _selectBrush.Dispose();

                    if (components != null) components.Dispose();
                }
                _disposed = true;
            }
            base.Dispose(disposing);
        }

        void BasePlayer_MediaStarted(object sender, EventArgs e)
        {
            if (!_running && _basePlayer.Video.Present)
            {
                if (WindowState != FormWindowState.Minimized)
                {
                    SetBitmap(true);
                    _timer.Start();
                }
                _running = true;
            }
        }

        void BasePlayer_MediaDisplayModeChanged(object sender, EventArgs e)
        {
            Invalidate();
        }

        #endregion

        // ******************************** IOverlay Control

        #region IOverlay Control

        // The visibility of the menu is controlled by the user from the main application (in this example application)
        public bool MenuEnabled
        {
            get { return tilesPanel.Visible; }
            set { tilesPanel.Visible = value; }
        }

        public bool HasMenu
        {
            get { return true; }
        }

        public void MediaStopped()
        {
            if (Visible && _running)
            {
                _timer.Stop();
                _running = false;
                Invalidate();
            }
        }

        #endregion

        // ******************************** Set Bitmap / Display the tiles

        #region Set Bitmap / Display the tiles

        [PermissionSet(SecurityAction.LinkDemand, Name = "FullTrust", Unrestricted = false)]
        private void SetBitmap(bool create)
        {
            _busy = true;
            if (_bitmap1 != null)
            {
                _bitmapGraphics.ReleaseHdc(_bitmapHdc);
                _bitmapGraphics.Dispose();
                _bitmap1.Dispose();
                _bitmap1 = null;
            }
            if (create)
            {
                // Because of rounding there should be 2 alternating values for width and height
                // for compensating width and heigth differences (not used)

                _tileWidth = (int)((float)DisplayRectangle.Width / _horizontalTiles);
                if (_tileWidth < 4) return;
                _xPosDelta = _tileWidth - 1;
                if (_baseFlipX)
                {
                    _baseX = _tileWidth - 1;
                    _baseWidth = -_tileWidth;
                }
                else
                {
                    _baseX = 0;
                    _baseWidth = _tileWidth;
                }

                _tileHeight = (int)((float)DisplayRectangle.Height / _verticalTiles);
                if (_tileHeight < 4) return;
                _yPosDelta = _tileHeight - 1;
                if (_baseFlipY)
                {
                    _baseY = _tileHeight - 1;
                    _baseHeight = -_tileHeight;
                }
                else
                {
                    _baseY = 0;
                    _baseHeight = _tileHeight;
                }

                _bitmap1 = new Bitmap(_tileWidth, _tileHeight);
                _bitmapGraphics = Graphics.FromImage(_bitmap1);
                _bitmapHdc = _bitmapGraphics.GetHdc();
            }
            _busy = false;
        }

        // Display the tiles
        void TimerTick(object sender, EventArgs e)
        {
            if (_busy) return;
            _busy = true;

            _sourceGraphics = _basePlayer.Display.Window.CreateGraphics();
            _sourceHdc = _sourceGraphics.GetHdc();

            if (_puzzleOn)
            {
                int xSource, ySource;
                int xDest, yDest;

                _sourceBounds = Rectangle.Intersect(_basePlayer.Video.Bounds, _basePlayer.Display.Window.DisplayRectangle);

                _destinationGraphics = CreateGraphics();
                _destinationHdc = _destinationGraphics.GetHdc();

                if (_basePlayer.Overlay.Mode == OverlayMode.Video)
                {
                    xDest = yDest = 0;
                }
                else
                {
                    xDest = _sourceBounds.X;
                    yDest = _sourceBounds.Y;
                }

                if (_solved)
                {
                    SafeNativeMethods.BitBlt(_destinationHdc, xDest, yDest, _sourceBounds.Width, _sourceBounds.Height, _sourceHdc, _sourceBounds.X, _sourceBounds.Y, 0x00CC0020U);
                }
                else
                {
                    int index = 0;
                    int sourceTileWidth = _sourceBounds.Width / _horizontalTiles;
                    int sourceTileHeight = _sourceBounds.Height / _verticalTiles;
                    _selectRect.Width = sourceTileWidth - 3;
                    _selectRect.Height = sourceTileHeight - 3;
                    _gridRect.Width = sourceTileWidth - 1;
                    _gridRect.Height = sourceTileHeight - 1;

                    _yPos = yDest;
                    for (int i = 0; i < _verticalTiles; i++)
                    {
                        _xPos = xDest;
                        for (int j = 0; j < _horizontalTiles; j++)
                        {
                            // get source tile (position stored in _puzzleArray)
                            xSource = _sourceBounds.X + ((_puzzleArray[index] % _horizontalTiles) * sourceTileWidth);
                            ySource = _sourceBounds.Y + ((_puzzleArray[index] / _horizontalTiles) * sourceTileHeight);

                            // Bitblt
                            if (_selectionOn && index == _selectedIndex)
                            {
                                // prevent flicker of selection rectangle
                                _selectRect.X = _xPos + 1;
                                _selectRect.Y = _yPos + 1;
                                SafeNativeMethods.BitBlt(_destinationHdc, _xPos + 3, _yPos + 3, sourceTileWidth - 6, sourceTileHeight - 6, _sourceHdc, xSource + 3, ySource + 3, 0x00CC0020U);
                            }
                            else
                            {
                                if (_gridOn || (_indicatorsOn && _puzzleArray[index] == index))
                                {
                                    // prevent flicker of grid rectangle
                                    _gridRect.X = _xPos;
                                    _gridRect.Y = _yPos;
                                    SafeNativeMethods.BitBlt(_destinationHdc, _xPos + 1, _yPos + 1, sourceTileWidth - 2, sourceTileHeight - 2, _sourceHdc, xSource + 1, ySource + 1, 0x00CC0020U);

                                    _destinationGraphics.ReleaseHdc(_destinationHdc);
                                    if (_indicatorsOn && _puzzleArray[index] == index) _destinationGraphics.DrawRectangle(_indicatorPen, _gridRect);
                                    else _destinationGraphics.DrawRectangle(_gridPen, _gridRect);
                                    _destinationHdc = _destinationGraphics.GetHdc();
                                }
                                else
                                {
                                    SafeNativeMethods.BitBlt(_destinationHdc, _xPos, _yPos, sourceTileWidth, sourceTileHeight, _sourceHdc, xSource, ySource, 0x00CC0020U);
                                }
                            }
                            index++;
                            _xPos += sourceTileWidth;
                        }
                        _yPos += sourceTileHeight;
                    }
                }

                _destinationGraphics.ReleaseHdc(_destinationHdc);
                if (_selectionOn) _destinationGraphics.DrawRectangle(_selectPen, _selectRect);
                _destinationGraphics.Dispose();

                _sourceGraphics.ReleaseHdc(_sourceHdc);
                _sourceGraphics.Dispose();
            }
            else
            {
                _sourceBounds = _videoBoundsMode ? Rectangle.Intersect(_basePlayer.Video.Bounds, _basePlayer.Display.Window.DisplayRectangle) : _basePlayer.Display.Window.DisplayRectangle;

                SafeNativeMethods.SetStretchBltMode(_bitmapHdc, STRETCH_HALFTONE);
                if (SafeNativeMethods.StretchBlt(_bitmapHdc, _baseX, _baseY, _baseWidth, _baseHeight, _sourceHdc, _sourceBounds.Left, _sourceBounds.Top, _sourceBounds.Width, _sourceBounds.Height, 0x00CC0020U))
                {
                    _sourceGraphics.ReleaseHdc(_sourceHdc);
                    _sourceGraphics.Dispose();

                    _destinationGraphics = CreateGraphics();
                    _destinationHdc = _destinationGraphics.GetHdc();

                    _yPos = 0;

                    for (int i = 0; i < _verticalTiles; i++)
                    {
                        _xPos = 0;
                        for (int j = 0; j < _horizontalTiles; j++)
                        {
                            if ((j & 1) == 0)
                            {
                                if ((i & 1) != 0 && _flipY) SafeNativeMethods.StretchBlt(_destinationHdc, _xPos, _yPos + _yPosDelta, _tileWidth, -_tileHeight, _bitmapHdc, 0, 0, _tileWidth, _tileHeight, 0x00CC0020U);
                                else SafeNativeMethods.BitBlt(_destinationHdc, _xPos, _yPos, _tileWidth, _tileHeight, _bitmapHdc, 0, 0, 0x00CC0020U);
                            }
                            else
                            {
                                if ((i & 1) != 0 && _flipY)
                                {
                                    if (_flipX) SafeNativeMethods.StretchBlt(_destinationHdc, _xPos + _xPosDelta, _yPos + _yPosDelta, -_tileWidth, -_tileHeight, _bitmapHdc, 0, 0, _tileWidth, _tileHeight, 0x00CC0020U);
                                    else SafeNativeMethods.StretchBlt(_destinationHdc, _xPos, _yPos + _yPosDelta, _tileWidth, -_tileHeight, _bitmapHdc, 0, 0, _tileWidth, _tileHeight, 0x00CC0020U);
                                }
                                else
                                {
                                    if (_flipX) SafeNativeMethods.StretchBlt(_destinationHdc, _xPos + _xPosDelta, _yPos, -_tileWidth, _tileHeight, _bitmapHdc, 0, 0, _tileWidth, _tileHeight, 0x00CC0020U);
                                    else SafeNativeMethods.BitBlt(_destinationHdc, _xPos, _yPos, _tileWidth, _tileHeight, _bitmapHdc, 0, 0, 0x00CC0020U);
                                }
                            }
                            _xPos += _tileWidth;
                        }
                        _xPos = 0;
                        _yPos += _tileHeight;
                    }

                    _destinationGraphics.ReleaseHdc(_destinationHdc);
                    _destinationGraphics.Dispose();
                }
                else
                {
                    _sourceGraphics.ReleaseHdc(_sourceHdc);
                    _sourceGraphics.Dispose();
                }
            }
            _busy = false;
        }

        #endregion

        // ******************************** 'Set' button

        #region 'Set' button

        // 'Set' button
        private void SetButton_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value < 1) numericUpDown1.Value = 1;
            if (numericUpDown2.Value < 1) numericUpDown2.Value = 1;

            _horizontalTiles = (int)numericUpDown1.Value;
            _verticalTiles = (int)numericUpDown2.Value;

            if (_puzzleOn) StartPuzzle();
            if (_running) SetBitmap(true);
            Invalidate();
        }

        #endregion

        // ******************************** Options menu handling

        #region Options menu handling

        // Set focus to input tiles when closed
        private void OptionsMenu_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            numericUpDown1.Focus();
        }

        #region Tile Source

        // TileSource - Video
        private void VideoMenuItem_Click(object sender, EventArgs e)
        {
            SetMenuCheckMarks(sender);
            _videoBoundsMode = true;
            if (_running) SetBitmap(true);
            Invalidate();

        }

        // TileSource - Display
        private void DisplayMenuItem_Click(object sender, EventArgs e)
        {
            SetMenuCheckMarks(sender);
            _videoBoundsMode = false;
            if (_running) SetBitmap(true);
            Invalidate();
        }

        #endregion

        #region Base Tile

        // BaseTile - Normal
        private void BaseNormalMenuItem_Click(object sender, EventArgs e)
        {
            SetMenuCheckMarks(sender);
            _baseFlipX = false;
            _baseFlipY = false;
            SetBaseTile();
        }

        // BaseTile - FlipX
        private void BaseFlipXMenuItem_Click(object sender, EventArgs e)
        {
            SetMenuCheckMarks(sender);
            _baseFlipX = true;
            _baseFlipY = false;
            SetBaseTile();
        }

        // BaseTile - FlipXY
        private void BaseFlipXYMenuItem_Click(object sender, EventArgs e)
        {
            SetMenuCheckMarks(sender);
            _baseFlipX = true;
            _baseFlipY = true;
            SetBaseTile();
        }

        // BaseTile - FlipY
        private void BaseFlipYMenuItem_Click(object sender, EventArgs e)
        {
            SetMenuCheckMarks(sender);
            _baseFlipX = false;
            _baseFlipY = true;
            SetBaseTile();
        }

        // Set BaseTile
        private void SetBaseTile()
        {
            if (_baseFlipX)
            {
                _baseX = _tileWidth - 1;
                _baseWidth = -_tileWidth;
            }
            else
            {
                _baseX = 0;
                _baseWidth = _tileWidth;
            }

            if (_baseFlipY)
            {
                _baseY = _tileHeight - 1;
                _baseHeight = -_tileHeight;
            }
            else
            {
                _baseY = 0;
                _baseHeight = _tileHeight;
            }
        }

        #endregion

        #region Tile Mode

        // TileMode - Normal
        private void TileNormalMenuItem_Click(object sender, EventArgs e)
        {
            SetMenuCheckMarks(sender);
            _flipX = false;
            _flipY = false;
        }

        // TileMode - TileFlipX
        private void TileFlipXMenuItem_Click(object sender, EventArgs e)
        {
            SetMenuCheckMarks(sender);
            _flipX = true;
            _flipY = false;
        }

        // TileMode - TileFlipXY
        private void TileFlipXYMenuItem_Click(object sender, EventArgs e)
        {
            SetMenuCheckMarks(sender);
            _flipX = true;
            _flipY = true;
        }

        // TileMode - TileFlipY
        private void TileFlipYMenuItem_Click(object sender, EventArgs e)
        {
            SetMenuCheckMarks(sender);
            _flipX = false;
            _flipY = true;
        }

        #endregion

        #region Opacity

        // Opacity - 25%
        private void Opacity25_MenuItem_Click(object sender, EventArgs e)
        {
            SetMenuCheckMarks(sender);
            Opacity = 0.25;
            opacityMenuItem.Checked = true;
        }

        // Opacity - 50%
        private void Opacity50_MenuItem_Click(object sender, EventArgs e)
        {
            SetMenuCheckMarks(sender);
            Opacity = 0.50;
            opacityMenuItem.Checked = true;
        }

        // Opacity - 75%
        private void Opacity75_MenuItem_Click(object sender, EventArgs e)
        {
            SetMenuCheckMarks(sender);
            Opacity = 0.75;
            opacityMenuItem.Checked = true;
        }

        // Opacity - 100%
        private void Opacity100_MenuItem_Click(object sender, EventArgs e)
        {
            SetMenuCheckMarks(sender);
            Opacity = 1;
            opacityMenuItem.Checked = false;
        }

        #endregion

        #region Refresh Rate

        // Refresh Rate - 1 fps
        private void Fps01_MenuItem_Click(object sender, EventArgs e)
        {
            SetMenuCheckMarks(sender);
            _timer.Interval = FPS01;
        }

        // Refresh Rate - 2 fps
        private void Fps02_MenuItem_Click(object sender, EventArgs e)
        {
            SetMenuCheckMarks(sender);
            _timer.Interval = FPS02;
        }

        // Refresh Rate - 5 fps
        private void Fps05_MenuItem_Click(object sender, EventArgs e)
        {
            SetMenuCheckMarks(sender);
            _timer.Interval = FPS05;
        }

        // Refresh Rate - 10 fps
        private void Fps10_MenuItem_Click(object sender, EventArgs e)
        {
            SetMenuCheckMarks(sender);
            _timer.Interval = FPS10;
        }

        // Refresh Rate - 15 fps
        private void Fps15_MenuItem_Click(object sender, EventArgs e)
        {
            SetMenuCheckMarks(sender);
            _timer.Interval = FPS15;
        }

        // Refresh Rate - 20 fps
        private void Fps20_MenuItem_Click(object sender, EventArgs e)
        {
            SetMenuCheckMarks(sender);
            _timer.Interval = FPS20;
        }

        // Refresh Rate - 25 fps
        private void Fps25_MenuItem_Click(object sender, EventArgs e)
        {
            SetMenuCheckMarks(sender);
            _timer.Interval = FPS25;
        }

        // Refresh Rate - 30 fps
        private void Fps30_MenuItem_Click(object sender, EventArgs e)
        {
            SetMenuCheckMarks(sender);
            _timer.Interval = FPS30;
        }

        // Refresh Rate - 40 fps
        private void Fps40_MenuItem_Click(object sender, EventArgs e)
        {
            SetMenuCheckMarks(sender);
            _timer.Interval = FPS40;
        }

        // Refresh Rate - 50 fps
        private void Fps50_MenuItem_Click(object sender, EventArgs e)
        {
            SetMenuCheckMarks(sender);
            _timer.Interval = FPS50;
        }

        // Refresh Rate - 60 fps
        private void Fps60_MenuItem_Click(object sender, EventArgs e)
        {
            SetMenuCheckMarks(sender);
            _timer.Interval = FPS60;
        }

        #endregion

        // Removes the check marks from a contextmenu items and checks the selected item
        private void SetMenuCheckMarks(object sender)
        {
            foreach (ToolStripItem item in (((ToolStripMenuItem)sender).GetCurrentParent().Items))
            {
                if (item.GetType() == typeof(ToolStripMenuItem))
                {
                    ((ToolStripMenuItem)item).Checked = item == sender;
                }
            }
        }

        #endregion

        // ******************************** Puzzle

        #region Puzzle

        private void NewPuzzleMenuItem_Click(object sender, EventArgs e)
        {
            if (_puzzleOn)
            {
                StopPuzzle();
                MouseDown += _basePlayer.Display.Drag_MouseDown;
            }
            else
            {
                MouseDown -= _basePlayer.Display.Drag_MouseDown;
                StartPuzzle();
            }
        }

        private void ShowGridMenuItem_Click(object sender, EventArgs e)
        {
            _gridOn = showGridMenuItem.Checked = !_gridOn;
        }

        private void ShowIndicatorsMenuItem_Click(object sender, EventArgs e)
        {
            _indicatorsOn = showIndicatorsMenuItem.Checked = !_indicatorsOn;
        }

        private void StartPuzzle()
        {
            _baseForm.SetWindowDrag(false);

            _selectionOn = false;

            // create (new) array
            _puzzleArray = new int[_horizontalTiles * _verticalTiles];

            // fill array
            for (int i = 0; i < _puzzleArray.Length; i++)
            {
                _puzzleArray[i] = i;
            }

            // shuffle array
            Random r = new Random();
            bool shuffled = false;
            int retryCount = 10;
            while (!shuffled && retryCount-- > 0)
            {
                int n = _puzzleArray.Length;
                while (n > 0)
                {
                    int k = r.Next(n--);
                    int temp = _puzzleArray[k];
                    _puzzleArray[k] = _puzzleArray[n];
                    _puzzleArray[n] = temp;
                }

                for (int i = 0; i < _puzzleArray.Length; i++)
                {
                    if (_puzzleArray[i] != i)
                    {
                        shuffled = true;
                        break;
                    }
                }
            }

            _solved = false;
            _puzzleOn = true;

            newPuzzleMenuItem.Text = "Stop Puzzle";
            Cursor = Cursors.Hand;
        }

        private void StopPuzzle()
        {
            _puzzleOn = false;
            _selectionOn = false;
            newPuzzleMenuItem.Text = "Start Puzzle";
            Cursor = Cursors.Default;

            _baseForm.SetWindowDrag(true);
        }

        private void TilesOverlay_MouseDown(object sender, MouseEventArgs e)
        {
            if (_running && _puzzleOn && !_solved && e.Button == MouseButtons.Left)
            {
                int index = _basePlayer.Overlay.Mode == OverlayMode.Video ?
                    ((e.Y / (Height / _verticalTiles)) * _horizontalTiles) + (e.X / (Width / _horizontalTiles)) :
                    (((e.Y - _basePlayer.Video.Bounds.Y) / (_basePlayer.Video.Bounds.Height / _verticalTiles)) * _horizontalTiles) + ((e.X - _basePlayer.Video.Bounds.X) / (_basePlayer.Video.Bounds.Width / _horizontalTiles));

                if ((index >= 0 && index < _puzzleArray.Length) && !(_indicatorsOn && _puzzleArray[index] == index))
                {
                    if (_selectionOn)
                    {
                        // Swap tiles
                        _selectionOn = false;
                        if (index != _selectedIndex)
                        {
                            SwapTiles(index);
                        }
                    }
                    else
                    {
                        // Select tile
                        _selectedIndex = index;
                        _selectionOn = true;
                    }
                }
            }
        }

        private void SwapTiles(int index)
        {
            // Only called from TileOverlay_MouseDown
            // 'checks' are done at TileOverlay_MouseDown

            int swap = _puzzleArray[_selectedIndex];
            _puzzleArray[_selectedIndex] = _puzzleArray[index];
            _puzzleArray[index] = swap;

            // swap - do something 'graphical' ?

            // test if picture completed
            bool completed = true;
            for (int i = 0; i < _puzzleArray.Length; i++)
            {
                if (_puzzleArray[i] != i)
                {
                    completed = false;
                    break;
                }
            }

            if (completed)
            {
                _solved = true;
                _selectionOn = false;
                Cursor = Cursors.Default;

                if (ShowPuzzleDialog() == DialogResult.OK) StartPuzzle();
                else StopPuzzle();
            }
        }

        private DialogResult ShowPuzzleDialog()
        {
            PuzzleDialog puzzleMessage = new PuzzleDialog();
            MainWindow.CenterDialog(this, puzzleMessage);
            DialogResult result = puzzleMessage.ShowDialog(this);
            puzzleMessage.Dispose();
            return result;
        }

        #endregion
    }
}
