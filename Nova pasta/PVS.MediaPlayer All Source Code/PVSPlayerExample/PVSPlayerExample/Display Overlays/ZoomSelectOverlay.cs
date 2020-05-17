#region Usings

using PVS.MediaPlayer;
using System;
using System.Drawing;
using System.Windows.Forms;

#endregion

namespace PVSPlayerExample
{
    public sealed partial class ZoomSelectOverlay : Form, IOverlay
    {
        /*
        
        PVS.MediaPlayer Display Overlay - Example 'ZoomSelect'
        Zooms the selected part of a video.

        Draws a filled rectangle to allow the selection of an area of a video to zoom in or out,
        and allows moving of video within the display.
        
        */

        // ******************************** Fields

        #region Fields

        private enum ZoomMode
        {
            ZoomIn,
            ZoomOut,
            Move
        }

        // selection rectangle opacity
        private const double OPACITY = 0.4;

        private MainWindow  _baseForm;
        private Player      _basePlayer;
        private OverlayMode _baseOverlayMode;
        private DisplayMode _resetMode;
        private ZoomMode    _zoomMode = ZoomMode.ZoomIn;
        private Rectangle[] _undoSize;

        // RubberBand (rb) properties
        private bool        _isDrawing;
        private int         _rbOriginX;
        private  int        _rbOriginY;
        private Rectangle   _rbRectangle;
        private Pen         _rbPen;
        private SolidBrush  _rbBrush;

        private bool        _keepAspectRatio = true;

        // Buttons Panel divider lines paint
        private Pen         _pPen;
        private Point       _pPoint1A;
        private Point       _pPoint1B;
        private Point       _pPoint2A;
        private Point       _pPoint2B;

        // menu active
        private bool        _menuOn;

        // Mouse Events
        private bool        _hasMouseEvents;
        //private bool        _menuActive; // TODO: check this

        private bool        _disposed;

        #endregion

        // ******************************** Initialize & Form event handling

        #region Initialize & Form event handling

        // Main
        public ZoomSelectOverlay(MainWindow baseForm, Player thePlayer)
        {
            InitializeComponent();

            _baseForm   = baseForm;
            _basePlayer = thePlayer;

            // Pass on drag and drop to main form (handled in source file: DragDrop.cs):
            // but not for webcam overlay (_baseForm set to null)
            if (_baseForm != null)
            {
                AllowDrop = true;
                DragDrop += _baseForm.Form1_DragDrop;
            }
            else
            {
                _menuOn = true;
                zoomPanel.Visible = true;
            }

            _rbPen      = new Pen(Color.Goldenrod, 2);
            _rbBrush    = new SolidBrush(Color.FromArgb(157, 127, 55));
            _undoSize   = new Rectangle[10];

            _pPen       = new Pen(Color.DimGray, 1);
            _pPoint1A   = new Point(118, 2);
            _pPoint1B   = new Point(118, 22);
            _pPoint2A   = new Point(348, 2);
            _pPoint2B   = new Point(348, 22);

            Cursor      = Cursors.Cross;
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
                MouseDown   += ZoomSelectOverlay_MouseDown;
                MouseMove   += ZoomSelectOverlay_MouseMove;
                MouseUp     += ZoomSelectOverlay_MouseUp;

                _hasMouseEvents = true;
            }
        }

        private void RemoveMouseEvents()
        {
            if (_hasMouseEvents)
            {
                MouseDown   -= ZoomSelectOverlay_MouseDown;
                MouseMove   -= ZoomSelectOverlay_MouseMove;
                MouseUp     -= ZoomSelectOverlay_MouseUp;

                _hasMouseEvents = false;
            }
        }

        // Called when the form is shown or hidden
        private void ZoomSelectOverlay_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                if (_basePlayer.Display.Mode == DisplayMode.Manual)
                {
                    SetUndo();
                    _resetMode = DisplayMode.ZoomCenter;
                }
                else _resetMode = _basePlayer.Display.Mode;

                _basePlayer.Events.MediaDisplayModeChanged += BasePlayer_MediaDisplayModeChanged;

                _baseOverlayMode = _basePlayer.Overlay.Mode;
                if (_baseForm == null) _basePlayer.Overlay.Mode = OverlayMode.Display;
                else _baseForm.SetOverlayDisplayMode();

