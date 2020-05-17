#region Usings

using PVS.MediaPlayer;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

#endregion

namespace PVSPlayerExample
{
    public sealed partial class ScribbleOverlay : Form, IOverlay
    {
        /*
        
        PVS.MediaPlayer Display Overlay - Example 'Scribble'
        Simple basic drawing with the mouse on a transparent surface.

        The backcolor of the form determines whether the form is transparant for mouse clicks or not.
        
        */

        // ******************************** Fields

        #region Fields

        enum DrawMode
        {
            Scribble,
            Line, // also arrow
            Circle,
            Ellipse,
            Rectangle
        }

        private MainWindow  _baseForm;
        private Player      _basePlayer;
        private OverlayMode _baseOverlayMode;

        private Graphics    _formGraphics;
        private Graphics    _bufferGraphics;
        private Pen         _pen1;
        private bool        _isDrawing;
        private Point       _lastLocation;
        private Panel       _selectedColor;
        private ColorDialog _colorDialog1;

        // drawing
        private DrawMode    _drawMode;
        private bool        _drawCancelled;
        private Rectangle   _shapeRect;
        private Bitmap      _shapeBuffer;
        private Graphics    _shapeGraphics;

        // preserve and scale drawing
        private bool        _autoScale = true;
        private bool        _scaling;
        private Bitmap      _buffer;

        // Mouse Events
        private bool        _hasMouseEvents;
        private bool        _menuActive;

        private bool        _disposed;

        #endregion

        // ******************************** Initialize & Form event handling

        #region Initialize & Form event handling

        // Main
        public ScribbleOverlay(MainWindow baseForm, Player thePlayer)
        {
            InitializeComponent();

            _baseForm   = baseForm;
            _basePlayer = thePlayer;

            // Pass on drag and drop to main form (handled in source file: DragDrop.cs):
            if (_baseForm != null)
            {
                AllowDrop = true;
                DragDrop += _baseForm.Form1_DragDrop;
            }

            _buffer         = new Bitmap(ClientRectangle.Width, ClientRectangle.Height);
            _selectedColor  = panel1;

            _pen1           = new Pen(_selectedColor.BackColor, 2);
            _drawMode       = DrawMode.Scribble;
            _pen1.StartCap  = LineCap.Round;
            _pen1.EndCap    = LineCap.Round;

            _colorDialog1   = new ColorDialog();

            KeyPreview      = true;
            KeyDown         += ScribbleOverlay_KeyDown;
        }

