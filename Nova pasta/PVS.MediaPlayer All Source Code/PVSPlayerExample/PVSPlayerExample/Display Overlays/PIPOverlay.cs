#region Usings

using PVS.MediaPlayer;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

#endregion

namespace PVSPlayerExample
{
    public sealed partial class PIPOverlay : Form, IOverlay
    {
        /*
        
        PVS.MediaPlayer Display Overlay - Example 'PIP'
        Displays a Picture-In-Picture (movie) player.

        From version 0.95 you could also display the PIP directly on the display,
        without using a display overlay.
        
        */

        // ******************************** Fields

        #region Fields

        private const int   NO_ERROR = 0;

        private MainWindow  _baseForm;
        private Player      _basePlayer;
        private OverlayMode _baseOverlayMode;

        private Player      _pipPlayer1;
        private bool        _autoPaused;

        private bool        _pipPanelVisible;
        private bool        _pipControlsEnabled = true;
        private bool        _movingEnabled      = true;
        private bool        _resizingEnabled    = true;

        private bool        _backgroundHidden;
        private bool        _backgroundShownTemp;

        private bool        _playMenuRightButton;
        private Point       _playMenuPopUpLocation;
        private int         _playMenuItemIndex;
            
        private int         _mediaToPlay;
        private int         _errorCount;

        // Used with PIP Moving and Sizing
        private bool        _pipSizing;
        private int         _pipSizingType;
        private Point       _oldMouseSizePos;
        private Point       _newMouseSizePos;

        private InfoLabel   _positionLabel;

        private bool        _disposed;

        #endregion

        // ******************************** Main

        #region Main

        public PIPOverlay(MainWindow baseForm, Player basePlayer)
        {
            InitializeComponent();

            _baseForm                               = baseForm;
            _basePlayer                             = basePlayer;

            _pipPlayer1                             = new Player(displayPanel);
            _pipPlayer1.Display.Mode                = DisplayMode.Zoom;
            _pipPlayer1.Repeat                      = true;
            _pipPlayer1.Audio.Mute                  = true;
            _pipPlayer1.Sliders.Position.TrackBar   = positionSlider;

            _pipPlayer1.Events.MediaStarted         += Events_MediaStarted;
            _pipPlayer1.Events.MediaEndedNotice     += Events_MediaEndedNotice;

            _positionLabel                          = new InfoLabel();
            _positionLabel.RoundedCorners           = true;
            _positionLabel.ForeColor                = Color.FromArgb(179, 173, 146);
            _positionLabel.Text                     = "Ty";   // 'pre-size' height for brush size
            _positionLabel.BackBrush                = new LinearGradientBrush( new Rectangle(new Point(0, 0), _positionLabel.Size), Color.FromArgb(80, 80, 80), Color.Black, LinearGradientMode.Vertical);
            _positionLabel.AlignOffset              = new Point(0, -3);
            _positionLabel.Duration                 = 500;

            positionSlider.Scroll                   += PositionSlider_Scroll;

            // Pass on drag and drop to main form (handled in source file: DragDrop.cs):
            AllowDrop                               = true;
            DragDrop                                += _baseForm.Form1_DragDrop;

            // Construct displayContextmenu - add playMenu as dropdown
            ((ToolStripMenuItem)displayMenu.Items[0]).DropDown = playMenu;
            ReBuildPIPPlayListMenu();
        }

        private void Events_MediaStarted(object sender, EventArgs e)
        {
            HideBackground();
        }

