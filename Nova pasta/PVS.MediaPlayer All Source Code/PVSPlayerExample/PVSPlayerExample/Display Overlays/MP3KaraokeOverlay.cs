#region Usings

using PVS.MediaPlayer;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

#endregion

namespace PVSPlayerExample
{
    /*
    
    PVS.MediaPlayer Display Overlay - Example 'MP3 Karaoke'
    Displays CD+G graphics (if available) when an mp3 mediafile is being played, the cdg-files must have the same name as
    the playing mediafile (but with the extension .cdg) and be in the same directory.

    About decoding CD+G graphics:
    Thanks to Jim Bumgardner (http://jbum.com/cdg_revealed.html)
    Thanks to Nikolay Nikolov (http://cdg2video.googlecode.com/svn/trunk/cdgfile.cpp)
    
    */

    public sealed partial class Mp3KaraokeOverlay : Form, IOverlay
    {
        // ************************************ Fields

        #region Fields

        #region Constants

        // Sizes 1
        private const int   CDG_FULL_WIDTH = 300;
        private const int   CDG_FULL_HEIGHT = 216;
        private const int   CDG_DISPLAY_WIDTH = 288;
        private const int   CDG_DISPLAY_HEIGHT = 192;
        private const int   CDG_BORDER_WIDTH = 6;
        private const int   CDG_BORDER_HEIGHT = 12;

        // Sizes 2
        private const int   CDG_TILE_WIDTH = 6;
        private const int   CDG_TILE_HEIGHT = 12;
        private const int   CDG_PACKET_SIZE = 24;
        private const int   CDG_COLORPALETTE_SIZE = 16;
        private const int   CDG_PIXEL_SIZE = 4;

        // CDG Command and Instruction Codes
        private const int   CDG_COMMAND = 0x09;
        private const int   CDG_MEMORY_PRESET = 1;
        private const int   CDG_BORDER_PRESET = 2;
        private const int   CDG_TILE_BLOCK = 6;
        private const int   CDG_SCROLL_PRESET = 20;
        private const int   CDG_SCROLL_COPY = 24;
        private const int   CDG_TRANSPARANT_COLOR = 28;
        private const int   CDG_COLOR_PALETTE_LOW = 30;
        private const int   CDG_COLOR_PALETTE_HIGH = 31;
        private const int   CDG_TILE_BLOCK_XOR = 38;

        // Bitmasks
        private const int   CDG_MASK = 0x3F;
        private const int   LOW_NIBBLE_MASK = 0x0F;
        private const int   HIGH_NIBBLE_MASK = 0xF0;

        // cdgIndex Offsets
        private const int   INSTRUCTION_OFFSET = 1;
        private const int   PARITYQ_OFFSET = 2;
        private const int   DATA_OFFSET = 4;
        private const int   PARITYP_OFFSET = 20;

        // cdgData Offsets
        private const int   REPEAT_OFFSET = DATA_OFFSET + 1;

        #endregion

        private MainWindow  _baseForm;
        private Player      _basePlayer;
        private bool        _playerMode;

        // as cdg files are usually less than 2 MB, they're loaded entirely into memory for performance
        private byte[]      _cdgFile;               // the cdg file in memory
        private int         _cdgFileLenght;         // the lenght of the cdg file in memory
        private int         _cdgIndex;              // index pointer to cdg file in memory (cdg packets)
        private bool        _busy;                  // cdg packets are being processed

        // Bitmaps
        private Bitmap      _backBuffer;            // off-screen buffer
        private Bitmap      _cdgImage;              // the cdg bitmap to display
        private Rectangle   _backZoomRect;          // background image zoom rect
        private Rectangle   _cdgImageRect;          // cdgImage size rect
        private Rectangle   _cdgZoomRect;           // cdgImage zoom rect
        private Region      _eraseRgn;              // used with OnPaintBackground

        private bool        _backOpaqueMode = true;
        private SolidBrush  _backColorBrush;
        private bool        _backImageMode;         // use background image
        private Bitmap      _backImage;             // background image
        private bool        _backTransparentMode;   // transparent cdgImage

        private bool        _cdgImageStretch;       // cdgImage stretch or zoom
        private bool        _backStretch;           // background image stretch or zoom
        private bool        _backMatch;             // background image size is same as cdgImage size (with backImageStretch)

        // Graphics - used with copying bitmaps (Bitblt)
        private Graphics    _cdgImageGraphics;
        private Graphics    _backBufferGraphics;
        private Graphics    _backImageGraphics;
        private Graphics    _screenGraphics;

        // Hdc - device contexts - used with copying bitmaps (Bitblt)
        private IntPtr      _cdgImageHdc = IntPtr.Zero;
        private IntPtr      _backBufferHdc = IntPtr.Zero;
        private IntPtr      _backImageHdc = IntPtr.Zero;
        private IntPtr      _screenHdc = IntPtr.Zero;

        private IntPtr      _cdgBitmapHbitmap;
        private IntPtr      _cdgBitmapOldObject;
        private IntPtr      _backBufferHbitmap;
        private IntPtr      _backBufferOldObject;
        private IntPtr      _backImageHbitmap;
        private IntPtr      _backImageOldObject;

        // Colorsystem
        private Color[]     _cdgColorPalette;       // color palette
        private byte[,]     _cdgColorTable;         // color table display + border

