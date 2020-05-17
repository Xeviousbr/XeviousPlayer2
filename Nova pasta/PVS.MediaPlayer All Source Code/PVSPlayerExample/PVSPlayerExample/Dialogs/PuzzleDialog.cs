#region Usings

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

#endregion

namespace PVSPlayerExample
{
    public partial class PuzzleDialog : Form
    {
        // Puzzle Completed Dialog - asks to play again or stop (with auto close).

        #region Fields

        private const int           AUTO_CLOSE_SECONDS  = 30;
        private const string        MESSAGE             = "Completed!";
        private const int           OUTLINE_WIDTH       = 3;

        private double              _oldOpacity;
        private Timer               _closeTimer;
        private LinearGradientBrush _fillBrush;

        private bool                _disposed;

        #endregion

        public PuzzleDialog()
        {
            InitializeComponent();

            _fillBrush = new LinearGradientBrush(messageLabel.DisplayRectangle, Color.FromArgb(18, 18, 18), messageLabel.ForeColor, LinearGradientMode.Vertical);
            _fillBrush.SetBlendTriangularShape(0.5F);

            _oldOpacity = Opacity;
            Opacity = 0;
        }

        private void PuzzleDialog_Shown(object sender, EventArgs e)
        {
            Application.DoEvents();
            System.Threading.Thread.Sleep(50);
            Opacity = _oldOpacity;

            _closeTimer = new Timer();
            _closeTimer.Interval = AUTO_CLOSE_SECONDS * 1000;
            _closeTimer.Tick += NoButton_Click;
            _closeTimer.Start();
        }

        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                _disposed = true;
                if (disposing)
                {
                    _closeTimer.Dispose();
                    _fillBrush.Dispose();

                    if (components != null) components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        private void YesButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void NoButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        // Draw text

        private void MessageLabel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            GraphicsPath path = new GraphicsPath();
            path.AddString(MESSAGE, messageLabel.Font.FontFamily, (int)messageLabel.Font.Style, messageLabel.Font.Size * 1.3f, messageLabel.ClientRectangle, StringFormat.GenericDefault);
            e.Graphics.DrawPath(new Pen(Color.FromArgb(60, 0, 0), OUTLINE_WIDTH), path);
            e.Graphics.FillPath(_fillBrush, path);
            path.Dispose();
        }
    }
}
