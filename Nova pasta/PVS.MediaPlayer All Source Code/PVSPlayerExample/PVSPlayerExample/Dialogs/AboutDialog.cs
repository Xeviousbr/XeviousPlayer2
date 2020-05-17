#region Usings

using System;
using System.Drawing;
using System.Windows.Forms;
using PVS.MediaPlayer;

#endregion

namespace PVSPlayerExample
{
    // About dialog - shows some information about this sample application (with auto close).

    public partial class AboutDialog : Form
    {
        #region Fields

        private const int   AUTO_CLOSE_SECONDS = 60;

        private MainWindow  _base;
        private double      _oldOpacity;
        private Control[]   _miniDisplays;
        private Timer       _closeTimer;
        private bool        _disposed;

        #endregion


        public AboutDialog(MainWindow window)
        {
            InitializeComponent();
            _base                   = window;

            _closeTimer             = new Timer();
            _closeTimer.Interval    = AUTO_CLOSE_SECONDS * 1000;
            _closeTimer.Tick        += NoButton_Click;

            Icon                    = Properties.Resources.Media_Normal;
            Text                    = Player.VersionString;
            toolTipCheckBox.Checked = MainWindow.Prefs.ShowTooltips;
            MainWindow.UrlClicked   = false;

            KeyPreview              = true;
            KeyDown                 += AboutDialog_KeyDown;

            _oldOpacity             = Opacity;
            Opacity                 = 0;
        }

        private void AboutDialog_Shown(object sender, EventArgs e)
        {
            if (MainWindow.Prefs.ShowMiniPlayers)
            {
                _miniDisplays = new Control[] { panel1, panel2, panel3 };
                _base.Player1.DisplayClones.AddRange(_miniDisplays);
                FormClosing += AboutDialog_FormClosing;
            }

            Application.DoEvents();
            System.Threading.Thread.Sleep(50);

            Opacity = _oldOpacity;

            _closeTimer.Start();
        }

        protected override void OnMove(EventArgs e)
        {
            base.OnMove(e);

            if (_closeTimer != null)
            {
                _closeTimer.Stop();
                _closeTimer.Start();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                _disposed = true;
                if (disposing)
                {
                    _closeTimer.Dispose();

                    if (components != null) components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        private void AboutDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_miniDisplays != null)
            {
                _base.Player1.DisplayClones.RemoveRange(_miniDisplays);
                _miniDisplays = null;
            }
        }

        private void AboutDialog_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                e.Handled = true;
                Close();
            }
            else if (e.KeyCode == Keys.F1)
            {
                e.Handled = true;
                MainWindow.UrlClicked = true;
                Close();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawIcon(SystemIcons.Information, 23, 25);

            Rectangle rect = DisplayRectangle;
            rect.Width -= 1;
            rect.Height -= 1;
            Pen pen = new Pen(Color.FromArgb(109, 103, 76), 1);
            e.Graphics.DrawRectangle(pen, rect);
            pen.Dispose();
        }

        private void LogoPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillEllipse(Brushes.SandyBrown, new Rectangle(1, 1, 30, 30));
            e.Graphics.DrawImage(Properties.Resources.Bob, 0, 0);
        }

        private void KaizenPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(Properties.Resources.Kaizen_4, 0, 0);
        }

        private void PvsPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(Properties.Resources.PVSLogoOutline, 4, 0);
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ToolTipCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            MainWindow.Prefs.ShowTooltips = toolTipCheckBox.Checked;
            if (_closeTimer.Enabled)
            {
                _closeTimer.Stop(); _closeTimer.Start();
            }
        }

        private void UrlLabel_Click(object sender, EventArgs e)
        {
            MainWindow.UrlClicked = true;
            Close();
        }

        private void NoButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

    }
}