        private void Events_MediaEndedNotice(object sender, EndedEventArgs e)
        {
            if (e.StopReason != StopReason.AutoStop)
            {
                _backgroundShownTemp = false;
                ShowBackground();
            }
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

        private void PIPOverlay_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                _baseOverlayMode = _basePlayer.Overlay.Mode;
                if (_baseForm == null) _basePlayer.Overlay.Mode = OverlayMode.Display;
                else _baseForm.SetOverlayDisplayMode();

                if (_autoPaused)
                {
                    _pipPlayer1.Resume();
                    _autoPaused = false;
                }
                _pipPlayer1.Sliders.Position.LiveUpdate = _baseForm.Player1.Sliders.Position.LiveUpdate;
                MouseDown += _baseForm.Player1.Display.Drag_MouseDown;
            }
            else
            {
                if (_baseOverlayMode == OverlayMode.Video)
                {
                    if (_baseForm == null) _basePlayer.Overlay.Mode = OverlayMode.Video;
                    else _baseForm.SetOverlayVideoMode();
                }

                if (!_pipPlayer1.Paused)
                {
                    _pipPlayer1.Pause();
                    _autoPaused = true;
                }
                MouseDown -= _baseForm.Player1.Display.Drag_MouseDown;
            }
        }

        // Keep the PiP inside the overlay
        private void PIPOverlay_Resize(object sender, EventArgs e)
        {
            if (pipPanel.Left < 0) pipPanel.Left = 0;
            else
            {
                if (pipPanel.Left > Width) pipPanel.Left = Width - pipPanel.Width;
                if (pipPanel.Left < 0) pipPanel.Left = 0;
            }
            if (pipPanel.Top < 0) pipPanel.Top = 0;
            else
            {
                if (pipPanel.Top > Height) pipPanel.Top = Height - pipPanel.Height;
                if (pipPanel.Top < 0) pipPanel.Top = 0;
            }

            if (pipPanel.Left + pipPanel.Width > Width)
            {
                pipPanel.Width = Width - pipPanel.Left;
                if (pipPanel.Left + pipPanel.Width > Width)
                {
                    pipPanel.Left = Width - pipPanel.Width;
                    if (pipPanel.Left < 0) pipPanel.Left = 0;
                }
            }
            if (pipPanel.Top + pipPanel.Height > Height)
            {
                pipPanel.Height = Height - pipPanel.Top;
                if (pipPanel.Left + pipPanel.Height > Height)
                {
                    pipPanel.Top = Height - pipPanel.Height;
                    if (pipPanel.Top < 0) pipPanel.Top = 0;
                }
            }
        }

        // Show infolabel
        private void PositionSlider_Scroll(object sender, EventArgs e)
        {
            // Get the position slider's x-coordinate of the current position (= thumb location)
            Point location = SliderValue.ToPoint(positionSlider, positionSlider.Value);

            // Show the infolabel
            TimeSpan time = _pipPlayer1.Position.FromStart;
            _positionLabel.Show(
                string.Format("{0:00;00}:{1:00;00}:{2:00;00}", time.Hours, time.Minutes, time.Seconds),
                positionSlider, location);
        }

        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    DragDrop -= _baseForm.Form1_DragDrop;

                    _positionLabel.Dispose();
                    _pipPlayer1.Dispose(); _pipPlayer1 = null;
                    _baseForm = null;

