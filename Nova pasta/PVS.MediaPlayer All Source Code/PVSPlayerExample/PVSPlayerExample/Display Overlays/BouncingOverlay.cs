#region Usings

using PVS.MediaPlayer;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

#endregion

namespace PVSPlayerExample
{
    public sealed partial class BouncingOverlay : Form, IOverlay
    {
        /*
        
        PVS.MediaPlayer Display Overlay - Example 'Bounce & Pong'
        Displays simple 'bouncing' transparent shapes and offers a game of "Pong".
        
        */

        // ******************************** Fields

        #region Fields

        // Structure to hold a shape's data
        private struct Shape
        {
            public int          XPos;
            public int          YPos;
            public int          XDelta;
            public int          YDelta;
            public Rectangle    Rect;
        }

        // Enumeration shapes form
        private enum ShapeForm
        {
            Round,
            Square,
            Diamond,
            Star
        }

        private const int   BASE_XDELTA = 8; // the x movement (speed) of the first shape (in pixels)
        private const int   BASE_YDELTA = 10; // the y movement (speed) of the first shape (in pixels)
        private const int   DIFF_XDELTA = 1; // the x speed added to every next shape
        private const int   DIFF_YDELTA = 1; // the y speed added to every next shape

        private const int   TIMER_INTERVAL = 25;

        private bool        _isDrawing; // indicates shapes are being drawn

        private Shape[]     _shapes; // the shapes array
        private int         _shapeCount = 3; // the number of shapes

        private ShapeForm   _shapeForm = ShapeForm.Round; // the shape form
        private Point[]     _diamondPoints = new Point[4]; // used with drawing Diamond shape
        private Point[]     _starPoints = new Point[8]; // used with drawing Star shape

        private int         _shapeSize = 3; // the size of the shapes (overlay width or height divided by this)
        private bool        _shapeSizeCount; // set to true if shapeSize is number of shapes

        private bool        _moveShapes; // used to move shapes only by timer tick event (not with resize)

        private SolidBrush  _brush1; // used to draw shapes
        private HatchBrush  _brush2; // used to draw shapes
        private HatchBrush  _brush3; // used to draw shapes
        private HatchBrush  _brush4; // used to draw shapes
        private bool        _backTransparent; // indicates what is transparent, shape or background

        private Timer       _timer1;

        // Interacting with the player
        private Player      _basePlayer;
        private MainWindow  _baseForm;

        private bool        _disposed;

        #endregion

        // ******************************** Initialize & Form event handling

        #region Initialize & Form event handling

        // Initialize
        public BouncingOverlay(MainWindow baseForm, Player thePlayer)
        {
            InitializeComponent();
            _baseForm = baseForm;

            // Reduce 'flickering' of the bubbles
            DoubleBuffered = true;

            // Set numericUpDown1 control
            numericUpDown1.Value = _shapeCount;
            numericUpDown1.Focus();
            numericUpDown1.Select(0, 5);

            // Create and initialize the bubbles
            ShapesInit();

            // Set brush to draw transparant bubbles
            _brush1 = new SolidBrush(TransparencyKey);
            _brush2 = new HatchBrush(HatchStyle.HorizontalBrick, Color.Red, TransparencyKey);
            _brush3 = new HatchBrush(HatchStyle.OutlinedDiamond, Color.White, TransparencyKey);
            _brush4 = new HatchBrush(HatchStyle.Percent50, Color.Gold, TransparencyKey);

            // Create a timer
            _timer1 = new Timer();
            _timer1.Tick += Timer1_Tick;
            _timer1.Interval = TIMER_INTERVAL;

            // Pass on drag and drop to main form (handled in source file: DragDrop.cs):
            AllowDrop = true;
            DragDrop += _baseForm.Form1_DragDrop;

            // Interact with the (base) player
            _basePlayer = thePlayer;
            _basePlayer.Events.MediaPausedChanged += BasePlayer_MediaPausedResumed;

            // If paused, insure proper redraw
            ResizeRedraw = true;
        }

        protected override bool ShowWithoutActivation
        {
            get { return true; }
        }

        // Form  don't activate form with mouse click
        protected override void WndProc(ref Message m)
        {
            const int WM_MOUSEACTIVATE  = 0x0021;
            const int MA_NOACTIVATE     = 0x0003;

            if (m.Msg == WM_MOUSEACTIVATE) m.Result = (IntPtr)MA_NOACTIVATE;
            else base.WndProc(ref m);
        }

        // Handles pause/resume events from the main (base) player
        private void BasePlayer_MediaPausedResumed(object sender, EventArgs e)
        {
            if (!_pongMode)
            {
                if (_basePlayer.Paused) _timer1.Stop();
                else if (Visible) _timer1.Start();
            }
        }

        // Gets called when the overlay is shown or hidden
        private void Form1_VisibleChanged(object sender, EventArgs e)
        {
            // No need for a running timer when the overlay is not visible
            if (Visible)
            {
                if (!_pongMode) MouseDown += _basePlayer.Display.Drag_MouseDown;
                else _basePlayer.Overlay.Blend = OverlayBlend.Opaque;
                if (!_basePlayer.Paused) _timer1.Start();
            }
            else
            {
                if (_pongMode)
                {
                    if (_playing)
                    {
                        _pauseStatus = _status;
                        _scorePlayer1_On = true;
                        _scorePlayer2_On = true;
                        _status = PongStatus.Paused;
                        SetPlayMode(false);
                    }
                }
                else
                {
                    MouseDown -= _basePlayer.Display.Drag_MouseDown;
                }
                _timer1.Stop();

                _basePlayer.Overlay.Blend = OverlayBlend.None;
            }

            _baseForm.SetWindowDrag(!_pongMode);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (_pongMode)
            {
                switch (_status)
                {
                    case PongStatus.Begin:
                    case PongStatus.Player1_Won:
                    case PongStatus.Player2_Won:
                        if (e.Button == MouseButtons.Left)
                        {
                            _scorePlayer1 = 0;
                            _scorePlayer2 = 0;
                            SetPlayMode(true);
                            _status = PongStatus.Ball_Launch;
                        }
                        break;

                    case PongStatus.Paused:
                        if (e.Button == MouseButtons.Left)
                        {
                            SetPlayMode(true);
                            if (_pauseStatus != PongStatus.Playing) _status = PongStatus.Ball_Launch;
                            else _status = PongStatus.Playing;
                        }
                        break;

                    default:
                        //case PongStatus.Playing:
                        _pauseStatus = _status;
                        _scorePlayer1_On = true;
                        _scorePlayer2_On = true;
                        _status = PongStatus.Paused;
                        SetPlayMode(false);
                        break;
                }
            }
            else
            {
                // If the mouse click is inside a shape reverse it's x direction movement
                for (int i = 0; i < _shapes.Length; i++)
                {
                    if (_shapes[i].Rect.Contains(e.Location))
                    {
                        _shapes[i].XDelta = -_shapes[i].XDelta;
                    }
                }
            }
        }

