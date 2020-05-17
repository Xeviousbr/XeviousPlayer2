#region Usings

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

#endregion

namespace FolderView
{
    // *********************************************

    // A custom drawn slider can be created using the standard .NET TrackBar control if you draw the trackbar
    // items (track, thumb) yourself (ControlStyles.UserPaint) inside the same 'space' (size and location) as
    // the original items (as shown below).

    // Actually, you can draw whatever you like as long as you keep the thumb inside it's original size and location
    // (see below; because of the trackbar's redraw with 'smart clipping'). And even this can be (partially) ignored
    // if you use CreateGraphics() (instead of e.Grahics - as with CustomSlider2) to draw.

    // The track (channel) is always at a fixed position and size (given the orientation, width and tickstyle);
    // the thumb (slider) size is fixed too and it's position can be found with 'SendMessage' (please see below - dll import).
    // The height of the entire control (horizontal bar) has to be at least 26 pixels to avoid 'drawing problems'.

    // --------

    // The size and location of the trackbar items can be found with 'SendMessage' (TBM_GETTHUMBRECT and TBM_GETCHANNELRECT):
    // Original size and location:

    // Horizontal TrackBar with TickStyle None or BottomRight:
    // Thumb: X=(variable), Y=2, Width=11, Height=19
    // Track: X=8, Y=8, Width=ControlWidth-16, Height=4

    // Horizontal TrackBar with TickStyle TopLeft:
    // Thumb: X=(variable), Y=10, Width=11, Height=19
    // Track: X=8, Y=18, Width=ControlWidth-16, Height=4

    // Horizontal TrackBar with TickStyle Both:
    // Thumb: X=(variable), Y=10, Width=11, Height=22
    // Track: X=8, Y=19, Width=ControlWidth-16, Height=4

    // --------

    // Vertical TrackBar with TickStyle None or BottomRight:
    // Thumb: X=2, Y=(variable), Width=19, Height=11
    // Track: X=8, Y=8, Width=4, Height=ControlHeight-16

    // Vertical TrackBar with TickStyle TopLeft:
    // Thumb: X=10, Y=(variable), Width=19, Height=11
    // Track: X=18, Y=8, Width=4, Height=ControlHeight-16

    // Vertical TrackBar with TickStyle Both:
    // Thumb: X=10, Y=(variable), Width=22, Height=11
    // Track: X=19, Y=8, Width=4, Height=ControlHeight-16

    // --------

    // Instead of drawing all the items yourself, you can also make use of .Net controls or the TrackBarRenderer Class:
    // http://msdn.microsoft.com/en-us/library/6bzct57b%28v=vs.90%29.aspx

    // --------

    // There are a few things missing from these examples (like the 'state' (appearance) of the thumb, disabled control colors
    // and vertical orientation) but these can easily be added. And you could add support for the designer too if you like.
    // But if you're using a 'fixed type' trackbar (like the ones used here) there's no need for that.

    // *********************************************
    
    // Slider used with ItemView
    class CustomSlider1 : TrackBar
    {
        // ********************************************* Fields

        #region Fields

        Point                   _trackStartPoint; // using a horizontal line as track
        Point                   _trackEndPoint;
        SafeNativeMethods.RECT  _thumbRECT;
        Rectangle               _thumbRect;
        SolidBrush              _brush;

        #endregion

        // ********************************************* Main

        #region Main

        public CustomSlider1()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
            AutoSize = false;

            _trackStartPoint = new Point(8, 8);
            _trackEndPoint = new Point(Width - 8, 8);

            _thumbRECT = new SafeNativeMethods.RECT();
            _thumbRect = new Rectangle(0, 6, 11, 5);