        private int         _presetColorIndex;      // cdg background color
        private int         _borderColorIndex;      // border color
        private int         _transparentColorIndex; // not used here (but may be set by a cdg instruction)

        private int         _cdgTransparentColor;

        // Active display
        private bool        _processing;            // a cdg file is being processed (by timer or mp3 playing)

        // Timer
        private Timer       _cdgTimer;
        private int         _playbackPosition;
        private const int   CDG_TIMER_INTERVAL = 80;

        // Open file initial directory
        private string      _openCdgFilePath;
        private string      _openImageFilePath;

        private bool        _disposed;

        #endregion

        // ************************************ Main

        #region Main

        public Mp3KaraokeOverlay(MainWindow theForm, Player thePlayer)
        {
            InitializeComponent();

            _baseForm           = theForm;
            _basePlayer         = thePlayer;

            _backColorBrush     = new SolidBrush(Color.Black);
            _eraseRgn           = new Region(ClientRectangle);
            _openCdgFilePath    = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
            _openImageFilePath  = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
        }

        protected override bool ShowWithoutActivation
        {
            get { return true; }
        }

        // Don't activate form with mouse click
        protected override void WndProc(ref Message m)
        {
            const int WM_MOUSEACTIVATE  = 0x0021;
            const int MA_NOACTIVATE     = 0x0003;

            if (m.Msg == WM_MOUSEACTIVATE) m.Result = (IntPtr)MA_NOACTIVATE;
            else base.WndProc(ref m);
        }

        private void MP3KaraokeOverlay_Paint(object sender, PaintEventArgs e)
        {
            if (_processing) CdgPaint();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            if (!_processing) base.OnPaintBackground(e);
            else if (_backOpaqueMode && !_cdgImageStretch)
            {
                _eraseRgn.MakeEmpty();
                _eraseRgn.Union(ClientRectangle);
                _eraseRgn.Exclude(_cdgZoomRect);
                e.Graphics.FillRegion(_backColorBrush, _eraseRgn);
            }
        }

        private void MP3KaraokeOverlay_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                if (_processing) return;

                _basePlayer.Events.MediaStarted         += BasePlayer_MediaStarted;
                _basePlayer.Events.MediaPausedChanged   += BasePlayer_MediaPausedResumed;

                if (_basePlayer.Playing
                    && (_basePlayer.Media.GetName(MediaName.FileName).EndsWith(".mp3", StringComparison.OrdinalIgnoreCase)
                    || _basePlayer.Media.GetName(MediaName.FileName).EndsWith(".wma", StringComparison.OrdinalIgnoreCase)))
                {
                    if (_processing) StopProcess();
                    if (GetCdgFile())
                    {
                        _playerMode = true;
                        StartProcess();
                        if (_basePlayer.Paused) SetPlayerPausedMode();
                    }
                }
                else label1.Show();