        // Create and initialize 'shapesCount' bubbles
        private void ShapesInit()
        {
            int xDelta = BASE_XDELTA;
            int yDelta = BASE_YDELTA;

            _shapes = new Shape[_shapeCount];

            for (int i = 0; i < _shapes.Length; i++)
            {
                _shapes[i].XPos = 0;
                _shapes[i].YPos = 0;
                _shapes[i].XDelta = xDelta;
                _shapes[i].YDelta = yDelta;

                // This makes the shapes move in (slightly) different ways:
                xDelta += DIFF_XDELTA;
                yDelta += DIFF_YDELTA;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                _disposed = true;
                if (disposing)
                {
                    _timer1.Dispose(); _timer1 = null;

                    _brush1.Dispose(); _brush1 = null;
                    _brush2.Dispose(); _brush2 = null;
                    _brush3.Dispose(); _brush3 = null;
                    _brush4.Dispose(); _brush4 = null;

                    DragDrop -= _baseForm.Form1_DragDrop;
                    _baseForm = null;

                    _basePlayer.Events.MediaPausedChanged -= BasePlayer_MediaPausedResumed;
                    _basePlayer = null;

                    // Pong
                    SetPlayMode(false);
                    this.SizeChanged -= Pong_SizeChanged;
                    if (_scoreFont != null)
                    {
                        _scoreFont.Dispose(); _scoreFont = null;
                        _scoreBrush.Dispose();
                        _scoreFormat.Dispose();
                        _messageFont.Dispose();
                        _messageBrush.Dispose();
                        _centerLinePen.Dispose();
                        _ballBrush.Dispose();
                        _leftPaddleBrush.Dispose();
                        _rightPaddleBrush.Dispose();
                    }

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
            get { return bouncingPanel.Visible; }
            set { bouncingPanel.Visible = value; }
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

        // ******************************** Timer tick event handling

        #region Timer tick event

        void Timer1_Tick(object sender, EventArgs e)
        {
            if (_pongMode)
            {
                if (_status == PongStatus.Playing) MoveBall();
                this.Invalidate(false);
            }
            else
            {
                _moveShapes = true;
                Refresh(); // Move and draw the shapes (Form1_Paint)
                _moveShapes = false;
            }
        }

        #endregion

        // ******************************** Move and/or draw the shapes

        #region Paint Shapes

        // Paint the shapes
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (!_isDrawing) // don't draw shapes if already drawing
            {
                _isDrawing = true;

                int theWidth = ClientRectangle.Width;
                int theHeight = ClientRectangle.Height;
                int theSize = theWidth > theHeight ? theHeight : theWidth;
                theSize /= _shapeSize;

                for (int i = 0; i < _shapes.Length; i++)
                {
                    // Only move the shapes from the timer tick event (not when overlay is resized)...
                    if (_moveShapes)
                    {
                        _shapes[i].XPos += _shapes[i].XDelta;
                        if (_shapes[i].XPos <= 0)
                        {
                            _shapes[i].XPos = 0;
                            _shapes[i].XDelta = -_shapes[i].XDelta;
                        }
                        else if (_shapes[i].XPos + theSize > theWidth)
                        {
                            _shapes[i].XPos = theWidth - theSize;
                            _shapes[i].XDelta = -_shapes[i].XDelta;
                        }

                        _shapes[i].YPos += _shapes[i].YDelta;
                        if (_shapes[i].YPos <= 0)
                        {
                            _shapes[i].YPos = 0;
                            _shapes[i].YDelta = -_shapes[i].YDelta;
                        }
                        else if (_shapes[i].YPos + theSize >= theHeight)
                        {
                            _shapes[i].YPos = theHeight - theSize;
                            _shapes[i].YDelta = -_shapes[i].YDelta;
                        }
                    }

                    // ... but also redraw the shapes after resizing the overlay
                    _shapes[i].Rect = new Rectangle(_shapes[i].XPos, _shapes[i].YPos, theSize, theSize);

                    // Drawing shapes, but could also move around controls like panels and pictureboxes
                    // Draw the transparant shape
                    switch (_shapeForm)
                    {
                        case ShapeForm.Round:
                            e.Graphics.FillEllipse(_brush1, _shapes[i].Rect);
                            break;

                        case ShapeForm.Square:
                            e.Graphics.FillRectangle(_brush2, _shapes[i].Rect);
                            break;

                        case ShapeForm.Diamond:
                            // Should do these calculations elsewhere for efficiency/speed
                            _diamondPoints[0] = new Point(_shapes[i].XPos + (_shapes[i].Rect.Width / 2), _shapes[i].YPos);
                            _diamondPoints[1] = new Point(_shapes[i].XPos + _shapes[i].Rect.Width, _shapes[i].YPos + (_shapes[i].Rect.Height / 2));
                            _diamondPoints[2] = new Point(_shapes[i].XPos + (_shapes[i].Rect.Width / 2), _shapes[i].YPos + _shapes[i].Rect.Height);
                            _diamondPoints[3] = new Point(_shapes[i].XPos, _shapes[i].YPos + (_shapes[i].Rect.Height / 2));
                            e.Graphics.FillPolygon(_brush3, _diamondPoints);
                            break;

                        case ShapeForm.Star:
                            // Should do these calculations elsewhere for efficiency/speed
                            _starPoints[0] = new Point(_shapes[i].XPos + (_shapes[i].Rect.Width / 2), _shapes[i].YPos);
                            _starPoints[1] = new Point(_shapes[i].XPos + (int)(0.67 * _shapes[i].Rect.Width), _shapes[i].YPos + (int)(0.33 * _shapes[i].Rect.Height));
                            _starPoints[2] = new Point(_shapes[i].XPos + (_shapes[i].Rect.Width), _shapes[i].YPos + (_shapes[i].Rect.Height / 2));
                            _starPoints[3] = new Point(_shapes[i].XPos + (int)(0.67 * _shapes[i].Rect.Width), _shapes[i].YPos + (int)(0.67 * _shapes[i].Rect.Height));
                            _starPoints[4] = new Point(_shapes[i].XPos + (_shapes[i].Rect.Width / 2), _shapes[i].YPos + _shapes[i].Rect.Height);
                            _starPoints[5] = new Point(_shapes[i].XPos + (int)(0.33 * _shapes[i].Rect.Width), _shapes[i].YPos + (int)(0.67 * _shapes[i].Rect.Height));
                            _starPoints[6] = new Point(_shapes[i].XPos, _shapes[i].YPos + (_shapes[i].Rect.Height / 2));
                            _starPoints[7] = new Point(_shapes[i].XPos + (int)(0.33 * _shapes[i].Rect.Width), _shapes[i].YPos + (int)(0.33 * _shapes[i].Rect.Height));
                            e.Graphics.FillPolygon(_brush4, _starPoints);
                            break;
                    }
                }
                _isDrawing = false;
            }
        }

        #endregion

        // ******************************** Buttons 'Set' handling

        #region Button 'Set'

        // The button 'Options' is handled by the user control Menubutton

        // Set the number of shapes according to the value in 'numericUpDown1' control
        private void SetButton_Click(object sender, EventArgs e)
        {
            bool timerEnabled = _timer1.Enabled; // Get the current running state of the timer

            if (timerEnabled) _timer1.Stop(); // Don't draw shapes while they're being created and initialized

            _shapeCount = (int)numericUpDown1.Value;
            ShapesInit();
            if (_shapeSizeCount) _shapeSize = _shapes.Length;

            if (timerEnabled) _timer1.Start(); // Restart the timer if it was previously running
            else Invalidate();

            numericUpDown1.Focus();
            numericUpDown1.Select(0, 5);
        }

        #endregion

        // ******************************** Contextmenu handling

        #region Contextmenu handling

        // When closed set focus to shapecount input
        private void ContextMenuStrip1_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            numericUpDown1.Focus();
        }

        // ******************************** Contextmenu ShapeForm items handling

        // Round
        private void RoundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _shapeForm = ShapeForm.Round;
            SetToolStripShapeForm(sender);
        }

