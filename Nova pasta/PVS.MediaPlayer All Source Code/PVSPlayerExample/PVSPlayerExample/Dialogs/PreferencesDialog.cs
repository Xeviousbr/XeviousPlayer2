#region Usings

using PVS.MediaPlayer;
using System;
using System.Drawing;
using System.Windows.Forms;

#endregion

namespace PVSPlayerExample
{
    // Preferences dialog - application settings.

    public partial class PreferencesDialog : Form
    {
        #region Fields

        private double      _oldOpacity;
        private MainWindow  _baseForm;
        private Player      _basePlayer;
        private bool        _hasMiniPlayers;
        private bool        _oldShowExtensions;
        private bool        _oldClock24Hrs;
        Control[]           _miniDisplays;

        #endregion


        #region Main / Shown / OnPaint / Closing

        public PreferencesDialog(MainWindow baseForm, Player thePlayer)
        {
            InitializeComponent();
            _baseForm = baseForm;
            _basePlayer = thePlayer;
            ((TextBox)secondsBox.Controls[1]).MaxLength = 5;

            Icon = Properties.Resources.Media_Normal;

            GetPreferences();

            _oldShowExtensions = MainWindow.Prefs.PlayListShowExtensions;
            _oldClock24Hrs = MainWindow.Prefs.Clock24Hr;

            _oldOpacity = Opacity;
            Opacity = 0;
        }

        private void PreferencesDialog_Shown(object sender, EventArgs e)
        {
            if (MainWindow.Prefs.ShowMiniPlayers)
            {
                _miniDisplays = new Control[] { panel2, panel3, panel4 };
                _baseForm.Player1.DisplayClones.AddRange(_miniDisplays);
            }
            Application.DoEvents();
            System.Threading.Thread.Sleep(50);
            Opacity = _oldOpacity;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rect = DisplayRectangle;
            rect.Width -= 1;
            rect.Height -= 1;
            Pen pen = new Pen(Color.FromArgb(109, 103, 76), 1);
            e.Graphics.DrawRectangle(pen, rect);
            pen.Dispose();
        }

        private void PvsPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(Properties.Resources.PVSLogoOutline, 4, 0);
        }