                MouseDown += _basePlayer.Display.Drag_MouseDown;
            }
            else
            {
                if (_processing) StopProcess();
                _basePlayer.Events.MediaStarted         -= BasePlayer_MediaStarted;
                _basePlayer.Events.MediaPausedChanged   -= BasePlayer_MediaPausedResumed;
                SizeChanged                             -= Form1_SizeChanged;
                MouseDown                               -= _basePlayer.Display.Drag_MouseDown;
            }
        }

        private void BasePlayer_MediaStarted(object sender, EventArgs e)
        {
            if (_processing) StopProcess();

            if (!_basePlayer.Media.GetName(MediaName.FileName).EndsWith(".mp3", StringComparison.OrdinalIgnoreCase) &&
                !_basePlayer.Media.GetName(MediaName.FileName).EndsWith(".wma", StringComparison.OrdinalIgnoreCase)) return;

            if (GetCdgFile())
            {
                _playerMode = true;
                StartProcess();
                if (_basePlayer.Paused) SetPlayerPausedMode();
            }
        }

        private void BasePlayer_MediaPausedResumed(object sender, EventArgs e)
        {
            SetPlayerPausedMode();
        }

        private void SetPlayerPausedMode()
        {
            if (_processing && _playerMode)
            {
                if (_basePlayer.Paused)
                {
                    _cdgTimer.Stop();
                    _basePlayer.Events.MediaPositionChanged += CdgTimer_Tick;
                }
                else
                {
                    _basePlayer.Events.MediaPositionChanged -= CdgTimer_Tick;
                    _cdgTimer.Start();
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    StopProcess();
                    if (_backImage != null)
                    {
                        _backImage.Dispose(); _backImage = null;
                        _backColorBrush.Dispose(); _backColorBrush = null;
                    }
                    _eraseRgn.Dispose(); _eraseRgn = null;
                    _basePlayer = null;

                    if (components != null) components.Dispose();
                }
                _disposed = true;
            }
            base.Dispose(disposing);
        }

        private bool GetCdgFile()
        {
            bool result = false;

            string path = _baseForm.SearchFile.Find(_basePlayer.Media.GetName(MediaName.FileNameWithoutExtension) + ".cdg", _basePlayer.Media.GetName(MediaName.DirectoryName), MainWindow.SEARCH_DEPTH);
            if (!string.IsNullOrEmpty(path))
            {
                try
                {
                    _cdgFile = File.ReadAllBytes(path);
                    _cdgFileLenght = _cdgFile.Length;
                    if (_cdgFileLenght % CDG_PACKET_SIZE == 0)
                    {
                        result = true;
                    }
                    else
                    {
                        _cdgFile = null;
                        _cdgFileLenght = 0;
                    }
                }
                catch { }
            }
            if (result) label1.Hide();
            else label1.Show();
            return result;
        }

        private bool GetCdgFile(string fileName)
        {
            bool result = false;

            if (File.Exists(fileName))
            {
                try
                {
                    _cdgFile = File.ReadAllBytes(fileName);
                    _cdgFileLenght = _cdgFile.Length;
                    if (_cdgFileLenght % CDG_PACKET_SIZE == 0)
                    {
                        result = true;
                    }
                    else
                    {
                        _cdgFile = null;
                        _cdgFileLenght = 0;
                    }
                }
                catch { }
            }
            if (result) label1.Hide();
            else label1.Show();
            return result;
        }

        #endregion

        // ******************************** Options Menu

        #region Options Menu

        // Foreground Size Mode: Stretch
        private void StretchMenuItem_Click(object sender, EventArgs e)
        {
            stretchMenuItem.Checked = true;
            zoomMenuItem.Checked = false;
            _cdgImageStretch = true;
            if (_processing)
            {
                CalculateZoom();
                CdgPaint();
            }
        }

        // Foreground Size Mode: Zoom
        private void ZoomMenuItem_Click(object sender, EventArgs e)
        {
            stretchMenuItem.Checked = false;
            zoomMenuItem.Checked = true;
            _cdgImageStretch = false;
            if (_processing)
            {
                CalculateZoom();
                if (_backOpaqueMode) Invalidate();
                else CdgPaint();
            }
        }

        // Background: Color
        private void ColorMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog {Color = _backColorBrush.Color};
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                ResetBackImageMode();
                _backColorBrush.Color = dlg.Color;
                _backTransparentMode = false;
                _backOpaqueMode = false;
                SetCheckMarks(colorMenuItem);
                if (_processing) CdgPaint(); // this.Invalidate();
            }
            dlg.Dispose();
        }

        // Background: Image
        private void ImageMenuItem_Click(object sender, EventArgs e)
        {
            bool result = false;
            Bitmap newBitmap = null;

            OpenFileDialog dlg = new OpenFileDialog
            {
                Title = "Open \"MP3 Karaoke\" Background Image",
                InitialDirectory = _openImageFilePath
            };
            dlg.CheckFileExists = dlg.CheckPathExists = true;
            dlg.Filter = "Images|*.bmp;*.jpg;*.jpeg;*.gif;*.tif;*.tiff;*.png|All Files|*.*";

            while (!result)
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    dlg.InitialDirectory = _openImageFilePath = Path.GetDirectoryName(dlg.FileName);
                    try
                    {
                        newBitmap = new Bitmap(dlg.FileName);
                        result = true;
                    }
                    catch
                    {
                        MessageBox.Show("\"" + Path.GetFileName(dlg.FileName) + "\" is not a valid Image file.\n\rPlease try another file...", dlg.Title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dlg.FileName = string.Empty;
                    }

                    if (result)
                    {
                        //backColorMode = false;
                        _backTransparentMode = false;
                        _backOpaqueMode = false;
                        ResetBackImageMode();
                        _backImage = newBitmap;
                        _backImageGraphics = Graphics.FromImage(_backImage);
                        _backImageMode = true;
                        SetCheckMarks(imageMenuItem);
                        CalculateZoom();
                        if (_processing) CdgPaint(); // this.Invalidate();
                    }
                }
                else result = true;
            }
            dlg.Dispose();
        }

        // Background: Transparent
        private void TransparentMenuItem_Click(object sender, EventArgs e)
        {
            ResetBackImageMode();
            _backTransparentMode = true;
            _backOpaqueMode = false;
            SetCheckMarks(transparentMenuItem);
            if (_processing) CdgPaint(); // this.Invalidate();
        }

        // Background: Normal
        private void NormalMenuItem_Click(object sender, EventArgs e)
        {
            if (_backImageMode)
            {
                _backImageMode = false;
                _backImage.Dispose();
                _backImage = null;
                _backImageGraphics = null;
            }
            SetCheckMarks(normalMenuItem);
            if (_processing)
            {
                _backOpaqueMode = false;
                _backColorBrush.Color = Color.RosyBrown;
                CdgPaint();
            }
            else
            {
                _backTransparentMode = false;
            }
            _backOpaqueMode = true;
        }

        // Background Size Mode: Stretch
        private void BgStretchMenuItem_Click(object sender, EventArgs e)
        {
            _backStretch = true;
            _backMatch = false;
            SetCheckMarks(bgStretchMenuItem);
            if (_processing) CdgPaint(); // this.Invalidate();
        }

        // Background Size Mode: Zoom
        private void BgZoomMenuItem_Click(object sender, EventArgs e)
        {
            _backStretch = false;
            _backMatch = false;
            SetCheckMarks(bgZoomMenuItem);
            if (_processing) CdgPaint(); // this.Invalidate();
        }

        // Background Size Mode: Match Foreground
        private void BgMatchForegroundMenuItem_Click(object sender, EventArgs e)
        {
            _backStretch = false;
            _backMatch = true;
            SetCheckMarks(bgMatchForegroundMenuItem);
            if (_processing) CdgPaint(); // this.Invalidate();
        }

        // Play Karaoke File
        private void PlayCDGFileMenuItem_Click(object sender, EventArgs e)
        {
            bool result = false;

            if (_processing && _playerMode == false)
            {
                StopProcess();
            }
            else
            {
                OpenFileDialog dlg = new OpenFileDialog
                {
                    Title = "Open \"MP3 Karaoke\" File",
                    InitialDirectory = _openCdgFilePath
                };
                dlg.CheckFileExists = dlg.CheckPathExists = true;
                dlg.Filter = "Karaoke Files|*.cdg";

                while (!result)
                {
                    if (dlg.ShowDialog(this) == DialogResult.OK)
                    {
                        dlg.InitialDirectory = _openCdgFilePath = Path.GetDirectoryName(dlg.FileName);
                        if (GetCdgFile(dlg.FileName))
                        {
                            result = true;
                        }
                        else
                        {
                            MessageBox.Show("\"" + Path.GetFileName(dlg.FileName) + "\" is not a valid Karaoke file.\n\rPlease try another file...", dlg.Title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dlg.FileName = string.Empty;
                        }

                        if (result)
                        {
                            _playerMode = false;
                            playCDGFileMenuItem.Text = "Stop Karaoke File";
                            StartProcess();
                        }
                    }
                    else result = true;
                }
                dlg.Dispose();
            }
        }

        // Helper methods

        // Checks the selected menu item and removes the check marks from the others
        private void SetCheckMarks(object sender)
        {
            foreach (ToolStripItem item in (((ToolStripMenuItem)sender).GetCurrentParent().Items))
            {
                if (item.GetType() == typeof(ToolStripMenuItem))
                {
                    ((ToolStripMenuItem)item).Checked = item == sender;
                }
            }

            if (_backOpaqueMode || _backTransparentMode)
            {
                backModeMenuItem.Enabled = false;
                bgZoomMenuItem.Enabled = false;
                bgStretchMenuItem.Enabled = false;
                bgMatchForegroundMenuItem.Enabled = false;
            }
            else
            {
                backModeMenuItem.Enabled = true;
                bgZoomMenuItem.Enabled = true;
                bgStretchMenuItem.Enabled = true;
                bgMatchForegroundMenuItem.Enabled = true;
            }
        }

        // Set Background: Image Off
        private void ResetBackImageMode()
        {
            if (_backImageMode)
            {
                _backImageMode = false;
                _backImage.Dispose();
                _backImage = null;
                _backImageGraphics = null;
            }
        }

        #endregion

        // ******************************** IOverlay Control

        #region IOverlay Control

        // The visibility of the menu is controlled by the user from the main application (in this example application)
        public bool MenuEnabled
        {
            // not much to do here
            get { return optionsPanel.Visible; }
            set { optionsPanel.Visible = value; }
        }

        public bool HasMenu
        {
            get { return true; }
        }

        public void MediaStopped()
        {
            if (_processing && _playerMode) StopProcess();
        }

        #endregion

        // ******************************** Start / Stop Process

        #region Start / Stop Process

        private void StartProcess()
        {
            Cdg_Init();

            _playbackPosition = 0;
            _cdgIndex = 0;

            _processing = true;
            _cdgTimer.Start();
        }

        private void StopProcess()
        {
            if (_processing)
            {
                // stop process
                _processing = false;
                SizeChanged -= Form1_SizeChanged;
                _basePlayer.Events.MediaPositionChanged -= CdgTimer_Tick;

                _cdgTimer.Stop();
                _cdgTimer.Dispose();
                _cdgTimer = null;

                // clear graphics
                if (_cdgImageGraphics != null)
                {
                    _cdgImageGraphics.Dispose();
                    _cdgImageGraphics = null;
                }
                if (_backBufferGraphics != null)
                {
                    _backBufferGraphics.Dispose();
                    _backBufferGraphics = null;
                }
                if (_backImageGraphics != null)
                {
                    _backImageGraphics.Dispose();
                    _backImageGraphics = null;
                }
                if (_screenGraphics != null)
                {
                    _screenGraphics.Dispose();
                    _screenGraphics = null;
                }

                // clear displays
                if (_cdgImage != null)
                {
                    _cdgImage.Dispose();
                    _cdgImage = null;
                }
                if (_backBuffer != null)
                {
                    _backBuffer.Dispose();
                    _backBuffer = null;
                }

                // remove cdg file
                _cdgFile = null;
                _cdgFileLenght = 0;
                _cdgColorPalette = null;
                _cdgColorTable = null;

                playCDGFileMenuItem.Text = "Play Karaoke File…";

                Invalidate(ClientRectangle);
            }
        }

        #endregion

        // ******************************** CDG Initialization

        #region CDG Initialization

        private void Cdg_Init()
        {
            InitDisplay();
            InitColorPalette();
            InitColorTable();
            InitTimer();
            SizeChanged += Form1_SizeChanged;
        }

        private void InitDisplay()
        {
            if (_cdgImage == null)
            {
                _cdgImage = new Bitmap(CDG_DISPLAY_WIDTH, CDG_DISPLAY_HEIGHT, PixelFormat.Format32bppArgb);
                _cdgImageGraphics = Graphics.FromImage(_cdgImage);
                _cdgImageRect = new Rectangle(0, 0, CDG_DISPLAY_WIDTH, CDG_DISPLAY_HEIGHT);

                _backBuffer = new Bitmap(ClientRectangle.Width, ClientRectangle.Height, PixelFormat.Format32bppArgb);
                _backBufferGraphics = Graphics.FromImage(_backBuffer);

                _screenGraphics = CreateGraphics();

                if (_backImageMode) _backImageGraphics = Graphics.FromImage(_backImage);

            }
            _cdgImageGraphics.FillRectangle(Brushes.Black, _cdgImageRect);
            CalculateZoom();
        }

        private void InitTimer()
        {
            if (_cdgTimer == null)
            {
                _cdgTimer = new Timer {Interval = CDG_TIMER_INTERVAL};
                _cdgTimer.Tick += CdgTimer_Tick;
            }
        }

        private void InitColorPalette()
        {
            if (_cdgColorPalette == null) _cdgColorPalette = new Color[CDG_COLORPALETTE_SIZE];
            for (int i = 0; i < CDG_COLORPALETTE_SIZE; ++i) _cdgColorPalette[i] = Color.Black;
        }

        private void InitColorTable()
        {
            if (_cdgColorTable == null) _cdgColorTable = new byte[CDG_FULL_WIDTH, CDG_FULL_HEIGHT];
            for (int y = 0; y < CDG_FULL_HEIGHT; ++y)
            {
                for (int x = 0; x < CDG_FULL_WIDTH; ++x) _cdgColorTable[x, y] = 0;
            }
            _presetColorIndex = 0;
            _borderColorIndex = 0;
            _transparentColorIndex = 0;
        }

        #endregion

        // ******************************** Size Handling

        #region Size Handling

        // only active when processing cdgFile
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            _backBufferGraphics.Dispose();
            _backBuffer.Dispose();
            _backBuffer = new Bitmap(ClientRectangle.Width, ClientRectangle.Height, PixelFormat.Format32bppArgb);
            _backBufferGraphics = Graphics.FromImage(_backBuffer);

            _screenGraphics.Dispose();
            _screenGraphics = CreateGraphics();

            CalculateZoom();
        }

        private void CalculateZoom()
        {
            double difX = (double)ClientRectangle.Width / CDG_DISPLAY_WIDTH;
            double difY = (double)ClientRectangle.Height / CDG_DISPLAY_HEIGHT;
            if (difX < difY)
            {
                _cdgZoomRect.Height = (int)(CDG_DISPLAY_HEIGHT * difX);
                _cdgZoomRect.Width = (int)(CDG_DISPLAY_WIDTH * difX);
                _cdgZoomRect.Y = (ClientRectangle.Height - _cdgZoomRect.Height) / 2;
                _cdgZoomRect.X = 0;
            }
            else
            {
                _cdgZoomRect.Height = (int)(CDG_DISPLAY_HEIGHT * difY);
                _cdgZoomRect.Width = (int)(CDG_DISPLAY_WIDTH * difY);
                _cdgZoomRect.X = (ClientRectangle.Width - _cdgZoomRect.Width) / 2;
                _cdgZoomRect.Y = 0;
            }

            if (_backImageMode)
            {
                difX = (double)ClientRectangle.Width / _backImage.Width;
                difY = (double)ClientRectangle.Height / _backImage.Height;
                if (difX < difY)
                {
                    _backZoomRect.Height = (int)(_backImage.Height * difX);
                    _backZoomRect.Width = (int)(_backImage.Width * difX);
                    _backZoomRect.Y = (ClientRectangle.Height - _backZoomRect.Height) / 2;
                    _backZoomRect.X = 0;
                }
                else
                {
                    _backZoomRect.Height = (int)(_backImage.Height * difY);
                    _backZoomRect.Width = (int)(_backImage.Width * difY);
                    _backZoomRect.X = (ClientRectangle.Width - _backZoomRect.Width) / 2;
                    _backZoomRect.Y = 0;
                }
            }
        }

        #endregion

        // ******************************** Rendering / Paint

        #region Rendering / Paint

        void CdgTimer_Tick(object sender, EventArgs e)
        {
            if (_playerMode) _playbackPosition = (int)_basePlayer.Position.FromStart.TotalMilliseconds;
            else _playbackPosition += CDG_TIMER_INTERVAL;
            if (_cdgIndex < _cdgFileLenght) RenderPosition(_playbackPosition);
            else StopProcess();
        }

        private void RenderPosition(int ms)
        {
            if (_busy) return;
            _busy = true;

            int position = (int)(ms * 7.2); // 7.2 = CDG_PACKET_SIZE * 0.3 (packets per millisecond)
            if (position < _cdgIndex) _cdgIndex = 0;
            while (_cdgIndex <= position && _cdgIndex < _cdgFileLenght)
            {
                ProcessPacket();
                _cdgIndex += CDG_PACKET_SIZE;
            }
            ApplyColorPalette();
            CdgPaint();

            _busy = false;
        }

        private void CdgPaint()
        {
            if (_backOpaqueMode)
            {
                // ******** cdgImage to screen

                _screenHdc = _screenGraphics.GetHdc();
                _cdgImageHdc = _cdgImageGraphics.GetHdc();
                _cdgBitmapHbitmap = _cdgImage.GetHbitmap();
                _cdgBitmapOldObject = SafeNativeMethods.SelectObject(_cdgImageHdc, _cdgBitmapHbitmap);

                if (_cdgImageStretch) SafeNativeMethods.StretchBlt(_screenHdc, 0, 0, ClientRectangle.Width, ClientRectangle.Height, _cdgImageHdc, 0, 0, CDG_DISPLAY_WIDTH, CDG_DISPLAY_HEIGHT, 0x00CC0020U);
                else SafeNativeMethods.StretchBlt(_screenHdc, _cdgZoomRect.X, _cdgZoomRect.Y, _cdgZoomRect.Width, _cdgZoomRect.Height, _cdgImageHdc, 0, 0, CDG_DISPLAY_WIDTH, CDG_DISPLAY_HEIGHT, 0x00CC0020U);

                SafeNativeMethods.SelectObject(_cdgImageHdc, _cdgBitmapOldObject);
                SafeNativeMethods.DeleteObject(_cdgBitmapHbitmap);
                _cdgBitmapOldObject = IntPtr.Zero;
                _cdgBitmapHbitmap = IntPtr.Zero;

                _cdgImageGraphics.ReleaseHdc(_cdgImageHdc);
                _screenGraphics.ReleaseHdc(_screenHdc);
            }
            else
            {
                if (_backImageMode)
                {
                    if (!_backStretch || !(_backMatch && _cdgImageStretch)) _backBufferGraphics.FillRectangle(Brushes.RosyBrown, 0, 0, _backBuffer.Width, _backBuffer.Height);

                    _backBufferHdc = _backBufferGraphics.GetHdc();
                    _backBufferHbitmap = _backBuffer.GetHbitmap();
                    _backBufferOldObject = SafeNativeMethods.SelectObject(_backBufferHdc, _backBufferHbitmap);

                    // ******** backimage to buffer

                    _backImageHdc = _backImageGraphics.GetHdc();
                    _backImageHbitmap = _backImage.GetHbitmap();
                    _backImageOldObject = SafeNativeMethods.SelectObject(_backImageHdc, _backImageHbitmap);

                    SafeNativeMethods.SetStretchBltMode(_backBufferHdc, 4);
                    if (_backStretch || (_backMatch && _cdgImageStretch)) SafeNativeMethods.StretchBlt(_backBufferHdc, 0, 0, _backBuffer.Width, _backBuffer.Height, _backImageHdc, 0, 0, _backImage.Width, _backImage.Height, 0x00CC0020U);
                    else
                    {
                        if (_backMatch) SafeNativeMethods.StretchBlt(_backBufferHdc, _cdgZoomRect.X, _cdgZoomRect.Y, _cdgZoomRect.Width, _cdgZoomRect.Height, _backImageHdc, 0, 0, _backImage.Width, _backImage.Height, 0x00CC0020U);
                        else SafeNativeMethods.StretchBlt(_backBufferHdc, _backZoomRect.X, _backZoomRect.Y, _backZoomRect.Width, _backZoomRect.Height, _backImageHdc, 0, 0, _backImage.Width, _backImage.Height, 0x00CC0020U);
                    }
                    SafeNativeMethods.SelectObject(_backImageHdc, _backImageOldObject);
                    SafeNativeMethods.DeleteObject(_backImageHbitmap);
                    _backImageOldObject = IntPtr.Zero;
                    _backImageHbitmap = IntPtr.Zero;
                    _backImageGraphics.ReleaseHdc(_backImageHdc);
                }
                else
                {
                    // ******** background color / transparent to buffer

                    if(_backTransparentMode || !_backStretch) _backBufferGraphics.FillRectangle(Brushes.RosyBrown, 0, 0, _backBuffer.Width, _backBuffer.Height);
                    if (!_backTransparentMode)
                    {
                        if (_backStretch) _backBufferGraphics.FillRectangle(_backColorBrush, 0, 0, _backBuffer.Width, _backBuffer.Height);
                        else _backBufferGraphics.FillRectangle(_backColorBrush, _cdgZoomRect);
                    }

                    _backBufferHdc = _backBufferGraphics.GetHdc();
                    _backBufferHbitmap = _backBuffer.GetHbitmap();
                    _backBufferOldObject = SafeNativeMethods.SelectObject(_backBufferHdc, _backBufferHbitmap);
                }

                // ******** cdgImage to buffer

                _cdgImageHdc = _cdgImageGraphics.GetHdc();
                _cdgBitmapHbitmap = _cdgImage.GetHbitmap();
                _cdgBitmapOldObject = SafeNativeMethods.SelectObject(_cdgImageHdc, _cdgBitmapHbitmap);

                _cdgTransparentColor = ColorTranslator.ToWin32(_cdgColorPalette[_presetColorIndex]);
                if (_cdgImageStretch) SafeNativeMethods.TransparentBlt(_backBufferHdc, 0, 0, _backBuffer.Width, _backBuffer.Height, _cdgImageHdc, 0, 0, CDG_DISPLAY_WIDTH, CDG_DISPLAY_HEIGHT, _cdgTransparentColor);
                else SafeNativeMethods.TransparentBlt(_backBufferHdc, _cdgZoomRect.X, _cdgZoomRect.Y, _cdgZoomRect.Width, _cdgZoomRect.Height, _cdgImageHdc, 0, 0, CDG_DISPLAY_WIDTH, CDG_DISPLAY_HEIGHT, _cdgTransparentColor);

                SafeNativeMethods.SelectObject(_cdgImageHdc, _cdgBitmapOldObject);
                SafeNativeMethods.DeleteObject(_cdgBitmapHbitmap);
                _cdgBitmapOldObject = IntPtr.Zero;
                _cdgBitmapHbitmap = IntPtr.Zero;
                _cdgImageGraphics.ReleaseHdc(_cdgImageHdc);

                // ******** buffer to screen

                _screenHdc = _screenGraphics.GetHdc();
                SafeNativeMethods.BitBlt(_screenHdc, 0, 0, _backBuffer.Width, _backBuffer.Height, _backBufferHdc, 0, 0, 0x00CC0020U);
                _screenGraphics.ReleaseHdc(_screenHdc);

                // ******** unset buffer

                SafeNativeMethods.SelectObject(_backBufferHdc, _backBufferOldObject);
                SafeNativeMethods.DeleteObject(_backBufferHbitmap);
                _backBufferOldObject = IntPtr.Zero;
                _backBufferHbitmap = IntPtr.Zero;
                _backBufferGraphics.ReleaseHdc(_backBufferHdc);
            }
        }

        #endregion

        // ******************************** Process CDG Packets

        #region Process CDG Packets

        private void ProcessPacket()
        {
            if ((_cdgFile[_cdgIndex] & CDG_MASK) == CDG_COMMAND)
            {
                switch (_cdgFile[_cdgIndex + INSTRUCTION_OFFSET] & CDG_MASK)
                {
                    case CDG_MEMORY_PRESET:
                        MemoryPreset();
                        break;

                    case CDG_BORDER_PRESET:
                        BorderPreset();
                        break;

                    case CDG_SCROLL_PRESET:
                        ScrollPreset(false);
                        break;

                    case CDG_SCROLL_COPY:
                        ScrollPreset(true);
                        break;

                    case CDG_TRANSPARANT_COLOR:
                        DefineTransparentColor();
                        break;

                    case CDG_COLOR_PALETTE_LOW:
                        SetColorPalette(false);
                        break;

                    case CDG_COLOR_PALETTE_HIGH:
                        SetColorPalette(true);
                        break;

                    case CDG_TILE_BLOCK:
                        TileBlock(false);
                        break;

                    case CDG_TILE_BLOCK_XOR:
                        TileBlock(true);
                        break;

                    //default:
                    //    // Ignore other instructions
                    //    break;
                }
            }
        }

        // ******************************** Memory Preset

        #region Memory Preset

        private void MemoryPreset()
        {
            if ((_cdgFile[_cdgIndex + REPEAT_OFFSET] & LOW_NIBBLE_MASK) == 0)
            {
                byte color = (byte)(_cdgFile[_cdgIndex + DATA_OFFSET] & LOW_NIBBLE_MASK);
                _presetColorIndex = color;
                _borderColorIndex = color;

                for (int y = 0; y < CDG_FULL_HEIGHT; ++y)
                {
                    for (int x = 0; x < CDG_FULL_WIDTH; ++x) _cdgColorTable[x, y] = color;
                }
            }
        }

        #endregion

        // ******************************** Border Preset

        #region Border Preset

        private void BorderPreset()
        {
            int x, y;
            byte color = (byte)(_cdgFile[_cdgIndex + DATA_OFFSET] & LOW_NIBBLE_MASK);
            _borderColorIndex = color;

            for (y = 0; y < CDG_FULL_HEIGHT; ++y)
            {
                for (x = 0; x < CDG_BORDER_WIDTH; ++x) _cdgColorTable[x, y] = color;
                for (x = CDG_FULL_WIDTH - CDG_BORDER_WIDTH; x < CDG_FULL_WIDTH; ++x) _cdgColorTable[x, y] = color;
            }

            for (x = CDG_BORDER_WIDTH; x < CDG_FULL_WIDTH - CDG_BORDER_WIDTH; ++x)
            {
                for (y = 0; y < CDG_BORDER_HEIGHT; ++y) _cdgColorTable[x, y] = color;
                for (y = CDG_FULL_HEIGHT - CDG_BORDER_HEIGHT; y < CDG_FULL_HEIGHT; ++y) _cdgColorTable[x, y] = color;
            }
        }

        #endregion

        // ******************************** Scroll

        #region Scroll

        private void ScrollPreset(bool copy)
        {
            // Decode the scroll command parameters
            byte color = (byte)(_cdgFile[_cdgIndex + DATA_OFFSET] & LOW_NIBBLE_MASK);
            int hScroll = _cdgFile[_cdgIndex + DATA_OFFSET + 1] & CDG_MASK;
            int vScroll = _cdgFile[_cdgIndex + DATA_OFFSET + 2] & CDG_MASK;

            int hSCmd = (hScroll & 0x30) >> 4;
            //int hOffset = hScroll & 0x07;
            int vSCmd = (vScroll & 0x30) >> 4;
            //int vOffset = vScroll & 0x0F;

            //int mHOffset = hOffset < 5 ? hOffset : 5;
            //int mVOffset = vOffset < 11 ? vOffset : 11;

            // Scroll Vertical - Calculate number of pixels
            int vScrollPixels = 0;
            if (vSCmd == 2) vScrollPixels = -12;
            else if (vSCmd == 1) vScrollPixels = 12;

            // Scroll Horizontal- Calculate number of pixels
            int hScrollPixels = 0;
            if (hSCmd == 2) hScrollPixels = -6;
            else if (hSCmd == 1) hScrollPixels = 6;

            if (hScrollPixels == 0 && vScrollPixels == 0) return;

            byte[,] cdgColorTableCopy = new byte[CDG_FULL_WIDTH, CDG_FULL_HEIGHT];
            int x, y;
            int vInc = vScrollPixels + CDG_FULL_HEIGHT;
            int hInc = hScrollPixels + CDG_FULL_WIDTH;

            for (y = 0; y < CDG_FULL_HEIGHT; ++y)
            {
                for (x = 0; x < CDG_FULL_WIDTH; ++x) cdgColorTableCopy[(x + hInc) % CDG_FULL_WIDTH, (y + vInc) % CDG_FULL_HEIGHT] = _cdgColorTable[x, y];
            }

            if (!copy)
            {
                if (vScrollPixels > 0)
                {
                    for (x = 0; x < CDG_FULL_WIDTH; ++x)
                    {
                        for (y = 0; y < vScrollPixels; ++y) cdgColorTableCopy[x, y] = color;
                    }
                }
                else if (vScrollPixels < 0)
                {
                    for (x = 0; x < CDG_FULL_WIDTH; ++x)
                    {
                        for (y = CDG_FULL_HEIGHT + vScrollPixels; y < CDG_FULL_HEIGHT; ++y) cdgColorTableCopy[x, y] = color;
                    }
                }

                if (hScrollPixels > 0)
                {
                    for (x = 0; x < hScrollPixels; ++x)
                    {
                        for (y = 0; y < CDG_FULL_HEIGHT; ++y) cdgColorTableCopy[x, y] = color;
                    }
                }
                else if (hScrollPixels < 0)
                {
                    for (x = CDG_FULL_WIDTH + hScrollPixels; x < CDG_FULL_WIDTH; ++x)
                    {
                        for (y = 0; y < CDG_FULL_HEIGHT; ++y) cdgColorTableCopy[x, y] = color;
                    }
                }
            }
            _cdgColorTable = cdgColorTableCopy;
        }

        #endregion

        // ******************************** Transparent Color

        #region Transparent Color

        private void DefineTransparentColor()
        {
            _transparentColorIndex = _cdgFile[_cdgIndex + DATA_OFFSET] & LOW_NIBBLE_MASK;
        }

        #endregion

        // ******************************** Color Palette

        #region Color Palette

        private void SetColorPalette(bool highPart)
        {
            int offset = highPart ? 8 : 0;

            for (int i = 0; i < 8; ++i)
            {
                short color = (short)((_cdgFile[_cdgIndex + DATA_OFFSET + (2 * i)] << 6) + (_cdgFile[_cdgIndex + DATA_OFFSET + (2 * i + 1)] & CDG_MASK));
                _cdgColorPalette[i + offset] = Color.FromArgb((byte)((color >> 4) & HIGH_NIBBLE_MASK), (byte)(color & HIGH_NIBBLE_MASK), (byte)((color << 4) & HIGH_NIBBLE_MASK));
            }
        }

        // render
        private void ApplyColorPalette()
        {
            BitmapData bmd = _cdgImage.LockBits(_cdgImageRect, ImageLockMode.ReadWrite, _cdgImage.PixelFormat);
            unsafe
            {
                for (int y = CDG_BORDER_HEIGHT; y < CDG_BORDER_HEIGHT + CDG_DISPLAY_HEIGHT; ++y)
                {
                    byte* row = (byte*)bmd.Scan0 + ((y - CDG_BORDER_HEIGHT) * bmd.Stride);
                    for (int x = CDG_BORDER_WIDTH; x < CDG_BORDER_WIDTH + CDG_DISPLAY_WIDTH; ++x)
                    {
                        Color color = _cdgColorPalette[_cdgColorTable[x, y]];
                        *row++ = color.B; *row++ = color.G; *row++ = color.R; *row++ = color.A;
                    }
                }
            }
            _cdgImage.UnlockBits(bmd);
        }

        #endregion

        // ******************************** Tile Block

        #region Tile Block

        private void TileBlock(bool xor)
        {
            byte color0 = (byte)(_cdgFile[_cdgIndex + DATA_OFFSET] & LOW_NIBBLE_MASK);
            byte color1 = (byte)(_cdgFile[_cdgIndex + DATA_OFFSET + 1] & LOW_NIBBLE_MASK);
            int row = (_cdgFile[_cdgIndex + DATA_OFFSET + 2] & 0x1F) * CDG_TILE_HEIGHT;
            int column = (_cdgFile[_cdgIndex + DATA_OFFSET + 3] & CDG_MASK) * CDG_TILE_WIDTH;

            if (row > (CDG_FULL_HEIGHT - CDG_TILE_HEIGHT)) return;
            if (column > (CDG_FULL_WIDTH - CDG_TILE_WIDTH)) return;

            for (int y = 0; y < CDG_TILE_HEIGHT; ++y)
            {
                byte pixels = (byte)(_cdgFile[_cdgIndex + DATA_OFFSET + 4 + y] & CDG_MASK);
                for (int x = 0; x < CDG_TILE_WIDTH; ++x)
                {
                    if (xor) _cdgColorTable[column + x, row + y] = (byte)(_cdgColorTable[column + x, row + y] ^ ((byte)((pixels >> (5 - x)) & 0x01) == 0 ? color0 : color1));
                    else _cdgColorTable[column + x, row + y] = (byte)((pixels >> (5 - x)) & 0x01) == 0 ? color0 : color1;
                }
            }
        }

        #endregion

        #endregion // Process CDG Packets

    }
}
