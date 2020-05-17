#region Usings

using System;
using System.Drawing;
using System.Windows.Forms;

#endregion

namespace PVSPlayerExample
{

    // Webcam Copy Overlay
    // a display overlay used by the Webcam Window to show a copy message

    // the backcolor "Lime" is chosen because this color lets mouse clicks through to the underlying window
    // and has (in this case) no influence on the display of the items on the overlay

    public partial class WebcamCopyOverlay : Form
    {
        #region Fields

        private const string    FILE_TEXT       = "File";
        private const string    CLIPBOARD_TEXT  = "Clipboard";

        private Pen             _copyPen;
        private bool            _disposed;

        #endregion

        public WebcamCopyOverlay()
        {
            InitializeComponent();

            _copyPen = new Pen(Color.FromArgb(179, 173, 146), 1);
        }

        protected override bool ShowWithoutActivation
        {
            get { return true; }
        }

        // Don't activate form with mouse click
        protected override void WndProc(ref Message m)
        {
            const int WM_MOUSEACTIVATE = 0x0021;
            const int MA_NOACTIVATE = 0x0003;

            if (m.Msg == WM_MOUSEACTIVATE) m.Result = (IntPtr)MA_NOACTIVATE;
            else base.WndProc(ref m);
        }

        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                _disposed = true;
                if (disposing)
                {
                    if (_copyPen != null) _copyPen.Dispose();
                    if (components != null) components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        private void WebcamCopyOverlay_SizeChanged(object sender, EventArgs e)
        {
            copyMessagePanel.Left = (Width - copyMessagePanel.Width) / 2;
            copyMessagePanel.Top = (Height - copyMessagePanel.Height) / 2;
        }

        private void CopyMessagePanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(_copyPen, new Rectangle(0, 0, copyMessagePanel.ClientRectangle.Width - 1, copyMessagePanel.ClientRectangle.Height - 1));
        }

        internal void ShowMessagePanel(bool show)
        {
            copyMessagePanel.Visible = show;
        }

        internal void SetDestinationText(bool file)
        {
            if (file) destinationLabel.Text = FILE_TEXT;
            else destinationLabel.Text      = CLIPBOARD_TEXT;
        }
    }
}
