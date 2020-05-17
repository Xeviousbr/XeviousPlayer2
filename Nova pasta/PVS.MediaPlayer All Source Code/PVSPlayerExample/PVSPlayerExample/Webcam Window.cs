#region Usings

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows.Forms;
using PVS.MediaPlayer;

#endregion

namespace PVSPlayerExample
{
    /*
        A simple webcam window
        The webcam video and (optional) input audio are played by separate players.
    */

    public partial class Webcam_Window : Form
    {
        #region Fields

        private const int           START_AUDIO_DEVICE_ITEMS    = 1;
        private const int           COPY_TIMER_INTERVAL         = 1500; // milliseconds


        private double              _oldOpacity;
        private Size                _formSize;
        private bool                _shapeBorder;
        private bool                _disposed;

        // Players
        private Player              _webcamPlayer;
        private Player              _audioPlayer;

        // Webcam
        private WebcamDevice        _webcam;

        // Webcam Formats
        private WebcamFormat[]      _formatMenuItems;
        private int                 _selectedFormat;            // menu index

        // Audio In
        private AudioInputDevice[]  _audioInMenuItems;
        private AudioInputDevice    _audioInDeviceSelected;
        // when audioplayer is stopped, the audio input menu is set to "None" in the MediaEnded eventhandler, don't do this with restart audioplayer
        // it's not caused by the player but by this sample code - and it's all right, but don't do it with a restart
        private bool                _ignoreAudioInputMenu; // with restart of audioPlayer - don't reset menu in MediaEnded eventhandler

        // Audio Out
        private AudioDevice[]       _audioOutMenuItems;
        private AudioDevice         _audioOutDeviceSelected;
        private bool                _volumeRedDial;
        private bool                _dontSetVolumeDial;

        // Display Clones
        private List<CloneWindow>   _cloneWindows;
        private int                 _cloneCount;

        // Screen Copy
        private string              _picturesFolder;
        private bool                _copyMessageOn;
        private Timer               _copyTimer;

        // Automatic Screen Copy
        private Timer               _autoCopyTimer;
        private int                 _autoCopyInterval;

        // Display Overlays
        private bool                _copyOverlayOn;
        private WebcamCopyOverlay   _copyOverlay;
        private bool                _zoomOverlayOn;
        private ZoomSelectOverlay   _zoomOverlay;
        private bool                _scribbleOverlayOn;
        private ScribbleOverlay     _scribbleOverlay;

        #endregion


        #region Main

        public Webcam_Window(WebcamDevice webcam)
        {
            InitializeComponent();
            _webcam = webcam;
            
            ((ToolStripDropDownMenu)screenCopyMenuItem.DropDown).ShowImageMargin = false;
            ((ToolStripDropDownMenu)displayCloneMenuItem.DropDown).ShowImageMargin = false;

            _webcamPlayer                       = new Player(webcamDisplay);
            _webcamPlayer.SleepDisabled         = true;
            _webcamPlayer.PlayUnblock           = true;
            _webcamPlayer.Display.DragEnabled   = true;
            _webcamPlayer.CursorHide.Add(this);

            _audioPlayer                        = new Player();
            _audioPlayer.PlayUnblock            = true;
            _audioPlayer.LowLatency             = true;

            _cloneWindows = new List<CloneWindow>(8);
            _webcamPlayer.DisplayClones.ShowOverlay = false;

            _picturesFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), webcam.Name);

            _copyTimer          = new Timer();
            _copyTimer.Interval = COPY_TIMER_INTERVAL;
            _copyTimer.Tick     += CopyTimer_Tick;

            _copyOverlay = new WebcamCopyOverlay();

