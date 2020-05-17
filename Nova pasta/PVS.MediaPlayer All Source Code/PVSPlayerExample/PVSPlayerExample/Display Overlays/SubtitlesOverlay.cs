#region Usings

using PVS.MediaPlayer;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Text;
using System.Windows.Forms;

#endregion

namespace PVSPlayerExample
{
    public sealed partial class SubtitlesOverlay : Form, IOverlay
    {
        /*
        
        PVS.MediaPlayer Display Overlay - Example 'Subtitles'

        */

        // ******************************** Fields

        #region Fields

        private const string    NO_SUBTITLES_TEXT       = "No Subtitles";
        private bool            SHOW_NO_SUBTITLES_TEXT  = true;

        private MainWindow      _baseForm;
        private Player          _basePlayer;

        private Pen             _outlinePen;
        private SolidBrush      _fillBrush;
        private SolidBrush      _backBrush;
        private SolidBrush      _backBrush2;

        private GraphicsPath    _path;
        private Matrix          _offsetMatrix;

        // subtitle font
        private Font            _theFont;
        private FontFamily      _fontFamily;
        private int             _fontStyle;
        private float           _emSize;
        private StringFormat    _stringFormat;
        private int             _autoSize           = 2;    // 0 = off, 1 = large, 2 = medium, 3 = small
        private int             _lineSpacing        = 6;    // custom line distance - value 5 to 12 (?)
        private int             _bottomMargin       = 12;   // distance from bottom
        private StringAlignment _alignment          = StringAlignment.Center;

        private bool            _background         = true; // text background none, shadow or fill
        private bool            _backgroundFill;
        private float           _backgroundHeight;

        private FontDialog      _fontDialog;
        private ColorDialog     _colorDialog;

        private Encoding        _encoding;
        private int             _timeShift;

        // subtitle current
        private string          _currentText        = "";
        private string[]        _splitString        = { "\r\n" };

        // Interface
        private bool            _interfaceEnabled   = true;

        // subtitle selector
        private bool            _subtitleSelectorOn;
        private bool            _selectorLineNumbers = true;
        private double          _saveOpacity;
        private Color           _saveBackColor;
        private int             _searchStartIndex;
        private int             _searchStringIndex;
        private bool            _searchNextMode;
        private bool            _searchColorMode;

        private bool            _disposed;

        #endregion

        // ******************************** Initialize & Form event handling (VisibleChanged, Paint and others) & Dispose

        #region Initialize & Form event handling & Dispose

        public SubtitlesOverlay(MainWindow baseForm, Player thePlayer)
        {
            InitializeComponent();
            ((ToolStripDropDownMenu)synchronizingMenuItem.DropDown).ShowImageMargin = false;

            _baseForm                   = baseForm;
            _basePlayer                 = thePlayer;

            // Pass on drag and drop to main form (handled in source file: DragDrop.cs):
            AllowDrop                   = true;
            DragDrop                    += _baseForm.Form1_DragDrop;

            ResizeRedraw                = true;
            KeyPreview                  = true;

            _fontFamily                 = new FontFamily("Arial");
            _emSize                     = 18;
            _stringFormat               = StringFormat.GenericDefault;
            _stringFormat.Alignment     = StringAlignment.Center;
            _stringFormat.LineAlignment = StringAlignment.Center;
            _theFont                    = new Font(_fontFamily.Name, _emSize);

            _encoding                   = Encoding.Default;

            _path                       = new GraphicsPath();
            _offsetMatrix               = new Matrix();
            _offsetMatrix.Translate(-2.2F, -2.2F);

            _outlinePen                 = new Pen(Color.Black, 2.2f); // 2.2 - 2.4
            //outlinePen.LineJoin       = System.Drawing.Drawing2D.LineJoin.Round;
            _fillBrush                  = new SolidBrush(Color.White);
            _backBrush                  = new SolidBrush(Color.FromArgb(8, 8, 8)); // background shadow
            _backBrush2                 = new SolidBrush(Color.FromArgb(18, 18, 18)); // background fill
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

        // Gets called when the overlay is shown or hidden
        private void Form1_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                //MouseWheel += SubtitlesOverlay_MouseWheel;
                MouseDown += _basePlayer.Display.Drag_MouseDown;
                if (_autoSize != 0) SetFontAutoSize();

                _basePlayer.Events.MediaStarted += Events_MediaStarted;
                _basePlayer.Events.MediaSubtitleChanged += Events_MediaSubtitleChanged;
                SetInterface(false);
            }
            else
            {
                try
                {
                    //MouseWheel -= SubtitlesOverlay_MouseWheel;
                    MouseDown -= _basePlayer.Display.Drag_MouseDown;

                    _basePlayer.Events.MediaStarted -= Events_MediaStarted;
                    _basePlayer.Events.MediaSubtitleChanged -= Events_MediaSubtitleChanged;
                    SetInterface(true);
                }
                catch { }
            }
        }

