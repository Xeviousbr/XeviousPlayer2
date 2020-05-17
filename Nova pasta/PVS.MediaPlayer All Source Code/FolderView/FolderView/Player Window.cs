#region Usings

using PVS.MediaPlayer;
using System;
using System.Drawing;
using System.Windows.Forms;

#endregion

namespace FolderView
{
    public partial class PlayerWindow : Form
    {
        /*
            A simple Player Window.
        */


        // ******************************** Fields

        #region Fields

        MainWindow                  _baseWindow;

        internal Player             _player;
        internal bool               _userMuted;
        internal bool               _audioHold;
        private bool                _disposed;

        private string              _theMovie;
        private TimeSpan            _startTime;

        private DisplayShape        _playerShape;

        private SubtitlesOverlay    _subtitlesOverlay;
        private bool                _subtitlesOn;
        private bool                _subtitlesMenuOn;

        public bool                 _lastError;

        #endregion


        // ******************************** Main

        #region Main

        public PlayerWindow(MainWindow baseWindow, string theMovie, TimeSpan startPosition)
        {
            InitializeComponent();
            Icon = Properties.Resources.Media8a;

            _baseWindow = baseWindow;

            ((ToolStripDropDownMenu)allWindowsMenuItem.DropDown).ShowImageMargin     = false;
            ((ToolStripDropDownMenu)displayModeAllMenuItem.DropDown).ShowImageMargin = false;

            positionLabel1.Font                         = Globals.CrystalFont16;
            positionLabel1.UseCompatibleTextRendering   = true;
            positionLabel2.Font                         = Globals.CrystalFont16;
            positionLabel2.UseCompatibleTextRendering   = true;

            _theMovie   = theMovie;
            _startTime  = startPosition;
            Text        = theMovie;

            _player = new Player();

            _player.Display.Window              = panel1;
            _player.Display.DragEnabled         = true;

            _player.Repeat                      = true;

            _player.Sliders.Position.TrackBar   = customSlider21;
            //_player.Sliders.Position.LiveUpdate = false; // v 0.95 default false

            _player.TaskbarProgress.Add(this);
            _player.TaskbarProgress.Mode        = TaskbarProgressMode.Track;

            _player.Events.MediaPeakLevelChanged += Player_MediaPeakLevelChanged;
            _player.Events.MediaSystemAudioDevicesChanged += Player_MediaSystemAudioDevicesChanged;

            _player.CursorHide.Add(this);

            Opacity = 0; // continue in PlayerWindow_Shown
        }

        private void PlayerWindow_Shown(object sender, EventArgs e)
        {
            Application.DoEvents();

            if (_baseWindow._audioHold) _player.Audio.Enabled = false;

            _player.Events.MediaPositionChanged += Player_MediaPositionChanged;
            _player.Play(_theMovie, _startTime, TimeSpan.Zero);
            _lastError = _player.LastError;

            if (!_lastError)
            {
                // reset the (repeat) startposition to the beginning of file
                // (if not played from the beginning of the file)
                _player.Media.StartTime = TimeSpan.Zero;

                this.KeyPreview = true;
                this.KeyDown += PlayerWindow_KeyDown;

                string path = Globals.Subtitles.Find(_player.Media.GetName(MediaName.FileNameWithoutExtension) + ".srt", _player.Media.GetName(MediaName.DirectoryName), 3);
                if (!string.IsNullOrEmpty(path))
                {
                    _subtitlesOverlay = new SubtitlesOverlay(_player);
                    _player.Overlay.Hold = true;

                    showSubtitlesMenuItem.Enabled = showSubtitleOptionsMenuItem.Enabled = true;
                    showSubtitlesMenuItem.PerformClick();
                }
            }

            Application.DoEvents();
            Opacity = 1;
        }

        // Enable audio when form activated and mute other PlayerWindows
        private void PlayerWindow_Activated(object sender, EventArgs e)
        {
            if (!_baseWindow._audioHold) PlayerWindow_SetAudio();
        }

