#region Usings

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#endregion

namespace AVPlayerExample
{
    // PVS.AVPlayer Example Application - Custom Controls

    // These custom controls are 'regular' controls with one or more properties added or changed
    // and are made for and used only with this example application's user interface to reduce
    // manual setting of properties with the designer and/or (re-) writing code for handling them.

    // Note: these user controls are far from complete for general purposes, but they can be easily
    // modified to be so. The idea here is that they'll be short and fast.

    // ******************************** Global Color Scheme

    #region Global Color Scheme

    static internal class UIColors
    {
        // ... under construction ...

        // Buttons, DropDownButtons
        static internal Color BorderColor = Color.FromArgb(64, 64, 64); // 100
        //static internal Pen FocusPen = new Pen(Color.DarkGoldenrod);
        static internal Pen FocusPen = new Pen(Color.FromArgb(189, 159, 87));

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

        //static internal Color MenuTextEnabledColor = Color.Goldenrod;
        static internal Color MenuTextEnabledColor = Color.FromArgb(189, 159, 87);
        static internal Color MenuTextDisabledColor = Color.DimGray;
    }

    #endregion

    // ******************************** Custom Controls

    #region Custom Control: HeadLabel

    sealed class HeadLabel : Label
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

    sealed class CustomPanel : Panel
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

    #region Custom Control: SliderPanel

    class SliderPanel : Panel
    {
        // Removed.
    }

    #endregion

    #region Custom Control: DropDownButton

    class DropDownButton : CheckBox
    {
        // A button-type control with a little arrow to select an option from a dropdown menu.

        // ************************************ Fields

        #region Fields

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

            _borderPen = new Pen(UIColors.BorderColor);

            _arrowPoints = new Point[3];
            SetButtonRectangle();

            base.AutoSize = false;
            Size = new Size(123, 23);
            base.Appearance = Appearance.Button;
            TextAlign = ContentAlignment.MiddleLeft;

            _enabledColor = new SolidBrush(Color.FromArgb(189, 159, 87)); // if changed back - remove dispose
            _disabledColor = new SolidBrush(Color.FromArgb(175, 175, 175));
        }

        protected override void OnCheckedChanged(EventArgs e)
        {
            if (_hasMenu && base.Checked)
            {
                if (!_menuInitialized)
                {
                    _theMenu.AutoSize = false;
                    _theMenu.Height = 0;
                    _theMenu.Show(0, 0);
                    _theMenu.Close();
                    _theMenu.AutoSize = true;

                    _menuInitialized = true;
                    _theMenu.Closed += theMenu_Closed;
                }
                _theMenu.Show(this, 0, Height);
            }
            // Windows Bug? The first time the contextmenu is not shown at the specified location
            // so the first time dropdown we do this... (have to find another solution for this(?))
        }

