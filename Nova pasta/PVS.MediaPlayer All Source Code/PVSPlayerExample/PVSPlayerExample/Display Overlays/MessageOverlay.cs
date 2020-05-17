#region Usings

using PVS.MediaPlayer;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

#endregion

namespace PVSPlayerExample
{
    public sealed partial class MessageOverlay : Form, IOverlay
    {
        /*
        
        PVS.MediaPlayer Display Overlay - Example 'Message'
        Displays a text message.

        The message is split into separate words (centerTextLabel) - use underscore (_) to insert a non breaking space to
        keep words together - and (as a whole) is scrolled at the bottom of the overlay (scrollingTextLabel).
        
        */

        // ******************************** Fields

        #region Fields

        private MainWindow          _baseForm;
        private Player              _basePlayer;

        private enum GradientColor
        {
            Rainbow1,
            Rainbow2,
            Gold,
            Silver,
            Black
        }
        private GradientColor       _gradientColor = GradientColor.Rainbow2;

        private const string        DEFAULT_MESSAGE = "You_can display anything you_want on_top_of a_movie with_a pvs_player overlay.";
        private const int           TIMER_INTERVAL = 50;

        private Color               _theColor; // the color used for text or background
        private bool                _randomColor = true; // if true, a new random color is set everytime the message repeats
        private bool                _randomOpacity; // if true, a new random opacity is set everytime the message repeats
        private bool                _backTransparency = true; // if true the background is transparent, otherwise the text is

        private bool                _outlineOn = true; // text outline
        private int                 _outlineWidth = 4;
        private StringFormat        _outlineFormat;

        private string[]            _message; // holds the message split into words
        private int                 _messageIndex; // indicates which word of the message to display
        private int                 _scrollingPixels = 3; // (adjustable) pixel movement of scrolling (bottom) text
            
        private Timer               _timer;
        private int                 _timerCount;

        private Random              _random; // random number generator

        // Used with linear gradient text
        private bool                _gradientOn = true;
        private bool                _gradientVertical;
        private RectangleF          _textRect;
        private SizeF               _textSize;
        private LinearGradientBrush _textBrush;
        private ColorBlend          _textBlend;

        private bool                _disposed;
        double                      _saveOpacity;
        bool                        _firstColor = true;

        #endregion

        // ******************************** Initialize & Form event handling

        #region Initialize & Form event handling

        // Main
        public MessageOverlay(MainWindow baseForm, Player basePlayer)
        {
            InitializeComponent();
            //SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            _baseForm   = baseForm;
            _basePlayer = basePlayer;

            // Pass on drag and drop to main form (handled in source file: DragDrop.cs):
            AllowDrop = true;
            DragDrop += _baseForm.Form1_DragDrop;

            _random = new Random();

            _textSize = new SizeF();
            _textRect = new RectangleF(0, 0, 10, 10);
            _textBlend = new ColorBlend();
            _textBrush = new LinearGradientBrush(_textRect, Color.Black, Color.Black, 0, false);

            _outlineFormat = new StringFormat();
            _outlineFormat.Alignment = StringAlignment.Center;
            _outlineFormat.LineAlignment = StringAlignment.Center;

            SetMessage();

            _timer = new Timer();
            _timer.Tick += TimerTick;
            _timer.Interval = TIMER_INTERVAL;
        }

        // Don't activate form when shown
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

        // Gets called when the overlay is shown or hidden
        private void Form1_VisibleChanged(object sender, EventArgs e)
        {
            // No need for a running timer when the overlay is not visible
            if (Visible)
            {
                // this if for dragging the display
                MouseDown                       += _basePlayer.Display.Drag_MouseDown;
                centerTextLabel.MouseDown       += _basePlayer.Display.Drag_MouseDown;
                scrollingTextLabel.MouseDown    += _basePlayer.Display.Drag_MouseDown;

                _timer.Start();

                _basePlayer.Overlay.Blend       = OverlayBlend.Transparent;
            }
            else
            {
                _timer.Stop();

                MouseDown                       -= _basePlayer.Display.Drag_MouseDown;
                centerTextLabel.MouseDown       -= _basePlayer.Display.Drag_MouseDown;
                scrollingTextLabel.MouseDown    -= _basePlayer.Display.Drag_MouseDown;

                _basePlayer.Overlay.Blend       = OverlayBlend.None;
            }
        }