            _oldOpacity = Opacity;
            Opacity = 0;
        }

        private void Webcam_Window_Shown(object sender, System.EventArgs e)
        {
            if (_webcam == null)
            {
                Close();
            }
            else
            {
                Icon = Properties.Resources.Media_Playing;
                Text = _webcam.Name;

                volumeDial.ValueChanged += VolumeDial_ValueChanged;
                volumeDial.Value = (int)(_audioPlayer.Audio.Volume * 1000);

                Application.DoEvents();
                Opacity = _oldOpacity;

                _webcamPlayer.Play(_webcam, WebcamQuality.High);
                if (_webcamPlayer.LastError)
                {
                    SetWebcamWindowError(_webcamPlayer.LastErrorString);
                }
                else
                {
                    // use the framerate of the high quality format as guide to fill the format menu.
                    CreateFormatMenu((int)_webcamPlayer.Webcam.Format.FrameRate);
                    CreateAudioInputMenu();
                    CreateAudioOutputMenu();

                    _webcamPlayer.Events.MediaEnded += WebcamPlayer_MediaEnded;
                    _webcamPlayer.Events.MediaDisplayModeChanged += WebcamPlayer_MediaDisplayModeChanged;

                    _audioPlayer.Events.MediaEnded += AudioPlayer_MediaEnded;
                    _audioPlayer.Events.MediaSystemAudioDevicesChanged += AudioPlayer_MediaSystemAudioDevicesChanged;
                    _audioPlayer.Events.MediaAudioDeviceChanged += AudioPlayer_MediaAudioDeviceChanged;
                    _audioPlayer.Events.MediaAudioVolumeChanged += AudioPlayer_MediaAudioVolumeChanged;

                    if (ShowInTaskbar) _webcamPlayer.TaskbarProgress.Add(this);
                    showInTaskbarMenuItem.Checked = ShowInTaskbar;
                    alwaysOnTopMenuItem.Checked = TopMost;
                }
            }
        }

        private void Webcam_Window_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
        }

        // should be ProcessKeyPreview?
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.F3: // Screencopy to clipboard
                    copyToClipboardMenuItem.PerformClick();
                    break;

                case Keys.F4: // Screencopy to file (auto save in documents folder)
                    copyToFileMenuItem.PerformClick();
                    break;

                case Keys.F11: // toggle full screen mode
                    fullScreenMenuItem.PerformClick();
                    break;

                case Keys.Control | Keys.D: // add display clone
                    addDisplayCloneMenuItem.PerformClick();
                    break;

                case Keys.Escape: // escape full screen mode
                    if (_webcamPlayer.FullScreen)
                    {
                        fullScreenMenuItem.PerformClick();
                    }
                    break;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
            return true;
        }

        private void Menu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _webcamPlayer.CursorHide.Enabled = false;
            if (sender == audioInputMenu)
            {
                if (audioInputMenu.Width < audioInputButton.Width)
                {
                    audioInputMenu.AutoSize = false;
                    int width = audioInputButton.Width;
                    audioInputMenu.Width = width;
                    int count = audioInputMenu.Items.Count;
                    for (int i = 0; i < count; i++)
                    {
                        audioInputMenu.Items[i].AutoSize = false;
                        audioInputMenu.Items[i].Width = width;
                    }
                }
            }
        }

        private void Menu_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            if (sender == audioInputMenu)
            {
                audioInputMenu.AutoSize = true;
                int count = audioInputMenu.Items.Count;
                for (int i = 0; i < count; i++)
                {
                    audioInputMenu.Items[i].AutoSize = true;
                }
            }
            _webcamPlayer.CursorHide.Enabled = true;
        }

        private bool _isMinimized;
        // This has to do with clone windows (or any child window) and display overlays that 'CanFocus':
        // if the owner/parent of the clone windows is the main window, a focused display overlay (on the main window) might show in front of the clone windows
        // if the clone windows have no owner/parent, they stay visible (but without video picture) when the main window is minimized
        // so we're using clone windows without owner/parent but make them invisible (minimized) when the main window is minimized.
        // Yes, having editable items on a display overlay might not always be a good idea. :)
        private void WebcamWindow_Resize(object sender, EventArgs e)
        {
            if (_webcamPlayer.Has.DisplayClones)
            {
                if (WindowState == FormWindowState.Minimized)
                {
                    if (!_isMinimized)
                    {
                        CloneWindows_SetVisibility(false);
                        _isMinimized = true;
                    }
                }
                else if (_isMinimized)
                {
                    CloneWindows_SetVisibility(true);
                    _isMinimized = false;
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                _disposed = true;
                if (disposing)
                {
                    StopAutoCopy();

                    if (_webcamPlayer.Has.DisplayClones)
                    {
                        _webcamPlayer.DisplayClones.RemoveAll();
                        RemoveAllClonewindows();
                    }

                    _webcamPlayer.Overlay.Remove();
                    if (_copyOverlay != null) _copyOverlay.Dispose();
                    if (_zoomOverlay != null) _zoomOverlay.Dispose();
                    if (_scribbleOverlay != null) _scribbleOverlay.Dispose();

                    Visible = false;

                    if (_audioPlayer != null) { _audioPlayer.Dispose(); _audioPlayer = null; }
                    if (_webcamPlayer != null) { _webcamPlayer.SleepDisabled = false;  _webcamPlayer.Dispose(); _webcamPlayer = null; }

                    if (_copyTimer != null) _copyTimer.Dispose();

                    _webcam = null;
                    _formatMenuItems = null;

                    if (components != null) components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #endregion

        #region Players Event Handlers

        // to detect webcam disconnect
        private void WebcamPlayer_MediaEnded(object sender, EndedEventArgs e)
        {            
            if (e.StopReason == StopReason.Error) SetWebcamWindowError(_webcamPlayer.GetErrorString(e.ErrorCode));
            else SetWebcamWindowError("Stopped");
        }

        private void WebcamPlayer_MediaDisplayModeChanged(object sender, EventArgs e)
        {
            MainWindow.UnCheckMenuItems(displayModeMenuItem.DropDown, 0, 0);
            switch (_webcamPlayer.Display.Mode)
            {
                case DisplayMode.ZoomCenter:
                    zoomMenuItem.Checked = true;
                    displayModeMenuItem.Checked = false;
                    break;

                case DisplayMode.CoverCenter:
                    coverMenuItem.Checked = true;
                    displayModeMenuItem.Checked = true;
                    break;

                case DisplayMode.Stretch:
                    stretchMenuItem.Checked = true;
                    displayModeMenuItem.Checked = true;
                    break;

                default:
                    manualMenuItem.Checked = true;
                    displayModeMenuItem.Checked = true;
                    break;
            }
        }

        private void AudioPlayer_MediaEnded(object sender, EndedEventArgs e)
        {
            if (!_ignoreAudioInputMenu)
            {
                _audioInDeviceSelected = null;
                CreateAudioInputMenu();
            }
        }

        // when an error has occured
        private void SetWebcamWindowError(string errorText)
        {
            StopAutoCopy();
            removeAllClonesMenuItem.PerformClick();

            //webcamDisplay.ContextMenuStrip = null;
            displayCloneMenuItem.Enabled = false;
            videoColorMenuItem.Enabled = false;
            propertiesMenuItem.Enabled = false;
            screenCopyMenuItem.Enabled = false;

            webcamFormatLabel.ForeColor = Color.Gray;
            webcamFormatButton.ForeColor = Color.Gray;
            webcamFormatButton.ShowDropDownArrow = false;
            webcamFormatButton.Enabled = false;

            audioInputLabel.ForeColor = Color.Gray;
            audioInputButton.ForeColor = Color.Gray;
            audioInputButton.ShowDropDownArrow = false;
            audioInputButton.Enabled = false;

            audioOutputLabel.ForeColor = Color.Gray;
            audioOutputButton.ForeColor = Color.Gray;
            audioOutputButton.ShowDropDownArrow = false;
            audioOutputButton.Enabled = false;

            volumeDial.Enabled = false;

            Icon = Properties.Resources.Media_Normal;
            Label message = new Label();
            message.Font = new Font(message.Font.FontFamily, 22);
            message.ForeColor = Color.Maroon;
            message.TextAlign = ContentAlignment.MiddleCenter;

            if (System.Globalization.CultureInfo.CurrentCulture.TextInfo.IsRightToLeft) message.Text = _webcam.Name + "\r\n." + errorText;
            else message.Text = _webcam.Name + "\r\n" + errorText + ".";

            message.Dock = DockStyle.Fill;
            webcamDisplay.Controls.Add(message);

            if (_audioPlayer != null) { _audioPlayer.Dispose(); _audioPlayer = null; }
            //if (_webcamPlayer != null) { _webcamPlayer.Dispose(); _webcamPlayer = null; }

            message.MouseDown += _webcamPlayer.Display.Drag_MouseDown;
        }

        // to detect system audio input or ouput device changes
        private void AudioPlayer_MediaSystemAudioDevicesChanged(object sender, SystemAudioDevicesEventArgs e)
        {
            if (e.IsInputDevice)
            {
                if (_audioPlayer != null && _audioPlayer.Playing)
                {
                    if (e.Notification == SystemAudioDevicesNotification.Disabled || e.Notification == SystemAudioDevicesNotification.Removed)
                    {
                        if (e.DeviceId == _audioPlayer.AudioInput.Device.Id)
                        {
                            // when the used audio input device is removed, the media ended event is raised (with audio input device players only)
                            _audioInDeviceSelected = null;
                        }
                    }
                }
                CreateAudioInputMenu();
            }
            else
            {
                CreateAudioOutputMenu(); // output devices
            }
        }

        // to set the player's audio output device when changed by user
        private void AudioPlayer_MediaAudioDeviceChanged(object sender, EventArgs e)
        {
            _audioOutDeviceSelected = _audioPlayer.Audio.Device;
            CreateAudioOutputMenu();
        }

        // to set the audio rotary knob when the volume is changed using the context menu of the knob
        private void AudioPlayer_MediaAudioVolumeChanged(object sender, EventArgs e)
        {
            if (_audioPlayer.Audio.Volume == 0)
            {
                if (!_volumeRedDial)
                {
                    _volumeRedDial = true;
                    volumeDial.SwitchImage(true);
                }
            }
            else
            {
                if (_volumeRedDial && !_audioPlayer.Audio.Mute)
                {
                    _volumeRedDial = false;
                    volumeDial.SwitchImage(false);
                }
            }

            if (!_dontSetVolumeDial) volumeDial.SetValue((int)(_audioPlayer.Audio.Volume * 1000)); // does not raise changed event
        }

        #endregion

        #region Format Menu

        // the selection of webcam formats used here can be greatly simplified if desired

        // create the webcam format menu - called only once at start up
        private void CreateFormatMenu(int frameRate)
        {
            if (frameRate > 30) frameRate = 30;
            _formatMenuItems = _webcamPlayer.Webcam.GetFormats(_webcam, false, 640, 480, frameRate);
            int count = _formatMenuItems == null ? 0 : _formatMenuItems.Length;
            if (count > 0)
            {
                StringBuilder text = new StringBuilder(32);
                formatMenu.SuspendLayout();
                formatMenu.Items.Clear();
                for (int i = 0; i < count; i++)
                {
                    text.Append(_formatMenuItems[i].VideoWidth)
                        .Append(" x ")
                        .Append(_formatMenuItems[i].VideoHeight)
                        .Append(", ").Append(_formatMenuItems[i].FrameRate)
                        .Append(" fps");
                    formatMenu.Items.Add(text.ToString());
                    text.Length = 0;
                }
                formatMenu.ResumeLayout();

                formatMenu.ItemClicked += FormatMenu_ItemClicked;
            }

            SetFormatMenu(_webcamPlayer.Webcam.Format);
        }

        // set the webcam format menu (button text and checkmarks) - called every time another format is selected
        private void SetFormatMenu(WebcamFormat format)
        {
            string text = format.VideoWidth.ToString() + " x " + format.VideoHeight + ", " + format.FrameRate + " fps";
            int count = _formatMenuItems == null ? 0 : _formatMenuItems.Length;
            if (count > 0)
            {
                for (int i = 0; i < count; i++) ((ToolStripMenuItem)formatMenu.Items[i]).Checked = false;
                for (int i = 0; i < count; i++)
                {
                    if (_formatMenuItems[i].VideoWidth == format.VideoWidth &&
                        _formatMenuItems[i].VideoHeight == format.VideoHeight &&
                        _formatMenuItems[i].FrameRate == format.FrameRate)
                    {
                        ((ToolStripMenuItem)formatMenu.Items[i]).Checked = true;
                        webcamFormatButton.Text = formatMenu.Items[i].Text;
                        _selectedFormat = i;
                        break;
                    }
                }
            }
            else
            {
                webcamFormatButton.Text = text;
            }
        }

        // handle webcam format menu item selection
        private void FormatMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            int index = formatMenu.Items.IndexOf(e.ClickedItem);
            if (index != _selectedFormat)
            {
                formatMenu.Close();
                _webcamPlayer.Webcam.Format = _formatMenuItems[index];
                SetFormatMenu(_webcamPlayer.Webcam.Format);
                if (_audioInDeviceSelected != null)
                {
                    _ignoreAudioInputMenu = true; // don't renew input menu (or it is set to "None" when restart of audioPlayer)
                    _audioPlayer.Play(_audioInDeviceSelected); // restart because of possible delay
                    _ignoreAudioInputMenu = false;
                }
            }
        }

        #endregion

        #region Audio Input Menu

        // the selection of audio input devices used here can be greatly simplified if desired

        // create the audio input menu - at start up and when the system input devices have changed
        private void CreateAudioInputMenu()
        {
            audioInputMenu.SuspendLayout();
            audioInputMenu.Items.Clear();

            _audioInMenuItems = _audioPlayer.AudioInput.GetDevices();
            int count = _audioInMenuItems == null ? 0 : _audioInMenuItems.Length;
            if (count > 0)
            {
                StringBuilder text = new StringBuilder(32);
                for (int i = 0; i < count; i++)
                {
                    text.Append(_audioInMenuItems[i].Name)
                        .Append(" (")
                        .Append(_audioInMenuItems[i].Adapter)
                        .Append(")");
                    audioInputMenu.Items.Add(text.ToString());
                    text.Length = 0;
                }
                audioInputMenu.Items.Add("-");
                audioInputMenu.Items[count++].Enabled = false;
                audioInputMenu.Items.Add("None");
            }

            audioInputMenu.ResumeLayout();
            SetAudioInputMenu();
        }

        // set the audio input menu - called after "CreateAudioInputMenu'' (above) and when an item has been selected from the menu
        // when there are no audio input devices or the input device = null (None) the audio player is stopped.
        private void SetAudioInputMenu()
        {
            int count = _audioInMenuItems == null ? 0 : _audioInMenuItems.Length;
            if (count == 0)
            {
                _audioInDeviceSelected = null;
                audioInputMenu.Items.Clear();
                audioInputMenu.Items.Add("None");
                audioInputMenu.Items[0].Enabled = false;
                audioInputButton.Text = "None";
                _audioPlayer.Stop();
            }
            else
            {
                bool set = false;
                for (int i = 0; i < count; i++)
                {
                    if (_audioInDeviceSelected != null && _audioInMenuItems[i].Id == _audioInDeviceSelected.Id)
                    {
                        ((ToolStripMenuItem)audioInputMenu.Items[i]).Checked = true;
                        _audioInDeviceSelected = _audioInMenuItems[i];
                        audioInputButton.Text = audioInputMenu.Items[i].Text; //  _audioInDeviceSelected.Name;
                        set = true;
                    }
                    else ((ToolStripMenuItem)audioInputMenu.Items[i]).Checked = false;
                }
                if (!set)
                {
                    _audioInDeviceSelected = null;
                    ((ToolStripMenuItem)audioInputMenu.Items[count + 1]).Checked = true;
                    audioInputButton.Text = "None";
                    _audioPlayer.Stop();
                }
                else ((ToolStripMenuItem)audioInputMenu.Items[count + 1]).Checked = false;
            }
        }

        // handle audio input menu selection - the last 2 items in the menu are a (not selectable) separator line and the option "None"
        // after an item is selected "SetAudioInputMenu" (above) is called
        private void AudioInputMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            int index = audioInputMenu.Items.IndexOf(e.ClickedItem);

            if (_audioInMenuItems == null || index >= _audioInMenuItems.Length)
            {
                _audioInDeviceSelected = null;
                _audioPlayer.Stop();
            }
            else
            {
                if (!((ToolStripMenuItem)audioInputMenu.Items[index]).Checked)
                {
                    _ignoreAudioInputMenu = true;
                    _audioInDeviceSelected = _audioInMenuItems[index];
                    _audioPlayer.Play(_audioInDeviceSelected);
                    _ignoreAudioInputMenu = false;
                }
            }
            SetAudioInputMenu();
        }

        #endregion

        #region Audio Output Menu

        // the selection of audio output devices used here can be greatly simplified if desired

        // create the audio output menu - at start up and when the system output devices have changed
        private void CreateAudioOutputMenu()
        {
            audioOutputMenu.SuspendLayout();

            while (audioOutputMenu.Items.Count > START_AUDIO_DEVICE_ITEMS) audioOutputMenu.Items.RemoveAt(START_AUDIO_DEVICE_ITEMS);

            _audioOutMenuItems = _audioPlayer.Audio.GetDevices();
            if (_audioOutMenuItems != null)
            {
                int count = _audioOutMenuItems.Length;
                if (count > 1) // || _audioPlayer.Audio.Device != null)
                {
                    StringBuilder text = new StringBuilder(32);
                    for (int i = 0; i < count; i++)
                    {
                        text.Append(_audioOutMenuItems[i].Name)
                            .Append(" (")
                            .Append(_audioOutMenuItems[i].Adapter)
                            .Append(")");
                        audioOutputMenu.Items.Add(text.ToString());
                        text.Length = 0;
                    }
                }
            }

            audioOutputMenu.ResumeLayout();
            SetAudioOutputMenu();
        }

        // set the audio output menu - called after "CreateAudioOutputMenu" (above)
        private void SetAudioOutputMenu()
        {
            int count = _audioOutMenuItems == null ? 0 : _audioOutMenuItems.Length;
            if (count == 0)
            {
                _audioOutDeviceSelected = null;
                audioOutputButton.Text = "[ No Devices ]";
            }
            else
            {
                bool set = false;
                if (count > 1 || _audioPlayer.Audio.Device != null)
                {
                    for (int i = 0; i < count; i++)
                    {
                        if (_audioOutDeviceSelected != null && _audioOutMenuItems[i].Id == _audioOutDeviceSelected.Id)
                        {
                            ((ToolStripMenuItem)audioOutputMenu.Items[i + START_AUDIO_DEVICE_ITEMS]).Checked = true;
                            _audioOutDeviceSelected = _audioOutMenuItems[i];
                            audioOutputButton.Text = _audioOutDeviceSelected.Name;
                            set = true;
                        }
                        else ((ToolStripMenuItem)audioOutputMenu.Items[i + START_AUDIO_DEVICE_ITEMS]).Checked = false;
                    }
                }
                if (!set)
                {
                    _audioOutDeviceSelected = null;
                    ((ToolStripMenuItem)audioOutputMenu.Items[0]).Checked = true;
                    audioOutputButton.Text = "[ " + _audioPlayer.Audio.GetDefaultDevice().Name + " ]";
                }
                else ((ToolStripMenuItem)audioOutputMenu.Items[START_AUDIO_DEVICE_ITEMS - 1]).Checked = false;
            }
        }

        // handle audio output menu selection - the first item in the menu is the option "System Default"
        // after an item is selected "CreateAudioOutputMenu" (above) is called via "Events_MediaAudioDeviceChanged" (above)
        private void AudioOutputMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            int index = audioOutputMenu.Items.IndexOf(e.ClickedItem);

            if (!((ToolStripMenuItem)audioOutputMenu.Items[index]).Checked)
            {
                if (index == 0) _audioPlayer.Audio.Device = null;
                else _audioPlayer.Audio.Device = _audioOutMenuItems[index - START_AUDIO_DEVICE_ITEMS];
                // changes are handled by Events_MediaAudioDeviceChanged (above)
            }
        }

        #endregion

        #region Audio Volume Dial

        private void VolumeDial_ValueChanged(object sender, Dial.ValueChangedEventArgs e)
        {
            _dontSetVolumeDial = true;
            _audioPlayer.Audio.Volume = (float)volumeDial.Value / 1000;
            _dontSetVolumeDial = false;
        }

        private void AudioVolumeMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            _audioPlayer.Audio.Volume = audioVolumeMenu.Items.IndexOf(e.ClickedItem) * 0.25f;
        }

        #endregion

        #region Display Menu

        #region Display Mode

        private void ZoomMenuItem_Click(object sender, EventArgs e)
        {
            // menu handled by eventhandler
            _webcamPlayer.Display.Mode = DisplayMode.ZoomCenter;
        }

        private void CoverMenuItem_Click(object sender, EventArgs e)
        {
            // menu handled by eventhandler
            _webcamPlayer.Display.Mode = DisplayMode.CoverCenter;
        }

        private void StretchMenuItem_Click(object sender, EventArgs e)
        {
            // menu handled by eventhandler
            _webcamPlayer.Display.Mode = DisplayMode.Stretch;
        }

        #endregion

        #region Display Shape

        private void ArrowDownMenuItem_Click(object sender, EventArgs e)
        {
            SetDisplayShape(DisplayShape.ArrowDown, (ToolStripMenuItem)sender);
        }

        private void ArrowLeftMenuItem_Click(object sender, EventArgs e)
        {
            SetDisplayShape(DisplayShape.ArrowLeft, (ToolStripMenuItem)sender);
        }

        private void ArrowRightMenuItem_Click(object sender, EventArgs e)
        {
            SetDisplayShape(DisplayShape.ArrowRight, (ToolStripMenuItem)sender);
        }

        private void ArrowUpMenuItem_Click(object sender, EventArgs e)
        {
            SetDisplayShape(DisplayShape.ArrowUp, (ToolStripMenuItem)sender);
        }

        private void CircleMenuItem_Click(object sender, EventArgs e)
        {
            SetDisplayShape(DisplayShape.Circle, (ToolStripMenuItem)sender);
        }

        private void FrameMenuItem_Click(object sender, EventArgs e)
        {
            SetDisplayShape(DisplayShape.Frame, (ToolStripMenuItem)sender);
        }

        private void HeartMenuItem_Click(object sender, EventArgs e)
        {
            SetDisplayShape(DisplayShape.Heart, (ToolStripMenuItem)sender);
        }

        private void OvalMenuItem_Click(object sender, EventArgs e)
        {
            SetDisplayShape(DisplayShape.Oval, (ToolStripMenuItem)sender);
        }

        private void RectangleMenuItem_Click(object sender, EventArgs e)
        {
            SetDisplayShape(DisplayShape.Rectangle, (ToolStripMenuItem)sender);
        }

        private void RoundedMenuItem_Click(object sender, EventArgs e)
        {
            SetDisplayShape(DisplayShape.Rounded, (ToolStripMenuItem)sender);
        }

        private void StarMenuItem_Click(object sender, EventArgs e)
        {
            SetDisplayShape(DisplayShape.Star, (ToolStripMenuItem)sender);
        }

        private void NormalShapeMenuItem_Click(object sender, EventArgs e)
        {
            SetDisplayShape(DisplayShape.Normal, (ToolStripMenuItem)sender);
        }

        private void SetDisplayShape(DisplayShape shape, ToolStripMenuItem menuItem)
        {
            if (_webcamPlayer.Display.Shape != shape)
            {
                MainWindow.UnCheckMenuItems(displayShapeMenuItem.DropDown, 0, 0);
                menuItem.Checked = true;
                displayShapeMenuItem.Checked = shape != DisplayShape.Normal;

                // see also "FullScreenMenuItem_Click" below
                if (shape == DisplayShape.Normal)
                {
                    // restore window
                    panel1.Visible = true;
                    _webcamPlayer.Display.Shape = DisplayShape.Normal;
                    if (_shapeBorder && !_webcamPlayer.FullScreen)
                    {
                        FormBorderStyle = FormBorderStyle.Sizable;
                        Size = _formSize;
                        _shapeBorder = false;
                    }
                }
                else
                {
                    // set window shape
                    if (panel1.Visible) // if not already shaped
                    {
                        _formSize = Size;
                        panel1.Visible = false;
                        if (!_webcamPlayer.FullScreen)
                        {
                            FormBorderStyle = FormBorderStyle.None;
                            _shapeBorder = true;
                        }
                    }
                    _webcamPlayer.Display.Shape = shape;
                }
            }
        }

        #endregion

        #region Display Clones

        // should monitor when clone window is closed as in MainWindow
        private void AddDisplayCloneMenuItem_Click(object sender, EventArgs e)
        {
            string cloneTitle = "#" + (++_cloneCount).ToString("00") + ": " + Text;
            CloneWindow clone = new CloneWindow(null, _webcamPlayer, cloneTitle);
            clone.Text = cloneTitle;
            _cloneWindows.Add(clone);
            _webcamPlayer.DisplayClones.Add(clone);
            clone.Show();
        }

        private void RemoveAllClonesMenuItem_Click(object sender, EventArgs e)
        {
            RemoveAllClonewindows();
        }

        private void CloneWindows_SetVisibility(bool visible)
        {
            int count = _cloneWindows.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    try
                    {
                        if (_cloneWindows[i] != null)
                        {
                            _cloneWindows[i].Visible = visible;
                            if (_cloneWindows[i].ShowInTaskbar)
                            {
                                if (visible) _webcamPlayer.TaskbarProgress.Add(_cloneWindows[i]);
                                else _webcamPlayer.TaskbarProgress.Remove(_cloneWindows[i]);
                            }
                        }
                    }
                    catch { _cloneWindows[i] = null; }
                }
            }
        }

        private void RemoveAllClonewindows()
        {
            int count = _cloneWindows.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    try
                    {
                        if (_cloneWindows[i] != null)
                        {
                            _cloneWindows[i].Close();
                            _cloneWindows[i] = null;
                        }
                    }
                    catch { /* ignore */ }
                }
                _cloneWindows.Clear();
                _webcamPlayer.DisplayClones.RemoveAll();
            }
            _cloneCount = 0;
        }

        #endregion

        #region Opacity

        private void Opacity25MenuItem_Click(object sender, EventArgs e)
        {
            SetOpacity(0, 0.25f);
        }

        private void Opacity50MenuItem_Click(object sender, EventArgs e)
        {
            SetOpacity(1, 0.5f);
        }

        private void Opacity75MenuItem_Click(object sender, EventArgs e)
        {
            SetOpacity(2, 0.75f);
        }

        private void Opacity100MenuItem_Click(object sender, EventArgs e)
        {
            SetOpacity(3, 1f);
        }

        private void SetOpacity(int index, float opacity)
        {
            if (Opacity != opacity)
            {
                MainWindow.UnCheckMenuItems(opacityMenuItem.DropDown, 0, 0);
                ((ToolStripMenuItem)opacityMenuItem.DropDown.Items[index]).Checked = true;
                Opacity = opacity;
                opacityMenuItem.Checked = opacity != 1;
            }
        }

        #endregion

        #region Full Screen

        private void FullScreenMenuItem_Click(object sender, EventArgs e)
        {
            _webcamPlayer.FullScreen = !_webcamPlayer.FullScreen;
            fullScreenMenuItem.Checked = _webcamPlayer.FullScreen;

            // see also "SetDisplayShape" above
            if (!_webcamPlayer.FullScreen)
            {
                if (_shapeBorder)
                {
                    if (panel1.Visible)
                    {
                        FormBorderStyle = FormBorderStyle.Sizable;
                        _shapeBorder = false;
                        Size = _formSize;
                    }
                    else
                    {
                        FormBorderStyle = FormBorderStyle.None;
                        Size = _formSize;
                    }
                }
                else if (!panel1.Visible)
                {
                    _formSize = Size;
                    FormBorderStyle = FormBorderStyle.None;
                    _shapeBorder = true;
                }
            }
        }

        #endregion

        #region Video Color

        private void VideoColorMenuItem_Click(object sender, EventArgs e)
        {
            VideoColorDialog dlg = new VideoColorDialog(null, _webcamPlayer);
            dlg.Text += " - " + _webcam.Name;
            MainWindow.CenterDialog(this, dlg);
            dlg.Show(this);
        }

        #endregion

        #region Webcam Properties

        private void PropertiesMenuItem_Click(object sender, EventArgs e)
        {
            if (_webcamPlayer.Playing)
            {
                WebcamDialog dlg = new WebcamDialog(_webcamPlayer);
                MainWindow.CenterDialog(this, dlg);
                dlg.Show(this);
            }
        }

        #endregion

        #region Screen Copy

        private void CopyToClipboardMenuItem_Click(object sender, EventArgs e)
        {
            if (_scribbleOverlayOn)
            {
                _scribbleOverlay.MenuEnabled = false;
                _webcamPlayer.ScreenCopy.ToClipboard(ScreenCopyMode.Display);
                _scribbleOverlay.MenuEnabled = true;
            }
            else _webcamPlayer.Video.ToClipboard();

            ShowCopyMessage(false);
        }

        private void CopyToFileMenuItem_Click(object sender, EventArgs e)
        {
            string path = _picturesFolder + string.Format("\\Images {0:yyyy-MM-dd}", DateTime.Now);
            Directory.CreateDirectory(path);

            if (_scribbleOverlayOn)
            {
                _scribbleOverlay.MenuEnabled = false;
                _webcamPlayer.ScreenCopy.ToFile(path + string.Format("\\Image {0:yyyy-MM-dd} at {0:HH-mm-ss}.jpg", DateTime.Now), ImageFormat.Jpeg, ScreenCopyMode.Display);
                _scribbleOverlay.MenuEnabled = true;
            }
            else _webcamPlayer.Video.ToFile(path + string.Format("\\Image {0:yyyy-MM-dd} at {0:HH-mm-ss}.jpg", DateTime.Now), ImageFormat.Jpeg);

            ShowCopyMessage(true);
        }

        private void ShowCopyMessage(bool file)
        {
            if (!_zoomOverlayOn && !_scribbleOverlayOn)
            {
                _copyOverlay.SetDestinationText(file);
                if (_copyMessageOn) _copyTimer.Stop();
                else
                {
                    // why does this display overlay occasionally flash the window's title bar?
                    // everything is done to prevent that, both in de library as in the overlay window :(
                    // so because it can often be shown on / off, we keep the overlay on once it is turned on
                    // and change the visibility of the items on it
                    if (!_copyOverlayOn)
                    {
                        _webcamPlayer.Overlay.Window = _copyOverlay;
                        _copyOverlayOn = true;
                    }
                    _copyOverlay.ShowMessagePanel(true);
                    _copyMessageOn = true;
                }
                _copyTimer.Start();
            }
        }

        private void CopyTimer_Tick(object sender, EventArgs e)
        {
            RemoveCopyMessage();
        }

        private void RemoveCopyMessage()
        {
            if (_copyOverlayOn && _copyMessageOn)
            {
                _copyTimer.Stop();
                _copyOverlay.ShowMessagePanel(false);
                _copyMessageOn = false;
            }
        }

        #endregion

        #region Zoom Mode

        private void ZoomModeMenuItem_Click(object sender, EventArgs e)
        {
            zoomModeMenuItem.Checked = !zoomModeMenuItem.Checked;
            if (zoomModeMenuItem.Checked)
            {
                RemoveCopyMessage();
                _webcamPlayer.DisplayClones.ShowOverlay = false;
                if (_zoomOverlay == null) _zoomOverlay = new ZoomSelectOverlay(null, _webcamPlayer);
                _webcamPlayer.Overlay.CanFocus = false;
                _webcamPlayer.Overlay.Window = _zoomOverlay;
                _zoomOverlayOn = true;
                _copyOverlayOn = false;
                _scribbleOverlayOn = false;
                scribbleModeMenuItem.Checked = false;
            }
            else
            {
                _webcamPlayer.Overlay.Remove();
                _zoomOverlayOn = false;
            }
        }

        #endregion

        #region Marker Mode

        private void ScribbleModeMenuItem_Click(object sender, EventArgs e)
        {
            scribbleModeMenuItem.Checked = !scribbleModeMenuItem.Checked;
            if (scribbleModeMenuItem.Checked)
            {
                RemoveCopyMessage();
                if (_scribbleOverlay == null) _scribbleOverlay = new ScribbleOverlay(null, _webcamPlayer);
                _webcamPlayer.Overlay.CanFocus = true;
                _webcamPlayer.Overlay.Window = _scribbleOverlay;
                _webcamPlayer.DisplayClones.ShowOverlay = true;
                _scribbleOverlayOn = true;
                _zoomOverlayOn = false;
                zoomModeMenuItem.Checked = false;
                _copyOverlayOn = false;
            }
            else
            {
                _webcamPlayer.Overlay.Remove();
                _webcamPlayer.Overlay.CanFocus = false;
                _scribbleOverlayOn = false;
                _webcamPlayer.DisplayClones.ShowOverlay = false;
            }
        }

        #endregion

        #region Auto Screen Copy

        private void Auto01SecMenuItem_Click(object sender, EventArgs e)
        {
            StartAutoCopy(sender, 1 * 1000);
        }

        private void Auto02SecMenuItem_Click(object sender, EventArgs e)
        {
            StartAutoCopy(sender, 2 * 1000);
        }

        private void Auto03SecMenuItem_Click(object sender, EventArgs e)
        {
            StartAutoCopy(sender, 3 * 1000);
        }

        private void Auto05SecMenuItem_Click(object sender, EventArgs e)
        {
            StartAutoCopy(sender, 5 * 1000);
        }

        private void Auto10SecMenuItem_Click(object sender, EventArgs e)
        {
            StartAutoCopy(sender, 10 * 1000);
        }

        private void Auto15SecMenuItem_Click(object sender, EventArgs e)
        {
            StartAutoCopy(sender, 15 * 1000);
        }

        private void Auto30SecMenuItem_Click(object sender, EventArgs e)
        {
            StartAutoCopy(sender, 30 * 1000);
        }

        private void Auto01MinMenuItem_Click(object sender, EventArgs e)
        {
            StartAutoCopy(sender, 1 * 60 * 1000);
        }

        private void Auto02MinMenuItem_Click(object sender, EventArgs e)
        {
            StartAutoCopy(sender, 2 * 60 * 1000);
        }

        private void Auto03MinMenuItem_Click(object sender, EventArgs e)
        {
            StartAutoCopy(sender, 1 * 60 * 1000);
        }

        private void Auto05MinMenuItem_Click(object sender, EventArgs e)
        {
            StartAutoCopy(sender, 5 * 60 * 1000);
        }

        private void Auto10MinMenuItem_Click(object sender, EventArgs e)
        {
            StartAutoCopy(sender, 10 * 60 * 1000);
        }

        private void Auto15MinMenuItem_Click(object sender, EventArgs e)
        {
            StartAutoCopy(sender, 15 * 60 * 1000);
        }

        private void Auto30MinMenuItem_Click(object sender, EventArgs e)
        {
            StartAutoCopy(sender, 30 * 60 * 1000);
        }

        private void Auto01HourMenuItem_Click(object sender, EventArgs e)
        {
            StartAutoCopy(sender, 1 * 60 * 60 * 1000);
        }

        private void AutoOffMenuItem_Click(object sender, EventArgs e)
        {
            StopAutoCopy();
        }

        private void StartAutoCopy(object menuItem, int interval)
        {
            bool startTimer = true;

            if (_autoCopyTimer == null)
            {
                _autoCopyTimer = new Timer();
                _autoCopyTimer.Tick += AutoCopyTimer_Tick;
            }
            else
            {
                if (interval == _autoCopyInterval) startTimer = false;
                else _autoCopyTimer.Stop();
            }

            if (startTimer)
            {
                Icon = Properties.Resources.Media_Recording;

                // set menu
                screenCopyMenuItem.Checked = true;
                MainWindow.UnCheckMenuItems(autoToFileMenuItem.DropDown, 0, 0);
                ((ToolStripMenuItem)menuItem).Checked = true;

                AutoCopyTimer_Tick(_autoCopyTimer, EventArgs.Empty);
                ShowCopyMessage(true);

                _autoCopyInterval = interval;
                _autoCopyTimer.Interval = _autoCopyInterval;
                _autoCopyTimer.Start();
            }
        }

        private void StopAutoCopy()
        {
            if (_autoCopyTimer != null)
            {
                Icon = Properties.Resources.Media_Playing;

                screenCopyMenuItem.Checked = false;
                MainWindow.UnCheckMenuItems(autoToFileMenuItem.DropDown, 0, 0);
                autoOffMenuItem.Checked = true;

                _autoCopyTimer.Stop();
                _autoCopyTimer.Dispose();
                _autoCopyTimer = null;
            }
        }

        private void AutoCopyTimer_Tick(object sender, EventArgs e)
        {
            string path = _picturesFolder + string.Format("\\AutoCopy Images {0:yyyy-MM-dd}", DateTime.Now);
            Directory.CreateDirectory(path);
            if (_scribbleOverlayOn)
            {
                _scribbleOverlay.MenuEnabled = false;
                _webcamPlayer.ScreenCopy.ToFile(path + string.Format("\\AutoCopy Image {0:yyyy-MM-dd} at {0:HH-mm-ss}.jpg", DateTime.Now), ImageFormat.Jpeg, ScreenCopyMode.Display);
                _scribbleOverlay.MenuEnabled = true;
            }
            else
            {
                _webcamPlayer.Video.ToFile(path + string.Format("\\AutoCopy Image {0:yyyy-MM-dd} at {0:HH-mm-ss}.jpg", DateTime.Now), ImageFormat.Jpeg);
            }
            if (_webcamPlayer.LastError) StopAutoCopy();
        }

        #endregion

        #region Show In Taskbar / Always On Top / Close

        private void ShowInTaskbarMenuItem_Click(object sender, EventArgs e)
        {
            ShowInTaskbar = !ShowInTaskbar;
            showInTaskbarMenuItem.Checked = ShowInTaskbar;

            if (_webcamPlayer.Playing)
            {
                if (ShowInTaskbar) _webcamPlayer.TaskbarProgress.Add(this);
                else _webcamPlayer.TaskbarProgress.Remove(this);
                // video picture gets lost?
                _webcamPlayer.Webcam.Update();
            }

        }

        private void AlwaysOnTopMenuItem_Click(object sender, EventArgs e)
        {
            TopMost = !TopMost;
            alwaysOnTopMenuItem.Checked = TopMost;
        }

        private void CloseMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #endregion

    }
}
