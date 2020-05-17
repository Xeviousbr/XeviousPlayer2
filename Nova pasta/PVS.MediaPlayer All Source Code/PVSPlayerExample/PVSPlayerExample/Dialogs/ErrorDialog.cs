#region Usings

using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

#endregion

namespace PVSPlayerExample
{
    // ErrorBox - a dialog window to show errors and messages.

    public partial class ErrorDialog : Form
    {
        #region Fields

        private const int   AUTO_CLOSE_SECONDS_INFO     = 45;
        private const int   AUTO_CLOSE_SECONDS_ERROR    = 30;

        private bool        _useTimer;
        private Timer       _closeTimer;
        private bool        _infoType;
        private double      _oldOpacity;

        #endregion


        public ErrorDialog(string title, string errorText, bool infoIcon, bool useTimer)
        {
            InitializeComponent();

            Icon = Properties.Resources.Media_Normal;
            Text = title;
            _useTimer = useTimer;

            int oldLabelHeight = label1.Height;
            label1.Text = errorText;
            label1.Height = label1.PreferredHeight;
            Height += label1.Height - oldLabelHeight;

            _infoType = infoIcon;

            _oldOpacity = Opacity;
            Opacity = 0;
        }

        private void ErrorDialog_Shown(object sender, EventArgs e)
        {
            Application.DoEvents();
            System.Threading.Thread.Sleep(50);
            Opacity = _oldOpacity;

            if (_useTimer)
            {
                _closeTimer = new Timer();
                if (_infoType)
                {
                    //System.Media.SystemSounds.Asterisk.Play();
                    _closeTimer.Interval = AUTO_CLOSE_SECONDS_INFO * 1000;
                }
                else
                {
                    SystemSounds.Exclamation.Play();
                    _closeTimer.Interval = AUTO_CLOSE_SECONDS_ERROR * 1000;
                }
                _closeTimer.Tick += Button1_Click;
                RestartTimer();
            }
            else if (!_infoType) SystemSounds.Exclamation.Play();
        }

        protected override void OnMove(EventArgs e)
        {
            base.OnMove(e);
            if (_useTimer) RestartTimer();
        }

        private void RestartTimer()
        {
            if (_closeTimer != null)
            {
                _closeTimer.Stop();
                _closeTimer.Start();
            }
        }

        private void ErrorDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_closeTimer != null)
            {
                _closeTimer.Stop();
                _closeTimer.Dispose();
                _closeTimer = null;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawIcon(_infoType ? SystemIcons.Information : SystemIcons.Exclamation, 23, 25);
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

        internal bool PlayNext
        {
            get { return checkBox1.Checked; }
            set { checkBox1.Checked = value; }
        }

        internal bool PlayNextVisible
        {
            get { return checkBox1.Visible; }
            set { checkBox1.Visible = value; }
        }

        internal bool OnErrorRemove
        {
            get { return checkBox2.Checked; }
            set { checkBox2.Checked = value; }
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (_useTimer) RestartTimer();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