        // Enable audio when overlay activated
        private void SubtitlesOverlay_Activated(object sender, EventArgs e)
        {
            if (!_baseWindow._audioHold) PlayerWindow_SetAudio();
        }

        // Mute audio when overlay deactivated (and other form activated)
        private void SubtitlesOverlay_Deactivate(object sender, EventArgs e)
        {
            Application.DoEvents();
            if (this.Handle != SafeNativeMethods.GetForegroundWindow())
            {
                if (!_baseWindow._audioHold) _player.Audio.Enabled = false;
            }
        }

        private void PlayerWindow_SetAudio()
        {
            FormCollection windows = Application.OpenForms;
            foreach (Form form in windows)
            {
                //Application.DoEvents(); // error because player (scroll slider) infolabel can be added to openforms
                if (form != null && (form.GetType() == typeof(PlayerWindow)) && form.Handle != this.Handle)
                {
                    if (((PlayerWindow)form)._player != null)
                    {
                        ((PlayerWindow)form)._player.Audio.Enabled = false;
                    }
                }
            }
            if (!_userMuted) _player.Audio.Enabled = true;
        }

        // Esc key cancels fullscreen mode
        private void PlayerWindow_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            if (e.KeyCode == Keys.Q && e.Control)
            {
                Close();
            }
            else
            {
                switch (e.KeyCode)
                {
                    case Keys.Escape:
                        if (_player.FullScreen) fullScreenMenuItem.PerformClick();
                        else Close();
                        break;

                    // FullScreen
                    case Keys.F:
                    case Keys.F11:
                        fullScreenMenuItem.PerformClick();
                        break;

                    // Pause
                    case Keys.P:
                    case Keys.Space:
                        pauseMenuItem.PerformClick();
                        break;

                    // Mute
                    case Keys.M:
                        muteMenuItem.PerformClick();
                        break;

                    // Subtitles
                    case Keys.S:
                        showSubtitlesMenuItem.PerformClick();
                        break;

                    // Properties
                    case Keys.I:
                        propertiesMenuItem.PerformClick();
                        break;

                    // Close
                    case Keys.C:
                        Close();
                        break;

                    default:
                        e.Handled = false;
                        break;
                }
            }
        }