            _brush = new SolidBrush(Color.FromArgb(179, 173, 146));
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            _trackEndPoint.X = Width - 8;
            base.OnSizeChanged(e);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _brush.Dispose();
            }
            base.Dispose(disposing);
        }

        #endregion

        // ********************************************* OnPaint

        #region OnPaint

        protected override void OnPaint(PaintEventArgs e)
        {
            // draw track
            e.Graphics.DrawLine(Pens.DimGray, _trackStartPoint, _trackEndPoint);

            // draw thumb
            SafeNativeMethods.SendMessage(Handle, SafeNativeMethods.TBM_GETTHUMBRECT, IntPtr.Zero, ref _thumbRECT);
            _thumbRect.X = _thumbRECT.left;
            e.Graphics.FillEllipse(_brush, _thumbRect);
        }

        #endregion
    }

    // Slider used with DetailView
    class CustomSlider2 : TrackBar
    {
        // ********************************************* Fields

        #region Fields

        Rectangle               _trackRect;
        Rectangle               _tempRect; // split track area before and after thumb

        SafeNativeMethods.RECT  _thumbRECT;
        Rectangle               _thumbBorderRect;
        Rectangle               _thumbFillRect; // to reduce flicker
        Rectangle               _thumbEraseRect; // to reduce flicker - border right/bottom line outside rect

        Region                  _eraseRegion; // to reduce flicker
        SolidBrush              _eraseBrush;

        LinearGradientBrush     _thumbBrush;
        LinearGradientBrush     _trackBrush1;
        LinearGradientBrush     _trackBrush2;

        #endregion

        // ********************************************* Main

        #region Main

        public CustomSlider2()
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
            _trackBrush1 = new LinearGradientBrush(_trackRect, Color.FromArgb(96, 96, 96), Color.Black, LinearGradientMode.Vertical);
            _trackBrush1.SetBlendTriangularShape(0.5F);
            _trackBrush2 = new LinearGradientBrush(_trackRect, Color.FromArgb(48, 48, 48), Color.Black, LinearGradientMode.Vertical);
            _trackBrush2.SetBlendTriangularShape(0.5F);

            // thumb
            _thumbRECT = new SafeNativeMethods.RECT();
            _thumbBorderRect = new Rectangle(0, 2, 9, 14);
            _thumbEraseRect = new Rectangle(0, 2, 10, 15);
            _thumbFillRect = new Rectangle(0, 3, 8, 13);
            _thumbBrush = new LinearGradientBrush(_thumbBorderRect, Color.FromArgb(132, 132, 132), Color.Black, LinearGradientMode.Vertical);
            _thumbBrush.SetBlendTriangularShape(0.5F);
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

        protected override void OnSizeChanged(EventArgs e)
        {
            _trackRect.Width = Width - 16;
            base.OnSizeChanged(e);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _eraseRegion.Dispose();
                _eraseBrush.Dispose();

                _thumbBrush.Dispose();
                _trackBrush1.Dispose();
                _trackBrush2.Dispose();
            }

            base.Dispose(disposing);
        }

        #endregion

        // ********************************************* OnPaint

        #region OnPaint

        protected override void OnPaint(PaintEventArgs e)
        {
            // using 'new' graphics (instead of clipped e.Graphics) to avoid problems with 'smart clipping' (when fast moving
            // the thumb to another position) because the track's appearance is not everywhere the same (before and after the thumb).
            Graphics g = CreateGraphics();

            // get the thumb position first - also used with erase and draw track
            SafeNativeMethods.SendMessage(Handle, SafeNativeMethods.TBM_GETTHUMBRECT, IntPtr.Zero, ref _thumbRECT);
            _thumbBorderRect.X = _thumbEraseRect.X = _thumbRECT.left;
            _thumbFillRect.X = _thumbRECT.left + 1;

            // erase background
            _eraseRegion.MakeEmpty();
            _eraseRegion.Union(ClientRectangle);
            _eraseRegion.Exclude(_trackRect);
            _eraseRegion.Exclude(_thumbEraseRect);
            g.FillRegion(_eraseBrush, _eraseRegion);
            // with this trackbar (all items within original bounds) we could have used:
            //e.Graphics.FillRectangle(eraseBrush, this.ClientRectangle);

            // draw track - different fill color before and after thumb position
            // before thumb
            _tempRect.X = _trackRect.X;
            _tempRect.Width = _thumbBorderRect.X - _trackRect.X;
            g.FillRectangle(_trackBrush1, _tempRect);
            // after thumb
            _tempRect.X = _thumbBorderRect.X + _thumbBorderRect.Width;
            _tempRect.Width = _trackRect.Width - _thumbBorderRect.X;
            g.FillRectangle(_trackBrush2, _tempRect);

            // draw thumb
            g.DrawRectangle(Pens.DimGray, _thumbBorderRect);
            g.FillRectangle(_thumbBrush, _thumbFillRect);

            g.Dispose();
        }

        #endregion
    }

    // *********************************************

    #region Custom Control: DropDownButton

    internal class DropDownButton : CheckBox
    {
        // A button-type control with a little arrow to select an option from a dropdown menu.

        // ************************************ Fields

        #region Fields

        private ContextMenuStrip _theMenu;
        private bool _hasMenu;
        private bool _menuInitialized;
        private bool _showArrow = true;

        private Point[] _arrowPoints;
        private Brush _enabledColor;
        private Brush _disabledColor;

        private LinearGradientBrush _normalBrush1;
        private LinearGradientBrush _normalBrush2;
        private LinearGradientBrush _hotBrush1;
        private LinearGradientBrush _hotBrush2;
        private LinearGradientBrush _pressedBrush1;
        private LinearGradientBrush _pressedBrush2;

        private Rectangle _borderRect;
        private Rectangle _buttonRect1;
        private Rectangle _buttonRect2;

        private Pen _borderPen;
        private bool _hotButton;
        private bool _pressedButton;

        private bool _disposed;

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
                    _theMenu.Closed += TheMenu_Closed;
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
                if (_menuInitialized) _theMenu.Closed -= TheMenu_Closed;
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

        private Rectangle _borderRect;
        private Rectangle _buttonRect1;
        private Rectangle _buttonRect2;

        private Pen _borderPen;
        private bool _hotButton;
        private bool _pressedButton;
        private bool _notifyDefault;
        private bool _notifyDefaultDraw;

        private TextFormatFlags _textFlags;

        private bool _disposed;

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


    #region Global Color Scheme

    internal static class UIColors
    {
        // Buttons, DropDownButtons
        static internal Color BorderColor = Color.FromArgb(64, 64, 64); // 100
        static internal Pen FocusPen = new Pen(Color.FromArgb(179, 173,146));

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
    }

    #endregion

}