        // Gets called when centerTextLabel needs to be redrawn
        private void CenterTextLabel_SizeChanged(object sender, EventArgs e)
        {
            SetFontSize();
        }

        private void CenterTextLabel_Paint(object sender, PaintEventArgs e)
        {
            if ((_gradientOn || _outlineOn) && _messageIndex < _message.Length)
            {
                _textSize = e.Graphics.MeasureString(_message[_messageIndex], centerTextLabel.Font);
                float top = (centerTextLabel.Height - (int)_textSize.Height) / 2;
                float left = (centerTextLabel.Width - (int)_textSize.Width) / 2;

                if (_gradientVertical)
                {
                    _textRect.X = top;
                    _textRect.Y = left;
                    _textRect.Height = _textSize.Width;
                    _textRect.Width = _textSize.Height;
                }
                else
                {
                    _textRect.X = left;
                    _textRect.Y = top;
                    _textRect.Height = _textSize.Height;
                    _textRect.Width = _textSize.Width;
                }
                SetGradientBrush(_gradientColor);

                e.Graphics.InterpolationMode = InterpolationMode.High;
                e.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

                if (_outlineOn)
                {
                    GraphicsPath path = new GraphicsPath();
                    //path.AddString(_message[_messageIndex], centerTextLabel.Font.FontFamily, (int)centerTextLabel.Font.Style, centerTextLabel.Font.Size * 1.3f, centerTextLabel.ClientRectangle, StringFormat.GenericDefault);
                    path.AddString(_message[_messageIndex], centerTextLabel.Font.FontFamily, (int)centerTextLabel.Font.Style, centerTextLabel.Font.Size * 1.3f, centerTextLabel.ClientRectangle, _outlineFormat);
                    e.Graphics.DrawPath(new Pen(centerTextLabel.ForeColor, _outlineWidth), path);
                    if (_gradientOn) e.Graphics.FillPath(_textBrush, path);
                    else e.Graphics.FillPath(new SolidBrush(centerTextLabel.BackColor), path);
                    path.Dispose();
                }
                else
                {
                    e.Graphics.DrawString(_message[_messageIndex], centerTextLabel.Font, _textBrush, left, top);
                }
            }
            else
            {
                if (_messageIndex < _message.Length)
                {
                    SolidBrush b = new SolidBrush(centerTextLabel.ForeColor);
                    e.Graphics.DrawString(_message[_messageIndex], centerTextLabel.Font, b, centerTextLabel.Width / 2, centerTextLabel.Height / 2, _outlineFormat);
                    b.Dispose();
                }
            }
        }

        // Dispose
        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _timer.Dispose(); _timer = null;
                    _textBrush.Dispose(); _textBrush = null;
                    _outlineFormat.Dispose(); _outlineFormat = null;

                    DragDrop -= _baseForm.Form1_DragDrop;