                    if (components != null) components.Dispose();
                }
                _disposed = true;
            }
            base.Dispose(disposing);
        }

        #endregion

        // ******************************** IOverlay Control

        #region IOverlay Control

        // The visibility of the menu is controlled by the user from the main application (in this example application)
        public bool HasMenu
        {
            get { return false; }
        }

        public bool MenuEnabled
        {
            get { return false; }
            set { }
        }

        public void MediaStopped()
        {
            // not used with this overlay
        }

        #endregion

        // ******************************** Player PlayMedia / PlayNextMedia

        #region Player PlayMedia / PlayNextMedia

        // Play a mediafile
        private void PlayMedia(string fileName)
        {
            if (_pipPlayer1.Play(fileName) != NO_ERROR)
            {
                if (MainWindow.Prefs.ShowErrorMessages)
                {
                    ErrorDialog errorDialog = new ErrorDialog(MainWindow.APPLICATION_NAME, "PIP Overlay Media:\r\n" + fileName + "\r\n\r\n" + _pipPlayer1.LastErrorString, false, true);
                    MainWindow.CenterDialog(this, errorDialog);

                    errorDialog.checkBox1.Hide();
                    errorDialog.checkBox2.Hide();

                    errorDialog.ShowDialog(this);
                    errorDialog.Dispose();
                }

                if (++_errorCount > 1) _errorCount = 0;
                else if (MainWindow.Prefs.AutoPlayNext && _baseForm.Playlist.Count > 1)
                {
                    // Continue playing next mediafile
                    PlayNextMedia();
                }
            }
            else _errorCount = 0;
        }

        // Play a mediafile and update the 'next' counter
        private void PlayNextMedia()
        {
            if (_baseForm.Playlist.Count > 0)
            {
                if (_mediaToPlay >= _baseForm.Playlist.Count) _mediaToPlay = 0;
                PlayMedia(_baseForm.Playlist[_mediaToPlay++]);
            }
        }

        #endregion

        // ******************************** PIP Controls Visibility

        #region PIP Controls Visibility

        private void DisplayPanel_MouseEnter(object sender, EventArgs e)
        {
            if (_pipSizing || !_pipControlsEnabled) return;
            ShowPIPPanel();
        }

        private void PipPanel_MouseLeave(object sender, EventArgs e)
        {
            if (_pipSizing) return;
            if (!pipPanel.ClientRectangle.Contains(pipPanel.PointToClient(Cursor.Position))) HidePIPPanel();
        }

        private void ShowPIPPanel()
        {
            if (!_pipPanelVisible && _pipControlsEnabled)
            {
                playButton.Show();
                pauseButton.Show();
                stopButton.Show();
                positionSlider.Show();
                _pipPanelVisible = true;

                if (_backgroundHidden)
                {
                    _backgroundShownTemp = true;
                    ShowBackground();
                }
            }
        }

        private void HidePIPPanel()
        {
            if (_pipPanelVisible)
            {
                playButton.Hide();
                pauseButton.Hide();
                stopButton.Hide();
                positionSlider.Hide();
                _pipPanelVisible = false;

                if (_backgroundShownTemp)
                {
                    HideBackground();
                    _backgroundShownTemp = false;
                }
            }
        }

        private void HideBackground()
        {
            if (!_backgroundHidden)
            {
                displayPanel.BorderStyle = BorderStyle.None;
                displayPanel.BackColor = BackColor;
                _backgroundHidden = true;
            }
        }

        private void ShowBackground()
        {
            if (_backgroundHidden)
            {
                displayPanel.BorderStyle = BorderStyle.FixedSingle;
                displayPanel.BackColor = Color.FromArgb(18, 18, 18);
                _backgroundHidden = false;
            }
        }

        #endregion

        // ******************************** PIP Moving and Sizing

        #region PIP Moving and Sizing

        private void SizePanelSizing_MouseDown(object sender, MouseEventArgs e)
        {
            _oldMouseSizePos = ((Panel)sender).PointToScreen(e.Location);
            HidePIPPanel();
            if (sender == sizePanelWE) _pipSizingType = 0;
            else if (sender == sizePanelNS) _pipSizingType = 1;
            else if (sender == sizePanelNWSE) _pipSizingType = 2;
            else
            {
                if (_movingEnabled)
                {
                    Cursor = Cursors.SizeAll;
                    _pipSizingType = 3; // Move
                }
                else _pipSizingType = -1; // Move disabled
            }
            _pipSizing = true;
        }

        private void SizePanelSizing_MouseMove(object sender, MouseEventArgs e)
        {
            Point newPosition = pipPanel.Location;
            Size newSize = pipPanel.Size;

            if (!_pipSizing) return;
            _newMouseSizePos = ((Panel)sender).PointToScreen(e.Location);

            switch (_pipSizingType)
            {
                case 3: // move
                    if (_newMouseSizePos.Y != _oldMouseSizePos.Y)
                    {
                        newPosition.Y = pipPanel.Top + (_newMouseSizePos.Y - _oldMouseSizePos.Y);
                        if (pipPanel.Top < 0) newPosition.Y = 0;
                        else
                        {
                            if (_pipControlsEnabled)
                            {
                                if (newPosition.Y + pipPanel.Height > Height) newPosition.Y = Height - pipPanel.Height;
                            }
                            else
                            {
                                // 45 is about the height of the control buttons + slider
                                if (newPosition.Y + (pipPanel.Height - 45)  > Height) newPosition.Y = Height - (pipPanel.Height - 45);
                            }
                        }
                    }
                    if (_newMouseSizePos.X != _oldMouseSizePos.X)
                    {
                        newPosition.X = pipPanel.Left + (_newMouseSizePos.X - _oldMouseSizePos.X);
                        if (pipPanel.Left < 0) newPosition.X = 0;
                        else if (newPosition.X + pipPanel.Width > Width) newPosition.X = Width - pipPanel.Width;
                    }
                    pipPanel.Location = newPosition;
                    break;

                case 0: // size width
                    if (_newMouseSizePos.X != _oldMouseSizePos.X)
                    {
                        newSize.Width = pipPanel.Width + (_newMouseSizePos.X - _oldMouseSizePos.X);
                        if (newPosition.X + newSize.Width > Width) newSize.Width = Width - newPosition.X;
                        pipPanel.Width = newSize.Width;
                    }
                    break;

                case 1: // size height
                    if (_newMouseSizePos.Y != _oldMouseSizePos.Y)
                    {
                        newSize.Height = pipPanel.Height + (_newMouseSizePos.Y - _oldMouseSizePos.Y);
                        if (newPosition.Y + newSize.Height > Height) newSize.Height = Height - newPosition.Y;
                        pipPanel.Height = newSize.Height;
                    }
                    break;

                //default:
                case 2: // size width + height
                    if (_newMouseSizePos.Y != _oldMouseSizePos.Y)
                    {
                        newSize.Height = pipPanel.Height + (_newMouseSizePos.Y - _oldMouseSizePos.Y);
                        if (_pipControlsEnabled)
                        {
                            if (newPosition.Y + newSize.Height > Height) newSize.Height = Height - newPosition.Y;
                        }
                        else if (newPosition.Y + (newSize.Height - 45) > Height) newSize.Height = Height - (newPosition.Y - 45);
                        pipPanel.Height = newSize.Height;
                    }
                    if (_pipSizingType == 2 && _newMouseSizePos.X != _oldMouseSizePos.X)
                    {
                        newSize.Width = pipPanel.Width + (_newMouseSizePos.X - _oldMouseSizePos.X);
                        if (newPosition.X + newSize.Width > Width) newSize.Width = Width - newPosition.X;
                        pipPanel.Width = newSize.Width;
                    }
                    break;

                default: break; // move disabled
            }
            _oldMouseSizePos = _newMouseSizePos;
        }

        private void SizePanelSizing_MouseUp(object sender, MouseEventArgs e)
        {
            _pipSizing = false;
            if (_pipSizingType == 3) Cursor = Cursors.Default;
        }

        #endregion

        // ******************************** Play, Pause/Resume and Stop Button

        #region Play Button

        private void PlayMenu_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                _playMenuRightButton = true;
                _playMenuPopUpLocation.X = e.Location.X - 1;
                _playMenuPopUpLocation.Y = e.Location.Y - 1;
            }
        }

        private void PlayMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            _playMenuItemIndex = playMenu.Items.IndexOf(e.ClickedItem);

            if (_playMenuItemIndex == 0) // This is menu item 'Add MediaFiles'
            {
                playMenu.Close();
                if (displayMenu.Visible) displayMenu.Close();
                HidePIPPanel();
                SelectMediaFiles();
            }
            else
            {
                if (_playMenuRightButton)
                {
                    _playMenuRightButton = false;
                    playMenu.AutoClose = false;
                    if (displayMenu.Visible) displayMenu.AutoClose = false;
                    playMenu.Items[_playMenuItemIndex].BackColor = SystemColors.GradientInactiveCaption;
                    playSubMenu.Show(playMenu.PointToScreen(_playMenuPopUpLocation));
                }
                else
                {
                    playMenu.Close();
                    if (displayMenu.Visible) displayMenu.Close();
                    HidePIPPanel();
                    _mediaToPlay = _playMenuItemIndex - 2;
                    PlayNextMedia();
                }
            }
        }

        private void PlaySubMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            playSubMenu.Close();
            playMenu.AutoClose = true;
            displayMenu.AutoClose = true;
            switch (playSubMenu.Items.IndexOf(e.ClickedItem))
            {
                case 0: // Play the mediafile
                    playMenu.Close();
                    if (displayMenu.Visible) displayMenu.Close();
                    HidePIPPanel();
                    _mediaToPlay = _playMenuItemIndex - 2;
                    PlayNextMedia();
                    break;

                case 1: // Remove from List
                    _baseForm.Playlist.RemoveAt(_playMenuItemIndex - 2);
                    _playMenuItemIndex--;
                    //baseForm.ReBuildPlayListMenu();
                    SavePlayList();
                    // Rebuild my menu
                    ReBuildPIPPlayListMenu();
                    break;

                case 3: // Sort List
                    _baseForm.Playlist.Sort();
                    //baseForm.ReBuildPlayListMenu();
                    SavePlayList();
                    // Rebuild my menu
                    ReBuildPIPPlayListMenu();
                    break;
            }
        }

        #endregion

        #region PlayMenu Drag and Drop

        private bool        _ddMouseDown;
        private bool        _ddOurDrag;
        private int         _ddSourceIndex;
        private Point       _ddMouseLocation;
        ToolStripMenuItem   _ddDragMenuItem;

        private void PlayMenu_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _ddMouseLocation = e.Location;
                _ddDragMenuItem = (ToolStripMenuItem)sender;
                _ddDragMenuItem.MouseMove += PlayMenu_MouseMove;
                _ddDragMenuItem.MouseUp += PlayMenu_MouseUp;
                _ddSourceIndex = playMenu.Items.IndexOf((ToolStripMenuItem)sender);
                _ddMouseDown = true;
            }
        }

        private void PlayMenu_MouseMove(object sender, MouseEventArgs e)
        {
            if (_ddMouseDown && (Math.Abs(_ddMouseLocation.X - e.Location.X) > 3 || Math.Abs(_ddMouseLocation.Y - e.Location.Y) > 3))
            {
                _ddMouseDown = false; // we don't get a mouse up event after dodragdrop

                _ddDragMenuItem.MouseMove -= PlayMenu_MouseMove;
                _ddDragMenuItem.MouseUp -= PlayMenu_MouseUp;

                _ddOurDrag = true;
                playMenu.DoDragDrop(_baseForm.Playlist[_ddSourceIndex - 2], DragDropEffects.Move);
                _ddOurDrag = false;
            }
        }

        private void PlayMenu_MouseUp(object sender, MouseEventArgs e)
        {
            _ddDragMenuItem.MouseMove -= PlayMenu_MouseMove;
            _ddDragMenuItem.MouseUp -= PlayMenu_MouseUp;
            _ddMouseDown = false;
        }

        // DragEnter not needed - responding only to 'our drag'
        private void PlayMenu_DragOver(object sender, DragEventArgs e)
        {
            if (_ddOurDrag)
            {
                Point location = playMenu.PointToClient(new Point(e.X, e.Y));
                e.Effect = playMenu.Items.IndexOf(playMenu.GetItemAt(location)) > 1 ? DragDropEffects.Move : DragDropEffects.None;
            }
            else e.Effect = DragDropEffects.None;
        }

        private void PlayMenu_DragDrop(object sender, DragEventArgs e)
        {
            if (_ddOurDrag)
            {
                Point location = playMenu.PointToClient(new Point(e.X, e.Y));
                int ddDestIndex = playMenu.Items.IndexOf(playMenu.GetItemAt(location));
                if (ddDestIndex != _ddSourceIndex && ddDestIndex > 1)
                {
                    ToolStripMenuItem menuItem = (ToolStripMenuItem)playMenu.Items[_ddSourceIndex];
                    playMenu.Items.RemoveAt(_ddSourceIndex);
                    playMenu.Items.Insert(ddDestIndex, menuItem);

                    string listItem = _baseForm.Playlist[_ddSourceIndex - 2];
                    _baseForm.Playlist.RemoveAt(_ddSourceIndex - 2);
                    _baseForm.Playlist.Insert(ddDestIndex - 2, listItem);

                    SavePlayList();
                }
            }
        }

        #endregion

        #region Pause Button

        private void PauseButton_Click(object sender, EventArgs e)
        {
            _pipPlayer1.Paused = !_pipPlayer1.Paused;
            if (_pipPlayer1.Paused) displayMenu.Items[1].Text = pauseButton.Text = "Resume";
            else displayMenu.Items[1].Text = pauseButton.Text = "Pause";
        }

        #endregion

        #region Stop Button

        private void StopButton_Click(object sender, EventArgs e)
        {
            _pipPlayer1.Stop();
        }

        #endregion

        // ******************************** Select Mediafiles

        #region Select Mediafiles

        // Use an OpenFileDialog to select mediafiles and add them to the PlayList - using the baseForm Form1
        private void SelectMediaFiles()
        {
            _baseForm.OpenFileDialog1.Title = MainWindow.OPENMEDIA_DIALOG_TITLE;
            _baseForm.OpenFileDialog1.Filter = string.Empty;
            _baseForm.OpenFileDialog1.InitialDirectory = MainWindow.Prefs.MediaFilesFolder;
            _baseForm.OpenFileDialog1.Multiselect = true;

            if (_baseForm.OpenFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                //_baseForm.MediaDirectory = Path.GetDirectoryName(_baseForm.OpenFileDialog1.FileName);

                int newToPlay = _baseForm.Playlist.Count;
                _baseForm.AddToPlayList(_baseForm.OpenFileDialog1.FileNames);
                ReBuildPIPPlayListMenu();
                if (!_pipPlayer1.Playing)
                {
                    _mediaToPlay = newToPlay;
                    PlayNextMedia();
                }
            }
        }

        #endregion

        // ******************************** Rebuild playMenu

        #region Rebuild playMenu and SavePlayList

        internal void ReBuildPIPPlayListMenu()
        {
            playMenu.SuspendLayout();
            while (playMenu.Items.Count > 2) playMenu.Items.RemoveAt(2);
            for (int i = 0; i < _baseForm.Playlist.Count; i++)
            {
                // should omit non-video files...
                if (MainWindow.Prefs.PlayListShowExtensions) playMenu.Items.Add(Path.GetFileName(_baseForm.Playlist[i].Replace("&", "&&")));
                else playMenu.Items.Add(Path.GetFileNameWithoutExtension(_baseForm.Playlist[i].Replace("&", "&&")));
                if (_baseForm.Playlist[i].StartsWith("http", StringComparison.OrdinalIgnoreCase)) playMenu.Items[i + 2].ForeColor = Color.LightSteelBlue;
                playMenu.Items[i + 2].MouseDown += PlayMenu_MouseDown;
            }
            playMenu.ResumeLayout();
        }

        // Save the PlayList to disk (used when the PlayList has changed)
        private void SavePlayList()
        {
            try
            {
                if (_baseForm.Playlist.Count > 0) File.WriteAllLines(_baseForm.PlaylistFile, _baseForm.Playlist.ToArray());
                else if (File.Exists(_baseForm.PlaylistFile)) File.Delete(_baseForm.PlaylistFile);
                _baseForm.ReBuildPlayListMenu(); // update main form playmenu
            }
            catch { }
        }

        #endregion

        // ******************************** Display ContextMenu

        #region Display ContextMenu

        private void PauseMenuItem_Click(object sender, EventArgs e)
        {
            PauseButton_Click(this, EventArgs.Empty);
            HidePIPPanel();
        }

        private void StopMenuItem_Click(object sender, EventArgs e)
        {
            _pipPlayer1.Stop();
            HidePIPPanel();
        }

        private void EnableControlsMenuItem_Click(object sender, EventArgs e)
        {
            _pipControlsEnabled = !_pipControlsEnabled;
            enableControlsMenuItem.Checked = _pipControlsEnabled;
            if (!_pipControlsEnabled) HidePIPPanel();
            else ShowPIPPanel();
        }

        private void EnableMovingMenuItem_Click(object sender, EventArgs e)
        {
            _movingEnabled = !_movingEnabled;
            //sizePanelMove.Enabled = _movingEnabled;
            enableMovingMenuItem.Checked = _movingEnabled;
            HidePIPPanel();
        }

        private void EnableResizingMenuItem_Click(object sender, EventArgs e)
        {
            _resizingEnabled = !_resizingEnabled;
            sizePanelNS.Enabled = _resizingEnabled;
            sizePanelWE.Enabled = _resizingEnabled;
            sizePanelNWSE.Enabled = _resizingEnabled;
            enableResizingMenuItem.Checked = _resizingEnabled;
            HidePIPPanel();
        }

        // Opacity
        private void HandleToolStripOpacity(object sender, EventArgs e)
        {
            double value;

            // get the text of the menu item (e.g. 50%), remove the '%' and convert to double value
            if (double.TryParse(((ToolStripMenuItem)sender).Text.TrimEnd('%'), out value))
            {
                if (value >= 25 && value <= 100)
                {
                    Opacity = value / 100;

                    // Removes the check marks from the Opacity contextmenu items and checks the selected item
                    foreach (ToolStripItem item in (((ToolStripMenuItem)sender).GetCurrentParent().Items))
                    {
                        if (item.GetType() == typeof(ToolStripMenuItem))
                        {
                            ((ToolStripMenuItem)item).Checked = item == sender;
                        }
                    }
                }
            }
            opacityMenuItem.Checked = (Opacity != 1);
            HidePIPPanel();
        }

        // Switch base player and pipplayer screens
        private void SwitchScreensMenuItem_Click(object sender, EventArgs e)
        {
            // Because one of the displays is on an overlay of the other display, don't just switch the player's displays.

            // base player
            string movie1       = _baseForm.Player1.Media.GetName(MediaName.FullPath);
            WebcamDevice webcam1 = _baseForm.Player1.Webcam.Device;
            WebcamFormat format1 = _baseForm.Player1.Webcam.Format;
            TimeSpan position1  = _baseForm.Player1.Position.FromStart;
            TimeSpan startTime1 = _baseForm.Player1.Media.StartTime;
            TimeSpan stopTime1  = _baseForm.Player1.Media.StopTime;
            bool playing1       = _baseForm.Player1.Playing;
            bool paused1        = _baseForm.Player1.Paused;

            // pip player
            string movie2       = _pipPlayer1.Media.GetName(MediaName.FullPath);
            WebcamDevice webcam2 = _pipPlayer1.Webcam.Device;
            WebcamFormat format2 = _pipPlayer1.Webcam.Format;
            TimeSpan position2  = _pipPlayer1.Position.FromStart;
            TimeSpan startTime2 = _pipPlayer1.Media.StartTime;
            TimeSpan stopTime2  = _pipPlayer1.Media.StopTime;
            bool playing2       = _pipPlayer1.Playing;
            bool paused2        = _pipPlayer1.Paused;

            // Reducing screen flashing (by not closing and reopening the overlay):
            bool holdCopy = _baseForm.Player1.Overlay.Hold;
            _baseForm.Player1.Overlay.Hold = true;
            _baseForm.StopAndPlay = true;

            if (playing2)
            {
                _baseForm.Player1.Paused = paused2;
                if (webcam2 != null)
                {
                    _baseForm.Player1.Play(webcam2, format2);
                }
                else
                {
                    _baseForm.Player1.Play(movie2, position2, stopTime2);
                    _baseForm.Player1.Media.StartTime = startTime2;
                }
            }

            if (playing1)
            {
                _pipPlayer1.Paused = paused1; // may be overridden by autoPaused (PIPOverlay_VisibleChanged), so:
                if (paused1) _autoPaused = false;
                if (webcam1 != null)
                {
                    _pipPlayer1.Play(webcam1, format1);
                }
                else
                {
                    _pipPlayer1.Play(movie1, position1, stopTime1);
                    _pipPlayer1.Media.StartTime = startTime1;
                }
            }
            else _pipPlayer1.Stop();

            _baseForm.Player1.Overlay.Hold = holdCopy;
        }

        #endregion
    }
}
