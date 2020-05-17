#region Usings

using PVS.MediaPlayer;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

#endregion

namespace FolderView
{
    public partial class SubtitlesOverlay : Form
    {
        /*
        
        PVS.MediaPlayer Display Overlay - Example 'Subtitles'

        Displays subtitles from .srt files: the srt-files must have the same name as
        the playing mediafile (but with the extension .srt) and be in the same or an up to two levels deep subdirectory.

        This overlay does not yet use the subtitle option that is available in the PVS.MediaPlayer library (which is an improved version of this).
        
        */

        // ******************************** Fields

        #region Fields

        private Player          _basePlayer;

        private Pen             _outlinePen;
        private SolidBrush      _fillBrush;
        private SolidBrush      _backBrush;
        private SolidBrush      _backBrush2;

        private GraphicsPath    _path;
        private Matrix          _offsetMatrix;

        // susbtitle font
        private Font            _theFont;
        private FontFamily      _fontFamily;
        private int             _fontStyle;
        private float           _emSize;
        private StringFormat    _stringFormat;
        private int             _autoSize = 2; // 0 = off, 1 = large, 2 = medium, 3 = small

        private bool            _background = true; // text background none, shadow or fill
        private bool            _backgroundFill;
        private float           _backgroundHeight;

        private FontDialog      _fontDialog;
        private ColorDialog     _colorDialog;

        private DataTable       _subtitleItems;
        private bool            _hasSubtitles;

        private Encoding        _encoding;

        // subtitle current
        private bool            _subtitleOn;
        private int             _currentSubtitle;
        private double          _currentStart;
        private double          _currentEnd;
        private string          _currentText = "";

        private static readonly Regex TimeRegex = new Regex("(?<start>[0-9:,]+) --> (?<end>[0-9:,]+)", RegexOptions.Compiled);
        private static readonly Regex TagsRegex = new Regex("<.*?>", RegexOptions.Compiled);

        // subtitles timing
        private Timer           _subtitleTimer;
        private double          _lastPosition;
        private double          _timeShift; // adjust timing of subtitles

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

        public SubtitlesOverlay(Player thePlayer)
        {
            InitializeComponent();
            _basePlayer = thePlayer;

            ((ToolStripDropDownMenu)synchronizingMenuItem.DropDown).ShowImageMargin = false;

            ResizeRedraw = true;
            //KeyPreview = true;

            _fontFamily = new FontFamily("Arial");
            //fontStyle = (int)FontStyle.Regular; // can cause an error if it does not exist
            _emSize = 18;
            _stringFormat = StringFormat.GenericDefault;
            _stringFormat.Alignment = StringAlignment.Center;
            _stringFormat.LineAlignment = StringAlignment.Center;
            _theFont = new Font(_fontFamily.Name, _emSize);

            _encoding = Encoding.Default;

            _path = new GraphicsPath();
            _offsetMatrix = new Matrix();
            _offsetMatrix.Translate(-2.2F, -2.2F);

            _outlinePen = new Pen(Color.Black, 2.2f); // 2.2 - 2.4
            //outlinePen.LineJoin = System.Drawing.Drawing2D.LineJoin.Round;
            _fillBrush = new SolidBrush(Color.White);
            _backBrush = new SolidBrush(Color.FromArgb(8, 8, 8)); // background shadow
            _backBrush2 = new SolidBrush(Color.FromArgb(18, 18, 18)); // background fill

            _subtitleItems = new DataTable();
            _subtitleItems.Columns.Add("Id", typeof(int));
            _subtitleItems.Columns.Add("BeginTime", typeof(double));
            _subtitleItems.Columns.Add("EndTime", typeof(double));
            _subtitleItems.Columns.Add("Text", typeof(string));

            _subtitleTimer = new Timer {Interval = 100};
            _subtitleTimer.Tick += SubtitleTimer_Tick;

            ResetSubtitles(true);
        }