        // Square
        private void SquareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _shapeForm = ShapeForm.Square;
            SetToolStripShapeForm(sender);
        }

        // Diamond
        private void DiamondToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _shapeForm = ShapeForm.Diamond;
            SetToolStripShapeForm(sender);
        }

        // Star
        private void StarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _shapeForm = ShapeForm.Star;
            SetToolStripShapeForm(sender);
        }

        // Removes the check marks from the Shape contextmenu items and checks the selected item
        private void SetToolStripShapeForm(object sender)
        {
            foreach (ToolStripItem item in (((ToolStripMenuItem)sender).GetCurrentParent().Items))
            {
                if (item.GetType() == typeof(ToolStripMenuItem))
                {
                    ((ToolStripMenuItem)item).Checked = item == sender;
                }
            }

            if(!_timer1.Enabled) Invalidate();
        }

        // ******************************** Contextmenu ShapeSize items handling

        // OverlaySize/3
        private void OverlaySize3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _shapeSize = 3;
            SetToolStripShapeSize(sender);
        }

        // OverlaySize/4
        private void OverlaySize4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _shapeSize = 4;
            SetToolStripShapeSize(sender);
        }

        // OverlaySize/5
        private void OverlaySize5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _shapeSize = 5;
            SetToolStripShapeSize(sender);
        }

        // Handles contextmenu item 'OverlaySize/shapecount' to set shape size
        private void OverlaySizeBubblesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _shapeSize = _shapes.Length;
            SetToolStripShapeSize(sender);
        }

        // Removes the check marks from the ShapeSize contextmenu items and checks the selected item
        private void SetToolStripShapeSize(object sender)
        {
            // Check selected item (sender) and uncheck other menu items 
            foreach (ToolStripItem item in (((ToolStripMenuItem)sender).GetCurrentParent().Items))
            {
                if (item.GetType() == typeof(ToolStripMenuItem))
                {
                    ((ToolStripMenuItem)item).Checked = item == sender;
                }
            }

            // Set 'shapeSizeCount' to true if the shape size is calculated from the number of bubbles
            _shapeSizeCount = (ToolStripMenuItem)sender == overlaySizeBubblesToolStripMenuItem;

            if (!_timer1.Enabled) Invalidate();
        }

        // ******************************** Contextmenu Color item handling

        // Handles contextmenu item 'Color' to set the background color of the overlay (or shape)
        private void BackColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog1 = new ColorDialog {Color = BackColor};
            if (colorDialog1.ShowDialog(this) == DialogResult.OK)
            {
                _brush2.Dispose();
                _brush3.Dispose();
                _brush4.Dispose();

                if (_backTransparent)
                {
                    _brush1.Color = colorDialog1.Color;
                    _brush2 = new HatchBrush(HatchStyle.HorizontalBrick, _brush1.Color, TransparencyKey);
                    _brush3 = new HatchBrush(HatchStyle.OutlinedDiamond, _brush1.Color, TransparencyKey);
                    _brush4 = new HatchBrush(HatchStyle.Percent50, _brush1.Color, TransparencyKey);
                }
                else
                {
                    BackColor = colorDialog1.Color;
                    _brush2 = new HatchBrush(HatchStyle.HorizontalBrick, Color.Red, TransparencyKey);
                    _brush3 = new HatchBrush(HatchStyle.OutlinedDiamond, Color.White, TransparencyKey);
                    _brush4 = new HatchBrush(HatchStyle.Percent50, Color.Gold, TransparencyKey);
                }
            }
            colorDialog1.Dispose();
        }

        // ******************************** Contextmenu Opacity item handling

        // Opacity
        private void HandleToolStripOpacity(object sender, EventArgs e)
        {
            double value;

            // get the text of the menu item (e.g. 50%), remove the '%' and convert to double value
            if (double.TryParse(((ToolStripMenuItem)sender).Text.TrimEnd('%'), out value))
            {
                if (value >= 25 && value <= 100)
                {
                    Opacity = value / 100;

                    // Removes the check marks from the Opacity contextmenu items and checks the selected item
                    foreach (ToolStripItem item in (((ToolStripMenuItem)sender).GetCurrentParent().Items))
                    {
                        if (item.GetType() == typeof(ToolStripMenuItem))
                        {
                            ((ToolStripMenuItem)item).Checked = item == sender;
                        }
                    }
                }

                opacityMenuItem.Checked = (Opacity != 1);
            }
        }

        // ******************************** Contextmenu Invert Transparency handling

        // Invert Transparency
        private void InvertTransparencyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!_pongMode)
            {
                if (_backTransparent)
                {
                    BackColor = _brush1.Color;
                    _brush1.Color = TransparencyKey;
                }
                else
                {
                    _brush1.Color = BackColor;
                    BackColor = TransparencyKey;
                }
                _backTransparent = !_backTransparent;
            }
        }

        // ******************************** Pong items handling

        private void StartPongMenuItem_Click(object sender, EventArgs e)
        {
            if (_pongMode) StopPong();
            else StartPong();
        }

        private void SlowPongMenuItem_Click(object sender, EventArgs e)
        {
            SetPongDifficulty(PongSpeed.Slow);
        }

        private void NormalPongMenuItem_Click(object sender, EventArgs e)
        {
            SetPongDifficulty(PongSpeed.Normal);
        }

        private void FastPongMenuItem_Click(object sender, EventArgs e)
        {
            SetPongDifficulty(PongSpeed.Fast);
        }

        private void FasterPongMenuItem_Click(object sender, EventArgs e)
        {
            SetPongDifficulty(PongSpeed.Ultra);
        }

        // set pong speed
        private void SetPongDifficulty(PongSpeed difficulty)
        {
            if (difficulty != _difficulty)
            {
                slowPongMenuItem.Checked = false;
                normalPongMenuItem.Checked = false;
                fastPongMenuItem.Checked = false;
                fasterPongMenuItem.Checked = false;

                float scaleX = _totalfieldRect.Width / TOTALFIELD_WIDTH;
                float scaleY = _totalfieldRect.Height / TOTALFIELD_HEIGHT;

                _difficulty = difficulty;
                switch (_difficulty)
                {
                    case PongSpeed.Slow:
                        _basePaddleSpeed = PADDLE_SPEED_SLOW;
                        _baseBallSpeed_X = BALL_SPEED_SLOW_X;
                        _baseBallSpeed_Y = BALL_SPEED_SLOW_Y;
                        slowPongMenuItem.Checked = true;
                        break;

                    case PongSpeed.Normal:
                        _basePaddleSpeed = PADDLE_SPEED_NORMAL;
                        _baseBallSpeed_X = BALL_SPEED_NORMAL_X;
                        _baseBallSpeed_Y = BALL_SPEED_NORMAL_Y;
                        normalPongMenuItem.Checked = true;
                        break;

                    case PongSpeed.Fast:
                        _basePaddleSpeed = PADDLE_SPEED_FAST;
                        _baseBallSpeed_X = BALL_SPEED_FAST_X;
                        _baseBallSpeed_Y = BALL_SPEED_FAST_Y;
                        fastPongMenuItem.Checked = true;
                        break;

                    case PongSpeed.Ultra:
                        _basePaddleSpeed = PADDLE_SPEED_ULTRA;
                        _baseBallSpeed_X = BALL_SPEED_ULTRA_X;
                        _baseBallSpeed_Y = BALL_SPEED_ULTRA_Y;
                        fasterPongMenuItem.Checked = true;
                        break;
                }

                // computer paddle speed - TODO increasing paddle speed like this makes computer 'invincible'
                //_paddleSpeed = (int)(_basePaddleSpeed * scaleY * ((float)PADDLE_HEIGHT / _leftPaddleRect.Height));
                //if (_paddleSpeed < 1) _paddleSpeed = 1;
                _paddleSpeed = (int)_basePaddleSpeed;

                // ball speed (preserve direction)
                _ballSpeed_X = (int)(scaleX * _baseBallSpeed_X) * (_ballSpeed_X < 0 ? -1 : 1);
                _ballSpeed_Y = (int)(scaleY * _baseBallSpeed_Y) * (_ballSpeed_Y < 0 ? -1 : 1);

                if (!_pongMode) StartPong();
            }
        }

        #endregion



        // ******************************** Pong Game

        // ******************************** Pong Fields

        #region Fields

        // ******************************** Design values

        #region Design values

        private const int   MAX_SCORE               = 11; // - 15 - 21
        private Color       SCORE_TEXT_COLOR        = UIColors.MenuTextEnabledColor; // Color.White;

        private const int   FLASH_COUNT             = 4; // must be even
        private const int   FLASH_INTERVAL          = 15;

        private const float TOTALFIELD_WIDTH        = 871; // form displayrectangle at design time
        private const float TOTALFIELD_HEIGHT       = 501; // base design values - don't change

        private Color       CENTER_LINE_COLOR       = UIColors.MenuTextEnabledColor; // Color.White;
        private const float CENTER_LINE_WIDTH       = 5;
        private const bool  CENTER_LINE_ROUNDED     = true;

        private Color       PADDLE_COLOR_LEFT       = UIColors.MenuTextEnabledColor; // Color.White;
        private Color       PADDLE_COLOR_RIGHT      = UIColors.MenuTextEnabledColor; // Color.White;
        private const int   PADDLE_BASE_SIZE        = 50;
        private const int   PADDLE_STRETCH_SIZE     = 30;
        private const int   PADDLE_WIDTH            = 18;
        private const int   PADDLE_HEIGHT           = PADDLE_BASE_SIZE + PADDLE_STRETCH_SIZE;
        private const int   PADDLE_MARGIN           = PADDLE_WIDTH + 20;

        // this also determines the degree of difficulty (together with ballspeed and sizes)
        private const float PADDLE_SPEED_SLOW       = 6.0F; // left paddle - computer
        private const float PADDLE_SPEED_NORMAL     = 7.5F; // ?
        private const float PADDLE_SPEED_FAST       = 7.0F; // ?
        private const float PADDLE_SPEED_ULTRA      = 7.6F; // ?

        private Color       BALL_COLOR              = Color.White; //  Color.Yellow;
        private const int   BALL_SIZE               = 30;
        private const int   BALL_SIZE_HALF          = BALL_SIZE / 2;

        private const float BALL_SPEED_SLOW_X       = 4;
        private const float BALL_SPEED_NORMAL_X     = 7;
        private const float BALL_SPEED_FAST_X       = 14;
        private const float BALL_SPEED_ULTRA_X      = 20;

        private const float BALL_SPEED_SLOW_Y       = 1;
        private const float BALL_SPEED_NORMAL_Y     = 2;
        private const float BALL_SPEED_FAST_Y       = 3;
        private const float BALL_SPEED_ULTRA_Y      = 4;

        private Color       MESSAGE_TEXT_COLOR      = UIColors.MenuTextEnabledColor;
        private const int   MESSAGE_FONT_SIZE       = 24;
        private string      MESSAGE_BEGIN           = "Click here to start playing.\r\n\r\nWhen playing\r\nClick = Pause / Resume";
        private string      MESSAGE_PAUSED          = "Game paused.\r\nClick here to continue.";
        private string      MESSAGE_PLAYER1_WON     = "COMPUTER WINS!\r\nClick here to play again.";
        private string      MESSAGE_PLAYER2_WON     = "YOU WIN!\r\nClick here to play again.";

        #endregion

        // Enums
        enum PongSpeed
        {
            Slow,
            Normal,
            Fast,
            Ultra
        }
        enum PongStatus
        {
            Begin,
            Ball_Launch,
            Ball_Lauch_Flash,

            Playing,
            Paused,

            Player1_Scored,
            Player1_Scored_Flash,
            Player1_Wins,
            Player1_Wins_Flash,
            Player1_Won,

            Player2_Scored,
            Player2_Scored_Flash,
            Player2_Wins,
            Player2_Wins_Flash,
            Player2_Won
        }

        // Play status
        private bool        _pongMode;
        private bool        _playing;           // mouse 'locked'
        private PongSpeed   _difficulty         = PongSpeed.Normal;
        private PongStatus  _status;
        private PongStatus  _pauseStatus;

        // Playfield
        private Rectangle   _totalfieldRect     = new Rectangle(0, 0, (int)TOTALFIELD_WIDTH, (int)TOTALFIELD_HEIGHT);
        private Rectangle   _playfieldRect;
        private Rectangle   _borderRect;

        // flashing items
        private bool        _flashState;
        private int         _flashCount;
        private int         _flashInterval;

        // score text
        private Font        _scoreFont;
        private Brush       _scoreBrush;
        private int         _scorePosition1;
        private StringFormat _scoreFormat;
        private int         _scorePosition2;

        // message text
        private Font        _messageFont;
        private Brush       _messageBrush;
        private TextFormatFlags _messageFlags;

        // Center line
        private Pen         _centerLinePen;
        private Point       _centerLineTop;
        private Point       _centerLineBottom;

        // Ball
        private Rectangle   _ballRect;
        private Brush       _ballBrush;
        private float       _baseBallSpeed_X    = BALL_SPEED_NORMAL_X;
        private int         _ballSpeed_X;
        private float       _baseBallSpeed_Y    = BALL_SPEED_NORMAL_Y;
        private int         _ballSpeed_Y;

        // Paddles
        private Rectangle   _leftPaddleRect;
        private Brush       _leftPaddleBrush;

        private Rectangle   _rightPaddleRect;
        private Brush       _rightPaddleBrush;

        private int         _paddleSectionSize;
        private float       _basePaddleSpeed    = PADDLE_SPEED_NORMAL;
        private int         _paddleSpeed;

        // players score
        private int         _scorePlayer1;
        private bool        _scorePlayer1_On    = true;
        private int         _scorePlayer2;
        private bool        _scorePlayer2_On    = true;

        // saved values
        private int         _oldInterval;       // timer

        #endregion

        // ******************************** Pong Main

        #region Main

        private void StartPong()
        {
            MouseDown -= _basePlayer.Display.Drag_MouseDown;

            _timer1.Stop();

            _pongMode = true;
            startPongMenuItem.Text = "Stop Pong";

            _oldInterval = _timer1.Interval;
            _timer1.Interval = 10;

            opacity75MenuItem.PerformClick();

            // score text
            _scorePlayer1 = 0;
            _scorePlayer2 = 0;
            _scoreFont = new Font(this.Font.FontFamily, 96, FontStyle.Bold);
            _scoreBrush = new SolidBrush(SCORE_TEXT_COLOR);
            _scoreFormat = new StringFormat(StringFormatFlags.DirectionRightToLeft);

            // message text
            _messageBrush = new SolidBrush(MESSAGE_TEXT_COLOR);
            _messageFlags = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.WordBreak;

            // center line
            _centerLinePen = new Pen(CENTER_LINE_COLOR, CENTER_LINE_WIDTH);
            _centerLinePen.DashStyle = DashStyle.Dash;
            if (CENTER_LINE_ROUNDED) _centerLinePen.SetLineCap(LineCap.Round, LineCap.Round, DashCap.Round);

            // ball
            _ballRect = new Rectangle(425, 240, BALL_SIZE, BALL_SIZE);
            _ballBrush = new SolidBrush(BALL_COLOR);

            // left paddle
            _leftPaddleRect = new Rectangle(20, 202, PADDLE_WIDTH, PADDLE_HEIGHT);
            _leftPaddleBrush = new SolidBrush(PADDLE_COLOR_LEFT);

            // right paddle
            _rightPaddleRect = new Rectangle(833, 202, PADDLE_WIDTH, PADDLE_HEIGHT);
            _rightPaddleBrush = new SolidBrush(PADDLE_COLOR_RIGHT);

            // both paddles
            _paddleSectionSize = PADDLE_HEIGHT / 5;

            _status = PongStatus.Begin;
            SetPlayField();

            this.SizeChanged += Pong_SizeChanged;
            _timer1.Start();

            _basePlayer.Overlay.Blend = OverlayBlend.Opaque;
        }

        private void StopPong()
        {
            if (_pongMode)
            {
                _timer1.Stop();
                this.SizeChanged -= Pong_SizeChanged;

                _timer1.Interval = _oldInterval;
                opacity100MenuItem.PerformClick();

                _pongMode = false;
                startPongMenuItem.Text = "Start Pong";

                _timer1.Start(); // timer for "Bouncing"
            }

            MouseDown += _basePlayer.Display.Drag_MouseDown;

            _basePlayer.Overlay.Blend = OverlayBlend.None;
        }

        private void Pong_SizeChanged(object sender, EventArgs e)
        {
            SetPlayField();
        }

        #endregion

        // ******************************** Pong Event Handling

        #region Event Handling

        private void Pong_MouseMove(object sender, MouseEventArgs e)
        {
            _rightPaddleRect.Y = e.Y - (_rightPaddleRect.Height / 2);
            if (_rightPaddleRect.Y < 0) _rightPaddleRect.Y = 0;
            else if (_rightPaddleRect.Y + _rightPaddleRect.Height > _playfieldRect.Height) _rightPaddleRect.Y = _playfieldRect.Height - _rightPaddleRect.Height;
        }

        #endregion

        // ******************************** Pong Paint

        #region Paint

        protected override void OnPaint(PaintEventArgs e)
        {
            if (!_pongMode)
            {
                base.OnPaint(e);
                return;
            }

            bool drawBall = false;
            Graphics g = e.Graphics;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

            // draw border lines
            g.DrawRectangle(Pens.DimGray, _borderRect);

            // draw score text
            if (_scorePlayer1_On) g.DrawString(_scorePlayer1.ToString(), _scoreFont, _scoreBrush, _scorePosition1, 5, _scoreFormat);
            if (_scorePlayer2_On) g.DrawString(_scorePlayer2.ToString(), _scoreFont, _scoreBrush, _scorePosition2, 5);

            // draw center line
            g.DrawLine(_centerLinePen, _centerLineTop, _centerLineBottom);

            // draw left paddle
            g.FillRectangle(_leftPaddleBrush, _leftPaddleRect);

            // draw right paddle
            g.FillRectangle(_rightPaddleBrush, _rightPaddleRect);

            switch (_status)
            {
                case PongStatus.Begin:
                    DrawMessage(g, MESSAGE_BEGIN);
                    break;

                case PongStatus.Ball_Launch:
                    _leftPaddleRect.Y = (_playfieldRect.Height / 2) - (_leftPaddleRect.Height / 2);

                    _ballRect.X = _playfieldRect.X + 40;
                    _ballRect.Y = (_playfieldRect.Height / 2) - BALL_SIZE_HALF;
                    if (_ballSpeed_X < 0) _ballSpeed_X = -_ballSpeed_X;
                    _ballSpeed_Y = 0;

                    _flashCount = FLASH_COUNT;
                    _flashInterval = FLASH_INTERVAL;
                    _flashState = true;

                    drawBall = true;
                    _status = PongStatus.Ball_Lauch_Flash;
                    break;

                case PongStatus.Ball_Lauch_Flash:
                    if (--_flashInterval < 0)
                    {
                        if (--_flashCount < 0) _status = PongStatus.Playing;
                        else
                        {
                            _flashState = !_flashState;
                            _flashInterval = FLASH_INTERVAL;
                        }
                    }
                    drawBall = _flashState;
                    break;

                case PongStatus.Playing:
                    drawBall = true;
                    break;

                case PongStatus.Paused:
                    DrawMessage(g, MESSAGE_PAUSED);
                    drawBall = true;
                    break;

                case PongStatus.Player1_Scored:
                    _flashCount = FLASH_COUNT;
                    _flashInterval = FLASH_INTERVAL;
                    _flashState = true;
                    _status = PongStatus.Player1_Scored_Flash;
                    break;

                case PongStatus.Player1_Scored_Flash:
                    if (--_flashInterval < 0)
                    {
                        if (--_flashCount < 0) _status = PongStatus.Ball_Launch;
                        else
                        {
                            _scorePlayer1_On = !_scorePlayer1_On;
                            _flashInterval = FLASH_INTERVAL;
                        }
                    }
                    break;

                case PongStatus.Player1_Wins:
                    SetPlayMode(false);
                    _status = PongStatus.Player1_Won;
                    break;

                case PongStatus.Player1_Won:
                    DrawMessage(g, MESSAGE_PLAYER1_WON);
                    break;

                case PongStatus.Player2_Scored:
                    _flashCount = FLASH_COUNT;
                    _flashInterval = FLASH_INTERVAL;
                    _flashState = true;
                    _status = PongStatus.Player2_Scored_Flash;
                    break;

                case PongStatus.Player2_Scored_Flash:
                    if (--_flashInterval < 0)
                    {
                        if (--_flashCount < 0) _status = PongStatus.Ball_Launch;
                        else
                        {
                            _scorePlayer2_On = !_scorePlayer2_On;
                            _flashInterval = FLASH_INTERVAL;
                        }
                    }
                    break;

                case PongStatus.Player2_Wins:
                    SetPlayMode(false);
                    _status = PongStatus.Player2_Won;
                    break;

                case PongStatus.Player2_Won:
                    DrawMessage(g, MESSAGE_PLAYER2_WON);
                    break;
            }

            if (drawBall) g.FillEllipse(_ballBrush, _ballRect);
        }

        private void DrawMessage(Graphics g, string message)
        {
            if (_messageFont != null)
            {
                _messageFont.Dispose();
                _messageFont = null;
            }

            int fontSize;
            float factorX = this.DisplayRectangle.Width / TOTALFIELD_WIDTH;
            float factorY = this.DisplayRectangle.Height / TOTALFIELD_HEIGHT;

            if (factorX < factorY) fontSize = (int)(factorX * MESSAGE_FONT_SIZE);
            else fontSize = (int)(factorY * MESSAGE_FONT_SIZE);

            if (fontSize < 12) fontSize = 12;
            else if (fontSize > 96) fontSize = 96;

            _messageFont = new Font(this.Font.FontFamily, fontSize, FontStyle.Bold);
            TextRenderer.DrawText(g, message, _messageFont, _playfieldRect, MESSAGE_TEXT_COLOR, _messageFlags);
        }

        #endregion

        // ******************************** Pong Movement

        #region Movement

        // used with start, pause and stop playing
        private void SetPlayMode(bool play)
        {
            if (play)
            {
                if (!_playing)
                {
                    Cursor.Hide();
                    Cursor.Position = this.PointToScreen(new Point(_rightPaddleRect.X, _rightPaddleRect.Y + (_rightPaddleRect.Height / 2)));
                    Cursor.Clip = this.RectangleToScreen(this.DisplayRectangle);
                    this.MouseMove += Pong_MouseMove;
                    _playing = true;
                }
            }
            else
            {
                if (_playing)
                {
                    this.MouseMove -= Pong_MouseMove;
                    Cursor.Clip = Rectangle.Empty;
                    Cursor.Show();
                    _playing = false;
                }
            }
        }

        // set difficulty (speed)
        //private void SetDifficulty(PongSpeed difficulty)
        //{
        //    if (difficulty != _difficulty)
        //    {
        //        float scaleX = _totalfieldRect.Width / TOTALFIELD_WIDTH;
        //        float scaleY = _totalfieldRect.Height / TOTALFIELD_HEIGHT;

        //        _difficulty = difficulty;
        //        switch (_difficulty)
        //        {
        //            case PongSpeed.Slow:
        //                _basePaddleSpeed = PADDLE_SPEED_SLOW;
        //                _baseBallSpeed_X = BALL_SPEED_SLOW_X;
        //                _baseBallSpeed_Y = BALL_SPEED_SLOW_Y;
        //                break;

        //            case PongSpeed.Normal:
        //                _basePaddleSpeed = PADDLE_SPEED_NORMAL;
        //                _baseBallSpeed_X = BALL_SPEED_NORMAL_X;
        //                _baseBallSpeed_Y = BALL_SPEED_NORMAL_Y;
        //                break;

        //            case PongSpeed.Fast:
        //                _basePaddleSpeed = PADDLE_SPEED_FAST;
        //                _baseBallSpeed_X = BALL_SPEED_FAST_X;
        //                _baseBallSpeed_Y = BALL_SPEED_FAST_Y;
        //                break;

        //            case PongSpeed.Ultra:
        //                _basePaddleSpeed = PADDLE_SPEED_ULTRA;
        //                _baseBallSpeed_X = BALL_SPEED_ULTRA_X;
        //                _baseBallSpeed_Y = BALL_SPEED_ULTRA_Y;
        //                break;
        //        }

        //        // computer paddle speed - TODO increasing paddle speed like this makes computer 'invincible'
        //        //_paddleSpeed = (int)(_basePaddleSpeed * scaleY * ((float)PADDLE_HEIGHT / _leftPaddleRect.Height));
        //        //if (_paddleSpeed < 1) _paddleSpeed = 1;
        //        _paddleSpeed = (int)_basePaddleSpeed;

        //        // ball speed (preserve direction)
        //        _ballSpeed_X = (int)(scaleX * _baseBallSpeed_X) * (_ballSpeed_X < 0 ? -1 : 1);
        //        _ballSpeed_Y = (int)(scaleY * _baseBallSpeed_Y) * (_ballSpeed_Y < 0 ? -1 : 1);
        //    }
        //}

        private void SetPlayField()
        {
            // old _totalfieldRect (for relative changes from previous size)
            float newScaleX = ((float)this.DisplayRectangle.Width / _totalfieldRect.Width);
            float newScaleY = ((float)this.DisplayRectangle.Height / _totalfieldRect.Height);

            // new _totalfieldRect (for relative changes from begin size)
            _totalfieldRect = this.DisplayRectangle;
            int centerX = _totalfieldRect.Width / 2;
            float scaleX = _totalfieldRect.Width / TOTALFIELD_WIDTH;
            float scaleY = _totalfieldRect.Height / TOTALFIELD_HEIGHT;

            // playfield
            _playfieldRect = this.DisplayRectangle;
            _playfieldRect.X += PADDLE_MARGIN;
            _playfieldRect.Width -= PADDLE_MARGIN * 2;

            // border rectangle
            _borderRect = Rectangle.Inflate(_totalfieldRect, -1, -1);

            // score text
            _scorePosition1 = centerX - 40;
            _scorePosition2 = centerX + 40;

            // center line
            _centerLineTop.X = centerX;
            _centerLineTop.Y = 20;

            _centerLineBottom.X = _centerLineTop.X;
            _centerLineBottom.Y = _totalfieldRect.Height - 20;

            // paddles x location
            _rightPaddleRect.X = _totalfieldRect.Width - PADDLE_MARGIN;

            // paddles height
            //_leftPaddleRect.Height = PADDLE_HEIGHT + (int)((scaleY) * PADDLE_STRETCH_SIZE);
            _leftPaddleRect.Height = PADDLE_BASE_SIZE + (int)((scaleY) * PADDLE_STRETCH_SIZE);
            _rightPaddleRect.Height = _leftPaddleRect.Height;
            _paddleSectionSize = _leftPaddleRect.Height / 5; // sections with different reflection angles

            // computer paddle speed - TODO increasing paddle speed like this makes computer 'invincible'
            //_paddleSpeed = (int)(_basePaddleSpeed * scaleY * ((float)PADDLE_HEIGHT / _leftPaddleRect.Height));
            //if (_paddleSpeed < 1) _paddleSpeed = 1;
            _paddleSpeed = (int)_basePaddleSpeed;

            // paddles y location
            _leftPaddleRect.Y = (int)Math.Round(_leftPaddleRect.Y * newScaleY);
            _rightPaddleRect.Y = (int)Math.Round(_rightPaddleRect.Y * newScaleY);

            // ball location
            _ballRect.X = (int)Math.Round(_ballRect.X * newScaleX);
            _ballRect.Y = (int)Math.Round(_ballRect.Y * newScaleY);

            // ball speed (preserve direction)
            _ballSpeed_X = (int)(scaleX * _baseBallSpeed_X) * (_ballSpeed_X < 0 ? -1 : 1);
            _ballSpeed_Y = (int)(scaleY * _baseBallSpeed_Y) * (_ballSpeed_Y < 0 ? -1 : 1);

            // adjust mouse clip rectangle
            if (_playing) Cursor.Clip = this.RectangleToScreen(this.DisplayRectangle);
        }

        private void MoveBall()
        {
            int diff;

            // move ball
            _ballRect.X += _ballSpeed_X;
            _ballRect.Y += _ballSpeed_Y;

            // move left paddle
            if (_ballSpeed_X < 0)
            {
                //diff = (_leftPaddleRect.Y + (_leftPaddleRect.Height / 2)) - (_ballRect.Y + (_ballRect.Height / 2));
                //if (_leftPaddleRect.Y < _ballRect.Y) diff = (_leftPaddleRect.Y + 30) - (_ballRect.Y + (_ballRect.Height / 2));
                if (_ballSpeed_Y < 0) diff = (_leftPaddleRect.Y + 30) - (_ballRect.Y + (_ballRect.Height / 2));
                else diff = (_leftPaddleRect.Y + (_leftPaddleRect.Height - 30)) - (_ballRect.Y + (_ballRect.Height / 2));
                if (diff < -_paddleSpeed) _leftPaddleRect.Y += _paddleSpeed;
                else if (diff > _paddleSpeed) _leftPaddleRect.Y -= _paddleSpeed;
                else _leftPaddleRect.Y -= diff;
                if (_leftPaddleRect.Y < 0) _leftPaddleRect.Y = 0;
                else if (_leftPaddleRect.Y + _leftPaddleRect.Height > _playfieldRect.Height) _leftPaddleRect.Y = _playfieldRect.Height - _leftPaddleRect.Height;
            }
            else // move to the middle
            {
                diff = (_leftPaddleRect.Y + (_leftPaddleRect.Height / 2)) - (_playfieldRect.Height / 2);
                if (diff < -_paddleSpeed) _leftPaddleRect.Y += _paddleSpeed;
                else if (diff > _paddleSpeed) _leftPaddleRect.Y -= _paddleSpeed;
                else _leftPaddleRect.Y -= diff;
            }

            // move right paddle
            //if (_ballSpeed_X > 0)
            //{
            //    diff = (_rightPaddleRect.Y + (_rightPaddleRect.Height / 2)) - (_ballRect.Y + (_ballRect.Height / 2));
            //    if (diff < -_paddleSpeed) _rightPaddleRect.Y += _paddleSpeed;
            //    else if (diff > _paddleSpeed) _rightPaddleRect.Y -= _paddleSpeed;
            //    else _rightPaddleRect.Y -= diff;
            //    if (_rightPaddleRect.Y < 0) _rightPaddleRect.Y = 0;
            //    else if (_rightPaddleRect.Y + _rightPaddleRect.Height > _playfieldRect.Height) _rightPaddleRect.Y = _playfieldRect.Height - _rightPaddleRect.Height;
            //}
            //else // move to the middle
            //{
            //    diff = (_rightPaddleRect.Y + (_rightPaddleRect.Height / 2) + 10) - (_playfieldRect.Height / 2);
            //    if (diff < -_paddleSpeed) _rightPaddleRect.Y += _paddleSpeed;
            //    else if (diff > _paddleSpeed) _rightPaddleRect.Y -= _paddleSpeed;
            //    else _rightPaddleRect.Y -= diff;
            //}

            if (_ballSpeed_X < 0) // check left side
            {
                if (_ballRect.X + _ballRect.Width <= _playfieldRect.Left)  // ball passed paddle
                {
                    if (_ballRect.X + _ballRect.Width <= _totalfieldRect.Left) // ball passed playfield edge
                    {
                        _scorePlayer2++;
                        if (_scorePlayer2 >= MAX_SCORE) _status = PongStatus.Player2_Wins;
                        else _status = PongStatus.Player2_Scored;
                    }
                }
                else if (_ballRect.X <= _playfieldRect.Left) // check ball paddle collision
                {
                    int hitSpot = _ballRect.Y + BALL_SIZE_HALF;
                    if (hitSpot >= (_leftPaddleRect.Y - BALL_SIZE_HALF) && hitSpot <= (_leftPaddleRect.Y + _leftPaddleRect.Height + BALL_SIZE_HALF))
                    {
                        _ballSpeed_X = -_ballSpeed_X;
                        _ballRect.X = _playfieldRect.Left;

                        if (hitSpot <= _leftPaddleRect.Y + _paddleSectionSize)
                        {
                            _ballSpeed_Y -= 4;
                            if (_ballSpeed_Y < -8) _ballSpeed_Y = -8;
                        }
                        else if (hitSpot <= _leftPaddleRect.Y + (2 * _paddleSectionSize))
                        {
                            _ballSpeed_Y -= 2;
                            if (_ballSpeed_Y < -8) _ballSpeed_Y = -8;
                        }
                        else if (hitSpot <= _leftPaddleRect.Y + (3 * _paddleSectionSize))
                        {
                        }
                        else if (hitSpot <= _leftPaddleRect.Y + (4 * _paddleSectionSize))
                        {
                            _ballSpeed_Y += 2;
                            if (_ballSpeed_Y > 8) _ballSpeed_Y = 8;
                        }
                        else
                        {
                            _ballSpeed_Y += 4;
                            if (_ballSpeed_Y > 8) _ballSpeed_Y = 8;
                        }
                    }
                }
            }
            else // check right side
            {
                if (_ballRect.X >= _playfieldRect.Right) // ball passed paddle
                {
                    if (_ballRect.X >= _totalfieldRect.Right) // ball passed playfield edge
                    {
                        _scorePlayer1++;
                        if (_scorePlayer1 >= MAX_SCORE) _status = PongStatus.Player1_Wins;
                        else _status = PongStatus.Player1_Scored;
                    }
                }
                else if (_ballRect.X >= _playfieldRect.Right - _ballRect.Width) // check ball paddle collision
                {
                    int hitSpot = _ballRect.Y + BALL_SIZE_HALF;
                    if (hitSpot >= (_rightPaddleRect.Y - BALL_SIZE_HALF) && hitSpot <= (_rightPaddleRect.Y + _rightPaddleRect.Height + BALL_SIZE_HALF))
                    {
                        _ballSpeed_X = -_ballSpeed_X;
                        _ballRect.X = _playfieldRect.Right - _ballRect.Width;

                        if (hitSpot <= _rightPaddleRect.Y + _paddleSectionSize)
                        {
                            _ballSpeed_Y -= 4;
                            if (_ballSpeed_Y < -8) _ballSpeed_Y = -8;
                        }
                        else if (hitSpot <= _rightPaddleRect.Y + (2 * _paddleSectionSize))
                        {
                            _ballSpeed_Y -= 2;
                            if (_ballSpeed_Y < -8) _ballSpeed_Y = -8;
                        }
                        else if (hitSpot <= _rightPaddleRect.Y + (3 * _paddleSectionSize))
                        {
                        }
                        else if (hitSpot <= _rightPaddleRect.Y + (4 * _paddleSectionSize))
                        {
                            _ballSpeed_Y += 2;
                            if (_ballSpeed_Y > 8) _ballSpeed_Y = 8;
                        }
                        else
                        {
                            _ballSpeed_Y += 4;
                            if (_ballSpeed_Y > 8) _ballSpeed_Y = 8;
                        }
                    }
                }
            }

            if (_status == PongStatus.Playing)
            {
                if (_ballSpeed_Y < 0)
                {
                    if (_ballRect.Y <= _playfieldRect.Top)
                    {
                        _ballSpeed_Y = -_ballSpeed_Y;
                        _ballRect.Y = _playfieldRect.Top;
                    }
                }
                else
                {
                    if (_ballRect.Y >= _playfieldRect.Bottom - _ballRect.Height)
                    {
                        _ballSpeed_Y = -_ballSpeed_Y;
                        _ballRect.Y = _playfieldRect.Bottom - _ballRect.Height;
                    }
                }
            }
        }

        #endregion

    }
}
