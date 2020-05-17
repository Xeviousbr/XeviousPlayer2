#region Usings

using Microsoft.Win32;
using PVS.MediaPlayer;
using System;
using System.Drawing;
using System.Security.Permissions;
using System.Text;
using System.Windows.Forms;

#endregion

namespace PVSPlayerExample
{
    public sealed partial class VideoWall : Form, IOverlay
    {
        /*

        PVS.MediaPlayer Display Overlay - Example 'Video Wall'
        Displays the main video picture on all connected active screens
        as if they were (part of) one large screen (or on each screen ('tiles')).

        From version 0.95 you could also create a video wall without using a display overlay.
        
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
        private MainWindow  _baseWindow;
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

        public VideoWall(MainWindow baseWindow, Player basePlayer)
        {
            InitializeComponent();

            _baseWindow = baseWindow;
            _basePlayer = basePlayer;

            _display = new Form
            {
                StartPosition       = FormStartPosition.Manual,
                FormBorderStyle     = FormBorderStyle.None,
                ShowInTaskbar       = false,
                BackColor           = Color.FromArgb(18, 18, 18),
                ContextMenuStrip    = optionsMenu,
                KeyPreview          = true,
            };
            _display.KeyDown += Display_KeyDown;
            if (MainWindow.Prefs.AutoHideCursor) _basePlayer.CursorHide.Add(_display);

            _timer = new Timer { Interval = FPS30 };
            _timer.Tick += TimerTick;
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
            _sourceRect = Rectangle.Intersect(_basePlayer.Video.Bounds, _basePlayer.Display.Window.DisplayRectangle);

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
                _basePlayer.Events.MediaStarted += BasePlayer_MediaStarted;
                // assumes (and requires) a player display (should add check):
                _basePlayer.Events.MediaDisplayModeChanged += BasePlayer_MediaDisplayModeChanged;
                _basePlayer.Display.Window.SizeChanged += BasePlayer_DisplaySizeChanged;
                // TODO - does not recalculate when set to fullscreenmode ? check, now using:
                Layout += BasePlayer_DisplaySizeChanged;
                // check for display settings changes (e.g. number of screens and/or their positions)
                SystemEvents.DisplaySettingsChanged += SystemEvents_DisplaySettingsChanged;
                _hasEvents = true;
            }

            if (_basePlayer.Video.Present)
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
                _basePlayer.Events.MediaStarted -= BasePlayer_MediaStarted;
                _basePlayer.Events.MediaDisplayModeChanged -= BasePlayer_MediaDisplayModeChanged;
                _basePlayer.Display.Window.SizeChanged -= BasePlayer_DisplaySizeChanged;
                Layout -= BasePlayer_DisplaySizeChanged;
                SystemEvents.DisplaySettingsChanged -= SystemEvents_DisplaySettingsChanged;
                _hasEvents = false;
            }

            if (_display.Visible) _display.Hide();
            startButton.Text = "Start";
            startMenuItem.Text = "Start 'Video Wall'";
        }

        [PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    StopView();

                    _basePlayer.CursorHide.Remove(this);
                    _display.Dispose(); _display = null;

                    _timer.Dispose(); _timer = null;
                    _basePlayer = null;
                    _baseWindow = null;

                    if (components != null) components.Dispose();
                }
                _disposed = true;
            }
            base.Dispose(disposing);
        }

        #endregion

        // ******************************** Event Handling

        #region Event Handling

        // this overlay activated / deactivated
        private void VideoWallOverlay_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                MouseDown += _basePlayer.Display.Drag_MouseDown;
                if (_active) StartView();
            }
            else
            {
                if (_active) StopView();
                MouseDown -= _basePlayer.Display.Drag_MouseDown;
            }
        }

        // baseplayer display size changed
        private void BasePlayer_DisplaySizeChanged(object sender, EventArgs e)
        {
            UpdateActiveView();
        }

        // baseplayer media started
        private void BasePlayer_MediaStarted(object sender, EventArgs e)
        {
            if (_basePlayer.Video.Present)
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
        private void BasePlayer_MediaDisplayModeChanged(object sender, EventArgs e)
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
        private void Display_KeyDown(object sender, KeyEventArgs e)
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

            Graphics sourceGraphics = _basePlayer.Display.Window.CreateGraphics();
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

        private void StartButton_Click(object sender, EventArgs e)
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
        private void StretchMenuItem_Click(object sender, EventArgs e)
        {
            SetMenuCheckMarks(sender);
            _displayMode = 0;
            if (_running) _display.Invalidate();
        }

        // DisplayMode Zoom Menu Item
        private void ZoomMenuItem_Click(object sender, EventArgs e)
        {
            SetMenuCheckMarks(sender);
            _displayMode = 1;
            if (_running) _display.Invalidate();
        }

        // DisplayMode Tiles Stretch Menu Item
        private void TilesStretchMenuItem_Click(object sender, EventArgs e)
        {
            SetMenuCheckMarks(sender);
            _displayMode = 2;
            if (_running) _display.Invalidate();
        }

        // DisplayMode Tiles Zoom Menu Item
        private void TilesZoomMenuItem_Click(object sender, EventArgs e)
        {
            SetMenuCheckMarks(sender);
            _displayMode = 3;
            if (_running) _display.Invalidate();
        }

        // Video Color Brightness, Contrast, Hue and Saturation
        private void VideoColorMenuItem_Click(object sender, EventArgs e)
        {
            VideoColorDialog colorDialog = new VideoColorDialog(_baseWindow, _basePlayer);

            if (_active)
            {
                Point p = Cursor.Position;

                p.X -= colorDialog.Width / 2;
                if (p.X <= _display.Left) p.X = _display.Left + 16;
                else if (p.X + colorDialog.Width >= _display.Left + _display.Width) p.X = (_display.Left + _display.Width) - colorDialog.Width - 16;

                p.Y -= colorDialog.Height / 2;
                if (p.Y <= _display.Top) p.Y = _display.Top + 16;
                else if (p.Y + colorDialog.Height >= _display.Top + _display.Height) p.Y = (_display.Top + _display.Height) - colorDialog.Height - 16;

                colorDialog.Location = p;
                //colorDialog.TopMost = true;
            }
            else
            {
                MainWindow.CenterDialog(this, colorDialog);
            }

            colorDialog.ShowDialog();
            colorDialog.Dispose();
        }

        // Background Color Menu Item
        private void BackColorMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog1 = new ColorDialog {Color = _display.BackColor};
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                _display.BackColor = colorDialog1.Color;
            }
            colorDialog1.Dispose();
        }

        // Quality Mode Normal
        private void NormalQualityMenuItem_Click(object sender, EventArgs e)
        {
            _highQuality = false;
            normalQualityMenuItem.Checked = true;
            highQualityMenuItem.Checked = false;
        }

        // Quality Mode High
        private void HighQualityMenuItem_Click(object sender, EventArgs e)
        {
            _highQuality = true;
            normalQualityMenuItem.Checked = false;
            highQualityMenuItem.Checked = true;
        }

        // Refresh Rate 1 fps Menu Item
        private void Fps01MenuItem_Click(object sender, EventArgs e)
        {
            SetMenuCheckMarks(sender);
            _timer.Interval = FPS01;
        }

        // Refresh Rate 2 fps Menu Item
        private void Fps02MenuItem_Click(object sender, EventArgs e)
        {
            SetMenuCheckMarks(sender);
            _timer.Interval = FPS02;
        }

        // Refresh Rate 5 fps Menu Item
        private void Fps05MenuItem_Click(object sender, EventArgs e)
        {
            SetMenuCheckMarks(sender);
            _timer.Interval = FPS05;
        }

        // Refresh Rate 10 fps Menu Item
        private void Fps10MenuItem_Click(object sender, EventArgs e)
        {
            SetMenuCheckMarks(sender);
            _timer.Interval = FPS10;
        }

        // Refresh Rate 15 fps Menu Item
        private void Fps15MenuItem_Click(object sender, EventArgs e)
        {
            SetMenuCheckMarks(sender);
            _timer.Interval = FPS15;
        }

        // Refresh Rate 20 fps Menu Item
        private void Fps20MenuItem_Click(object sender, EventArgs e)
        {
            SetMenuCheckMarks(sender);
            _timer.Interval = FPS20;
        }

        // Refresh Rate 25 fps Menu Item
        private void Fps25MenuItem_Click(object sender, EventArgs e)
        {
            SetMenuCheckMarks(sender);
            _timer.Interval = FPS25;
        }

        // Refresh Rate 30 fps Menu Item
        private void Fps30MenuItem_Click(object sender, EventArgs e)
        {
            SetMenuCheckMarks(sender);
            _timer.Interval = FPS30;
        }

        // Refresh Rate 40 fps Menu Item
        private void Fps40MenuItem_Click(object sender, EventArgs e)
        {
            SetMenuCheckMarks(sender);
            _timer.Interval = FPS40;
        }

        // Refresh Rate 50 fps Menu Item
        private void Fps50MenuItem_Click(object sender, EventArgs e)
        {
            SetMenuCheckMarks(sender);
            _timer.Interval = FPS50;
        }

        // Refresh Rate 60 fps Menu Item
        private void Fps60MenuItem_Click(object sender, EventArgs e)
        {
            SetMenuCheckMarks(sender);
            _timer.Interval = FPS60;
        }

        // Opacity 25% Menu Item
        private void Opacity25MenuItem_Click(object sender, EventArgs e)
        {
            SetMenuCheckMarks(sender);
            _display.Opacity = 0.25;
            opacityMenuItem.Checked = true;
        }

        // Opacity 50% Menu Item
        private void Opacity50MenuItem_Click(object sender, EventArgs e)
        {
            SetMenuCheckMarks(sender);
            _display.Opacity = 0.5;
            opacityMenuItem.Checked = true;
        }

        // Opacity 75% Menu Item
        private void Opacity75MenuItem_Click(object sender, EventArgs e)
        {
            SetMenuCheckMarks(sender);
            _display.Opacity = 0.75;
            opacityMenuItem.Checked = true;
        }

        // Opacity 100% Menu Item
        private void Opacity100MenuItem_Click(object sender, EventArgs e)
        {
            SetMenuCheckMarks(sender);
            _display.Opacity = 1;
            opacityMenuItem.Checked = false;
        }

        // display settings
        private void DisplaySettingsMenuItem_Click(object sender, EventArgs e)
        {
            if (_display == ActiveForm) _basePlayer.SystemPanels.ShowDisplaySettings();
            else _basePlayer.SystemPanels.ShowDisplaySettings(this);
        }

        // overlay info
        private void OverlayInfoMenuItem_Click(object sender, EventArgs e)
        {
            ShowInfoMessage();
        }

        // Start / Stop Menu Item
        private void StartMenuItem_Click(object sender, EventArgs e)
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

            if (_active)
            {
                string rateText = string.Empty;
                for (int i = 0; i < refreshRateMenuItem.DropDown.Items.Count; i++)
                {
                    if (((ToolStripMenuItem)(refreshRateMenuItem.DropDown).Items[i]).Checked == true)
                    {
                        rateText = refreshRateMenuItem.DropDown.Items[i].Text;
                        break;
                    }
                }
                infoText.AppendLine("Video Wall Activated - Refresh Rate: " + rateText + " - High Quality " + (_highQuality ? "On." : "Off."));
            }

            ErrorDialog infoDialog = new ErrorDialog(MainWindow.APPLICATION_NAME, infoText.ToString(), true, true);

            infoDialog.checkBox1.Hide();
            infoDialog.checkBox2.Hide();

            if (_active)
            {
                Point p = Cursor.Position;

                p.X -= infoDialog.Width/2;
                if (p.X <= _display.Left) p.X = _display.Left + 16;
                else if (p.X + infoDialog.Width >= _display.Left + _display.Width) p.X = (_display.Left + _display.Width) - infoDialog.Width - 16;

                p.Y -= infoDialog.Height / 2;
                if (p.Y <= _display.Top) p.Y = _display.Top + 16;
                else if (p.Y + infoDialog.Height >= _display.Top + _display.Height) p.Y = (_display.Top + _display.Height) - infoDialog.Height - 16;

                infoDialog.Location = p;
                //infoDialog.TopMost = true;
            }
            else
            {
                MainWindow.CenterDialog(this, infoDialog);
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
