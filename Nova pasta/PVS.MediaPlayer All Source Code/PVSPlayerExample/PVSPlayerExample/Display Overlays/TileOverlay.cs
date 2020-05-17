#region Usings

using PVS.AVPlayer;
using System;
using System.Drawing;
using System.Security;
using System.Security.Permissions;
using System.Windows.Forms;

#endregion

namespace AVPlayerExample
{
    public partial class TileOverlay : Form, IOverlay
    {
        /*
        
        PVS.AVPlayer Display Overlay - Example 'Tiles'
        Displays video as tiles.

        This overlay copies the video from the player's display
        to a bitmap that is used to draw tiles on the overlay (using Win32 BitBlt).
        
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
        private Form1       _baseForm;
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

        private bool        _disposed;

        #endregion

        // ******************************** Initializing / Form & Player eventhandling

        #region Initializing and Form & Player eventhandling

        public TileOverlay(Form1 baseForm, Player basePlayer)
        {
            InitializeComponent();

            _baseForm = baseForm;
            _basePlayer = basePlayer;

            // Pass on drag and drop to main form (handled in source file: DragDrop.cs):
            AllowDrop = true;
            //DragEnter += _baseForm.Form1_DragEnter;
            DragDrop += _baseForm.Form1_DragDrop;

            _timer = new Timer {Interval = TIMER_INTERVAL};
            _timer.Tick += TimerTick;
        }

        private void TileOverlay_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                if (!_hasEvents)
                {
                    _basePlayer.MediaStarted += basePlayer_MediaStarted;
                    _basePlayer.MediaDisplayModeChanged += basePlayer_MediaDisplayModeChanged;
                    _hasEvents = true;
                }
                if (!_running)
                {
                    if (_basePlayer.VideoPresent)
                    {
                        SetBitmap(true);
                        _timer.Start();
                        _running = true;
                    }
                }
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
                    _basePlayer.MediaStarted -= basePlayer_MediaStarted;
                    _basePlayer.MediaDisplayModeChanged -= basePlayer_MediaDisplayModeChanged;
                    _hasEvents = false;
                }
            }
        }

        private void TileOverlay_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized) _timer.Stop();
            else if (_running)
            {
                SetBitmap(true);
                if (!_timer.Enabled) _timer.Start();
                TimerTick(this, EventArgs.Empty);
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
                        _basePlayer.MediaStarted -= basePlayer_MediaStarted;
                        _basePlayer.MediaDisplayModeChanged -= basePlayer_MediaDisplayModeChanged;
                        _hasEvents = false;
                    }

                    _timer.Dispose(); _timer = null;
                    if (_bitmap1 != null)
                    {
                        _bitmap1.Dispose();
                        _bitmap1 = null;
                    }
                    _basePlayer = null;

                    DragEnter -= _baseForm.Form1_DragEnter;
                    DragDrop -= _baseForm.Form1_DragDrop;
                    _baseForm = null;

                    if (components != null) components.Dispose();
                }
                base.Dispose(disposing);
                _disposed = true;
            }
        }

        void basePlayer_MediaStarted(object sender, EventArgs e)
        {
            if (!_running && _basePlayer.VideoPresent)
            {
                if (WindowState != FormWindowState.Minimized)
                {
                    SetBitmap(true);
                    _timer.Start();
                }
                _running = true;
            }
        }

        void basePlayer_MediaDisplayModeChanged(object sender, EventArgs e)
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

            _sourceGraphics = _basePlayer.Display.CreateGraphics();
            _sourceHdc = _sourceGraphics.GetHdc();

            _sourceBounds = _videoBoundsMode ? Rectangle.Intersect(_basePlayer.VideoBounds, _basePlayer.Display.DisplayRectangle) : _basePlayer.Display.DisplayRectangle;

            SafeNativeMethods.SetStretchBltMode(_bitmapHdc, STRETCH_HALFTONE);
            if (SafeNativeMethods.StretchBlt(_bitmapHdc, _baseX, _baseY, _baseWidth, _baseHeight, _sourceHdc, _sourceBounds.Left, _sourceBounds.Top, _sourceBounds.Width, _sourceBounds.Height, 0x00CC0020U))
            {
                _sourceGraphics.ReleaseHdc(_sourceHdc);
                _sourceGraphics.Dispose();

                _destinationGraphics = CreateGraphics();
                _destinationHdc = _destinationGraphics.GetHdc();

                _xPos = _yPos = 0;

                for (int i = 0; i < _verticalTiles; i++)
                {
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

            _busy = false;
        }

        #endregion

        // ******************************** 'Set' button

        #region 'Set' button

        // 'Set' button
        private void setButton_Click(object sender, EventArgs e)
        {
            _horizontalTiles = (int)numericUpDown1.Value;
            _verticalTiles = (int)numericUpDown2.Value;
            if (_running) SetBitmap(true);
            Invalidate();
        }

        #endregion

        // ******************************** Options menu handling

        #region Options menu handling

        // Set focus to input tiles when closed
        private void optionsMenu_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            numericUpDown1.Focus();
        }

        // TileSource - Video
        private void videoMenuItem_Click(object sender, EventArgs e)
        {
            SetMenuCheckMarks(sender);
            _videoBoundsMode = true;
            if (_running) SetBitmap(true);
            Invalidate();

        }

        // TileSource - Display
        private void displayMenuItem_Click(object sender, EventArgs e)
        {
            SetMenuCheckMarks(sender);
            _videoBoundsMode = false;
            if (_running) SetBitmap(true);
            Invalidate();
        }

        #region Base Tile

        // BaseTile - Normal
        private void baseNormalMenuItem_Click(object sender, EventArgs e)
        {
            SetMenuCheckMarks(sender);
            _baseFlipX = false;
            _baseFlipY = false;
            SetBaseTile();
        }

        // BaseTile - FlipX
        private void baseFlipXMenuItem_Click(object sender, EventArgs e)
        {
            SetMenuCheckMarks(sender);
            _baseFlipX = true;
            _baseFlipY = false;
            SetBaseTile();
        }

        // BaseTile - FlipXY
        private void baseFlipXYMenuItem_Click(object sender, EventArgs e)
        {
            SetMenuCheckMarks(sender);
            _baseFlipX = true;
            _baseFlipY = true;
            SetBaseTile();
        }

        // BaseTile - FlipY
        private void baseFlipYMenuItem_Click(object sender, EventArgs e)
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
        private void tileNormalMenuItem_Click(object sender, EventArgs e)
        {
            SetMenuCheckMarks(sender);
            _flipX = false;
            _flipY = false;
        }

        // TileMode - TileFlipX
        private void tileFlipXMenuItem_Click(object sender, EventArgs e)
        {
            SetMenuCheckMarks(sender);
            _flipX = true;
            _flipY = false;
        }

        // TileMode - TileFlipXY
        private void tileFlipXYMenuItem_Click(object sender, EventArgs e)
        {
            SetMenuCheckMarks(sender);
            _flipX = true;
            _flipY = true;
        }

        // TileMode - TileFlipY
        private void tileFlipYMenuItem_Click(object sender, EventArgs e)
        {
            SetMenuCheckMarks(sender);
            _flipX = false;
            _flipY = true;
        }

        #endregion

        #region Opacity

        // Opacity - 25%
        private void opacity25_MenuItem_Click(object sender, EventArgs e)
        {
            SetMenuCheckMarks(sender);
            Opacity = 0.25;
        }

        // Opacity - 50%
        private void opacity50_MenuItem_Click(object sender, EventArgs e)
        {
            SetMenuCheckMarks(sender);
            Opacity = 0.50;
        }

        // Opacity - 75%
        private void opacity75_MenuItem_Click(object sender, EventArgs e)
        {
            SetMenuCheckMarks(sender);
            Opacity = 0.75;
        }

        // Opacity - 100%
        private void opacity100_MenuItem_Click(object sender, EventArgs e)
        {
            SetMenuCheckMarks(sender);
            Opacity = 1;
        }

        #endregion

        #region Refresh Rate

        // Refresh Rate - 1 fps
        private void fps01_MenuItem_Click(object sender, EventArgs e)
        {
            SetMenuCheckMarks(sender);
            _timer.Interval = FPS01;
        }

        // Refresh Rate - 2 fps
        private void fps02_MenuItem_Click(object sender, EventArgs e)
        {
            SetMenuCheckMarks(sender);
            _timer.Interval = FPS02;
        }

        // Refresh Rate - 5 fps
        private void fps05_MenuItem_Click(object sender, EventArgs e)
        {
            SetMenuCheckMarks(sender);
            _timer.Interval = FPS05;
        }

        // Refresh Rate - 10 fps
        private void fps10_MenuItem_Click(object sender, EventArgs e)
        {
            SetMenuCheckMarks(sender);
            _timer.Interval = FPS10;
        }

        // Refresh Rate - 15 fps
        private void fps15_MenuItem_Click(object sender, EventArgs e)
        {
            SetMenuCheckMarks(sender);
            _timer.Interval = FPS15;
        }

        // Refresh Rate - 20 fps
        private void fps20_MenuItem_Click(object sender, EventArgs e)
        {
            SetMenuCheckMarks(sender);
            _timer.Interval = FPS20;
        }

        // Refresh Rate - 25 fps
        private void fps25_MenuItem_Click(object sender, EventArgs e)
        {
            SetMenuCheckMarks(sender);
            _timer.Interval = FPS25;
        }

        // Refresh Rate - 30 fps
        private void fps30_MenuItem_Click(object sender, EventArgs e)
        {
            SetMenuCheckMarks(sender);
            _timer.Interval = FPS30;
        }

        // Refresh Rate - 40 fps
        private void fps40_MenuItem_Click(object sender, EventArgs e)
        {
            SetMenuCheckMarks(sender);
            _timer.Interval = FPS40;
        }

        // Refresh Rate - 50 fps
        private void fps50_MenuItem_Click(object sender, EventArgs e)
        {
            SetMenuCheckMarks(sender);
            _timer.Interval = FPS50;
        }

        // Refresh Rate - 60 fps
        private void fps60_MenuItem_Click(object sender, EventArgs e)
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
    }
}
