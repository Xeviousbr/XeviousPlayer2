#region Usings

using System;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

#endregion

namespace FolderView
{
    // ******************************** Globals

    #region Globals

    // Global Constants and Variables - used at various locations
    static class Globals
    {
        internal static FileSearch Subtitles;

        internal static PrivateFontCollection FontCollection1;
        internal static Font CrystalFont16;
        internal static Font CrystalFont26;
    }

    #endregion

    // ******************************** Custom Color Menus

    #region CustomMenuRenderer

    class CustomMenuRenderer : ToolStripProfessionalRenderer, IDisposable
    {
        #region Fields

        private SolidBrush _stripBrush;
        private SolidBrush _marginBrush;
        private SolidBrush _selectBrush;
        private Pen _selectPen;
        private Rectangle _checkRect;
        private Color _textColor = Color.FromArgb(179, 173, 146);
        private bool _disposed;

        #endregion

        public CustomMenuRenderer() : base(new CustomMenuColors())
        {
            _stripBrush = new SolidBrush(Color.FromArgb(32, 32, 32));
            _marginBrush = new SolidBrush(Color.FromArgb(48, 48, 48));
            _selectBrush = new SolidBrush(Color.FromArgb(64, 24, 24));
            _selectPen = new Pen(Color.FromArgb(80, 80, 80));
            _checkRect = new Rectangle(2, 1, 20, 20);
        }

        protected override void OnRenderImageMargin(ToolStripRenderEventArgs e)
        { e.Graphics.FillRectangle(_marginBrush, e.AffectedBounds); }

        protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
        { e.Graphics.FillRectangle(_stripBrush, e.AffectedBounds); }

        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            e.TextColor = _textColor; // Color.Goldenrod;
            base.OnRenderItemText(e);
        }

        protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
        {
            e.ArrowColor = e.Item.Enabled ? _textColor : Color.DimGray;
            base.OnRenderArrow(e);
        }

        protected override void OnRenderItemCheck(ToolStripItemImageRenderEventArgs e)
        {
            _checkRect.Height = e.Item.Height - 2;
            e.Graphics.FillRectangle(_selectBrush, _checkRect);
            e.Graphics.DrawRectangle(Pens.DimGray, _checkRect);
            e.Graphics.DrawString("\u2713", e.Item.Font, Brushes.Goldenrod, Rectangle.Inflate(e.ImageRectangle, 0, 1));
        }

        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            if (e.Item.Selected || e.Item.BackColor != SystemColors.Control)
            {
                e.Graphics.FillRectangle(_selectBrush, 0, 0, e.Item.Width, e.Item.Height);
                e.Graphics.DrawRectangle(_selectPen, 1, 0, e.Item.Width - 2, e.Item.Height - 1);
            }
        }

        #region Dispose

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _stripBrush.Dispose();
                    _marginBrush.Dispose();
                    _selectBrush.Dispose();
                    _selectPen.Dispose();
                }
                _disposed = true;
            }
        }

        #endregion

    }

    #endregion

    #region CustomMenuColors

    class CustomMenuColors : ProfessionalColorTable
    {
        private Color _lineColor = Color.FromArgb(80, 80, 80);

        public override Color SeparatorDark
        {
            get { return _lineColor; }
        }

        public override Color SeparatorLight
        {
            get { return Color.DarkGray; }
        }

        //public override Color CheckBackground
        //{
        //    get { return Color.DarkGray; }
        //}

        //public override Color CheckSelectedBackground
        //{
        //    get { return Color.DarkGray; }
        //}

        //public override Color CheckPressedBackground
        //{
        //    get { return Color.DarkGray; }
        //}
    }

    #endregion
}

