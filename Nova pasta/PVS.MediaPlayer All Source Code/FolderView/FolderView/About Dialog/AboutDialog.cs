#region Usings

using System;
using System.Drawing;
using System.Windows.Forms;
using PVS.MediaPlayer;

#endregion

namespace FolderView
{
    // About dialog - shows some information about this example application.

    public partial class AboutDialog : Form
    {
        private MainWindow  _baseWindow;
        private double      _oldOpacity;


        public AboutDialog(MainWindow window)
        {
            InitializeComponent();
            _baseWindow = window;

            Icon = Properties.Resources.Media8b;
            Text = Player.VersionString;

            _oldOpacity = Opacity;
            Opacity = 0;

            this.KeyPreview = true;
            this.KeyDown += AboutDialog_KeyDown;
        }

        private void AboutDialog_Shown(object sender, EventArgs e)
        {
            Application.DoEvents();
            Opacity = _oldOpacity;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawIcon(SystemIcons.Information, 23, 25);

            Rectangle rect = DisplayRectangle;
            rect.Width -= 1;
            rect.Height -= 1;
            Pen pen = new Pen(Color.FromArgb(109,103,76), 1);
            e.Graphics.DrawRectangle(pen, rect);
            pen.Dispose();
        }

        private void LogoPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillEllipse(Brushes.SandyBrown, new Rectangle(1, 1, 30, 30));
            e.Graphics.DrawImage(Properties.Resources.Bob, 0, 0);
        }

        private void PVSLogo_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(Properties.Resources.PVSLogoOutline, 4, 0);
        }

        private void AboutDialog_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                e.Handled = true;
                Close();
            }
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void UrlLabel_Click(object sender, EventArgs e)
        {
            _baseWindow.UrlClicked = true;
            Close();
        }

    }
}
