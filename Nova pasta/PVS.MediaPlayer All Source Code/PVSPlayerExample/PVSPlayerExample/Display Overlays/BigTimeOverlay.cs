#region Usings

using PVS.MediaPlayer;
using System;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

#endregion

namespace PVSPlayerExample
{
    public sealed partial class BigTimeOverlay : Form, IOverlay
    {
        /*

        PVS.MediaPlayer Display Overlay - Example 'Big Time'
        Displays large timecounters using embedded digital font
        and -optional- audio peaklevel meters.

        */

        // ******************************** Fields

        #region Fields

        private bool        _isActive;
        private MainWindow   _baseWindow;
        private Player      _basePlayer;
        private Font        _crystalFont45;
        private bool        _smallDisplay;
        private bool        _busy;
        private bool        _progressTime = true;

        // VU Meters
        private bool        _vuMetersEnabled;
        private bool        _vuMetersHidden;
        private VU_Meter    _leftVUMeter;
        private VU_Meter    _rightVUMeter;

        private bool        _disposed;

        #endregion

        // ******************************** Main

        #region Main

        public BigTimeOverlay(MainWindow baseWindow, Player basePlayer, PrivateFontCollection fontCollection)
        {
            InitializeComponent();

            _baseWindow = baseWindow;
            _basePlayer = basePlayer;
            _crystalFont45 = new Font(fontCollection.Families[0], 45, FontStyle.Italic);

            // Pass on drag and drop to main form (handled in source file: DragDrop.cs):
            AllowDrop = true;
            DragDrop += _baseWindow.Form1_DragDrop;

            startTimerLabel.Font = _crystalFont45;
            startTimerLabel.UseCompatibleTextRendering = true;
            endTimerLabel.Font = _crystalFont45;
            endTimerLabel.UseCompatibleTextRendering = true;
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

        private void BigTimeOverlay_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                BigTimeOverlay_SizeChanged(this, EventArgs.Empty); // set initial position
                SizeChanged += BigTimeOverlay_SizeChanged;
                _basePlayer.Events.MediaPositionChanged += BasePlayer_MediaPositionChanged;
                // get values if paused:
                if (_basePlayer.Playing && _basePlayer.Paused) SetTimeValues();
                // Vu meters
                if (_vuMetersHidden) ShowVUMeters();
                _isActive = true;

                MouseDown += _basePlayer.Display.Drag_MouseDown;

                _basePlayer.Overlay.Blend = OverlayBlend.Transparent;
            }
            else
            {
                SizeChanged -= BigTimeOverlay_SizeChanged;
                _basePlayer.Events.MediaPositionChanged -= BasePlayer_MediaPositionChanged;
                // Vu meters
                HideVUMeters(true);
                _isActive = false;

                MouseDown -= _basePlayer.Display.Drag_MouseDown;

                _basePlayer.Overlay.Blend = OverlayBlend.None;
            }
        }

        private void BigTimeOverlay_SizeChanged(object sender, EventArgs e)
        {
            if (Width < 640)
            {
                if (!_smallDisplay)
                {
                    startTimerLabel.Top = Height - 120;
                    endTimerLabel.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
                    endTimerLabel.Top = Height - 60;
                    endTimerLabel.Left = startTimerLabel.Left;
                    _smallDisplay = true;

                    if (_vuMetersEnabled) HideVUMeters(true);
                }
            }
            else if (_smallDisplay)
            {
                startTimerLabel.Top = Height - 60;
                endTimerLabel.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right);
                endTimerLabel.Top = Height - 60;
                endTimerLabel.Left = Width - 320;
                _smallDisplay = false;

                if (_vuMetersHidden) ShowVUMeters();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_leftVUMeter != null)
                    {
                        if (_vuMetersEnabled) _basePlayer.Events.MediaPeakLevelChanged -= BasePlayer_MediaPeakLevelChanged;
                        _leftVUMeter.Dispose();
                        _rightVUMeter.Dispose();
                    }

