#region Usings

using PVS.MediaPlayer;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

#endregion

namespace PVSPlayerExample
{
    public sealed partial class Mp3CoverOverlay : Form, IOverlay
    {
        /*
        
        PVS.MediaPlayer Display Overlay - Example 'MP3 Cover'
        Displays mp3/wma tag information.

        Some of the code for this overlay is a bit more complicated because the overlay has to be fully invisible
        when a movie (instead of an mp3) is being played and the background settings have to be remembered.
        
        */

        // ******************************** Fields

        #region Fields

        // Image(s) to use when metadata image is missing
        // random selection of images in the folder "Images" in the application's folder
        private const string        DEFAULT_IMAGES = @"Images\*.*"; // no file type check

        // The form and player
        private MainWindow          _baseForm;
        private Player              _basePlayer;

        // tag info
        private Metadata            _tagInfo;
        private Image               _cover;
        private ImageSource         _imageSource = ImageSource.MediaOrFolder;
        private Random              _random;

        // drawing
        private bool                _activeState;

        private bool                _menuOn;
        private bool                _reColor;
        private int                 _imageColor; // 0 = b/w, 1 = grayscale, 2 = sepia, 3 = inverse - (should be enum)

        private bool                _showText = true;
        private bool                _showImage = true;

        private bool                _hasBackImage;
        private bool                _hasHiddenBackImage;
        private string              _backImageName;
        private string              _backImagePath = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

        private Player              _backPlayer;
        private bool                _hasBackVideo;
        private TimeSpan            _backVideoPosition;
        private bool                _hasHiddenBackVideo;
        private string              _backVideoName;
        private string              _backVideoPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        private bool                _disposed;

        #endregion

        // ******************************** Initialize and Form and Player event handling

        #region Initialize and Form and Player event handling

        public Mp3CoverOverlay(MainWindow baseForm, Player basePlayer)
        {
            InitializeComponent();
            _baseForm = baseForm;
            _basePlayer = basePlayer;

            _random = new Random();

            // Pass on drag and drop to main form (handled in source file: DragDrop.cs):
            AllowDrop = true;
            DragDrop += _baseForm.Form1_DragDrop;

            optionsPanel.Visible = false;

            ResizeRedraw = true;
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

        private void MP3CoverOverlay_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                _basePlayer.Events.MediaStarted += BasePlayer_MediaStarted;
                MouseDown                       += _basePlayer.Display.Drag_MouseDown;
                topLabel.MouseDown              += _basePlayer.Display.Drag_MouseDown;
                imageBox1.MouseDown             += _basePlayer.Display.Drag_MouseDown;
                bottomLabel.MouseDown           += _basePlayer.Display.Drag_MouseDown;

                // event media stopped is passed on by main app in IOverlay control
                if (_basePlayer.Playing && !_basePlayer.Video.Present)
                {
                    SetActiveState(true);
                    //Width--; Width++; // used because of repaint problems
                }
                else SetActiveState(false);
            }
            else
            {
                _basePlayer.Events.MediaStarted -= BasePlayer_MediaStarted;
                MouseDown                       -= _basePlayer.Display.Drag_MouseDown;
                topLabel.MouseDown              -= _basePlayer.Display.Drag_MouseDown;
                imageBox1.MouseDown             -= _basePlayer.Display.Drag_MouseDown;
                bottomLabel.MouseDown           -= _basePlayer.Display.Drag_MouseDown;
                SetActiveState(false);
            }
        }