        private void PreferencesDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_miniDisplays != null)
            {
                _baseForm.Player1.DisplayClones.RemoveRange(_miniDisplays);
                _miniDisplays = null;
            }

            if (DialogResult == DialogResult.OK)
            {
                SetPreferences();
            }
            else
            {
                // reset clock display
                _baseForm.SetClockDisplay(MainWindow.Prefs.ClockShow);
                _baseForm.SetClockColor(MainWindow.Prefs.ClockColor);
                MainWindow.Prefs.Clock24Hr = _oldClock24Hrs;
                if (MainWindow.Prefs.ClockShow) _baseForm.SetClockTime();
            }
        }

        #endregion

        #region Get / Set Preferences

        private void GetPreferences()
        {
            saveWindowBox.Checked = MainWindow.Prefs.SaveWindow;
            saveDisplayModeBox.Checked = MainWindow.Prefs.SaveDisplayMode;
            saveOverlayBox.Checked = MainWindow.Prefs.SaveOverlay;
            saveRepeatBox.Checked = MainWindow.Prefs.SaveRepeat;
            saveSpeedBox.Checked = MainWindow.Prefs.SaveSpeed;
            saveSliderBox.Checked = MainWindow.Prefs.SaveSlider;
            autoOverlayBox.Checked = MainWindow.Prefs.AutoOverlay;
            saveAudioBox.Checked = MainWindow.Prefs.SaveAudio;

            autoPlayStartBox.Checked = MainWindow.Prefs.AutoPlayStart;
            autoPlayAddedBox.Checked = MainWindow.Prefs.AutoPlayAdded;
            autoPlayNextBox.Checked = MainWindow.Prefs.AutoPlayNext;
            onErrorRemoveBox.Checked = MainWindow.Prefs.OnErrorRemove;
            autoHideCursorBox.Checked = MainWindow.Prefs.AutoHideCursor;
            showExtensionsBox.Checked = MainWindow.Prefs.PlayListShowExtensions;
            noMessageBox.Checked = !MainWindow.Prefs.ShowErrorMessages;
            showToolTipsBox.Checked = MainWindow.Prefs.ShowTooltips;
            if (MainWindow.Prefs.ShowMiniPlayers) _hasMiniPlayers = true;
            enablePlayersBox.Checked = MainWindow.Prefs.ShowMiniPlayers; // this triggers enablePlayersBox_CheckedChanged eventhandler (!)

            showClockBox.Checked = MainWindow.Prefs.ClockShow;
            clock24hLabel.Text = MainWindow.Prefs.Clock24Hr ? "24 hr" : "12 hr";
            clockColorPanel.BackColor = MainWindow.Prefs.ClockColor;

            saveMediaFolderBox.Checked = MainWindow.Prefs.SaveMediaFilesFolder;
            mediaFilesLabel.Text = MainWindow.Prefs.MediaFilesFolder;
            savePlaylistBox.Checked = MainWindow.Prefs.SavePlaylistsFolder;
            playlistsLabel.Text = MainWindow.Prefs.PlaylistsFolder;

            continuePlayBox.Checked = MainWindow.Prefs.ContinuePlay;
            secondsBox.Value = MainWindow.Prefs.RewindSecs;
        }

        private void SetPreferences()
        {
            MainWindow.Prefs.SaveWindow = saveWindowBox.Checked;
            MainWindow.Prefs.SaveDisplayMode = saveDisplayModeBox.Checked;
            MainWindow.Prefs.SaveOverlay = saveOverlayBox.Checked;
            MainWindow.Prefs.SaveSlider = saveSliderBox.Checked;
            MainWindow.Prefs.SaveRepeat = saveRepeatBox.Checked;
            MainWindow.Prefs.SaveSpeed = saveSpeedBox.Checked;
            MainWindow.Prefs.AutoOverlay = autoOverlayBox.Checked;
            MainWindow.Prefs.SaveAudio = saveAudioBox.Checked;

            MainWindow.Prefs.AutoPlayStart = autoPlayStartBox.Checked;
            MainWindow.Prefs.AutoPlayAdded = autoPlayAddedBox.Checked;
            MainWindow.Prefs.AutoPlayNext = autoPlayNextBox.Checked;
            MainWindow.Prefs.AutoHideCursor = autoHideCursorBox.Checked;
            MainWindow.Prefs.OnErrorRemove = onErrorRemoveBox.Checked;
            MainWindow.Prefs.PlayListShowExtensions = showExtensionsBox.Checked;
            MainWindow.Prefs.ShowErrorMessages = !noMessageBox.Checked;
            MainWindow.Prefs.ShowTooltips = showToolTipsBox.Checked;
            MainWindow.Prefs.ShowMiniPlayers = enablePlayersBox.Checked;

            MainWindow.Prefs.ClockShow = showClockBox.Checked;
            MainWindow.Prefs.ClockColor = clockColorPanel.BackColor;

            MainWindow.Prefs.SaveMediaFilesFolder = saveMediaFolderBox.Checked;
            if (MainWindow.Prefs.SaveMediaFilesFolder) MainWindow.MediaDirectory = MainWindow.Prefs.MediaFilesFolder = mediaFilesLabel.Text;
            else MainWindow.Prefs.MediaFilesFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            MainWindow.Prefs.SavePlaylistsFolder = savePlaylistBox.Checked;
            if (MainWindow.Prefs.SavePlaylistsFolder) MainWindow.PlayListDirectory = MainWindow.Prefs.PlaylistsFolder = playlistsLabel.Text;
            else MainWindow.Prefs.PlaylistsFolder = MainWindow.Prefs.MediaFilesFolder;

            MainWindow.Prefs.ContinuePlay = continuePlayBox.Checked;
            MainWindow.Prefs.RewindSecs = (int)secondsBox.Value;

            if (MainWindow.Prefs.PlayListShowExtensions != _oldShowExtensions) _baseForm.ReBuildPlayListMenu();

            if (MainWindow.Prefs.AutoHideCursor) _basePlayer.CursorHide.Add(_baseForm);
            else _basePlayer.CursorHide.RemoveAll();
        }

        private void SetMiniPlayers()
        {
            panel2.Visible = panel3.Visible = panel4.Visible = enablePlayersBox.Checked;
            if (enablePlayersBox.Checked && !_hasMiniPlayers)
            {
                if (_miniDisplays == null) _miniDisplays = new Control[] { panel2, panel3, panel4 };
                _baseForm.Player1.DisplayClones.AddRange(_miniDisplays);
                _hasMiniPlayers = true;
            }
        }

        #endregion

        #region Buttons / Labels Handlers

        private void OKButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MediaFilesLabel_Click(object sender, EventArgs e)
        {
            OKButton.Focus();
            FolderBrowserDialog dlg = new FolderBrowserDialog()
            {
                Description = Text + "\r\n\r\nPlease select the initial folder to browse for media files:",
                ShowNewFolderButton = true,
                SelectedPath = mediaFilesLabel.Text
            };
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                mediaFilesLabel.Text = dlg.SelectedPath;
                saveMediaFolderBox.Checked = true;
            }
            dlg.Dispose();
        }

        private void PlaylistsLabel_Click(object sender, EventArgs e)
        {
            OKButton.Focus();
            FolderBrowserDialog dlg = new FolderBrowserDialog()
            {
                Description = Text + "\r\n\r\nPlease select the initial folder to browse for playlists:",
                ShowNewFolderButton = true,
                SelectedPath = playlistsLabel.Text
            };
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                playlistsLabel.Text = dlg.SelectedPath;
                savePlaylistBox.Checked = true;
            }
            dlg.Dispose();
        }

        private void EnablePlayersBox_CheckedChanged(object sender, EventArgs e)
        {
            enablePlayersBox.Refresh();
            SetMiniPlayers();
        }

        private void SecondsBox_Click(object sender, EventArgs e)
        {
            continuePlayBox.Checked = true;
        }

        private void SecondsBox_KeyDown(object sender, KeyEventArgs e)
        {
            // the length of the input is limited to 5 digits in the dialog's constructor
            // here, don't allow typing the minus, decimal or comma chars:
            if (e.KeyCode == Keys.Subtract || e.KeyCode == Keys.OemMinus
                || e.KeyCode == Keys.Decimal || e.KeyCode == Keys.OemPeriod
                || e.KeyCode == Keys.Oemcomma)
            {
                System.Media.SystemSounds.Beep.Play();
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        private void SecondsLabel_Click(object sender, EventArgs e)
        {
            continuePlayBox.Checked = !continuePlayBox.Checked;
        }

        private void SystemTimeBox_CheckedChanged(object sender, EventArgs e)
        {
            _baseForm.SetClockDisplay(showClockBox.Checked);
        }

        private void Clock24hLabel_Click(object sender, EventArgs e)
        {
            MainWindow.Prefs.Clock24Hr = !MainWindow.Prefs.Clock24Hr;
            clock24hLabel.Text = MainWindow.Prefs.Clock24Hr ? "24 hr" : "12 hr";
            showClockBox.Checked = true;
            _baseForm.SetClockTime(); // refresh clock display
        }

        private void ClockColorPanel_MouseClick(object sender, MouseEventArgs e)
        {
            Color newColor = Color.Empty;

            if (e.Button == MouseButtons.Right)
            {
                newColor = UIColors.MenuTextEnabledColor;
            }
            else
            {
                ColorDialog colorDialog = new ColorDialog();
                colorDialog.Color = clockColorPanel.BackColor;
                if (colorDialog.ShowDialog(this) == DialogResult.OK)
                {
                    newColor = colorDialog.Color;
                }
                colorDialog.Dispose();
            }
            if (newColor != Color.Empty)
            {
                showClockBox.Checked = true;
                clockColorPanel.BackColor = newColor;
                _baseForm.SetClockColor(newColor);
                _baseForm.SetClockDisplay(true);
            }
        }

        #endregion

    }
}