                    if (_isActive)
                    {
                        SizeChanged -= BigTimeOverlay_SizeChanged;
                        _basePlayer.Events.MediaPositionChanged -= BasePlayer_MediaPositionChanged;
                    }

                    _crystalFont45.Dispose(); _crystalFont45 = null;
                    _basePlayer = null;

                    DragDrop -= _baseWindow.Form1_DragDrop;

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
        public bool MenuEnabled
        {
            get { return optionsPanel.Visible; }
            set { optionsPanel.Visible = value; }
        }

        public bool HasMenu
        {
            get { return true; }
        }

        public void MediaStopped()
        {
            startTimerLabel.Text = endTimerLabel.Text = "00:00:00.000";
        }

        #endregion

        // ******************************** Options Menu

        #region Options Menu

        #region Time Mode

        private void TrackTimeMenuItem_Click(object sender, EventArgs e)
        {
            _progressTime = false;
            startTimerLabel.Invalidate();
            endTimerLabel.Invalidate();

            trackTimeMenuItem.Checked = true;
            progressTimeMenuItem.Checked = false;
        }

        private void ProgressTimeMenuItem_Click(object sender, EventArgs e)
        {
            _progressTime = true;
            startTimerLabel.Invalidate();
            endTimerLabel.Invalidate();

            trackTimeMenuItem.Checked = false;
            progressTimeMenuItem.Checked = true;
        }

        #endregion

        #region Color