        private void PlayerWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_audioHold)
            {
                _audioHold = false;
                _baseWindow._audioHold = false;
                _baseWindow._audioHoldWindow = null;
            }

            if (e.CloseReason == CloseReason.UserClosing)
            {
                foreach (Form form in Application.OpenForms)
                {
                    Application.DoEvents();
                    if (form != null && (form.GetType() == typeof(PlayerWindow)) && form.Handle != this.Handle)
                    {
                        if (((PlayerWindow)form)._player != null)
                        {
                            form.Activate();
                        }
                    }
                }
            }
        }

        private void Player_MediaPeakLevelChanged(object sender, PeakLevelEventArgs e)
        {
            // update shared peak meters on main form - in combination with window (de-)activation handling
            // no need for any checking, disabling etc., the player takes care of everything

            // replaced original code to combine with the players on the main form with:
            _baseWindow.PaintPeakMeters(e.ChannelsValues[0], e.ChannelsValues[1]);
            // original code moved to PaintPeakMeters method
        }

        // if the default audio device has changed reset peaklevel handlers
        private void Player_MediaSystemAudioDevicesChanged(object sender, SystemAudioDevicesEventArgs e)
        {
            //if (e.Notification == SystemAudioDevicesNotification.DefaultChanged)
            //{
            //    _player.Events.MediaPeakLevelChanged -= Player_MediaPeakLevelChanged;
            //    _player.Events.MediaPeakLevelChanged += Player_MediaPeakLevelChanged;
            //}
        }

        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_subtitlesOverlay != null)
                    {
                        if (_subtitlesOn)
                        {
                            _player.Overlay.Window.Activated -= SubtitlesOverlay_Activated;
                            _player.Overlay.Window.Deactivate -= SubtitlesOverlay_Deactivate;
                        }
                        _player.Overlay.Window = null;

                        _subtitlesOverlay.Dispose();
                        _subtitlesOverlay = null;
                    }
                    _player.Events.MediaPositionChanged -= Player_MediaPositionChanged;
                    _player.Events.MediaSystemAudioDevicesChanged -= Player_MediaSystemAudioDevicesChanged;
                    _player.Events.MediaPeakLevelChanged -= Player_MediaPeakLevelChanged;
                    _player.Dispose(); _player = null;

                    if (components != null) components.Dispose();
                }
                _disposed = true;
                base.Dispose(disposing);
            }
        }

        #endregion


        // ******************************** Player Position Counters / InfoLabel Scroll Eventhandlers

        #region Player Position Counters Eventhandler

        // The playback position of a mediafile has changed - update position info labels
        private void Player_MediaPositionChanged(object sender, PositionEventArgs e)
        {
            positionLabel1.Text = TimeSpan.FromTicks(e.FromStart).ToString().Substring(0, 8); // hh:mm:ss
            positionLabel2.Text = TimeSpan.FromTicks(e.ToEnd).ToString().Substring(0, 8);
        }

        // Show infolabel
        private void CustomSlider21_Scroll(object sender, EventArgs e)
        {
            if (ModifierKeys == Keys.Shift) // don't show with shift key pressed
            {
                _baseWindow.PlayerWindowLabel.Hide(true);
            }
            else
            {
                // Get the position slider's x-coordinate of the current position (= thumb location)
                // (AlignmentOffset has been set to 0, -3)
                Point infoLabelLocation = SliderValue.ToPoint(customSlider21, customSlider21.Value);

                // Show the infolabel
                TimeSpan time = _player.Position.FromStart;
                //_baseWindow.PlayerWindowLabel.Show(
                //    string.Format("{0:00;00}:{1:00;00}:{2:00;00}.{3:000;000}", time.Hours, time.Minutes, time.Seconds, time.Milliseconds),
                //    customSlider21, infoLabelLocation);
                _baseWindow.PlayerWindowLabel.Show(
                    string.Format("{0:00;00}:{1:00;00}:{2:00;00}", time.Hours, time.Minutes, time.Seconds),
                    customSlider21, infoLabelLocation);
            }
        }

        #endregion


        // ******************************** Contextmenu Handler

        #region Contextmenu Handler

        private void PlayerWindowMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            int count = 0;
            foreach (Form window in Application.OpenForms)
            {
                if (window.GetType() == typeof(PlayerWindow))
                {
                    if (++count > 1) break;
                }
            }
            allWindowsMenuItem.Enabled = count > 1;
        }


        #region All Windows

        private void PauseAllMenuItem_Click(object sender, EventArgs e)
        {
            _baseWindow.PauseAllWindows();
        }

        private void ResumeAllMenuItem_Click(object sender, EventArgs e)
        {
            _baseWindow.ResumeAllWindows();
        }

        private void MuteAllMenuItem_Click(object sender, EventArgs e)
        {
            _baseWindow.MuteAllWindows();
        }

        private void StretchAllMenuItem_Click(object sender, EventArgs e)
        {
            _baseWindow.StretchAllWindows();
        }

        private void CoverAllMenuItem_Click(object sender, EventArgs e)
        {
            _baseWindow.CoverAllWindows();
        }

        private void ZoomAllMenuItem_Click(object sender, EventArgs e)
        {
            _baseWindow.ZoomAllWindows();
        }

        private void FullScreenOffAllMenuItem_Click(object sender, EventArgs e)
        {
            _baseWindow.FullScreenOffAllWindows();
        }

        private void HideSubtitlesAllMenuItem_Click(object sender, EventArgs e)
        {
            _baseWindow.HideSubtitlesAllWindows();
        }

        private void ShowSubtitlesAllMenuItem_Click(object sender, EventArgs e)
        {
            _baseWindow.ShowSubtitlesAllWindows();
        }

        private void CloseAllMenuItem_Click(object sender, EventArgs e)
        {
            _baseWindow.CloseAllWindows();
        }

        #endregion

        // Pause / Resume
        private void PauseMenuItem_Click(object sender, EventArgs e)
        {
            if (_player.Paused) DoResume();
            else DoPause();
        }
        internal void PauseMenuFromMain()
        {
            if (!_player.Paused) DoPause();
        }
        internal void ResumeMenuFromMain()
        {
            if (_player.Paused) DoResume();
        }

        private void DoPause()
        {
            _player.Paused = true;
            pauseMenuItem.Text = "Resume";
            Icon = Properties.Resources.Media_Paused;
        }
        private void DoResume()
        {
            _player.Paused = false;
            pauseMenuItem.Text = "Pause";
            Icon = Properties.Resources.Media8a;
        }

        // Mute On / Off
        private void MuteMenuItem_Click(object sender, EventArgs e)
        {
            if (_player.Audio.Enabled)
            {
                _player.Audio.Enabled = false;
                _userMuted = true;
                muteMenuItem.Text = "Mute Off";
            }
            else
            {
                _player.Audio.Enabled = true;
                _userMuted = false;
                muteMenuItem.Text = "Mute";
            }
        }
        internal void MuteMenuFromMain()
        {
            _player.Audio.Enabled = false;
            _userMuted = true;
            muteMenuItem.Text = "Mute Off";
        }
        internal void MuteOffMenuFromMain()
        {
            if (this == ActiveForm) _player.Audio.Enabled = true;
            _userMuted = false;
            muteMenuItem.Text = "Mute";
        }

        // Audio Hold / Release
        private void AudioHoldMenuItem_Click(object sender, EventArgs e)
        {
            if (_audioHold)
            {
                _audioHold                      = false;
                audioHoldMenuItem.Text          = "Audio Hold";

                _baseWindow._audioHold          = false;
                _baseWindow._audioHoldWindow    = null;
            }
            else
            {
                _audioHold                      = true;
                audioHoldMenuItem.Text          = "Audio Release";

                if (_baseWindow._audioHold)
                {
                    _baseWindow._audioHoldWindow._audioHold             = false;
                    _baseWindow._audioHoldWindow._player.Audio.Enabled  = false;
                }
                _baseWindow._audioHold          = true;
                _baseWindow._audioHoldWindow    = this;

                if (!_userMuted) _player.Audio.Enabled = true;
            }
        }

        // DisplayMode Stretch
        private void StretchMenuItem_Click(object sender, EventArgs e)
        {
            StretchMenuFromMain();
        }
        internal void StretchMenuFromMain()
        {
            _player.Display.Mode = DisplayMode.Stretch;
            stretchMenuItem.Checked = true;
            coverMenuItem.Checked = false;
            zoomMenuItem.Checked = false;
        }

        // DisplayMode Cover
        private void CoverMenuItem_Click(object sender, EventArgs e)
        {
            CoverMenuFromMain();
        }
        internal void CoverMenuFromMain()
        {
            _player.Display.Mode = DisplayMode.CoverCenter;
            stretchMenuItem.Checked = false;
            coverMenuItem.Checked = true;
            zoomMenuItem.Checked = false;
        }

        // DisplayMode Zoom
        private void ZoomMenuItem_Click(object sender, EventArgs e)
        {
            ZoomMenuFromMain();
        }
        internal void ZoomMenuFromMain()
        {
            _player.Display.Mode = DisplayMode.ZoomCenter;
            stretchMenuItem.Checked = false;
            coverMenuItem.Checked = false;
            zoomMenuItem.Checked = true;
        }

        // FullScreen On / Off
        private void FullScreenMenuItem_Click(object sender, EventArgs e)
        {
            if (_player.FullScreen)
            {
                _player.FullScreen = false;
                fullScreenMenuItem.Text = "FullScreen";
                if (_player.Has.DisplayShape) FormBorderStyle = FormBorderStyle.None;
            }
            else
            {
                if (_player.Has.DisplayShape) FormBorderStyle = FormBorderStyle.Sizable;
                _player.FullScreen = true;
                fullScreenMenuItem.Text = "FullScreen Off";
            }
        }
        internal void FullScreenOffFromMain()
        {
            if (_player.FullScreen)
            {
                _player.FullScreen = false;
                fullScreenMenuItem.Text = "FullScreen";
            }
        }

        // Subtitles
        private void ShowSubtitlesMenuItem_Click(object sender, EventArgs e)
        {
            _subtitlesOn = !_subtitlesOn;
            if (_subtitlesOn)
            {
                if (_subtitlesOverlay != null)
                {
                    _player.Overlay.Window = _subtitlesOverlay;
                    _player.Overlay.Window.Activated += SubtitlesOverlay_Activated;
                    _player.Overlay.Window.Deactivate += SubtitlesOverlay_Deactivate;

                    showSubtitlesMenuItem.Text = "Hide Subtitles";
                    showSubtitleOptionsMenuItem.Enabled = true;
                }
                else
                {
                    _subtitlesOn = false;
                }
            }
            else
            {
                _player.Overlay.Window.Activated -= SubtitlesOverlay_Activated;
                _player.Overlay.Window.Deactivate -= SubtitlesOverlay_Deactivate;
                _player.Overlay.Window = null;

                showSubtitleOptionsMenuItem.Enabled = false;
                showSubtitlesMenuItem.Text = "Show Subtitles";
            }
        }
        internal void SubtitlesOffFromMain()
        {
            if (_subtitlesOn)
            {
                _player.Overlay.Window.Activated -= SubtitlesOverlay_Activated;
                _player.Overlay.Window.Deactivate -= SubtitlesOverlay_Deactivate;
                _player.Overlay.Window = null;

                showSubtitleOptionsMenuItem.Enabled = false;
                showSubtitlesMenuItem.Text = "Show Subtitles";

                _subtitlesOn = false;
            }

            if (_subtitlesMenuOn)
            {
                showSubtitleOptionsMenuItem.Text = "Show Subtitles Menu";
                _subtitlesOverlay.MenuEnabled = _player.Overlay.CanFocus = false;

                _subtitlesMenuOn = false;
            }
        }
        internal void SubtitlesOnFromMain()
        {
            if (!_subtitlesOn)
            {
                if (_subtitlesOverlay != null)
                {
                    _player.Overlay.Window = _subtitlesOverlay;
                    _player.Overlay.Window.Activated += SubtitlesOverlay_Activated;
                    _player.Overlay.Window.Deactivate += SubtitlesOverlay_Deactivate;

                    showSubtitlesMenuItem.Text = "Hide Subtitles";
                    showSubtitleOptionsMenuItem.Enabled = true;

                    _subtitlesOn = true;
                }
            }
        }

        // Subtitles Menu
        private void ShowSubtitleOptionsMenuItem_Click(object sender, EventArgs e)
        {
            _subtitlesMenuOn = !_subtitlesMenuOn;
            if (_subtitlesMenuOn)
            {
                showSubtitleOptionsMenuItem.Text = "Hide Subtitles Menu";
                _subtitlesOverlay.MenuEnabled = _player.Overlay.CanFocus = true;
            }
            else
            {
                showSubtitleOptionsMenuItem.Text = "Show Subtitles Menu";
                _subtitlesOverlay.MenuEnabled = _player.Overlay.CanFocus = false;
            }
        }

        // Properties
        private void PropertiesMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SafeNativeMethods.SHELLEXECUTEINFO info = new SafeNativeMethods.SHELLEXECUTEINFO();
                info.cbSize = System.Runtime.InteropServices.Marshal.SizeOf(info);
                info.lpVerb = "properties";
                info.lpParameters = "details";
                info.lpFile = _player.Media.GetName(MediaName.FullPath);
                info.nShow = SafeNativeMethods.SW_SHOW;
                info.fMask = SafeNativeMethods.SEE_MASK_INVOKEIDLIST;
                SafeNativeMethods.ShellExecuteEx(ref info);
            }
            catch { /* ignore */ }
        }

        // Close
        private void CloseMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion


        // ******************************** Set Display Shapes

        #region Set Display Shapes

        //private void FrameShapeMenuItem_Click(object sender, EventArgs e)
        //{
        //    SetDisplayShape(frameShapeMenuItem, DisplayShape.Frame);
        //}

        private void HeartShapeMenuItem_Click(object sender, EventArgs e)
        {
            SetDisplayShape(heartShapeMenuItem, DisplayShape.Heart);
        }

        private void OvalShapeMenuItem_Click(object sender, EventArgs e)
        {
            SetDisplayShape(ovalShapeMenuItem, DisplayShape.Oval);
        }

        private void RectangleShapeMenuItem_Click(object sender, EventArgs e)
        {
            SetDisplayShape(rectangleShapeMenuItem, DisplayShape.Rectangle);
        }

        //private void RingShapeMenuItem_Click(object sender, EventArgs e)
        //{
        //    SetDisplayShape(ringShapeMenuItem, DisplayShape.Ring);
        //}

        private void RoundedShapeMenuItem_Click(object sender, EventArgs e)
        {
            SetDisplayShape(roundedShapeMenuItem, DisplayShape.Rounded);
        }

        private void StarShapeMenuItem_Click(object sender, EventArgs e)
        {
            SetDisplayShape(starShapeMenuItem, DisplayShape.Star);
        }

        private void TilesShapeMenuItem_Click(object sender, EventArgs e)
        {
            SetDisplayShape(tilesShapeMenuItem, DisplayShape.Tiles);
        }

        private void NormalShapeMenuItem_Click(object sender, EventArgs e)
        {
            SetDisplayShape(normalShapeMenuItem, DisplayShape.Normal);
        }

        private void SetDisplayShape(ToolStripMenuItem menuItem, DisplayShape shape)
        {
            if (shape != _playerShape)
            {
                // set form border
                if (shape == DisplayShape.Normal)
                {
                    if (_playerShape != DisplayShape.Normal)
                    {
                        SuspendLayout();

                        BackColor       = Color.FromArgb(18, 18, 18);
                        if (!_player.FullScreen) FormBorderStyle = FormBorderStyle.Sizable;
                        TransparencyKey = Color.Empty;

                        positionLabel1.Visible = true;
                        positionLabel2.Visible = true;
                        customSlider21.Visible = true;

                        ResumeLayout();
                    }
                }
                else
                {
                    if (_playerShape == DisplayShape.Normal)
                    {
                        if (!_player.FullScreen) FormBorderStyle = FormBorderStyle.None;
                        TransparencyKey = Color.RosyBrown;
                        BackColor       = Color.RosyBrown;

                        positionLabel1.Visible = false;
                        positionLabel2.Visible = false;
                        customSlider21.Visible = false;

                        normalShapeMenuItem.Checked = false;
                    }
                }

                // uncheck menu items
                int count = displayShapeMenuItem.DropDown.Items.Count - 2;
                for (int i = 0; i < count; i++)
                {
                    ((ToolStripMenuItem)displayShapeMenuItem.DropDown.Items[i]).Checked = false;
                }
                menuItem.Checked = true;
                displayShapeMenuItem.Checked = !normalShapeMenuItem.Checked;

                // set form shape
                _playerShape = shape;
                _player.Display.SetShape(shape);
            }
        }

        #endregion
    }
}
