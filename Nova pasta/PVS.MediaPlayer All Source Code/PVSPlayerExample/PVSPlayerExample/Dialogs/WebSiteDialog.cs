#region Usings

using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

#endregion

namespace PVSPlayerExample
{
    public partial class WebSiteDialog : Form
    {
        // Website dialog - requests (yes/no) website to be opened in browser (with auto close).


        #region Fields

        private const int   AUTO_CLOSE_SECONDS = 30;

        private MainWindow  _baseForm;
        private Control[]   _miniDisplays;
        private double      _oldOpacity;
        private Timer       _closeTimer;
        private bool        _disposed;

        #endregion


        public WebSiteDialog(MainWindow baseForm)
        {
            InitializeComponent();
            Icon = Properties.Resources.Media_Normal;

            _baseForm   = baseForm;

            _oldOpacity = Opacity;
            Opacity     = 0;
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

        private void WebSiteDialog_Shown(object sender, EventArgs e)
        {
            if (MainWindow.Prefs.ShowMiniPlayers)
            {
                _miniDisplays = new Control[] { panel4 };
                _baseForm.Player1.DisplayClones.AddRange(_miniDisplays);
                FormClosing += WebSiteDialog_FormClosing;
            }

            Application.DoEvents();
            System.Threading.Thread.Sleep(50);

            Opacity = _oldOpacity;
            SystemSounds.Question.Play();

            _closeTimer = new Timer();
            _closeTimer.Interval = AUTO_CLOSE_SECONDS * 1000;
            _closeTimer.Tick += NoButton_Click;
            _closeTimer.Start();
        }

        private void WebSiteDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_miniDisplays != null)
            {
                _baseForm.Player1.DisplayClones.RemoveRange(_miniDisplays);
                _miniDisplays = null;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawIcon(SystemIcons.Question, 23, 25);

            e.Graphics.FillEllipse(Brushes.SandyBrown, new Rectangle(71, 77, 30, 30));
            e.Graphics.DrawImage(Properties.Resources.Bob, 70, 76);

            Pen pen = new Pen(Color.FromArgb(109, 103, 76), 1);
            Rectangle rect = DisplayRectangle;
            rect.Width -= 1;
            rect.Height -= 1;
            e.Graphics.DrawRectangle(pen, rect);
            pen.Dispose();
        }

        private void PvsPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(Properties.Resources.PVSLogoOutline, 4, 0);
        }

        // OK - Yes
        private void OKButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        // Cancel - No
        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Goto Home Page (0), PVS Article (1) or Recorder Article(2)
        public int Selection
        {
            get
            {
                int result = 0;
                if (radioButton2.Checked) result = 1;
                else if (radioButton3.Checked) result = 2;
                return result;
            }
            set
            {
                if (value == 0) radioButton1.Checked = true;
                else if (value == 2) radioButton3.Checked = true;
                else radioButton2.Checked = true;
            }
        }

        private void NoButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

    }
}