        // Autosize font
        private void SubtitlesOverlay_SizeChanged(object sender, EventArgs e)
        {
            if (_autoSize > 0) SetFontAutoSize();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (_currentText != "" && !_subtitleSelectorOn)
            {
                Graphics g = e.Graphics;

                //string[] lines = _currentText.Split('\r');
                string[] lines = _currentText.Split(_splitString, StringSplitOptions.None);
                int length = lines.Length;// - 1;

                g.SmoothingMode      = SmoothingMode.HighQuality;
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.InterpolationMode  = InterpolationMode.HighQualityBicubic;
                g.TextRenderingHint  = TextRenderingHint.ClearTypeGridFit;

                // should put this somewhere else (?):
                if (_background && _backgroundFill)
                {
                    _path.Reset();
                    _path.AddString("Ty", _fontFamily, _fontStyle, _emSize, new PointF(0, 0), _stringFormat);
                    _backgroundHeight = _path.GetBounds().Height;
                }

                for (int i = 0; i < length; ++i)
                {
                    // TODO: string measurement height rewrite (do 'real' measurement)
                    // seems to work reasonably well for now
                    _path.Reset();
                    if (_alignment == StringAlignment.Near)
                    {
                        _path.AddString(lines[i], _fontFamily, _fontStyle, _emSize, new PointF(ClientRectangle.Left + 24, ClientRectangle.Height - _bottomMargin - ((length - i) * (_emSize + _lineSpacing))), _stringFormat);
                    }
                    else if (_alignment == StringAlignment.Center)
                    {
                        _path.AddString(lines[i], _fontFamily, _fontStyle, _emSize, new PointF(ClientRectangle.Width / 2, ClientRectangle.Height - _bottomMargin - ((length - i) * (_emSize + _lineSpacing))), _stringFormat);
                    }
                    else
                    {
                        _path.AddString(lines[i], _fontFamily, _fontStyle, _emSize, new PointF(ClientRectangle.Right - 24, ClientRectangle.Height - _bottomMargin - ((length - i) * (_emSize + _lineSpacing))), _stringFormat);
                    }

                    if (_background)
                    {
                        if (_backgroundFill)
                        {
                            RectangleF r = _path.GetBounds();
                            r.Height = _backgroundHeight;
                            g.FillRectangle(_backBrush2, RectangleF.Inflate(r, 10, _lineSpacing));
                        }
                        else
                        {
                            g.FillPath(_backBrush, _path);
                            _path.Transform(_offsetMatrix);
                        }
                    }

                    g.DrawPath(_outlinePen, _path);
                    g.FillPath(_fillBrush, _path);
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.M)
            {
                _baseForm.overlayMenuMenuItem.PerformClick();
            }

            //switch (e.KeyCode)
            //{
            //    // show menu
            //    case Keys.M:
            //        _baseForm.overlayMenuMenuItem.PerformClick();
            //        e.Handled = true;
            //        break;
            //
            //    case Keys.Down:
            //    case Keys.Subtract:
            //    case Keys.OemMinus:
            //        if (_emSize > 10)
            //        {
            //            _emSize -= 0.5f;
            //            _theFont.Dispose();
            //            _theFont = new Font(_fontFamily.Name, _emSize, (FontStyle)_fontStyle);
            //            e.Handled = true;
            //        }
            //        break;
            //    case Keys.Up:
            //    case Keys.Add:
            //    case Keys.Oemplus:
            //        if (_emSize < 80)
            //        {
            //            _emSize += 0.5f;
            //            _theFont.Dispose();
            //            _theFont = new Font(_fontFamily.Name, _emSize, (FontStyle)_fontStyle);
            //            e.Handled = true;
            //        }
            //        break;
            //    case Keys.D0:
            //    case Keys.NumPad0:
            //        _fillBrush.Color = Color.White;
            //        e.Handled = true;
            //        break;
            //    case Keys.D1:
            //    case Keys.NumPad1:
            //        _fillBrush.Color = Color.Coral;
            //        e.Handled = true;
            //        break;
            //    case Keys.D2:
            //    case Keys.NumPad2:
            //        _fillBrush.Color = Color.Red;
            //        e.Handled = true;
            //        break;
            //    case Keys.D3:
            //    case Keys.NumPad3:
            //        _fillBrush.Color = Color.LightGreen;
            //        e.Handled = true;
            //        break;
            //    case Keys.D4:
            //    case Keys.NumPad4:
            //        _fillBrush.Color = Color.Green;
            //        e.Handled = true;
            //        break;
            //    case Keys.D5:
            //    case Keys.NumPad5:
            //        _fillBrush.Color = Color.CornflowerBlue;
            //        e.Handled = true;
            //        break;
            //    case Keys.D6:
            //    case Keys.NumPad6:
            //        _fillBrush.Color = Color.Blue;
            //        e.Handled = true;
            //        break;
            //    case Keys.D7:
            //    case Keys.NumPad7:
            //        _fillBrush.Color = Color.PaleGoldenrod;
            //        e.Handled = true;
            //        break;
            //    case Keys.D8:
            //    case Keys.NumPad8:
            //        _fillBrush.Color = Color.Yellow;
            //        e.Handled = true;
            //        break;
            //    case Keys.D9:
            //    case Keys.NumPad9:
            //        _fillBrush.Color = Color.DarkGoldenrod;
            //        e.Handled = true;
            //        break;
            //}

            //if (e.Handled)
            //{
            //    if (_autoSize != 0)
            //    {
            //        _autoSize = 0;
            //        SetAutoSizeMenu();
            //    }
            //    else Invalidate();
            //}
        }

        //private void SubtitlesOverlay_MouseWheel(object sender, MouseEventArgs e)
        //{
        //    if (e.Delta > 0)
        //    {
        //        if (_emSize < 80)
        //        {
        //            _emSize += 0.5f;
        //            if (_autoSize != 0)
        //            {
        //                _autoSize = 0;
        //                SetAutoSizeMenu();
        //            }
        //            else
        //            {
        //                _theFont.Dispose();
        //                _theFont = new Font(_fontFamily.Name, _emSize, (FontStyle)_fontStyle);
        //                Invalidate();
        //            }
        //        }
        //    }
        //    else
        //    {
        //        if (_emSize > 10)
        //        {
        //            _emSize -= 0.5f;
        //            if (_autoSize != 0)
        //            {
        //                _autoSize = 0;
        //                SetAutoSizeMenu();
        //            }
        //            else
        //            {
        //                _theFont.Dispose();
        //                _theFont = new Font(_fontFamily.Name, _emSize, (FontStyle)_fontStyle);
        //                Invalidate();
        //            }
        //        }
        //    }
        //}

        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                _disposed = true;
                if (disposing)
                {
                    SetInterface(true);

                    _theFont.Dispose(); _theFont = null;
                    _fontFamily.Dispose(); _fontFamily = null;

                    _outlinePen.Dispose(); _outlinePen = null;
                    _fillBrush.Dispose(); _fillBrush = null;
                    _backBrush.Dispose(); _backBrush = null;
                    _backBrush2.Dispose(); _backBrush2 = null;

                    _path.Dispose(); _path = null;
                    _offsetMatrix.Dispose(); _offsetMatrix = null;

                    DragDrop -= _baseForm.Form1_DragDrop;
                    _baseForm = null;
                    _basePlayer = null;

                    if (_fontDialog != null) { _fontDialog.Dispose(); _fontDialog = null; }
                    if (_colorDialog != null) { _colorDialog.Dispose(); _colorDialog = null; }

                    if (components != null) components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #endregion

        #region Player Events

        // Check for subtitles and set interface - media ended handled in IOverlay Control below
        private void Events_MediaStarted(object sender, EventArgs e)
        {
            SetInterface(false);
        }

        // Player subtitles eventhandler
        private void Events_MediaSubtitleChanged(object sender, SubtitleEventArgs e)
        {
            _currentText = e.Subtitle;
            Invalidate();
        }

        #endregion

        // ******************************** IOverlay Control

        #region IOverlay Control

        // The visibility of the menu is controlled by the user from the main application (in this example application)
        public bool MenuEnabled
        {
            get { return optionsPanel.Visible; }
            set
            {
                optionsPanel.Visible = value;
                if (!value && _subtitleSelectorOn)
                {
                    HideSubtitleSelector();
                }
            }
        }

        public bool HasMenu
        {
            get { return true; }
        }

        public void MediaStopped()
        {
            if (Visible) SetInterface(true);
        }

        #endregion

        // ******************************** SetInterface

        #region SetInterface

        // Set interface with subtitles on/off change
        private void SetInterface(bool disable)
        {
            if (disable || !_basePlayer.Subtitles.Present)
            {
                if (_interfaceEnabled)
                {
                    if (SHOW_NO_SUBTITLES_TEXT) _currentText = NO_SUBTITLES_TEXT;
                    else _currentText = "";

                    synchronizingMenuItem.Enabled = false;
                    synchronizingMenuItem.DropDown.Enabled = false;

                    _interfaceEnabled = false;
                }
                // reset text encoding
                _encoding = Encoding.Default;
                SetEncodingMenu(defaultEncodingMenuItem);
                // reset time shift
                SetTimeShift(-_timeShift);
                // close subtitle selector
                if (_subtitleSelectorOn) HideSubtitleSelector();

                if (disable) _basePlayer.Overlay.Blend = OverlayBlend.None;
                else _basePlayer.Overlay.Blend = OverlayBlend.Transparent;
            }
            else
            {
                //_currentText = "";
                _currentText = _basePlayer.Subtitles.GetText();

                synchronizingMenuItem.Enabled = true;
                synchronizingMenuItem.DropDown.Enabled = true;

                _interfaceEnabled = true;

                _basePlayer.Overlay.Blend = OverlayBlend.Transparent;
            }
            Invalidate();
        }

        #endregion

        // ******************************** Options menu handling

        #region Options menu handling

        #region Font

        private void FontMenuItem_Click(object sender, EventArgs e)
        {
            if (_fontDialog == null) _fontDialog = new FontDialog();

            _fontDialog.Font = _theFont;
            if (_fontDialog.ShowDialog(this) == DialogResult.OK)
            {
                bool autoOff = (int)_emSize != (int)_fontDialog.Font.Size;

                _fontFamily.Dispose();
                _fontFamily = _fontDialog.Font.FontFamily;
                _fontStyle = (int)_fontDialog.Font.Style;
                _emSize = _fontDialog.Font.Size;
                _theFont.Dispose();
                _theFont = new Font(_fontFamily.Name, _emSize, (FontStyle)_fontStyle);

                if (_autoSize > 0 && autoOff)
                {
                    _autoSize = 0;
                    SetAutoSizeMenu();
                }

                Invalidate();
            }
        }

        #endregion

        #region BackDrop

        private void FillBackMenuItem_Click(object sender, EventArgs e)
        {
            backgroundMenuItem.Checked = true;
            fillBackMenuItem.Checked = true;
            shadowBackMenuItem.Checked = false;
            offBackMenuItem.Checked = false;

            _background = true;
            _backgroundFill = true;

            if (_currentText != "") Invalidate();
        }

        private void ShadowBackMenuItem_Click(object sender, EventArgs e)
        {
            backgroundMenuItem.Checked = true;
            fillBackMenuItem.Checked = false;
            shadowBackMenuItem.Checked = true;
            offBackMenuItem.Checked = false;

            _background = true;
            _backgroundFill = false;

            if (_currentText != "") Invalidate();
        }

        private void OffBackMenuItem_Click(object sender, EventArgs e)
        {
            backgroundMenuItem.Checked = false;
            fillBackMenuItem.Checked = false;
            shadowBackMenuItem.Checked = false;
            offBackMenuItem.Checked = true;

            _background = false;

            if (_currentText != "") Invalidate();
        }

        #endregion

        #region AutoSize

        private void AutoSizeLargeMenuItem_Click(object sender, EventArgs e)
        {
            _autoSize = 1;
            SetAutoSizeMenu();
        }

        private void AutoSizeMediumMenuItem_Click(object sender, EventArgs e)
        {
            _autoSize = 2;
            SetAutoSizeMenu();
        }

        private void AutoSizeSmallMenuItem_Click(object sender, EventArgs e)
        {
            _autoSize = 3;
            SetAutoSizeMenu();
        }

        private void AutoSizeOffMenuItem_Click(object sender, EventArgs e)
        {
            _autoSize = 0;
            SetAutoSizeMenu();
        }

        private void SetAutoSizeMenu()
        {
            autoSizeLargeMenuItem.Checked   = false;
            autoSizeMediumMenuItem.Checked  = false;
            autoSizeSmallMenuItem.Checked   = false;
            autoSizeOffMenuItem.Checked     = false;
            autoSizeMenuItem.Checked        = true;

            switch (_autoSize)
            {
                case 1:
                    autoSizeLargeMenuItem.Checked = true;
                    break;
                case 2:
                    autoSizeMediumMenuItem.Checked = true;
                    break;
                case 3:
                    autoSizeSmallMenuItem.Checked = true;
                    break;
                default:
                    autoSizeOffMenuItem.Checked = true;
                    autoSizeMenuItem.Checked = false;
                    break;
            }
            if (_autoSize > 0) SetFontAutoSize();
        }

        private void SetFontAutoSize()
        {
            if (_autoSize > 0)
            {
                if (_autoSize == 1) _emSize = Width / 25;
                else if (_autoSize == 2) _emSize = Width / 35;
                else _emSize = Width / 45;
                if (_emSize < 6) _emSize = 6; // can't have zero

                _theFont.Dispose();
                _theFont = new Font(_fontFamily.Name, _emSize, (FontStyle)_fontStyle);
                Invalidate();
            }
        }

        #endregion

        #region Alignment

        private void LeftAlignMenuItem_Click(object sender, EventArgs e)
        {
            textAlignmentMenuItem.Checked = leftAlignMenuItem.Checked = true;
            centerAlignMenuItem.Checked = false;
            rightAlignMenuItem.Checked = false;
            _stringFormat.Alignment = _alignment = StringAlignment.Near;
            // with !_hasSubtitles the text "No Subtitles" is displayed
            Invalidate();

        }

        private void CenterAlignMenuItem_Click(object sender, EventArgs e)
        {
            textAlignmentMenuItem.Checked = leftAlignMenuItem.Checked = false;
            centerAlignMenuItem.Checked = true;
            rightAlignMenuItem.Checked = false;
            _stringFormat.Alignment = _alignment = StringAlignment.Center;
            Invalidate();
        }

        private void RightAlignMenuItem_Click(object sender, EventArgs e)
        {
            leftAlignMenuItem.Checked = false;
            centerAlignMenuItem.Checked = false;
            textAlignmentMenuItem.Checked = rightAlignMenuItem.Checked = true;
            _stringFormat.Alignment = _alignment = StringAlignment.Far;
            Invalidate();
        }

        #endregion

        #region Color

        private void TextColorMenuItem_Click(object sender, EventArgs e)
        {
            if (_colorDialog == null) _colorDialog = new ColorDialog();

            _colorDialog.Color = _fillBrush.Color;
            if (_colorDialog.ShowDialog(this) == DialogResult.OK)
            {
                _fillBrush.Color = _colorDialog.Color;
                if (_subtitleSelectorOn) subtitleListBox.ForeColor = _fillBrush.Color;
                else if (_currentText != "") Invalidate();
            }
        }

        private void BackColorMenuItem_Click(object sender, EventArgs e)
        {
            if (_colorDialog == null) _colorDialog = new ColorDialog();

            _colorDialog.Color = _backBrush.Color;
            if (_colorDialog.ShowDialog(this) == DialogResult.OK)
            {
                _backBrush.Color = _colorDialog.Color;
                _backBrush2.Color = _colorDialog.Color;

                if (_currentText != "") Invalidate();
            }
        }

        #endregion

        #region Opacity

        // Opacity 25%
        private void Opacity25_MenuItem_Click(object sender, EventArgs e)
        {
            SetOpacityMenu(sender, 0.25);
        }

        // Opacity 50%
        private void Opacity50_MenuItem_Click(object sender, EventArgs e)
        {
            SetOpacityMenu(sender, 0.50);
        }

        // Opacity 75%
        private void Opacity75_MenuItem_Click(object sender, EventArgs e)
        {
            SetOpacityMenu(sender, 0.75);
        }

        // Opacity 100%
        private void Opacity100_MenuItem_Click(object sender, EventArgs e)
        {
            SetOpacityMenu(sender, 1);
        }

        // Checks the selected Opacity menu item and removes the check marks from the others
        private void SetOpacityMenu(object sender, double opacity)
        {
            if (_subtitleSelectorOn) _saveOpacity = opacity;
            else Opacity = opacity;

            foreach (ToolStripItem item in (((ToolStripMenuItem)sender).GetCurrentParent().Items))
            {
                if (item.GetType() == typeof(ToolStripMenuItem))
                {
                    ((ToolStripMenuItem)item).Checked = item == sender;
                }
            }

            opacityMenuItem.Checked = (opacity != 1);
        }

        #endregion

        #region Text Encoding

        // Text Encoding
        private void ASCIIMenuItem_Click(object sender, EventArgs e)
        {
            _encoding = Encoding.ASCII;
            SetEncodingMenu(sender);
        }

        private void BigEndianMenuItem_Click(object sender, EventArgs e)
        {
            _encoding = Encoding.BigEndianUnicode;
            SetEncodingMenu(sender);
        }

        private void UnicodeMenuItem_Click(object sender, EventArgs e)
        {
            _encoding = Encoding.Unicode;
            SetEncodingMenu(sender);
        }

        private void UTF32MenuItem_Click(object sender, EventArgs e)
        {
            _encoding = Encoding.UTF32;
            SetEncodingMenu(sender);
        }

        private void UTF7MenuItem_Click(object sender, EventArgs e)
        {
            _encoding = Encoding.UTF7;
            SetEncodingMenu(sender);
        }

        private void UTF8MenuItem_Click(object sender, EventArgs e)
        {
            _encoding = Encoding.UTF8;
            SetEncodingMenu(sender);
        }

        private void DefaultMenuItem_Click(object sender, EventArgs e)
        {
            _encoding = Encoding.Default;
            SetEncodingMenu(sender);
        }

        // Check/Uncheck Text Encoding Menu items and reload text.
        private void SetEncodingMenu(object sender)
        {
            ToolStripDropDown theMenu = textEncodingMenuItem.DropDown;
            int last = textEncodingMenuItem.DropDown.Items.Count - 1;

            for (int i = 0; i <= last; i++)
            {
                if (theMenu.Items[i].GetType() == typeof(ToolStripMenuItem) && theMenu.Items[i] != null)
                {
                    ((ToolStripMenuItem)theMenu.Items[i]).Checked = theMenu.Items[i] == (ToolStripMenuItem)sender;
                }
            }
            _basePlayer.Subtitles.Encoding = _encoding;
        }

        #endregion

        #region Synchronize (Time Shift)

        // Adjust timing of subtitles
        // minus: results in the subtitles being displayed earlier
        // plus: results in the subtitles being displayed later

        // -0.1 sec
        private void Minus01SecondMenuItem_Click(object sender, EventArgs e)
        {
            SetTimeShift(-100);
        }

        // -0.5 sec
        private void Minus05SecondsMenuItem_Click(object sender, EventArgs e)
        {
            SetTimeShift(-500);
        }

        // -1.0 sec
        private void Minus10SecondMenuItem_Click(object sender, EventArgs e)
        {
            SetTimeShift(-1000);
        }

        // +0.1 sec
        private void Plus01SecondMenuItem_Click(object sender, EventArgs e)
        {
            SetTimeShift(100);
        }

        // +0.5 sec
        private void Plus05SecondsMenuItem_Click(object sender, EventArgs e)
        {
            SetTimeShift(500);
        }

        // +1.0 sec
        private void Plus10SecondMenuItem_Click(object sender, EventArgs e)
        {
            SetTimeShift(1000);
        }

        // Show/Hide Text Selector
        private void TextSelectorMenuItem_Click(object sender, EventArgs e)
        {
            if (_subtitleSelectorOn) HideSubtitleSelector();
            else ShowSubtitleSelector();
        }

        // reset time shift
        private void ResetMenuItem_Click(object sender, EventArgs e)
        {
            SetTimeShift(-_timeShift);
        }

        private void SetTimeShift(int millisec)
        {
            _timeShift += millisec;

            if (_timeShift == 0)
            {
                synchronizingMenuItem.ForeColor = minus05SecondsMenuItem.ForeColor;
                synchronizingMenuItem.Text = "Synchronization";
                synchronizingMenuItem.Checked = false;

                _basePlayer.Subtitles.TimeShift = 0;
            }
            else
            {
                synchronizingMenuItem.Checked = true;
                synchronizingMenuItem.ForeColor = Color.Red;
                synchronizingMenuItem.Text = (_timeShift / 1000.0).ToString("+ 0.0 ;- 0.0 ") + ((_timeShift != 1000 && _timeShift != -1000) ? "Seconds" : "Second");

                _basePlayer.Subtitles.TimeShift = _timeShift;
            }
        }

        #endregion

        #region Restore Default Settings

        private void RestoreDefaultSettingsMenuItem_Click(object sender, EventArgs e)
        {
            // Font
            _fontFamily.Dispose();
            _fontFamily = new FontFamily("Arial");
            try { _fontStyle = (int)FontStyle.Regular; }
            catch { /* ignore */ }
            _emSize = 18;
            _theFont.Dispose();
            _theFont = new Font(_fontFamily.Name, _emSize);

            // BackDrop
            shadowBackMenuItem.PerformClick();

            // AutoSize
            autoSizeMediumMenuItem.PerformClick();

            // Colors
            _fillBrush.Color = Color.White; // text color
            _backBrush.Color = Color.FromArgb(8, 8, 8); // backdrop shadow
            _backBrush2.Color = Color.FromArgb(18, 18, 18); // backdrop fill

            // Opacity
            opacity100MenuItem.PerformClick();

            // Text Encoding
            defaultEncodingMenuItem.PerformClick();

            // Alignment
            //centerAlignMenuItem.PerformClick();

            // Synchronize
            //resetMenuItem.PerformClick();

            if (_currentText != "") Invalidate();
        }

        #endregion

        #endregion

        // ******************************** Subtitle Selector

        #region Subtitle Selector

        // Show (+ Init) / Hide (+ Clean Up) Subtitle Selector

        private void ShowSubtitleSelector()
        {
            if (!_basePlayer.Subtitles.Present || _subtitleSelectorOn) return;

            findSetButton.Enabled = false;

            subtitleListBox.SuspendLayout();
            subtitleListBox.ForeColor = _fillBrush.Color;

            // fill the listbox
            int itemCount = _basePlayer.Subtitles.Count;
            if (_selectorLineNumbers)
            {
                string formatString = new string('0', itemCount.ToString().Length) + ": ";
                _searchStringIndex = formatString.Length;
                for (int i = 0; i < itemCount; ++i)
                {
                    //subtitleListBox.Items.Add((i + 1).ToString(formatString) + _basePlayer.Subtitles.GetText(i).Replace('\r', ' '));
                    subtitleListBox.Items.Add((i + 1).ToString(formatString) + _basePlayer.Subtitles.GetText(i).Replace("\r\n", " "));
                }
            }
            else
            {
                _searchStringIndex = 0;
                for (int i = 0; i < itemCount; ++i)
                {
                    //subtitleListBox.Items.Add(_basePlayer.Subtitles.GetText(i).Replace('\r', ' '));
                    subtitleListBox.Items.Add(_basePlayer.Subtitles.GetText(i).Replace("\r\n", " "));
                }
            }

            // hide current subtitle
            _currentText = "";
            Invalidate();

            // set overlay backcolor and opacity
            _saveOpacity = Opacity;
            _saveBackColor = BackColor;
            BackColor = subtitleListBox.BackColor;
            Opacity = 0.6;

            // show the listbox and OK & Cancel Buttons
            findPanel1.Visible = findPanel2.Visible = subtitleListBox.Visible = _subtitleSelectorOn = true;
            subtitleSelectorMenuItem.Text = "Hide Subtitle Selector";

            // ... and set the top item
            subtitleListBox.Focus();
            subtitleListBox.TopIndex = _basePlayer.Subtitles.Current; //_currentSubtitle; // listbox has to be visible (and focused?) for this

            // enable set button when item selected
            subtitleListBox.SelectedIndexChanged += SubtitleListBox_SelectedIndexChanged;

            _basePlayer.Overlay.Blend = OverlayBlend.Opaque;
        }

        private void HideSubtitleSelector()
        {
            if (!_subtitleSelectorOn) return;

            findPanel1.Visible = findPanel2.Visible = subtitleListBox.Visible = _subtitleSelectorOn = false;
            subtitleListBox.SelectedIndexChanged -= SubtitleListBox_SelectedIndexChanged;

            subtitleListBox.Items.Clear();
            subtitleSelectorMenuItem.Text = "Show Subtitle Selector";
            findTextBox.Clear();
            SetFindButtonText(false, false);

            Opacity = _saveOpacity;
            BackColor = _saveBackColor;
            Invalidate();

            _basePlayer.Overlay.Blend = OverlayBlend.Transparent;
        }

        // Find / Set Subtitle

        private void FindSubtitle()
        {
            findTextBox.Text = findTextBox.Text.Trim();

            // not disabling find button -for 'readabilty'- so:
            if (findTextBox.Text.Length == 0) return;

            int itemCount = subtitleListBox.Items.Count;
            bool found = false;

            for (int i = _searchStartIndex; i < itemCount; ++i)
            {
                if (((string)subtitleListBox.Items[i]).IndexOf(findTextBox.Text, _searchStringIndex, StringComparison.OrdinalIgnoreCase) != -1)
                {
                    found = true;

                    subtitleListBox.SelectedIndex = i;
                    if (i > 2) subtitleListBox.TopIndex = i - 3;
                    else subtitleListBox.TopIndex = i;
                    _searchStartIndex = i + 1;

                    break;
                }
            }

            if (!found) System.Media.SystemSounds.Hand.Play();

            SetFindButtonText(found, true);
        }

        private void SetSubtitle()
        {
            if (subtitleListBox.SelectedIndex != -1)
            {
                _timeShift = 0;
                _basePlayer.Subtitles.TimeShift = 0;
                SetTimeShift((int)(_basePlayer.Position.FromBegin.TotalMilliseconds - _basePlayer.Subtitles.GetStartTime(subtitleListBox.SelectedIndex).TotalMilliseconds));

                //SetTimeShift(((int)(_basePlayer.Position.FromBegin.TotalMilliseconds - _basePlayer.Subtitles.GetStartTime(subtitleListBox.SelectedIndex).TotalMilliseconds)) + oldShift);
            }
        }

        // Button handling:

        private void FindSetButton_Click(object sender, EventArgs e)
        {
            SetSubtitle();
            HideSubtitleSelector();
        }

        private void FindCancelButton_Click(object sender, EventArgs e)
        {
            HideSubtitleSelector();
        }

        private void FindButton_Click(object sender, EventArgs e)
        {
            FindSubtitle();
        }

        // Event handling:

        private void SubtitleListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            findSetButton.Enabled = true;
        }

        private void FindTextBox_TextChanged(object sender, EventArgs e)
        {
            // not disabling find button - 'for readabilty'
            //findButton.Enabled = findTextBox.Text.Length != 0;
            if (_searchNextMode || _searchColorMode) SetFindButtonText(false, false);
        }

        private void FindTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                findButton.PerformClick();
                findTextBox.Focus();
            }
        }

        // Set Find Button text and input text color:

        private void SetFindButtonText(bool next, bool setColor)
        {
            if (next)
            {
                if (!_searchNextMode)
                {
                    findButton.Text = "Find Next";
                    findTextBox.ForeColor = Color.Lime;
                    _searchNextMode = _searchColorMode = true;
                }
            }
            else
            {
                if (_searchNextMode)
                {
                    _searchStartIndex = 0;
                    findButton.Text = "Find";
                    _searchNextMode = false;
                }
                findTextBox.ForeColor = setColor ? Color.Red : findButton.ForeColor;
                _searchColorMode = setColor;
            }
            Application.DoEvents();
        }

        #endregion

    }
}