                SetMouseEvents();
            }
            else
            {
                RemoveMouseEvents();

                if (_baseOverlayMode == OverlayMode.Video)
                {
                    if (_baseForm == null) _basePlayer.Overlay.Mode = OverlayMode.Video;
                    else _baseForm.SetOverlayVideoMode();
                }

                ClearUndo();
            }
        }

        private void BasePlayer_MediaDisplayModeChanged(object sender, EventArgs e)
        {
            if (_basePlayer.Display.Mode != DisplayMode.Manual) _resetMode = _basePlayer.Display.Mode;
        }

        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    RemoveMouseEvents();
                    _rbPen.Dispose(); _rbPen = null;
                    _rbBrush.Dispose(); _rbBrush = null;
                    _pPen.Dispose(); _pPen = null;
                    ClearUndo();

                    if (_baseForm != null)
                    {
                        DragDrop -= _baseForm.Form1_DragDrop;
                        _baseForm = null;
                    }
                    _basePlayer = null;

                    if (components != null) components.Dispose();
                }
                _disposed = true;
            }
            base.Dispose(disposing);
        }

        // Buttons Panel paint divider lines
        private void ZoomPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(_pPen, _pPoint1A, _pPoint1B);
            e.Graphics.DrawLine(_pPen, _pPoint2A, _pPoint2B);
        }

        #endregion

        // ******************************** iOverlay Control

        #region iOverlay Control

        // The visibility of the menu is controlled by the user from the main application (in this example application)
        public bool MenuEnabled
        {
            get { return zoomPanel.Visible; }
            set
            {
                _menuOn = value;
                zoomPanel.Visible = value;
            }
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

        // ******************************** Do the selection drawing

        #region Do the selection drawing

        // TODO

        private void ZoomSelectOverlay_MouseDown(object sender, MouseEventArgs e)
        {
            //if (!_menuActive && _basePlayer.VideoPresent)
            if (_basePlayer.Video.Present)
            {
                SetUndo();

                Point p             = e.Location;
                _rbOriginX          = p.X;
                _rbOriginY          = p.Y;
                _rbRectangle.Width  = 0;
                _rbRectangle.Height = 0;

                Cursor.Clip         = RectangleToScreen(ClientRectangle);
                _isDrawing          = true;
            }
        }

        private void ZoomSelectOverlay_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_isDrawing) return;

            if (zoomPanel.Visible) zoomPanel.Hide();
            Opacity = OPACITY;

            Point p = e.Location;

            if (_zoomMode == ZoomMode.ZoomIn)
            {
                // Draw a filled rectangle, in any direction
                // the actual drawing is done in the paint event handler
                if (p.X < _rbOriginX)
                {
                    _rbRectangle.X      = p.X;
                    _rbRectangle.Width  = _rbOriginX - p.X;
                }
                else
                {
                    _rbRectangle.X      = _rbOriginX;
                    _rbRectangle.Width  = p.X - _rbOriginX;
                }

                if (p.Y < _rbOriginY)
                {
                    _rbRectangle.Y      = p.Y;
                    _rbRectangle.Height = _rbOriginY - p.Y;
                }
                else
                {
                    _rbRectangle.Y      = _rbOriginY;
                    _rbRectangle.Height = p.Y - _rbOriginY;
                }
                Invalidate();
            }
            else
            {
                // move the video
                _basePlayer.Video.Move(p.X - _rbOriginX, p.Y - _rbOriginY);
                _rbOriginX = p.X;
                _rbOriginY = p.Y;
            }
        }

        private void ZoomSelectOverlay_MouseUp(object sender, MouseEventArgs e)
        {
            if (!_isDrawing) return;

            Cursor.Clip = Rectangle.Empty;

            _isDrawing = false;
            Invalidate();

            if (_zoomMode != ZoomMode.Move) ZoomSelection();

            Opacity = 1;
            if (_menuOn) zoomPanel.Show();

            _isDrawing = false;
        }

        private void ZoomSelectOverlay_Paint(object sender, PaintEventArgs e)
        {
            if (_isDrawing && _zoomMode == ZoomMode.ZoomIn)
            {
                e.Graphics.FillRectangle(_rbBrush, _rbRectangle);
                e.Graphics.DrawRectangle(_rbPen, _rbRectangle);
            }
        }

        #endregion

        // ******************************** Do the Zoom

        #region Do the Zoom

        private void ZoomSelection()
        {
            if (_zoomMode == ZoomMode.ZoomOut)
            {
                // VideoZoom expects a point relative to the (entire) display so translate the point
                // (in case the overlay is not the same size as the display)
                _basePlayer.Video.Zoom(0.9, _basePlayer.Display.Window.PointToClient(PointToScreen(new Point(_rbOriginX, _rbOriginY))));
            }
            else if (_rbRectangle.Width >= 16 && _rbRectangle.Height >= 16)
            {
                if (_keepAspectRatio)
                {
                    //// 1. adjust for the current video aspect ratio
                    //if (rb_Rectangle.Width < rb_Rectangle.Height)
                    //    rb_Rectangle.Width = (int)(rb_Rectangle.Height * ((double)basePlayer.VideoBounds.Width / basePlayer.VideoBounds.Height));
                    //else
                    //    rb_Rectangle.Height = (int)(rb_Rectangle.Width / ((double)basePlayer.VideoBounds.Width / basePlayer.VideoBounds.Height));

                    // 1. adjust for the original video aspect ratio
                    if (_rbRectangle.Width < _rbRectangle.Height)
                        _rbRectangle.Width = (int)(_rbRectangle.Height * ((double)_basePlayer.Media.VideoSourceSize.Width / _basePlayer.Media.VideoSourceSize.Height));
                    else
                        _rbRectangle.Height = (int)(_rbRectangle.Width / ((double)_basePlayer.Media.VideoSourceSize.Width / _basePlayer.Media.VideoSourceSize.Height));

                    // 2. adjust for the player display aspect ratio
                    if (_basePlayer.Display.Window.Width < _basePlayer.Display.Window.Height)
                        _rbRectangle.Width = (int)(_rbRectangle.Height * ((double)_basePlayer.Display.Window.Width / _basePlayer.Display.Window.Height));
                    else
                        _rbRectangle.Height = (int)(_rbRectangle.Width / ((double)_basePlayer.Display.Window.Width / _basePlayer.Display.Window.Height));
                }

                // VideoZoom expects a rectangle as part of the (entire) display so translate the rectangle
                // (in case the overlay is not the same size as the display)
                _basePlayer.Video.Zoom(_basePlayer.Display.Window.RectangleToClient(RectangleToScreen(_rbRectangle)));
            }
            else GetUndo(); // remove undo value if not used
        }

        #endregion

        // ******************************** Handle the Buttons

        #region Handle the Buttons

        private void RatioButton_Click(object sender, EventArgs e)
        {
            _keepAspectRatio = !_keepAspectRatio;
            ratioLight.LightOn = _keepAspectRatio;
        }

        // The next 3 are radiobuttons
        private void ZoomInButton_Click(object sender, EventArgs e)
        {
            _zoomMode = ZoomMode.ZoomIn;
            zoomOutLight.LightOn = false;
            moveLight.LightOn = false;
            zoomInLight.LightOn = true;
            Cursor = Cursors.Cross;
        }

        private void ZoomOutButton_Click(object sender, EventArgs e)
        {
            _zoomMode = ZoomMode.ZoomOut;
            zoomInLight.LightOn = false;
            moveLight.LightOn = false;
            zoomOutLight.LightOn = true;
            Cursor = Cursors.Hand;
        }

        private void MoveButton_Click(object sender, EventArgs e)
        {
            _zoomMode = ZoomMode.Move;
            zoomInLight.LightOn = false;
            zoomOutLight.LightOn = false;
            moveLight.LightOn = true;
            Cursor = Cursors.SizeAll;
        }

        // Undo Button
        private void UndoButton_Click(object sender, EventArgs e)
        {
            Rectangle undoValue = GetUndo();
            if (!undoValue.IsEmpty) _basePlayer.Video.Bounds = undoValue;
            else _basePlayer.Display.Mode = _resetMode;
        }

        // Reset Button
        private void ResetButton_Click(object sender, EventArgs e)
        {
            _basePlayer.Display.Mode = _resetMode;
            ClearUndo();
        }

        #endregion

        // ******************************** Undo Things

        #region Undo Things

        private void SetUndo()
        {
            if (_basePlayer.Video.Bounds != _undoSize[0])
            {
                for (int i = 9; i > 0; i--) _undoSize[i] = _undoSize[i - 1];
                _undoSize[0] = _basePlayer.Video.Bounds;
            }
        }

        private Rectangle GetUndo()
        {
            Rectangle retValue = _undoSize[0];

            for (int i = 0; i < 9; i++) _undoSize[i] = _undoSize[i + 1];
            _undoSize[9] = Rectangle.Empty;

            return retValue;
        }

        private void ClearUndo()
        {
            for (int i = 0; i < 10; i++) _undoSize[i] = Rectangle.Empty;
        }

        #endregion

    }
}