        private void ColorMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog { Color = startTimerLabel.ForeColor };
            if (colorDialog.ShowDialog(this) == DialogResult.OK)
            {
                startTimerLabel.ForeColor = endTimerLabel.ForeColor = colorDialog.Color;

                int r = startTimerLabel.ForeColor.R > 1 ? startTimerLabel.ForeColor.R - 2 : startTimerLabel.ForeColor.R + 2;
                int g = startTimerLabel.ForeColor.G > 1 ? startTimerLabel.ForeColor.G - 2 : startTimerLabel.ForeColor.G + 2;
                int b = startTimerLabel.ForeColor.B > 1 ? startTimerLabel.ForeColor.B - 2 : startTimerLabel.ForeColor.B + 2;
                BackColor = Color.FromArgb(r, g, b);
                TransparencyKey = BackColor;
            }
            colorDialog.Dispose();
        }

        #endregion

        #region VU Meters

        private void ShowVUMetersMenuItem_Click(object sender, EventArgs e)
        {
            if (_vuMetersEnabled || _vuMetersHidden)
            {
                HideVUMeters(false);
            }
            else
            {
                if (_leftVUMeter == null)
                {
                    Point p = new Point(10, this.Height - 216);
                    _leftVUMeter = new VU_Meter();
                    _leftVUMeter.Location = p;
                    _leftVUMeter.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
                    _leftVUMeter.Visible = false;
                    this.Controls.Add(_leftVUMeter);
                    _leftVUMeter.SendToBack();

                    _rightVUMeter = new VU_Meter();
                    p.X = this.Width - _rightVUMeter.Width - 10;
                    _rightVUMeter.Location = p;
                    _rightVUMeter.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
                    _rightVUMeter.Visible = false;
                    this.Controls.Add(_rightVUMeter);
                    _leftVUMeter.SendToBack();
                }
                ShowVUMeters();
            }
        }

        private void ShowVUMeters()
        {
            if (!_vuMetersEnabled)
            {
                if (_smallDisplay)
                {
                    _vuMetersHidden = true;
                }
                else
                {
                    _basePlayer.Events.MediaPeakLevelChanged += BasePlayer_MediaPeakLevelChanged;
                    _vuMetersEnabled = _leftVUMeter.Visible = _rightVUMeter.Visible = true;
                    _vuMetersHidden = false;
                }
                showVUMetersMenuItem.Text = "Hide VU Meters";
            }
        }

        private void HideVUMeters(bool forced)
        {
            if (_vuMetersEnabled)
            {
                _vuMetersEnabled = _leftVUMeter.Visible = _rightVUMeter.Visible = false;
                _basePlayer.Events.MediaPeakLevelChanged -= BasePlayer_MediaPeakLevelChanged;
                _leftVUMeter.Value = _rightVUMeter.Value = -1;
                if (!forced) showVUMetersMenuItem.Text = "Show VU Meters";
                _vuMetersHidden = forced;
            }
            else if (_vuMetersHidden && !forced)
            {
                _vuMetersHidden = false;
                showVUMetersMenuItem.Text = "Show VU Meters";
            }
        }

        #endregion

        #region Opacity

        // Opacity 25%
        private void Opacity25_MenuItem_Click(object sender, EventArgs e)
        {
            Opacity = 0.25;
            SetOpacityMenu(sender);
        }

        // Opacity 50%
        private void Opacity50_MenuItem_Click(object sender, EventArgs e)
        {
            Opacity = 0.50;
            SetOpacityMenu(sender);
        }

        // Opacity 75%
        private void Opacity75_MenuItem_Click(object sender, EventArgs e)
        {
            Opacity = 0.75;
            SetOpacityMenu(sender);
        }

        // Opacity 100%
        private void Opacity100_MenuItem_Click(object sender, EventArgs e)
        {
            Opacity = 1;
            SetOpacityMenu(sender);
        }

        // Checks the selected Opacity menu item and removes the check marks from the others
        private void SetOpacityMenu(object sender)
        {
            foreach (ToolStripItem item in (((ToolStripMenuItem)sender).GetCurrentParent().Items))
            {
                if (item.GetType() == typeof(ToolStripMenuItem))
                {
                    ((ToolStripMenuItem)item).Checked = item == sender;
                }
            }

            opacityMenuItem.Checked = (Opacity != 1);
        }

        #endregion

        #endregion

        // ******************************** Player PositionChanged / PeakLevelChanged Eventhandlers

        #region Player PositionChanged / SetPositionValues / PeakLevelChanged Eventhandlers

        private void BasePlayer_MediaPositionChanged(object sender, PositionEventArgs e)
        {
            if (_busy) return;
            _busy = true;

            TimeSpan t0, t1;

            if (_progressTime)
            {
                t0 = TimeSpan.FromTicks(e.FromStart);
                t1 = TimeSpan.FromTicks(e.ToStop);
            }
            else
            {
                t0 = TimeSpan.FromTicks(e.FromBegin);
                t1 = TimeSpan.FromTicks(e.ToEnd);
            }

            startTimerLabel.Text = string.Format("{0:00;00}:{1:00;00}:{2:00;00}.{3:000;000}", t0.Hours, t0.Minutes, t0.Seconds, t0.Milliseconds);
            endTimerLabel.Text = string.Format("{0:00;00}:{1:00;00}:{2:00;00}.{3:000;000}", t1.Hours, t1.Minutes, t1.Seconds, t1.Milliseconds);

            _busy = false;
        }

        private void SetTimeValues()
        {
            TimeSpan t0, t1;
            if (_progressTime)
            {
                t0 = _basePlayer.Position.FromStart;
                t1 = _basePlayer.Position.ToStop;
            }
            else
            {
                t0 = _basePlayer.Position.FromBegin;
                t1 = _basePlayer.Position.ToEnd;
            }

            startTimerLabel.Text = string.Format("{0:00;00}:{1:00;00}:{2:00;00}.{3:000;000}", t0.Hours, t0.Minutes, t0.Seconds, t0.Milliseconds);
            endTimerLabel.Text = string.Format("{0:00;00}:{1:00;00}:{2:00;00}.{3:000;000}", t1.Hours, t1.Minutes, t1.Seconds, t1.Milliseconds);
        }

        private void BasePlayer_MediaPeakLevelChanged(object sender, PeakLevelEventArgs e)
        {
            _leftVUMeter.Value = e.ChannelsValues[0];
            _rightVUMeter.Value = e.ChannelsValues[1];
        }

        #endregion

    }
}
