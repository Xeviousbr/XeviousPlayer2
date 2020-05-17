#region Usings

using Microsoft.Win32;
using PVS.AVPlayer;
using System;
using System.Drawing;
using System.Security.Permissions;
using System.Text;
using System.Windows.Forms;

#endregion

namespace AVPlayerExample
{
    public partial class VideoWall : Form, IOverlay
    {
        /*

        PVS.AVPlayer Display Overlay - Example 'Video Wall'
        Displays the main video picture on all connected active screens
        as if they were (part of) one large screen (or on each screen ('tiles')).
        
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

        // this is an overlay of:
        private Form1       _baseForm;
        private Player      _basePlayer;

        // display form
        private Form        _display;

        // displaymode
        private int         _displayMode; // 0 = stretch, 1 = zoom, 2 = tiles stretch, 3 = tiles zoom
        private bool        _highQuality; // true = SetStretchBltMode STRETCH_HALFTONE

        // areas
        private Rectangle   _sourceRect; // Source (basePlayer video/display)
        private Rectangle   _destRect; // Destination (display (Form size) - screens combined)
        private Rectangle   _zoomRect; // Size of video picture on destination (with Zoom displaymode)
        private Rectangle[] _screenRects; // for tiles stretch display
        private Rectangle[] _tilesRects; // for tiles zoom display

        // status
        private bool        _active; // display activated (but could be hidden or empty)
        private bool        _running; // video displayed (copied from baseplayer)
        private bool        _hasEvents; // has basePlayer eventhandlers
        private bool        _busy; // paint screens busy

        // timer
        private Timer       _timer;

        // dispose
        private bool        _disposed;

        #endregion

        // ******************************** Main

        #region Main

        public VideoWall(Form1 baseForm, Player basePlayer)
        {
            InitializeComponent();

            _baseForm = baseForm;
            _basePlayer = basePlayer;

            _display = new Form
            {
                StartPosition = FormStartPosition.Manual,
                FormBorderStyle = FormBorderStyle.None,
                ShowInTaskbar = false,
                BackColor = Color.FromArgb(18, 18, 18),
                ContextMenuStrip = optionsMenu,
                KeyPreview = true,
            };
            _display.KeyDown += _display_KeyDown;

            _timer = new Timer { Interval = FPS25 };
            _timer.Tick += TimerTick;
        }

        private void GetScreensInfo()
        {
            // info for displayform size and 'stretch' and 'zoom'
            _destRect = SystemInformation.VirtualScreen;

            // set displayform size
            _display.Bounds = _destRect;

            // info for 'tiles stretch' + adjust positions
            _screenRects = new Rectangle[Screen.AllScreens.Length];
            for (int i = 0; i < Screen.AllScreens.Length; ++i)
            {
                _screenRects[i] = Screen.AllScreens[i].Bounds;
                _screenRects[i].X -= _destRect.X;
                _screenRects[i].Y -= _destRect.Y;
            }
        }

        private void GetVideoInfo()
        {
            _sourceRect = Rectangle.Intersect(_basePlayer.VideoBounds, _basePlayer.Display.DisplayRectangle);

            // info for 'all screens zoom'
            _zoomRect = CalcZoomRect(_destRect, _sourceRect, false);

            // info for 'tiles zoom'
            _tilesRects = new Rectangle[_screenRects.Length];
            for (int i = 0; i < _screenRects.Length; ++i)
            {
                _tilesRects[i] = CalcZoomRect(_screenRects[i], _sourceRect, true);
            }
        }

        private void StartView()
        {
            GetScreensInfo();

            if (!_hasEvents)
            {
                _basePlayer.MediaStarted += basePlayer_MediaStarted;
                // assumes (and requires) a player display (should add check):
                _basePlayer.MediaDisplayModeChanged += basePlayer_MediaDisplayModeChanged;
                _basePlayer.Display.SizeChanged += basePlayer_DisplaySizeChanged;
                // TODO - does not recalculate when set to fullscreenmode ? check, now using:
                Layout += basePlayer_DisplaySizeChanged;
                // check for display settings changes (e.g. number of screens and/or their positions)
                SystemEvents.DisplaySettingsChanged += SystemEvents_DisplaySettingsChanged;
                _hasEvents = true;
            }

            if (_basePlayer.VideoPresent)
            {
                GetVideoInfo();
                _timer.Start();
                _running = true;
            }

            if (!_display.Visible) _display.Show();
            startButton.Text = "Stop";
            startMenuItem.Text = "Stop 'Video Wall'";
        }

        [PermissionSet(SecurityAction.LinkDemand, Name = "FullTrust", Unrestricted = false)]
        private void StopView()
        {
            if (_running)
            {
                _timer.Stop();
                _running = false;
            }

            if (_hasEvents)
            {
                _basePlayer.MediaStarted -= basePlayer_MediaStarted;
                _basePlayer.MediaDisplayModeChanged -= basePlayer_MediaDisplayModeChanged;
                _basePlayer.Display.SizeChanged -= basePlayer_DisplaySizeChanged;
                Layout -= basePlayer_DisplaySizeChanged;
                SystemEvents.DisplaySettingsChanged -= SystemEvents_DisplaySettingsChanged;
                _hasEvents = false;
            }

            if (_display.Visible) _display.Hide();
            startButton.Text = "Start";
            startMenuItem.Text = "Start 'Video Wall'";
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        [PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    StopView();
                    _display.Dispose(); _display = null;

                    _timer.Dispose(); _timer = null;
                    _basePlayer = null;

                    if (components != null) components.Dispose();
                }
                base.Dispose(disposing);
                _disposed = true;
            }
        }

        #endregion

        // ******************************** Event Handling

        #region Event Handling

        // this overlay activated / deactivated
        private void VideoWallOverlay_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                if (_active) StartView();
            }
            else
            {
                if (_active) StopView();
            }
        }

        // baseplayer display size changed
        private void basePlayer_DisplaySizeChanged(object sender, EventArgs e)
        {
            UpdateActiveView();
        }

        // baseplayer media started
        private void basePlayer_MediaStarted(object sender, EventArgs e)
        {
            if (_basePlayer.VideoPresent)
            {
                if (WindowState != FormWindowState.Minimized)
                {
                    GetVideoInfo();
                    _timer.Start();
                    _running = true;
                }
            }
        }

        // baseplayer displaymode changed
        private void basePlayer_MediaDisplayModeChanged(object sender, EventArgs e)
        {
            UpdateActiveView();
        }

        // system display settings changed
        private void SystemEvents_DisplaySettingsChanged(object sender, EventArgs e)
        {
            if (_destRect != SystemInformation.VirtualScreen) UpdateActiveView();
        }

        // handle changed display/video layout
        private void UpdateActiveView()
        {
            GetScreensInfo();
            GetVideoInfo();
            _display.Refresh();
            TimerTick(this, EventArgs.Empty);
        }

        // Esc-key can stop allscreens mode
        private void _display_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape && _active)
            {
                StopView();
                _active = false;
            }
        }

        #endregion

        // ******************************** Paint All Screens

        #region Paint All Screens

        void TimerTick(object sender, EventArgs e)
        {
            if (_busy) return;
            _busy = true;

            Graphics sourceGraphics = _basePlayer.Display.CreateGraphics();
            IntPtr sourceHdc = sourceGraphics.GetHdc();
            Graphics destGraphics = _display.CreateGraphics();
            IntPtr destHdc = destGraphics.GetHdc();

            if (_highQuality) SafeNativeMethods.SetStretchBltMode(destHdc, STRETCH_HALFTONE);

            switch (_displayMode)
            {
                case 0: // stretch
                    SafeNativeMethods.StretchBlt(destHdc, 0, 0, _destRect.Width, _destRect.Height, sourceHdc, _sourceRect.Left, _sourceRect.Top, _sourceRect.Width, _sourceRect.Height, 0x00CC0020U);
                    break;

                case 1: // zoom
                    SafeNativeMethods.StretchBlt(destHdc, _zoomRect.X, _zoomRect.Y, _zoomRect.Width, _zoomRect.Height, sourceHdc, _sourceRect.Left, _sourceRect.Top, _sourceRect.Width, _sourceRect.Height, 0x00CC0020U);
                    break;

                case 2: // tiles stretch
                    for (int i = _tilesRects.Length; i-- > 0;)
                    {
                        SafeNativeMethods.StretchBlt(destHdc, _screenRects[i].X, _screenRects[i].Y, _screenRects[i].Width, _screenRects[i].Height, sourceHdc, _sourceRect.Left, _sourceRect.Top, _sourceRect.Width, _sourceRect.Height, 0x00CC0020U);
                    }
                    break;

                default: // tiles zoom
                    for (int i = _tilesRects.Length; i-- > 0;)
                    {
                        SafeNativeMethods.StretchBlt(destHdc, _tilesRects[i].X, _tilesRects[i].Y, _tilesRects[i].Width, _tilesRects[i].Height, sourceHdc, _sourceRect.Left, _sourceRect.Top, _sourceRect.Width, _sourceRect.Height, 0x00CC0020U);
                    }
                    break;
            }

            sourceGraphics.ReleaseHdc(sourceHdc);
            sourceGraphics.Dispose();
            destGraphics.ReleaseHdc(destHdc);
            destGraphics.Dispose();

            _busy = false;
        }

        #endregion

        // ******************************** Start / Stop Button

        #region Start / Stop Button

        private void startButton_Click(object sender, EventArgs e)
        {
            if (_active)
            {
                StopView();
                _active = false;
            }
            else
            {
                StartView();
                _active = true;
            }
        }

        #endregion

        // ******************************** Options Menu Handling

        #region Options Menu Handling

        // DisplayMode Stretch Menu Item
        private void stretchMenuItem_Click(object sender, EventArgs e)
        {
            SetMenuCheckMarks(sender);
            _displayMode = 0;
            if (_running) _display.Invalidate();
        }

        // DisplayMode Zoom Menu Item
        private void zoomMenuItem_Click(object sender, EventArgs e)
        {
            SetMenuCheckMarks(sender);
            _displayMode = 1;
            if (_running) _display.Invalidate();
        }

        // DisplayMode Tiles Stretch Menu Item
        private void tilesStretchMenuItem_Click(object sender, EventArgs e)
        {
            SetMenuCheckMarks(sender);
            _displayMode = 2;
            if (_running) _display.Invalidate();
        }

        // DisplayMode Tiles Zoom Menu Item
        private void tilesZoomMenuItem_Click(object sender, EventArgs e)
        {
            SetMenuCheckMarks(sender);
            _displayMode = 3;
            if (_running) _display.Invalidate();
        }

        // Background Color Menu Item
        private void backColorMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog1 = new ColorDialog {Color = _display.BackColor};
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                _display.BackColor = colorDialog1.Color;
            }
            colorDialog1.Dispose();
        }

        // Quality Mode Normal
        private void normalQualityMenuItem_Click(object sender, EventArgs e)
        {
            _highQuality = false;
            normalQualityMenuItem.Checked = true;
            highQualityMenuItem.Checked = false;
        }

        // Quality Mode High
        private void highQualityMenuItem_Click(object sender, EventArgs e)
        {
            _highQuality = true;
            normalQualityMenuItem.Checked = false;
            highQualityMenuItem.Checked = true;
        }

        // Refresh Rate 1 fps Menu Item
        private void fps01MenuItem_Click(object sender, EventArgs e)
        {
            SetMenuCheckMarks(sender);
            _timer.Interval = FPS01;
        }

        // Refresh Rate 2 fps Menu Item
        private void fps02MenuItem_Click(object sender, EventArgs e)
        {
            SetMenuCheckMarks(sender);
            _timer.Interval = FPS02;
        }

        // Refresh Rate 5 fps Menu Item
        private void fps05MenuItem_Click(object sender, EventArgs e)
        {
            SetMenuCheckMarks(sender);
            _timer.Interval = FPS05;
        }

        // Refresh Rate 10 fps Menu Item
        private void fps10MenuItem_Click(object sender, EventArgs e)
        {
            SetMenuCheckMarks(sender);
            _timer.Interval = FPS10;
        }

        // Refresh Rate 15 fps Menu Item
        private void fps15MenuItem_Click(object sender, EventArgs e)
        {
            SetMenuCheckMarks(sender);
            _timer.Interval = FPS15;
        }

        // Refresh Rate 20 fps Menu Item
        private void fps20MenuItem_Click(object sender, EventArgs e)
        {
            SetMenuCheckMarks(sender);
            _timer.Interval = FPS20;
        }

        // Refresh Rate 25 fps Menu Item
        private void fps25MenuItem_Click(object sender, EventArgs e)
        {
            SetMenuCheckMarks(sender);
            _timer.Interval = FPS25;
        }

        // Refresh Rate 30 fps Menu Item
        private void fps30MenuItem_Click(object sender, EventArgs e)
        {
            SetMenuCheckMarks(sender);
            _timer.Interval = FPS30;
        }

        // Refresh Rate 40 fps Menu Item
        private void fps40MenuItem_Click(object sender, EventArgs e)
        {
            SetMenuCheckMarks(sender);
            _timer.Interval = FPS40;
        }

        // Refresh Rate 50 fps Menu Item
        private void fps50MenuItem_Click(object sender, EventArgs e)
        {
            SetMenuCheckMarks(sender);
            _timer.Interval = FPS50;
        }

        // Refresh Rate 60 fps Menu Item
        private void fps60MenuItem_Click(object sender, EventArgs e)
        {
            SetMenuCheckMarks(sender);
            _timer.Interval = FPS60;
        }

        // Opacity 25% Menu Item
        private void opacity25MenuItem_Click(object sender, EventArgs e)
        {
            SetMenuCheckMarks(sender);
            _display.Opacity = 0.25;
        }

        // Opacity 50% Menu Item
        private void opacity50MenuItem_Click(object sender, EventArgs e)
        {
            SetMenuCheckMarks(sender);
            _display.Opacity = 0.5;
        }

        // Opacity 75% Menu Item
        private void opacity75MenuItem_Click(object sender, EventArgs e)
        {
            SetMenuCheckMarks(sender);
            _display.Opacity = 0.75;
        }

        // Opacity 100% Menu Item
        private void opacity100MenuItem_Click(object sender, EventArgs e)
        {
            SetMenuCheckMarks(sender);
            _display.Opacity = 1;
        }

        // display settings
        private void displaySettingsMenuItem_Click(object sender, EventArgs e)
        {
            if (_display == ActiveForm) _basePlayer.ShowDisplaySettingsPanel();
            else _basePlayer.ShowDisplaySettingsPanel(this);
        }

        // overlay info
        private void overlayInfoMenuItem_Click(object sender, EventArgs e)
        {
            ShowInfoMessage();
        }

        // Start / Stop Menu Item
        private void startMenuItem_Click(object sender, EventArgs e)
        {
            if (_active)
            {
                StopView();
                _active = false;
            }
            else
            {
                StartView();
                _active = true;
            }
        }

        #endregion

        // ******************************** Info Message Dialog

        #region Info Message Dialog

        private void ShowInfoMessage()
        {
            StringBuilder infoText = new StringBuilder(450);
            infoText.AppendLine("Video Wall Display Overlay\r\n")
            .AppendLine("Select 'Start' to show the video picture of the main player's display on all connected and active computer monitors as if they were (part of) one large (virtual) screen.\r\n")
            .AppendLine("For best results, use the original size of the main video (displaymode normal or center) and the overlay's high quality mode (options).\r\n")
            .AppendLine("Number of monitors: " + Screen.AllScreens.Length)
            .AppendLine("Virtual Screen bounds: " + SystemInformation.VirtualScreen.ToString().TrimStart('{').TrimEnd('}'));

            ErrorDialog infoDialog = new ErrorDialog(Form1.APPLICATION_NAME, infoText.ToString(), true);

            infoDialog.checkBox1.Hide();
            infoDialog.checkBox2.Hide();

            if (_display == ActiveForm)
            {
                Point p = Cursor.Position;

                // don't we have something for this already somewhere? .Net?
                p.X -= infoDialog.Width/2;
                if (p.X <= _display.Left) p.X = _display.Left + 16;
                else if (p.X + infoDialog.Width >= _display.Left + _display.Width) p.X = (_display.Left + _display.Width) - infoDialog.Width - 16;

                p.Y -= infoDialog.Height / 2;
                if (p.Y <= _display.Top) p.Y = _display.Top + 16;
                else if (p.Y + infoDialog.Height >= _display.Top + _display.Height) p.Y = (_display.Top + _display.Height) - infoDialog.Height - 16;

                infoDialog.Location = p;
            }
            else
            {
                _baseForm.CenterDialog(this, infoDialog);
            }

            infoDialog.ShowDialog();
            infoDialog.Dispose();
            infoText.Length = 0;
        }

        #endregion

        // ******************************** IOverlay Control

        #region IOverlay Control

        // The visibility of the menu is controlled by the user from the main application (in this example application)
        public bool MenuEnabled
        {
            get { return screensPanel.Visible; }
            set { screensPanel.Visible = value; }
        }

        public bool HasMenu
        {
            get { return true; }
        }

        public void MediaStopped()
        {
            if (_running)
            {
                _timer.Stop();
                _running = false;
                _display.Invalidate();
            }
        }

        #endregion

        // ******************************** Utility Functions

        #region Utility Functions

        private Rectangle CalcZoomRect(Rectangle dest, Rectangle source, bool tile)
        {
            Rectangle r = new Rectangle();
            double difX = (double)dest.Width / source.Width;
            double difY = (double)dest.Height / source.Height;

            if (difX < difY)
            {
                r.Height = (int)(source.Height * difX);
                r.Width = (int)(source.Width * difX);
                r.Y = (dest.Height - r.Height) / 2;
            }
            else
            {
                r.Height = (int)(source.Height * difY);
                r.Width = (int)(source.Width * difY);
                r.X = (dest.Width - r.Width) / 2;
            }
            if (tile)
            {
                r.X += dest.X;
                r.Y += dest.Y;
            }

            return r;
        }

        // Removes the check marks from the menu items and checks the selected item
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