        protected override void OnSizeChanged(EventArgs e)
        {
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
            set { _showArrow = value; }
        }

        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
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
                _disposed = true;
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
                if (_menuInitialized) _theMenu.Closed -= theMenu_Closed;
                _theMenu = null;
                _hasMenu = false;
                _menuInitialized = false;
            }

            if (menu != null)
            {
                _theMenu = menu;
                _hasMenu = true;
            }
        }

        void theMenu_Closed(object sender, ToolStripDropDownClosedEventArgs e)
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
            TextRenderer.DrawText(pevent.Graphics, Text, Font, ClientRectangle, ForeColor, Color.Transparent, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

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

    class LightPanel : Panel
    {
        // A little checkbox type indicator (used with some buttons to indicate the active state)

        private bool        _lightIsOn;
        private SolidBrush  _brush;

        public LightPanel()
        {
            base.BackColor = Color.FromArgb(18, 18, 18);
            base.ForeColor = Color.Lime;
            //base.BorderStyle = BorderStyle.FixedSingle;

            _brush = new SolidBrush(Color.FromArgb(18, 18, 18));
        }

        protected override Size DefaultSize
        {
            get { return new Size(4, 6); }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(_brush, ClientRectangle);
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
                    _lightIsOn = value;
                    _brush.Color = _lightIsOn ? base.ForeColor : base.BackColor;
                    Invalidate();
                }
            }
        }

        public override Color ForeColor
        {
            get { return base.ForeColor; }
            set
            {
                if (_lightIsOn) _brush.Color = value;
                base.ForeColor = value;
            }
        }

        public override Color BackColor
        {
            get { return base.BackColor; }
            set
            {
                if (!_lightIsOn) _brush.Color = value;
                base.BackColor = value;
            }
        }
    }

    #endregion

    #region Custom Control: SmoothLabel

    public class SmoothLabel : Label
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

    class ImageBox : PictureBox
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

    sealed class CustomButton : Button
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
    sealed class CustomSlider : TrackBar
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
            if (_hotThumb)
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

    sealed class CustomSlider2 : TrackBar
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
            if (_hotThumb)
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

    // ******************************** DLL Import - SafeNativeMethods

    #region DLL Import

    [System.Security.SuppressUnmanagedCodeSecurity]
    internal static class SafeNativeMethods
    {
        // ********************************************* DLL Import SendMessage

        #region DLL Import SendMessage

        // DLL Import for CustomSliders

        internal const int TBM_GETTHUMBRECT = 0x419;
        //private const int TBM_GETCHANNELRECT = 0x41A;

        [StructLayout(LayoutKind.Sequential)]
        internal struct RECT { public int left, top, right, bottom; }

        [DllImport("user32.dll")]
        internal static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, ref RECT lp);

        #endregion

        // ********************************************* DLL Import ShellExecuteEx - For File Properties Info Dialog

        #region DLL Import ShellExecuteEx

        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        static extern internal bool ShellExecuteEx(ref SHELLEXECUTEINFO lpExecInfo);

        [StructLayout(LayoutKind.Sequential)]
        internal struct SHELLEXECUTEINFO
        {
            public int cbSize;
            public uint fMask;
            public IntPtr hwnd;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpVerb;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpFile;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpParameters;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpDirectory;
            public int nShow;
            public IntPtr hInstApp;
            public IntPtr lpIDList;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpClass;
            public IntPtr hkeyClass;
            public uint dwHotKey;
            public IntPtr hIcon;
            public IntPtr hProcess;
        }

        internal const int SW_SHOW = 5;
        internal const uint SEE_MASK_INVOKEIDLIST = 12;

        #endregion

        // ********************************************* DLL Import BitBlt

        #region DLL Import BitBlt

        [DllImport("gdi32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static internal extern bool BitBlt(IntPtr hdc, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, uint dwRop);

        [DllImport("gdi32.dll")]
        static internal extern bool StretchBlt(IntPtr hdcDest, int nXOriginDest, int nYOriginDest, int nWidthDest, int nHeightDest,
            IntPtr hdcSrc, int nXOriginSrc, int nYOriginSrc, int nWidthSrc, int nHeightSrc, uint dwRop);

        [DllImport("gdi32.dll")]
        static internal extern int SetStretchBltMode(IntPtr hdc, int iStretchMode);

        #endregion

        // ********************************************* DLL Import AddFontMemResourceEx

        #region AddFontMemResourceEx

        [DllImport("gdi32.dll")]
        static internal extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);

        #endregion
    }

    #endregion

    // ******************************** Custom Color Menus

    #region CustomMenuRenderer

    class CustomMenuRenderer : ToolStripProfessionalRenderer, IDisposable
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
            _checkMarkRect = new Rectangle(12, 8, 3, 6);
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

    class CustomMenuColors : ProfessionalColorTable
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

    static internal class ButtonFlash
    {
        private struct ButtonInfo
        {
            internal Button Button;
            internal Color  ForeColor;
            internal Color  FlashColor;
        }

        static private List<ButtonInfo> _buttonList;
        static private Timer            _timer;
        static private bool             _flash;

        static ButtonFlash()
        {
            _timer = new Timer {Interval = 600};
            _timer.Tick += TimerTick;

            _buttonList = new List<ButtonInfo>(4);
        }

        static private void TimerTick(object sender, EventArgs e)
        {
            _flash = !_flash;
            if (_flash) foreach (ButtonInfo buttonInfo in _buttonList) buttonInfo.Button.ForeColor = buttonInfo.FlashColor;
            else foreach (ButtonInfo buttonInfo in _buttonList) buttonInfo.Button.ForeColor = buttonInfo.ForeColor;
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

        // remove a button from the flashing buttons list
        static internal void Remove(Button button)
        {
            foreach (ButtonInfo item in _buttonList)
            {
                if (item.Button == button)
                {
                    button.ForeColor = item.ForeColor;
                    _buttonList.Remove(item);
                    if (_buttonList.Count == 0) _timer.Stop();
                    break;
                }
            }
        }
    }

    #endregion
}
