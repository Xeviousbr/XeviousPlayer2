#region Usings

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

#endregion

namespace PVSPlayerExample
{
    // PVS.MediaPlayer Example Application - Custom Controls

    // These custom controls are 'regular' controls with one or more properties added or changed
    // and are made for and used only with this example application's user interface to reduce
    // manual setting of properties with the designer and/or (re-) writing code for handling them.

    // Note: these user controls are far from complete for general purposes, but they can be easily
    // modified to be so. The idea here is that they'll be short and fast.

    // ******************************** Global Color Scheme

    #region Global Color Scheme

    internal static class UIColors
    {
        /* ... under construction ... */

        // Buttons, DropDownButtons
        static internal Color BorderColor = Color.FromArgb(64, 64, 64); // 100
        //static internal Pen FocusPen = new Pen(Color.DarkGoldenrod);
        static internal Pen FocusPen = new Pen(Color.FromArgb(169, 163, 136));

        static internal Color NormalColor1A = Color.Gray;
        static internal Color NormalColor1B = Color.FromArgb(32, 32, 32);
        static internal Color NormalColor2A = Color.Black;
        static internal Color NormalColor2B = Color.FromArgb(48, 48, 48);

        static internal Color HotColor1A = Color.FromArgb(148, 148, 148);
        static internal Color HotColor1B = Color.FromArgb(32, 32, 32);
        static internal Color HotColor2A = Color.Black;
        static internal Color HotColor2B = Color.FromArgb(60, 60, 60); //60

        static internal Color PressedColor1A = Color.FromArgb(180, 180, 180); // 164
        static internal Color PressedColor1B = Color.FromArgb(40, 40, 40); // 48
        static internal Color PressedColor2A = Color.Black; // 18
        static internal Color PressedColor2B = Color.FromArgb(72, 72, 72); // 72

        // Sliders Thumb
        static internal Pen ThumbBorderPen = new Pen(Color.FromArgb(80, 80, 80));

        static internal Color NormalThumbColor1 = Color.FromArgb(132, 132, 132);
        static internal Color NormalThumbColor2 = Color.Black;

        static internal Color HotThumbColor1 = Color.FromArgb(148, 148, 148);
        static internal Color HotThumbColor2 = Color.FromArgb(18, 18, 18);

        static internal Color PressedThumbColor1 = Color.FromArgb(180, 180, 180); // 164
        static internal Color PressedThumbColor2 = Color.FromArgb(18, 18, 18);

        // Menus
        static internal Color MenuBackgroundColor = Color.FromArgb(32, 32, 32);
        static internal Color MenuMarginColor = Color.FromArgb(48, 48, 48);
        //static internal Color MenuBorderColor = Color.DimGray;
        static internal Color MenuBorderColor = Color.FromArgb(64, 64, 64);
        //static internal Color MenuBorderColor = Color.FromArgb(56, 56, 56);

        static internal Color MenuSeparatorDarkColor = Color.FromArgb(80, 80, 80);
        static internal Color MenuSeparatorLightColor = Color.DimGray;

        static internal Color MenuHighlightColor = Color.FromArgb(64, 24, 24);
        //static internal Color MenuHighlightColor2 = Color.FromArgb(18, 18, 18);
        //static internal Color MenuHighlightColor = Color.FromArgb(48, 48, 48);
        //static internal Color MenuHighlightBorderColor = Color.FromArgb(80, 80, 80);
        static internal Color MenuHighlightBorderColor = Color.FromArgb(64, 64, 64);

        static internal Color MenuTextEnabledColor = Color.FromArgb(169, 163, 136);
        static internal Color MenuTextDisabledColor = Color.DimGray;
    }

    #endregion

    // ******************************** Custom Controls

    #region Custom Control: HeadLabel

    internal sealed class HeadLabel : Label
    {
        // A label with a linear gradient background

        private LinearGradientBrush _brush;

        public HeadLabel()
        {
            ForeColor = Color.Goldenrod;
            TextAlign = ContentAlignment.MiddleCenter;
            _brush = new LinearGradientBrush(DisplayRectangle, Color.FromArgb(64, 64, 64), Color.Black, LinearGradientMode.Vertical);
        }

        protected override Size DefaultSize
        {
            get { return new Size(121, 19); }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            if (DisplayRectangle.Width < 1 || DisplayRectangle.Height < 1) return;

            if (_brush != null) _brush.Dispose();
            _brush = new LinearGradientBrush(DisplayRectangle, Color.FromArgb(64, 64, 64), Color.Black, LinearGradientMode.Vertical);
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            pevent.Graphics.FillRectangle(_brush, DisplayRectangle);
        }
    }

    #endregion

    #region Custom Control: CustomPanel

    internal sealed class CustomPanel : Panel
    {
        // A panel with a linear gradient background

        LinearGradientBrush _brush;

        public CustomPanel()
        {
            _brush = new LinearGradientBrush(DisplayRectangle, Color.FromArgb(64, 64, 64), Color.Black, LinearGradientMode.Vertical);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (_brush != null) _brush.Dispose();
            _brush = new LinearGradientBrush(DisplayRectangle, Color.FromArgb(64, 64, 64), Color.Black, LinearGradientMode.Vertical);
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            pevent.Graphics.FillRectangle(_brush, DisplayRectangle);
        }
    }

    #endregion

    #region Custom Control: BufferedPanel

    internal sealed class BufferedPanel : Panel
    {
        // A panel with double buffered option enabled

        private Pen         _borderPen;
        private Rectangle   _borderRect;
        private bool        _disposed;

        public BufferedPanel()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);