        // see also: iOverlay Control: MediaStopped
        void BasePlayer_MediaStarted(object sender, EventArgs e)
        {
            if (!_basePlayer.Video.Present)
            {
                SetActiveState(true);
                Width--; Width++; // used because of repaint problems - see method SetActiveState
            }
            else SetActiveState(false);
        }

        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_hasBackImage) RemoveBackImage(false);
                    if (_backPlayer != null) _backPlayer.Dispose();
                    if (_cover != null) _cover.Dispose();

                    DragDrop -= _baseForm.Form1_DragDrop;

                    _baseForm = null;
                    _basePlayer = null;

                    if (components != null) components.Dispose();
                }
                _disposed = true;
            }
            base.Dispose(disposing);
        }

        #endregion

        // ******************************** iOverlay Control

        #region iOverlay Control

        // The visibility of the menu is controlled by the user from the main application (in this example application)
        public bool MenuEnabled
        {
            get { return _menuOn; }
            set
            {
                _menuOn = value;
                if (_activeState) optionsPanel.Visible = value;
            }
        }

        public bool HasMenu
        {
            get { return true; }
        }

        // The main application signals player media has ended (before playing new media)
        // This 'construction' is to prevent this overlay missing the player's MediaEnded event
        // before a (new) MediaStarted event is fired
        public void MediaStopped()
        {
            if (Visible) SetActiveState(false);
        }

        #endregion

        // ******************************** Options Menu

        #region Options Menu

        // show text
        private void ShowTextMenuItem_Click(object sender, EventArgs e)
        {
            _showText = !_showText;
            topLabel.Visible = bottomLabel.Visible = _showText;
            showTextMenuItem.Checked = textFontMenuItem.Enabled = textColorMenuItem.Enabled = _showText;
        }

        // text font
        private void TextFontMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog { Font = topLabel.Font };
            if (fontDialog.ShowDialog(this) == DialogResult.OK)
            {
                float fontSize = fontDialog.Font.Size;
                if (fontSize > 48) fontSize = 48;
                else if (fontSize < 10) fontSize = 10;

                Font newFont = new Font(fontDialog.Font.FontFamily, fontSize, fontDialog.Font.Style);
                topLabel.Font = newFont;
                bottomLabel.Font = newFont;
            }
            fontDialog.Dispose();
        }

        // text color
        private void TextColorMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog {Color = topLabel.ForeColor};
            if (colorDialog.ShowDialog(this) == DialogResult.OK)
            {
                topLabel.ForeColor = bottomLabel.ForeColor = colorDialog.Color;
                if (!_hasBackVideo && !_hasHiddenBackVideo) TransparencyKey = Color.Empty;
            }
            colorDialog.Dispose();
        }

        // background color
        private void BackgroundColorMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog {Color = BackColor};
            if (colorDialog.ShowDialog(this) == DialogResult.OK)
            {
                if (_hasBackImage) RemoveBackImage(false);
                else if (_hasBackVideo) RemoveBackVideo(false);

                BackColor = colorDialog.Color;
                if (!_activeState) TransparencyKey = BackColor;

                SetBackgroundMenuCheckmarks(backgroundColorMenuItem);
            }
            colorDialog.Dispose();
        }

        // background image
        private void BackgroundImageMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = _backImagePath,
                Filter = "Images|*.bmp; *.jpg; *.jpeg; *.gif; *.tif; *.tiff; *.png|All Files|*.*"
            };

            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                _backImagePath = Path.GetDirectoryName(openFileDialog.FileName);
                _hasHiddenBackImage = false;
                SetBackImage(openFileDialog.FileName);

                SetBackgroundMenuCheckmarks(backgroundImageMenuItem);
            }
            openFileDialog.Dispose();
        }

        // background video
        private void BackgroundVideoMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = _backVideoPath,
                Filter = "Video|*.avi; *.divx; *.flv; *.h264; *.mp4; *.mpeg; *.mpeg4; *.mpg; *.wmv; *.xvid|All Files|*.*"
            };

            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                _backVideoPath = Path.GetDirectoryName(openFileDialog.FileName);
                _hasHiddenBackVideo = false;
                SetBackVideo(openFileDialog.FileName);

                SetBackgroundMenuCheckmarks(backgroundVideoMenuItem);
            }
            openFileDialog.Dispose();
        }

        private void SetBackgroundMenuCheckmarks(ToolStripMenuItem checkItem)
        {
            backgroundColorMenuItem.Checked = false;
            backgroundImageMenuItem.Checked = false;
            backgroundVideoMenuItem.Checked = false;

            checkItem.Checked = true;
        }

        // show cover image
        private void ShowImageMenuItem_Click(object sender, EventArgs e)
        {
            _showImage = !_showImage;
            imageBox1.Visible = _showImage;
            showImageMenuItem.Checked = coverSourceMenuItem.Enabled = coverColorMenuItem.Enabled = _showImage;
        }

        // cover (album art) source - enables to skip mp3 file embedded album art
        private void Mp3AndFolderMenuItem_Click(object sender, EventArgs e)
        {
            _imageSource = ImageSource.MediaOrFolder;
            mp3AndFolderMenuItem.Checked = true;
            mp3OnlyMenuItem.Checked = false;
            folderOnlyMenuItem.Checked = false;
            if (_activeState)
            {
                if (_cover != null)
                {
                    _cover.Dispose();
                    _cover = null;
                }
                GetInfo();
            }
        }

        private void Mp3OnlyMenuItem_Click(object sender, EventArgs e)
        {
            _imageSource = ImageSource.MediaOnly;
            mp3AndFolderMenuItem.Checked = false;
            mp3OnlyMenuItem.Checked = true;
            folderOnlyMenuItem.Checked = false;
            if (_activeState)
            {
                if (_cover != null)
                {
                    _cover.Dispose();
                    _cover = null;
                }
                GetInfo();
            }
        }

        private void FolderOnlyMenuItem_Click(object sender, EventArgs e)
        {
            _imageSource = ImageSource.FolderOnly;
            mp3AndFolderMenuItem.Checked = false;
            mp3OnlyMenuItem.Checked = false;
            folderOnlyMenuItem.Checked = true;
            if (_activeState)
            {
                if (_cover != null)
                {
                    _cover.Dispose();
                    _cover = null;
                }
                GetInfo();
            }
        }

        // cover (album art) color
        private void CoverBlackWhiteMenuItem_Click(object sender, EventArgs e)
        {
            _reColor = true;
            _imageColor = 0;
            SetCoverColorMenuCheckMarks((ToolStripMenuItem)sender);
        }

        private void CoverImageGrayScaleMenuItem_Click(object sender, EventArgs e)
        {
            _reColor = true;
            _imageColor = 1;
            SetCoverColorMenuCheckMarks((ToolStripMenuItem)sender);
        }

        private void CoverImageSepiaMenuItem_Click(object sender, EventArgs e)
        {
            _reColor = true;
            _imageColor = 2;
            SetCoverColorMenuCheckMarks((ToolStripMenuItem)sender);
        }

        private void CoverImageInverseMenuItem_Click(object sender, EventArgs e)
        {
            _reColor = true;
            _imageColor = 3;
            SetCoverColorMenuCheckMarks((ToolStripMenuItem)sender);
        }

        private void CoverImageNormalMenuItem_Click(object sender, EventArgs e)
        {
            _reColor = false;
            SetCoverColorMenuCheckMarks((ToolStripMenuItem)sender);
        }

        private void SetCoverColorMenuCheckMarks(ToolStripMenuItem checkItem)
        {
            coverBlackWhiteMenuItem.Checked = false;
            coverGrayscaleMenuItem.Checked = false;
            coverSepiaMenuItem.Checked = false;
            coverInverseMenuItem.Checked = false;
            coverNormalMenuItem.Checked = false;

            checkItem.Checked = true;
            if (_activeState) GetInfo();
        }

        // restore default colors
        private void RestoreDefaultsMenuItem_Click(object sender, EventArgs e)
        {
            SuspendLayout();

            if (_hasBackImage) RemoveBackImage(false);
            else if (_hasBackVideo) RemoveBackVideo(false);

            topLabel.ForeColor = bottomLabel.ForeColor = UIColors.MenuTextEnabledColor;
            topLabel.BackColor = bottomLabel.BackColor = imageBox1.BackColor = Color.Transparent;
            BackColor = Color.FromArgb(18, 18, 18);

            if (!_activeState) TransparencyKey = BackColor;

            _reColor = false;
            SetBackgroundMenuCheckmarks(backgroundColorMenuItem);
            SetCoverColorMenuCheckMarks(coverNormalMenuItem);

            ResumeLayout();
        }

        #endregion

        // ******************************** SetActiveState / GetInfo

        #region SetActiveState / GetInfo

        // Don't show overlay contents when a movie (main player) is playing
        private void SetActiveState(bool state)
        {
            if (state)
            {
                if (_hasHiddenBackImage) SetBackImage(_backImageName);
                else if (_hasHiddenBackVideo) SetBackVideo(_backVideoName);

                GetInfo();
                if (_menuOn && !optionsPanel.Visible) optionsPanel.Visible = true;

                if (_hasBackVideo) TransparencyKey = BackColor;
                else TransparencyKey = Color.RosyBrown;

                _activeState = true;
                Invalidate(true);
            }
            else if (_activeState)
            {
                topLabel.Text = string.Empty;
                bottomLabel.Text = string.Empty;

                if (_hasBackImage) RemoveBackImage(true);
                else if (_hasBackVideo) RemoveBackVideo(true);

                imageBox1.Image = null;
                if (_cover != null)
                {
                    _cover.Dispose();
                    _cover = null;
                }

                optionsPanel.Visible = false;
                TransparencyKey = BackColor;

                _activeState = false;

                Invalidate(true);
            }
        }

        // Get media tag info
        private void GetInfo()
        {
            if (_cover != null) _cover.Dispose();

            _tagInfo = _basePlayer.Media.GetMetadata(_imageSource);
            _cover = _tagInfo.Image; // by doing this we don't dispose _tagInfo but _cover (image)

            if (_cover == null) // if no cover image get an image from a special folder
            {
                try
                {
                    string[] files = Directory.GetFiles(Application.StartupPath, DEFAULT_IMAGES);
                    if (files != null)
                    {
                        int index = _random.Next(files.Length);
                        Image img = Image.FromFile(files[index]);
                        _cover = new Bitmap(img);
                        img.Dispose();
                    }
                }
                catch {}
                if (_cover == null) _cover = Properties.Resources.Media_Normal.ToBitmap();
            }

            if (_reColor) _cover = _cover = ReColorImage((Bitmap)_cover);

            SuspendLayout();

            if (string.IsNullOrEmpty(_tagInfo.Album)) topLabel.Text = _tagInfo.Artist;
            else if (string.IsNullOrEmpty(_tagInfo.Artist)) topLabel.Text = _tagInfo.Album;
            else topLabel.Text = _tagInfo.Artist + " - " + _tagInfo.Album;
            bottomLabel.Text = _tagInfo.Title;
            imageBox1.Image = _cover;

            ResumeLayout();
        }

        #endregion

        // ******************************** Recolor cover image

        #region Recolor cover image

        // Method by and thanks to: Brandon Cannaday, Stephen Toub and others
        private Bitmap ReColorImage(Bitmap original)
        {
            ColorMatrix colorMatrix;

            // create a new bitmap the same size as original
            Bitmap newBitmap = new Bitmap(original.Width, original.Height);

            // get a graphics object from the new image
            Graphics g = Graphics.FromImage(newBitmap);

            switch (_imageColor)
            {
                case 1: // Grayscale - Matrix of type float
                    colorMatrix = new ColorMatrix(new[]
                    {
                        new[] {.3f, .3f, .3f, 0, 0},
                        new[] {.59f, .59f, .59f, 0, 0},
                        new[] {.11f, .11f, .11f, 0, 0},
                        new[] {0f, 0f, 0f, 1f, 0f},
                        new[] {0f, 0f, 0f, 0f, 1f}
                    });
                    break;

                case 2: // Sepia - Matrix of type float
                    colorMatrix = new ColorMatrix(new[]
                    {
                        new[] {.393f, .349f, .272f, 0, 0},
                        new[] {.769f, .686f, .534f, 0, 0},
                        new[] {.189f, .168f, .131f, 0, 0},
                        new[] {0f, 0f, 0f, 1f, 0f},
                        new[] {0f, 0f, 0f, 0f, 1f}
                    });
                    break;

                case 3: // Inverse - Matrix of type float
                    colorMatrix = new ColorMatrix(new[]
                    {
                        new[] {-1f, 0f, 0f, 0f, 0f},
                        new[] {0f, -1f, 0f, 0f, 0f},
                        new[] {0f, 0f, -1f, 0f, 0f},
                        new[] {0f, 0f, 0f, 1f, 0f},
                        new[] {1f, 1f, 1f, 0f, 1f}
                    });
                    break;

                default: // Black & White - Matrix of type float
                    colorMatrix = new ColorMatrix(new[]
                    {
                        new[] {1.5f, 1.5f, 1.5f, 0f, 0f},
                        new[] {1.5f, 1.5f, 1.5f, 0f, 0f},
                        new[] {1.5f, 1.5f, 1.5f, 0f, 0f},
                        new[] {0f, 0f, 0f, 1f, 0f},
                        new[] {-1f, -1f, -1f, 0f, 1f}
                    });
                    break;
            }

            // create some image attributes
            ImageAttributes attributes = new ImageAttributes();

            // set the color matrix attribute
            attributes.SetColorMatrix(colorMatrix);

            // draw the original image on the new image using the color matrix
            g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height),
               0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attributes);

            // dispose the Graphics object
            g.Dispose();

            // dispose the original bitmap
            original.Dispose();

            return newBitmap;
        }

        #endregion

        // ******************************** Set / Remove background image

        #region Set / Remove background image

        private void SetBackImage(string fileName)
        {
            if (_hasBackImage) RemoveBackImage(false);
            else if (_hasBackVideo) RemoveBackVideo(false);

            try
            {
                BackgroundImage = new Bitmap(fileName);
                _backImageName = fileName;
                _hasBackImage = true;
            }
            catch { }
        }

        private void RemoveBackImage(bool hideOnly)
        {
            if (_hasBackImage)
            {
                BackgroundImage.Dispose();
                BackgroundImage = null;
                _hasBackImage = false;
            }
            _hasHiddenBackImage = hideOnly;
        }

        #endregion

        // ******************************** Set / Remove background video / Create background player

        // As this is not really a 'true' overlay (there's no movie playing 'underneath')
        // we can use the main player's (unused) display to show a background movie

        #region Set / Remove background video / Create background player

        private void SetBackVideo(string fileName)
        {
            if (_backPlayer == null) CreateBackPlayer();

            if (_hasBackImage) RemoveBackImage(false);

            if (_hasHiddenBackVideo) _backPlayer.Play(fileName, _backVideoPosition, TimeSpan.Zero);
            else _backPlayer.Play(fileName);

            if (_backPlayer.LastError || !_backPlayer.Video.Present)
            {
                _hasBackVideo = false;
            }
            else
            {
                BackColor = TransparencyKey = Color.RosyBrown;
                _backVideoName = fileName;
                if (_hasHiddenBackVideo) _backPlayer.Media.StartTime = TimeSpan.Zero; // reset startposition after continued from _backVideoPosition
                _hasBackVideo = true;
            }
            _hasHiddenBackVideo = false;
        }

        private void RemoveBackVideo(bool hideOnly)
        {
            if (_hasBackVideo)
            {
                _backVideoPosition = _backPlayer.Position.FromStart;
                _backPlayer.Stop();
                _hasBackVideo = false;
            }
            _hasHiddenBackVideo = hideOnly;

            if (!_hasHiddenBackVideo) TransparencyKey = Color.Empty;
        }

        private void CreateBackPlayer()
        {
            if (_backPlayer == null)
            {
                _backPlayer = new Player();
                _backPlayer.Display.Window = _basePlayer.Display.Window;
                _backPlayer.Display.Mode = DisplayMode.Stretch;
                _backPlayer.Audio.Mute = true;
                _backPlayer.Repeat = true;
            }
        }

        #endregion

    }
}