        // Gets called when the overlay is shown or hidden
        private void Form1_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                _basePlayer.Events.MediaStarted += BasePlayer_MediaStarted;
                //MouseWheel += SubtitlesOverlay_MouseWheel;
                if (_autoSize != 0) SetFontAutoSize();
                if (_basePlayer.Playing) LoadSubtitles();
            }
            else
            {
                try
                {
                    _basePlayer.Events.MediaStarted -= BasePlayer_MediaStarted;
                    //MouseWheel -= SubtitlesOverlay_MouseWheel;
                    ResetSubtitles(true);
                }
                catch { }
            }
        }

        // Autosize font
        private void SubtitlesOverlay_SizeChanged(object sender, EventArgs e)
        {
            if (_autoSize > 0) SetFontAutoSize();
        }

        private void SubtitleTimer_Tick(object sender, EventArgs e)
        {
            // get player position + synchronize offset
            double position = _basePlayer.Position.FromBegin.TotalMilliseconds + _timeShift;

            if (position == _lastPosition) return;

            if (position < _lastPosition) _currentSubtitle = 0;
            _lastPosition = position;

            if (_subtitleOn)
            {
                if (position >= _currentStart && position < _currentEnd) return;
                ResetSubtitles(false);
            }

            int nextItem = FindSubtitle(position, _currentSubtitle);
            if (nextItem != -1)
            {
                _currentSubtitle = nextItem;
                _currentStart = (double)_subtitleItems.Rows[nextItem][1];
                _currentEnd = (double)_subtitleItems.Rows[nextItem][2];
                _currentText = (string)_subtitleItems.Rows[nextItem][3];
                _subtitleOn = true;
                Invalidate();
            }
        }

        private void BasePlayer_MediaStarted(object sender, EventArgs e)
        {
            LoadSubtitles();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (_currentText != "" && !_subtitleSelectorOn)
            {
                Graphics g = e.Graphics;

                string[] lines = _currentText.Split('\r');
                int length = lines.Length - 1;

                g.SmoothingMode = SmoothingMode.HighQuality;
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

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
                    _path.AddString(lines[i], _fontFamily, _fontStyle, _emSize, new PointF(ClientRectangle.Width / 2, ClientRectangle.Height - ((length - i) * (_emSize + 6))), _stringFormat);

                    if (_background)
                    {
                        if (_backgroundFill)
                        {
                            RectangleF r = _path.GetBounds();
                            r.Height = _backgroundHeight;
                            g.FillRectangle(_backBrush2, RectangleF.Inflate(r, 10, 5));
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

        //private void Form1_KeyDown(object sender, KeyEventArgs e)
        //{
        //    switch (e.KeyCode)
        //    {
        //        case Keys.Down:
        //        case Keys.Subtract:
        //        case Keys.OemMinus:
        //            if (_emSize > 10)
        //            {
        //                _emSize -= 0.5f;
        //                _theFont.Dispose();
        //                _theFont = new Font(_fontFamily.Name, _emSize, (FontStyle)_fontStyle);
        //                e.Handled = true;
        //            }
        //            break;
        //        case Keys.Up:
        //        case Keys.Add:
        //        case Keys.Oemplus:
        //            if (_emSize < 80)
        //            {
        //                _emSize += 0.5f;
        //                _theFont.Dispose();
        //                _theFont = new Font(_fontFamily.Name, _emSize, (FontStyle)_fontStyle);
        //                e.Handled = true;
        //            }
        //            break;
        //        case Keys.D0:
        //        case Keys.NumPad0:
        //            _fillBrush.Color = Color.White;
        //            e.Handled = true;
        //            break;
        //        case Keys.D1:
        //        case Keys.NumPad1:
        //            _fillBrush.Color = Color.Coral;
        //            e.Handled = true;
        //            break;
        //        case Keys.D2:
        //        case Keys.NumPad2:
        //            _fillBrush.Color = Color.Red;
        //            e.Handled = true;
        //            break;
        //        case Keys.D3:
        //        case Keys.NumPad3:
        //            _fillBrush.Color = Color.LightGreen;
        //            e.Handled = true;
        //            break;
        //        case Keys.D4:
        //        case Keys.NumPad4:
        //            _fillBrush.Color = Color.Green;
        //            e.Handled = true;
        //            break;
        //        case Keys.D5:
        //        case Keys.NumPad5:
        //            _fillBrush.Color = Color.CornflowerBlue;
        //            e.Handled = true;
        //            break;
        //        case Keys.D6:
        //        case Keys.NumPad6:
        //            _fillBrush.Color = Color.Blue;
        //            e.Handled = true;
        //            break;
        //        case Keys.D7:
        //        case Keys.NumPad7:
        //            _fillBrush.Color = Color.PaleGoldenrod;
        //            e.Handled = true;
        //            break;
        //        case Keys.D8:
        //        case Keys.NumPad8:
        //            _fillBrush.Color = Color.Yellow;
        //            e.Handled = true;
        //            break;
        //        case Keys.D9:
        //        case Keys.NumPad9:
        //            _fillBrush.Color = Color.DarkGoldenrod;
        //            e.Handled = true;
        //            break;
        //    }

        //    if (e.Handled)
        //    {
        //        if (_autoSize != 0)
        //        {
        //            _autoSize = 0;
        //            SetAutoSizeMenu();
        //        }
        //        else Invalidate();
        //    }
        //}

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
                if (disposing)
                {
                    try
                    {
                        _basePlayer.Events.MediaStarted -= BasePlayer_MediaStarted;
                    }
                    catch { }

                    ResetSubtitles(true);
                    _subtitleTimer.Dispose(); _subtitleTimer = null;

                    _theFont.Dispose(); _theFont = null;
                    _fontFamily.Dispose(); _fontFamily = null;

                    _outlinePen.Dispose(); _outlinePen = null;
                    _fillBrush.Dispose(); _fillBrush = null;
                    _backBrush.Dispose(); _backBrush = null;
                    _backBrush2.Dispose(); _backBrush2 = null;

                    _path.Dispose(); _path = null;
                    _offsetMatrix.Dispose(); _offsetMatrix = null;

                    if (_subtitleItems != null) _subtitleItems.Dispose();

                    _basePlayer = null;

                    if (_fontDialog != null) { _fontDialog.Dispose(); _fontDialog = null; }
                    if (_colorDialog != null) { _colorDialog.Dispose(); _colorDialog = null; }

                    if (components != null) components.Dispose();
                }
                _disposed = true;
                base.Dispose(disposing);
            }
        }

        #endregion

        // ******************************** LoadSubtitles / FindSubTitle / ResetSubTitles

        #region LoadSubtitles / FindSubtitle / ResetSubtitles

        private void LoadSubtitles()
        {
            ResetSubtitles(true);

            // check several paths for matching subtitles:
            string path = Globals.Subtitles.Find(_basePlayer.Media.GetName(MediaName.FileNameWithoutExtension) + ".srt", _basePlayer.Media.GetName(MediaName.DirectoryName), 3);
            if (!string.IsNullOrEmpty(path))
            {
                StreamReader reader = new StreamReader(path, _encoding, true);

                bool error = false;
                string line;
                int readStep = 0;
                string id = "";
                TimeSpan startTime = TimeSpan.Zero;
                TimeSpan endTime = TimeSpan.Zero;
                string text = "";

                // function adjusted to deal with multiple empty lines
                // that shouldn't be there, but sometimes just are (caused by multiple \r and/or \n after each other)

                while ((line = (reader.ReadLine())) != null && !error)
                {
                    line = line.Trim();
                    if (string.IsNullOrEmpty(line)) continue;

                    int testId;
                    switch (readStep)
                    {
                        case 0: // Id
                            if (int.TryParse(line, out testId))
                            {
                                id = line;
                                readStep = 1;
                            }
                            break;
                        case 1: // Time
                            Match m = TimeRegex.Match(line);
                            if (m.Success)
                            {
                                if (!TimeSpan.TryParse(m.Groups["start"].Value.Replace(",", "."), out startTime)) error = true;
                                if (!TimeSpan.TryParse(m.Groups["end"].Value.Replace(",", "."), out endTime)) error = true;
                            }
                            else error = true;
                            readStep = 2;
                            break;
                        case 2: // Text
                            if (int.TryParse(line, out testId))
                            {
                                _subtitleItems.Rows.Add(id, startTime.TotalMilliseconds, endTime.TotalMilliseconds, TagsRegex.Replace(text, string.Empty));
                                id = line;
                                text = "";
                                readStep = 1;
                            }
                            else text += line + '\r';
                            break;
                    }
                }
                if (text != "")
                {
                    _subtitleItems.Rows.Add(id, startTime.TotalMilliseconds, endTime.TotalMilliseconds, TagsRegex.Replace(text, string.Empty));
                }
                reader.Close();
                if (_subtitleItems.Rows.Count > 0 && !error)
                {
                    _hasSubtitles = true;
                    synchronizingMenuItem.Enabled = true;
                    synchronizingMenuItem.DropDown.Enabled = true;

                    _currentText = "";
                    Invalidate();
                    _subtitleTimer.Start();
                }
            }
        }

        private int FindSubtitle(double milliseconds, int startItem)
        {
            int result = -1;
            if (_hasSubtitles)
            {
                int itemCount = _subtitleItems.Rows.Count;
                for (int i = startItem; i < itemCount && result == -1; i++)
                {
                    if ((double)_subtitleItems.Rows[i][1] <= milliseconds && milliseconds < (double)_subtitleItems.Rows[i][2])
                    {
                        result = i;
                    }
                    else if (milliseconds < (double)_subtitleItems.Rows[i][1]) break;
                }
            }
            return result;
        }

        private void ResetSubtitles(bool full)
        {
            _subtitleOn = false;
            _currentStart = 0;
            _currentEnd = 0;

            if (full)
            {
                if (_subtitleTimer != null) _subtitleTimer.Stop();
                _lastPosition = 0;

                _subtitleItems.Clear();
                _currentSubtitle = 0;
                _currentText = "No Subtitles\r";

                _hasSubtitles = false;
                synchronizingMenuItem.Enabled = false;
                synchronizingMenuItem.DropDown.Enabled = false;

                SetTimeShift(-_timeShift);

                if (_subtitleSelectorOn) HideSubtitleSelector();
            }
            else
            {
                _currentText = "";
            }
            Invalidate();
        }

        #endregion

        // ******************************** Options menu handling

        #region Menu Enabled

        internal bool MenuEnabled
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

        #endregion

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
            autoSizeLargeMenuItem.Checked = false;
            autoSizeMediumMenuItem.Checked = false;
            autoSizeSmallMenuItem.Checked = false;
            autoSizeOffMenuItem.Checked = false;
            autoSizeMenuItem.Checked = true;

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
                if (_emSize < 16) _emSize = 16; // can't have zero or too small

                _theFont.Dispose();
                _theFont = new Font(_fontFamily.Name, _emSize, (FontStyle)_fontStyle);
                Invalidate();
            }
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
            LoadSubtitles();
            Invalidate();
        }

        #endregion

        #region Synchronize (Time Shift)

        // Adjust timing (shift start/end time) of subtitles
        // add: results in the subtitles being displayed earlier
        // subtract: results in the subtitles being displayed later

        // add 0.1 sec
        private void Add01SecondMenuItem_Click(object sender, EventArgs e)
        {
            SetTimeShift(100);
        }

        // add 0.5 sec
        private void AddSecondsMenuItem_Click(object sender, EventArgs e)
        {
            SetTimeShift(500);
        }

        // add 1.0 sec
        private void Add10SecondMenuItem_Click(object sender, EventArgs e)
        {
            SetTimeShift(1000);
        }

        // subtract 0.1 sec
        private void Subtract01SecondMenuItem_Click(object sender, EventArgs e)
        {
            SetTimeShift(-100);
        }

        // subtract 0.5 sec
        private void SubtractSecondsMenuItem_Click(object sender, EventArgs e)
        {
            SetTimeShift(-500);
        }

        // subtract 1.0 sec
        private void Subtract10SecondMenuItem_Click(object sender, EventArgs e)
        {
            SetTimeShift(-1000);
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

        private void SetTimeShift(double millisec)
        {
            _timeShift += millisec;
            if (_hasSubtitles) SubtitleTimer_Tick(this, null);

            if (_timeShift == 0)
            {
                synchronizingMenuItem.ForeColor = add05SecondsMenuItem.ForeColor;
                synchronizingMenuItem.Text = "Synchronization";
                synchronizingMenuItem.Checked = false;
            }
            else
            {
                synchronizingMenuItem.Checked = true;
                synchronizingMenuItem.ForeColor = Color.Red;
                synchronizingMenuItem.Text = (-_timeShift / 1000).ToString("+ 0.0 ;- 0.0 ") + ((_timeShift != 1000 && _timeShift != -1000) ? "Seconds" : "Second");
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
            if (!_hasSubtitles || _subtitleSelectorOn) return;

            findSetButton.Enabled = false;

            subtitleListBox.SuspendLayout();
            subtitleListBox.ForeColor = _fillBrush.Color;

            // fill the listbox
            int itemCount = _subtitleItems.Rows.Count;
            if (_selectorLineNumbers)
            {
                string formatString = new string('0', itemCount.ToString().Length) + ": ";
                _searchStringIndex = formatString.Length;
                for (int i = 0; i < itemCount; ++i)
                {
                    subtitleListBox.Items.Add((i + 1).ToString(formatString) + ((string)_subtitleItems.Rows[i][3]).Replace('\r', ' '));
                }
            }
            else
            {
                _searchStringIndex = 0;
                for (int i = 0; i < itemCount; ++i)
                {
                    subtitleListBox.Items.Add(((string)_subtitleItems.Rows[i][3]).Replace('\r', ' '));
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
            subtitleListBox.TopIndex = _currentSubtitle; // listbox has to be visible (and focused?) for this

            // enable set button when item selected
            subtitleListBox.SelectedIndexChanged += SubtitleListBox_SelectedIndexChanged;

            _basePlayer.CursorHide.Enabled = false;
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

            _basePlayer.CursorHide.Enabled = true;
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
                _timeShift = 0d;
                SetTimeShift((double)_subtitleItems.Rows[subtitleListBox.SelectedIndex][1] - _basePlayer.Position.FromStart.TotalMilliseconds);
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