            _borderPen = new Pen(Color.FromArgb(64, 64, 64), 1);
            SetBorderRect();
        }

        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                _disposed = true;
                if (disposing)
                {
                    _borderPen.Dispose();
                }
                base.Dispose(disposing);
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            e.Graphics.DrawRectangle(_borderPen, _borderRect);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            SetBorderRect();
        }

        private void SetBorderRect()
        {
            _borderRect.Location = ClientRectangle.Location;
            _borderRect.Width = ClientRectangle.Width - 1;
            _borderRect.Height = ClientRectangle.Height - 1;
        }
    }

    #endregion

    #region Custom Control: SliderPanel

    internal class SliderPanel : Panel
    {
        // Removed.
    }

    #endregion

    #region Custom Control: DropDownButton

    internal class DropDownButton : CheckBox
    {
        // A button-type control with a little arrow to select an option from a dropdown menu.

        // ************************************ Fields

        #region Fields

        private const int           ARROW_MARGIN = 11;

        private ContextMenuStrip    _theMenu;
        private bool                _hasMenu;
        private bool                _menuInitialized;
        private bool                _showArrow = true;

        private Point[]             _arrowPoints;
        private Brush               _enabledColor;
        private Brush               _disabledColor;

        private LinearGradientBrush _normalBrush1;
        private LinearGradientBrush _normalBrush2;
        private LinearGradientBrush _hotBrush1;
        private LinearGradientBrush _hotBrush2;
        private LinearGradientBrush _pressedBrush1;
        private LinearGradientBrush _pressedBrush2;

        private Rectangle           _borderRect;
        private Rectangle           _buttonRect1;
        private Rectangle           _buttonRect2;

        private Rectangle           _textRect;

        private Pen                 _borderPen;
        private bool                _hotButton;
        private bool                _pressedButton;

        private bool                _disposed;

        #endregion

        // ************************************ Main

        #region Main

        public DropDownButton()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.Opaque, true);

            _textRect = ClientRectangle;

            _borderPen = new Pen(UIColors.BorderColor);

            _arrowPoints = new Point[3];
            SetButtonRectangle();

            base.AutoSize = false;
            Size = new Size(123, 23);
            base.Appearance = Appearance.Button;
            TextAlign = ContentAlignment.MiddleLeft;

            _enabledColor = new SolidBrush(Color.FromArgb(169, 163, 136)); // if changed back - remove dispose
            _disabledColor = new SolidBrush(Color.FromArgb(175, 175, 175));
        }

        protected override void OnCheckedChanged(EventArgs e)
        {
            if (_hasMenu && base.Checked)
            {
                if (!_menuInitialized)
                {
                    // .NET Bug? The first time the contextmenu is not shown at the specified location
                    // so the first time showing the dropdown we do this...
                    _theMenu.AutoSize = false;
                    _theMenu.Height = 0;
                    _theMenu.Show(0, 0);
                    _theMenu.Close();
                    _theMenu.AutoSize = true;
                    _menuInitialized = true;

                    _theMenu.Closed += TheMenu_Closed; // used with checked status (this is a checkbox type)
                }
                _theMenu.Show(this, 0, Height);
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            _textRect = ClientRectangle;
            if (_showArrow)
            {
                _textRect.X = ARROW_MARGIN;
                _textRect.Width -= 2 * ARROW_MARGIN;
            }

            SetButtonRectangle();
        }

        /// <summary>
        /// Gets or sets the control's border color.
        /// </summary>
        [Category("Appearance"), Description("The control's border color.")]
        public Color BorderColor
        {
            get { return _borderPen.Color; }
            set { _borderPen.Color = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether an arrow is displayed on the DropDownButton, which indicates that further options are available in a drop-down list.
        /// </summary>
        [Category("Appearance"), Description("Indicates whether an arrow should be shown on the DropDownButton."), DefaultValue(true)]
        public bool ShowDropDownArrow
        {
            get { return _showArrow; }
            set
            {
                _showArrow = value;
                _textRect = ClientRectangle;
                if (_showArrow)
                {
                    _textRect.X = ARROW_MARGIN;
                    _textRect.Width -= 2 * ARROW_MARGIN;
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                _disposed = true;
                if (disposing)
                {
                    _enabledColor.Dispose(); _enabledColor = null;
                    _disabledColor.Dispose(); _disabledColor = null;

                    _borderPen.Dispose(); _borderPen = null;
                    _normalBrush1.Dispose(); _normalBrush1 = null;
                    _normalBrush2.Dispose(); _normalBrush2 = null;
                    _hotBrush1.Dispose(); _hotBrush1 = null;
                    _hotBrush2.Dispose(); _hotBrush2 = null;
                    _pressedBrush1.Dispose(); _pressedBrush1 = null;
                    _pressedBrush2.Dispose(); _pressedBrush2 = null;
                }
                base.Dispose(disposing);
            }
        }

        #endregion

        // ************************************ DropDownMenu

        #region DropDownMenu

        /// <summary>
        /// Gets or sets the ContextMenuStrip that will be displayed when this DropDownButton is clicked.
        /// </summary>
        [Category("Data"), Description("Specifies a ContextMenuStrip to display when the control is clicked."), DefaultValue(null)]
        public ContextMenuStrip DropDown
        {
            get { return _theMenu; }
            set { SetMenu(value); }
        }

        private void SetMenu(ContextMenuStrip menu)
        {
            if (_hasMenu)
            {
                if (base.Checked) _theMenu.Close();
                if (_menuInitialized) _theMenu.Closed -= TheMenu_Closed;
                _theMenu = null;
                _hasMenu = false;
                _menuInitialized = false;
            }

            if (menu != null)
            {
                _theMenu = menu;
                _hasMenu = true;

                for (int i = 0; i < menu.Items.Count; i++)
                {
                    if (menu.Items[i].GetType() == typeof(ToolStripSeparator))
                    {
                        menu.Items[i].Enabled = false;
                    }
                }
            }
        }

        void TheMenu_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            if (base.Checked) base.Checked = false;
        }

        #endregion

        // ************************************ MouseEventHandlers

        #region MouseEventHandlers

        protected override void OnMouseEnter(EventArgs eventargs)
        {
            _hotButton = true;
            base.OnMouseEnter(eventargs);
        }

        protected override void OnMouseLeave(EventArgs eventargs)
        {
            _hotButton = false;
            base.OnMouseLeave(eventargs);
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            _pressedButton = true;
            base.OnMouseDown(mevent);
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            _pressedButton = false;
            Invalidate();
            base.OnMouseUp(mevent);
        }

        #endregion

        // ************************************ OnPaint

        #region OnPaint

        protected override void OnPaint(PaintEventArgs pevent)
        {
            // draw fill
            if (_hotButton || base.Checked)
            {
                if (_pressedButton || base.Checked)
                {
                    pevent.Graphics.FillRectangle(_pressedBrush1, _buttonRect1);
                    pevent.Graphics.FillRectangle(_pressedBrush2, _buttonRect2);
                }
                else
                {
                    pevent.Graphics.FillRectangle(_hotBrush1, _buttonRect1);
                    pevent.Graphics.FillRectangle(_hotBrush2, _buttonRect2);
                }
            }
            else
            {
                pevent.Graphics.FillRectangle(_normalBrush1, _buttonRect1);
                pevent.Graphics.FillRectangle(_normalBrush2, _buttonRect2);
            }

            // draw border
            pevent.Graphics.DrawRectangle(_borderPen, _borderRect);

            // draw text
            TextRenderer.DrawText(pevent.Graphics, Text, Font, _textRect, ForeColor, Color.Transparent, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);

            if (_showArrow)
            {
                if (Enabled && _hasMenu) pevent.Graphics.FillPolygon(_enabledColor, _arrowPoints);
                else pevent.Graphics.FillPolygon(_disabledColor, _arrowPoints);
            }
        }

        #endregion

        // ************************************ SetButtonRectangle

        #region SetButtonRectangle

        private void SetButtonRectangle()
        {
            if (ClientRectangle.Width < 1 || ClientRectangle.Height < 1) return;

            if (_normalBrush1 != null)
            {
                _normalBrush1.Dispose();
                _normalBrush2.Dispose();
                _hotBrush1.Dispose();
                _hotBrush2.Dispose();
                _pressedBrush1.Dispose();
                _pressedBrush2.Dispose();
            }
            _borderRect.Width = ClientRectangle.Width - 1;
            _borderRect.Height = ClientRectangle.Height - 1;

            _buttonRect1 = new Rectangle(0, 0, ClientRectangle.Width, ClientRectangle.Height / 2);
            // gradient fix with odd heights
            _buttonRect2 = _buttonRect1.Height % 2 == 0 ? new Rectangle(0, ClientRectangle.Height / 2, ClientRectangle.Width, ClientRectangle.Height / 2) : new Rectangle(0, ClientRectangle.Height / 2, ClientRectangle.Width, ClientRectangle.Height / 2 + 2);

            _normalBrush1 = new LinearGradientBrush(_buttonRect1, UIColors.NormalColor1A, UIColors.NormalColor1B, LinearGradientMode.Vertical);
            _normalBrush2 = new LinearGradientBrush(_buttonRect2, UIColors.NormalColor2A, UIColors.NormalColor2B, LinearGradientMode.Vertical);
            _hotBrush1 = new LinearGradientBrush(_buttonRect1, UIColors.HotColor1A, UIColors.HotColor1B, LinearGradientMode.Vertical);
            _hotBrush2 = new LinearGradientBrush(_buttonRect2, UIColors.HotColor2A, UIColors.HotColor2B, LinearGradientMode.Vertical);
            _pressedBrush1 = new LinearGradientBrush(_buttonRect1, UIColors.PressedColor1A, UIColors.PressedColor1B, LinearGradientMode.Vertical);
            _pressedBrush2 = new LinearGradientBrush(_buttonRect2, UIColors.PressedColor2A, UIColors.PressedColor2B, LinearGradientMode.Vertical);

            _arrowPoints[0].X = Width - 13;
            _arrowPoints[0].Y = (Height / 2) - 1;
            _arrowPoints[1].X = _arrowPoints[0].X + 7;
            _arrowPoints[1].Y = _arrowPoints[0].Y;
            _arrowPoints[2].X = _arrowPoints[0].X + 3;
            _arrowPoints[2].Y = _arrowPoints[0].Y + 4;
        }

        #endregion

        // ******************************** Hide Some Inherited Properties

        #region Hide Some Inherited Properties

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        static public new event EventHandler CheckedChanged
        {
            add { throw new NotSupportedException(); }
            remove { }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        static public new event EventHandler CheckStateChanged
        {
            add { throw new NotSupportedException(); }
            remove { }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public override bool AutoSize
        {
            get { return false; }
            set { }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        new public Appearance Appearance
        {
            get { return base.Appearance; }
            set { }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        new public bool Checked
        {
            get { return base.Checked; }
            set { }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        new public ContentAlignment CheckAlign
        {
            get { return base.CheckAlign; }
            set { }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        new public CheckState CheckState
        {
            get { return base.CheckState; }
            set { }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        new public bool AutoCheck
        {
            get { return base.AutoCheck; }
            set { }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        new public bool ThreeState
        {
            get { return base.ThreeState; }
            set { }
        }

        #endregion
    }

    #endregion

    #region Custom Control: LightPanel

    internal class LightPanel : Panel
    {
        // A little checkbox type indicator (used with some buttons to indicate the active state)

        #region Fields

        private bool    _lightIsOn;
        private Color   _foreColor;
        private Color   _backColor;

        #endregion

        public LightPanel()
        {
            _foreColor = Color.Lime;
            _backColor = Color.FromArgb(18, 18, 18); ;
            base.BackColor  = _backColor;
        }

        protected override Size DefaultSize
        {
            get { return new Size(4, 6); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the control's 'light' (forecolor) is on.
        /// </summary>
        [Category("Appearance"), Description("Indicates whether the control's 'light' (forecolor) is on."), DefaultValue(false)]
        public bool LightOn
        {
            get { return _lightIsOn; }
            set
            {
                if (_lightIsOn != value)
                {
                    _lightIsOn      = value;
                    base.BackColor  = _lightIsOn ? _foreColor : _backColor;
                }
            }
        }

        public override Color ForeColor
        {
            get { return _foreColor; }
            set
            {
                _foreColor = value;
                if (_lightIsOn) base.BackColor = _foreColor;
            }
        }

        public override Color BackColor
        {
            get { return base.BackColor; }
            set
            {
                _backColor = value;
                if (!_lightIsOn) base.BackColor = _backColor;
            }
        }
    }

    #endregion

    #region Custom Control: SmoothLabel

    internal class SmoothLabel : Label
    {
        private TextRenderingHint _renderType = TextRenderingHint.ClearTypeGridFit;

        public TextRenderingHint TextRenderingHint
        {
            get { return _renderType; }
            set { _renderType = value; }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.TextRenderingHint = _renderType;
            base.OnPaint(e);
        }
    }

    #endregion

    #region Custom Control: PictureBox UserControl / ImageBox

    internal class ImageBox : PictureBox
    {
        protected override void OnPaint(PaintEventArgs pe)
        {
            pe.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            pe.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            pe.Graphics.CompositingMode = CompositingMode.SourceCopy;
            pe.Graphics.CompositingQuality = CompositingQuality.HighQuality;
            pe.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

            base.OnPaint(pe);
        }
    }

    #endregion

    #region Custom Control: CustomButton

    internal sealed class CustomButton : Button
    {
        // ************************************ Fields

        #region Fields

        private LinearGradientBrush _normalBrush1;
        private LinearGradientBrush _normalBrush2;
        private LinearGradientBrush _hotBrush1;
        private LinearGradientBrush _hotBrush2;
        private LinearGradientBrush _pressedBrush1;
        private LinearGradientBrush _pressedBrush2;

        private Rectangle           _borderRect;
        private Rectangle           _buttonRect1;
        private Rectangle           _buttonRect2;

        private Pen                 _borderPen;
        private bool                _hotButton;
        private bool                _pressedButton;
        private bool                _notifyDefault;
        private bool                _notifyDefaultDraw;

        private TextFormatFlags     _textFlags;

        private bool                _disposed;

        #endregion

        // ************************************ Main

        #region Main

        public CustomButton()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.Opaque, true);
            TextAlign = ContentAlignment.MiddleCenter;
            _textFlags = new TextFormatFlags();
            _textFlags = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter;

            _borderPen = new Pen(UIColors.BorderColor);
            SetButtonRectangle();
        }

        /// <summary>
        /// Gets or sets a value indicating whether the control's focus border is drawn.
        /// </summary>
        [Category("Appearance"), Description("Indicates whether the control's focus border is drawn."), DefaultValue(false)]
        public bool FocusBorder
        {
            get { return _notifyDefaultDraw; }
            set { _notifyDefaultDraw = value; }
        }

        /// <summary>
        /// Gets or sets the control's border color.
        /// </summary>
        [Category("Appearance"), Description("The control's border color.")]
        public Color BorderColor
        {
            get { return _borderPen.Color; }
            set { _borderPen.Color = value; }
        }

        public override void NotifyDefault(bool value)
        {
            _notifyDefault = value;
            base.NotifyDefault(value);
        }

        // need this for strange spacing of WebDings chars
        [DefaultValue(ContentAlignment.MiddleCenter)]
        public override ContentAlignment TextAlign
        {
            get
            {
                return base.TextAlign;
            }
            set
            {
                switch (value)
                {
                    case ContentAlignment.MiddleLeft:
                        _textFlags = TextFormatFlags.Left | TextFormatFlags.VerticalCenter;
                        break;
                    case ContentAlignment.MiddleCenter:
                        _textFlags = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter;
                        break;
                    case ContentAlignment.MiddleRight:
                        _textFlags = TextFormatFlags.Right | TextFormatFlags.VerticalCenter;
                        break;

                    // This is only to get the pause/next/previous/stop symbols centered!
                    case ContentAlignment.BottomCenter:
                        _textFlags = TextFormatFlags.Bottom;
                        break;
                }
                base.TextAlign = value;
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            SetButtonRectangle();
        }

        protected override void OnMouseEnter(EventArgs eventargs)
        {
            _hotButton = true;
            base.OnMouseEnter(eventargs);
        }

        protected override void OnMouseLeave(EventArgs eventargs)
        {
            _hotButton = false;
            base.OnMouseLeave(eventargs);
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            _pressedButton = true;
            base.OnMouseDown(mevent);
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            _pressedButton = false;
            Invalidate();
            base.OnMouseUp(mevent);
        }

        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {

                if (disposing)
                {
                    _borderPen.Dispose();
                    _normalBrush1.Dispose();
                    _normalBrush2.Dispose();
                    _hotBrush1.Dispose();
                    _hotBrush2.Dispose();
                    _pressedBrush1.Dispose();
                    _pressedBrush2.Dispose();
                }
                base.Dispose(disposing);
                _disposed = true;
            }
        }

        #endregion

        // ************************************ OnPaint

        #region OnPaint

        protected override void OnPaint(PaintEventArgs pevent)
        {
            // erase background - dropped (dropped rounded corners)
            // pevent.Graphics.FillRectangle(eraseBrush, this.ClientRectangle);

            // draw fill
            if (_hotButton)
            {
                if (_pressedButton)
                {
                    pevent.Graphics.FillRectangle(_pressedBrush1, _buttonRect1);
                    pevent.Graphics.FillRectangle(_pressedBrush2, _buttonRect2);
                }
                else
                {
                    pevent.Graphics.FillRectangle(_hotBrush1, _buttonRect1);
                    pevent.Graphics.FillRectangle(_hotBrush2, _buttonRect2);
                }
            }
            else
            {
                pevent.Graphics.FillRectangle(_normalBrush1, _buttonRect1);
                pevent.Graphics.FillRectangle(_normalBrush2, _buttonRect2);
            }

            // draw border
            if (_notifyDefault && _notifyDefaultDraw) pevent.Graphics.DrawRectangle(UIColors.FocusPen, _borderRect);
            else pevent.Graphics.DrawRectangle(_borderPen, _borderRect);

            // draw text
            if (_textFlags == TextFormatFlags.Bottom)
            {
                // This is only to get the pause/next/previous/stop symbols centered!
                TextRenderer.DrawText(pevent.Graphics, Text, Font, new Point(5, 1),
                    Enabled ? ForeColor : Color.DimGray, Color.Transparent);
            }
            else
            {
                TextRenderer.DrawText(pevent.Graphics, Text, Font, ClientRectangle,
                    Enabled ? ForeColor : Color.DimGray, Color.Transparent, _textFlags);
            }
          }

        #endregion

        // ************************************ SetButtonRectangle

        #region SetButtonRectangle

        private void SetButtonRectangle()
        {
            // dropped rounded corners

            if (_normalBrush1 != null)
            {
                _normalBrush1.Dispose();
                _normalBrush2.Dispose();
                _hotBrush1.Dispose();
                _hotBrush2.Dispose();
                _pressedBrush1.Dispose();
                _pressedBrush2.Dispose();
            }
            _borderRect.Width = ClientRectangle.Width - 1;
            _borderRect.Height = ClientRectangle.Height - 1;

            _buttonRect1 = new Rectangle(0, 0, ClientRectangle.Width, ClientRectangle.Height / 2);
            // gradient fix with odd heights
            _buttonRect2 = _buttonRect1.Height % 2 == 0 ? new Rectangle(0, ClientRectangle.Height / 2, ClientRectangle.Width, ClientRectangle.Height / 2) : new Rectangle(0, ClientRectangle.Height / 2, ClientRectangle.Width, ClientRectangle.Height / 2 + 2);

            _normalBrush1 = new LinearGradientBrush(_buttonRect1, UIColors.NormalColor1A, UIColors.NormalColor1B, LinearGradientMode.Vertical);
            _normalBrush2 = new LinearGradientBrush(_buttonRect2, UIColors.NormalColor2A, UIColors.NormalColor2B, LinearGradientMode.Vertical);
            _hotBrush1 = new LinearGradientBrush(_buttonRect1, UIColors.HotColor1A, UIColors.HotColor1B, LinearGradientMode.Vertical);
            _hotBrush2 = new LinearGradientBrush(_buttonRect2, UIColors.HotColor2A, UIColors.HotColor2B, LinearGradientMode.Vertical);
            _pressedBrush1 = new LinearGradientBrush(_buttonRect1, UIColors.PressedColor1A, UIColors.PressedColor1B, LinearGradientMode.Vertical);
            _pressedBrush2 = new LinearGradientBrush(_buttonRect2, UIColors.PressedColor2A, UIColors.PressedColor2B, LinearGradientMode.Vertical);
        }

        #endregion
    }

    #endregion

    #region Custom Control: CustomSlider

    // TrackBar used with position slider
    sealed internal class CustomSlider : TrackBar
    {
        // ********************************************* Fields

        #region Fields

        private Rectangle               _trackRect;
        private Rectangle               _tempRect; // split track area before and after thumb

        private SafeNativeMethods.RECT  _thumbRECT;
        private Rectangle               _thumbBorderRect;
        private Rectangle               _thumbEraseRect;
        private Rectangle               _thumbRect;

        private LinearGradientBrush     _normalBrush;
        private LinearGradientBrush     _hotBrush;
        private LinearGradientBrush     _pressedBrush;

        private bool                    _hotThumb;
        private bool                    _pressedThumb;

        private LinearGradientBrush     _track1Brush;
        private LinearGradientBrush     _track2Brush;

        private Region                  _eraseRegion; // to reduce flicker
        private SolidBrush              _eraseBrush;

        private Graphics                _graphics;

        private bool                    _disposed;

        #endregion

        // ********************************************* Main

        #region Main

        public CustomSlider()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.Opaque, true);
            base.BackColor = Color.Black;
            AutoSize = false;

            // background
            _eraseRegion = new Region(ClientRectangle);
            _eraseBrush = new SolidBrush(Color.Black); // default backcolor

            // track
            _trackRect = new Rectangle(8, 8, Width - 16, 4);
            _tempRect = new Rectangle(8, 8, Width - 16, 4);
            _track1Brush = new LinearGradientBrush(_trackRect, Color.DimGray, Color.Black, LinearGradientMode.Vertical);
            _track1Brush.SetBlendTriangularShape(0.5F);
            _track2Brush = new LinearGradientBrush(_trackRect, Color.FromArgb(48, 48, 48), Color.Black, LinearGradientMode.Vertical);
            //track2Brush.SetBlendTriangularShape(0.5F);

            // thumb
            _thumbRECT = new SafeNativeMethods.RECT();
            _thumbBorderRect = new Rectangle(0, 2, 9, 14);
            _thumbEraseRect = new Rectangle(0, 2, 10, 15);
            _thumbRect = new Rectangle(0, 3, 8, 13);

            _normalBrush = new LinearGradientBrush(_thumbRect, UIColors.NormalThumbColor1, UIColors.NormalThumbColor2, LinearGradientMode.Vertical);
            _normalBrush.SetBlendTriangularShape(0.5F);
            _hotBrush = new LinearGradientBrush(_thumbRect, UIColors.HotThumbColor1, UIColors.HotThumbColor2, LinearGradientMode.Vertical);
            _hotBrush.SetBlendTriangularShape(0.5F);
            _pressedBrush = new LinearGradientBrush(_thumbRect, UIColors.PressedThumbColor1, UIColors.PressedThumbColor2, LinearGradientMode.Vertical);
            _pressedBrush.SetBlendTriangularShape(0.5F);

            _graphics = CreateGraphics();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            _trackRect.Width = Width - 16;
            _graphics.Dispose();
            _graphics = CreateGraphics();
            base.OnSizeChanged(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (_thumbBorderRect.Contains(e.Location))
            {
                if (!_hotThumb)
                {
                    _hotThumb = true;
                    Invalidate(_thumbRect);
                }
            }
            else if (_hotThumb && !_pressedThumb)
            {
                _hotThumb = false;
                Invalidate(_thumbRect);
            }

            base.OnMouseMove(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (_hotThumb && e.Button == MouseButtons.Left)
            {
                _pressedThumb = true;
                Invalidate(_thumbRect);
            }
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (_pressedThumb)
            {
                _pressedThumb = false;
                Invalidate(_thumbRect);
            }
            base.OnMouseUp(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            if (_hotThumb)
            {
                _hotThumb = _pressedThumb = false;
                Invalidate(_thumbRect);
            }
            base.OnMouseLeave(e);
        }

        [DefaultValue(typeof(Color), "Black")]
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = value;
                _eraseBrush.Color = value;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _eraseRegion.Dispose();
                    _eraseBrush.Dispose();

                    _normalBrush.Dispose();
                    _hotBrush.Dispose();
                    _pressedBrush.Dispose();
                    _track1Brush.Dispose();
                    _track2Brush.Dispose();

                    _graphics.Dispose();
                }
                _disposed = true;
                base.Dispose(disposing);
            }
        }

        #endregion

        // ********************************************* OnPaint

        #region OnPaint

        protected override void OnPaint(PaintEventArgs e)
        {
            // get the thumb position first - also used with draw track
            SafeNativeMethods.SendMessage(Handle, SafeNativeMethods.TBM_GETTHUMBRECT, IntPtr.Zero, ref _thumbRECT);
            _thumbBorderRect.X = _thumbEraseRect.X = _thumbRECT.left;
            _thumbRect.X = _thumbRECT.left + 1;

            // erase background
            _eraseRegion.MakeEmpty();
            _eraseRegion.Union(ClientRectangle);
            _eraseRegion.Exclude(_trackRect);
            _eraseRegion.Exclude(_thumbEraseRect);
            _graphics.FillRegion(_eraseBrush, _eraseRegion);

            // draw track - different fill color before and after thumb position
            // before thumb
            _tempRect.X = _trackRect.X;
            //g.DrawRectangle(Pens.DimGray, trackRect);
            _tempRect.Width = _thumbBorderRect.X - _trackRect.X;
            _graphics.FillRectangle(_track1Brush, _tempRect);
            // after thumb
            _tempRect.X = _thumbBorderRect.X + _thumbBorderRect.Width;
            _tempRect.Width = _trackRect.Width - _thumbBorderRect.X;
            _graphics.FillRectangle(_track2Brush, _tempRect);

            // draw thumb
            if (_hotThumb)
            {
                _graphics.FillRectangle(_pressedThumb ? _pressedBrush : _hotBrush, _thumbRect);
            }
            else
            {
                _graphics.FillRectangle(_normalBrush, _thumbRect);
            }
            _graphics.DrawRectangle(UIColors.ThumbBorderPen, _thumbBorderRect);
        }

        #endregion
    }

    #endregion

    #region Custom Control: CustomSlider2

    internal sealed class CustomSlider2 : TrackBar
    {
        // ********************************************* Fields

        #region Fields

        private Rectangle _trackRect;

        private Rectangle _ticks1Rect;
        private Rectangle _ticks2Rect;

        private SafeNativeMethods.RECT _thumbRECT;
        private Rectangle _thumbBorderRect;
        private Rectangle _thumbRect;

        private LinearGradientBrush _normalBrush;
        private LinearGradientBrush _hotBrush;
        private LinearGradientBrush _pressedBrush;

        private bool _hotThumb;
        private bool _pressedThumb;

        private LinearGradientBrush _trackBrush;

        private bool _disposed;

        #endregion

        // ********************************************* Main

        #region Main

        public CustomSlider2()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
            Orientation = Orientation.Horizontal;
            TickStyle = TickStyle.Both;
            AutoSize = false;

            // track
            _trackRect = new Rectangle(8, 19, Width - 17, 6);
            _trackBrush = new LinearGradientBrush(_trackRect, Color.FromArgb(64, 64, 64), Color.Black, LinearGradientMode.Vertical);
            _trackBrush.SetBlendTriangularShape(0.5F);

            // ticks
            _ticks1Rect = new Rectangle(13, 6, Width - 26, 3);
            _ticks2Rect = new Rectangle(13, 33, Width - 26, 3);

            // thumb
            _thumbRECT = new SafeNativeMethods.RECT();
            _thumbBorderRect = new Rectangle(0, 11, 9, 19);
            _thumbRect = new Rectangle(0, 12, 8, 18);

            _normalBrush = new LinearGradientBrush(_thumbRect, UIColors.NormalThumbColor1, UIColors.NormalThumbColor2, LinearGradientMode.Vertical);
            _normalBrush.SetBlendTriangularShape(0.5F);
            _hotBrush = new LinearGradientBrush(_thumbRect, UIColors.HotThumbColor1, UIColors.HotThumbColor2, LinearGradientMode.Vertical);
            _hotBrush.SetBlendTriangularShape(0.5F);
            _pressedBrush = new LinearGradientBrush(_thumbRect, UIColors.PressedThumbColor1, UIColors.PressedThumbColor2, LinearGradientMode.Vertical);
            _pressedBrush.SetBlendTriangularShape(0.5F);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            _trackRect.Width = Width - 17;
            _ticks1Rect.Width = _ticks2Rect.Width = Width - 26;
            base.OnSizeChanged(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (_thumbBorderRect.Contains(e.Location))
            {
                if (!_hotThumb)
                {
                    _hotThumb = true;
                    Invalidate(_thumbRect);
                }
            }
            else if (_hotThumb && !_pressedThumb)
            {
                _hotThumb = false;
                Invalidate(_thumbRect);
            }
            base.OnMouseMove(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (_hotThumb && e.Button == MouseButtons.Left)
            {
                _pressedThumb = true;
                Invalidate(_thumbRect);
            }
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (_pressedThumb)
            {
                _pressedThumb = false;
                Invalidate(_thumbRect);
            }
            base.OnMouseUp(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            if (_hotThumb)
            {
                _hotThumb = _pressedThumb = false;
                Invalidate(_thumbRect);
            }
            base.OnMouseLeave(e);
        }

        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _normalBrush.Dispose();
                    _hotBrush.Dispose();
                    _pressedBrush.Dispose();
                    _trackBrush.Dispose();
                }
                base.Dispose(disposing);
                _disposed = true;
            }
        }

        #endregion

        // ********************************************* OnPaint

        #region OnPaint

        protected override void OnPaint(PaintEventArgs e)
        {
            // get the thumb position
            SafeNativeMethods.SendMessage(Handle, SafeNativeMethods.TBM_GETTHUMBRECT, IntPtr.Zero, ref _thumbRECT);
            _thumbBorderRect.X = _thumbRECT.left;
            _thumbRect.X = _thumbRECT.left + 1;

            // draw ticks
            if (TickFrequency > 0)
            {
                int tickCount = Math.Abs((Maximum - Minimum) / TickFrequency) + 1;
                TrackBarRenderer.DrawHorizontalTicks(e.Graphics, _ticks1Rect, tickCount, System.Windows.Forms.VisualStyles.EdgeStyle.Sunken);
                TrackBarRenderer.DrawHorizontalTicks(e.Graphics, _ticks2Rect, tickCount, System.Windows.Forms.VisualStyles.EdgeStyle.Sunken);
            }

            // draw track
            //TrackBarRenderer.DrawHorizontalTrack(e.Graphics, trackRect);
            e.Graphics.FillRectangle(_trackBrush, _trackRect);

            //// draw thumb
            //e.Graphics.DrawRectangle(UIColors.ThumbBorderPen, thumbBorderRect);

            // draw thumb fill
            if (_hotThumb)
            {
                e.Graphics.FillRectangle(_pressedThumb ? _pressedBrush : _hotBrush, _thumbRect);
            }
            else e.Graphics.FillRectangle(_normalBrush, _thumbRect);

            // draw thumb
            e.Graphics.DrawRectangle(UIColors.ThumbBorderPen, _thumbBorderRect);
        }

        #endregion
    }

    #endregion

    #region Custom Control: VU Meter

    sealed class VU_Meter : Control
    {
        /*
      
        A sample audio peak level meter (analog VU meter) control.
        Background image grabbed from the internet. Copyright unknown.

        */

        // ******************************** Fields

        #region Fields

        #region Constants

        private const double    METER_LOW_VALUE     = 142;  // high = low, has to do with angle (for Math.Cos/Sin) of needle
        private const double    METER_HIGH_VALUE    = 38;
        private const int       METER_LIGHT_VALUE   = 65;   // peak light on below this value
        private const double    METER_DECAY_DELAY   = 8;    // lower = slower (needle moving downwards)

        private const double    RADIAN              = Math.PI / 180;
        private const double    SCALE_UNIT          = 32767 / (METER_LOW_VALUE - METER_HIGH_VALUE);

        private const double    NEEDLE_LENGTH       = 108;
        private const float     NEEDLE_ORIGIN_X     = 155;  // x-coordinate of the base of the needle
        private const float     NEEDLE_ORIGIN_Y     = 138;  // y-coordinate of the base of the needle

        #endregion

        private Bitmap          _backgroundImage;

        private Pen             _needlePen;
        private Rectangle       _smallImageRect;
        private Rectangle       _ledLightRect;

        private double          _value              = METER_LOW_VALUE;
        private double          _oldValue           = METER_LOW_VALUE;

        private bool            _disposed;

        #endregion

        // ******************************** Main - Ctor / Dispose

        #region Main

        public VU_Meter()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer | ControlStyles.Opaque, true);

            _backgroundImage = Properties.Resources.VU_Meter; // this control is tailored for this image
            _backgroundImage.SetResolution(96, 96);
            this.Size = _backgroundImage.Size;

            _needlePen = new Pen(Color.FromArgb(64, 64, 64), 1.6F);
            _smallImageRect = new Rectangle(45, 30, 237, 110);
            _ledLightRect = new Rectangle(264, 57, 16, 16);
        }

        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // image in resource - don't dispose
                    _needlePen.Dispose();
                }
                _disposed = true;
            }
            base.Dispose(disposing);
        }

        #endregion

        // ******************************** Paint

        #region Paint

        protected override void OnPaint(PaintEventArgs e)
        {
            // draw (part of) background image
            e.Graphics.DrawImageUnscaled(_backgroundImage, 0, 0);

            // set anti-alias for needle and peak light
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // draw needle
            double rad = RADIAN * _value;
            e.Graphics.DrawLine(_needlePen, NEEDLE_ORIGIN_X, NEEDLE_ORIGIN_Y,
                (float)(NEEDLE_ORIGIN_X + (NEEDLE_LENGTH * Math.Cos(rad))), (float)(NEEDLE_ORIGIN_Y - (NEEDLE_LENGTH * Math.Sin(rad))));

            // draw peak light
            if (_value <= METER_LIGHT_VALUE) e.Graphics.FillEllipse(Brushes.Red, _ledLightRect);
        }

        #endregion

        // ******************************** Set Meter Value

        #region Set Meter Value

        // Changed with PVS.MediaPlayer version 0.91: values are between 0.0 and 1.0

        // This property receives values (in the range from 0 to 32767) from the player or
        // recorder (through the application's PeakLevelChanged eventhandler) and 'checks'
        // the value before it's displayed on the meter.
        // To slow down the meter the value can not change more than METER_DECAY_DELAY
        // units downwards. The value of -1 is sent by a player to signal that media playback
        // has paused, stopped or ended and the meter can be set immediately to the lowest value.

        // The low and high meter values are reversed: this has to do with the calculation
        // of the angle of the needle.

        // The values shown by this control are not true decibel values.

        internal float Value
        {
            set
            {
                int newVal = (int)(value * 32767); // easy conversion - should rewrite but is a bit complicated

                if (newVal < 0) _value = METER_LOW_VALUE;
                else
                {
                    if (newVal < 1) _value = METER_LOW_VALUE;
                    else if (newVal > 32766) _value = METER_HIGH_VALUE;
                    else _value = METER_LOW_VALUE - (newVal / SCALE_UNIT);

                    if (_value > _oldValue + METER_DECAY_DELAY)
                    {
                        if (_oldValue < METER_LOW_VALUE - METER_DECAY_DELAY) _value = _oldValue + METER_DECAY_DELAY;
                        else _value = METER_LOW_VALUE;
                    }
                }
                _oldValue = _value;
                this.Invalidate(_smallImageRect); // 'paint' new value on meter
            }
        }

        #endregion
    }

    #endregion

    #region Custom Control: Dial

    sealed class Dial : Control
    {
        // This control is not (yet) ready for common use.

        // ******************************** Events / EventArgs

        #region Events / EventArgs

        /// <summary>
        /// Provides data for the Dial.ValueChanged event.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public class ValueChangedEventArgs : EventArgs
        {
            private Dial _base;
            private int _value;

            public ValueChangedEventArgs(Dial theDial)
            {
                _base = theDial;
            }

            /// <summary>
            /// Gets a numeric value that represents the position of the dial. Value 0 to 1000. 
            /// </summary>
            public int Value
            {
                get { return _value; }
                set { _value = _base._value; }
            }
        }

        /// <summary>
        /// Occurs when the position of the dial has changed.
        /// </summary>
        public event EventHandler<ValueChangedEventArgs> ValueChanged;

        #endregion

        // ******************************** Fields

        #region Fields

        #region Constants

        private const int   FULL_CIRCLE     = 360;
        private const int   MINIMUM_VALUE   = 0;
        private const float MAXIMUM_VALUE   = 1000;

        #endregion

        private bool        _dialing;

        private Bitmap      _dialImage;
        private Size        _dialSize;
        private int         _dialCenter;

        //private bool        _hasIndicator       = true; // if false 'continuous rotating'
        private int         _indicatorType;     // 0 = volume,  1 = balance
        private Color       _indicatorColor1    = Color.DimGray;
        //private Color       _indicatorColor2    = Color.FromArgb(169, 163, 136);
        private Pen         _indicatorPen1;
        //private Pen       _indicatorPen2;
        private Rectangle   _indicatorRect;

        private float       _dialSpeed          = 2.2F;   // dial speed accelerator / decelerator
        private float       _dialAngle;

        private bool        _hasMinMax          = true;
        private float       _minMaxUnits        = 270 / MAXIMUM_VALUE;

        private float       _dialAngleMin       = -135; // depends on the 'start position' of the used image
        private float       _dialAngleMax       = 135; // and the amount of total rotation (here 2 * 135 = 270)
        private float       _dialAngleUnits     = MAXIMUM_VALUE / 270;

        private int         _oldLocationX;
        private int         _oldLocationY;

        private int         _value;
        private ValueChangedEventArgs           _valueChangedArgs;

        private bool        _disposed;

        #endregion


        // ******************************** Main - Constructor / Dispose

        #region Main - Constructor / Dispose

        public Dial()
        {
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.SupportsTransparentBackColor, true);

            _indicatorPen1 = new Pen(_indicatorColor1, 1);
            //_indicatorPen1.StartCap = LineCap.Round;
            //_indicatorPen1.EndCap = LineCap.Round;

            //_indicatorPen2          = new Pen(_indicatorColor2, 1);
            //_indicatorPen1.StartCap = LineCap.Round;
            //_indicatorPen1.EndCap   = LineCap.Round;

            _indicatorRect = new Rectangle(1, 1, 0, 0);
            //this.Image = Properties.Resources.Dial_Normal;
            this.Image = Properties.Resources.Dial_Normal_2;

            _valueChangedArgs = new ValueChangedEventArgs(this);
        }

        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                _disposed = true;
                if (disposing)
                {
                    _dialing = false;
                    _dialImage = null;
                    _indicatorPen1.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #endregion

        // ******************************** Paint Dial

        #region Paint Dial

        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);
            if (_dialImage != null)
            {
                Graphics g = e.Graphics;

                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;

                // These circle indicators are nice but don't look good in this app

                //if (_hasIndicator)
                //{
                //    if (_indicatorType == 0)
                //    {
                //        e.Graphics.DrawArc(_indicatorPen1, _indicatorRect, 135, _minMaxUnits * _value);
                //        //e.Graphics.DrawArc(_indicatorPen2, _indicatorRect, 135, _minMaxUnits * _value);
                //    }
                //    else if (_indicatorType == 1)
                //    {
                //        if (Value <= 500)
                //        {
                //            e.Graphics.DrawArc(_indicatorPen1, _indicatorRect, 135, _minMaxUnits * (500 + _value));
                //            //e.Graphics.DrawArc(_indicatorPen2, _indicatorRect, 135, _minMaxUnits * (500 + _value));

                //        }
                //        else
                //        {
                //            float arcValue = _minMaxUnits * (_value - 500);
                //            e.Graphics.DrawArc(_indicatorPen1, _indicatorRect, 135 + arcValue, 270 - arcValue);
                //            //e.Graphics.DrawArc(_indicatorPen2, _indicatorRect, 135 + arcValue, 270 - arcValue);
                //        }
                //    }
                //}

                g.TranslateTransform(_dialCenter, _dialCenter);
                g.RotateTransform(_dialAngle);
                g.TranslateTransform(-_dialCenter, -_dialCenter);
                g.DrawImage(_dialImage, 5, 5);
            }
        }

        #endregion

        // ******************************** Properties - Image / Size / Value / Minimum / Maximum

        #region Properties - Image / Size / Value / Minimum / Maximum

        /// <summary>
        /// Get or sets the image of the dial control. The width and height of the image have to be equal.
        /// </summary>
        public Bitmap Image
        {
            get { return _dialImage; }
            set
            {
                if (value.Width == value.Height)
                {
                    _dialImage = value;
                    _dialImage.SetResolution(96, 96);

                    this.Width = _dialImage.Size.Width + 11;
                    this.Height = this.Width;

                    _dialSize.Width = this.Width;
                    _dialSize.Height = this.Height;

                    _indicatorRect.Width = Width - 3;
                    _indicatorRect.Height = _indicatorRect.Width;

                    _dialCenter = Width / 2;

                    this.Invalidate();
                }
            }
        }

        public override Size MinimumSize
        {
            get { return _dialSize; }
            set { }
        }
        public override Size MaximumSize
        {
            get { return _dialSize; }
            set { }
        }

        /// <summary>
        /// Gets or sets a numeric value that represents the position of the dial. Value 0 to 1000. 
        /// </summary>
        public int Value
        {
            get { return _value; }
            set
            {
                if (SetDialValue(value) && ValueChanged != null)
                {
                    _valueChangedArgs.Value = _value;
                    ValueChanged(this, _valueChangedArgs);
                }
            }
        }

        private bool SetDialValue(int value)
        {
            bool changed = false;

            if (value < MINIMUM_VALUE)
            {
                if (_hasMinMax) value = MINIMUM_VALUE;
                else value = (int)MAXIMUM_VALUE + value;
            }
            else if (value > MAXIMUM_VALUE)
            {
                if (_hasMinMax) value = (int)MAXIMUM_VALUE;
                else value = value - (int)MAXIMUM_VALUE;
            }

            if (_value != value)
            {
                _value = value;
                changed = true;

                if (_hasMinMax) _dialAngle = _dialAngleMin + (_minMaxUnits * _value);
                else _dialAngle = FULL_CIRCLE * (_value / MAXIMUM_VALUE);

                this.Invalidate();
            }
            return changed;
        }

        public int IndicatorType
        {
            get { return _indicatorType; }
            set { _indicatorType = value; }
        }

        #endregion

        // ******************************** Methods - SetValue / Switch Image

        #region Methods - SetValue / Switch Image

        /// <summary>
        /// Sets the value of the dial without raising the ValueChanged event.
        /// </summary>
        /// <param name="value">The value to be set for the dial. Value 0 to 1000.</param>
        public bool SetValue(int value)
        {
            return SetDialValue(value);
        }

        // just for this application
        public void SwitchImage(bool redDial)
        {
            //if (redDial) _dialImage = Properties.Resources.Dial_Red;
            //else _dialImage = Properties.Resources.Dial_Normal;
            if (redDial) _dialImage = Properties.Resources.Dial_Red_2;
            else _dialImage = Properties.Resources.Dial_Normal_2;
            _dialImage.SetResolution(96, 96);
            this.Invalidate();
        }

        #endregion

        // ************************************************ Mouse Handling

        #region Mouse Handling

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (_dialImage != null)
            {
                this.Focus();

                _oldLocationX = e.Location.X;
                _oldLocationY = e.Location.Y;
                _dialing = true;
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (_dialing)
            {
                float oldAngle = _dialAngle;

                if (_oldLocationY <= _dialCenter) _dialAngle += (e.Location.X - _oldLocationX) * _dialSpeed;
                else _dialAngle -= (e.Location.X - _oldLocationX) * _dialSpeed;

                if (_oldLocationX <= _dialCenter) _dialAngle -= (e.Location.Y - _oldLocationY) * _dialSpeed;
                else _dialAngle += (e.Location.Y - _oldLocationY) * _dialSpeed;

                if (_hasMinMax)
                {
                    if (_dialAngle <= _dialAngleMin) _dialAngle = _dialAngleMin;
                    else if (_dialAngle > _dialAngleMax) _dialAngle = _dialAngleMax;
                }

                if (_dialAngle < -FULL_CIRCLE) _dialAngle += FULL_CIRCLE;
                else if (_dialAngle > FULL_CIRCLE) _dialAngle -= FULL_CIRCLE;

                if (_hasMinMax) _value = (int)((_dialAngle - _dialAngleMin) * _dialAngleUnits);
                else
                {
                    if (_dialAngle < 0) _value = (int)(((FULL_CIRCLE + _dialAngle) / FULL_CIRCLE) * MAXIMUM_VALUE);
                    else _value = (int)((_dialAngle / FULL_CIRCLE) * MAXIMUM_VALUE);
                }

                if (_dialAngle != oldAngle)
                {
                    this.Invalidate();

                    if (ValueChanged != null)
                    {
                        _valueChangedArgs.Value = _value;
                        ValueChanged(this, _valueChangedArgs);
                    }
                }

                _oldLocationX = e.Location.X;
                _oldLocationY = e.Location.Y;
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            _dialing = false;
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            int value = _value - 50;
            if (e.Delta > 0)
            {
                value += 100;
                if (value > 1000) value = 1000;
            }
            else if (value < 0) value = 0;

            if (value != _value)
            {
                if (SetDialValue(value) && ValueChanged != null)
                {
                    _valueChangedArgs.Value = _value;
                    ValueChanged(this, _valueChangedArgs);
                }
            }
        }

        #endregion

        // ************************************************Key Handling

        #region Key Handling

        protected override bool IsInputKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Right:
                case Keys.Left:
                case Keys.Up:
                case Keys.Down:
                    return true;
                case Keys.Shift | Keys.Right:
                case Keys.Shift | Keys.Left:
                case Keys.Shift | Keys.Up:
                case Keys.Shift | Keys.Down:
                    return true;
            }
            return base.IsInputKey(keyData);
        }

        // TODO
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            e.Handled = true;
            switch (e.KeyCode)
            {
                case Keys.Left:
                case Keys.NumPad4:
                    Value = _value - 10;
                    break;

                case Keys.Down:
                case Keys.NumPad2:
                    Value = _value - 100;
                    break;

                case Keys.Right:
                case Keys.NumPad6:
                    Value = _value + 10;
                    break;

                case Keys.Up:
                case Keys.NumPad8:
                    Value = _value + 100;
                    break;

                case Keys.PageUp:
                    Value = _value + 250;
                    break;

                case Keys.PageDown:
                    Value = _value - 250;
                    break;

                case Keys.Home:
                    Value = MINIMUM_VALUE;
                    break;

                case Keys.End:
                    Value = (int)MAXIMUM_VALUE;
                    break;

                default:
                    e.Handled = false;
                    break;
            }
        }

        #endregion
    }

    #endregion

    #region Custom Control: BlendLabel

    sealed class BlendLabel : Label
    {
        // Overlay blending on display clones and screen copies does not work with standard labels.
        // Here's an altenative solution: draw the labeltext with graphics.DrawString

        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);
            SolidBrush b = new SolidBrush(ForeColor);
            e.Graphics.DrawString(Text, Font, b, 0, 0);
            b.Dispose();
        }
    }

    #endregion


    // ******************************** Custom Color Menus

    #region CustomMenuRenderer

    internal class CustomMenuRenderer : ToolStripProfessionalRenderer, IDisposable
    {
        private SolidBrush          _backgroundBrush;
        private SolidBrush          _marginBrush;
        private LinearGradientBrush _highlightBrush;
        private Pen                 _highlightBorderPen;
        private Rectangle           _checkMarkRect;

        public CustomMenuRenderer() : base(new CustomMenuColors())
        {
            _backgroundBrush = new SolidBrush(UIColors.MenuBackgroundColor);
            _marginBrush = new SolidBrush(UIColors.MenuMarginColor);

            //highlightBrush = new SolidBrush(UIColors.MenuHighlightColor);
            //highlightBrush = new LinearGradientBrush(new Rectangle(0, 0, 200, 22), Color.DimGray, UIColors.MenuHighlightColor, LinearGradientMode.Vertical);
            _highlightBrush = new LinearGradientBrush(new Rectangle(0, 0, 200, 22), Color.DimGray, Color.Black, LinearGradientMode.Vertical);
            _highlightBrush.SetBlendTriangularShape(0.5F);

            _highlightBorderPen = new Pen(UIColors.MenuHighlightBorderColor);
            _checkMarkRect = new Rectangle(12, 8, 2, 6);
        }

        protected override void OnRenderImageMargin(ToolStripRenderEventArgs e)
        { e.Graphics.FillRectangle(_marginBrush, e.AffectedBounds); }

        protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
        { e.Graphics.FillRectangle(_backgroundBrush, e.AffectedBounds); }

        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            if (e.Item.ForeColor == SystemColors.ControlText) e.TextColor = UIColors.MenuTextEnabledColor; // Color.Goldenrod;
            base.OnRenderItemText(e);
        }

        protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
        {
            e.ArrowColor = e.Item.Enabled ? UIColors.MenuTextEnabledColor : UIColors.MenuTextDisabledColor;
            base.OnRenderArrow(e);
        }

        protected override void OnRenderItemCheck(ToolStripItemImageRenderEventArgs e)
        {
            //checkRect.Height = e.Item.Height - 2;
            //e.Graphics.FillRectangle(selectBrush, checkRect);
            //e.Graphics.DrawRectangle(Pens.DimGray, checkRect);
            //e.Graphics.DrawString("\u2713", e.Item.Font, Brushes.Goldenrod, Rectangle.Inflate(e.ImageRectangle, 0, 1));

            e.Graphics.FillRectangle(Brushes.Lime, _checkMarkRect);
        }

        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            if ((e.Item.Enabled && e.Item.Selected) || e.Item.BackColor != SystemColors.Control)
            {
                e.Graphics.FillRectangle(_highlightBrush, 0, 0, e.Item.Width, e.Item.Height);
                e.Graphics.DrawRectangle(_highlightBorderPen, 1, 0, e.Item.Width - 2, e.Item.Height - 1);
            }
        }

        private bool _disposed = false;
        void IDisposable.Dispose()
        {
            if (!_disposed)
            {
                _backgroundBrush.Dispose();
                _marginBrush.Dispose();
                _highlightBrush.Dispose();
                _highlightBorderPen.Dispose();

                _disposed = true;
            }
        }

    }

    #endregion

    #region CustomMenuColors

    internal class CustomMenuColors : ProfessionalColorTable
    {
        public override Color SeparatorDark
        {
            get { return UIColors.MenuSeparatorDarkColor; }
        }

        public override Color SeparatorLight
        {
            get { return UIColors.MenuSeparatorLightColor; }
        }

        public override Color MenuBorder
        {
            get { return UIColors.MenuBorderColor; }
        }
    }

    #endregion

    // ******************************** Global Button Flash

    #region Global Button Flash

    // Synchronizing flashing buttons application wide

    internal static class ButtonFlash
    {
        private struct ButtonInfo
        {
            internal Button Button;
            internal Color  ForeColor;
            internal Color  FlashColor;
        }

        private struct PanelInfo
        {
            internal Panel Panel;
            internal Color ForeColor;
            internal Color FlashColor;
        }

        static private List<ButtonInfo> _buttonList;
        static private List<PanelInfo>  _panelList;
        static private Timer            _timer;
        static private bool             _flash;

        static ButtonFlash()
        {
            _timer = new Timer {Interval = 600};
            _timer.Tick += TimerTick;

            _buttonList = new List<ButtonInfo>();
            _panelList  = new List<PanelInfo>();
        }

        static private void TimerTick(object sender, EventArgs e)
        {
            _flash = !_flash;
            if (_flash)
            {
                foreach (ButtonInfo buttonInfo in _buttonList) buttonInfo.Button.ForeColor = buttonInfo.FlashColor;
                foreach (PanelInfo panelInfo in _panelList) panelInfo.Panel.ForeColor = panelInfo.FlashColor;
            }
            else
            {
                foreach (ButtonInfo buttonInfo in _buttonList) buttonInfo.Button.ForeColor = buttonInfo.ForeColor;
                foreach (PanelInfo panelInfo in _panelList) panelInfo.Panel.ForeColor = panelInfo.ForeColor;
            }
        }

        // add a button to the flashing buttons list
        static internal void Add(Button button, Color foreColor, Color flashColor)
        {
            foreach (ButtonInfo item in _buttonList) if (item.Button == button) return;
            _buttonList.Add(new ButtonInfo { Button = button, ForeColor = foreColor, FlashColor = flashColor });

            if (!_timer.Enabled)
            {
                _flash = true;
                _timer.Start();
            }
            button.ForeColor = flashColor;
        }

        // add a panel to the flashing panels list (for use with 'LightPanels')
        static internal void Add(Panel panel, Color foreColor, Color flashColor)
        {
            foreach (PanelInfo item in _panelList) if (item.Panel == panel) return;
            _panelList.Add(new PanelInfo { Panel = panel, ForeColor = foreColor, FlashColor = flashColor });

            if (!_timer.Enabled)
            {
                _flash = true;
                _timer.Start();
            }
            panel.ForeColor = flashColor;
        }

        // remove a button from the flashing buttons list
        static internal void Remove(Button button)
        {
            foreach (ButtonInfo item in _buttonList)
            {
                if (item.Button == button)
                {
                    button.ForeColor = item.ForeColor;
                    _buttonList.Remove(item);
                    if (_buttonList.Count == 0 && _panelList.Count == 0) _timer.Stop();
                    break;
                }
            }
        }

        // remove a panel from the flashing panels list
        static internal void Remove(Panel panel)
        {
            foreach (PanelInfo item in _panelList)
            {
                if (item.Panel == panel)
                {
                    panel.ForeColor = item.ForeColor;
                    _panelList.Remove(item);
                    if (_buttonList.Count == 0 && _panelList.Count == 0) _timer.Stop();
                    break;
                }
            }
        }
    }

    #endregion
}