                    if (components != null) components.Dispose();
                }
                _disposed = true;
            }
            base.Dispose(disposing);
        }

        #endregion

        // ******************************** Timer tick handler

        #region Timer tick handler

        // Refresh the display of the message
        void TimerTick(object sender, EventArgs e)
        {
            if (centerTextLabel.Visible)
            {
                if (++_timerCount > 22)
                {
                    _timerCount = 0;
                    if (_messageIndex >= _message.Length)
                    {
                        // end of main message, display 'empty string' (pause)
                        if (_gradientOn) centerTextLabel.Refresh();
                        else centerTextLabel.Text = string.Empty;
                        centerTextLabel.Text = string.Empty;
                        SetColor();
                        _messageIndex = 0;
                    }
                    else
                    {
                        //if (_gradientOn || _outlineOn)
                        {
                            // display next word of main message as gradient and/or outline text
                            centerTextLabel.Refresh();
                            _messageIndex++;
                        }
                        //else
                        //{
                        //    // display next word of main message in the label
                        //    //centerTextLabel.Text = _message[_messageIndex++];
                        //}
                    }
                }
            }

            if (scrollingTextLabel.Visible)
            {
                // scroll the secondary (bottom) message
                scrollingTextLabel.Left -= _scrollingPixels;
                if (scrollingTextLabel.Left < -scrollingTextLabel.Width)
                {
                    scrollingTextLabel.Left = Width;
                    if (!centerTextLabel.Visible) SetColor();
                }

            }
        }

        #endregion

        // ******************************** Set Message, Font and Color

        #region Set Message, Font and Color

        // Set Message button
        private void SetButton_Click(object sender, EventArgs e)
        {
            SetMessage();
        }

        // Set message to display
        private void SetMessage()
        {
            // remove excess spaces...
            string text = Regex.Replace(textBox1.Text.Trim(), @"\s+", " ");
            if (text.Length < 2) text = DEFAULT_MESSAGE;
            textBox1.Text = text;

            // ... and replace underscore by non-breaking-space
            text = text.Replace('_', '\xA0');

            // Split the message into words
            _message = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            centerTextLabel.Text = string.Empty;
            SetFontSize();
            SetColor();
            _messageIndex = 0;
            if (!_gradientOn && !_outlineOn) centerTextLabel.Text = _message[0];
            else centerTextLabel.Refresh();

            scrollingTextLabel.Left = Width;
            scrollingTextLabel.Text = Regex.Replace(text, @"\s+", " ");

            textBox1.Focus();
            textBox1.SelectAll();
        }

        // Calculate 'fitting' fontsize
        private void SetFontSize()
        {
            Graphics g = centerTextLabel.CreateGraphics();
            Font theFont = centerTextLabel.Font;
            float fontSize;
            SizeF stringSize = new Size(0, 0);
            string longestWord = "";
            float theWidth = 0;
            //float theHeight = 0;

            // get true longest word
            for (int i = 0; i < _message.Length; i++)
            {
                // add a small letter for a save margin
                string testWord = _message[i] + "i";
                stringSize = g.MeasureString(testWord, centerTextLabel.Font);
                if (stringSize.Width > theWidth)
                {
                    theWidth = stringSize.Width;
                    //theHeight = stringSize.Height;
                    longestWord = testWord;
                }
            }

            float hRatio = centerTextLabel.Height / (stringSize.Height);
            float wRatio = centerTextLabel.Width / (stringSize.Width);
            float ratio = (hRatio < wRatio) ? hRatio : wRatio;

            do
            {
                fontSize = theFont.Size * ratio;
                if (fontSize < 6) fontSize = 6;
                centerTextLabel.Font = new Font(theFont.FontFamily, fontSize, theFont.Style);
                stringSize = g.MeasureString(longestWord, centerTextLabel.Font);
                ratio -= 0.01F;
            }
            while (fontSize > 6 && (stringSize.Width >= centerTextLabel.Width || stringSize.Height >= centerTextLabel.Height));

            g.Dispose();
        }

        // Set color of message / background
        private void SetColor()
        {
            int red, red1;
            int green;
            int blue;

            if (_firstColor)
            {
                _firstColor = false;
                red = red1 = 179;
                green = 173;
                blue = 146;
            }
            else
            {
                red1 = _random.Next(0, 255);
                if (_randomColor)
                {
                    // generate random color
                    red = red1;
                    green = _random.Next(0, 255);
                    blue = _random.Next(0, 255);
                }
                else
                {
                    // use selected color
                    red = _theColor.R;
                    green = _theColor.G;
                    blue = _theColor.B;
                }
            }

            if (_backTransparency)
            {
                // the background is transparent:
                centerTextLabel.ForeColor = Color.FromArgb(red, green, blue);
                scrollingTextLabel.ForeColor = Color.FromArgb(red, green, blue);

                // Use a backcolor close to the forecolor to avoid 'edges' around letters.
                red = (red > 253) ? red - 2 : red + 2;
                green = (green > 253) ? green - 2 : green + 2;
                blue = (blue > 253) ? blue - 2 : blue + 2;

                // This may sometimes cause a 'flicker' on screen, should have a second look at it...
                //this.TransparencyKey = this.BackColor = Color.FromArgb(red, green, blue);

                if (TransparencyKey != Color.FromArgb(red, green, blue))
                {
                    // With this the colors do not flicker but sometimes the input controls do, maybe a little bit less worse?
                    if (!_randomOpacity) _saveOpacity = Opacity;
                    Opacity = 0;
                    TransparencyKey = BackColor = Color.FromArgb(red, green, blue);
                    Application.DoEvents();
                    if (!_randomOpacity) Opacity = _saveOpacity;
                }
            }
            else
            {
                // the text is transparent:
                centerTextLabel.ForeColor = Color.RosyBrown;
                scrollingTextLabel.ForeColor = Color.RosyBrown;

                BackColor = Color.FromArgb(red, green, blue);
                TransparencyKey = Color.RosyBrown;
            }

            if (_randomOpacity)
            {
                Opacity = red1 < 128 ? 0.5 : 1;
            }
        }

        #endregion

        #region Linear gradient text

        private void SetGradientBrush(GradientColor color)
        {
            _textBrush.Dispose();
            _textBrush = new LinearGradientBrush(_textRect, Color.Black, Color.Black, 0, false);

            switch (color)
            {
                case GradientColor.Rainbow1:
                case GradientColor.Rainbow2:
                    _textBlend.Positions = _gradientVertical ? new[] { 0, 2 / 6f, 2.5f / 6f, 3 / 6f, 3.5f / 6f, 4f / 6f, 1 } : new[] { 0, 1 / 6f, 2 / 6f, 3 / 6f, 4 / 6f, 5 / 6f, 1 };
                    _textBlend.Colors = new[] { Color.Red, Color.Orange, Color.Yellow, Color.Green, Color.Blue, Color.Indigo, Color.Violet };
                    break;
                case GradientColor.Gold:
                    _textBlend.Positions = new[] { 0, 1.5f / 4f, 2f / 4f, 2.5f / 4f, 1 };
                    _textBlend.Colors = new[] { Color.DarkGoldenrod, Color.Goldenrod, Color.PaleGoldenrod, Color.Goldenrod, Color.DarkGoldenrod };
                    break;
                case GradientColor.Silver:
                    _textBlend.Positions = new[] { 0, 1.5f / 4f, 2f / 4f, 2.5f / 4f, 1 };
                    _textBlend.Colors = new[] { Color.DimGray, Color.Gray, Color.White, Color.Gray, Color.DimGray };
                    break;
                case GradientColor.Black:
                    _textBlend.Positions = new[] { 0, 1f / 2f, 1 };
                    _textBlend.Colors = new[] { Color.Black, Color.DimGray, Color.Black };
                    break;
            }

            _textBrush.InterpolationColors = _textBlend;
            if (_gradientVertical) _textBrush.RotateTransform(90);
        }

        #endregion

        // ******************************** IOverlay Control

        #region IOverlay Control

        // The visibility of the menu is controlled by the user from the main application (in this example application)
        public bool MenuEnabled
        {
            get {return messagePanel.Visible; }
            set { messagePanel.Visible = value; }
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

        // ******************************** Handle Options Menu items

        #region Handle Options Menu items

        // When closed set focus to text input
        private void OptionsMenu_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            textBox1.Focus();
        }

        // Show Text
        private void AllTextMenuItem_Click(object sender, EventArgs e)
        {
            if (!allTextMenuItem.Checked)
            {
                allTextMenuItem.Checked = true;
                showCenterTextMenuItem.Checked = false;
                showBottomTextMenuItem.Checked = false;

                if (!centerTextLabel.Visible)
                {
                    _timerCount = 0;
                    _messageIndex = 0;
                    centerTextLabel.Visible = true;
                }

                if (!scrollingTextLabel.Visible)
                {
                    scrollingTextLabel.Left = Width;
                    scrollingTextLabel.Visible = true;
                }

                Invalidate();
            }
        }

        private void ShowCenterTextMenuItem_Click(object sender, EventArgs e)
        {
            if (!showCenterTextMenuItem.Checked)
            {
                if (!centerTextLabel.Visible)
                {
                    _timerCount = 0;
                    _messageIndex = 0;
                }

                allTextMenuItem.Checked = false;
                centerTextLabel.Visible = showCenterTextMenuItem.Checked = true;
                scrollingTextLabel.Visible = showBottomTextMenuItem.Checked = false;

                Invalidate();
            }
        }

        private void ShowBottomTextMenuItem_Click(object sender, EventArgs e)
        {
            if (!showBottomTextMenuItem.Checked)
            {
                if (!scrollingTextLabel.Visible) scrollingTextLabel.Left = Width;

                allTextMenuItem.Checked = false;
                centerTextLabel.Visible = showCenterTextMenuItem.Checked = false;
                scrollingTextLabel.Visible = showBottomTextMenuItem.Checked = true;

                Invalidate();
            }
        }

        // Font...
        private void SetFont_MenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog1 = new FontDialog {Font = scrollingTextLabel.Font};
            if (fontDialog1.ShowDialog(this) == DialogResult.OK)
            {
                centerTextLabel.Font = fontDialog1.Font;
                scrollingTextLabel.Font = fontDialog1.Font;
                scrollingTextLabel.Font = new Font(fontDialog1.Font.FontFamily, 20, fontDialog1.Font.Style);
                SetFontSize();
            }
            fontDialog1.Dispose();

        }

        // Outline
        #region Outline

        private void CheckOutlineMenu(object sender, bool setOn)
        {
            foreach (ToolStripItem item in (outlinedMenuItem.DropDown.Items))
            {
                if (item.GetType() == typeof(ToolStripMenuItem))
                {
                    ((ToolStripMenuItem)item).Checked = item == sender;
                }
            }

            if (_messageIndex > 0) _messageIndex--;
            if (setOn)
            {
                if (!_outlineOn)
                {
                    outlinedMenuItem.Checked = true;
                    centerTextLabel.Text = string.Empty;
                    _outlineOn = true;
                }
                centerTextLabel.Refresh();
            }
            else if (_outlineOn)
            {
                _outlineOn = false;
                outlinedMenuItem.Checked = false;
                //if (_gradientOn) centerTextLabel.Refresh();
                //else centerTextLabel.Text = _message[_messageIndex];*
                centerTextLabel.Refresh();
            }
        }

        private void Pixels2MenuItem_Click(object sender, EventArgs e)
        {
            _outlineWidth = 2;
            CheckOutlineMenu(sender, true);
        }

        private void Pixels4MenuItem_Click(object sender, EventArgs e)
        {
            _outlineWidth = 4;
            CheckOutlineMenu(sender, true);
        }

        private void Pixels8MenuItem_Click(object sender, EventArgs e)
        {
            _outlineWidth = 8;
            CheckOutlineMenu(sender, true);
        }

        private void Pixels12MenuItem_Click(object sender, EventArgs e)
        {
            _outlineWidth = 12;
            CheckOutlineMenu(sender, true);
        }

        private void Pixels16MenuItem_Click(object sender, EventArgs e)
        {
            _outlineWidth = 16;
            CheckOutlineMenu(sender, true);
        }

        private void Pixels24MenuItem_Click(object sender, EventArgs e)
        {
            _outlineWidth = 24;
            CheckOutlineMenu(sender, true);
        }

        private void OutlineOffMenuItem_Click(object sender, EventArgs e)
        {
            CheckOutlineMenu(sender, false);
        }

        #endregion

        // Color...
        private void FixedColor_MenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog1 = new ColorDialog {Color = scrollingTextLabel.ForeColor};
            if (colorDialog1.ShowDialog(this) == DialogResult.OK)
            {
                fixedColor_MenuItem.Checked = true;
                _randomColor = randomColor_MenuItem.Checked = false;

                _theColor = colorDialog1.Color;
                SetColor();
                if (_outlineOn || _gradientOn)
                {
                    if (_messageIndex > 0) _messageIndex--;
                    centerTextLabel.Refresh();
                }
            }
            colorDialog1.Dispose();
        }

        // Random Color
        private void RandomColorMenuItem_Click(object sender, EventArgs e)
        {
            fixedColor_MenuItem.Checked = false;
            _randomColor = randomColor_MenuItem.Checked = true;
            SetColor();
            if (_outlineOn || _gradientOn)
            {
                if (_messageIndex > 0) _messageIndex--;
                centerTextLabel.Refresh();
            }
        }

        // Gradient
        #region Gradient

        private void CheckGradientMenu(object sender, bool setOn)
        {
            foreach (ToolStripItem item in (gradientMenuItem.DropDown.Items))
            {
                if (item.GetType() == typeof(ToolStripMenuItem))
                {
                    ((ToolStripMenuItem)item).Checked = item == sender;
                }
            }

            if (_messageIndex > 0) _messageIndex--;
            if (setOn)
            {
                if (!_gradientOn)
                {
                    gradientMenuItem.Checked = true;
                    centerTextLabel.Text = string.Empty;
                    _gradientOn = true;
                }
                centerTextLabel.Refresh();
            }
            else if (_gradientOn)
            {
                _gradientOn = false;
                gradientMenuItem.Checked = false;
                //if (_outlineOn) centerTextLabel.Refresh();
                //else centerTextLabel.Text = _message[_messageIndex];
                centerTextLabel.Refresh();
            }
        }

        private void Rainbow1MenuItem_Click(object sender, EventArgs e)
        {
            CheckGradientMenu(sender, true);

            _gradientColor = GradientColor.Rainbow1;
            _gradientVertical = true;
            centerTextLabel.Refresh();
        }

        private void Rainbow2MenuItem_Click(object sender, EventArgs e)
        {
            _gradientColor = GradientColor.Rainbow2;
            _gradientVertical = false;
            CheckGradientMenu(sender, true);
        }

        private void GoldMenuItem_Click(object sender, EventArgs e)
        {
            _gradientColor = GradientColor.Gold;
            _gradientVertical = true;
            CheckGradientMenu(sender, true);
        }

        private void SilverMenuItem_Click(object sender, EventArgs e)
        {
            _gradientColor = GradientColor.Silver;
            _gradientVertical = true;
            CheckGradientMenu(sender, true);
        }

        private void BlackMenuItem_Click(object sender, EventArgs e)
        {
            _gradientColor = GradientColor.Black;
            _gradientVertical = true;
            CheckGradientMenu(sender, true);
        }

        private void GradientOffMenuItem_Click(object sender, EventArgs e)
        {
            CheckGradientMenu(sender, false);
        }

        #endregion

        // Opacity
        #region Opacity

        // Opacity 25%
        private void Opacity25_MenuItem_Click(object sender, EventArgs e)
        {
            Opacity = 0.25;
            SetOpacityMenu(sender);
        }

        // Opacity 50%
        private void Opacity50_MenuItem_Click(object sender, EventArgs e)
        {
            Opacity = 0.50;
            SetOpacityMenu(sender);
        }

        // Opacity 75%
        private void Opacity75_MenuItem_Click(object sender, EventArgs e)
        {
            Opacity = 0.75;
            SetOpacityMenu(sender);
        }

        // Opacity 100%
        private void Opacity100_MenuItem_Click(object sender, EventArgs e)
        {
            Opacity = 1;
            SetOpacityMenu(sender);
        }

        // Opacity Random
        private void RandomOpacity_MenuItem_Click(object sender, EventArgs e)
        {
            SetOpacityMenu(sender);
            _randomOpacity = opacityMenuItem.Checked = true;
        }

        // Checks the selected Opacity menu item and removes the check marks from the others
        private void SetOpacityMenu(object sender)
        {
            foreach (ToolStripItem item in (((ToolStripMenuItem)sender).GetCurrentParent().Items))
            {
                if (item.GetType() == typeof(ToolStripMenuItem))
                {
                    ((ToolStripMenuItem)item).Checked = item == sender;
                }
            }
            _randomOpacity = false;
            opacityMenuItem.Checked = (Opacity != 1);
        }

        #endregion

        // Invert Transparency
        private void InvertTransparency_MenuItem_Click(object sender, EventArgs e)
        {
            _backTransparency = !_backTransparency;
            SetColor();
        }

        #endregion

    }
}
