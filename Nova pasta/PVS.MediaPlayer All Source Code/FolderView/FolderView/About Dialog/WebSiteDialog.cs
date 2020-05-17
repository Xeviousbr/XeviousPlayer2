#region Usings

using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

#endregion

namespace FolderView
{
    public partial class WebSiteDialog : Form
    {
        // Website dialog - requests (yes/no) website to be opened in browser.

        double      _oldOpacity;


        public WebSiteDialog()
        {
            InitializeComponent();

            Icon = Properties.Resources.Media8b;

            _oldOpacity = Opacity;
            Opacity     = 0;
        }

        private void WebSiteDialog_Shown(object sender, EventArgs e)
        {
            Application.DoEvents();
            Opacity = _oldOpacity;
            SystemSounds.Question.Play();
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

        private void PVSLogo_Paint(object sender, PaintEventArgs e)
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
        internal int Selection
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

    }
}