        private void ScribbleOverlay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt || e.Control || e.Shift)
            {
            }
            else
            {
                e.Handled = true;
                switch (e.KeyCode)
                {
                    case Keys.D1:
                        SetColor(panel1);
                        break;

                    case Keys.D2:
                        SetColor(panel2);
                        break;

                    case Keys.D3:
                        SetColor(panel3);
                        break;

                    case Keys.D4:
                        SetColor(panel4);
                        break;

                    case Keys.D5:
                        SetColor(panel5);
                        break;

                    case Keys.D6:
                        SetColor(panel6);
                        break;

                    case Keys.S:
                        scribbleMenuItem.PerformClick();
                        break;

                    case Keys.L:
                        drawLineMenuItem.PerformClick();
                        break;

                    case Keys.A:
                        drawArrowMenuItem.PerformClick();
                        break;

                    case Keys.C:
                        drawCircleMenuItem.PerformClick();
                        break;

                    case Keys.E:
                        drawEllipseMenuItem.PerformClick();
                        break;

                    case Keys.R:
                        drawRectangleMenuItem.PerformClick();
                        break;

                    case Keys.Oemplus:
                        switch (_pen1.Width)
                        {
                            case 1:
                                pixels2_MenuItem.PerformClick();
                                break;
                            case 2:
                                pixels4_MenuItem.PerformClick();
                                break;
                            case 4:
                                pixels8_MenuItem.PerformClick();
                                break;
                            case 8:
                                pixels16_MenuItem.PerformClick();
                                break;
                            case 16:
                                pixels24_MenuItem.PerformClick();
                                break;
                            case 24:
                                pixels32_MenuItem.PerformClick();
                                break;
                            case 32:
                                pixels40_MenuItem.PerformClick();
                                break;
                            case 40:
                                pixels48_MenuItem.PerformClick();
                                break;
                            case 48:
                                pixels56_MenuItem.PerformClick();
                                break;
                            case 56:
                                pixels64_MenuItem.PerformClick();
                                break;
                            default:
                                e.Handled = false;
                                break;
                        }
                        break;

                    case Keys.OemMinus:
                        switch (_pen1.Width)
                        {
                            case 2:
                                pixel1_MenuItem.PerformClick();
                                break;
                            case 4:
                                pixels2_MenuItem.PerformClick();
                                break;
                            case 8:
                                pixels4_MenuItem.PerformClick();
                                break;
                            case 16:
                                pixels8_MenuItem.PerformClick();
                                break;
                            case 24:
                                pixels16_MenuItem.PerformClick();
                                break;
                            case 32:
                                pixels24_MenuItem.PerformClick();
                                break;
                            case 40:
                                pixels32_MenuItem.PerformClick();
                                break;
                            case 48:
                                pixels40_MenuItem.PerformClick();
                                break;
                            case 56:
                                pixels48_MenuItem.PerformClick();
                                break;
                            case 64:
                                pixels48_MenuItem.PerformClick();
                                break;
                            default:
                                e.Handled = false;
                                break;
                        }
                        break;

                    case Keys.Escape:
                        if (_isDrawing)
                        {
                            _drawCancelled = true;
                            StopDrawing();
                        }
                        else e.Handled = false;
                        break;

                    default:
                        e.Handled = false;
                        break;
                }
                if (e.Handled && _isDrawing) MoveMouse(_lastLocation);
            }
        }

        protected override bool ShowWithoutActivation
        {
            get { return true; }
        }

        // Don't activate form with mouse click
        protected override void WndProc(ref Message m)
        {
            const int WM_MOUSEACTIVATE  = 0x0021;
            const int MA_NOACTIVATE     = 0x0003;

            if (m.Msg == WM_MOUSEACTIVATE) m.Result = (IntPtr)MA_NOACTIVATE;
            else base.WndProc(ref m);
        }

        private void SetMouseEvents()
        {
            if (!_hasMouseEvents)
            {
                MouseDown += ScribbleOverlay_MouseDown;
                MouseMove += ScribbleOverlay_MouseMove;
                MouseUp += ScribbleOverlay_MouseUp;

                _hasMouseEvents = true;
            }
        }

        private void RemoveMouseEvents()
        {
            if (_hasMouseEvents)
            {
                MouseDown -= ScribbleOverlay_MouseDown;
                MouseMove -= ScribbleOverlay_MouseMove;
                MouseUp -= ScribbleOverlay_MouseUp;

                _hasMouseEvents = false;
            }
        }

        // Called when the form is shown or hidden
        private void ScribbleOverlay_VisibleChanged(object sender, EventArgs e)
        {
            // Turn on/off mouse events with Form visibility (Show/Hide)
            if (Visible)
            {
                SetMouseEvents();

                _baseOverlayMode = _basePlayer.Overlay.Mode;
                if (_baseForm == null) _basePlayer.Overlay.Mode = OverlayMode.Display;
                else _baseForm.SetOverlayDisplayMode();

                //_basePlayer.Overlay.Blend = OverlayBlend.Transparent;
            }
            else
            {
                RemoveMouseEvents();

                if (_baseOverlayMode == OverlayMode.Video)
                {
                    if (_baseForm == null) _basePlayer.Overlay.Mode = OverlayMode.Video;
                    else _baseForm.SetOverlayVideoMode();
                }

                //_basePlayer.Overlay.Blend = OverlayBlend.None;
            }
            }

        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                _disposed = true;
                if (disposing)
                {
                    if (_hasMouseEvents) RemoveMouseEvents();

                    _pen1.Dispose(); _pen1 = null;
                    _colorDialog1.Dispose(); _colorDialog1 = null;

                    _buffer.Dispose(); _buffer = null;
                    if (_shapeBuffer != null) { _shapeBuffer.Dispose(); _shapeBuffer = null; }

                    if (_baseForm != null)
                    {
                        DragDrop -= _baseForm.Form1_DragDrop;
                        _baseForm = null;
                    }
                    _basePlayer = null;

                    if (components != null) components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #endregion

        // ******************************** IOverlay Control

        #region IOverlay Control

        // The visibility of the menu is controlled by the user from the main application (in this example application)
        public bool MenuEnabled
        {
            get { return scribblePanel.Visible; }
            set { scribblePanel.Visible = value; Application.DoEvents(); }
        }

        public bool HasMenu
        {
            get { return true; }
        }

        public void MediaStopped()
        {
            // not used with this overlay
        }

        #endregion

        // ******************************** Do the drawing

        #region Drawing

        private void ScribbleOverlay_MouseDown(object sender, MouseEventArgs e)
        {
            if (!_menuActive && MouseButtons == MouseButtons.Left)
            {
                _lastLocation = e.Location;
                _formGraphics = CreateGraphics();

                _bufferGraphics = Graphics.FromImage(_buffer);

                _shapeRect = new Rectangle(_lastLocation, new Size(0, 0));
                _shapeBuffer = new Bitmap(ClientRectangle.Width, ClientRectangle.Height);
                _shapeGraphics = Graphics.FromImage(_shapeBuffer);

                Cursor = Cursors.Hand;
                _isDrawing = true;
            }
        }

        private void ScribbleOverlay_MouseMove(object sender, MouseEventArgs e)
        {
            MoveMouse(e.Location);
        }

        private void MoveMouse(Point location)
        {
            if (_isDrawing)
            {
                if (_drawMode == DrawMode.Scribble)
                {
                    _formGraphics.DrawLine(_pen1, _lastLocation, location);
                    _bufferGraphics.DrawLine(_pen1, _lastLocation, location);
                }
                else
                {
                    _shapeGraphics.Clear(BackColor);
                    _shapeGraphics.DrawImage(_buffer, 0, 0);

                    _shapeRect.Width  = location.X - _shapeRect.X;
                    _shapeRect.Height = location.Y - _shapeRect.Y;

                    if (_drawMode == DrawMode.Line)
                    {
                        _shapeGraphics.DrawLine(_pen1, _shapeRect.X, _shapeRect.Y, _shapeRect.X + _shapeRect.Width, _shapeRect.Y + _shapeRect.Height);
                    }
                    else if (_drawMode == DrawMode.Circle)
                    {
                        Rectangle tempRect  = _shapeRect;
                        int radius          = Math.Abs(tempRect.Width) > Math.Abs(tempRect.Height) ? tempRect.Width : tempRect.Height;
                        tempRect.X         -= radius;
                        tempRect.Width      = radius * 2;
                        tempRect.Y         -= radius;
                        tempRect.Height     = radius * 2;

                        if (_selectedColor == panel7)
                        {
                            SolidBrush b = new SolidBrush(panel7.BackColor);
                            _shapeGraphics.FillEllipse(b, tempRect);
                            b.Dispose();
                        }
                        else
                        {
                            _shapeGraphics.DrawEllipse(_pen1, tempRect);
                        }
                    }
                    else if (_drawMode == DrawMode.Ellipse)
                    {
                        if ((ModifierKeys & Keys.Shift) == Keys.Shift)
                        {
                            int absWidth  = _shapeRect.Width >= 0  ? _shapeRect.Width : -_shapeRect.Width;
                            int absHeight = _shapeRect.Height >= 0 ? _shapeRect.Height : -_shapeRect.Height;

                            if (absWidth < absHeight)
                            {
                                if (_shapeRect.Width > 0) _shapeRect.Width = absHeight;
                                else _shapeRect.Width = -absHeight;
                            }
                            else
                            {
                                if (_shapeRect.Height > 0) _shapeRect.Height = absWidth;
                                else _shapeRect.Height = -absWidth;
                            }
                        }

                        if (_selectedColor == panel7)
                        {
                            SolidBrush b = new SolidBrush(panel7.BackColor);
                            _shapeGraphics.FillEllipse(b, _shapeRect);
                            b.Dispose();
                        }
                        else
                        {
                            _shapeGraphics.DrawEllipse(_pen1, _shapeRect);
                        }
                    }
                    else // DrawMode.Rectangle
                    {
                        Rectangle tempRect = _shapeRect;
                        if (tempRect.Width < 0)
                        {
                            tempRect.Width  = -tempRect.Width;
                            tempRect.X     -= tempRect.Width;
                        }
                        if (tempRect.Height < 0)
                        {
                            tempRect.Height = -tempRect.Height;
                            tempRect.Y     -= tempRect.Height;
                        }

                        if (_selectedColor == panel7)
                        {
                            SolidBrush b = new SolidBrush(panel7.BackColor);
                            _shapeGraphics.FillRectangle(b, tempRect);
                            b.Dispose();
                        }
                        else _shapeGraphics.DrawRectangle(_pen1, tempRect);
                    }
                    _formGraphics.DrawImage(_shapeBuffer, 0, 0);
                }
                _lastLocation = location;
            }
        }

        private void ScribbleOverlay_MouseUp(object sender, MouseEventArgs e)
        {
            StopDrawing();
        }

        private void StopDrawing()
        {
            if (_isDrawing)
            {
                _isDrawing = false;

                if (_drawMode != DrawMode.Scribble)
                {
                    if (!_drawCancelled) _bufferGraphics.DrawImage(_shapeBuffer, 0, 0);
                    else Invalidate();
                }

                _shapeGraphics.Dispose();   _shapeGraphics  = null;
                _shapeBuffer.Dispose();     _shapeBuffer    = null;
                _bufferGraphics.Dispose();  _bufferGraphics = null;
                _formGraphics.Dispose();    _formGraphics   = null;

                Cursor = Cursors.Default;
            }
            _drawCancelled = false;
        }

        private void ScribbleOverlay_Paint(object sender, PaintEventArgs e)
        {
            if (!_scaling) e.Graphics.DrawImage(_buffer, 0, 0);
        }

        private void ScribbleOverlay_SizeChanged(object sender, EventArgs e)
        {
            if (_autoScale)
            {
                _scaling = true;
                Bitmap b = new Bitmap(ClientRectangle.Width, ClientRectangle.Height);
                Graphics g = Graphics.FromImage(b);
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.InterpolationMode = InterpolationMode.NearestNeighbor;
                g.SmoothingMode = SmoothingMode.None;
                g.DrawImage(_buffer, 0, 0, b.Width, b.Height);
                _buffer.Dispose();
                g.Dispose();
                _buffer = b;
                _scaling = false;
                Refresh();
            }
        }

        #endregion

        // ******************************** Clear Button and Color Panels

        #region Clear Button and Color Panels

        // Clear
        private void ClearButton_Click(object sender, EventArgs e)
        {
            Bitmap b = new Bitmap(ClientRectangle.Width, ClientRectangle.Height);
            _buffer.Dispose();
            _buffer = b;

            Refresh();
        }

        // ******************************** Set drawing line color

        // Handles mousedown event for all color panels
        // panel7 is an 'eraser' (same color as Form backcolor)
        private void Panel_MouseDown(object sender, MouseEventArgs e)
        {
            _selectedColor.BorderStyle = BorderStyle.FixedSingle;
            _selectedColor = (Panel)sender;
            _selectedColor.BorderStyle = BorderStyle.Fixed3D;

            if (_selectedColor != panel7 && e.Button == MouseButtons.Right)
            {
                _colorDialog1.Color = _selectedColor.BackColor;
                if (_colorDialog1.ShowDialog(this) == DialogResult.OK)
                {
                    _selectedColor.BackColor = _colorDialog1.Color;
                }
            }

            _pen1.Color = _selectedColor.BackColor;
        }

        // set from shortcut keys
        private void SetColor(Panel colorPanel)
        {
            _selectedColor.BorderStyle = BorderStyle.FixedSingle;
            _selectedColor = colorPanel;
            _selectedColor.BorderStyle = BorderStyle.Fixed3D;
            _pen1.Color = _selectedColor.BackColor;
        }

        #endregion

        // ******************************** Options Menu

        #region Options Menu Opening / Closing

        // When menu openend - can't change color of 'eraser'
        private void OptionsMenu_Opening(object sender, CancelEventArgs e)
        {
            _menuActive = true;
            RemoveMouseEvents();
            lineColorMenuItem.Enabled = _selectedColor != panel7;
        }

        private void OptionsMenu_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            _menuActive = false;
            SetMouseEvents();
        }

        #endregion

        // **************** Options Menu - Line Thickness

        #region Line Thickness

        // Check/Uncheck items in the Line Thickness menu
        private void SetLineThicknessMenu(ToolStripMenuItem theItem)
        {
            foreach (ToolStripMenuItem item in lineThicknessMenuItem.DropDown.Items)
            {
                item.Checked = item == theItem;
            }
        }

        // Line Thickness 1 pixel
        private void Pixel1_MenuItem_Click(object sender, EventArgs e)
        {
            _pen1.Width = 1;
            SetLineThicknessMenu(pixel1_MenuItem);
        }

        // Line Thickness 2 pixels
        private void Pixels2_MenuItem_Click(object sender, EventArgs e)
        {
            _pen1.Width = 2;
            SetLineThicknessMenu(pixels2_MenuItem);
        }

        // Line Thickness 4 pixels
        private void Pixels4_MenuItem_Click(object sender, EventArgs e)
        {
            _pen1.Width = 4;
            SetLineThicknessMenu(pixels4_MenuItem);
        }

        // Line Thickness 8 pixels
        private void Pixels8_MenuItem_Click(object sender, EventArgs e)
        {
            _pen1.Width = 8;
            SetLineThicknessMenu(pixels8_MenuItem);
        }

        // Line Thickness 16 pixels
        private void Pixels16_MenuItem_Click(object sender, EventArgs e)
        {
            _pen1.Width = 16;
            SetLineThicknessMenu(pixels16_MenuItem);
        }

        private void Pixels24_MenuItem_Click(object sender, EventArgs e)
        {
            _pen1.Width = 24;
            SetLineThicknessMenu(pixels24_MenuItem);
        }

        private void Pixels32_MenuItem_Click(object sender, EventArgs e)
        {
            _pen1.Width = 32;
            SetLineThicknessMenu(pixels32_MenuItem);
        }

        private void Pixels40_MenuItem_Click(object sender, EventArgs e)
        {
            _pen1.Width = 40;
            SetLineThicknessMenu(pixels40_MenuItem);
        }

        private void Pixels48_MenuItem_Click(object sender, EventArgs e)
        {
            _pen1.Width = 48;
            SetLineThicknessMenu(pixels48_MenuItem);
        }

        private void Pixels56_MenuItem_Click(object sender, EventArgs e)
        {
            _pen1.Width = 56;
            SetLineThicknessMenu(pixels56_MenuItem);
        }

        private void Pixels64_MenuItem_Click(object sender, EventArgs e)
        {
            _pen1.Width = 64;
            SetLineThicknessMenu(pixels64_MenuItem);
        }

        #endregion

        // **************** Options Menu - Line Color

        #region Line Color

        // Line Color
        private void LineColorMenuItem_Click(object sender, EventArgs e)
        {
            if (_selectedColor != panel7)
            {
                _colorDialog1.Color = _selectedColor.BackColor;
                if (_colorDialog1.ShowDialog(this) == DialogResult.OK)
                {
                    _selectedColor.BackColor = _colorDialog1.Color;
                    _pen1.Color = _selectedColor.BackColor;
                }
            }
        }

        #endregion

        // **************** Options Menu - Draw Mode

        #region Draw Mode

        private const int DRAWMODE_MENU_END = 6;

        private void ScribbleMenuItem_Click(object sender, EventArgs e)
        {
            if (!scribbleMenuItem.Checked)
            {
                _drawMode = DrawMode.Scribble;
                _pen1.StartCap = LineCap.Round;
                _pen1.EndCap = LineCap.Round;
                MainWindow.CheckMenuItems(optionsMenu, 0, DRAWMODE_MENU_END, scribbleMenuItem);
            }
        }

        private void DrawLineMenuItem_Click(object sender, EventArgs e)
        {
            if (!drawLineMenuItem.Checked)
            {
                _drawMode = DrawMode.Line;
                _pen1.StartCap = LineCap.Round;
                _pen1.EndCap = LineCap.Round;
                MainWindow.CheckMenuItems(optionsMenu, 0, DRAWMODE_MENU_END, drawLineMenuItem);
            }
        }

        private void DrawArrowMenuItem_Click(object sender, EventArgs e)
        {
            if (!drawArrowMenuItem.Checked)
            {
                _drawMode = DrawMode.Line;
                _pen1.StartCap = LineCap.Round;
                _pen1.EndCap = LineCap.ArrowAnchor;
                MainWindow.CheckMenuItems(optionsMenu, 0, DRAWMODE_MENU_END, drawArrowMenuItem);
            }
        }

        private void DrawCircleMenuItem_Click(object sender, EventArgs e)
        {
            if (!drawCircleMenuItem.Checked)
            {
                _drawMode = DrawMode.Circle;
                _pen1.StartCap = LineCap.NoAnchor;
                _pen1.EndCap = LineCap.NoAnchor;
                MainWindow.CheckMenuItems(optionsMenu, 0, DRAWMODE_MENU_END, drawCircleMenuItem);
            }
        }

        private void DrawEllipseMenuItem_Click(object sender, EventArgs e)
        {
            if (!drawEllipseMenuItem.Checked)
            {
                _drawMode = DrawMode.Ellipse;
                _pen1.StartCap = LineCap.NoAnchor;
                _pen1.EndCap = LineCap.NoAnchor;
                MainWindow.CheckMenuItems(optionsMenu, 0, DRAWMODE_MENU_END, drawEllipseMenuItem);
            }
        }

        private void DrawRectangleMenuItem_Click(object sender, EventArgs e)
        {
            if (!drawRectangleMenuItem.Checked)
            {
                _drawMode = DrawMode.Rectangle;
                _pen1.StartCap = LineCap.NoAnchor;
                _pen1.EndCap = LineCap.NoAnchor;
                MainWindow.CheckMenuItems(optionsMenu, 0, DRAWMODE_MENU_END, drawRectangleMenuItem);
            }
        }

        #endregion

        // **************** Options Menu - Opacity

        #region Opacity

        // Check/Uncheck items in the Opacity menu
        private void SetOpacityMenu(ToolStripMenuItem theItem)
        {
            foreach (ToolStripMenuItem item in opacityMenuItem.DropDown.Items)
            {
                item.Checked = item == theItem;
            }
            opacityMenuItem.Checked = (Opacity != 1);
        }

        // Opacity 25%
        private void Opacity25_MenuItem_Click(object sender, EventArgs e)
        {
            Opacity = 0.25;
            SetOpacityMenu(opacity25_MenuItem);
        }

        // Opacity 50%
        private void Opacity50_MenuItem_Click(object sender, EventArgs e)
        {
            Opacity = 0.5;
            SetOpacityMenu(opacity50_MenuItem);
        }

        // Opacity 75%
        private void Opacity75_MenuItem_Click(object sender, EventArgs e)
        {
            Opacity = 0.75;
            SetOpacityMenu(opacity75_MenuItem);
        }

        // Opacity 100%
        private void Opacity100_MenuItem_Click(object sender, EventArgs e)
        {
            Opacity = 1;
            SetOpacityMenu(opacity100_MenuItem);
        }

        #endregion

        // **************** Options Menu - AutoScale

        #region AutoScale

        private void AutoScaleMenuItem_Click(object sender, EventArgs e)
        {
            autoScaleMenuItem.Checked = _autoScale = !_autoScale;
        }

        #endregion

    }
}
