#region Usings

using PVS.MediaPlayer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Serialization;

#endregion

namespace FolderView
{
    public partial class MainWindow : Form
    {
        /*
            PVS.MediaPlayer 0.99 Example Application - FolderView
            A simple movie folder viewer with 'live' media players.

            This example application shows the use of some of the methods and properties of
            the PVS.MediaPlayer library version 0.99 - licensed under The Code Project Open License (CPOL)
    
            PVS.MediaPlayer uses (part of) the Media Foundation .NET library by nowinskie and snarfle (https://sourceforge.net/projects/mfnet).
            Licensed under either Lesser General Public License v2.1 or BSD.  See license.txt or BSDL.txt for details (http://mfnet.sourceforge.net).

            A large part of the application's functionality is created by using Microsoft Visual Studio Designer.
    

            Many thanks to Microsoft (Windows, .NET Framework, Visual Studio, etc.), all the people
            writing about programming on the internet (a great source for ideas and solving problems),
            the websites publishing those or other writings about programming, the people responding
            to the PVS.MediaPlayer article with comments and suggestions and, of course, The Code Project:
            thank you Deeksha, Smitha and Sean Ewington for the beautiful article and all!

            Font 'Crystal Italic' by Allen R. Walden (FontInfo.txt in Resources folder). Thank you Allen!
            Application icon by Kyo-Tux. Thanks! www.iconarchive.com/show/soft-icons-by-kyo-tux/Media-icon.html

            Special thanks to the creators of Media Foundation .NET for their great library!

            Special thanks to Sean Ewington of The Code Project who also took care of publishing the many code updates
            and changes in the PVS.MediaPlayer articles in a friendly, fast, and highly competent manner.
            Thank you very much, Sean!


            If you have questions about using the PVS.MediaPlayer library or this sample application, do not hesitate
            to ask a question in the PVS.MediaPlayer article's comments (after the text of the article) on The Code Project:
            https://www.codeproject.com/Articles/109714/PVS-MediaPlayer-Audio-and-Video-Player-Library


            Peter Vegter
            May 2020, The Netherlands
    
            Microsoft Windows 10 (64-bit)
            Microsoft Visual Studio 2019 Community
            Medion PC (Intel Core i5-7400 CPU @ 3.00 GHz, 8,0GB RAM, NVIDIA GeForce GT 1030)
            AOC i2490PXQU/BT 24-inch monitor
            Dell E173FP 17-inch monitor

        */


        // ******************************** Fields

        #region Fields

        // To avoid too much CPU-usage and/or memory usage
        //private const int       PREFERENCES_VERSION             = 3;
        private const int       MAX_VIEW_PLAYERS                = 57;   // The maximum number of players in a folderview
        private const int       MAX_PLAYING_BACKGROUND_PLAYERS  = 12;   // If more than this: pause all folderview players when opening detailview

        // Movie file extensions to look for (this list starts with .lnk (shortcut file))
        private const string    MOVIE_EXTENSIONS = ".lnk.3g2.3gp.3gp2.3gpp.asf.avi.m4v.mkv.mov.mp4.mpeg.mpg.sami.webm.wmv";

        // Players and Displays (ItemViews)
        private int             _activeCount;
        private int             _playerCount;
        private Player[]        _myPlayers;
        private ItemView[]      _myItemViews;
        private Random          _random;

        // ItemViews Label Colors
        private readonly Color  NORMAL_COLOR        = Color.FromArgb(179, 173, 146);
        private readonly Color  ERROR_COLOR         = Color.Firebrick;
        private readonly Color  AUDIO_ENABLED_COLOR = Color.ForestGreen;

        // FolderView
        private bool            _busy;
        private bool            _hasQueue;
        private string          _queuePath;
        private bool            _exit;
        private List<string>    _fileList;

        // Treeview (folderBrowser)
        private bool            _dontExpand;
        private bool            _scrollBarHidden;

        // InfoLabels (trackbar labels)
        internal InfoLabel      ItemViewLabel;
        internal InfoLabel      PlayerWindowLabel;

        // Contextmenu Handler
        private int             _playerId;

        // Preferences
        [Serializable]
        public struct Preferences
        {
            public Rectangle    WindowBounds;
            public bool         WindowMaximized;
            public string       InitialDirectory;
            public DisplayMode  ItemDisplayMode;
            public DisplayShape ItemDisplayShape;
            public int          SplitterDistance;
        }
        private Preferences     _prefs;
        private const string    PREFS_FILENAME = "FolderView.inf";
        private readonly string PREFS_PATH = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\FolderView\";

        // About / Website Dialogs
        internal bool           UrlClicked;
        internal int            _goToArticle = 1;

        // Audio Hold
        internal bool           _audioHold;
        internal PlayerWindow   _audioHoldWindow;

        // Peak meters - for all PlayerWindows (only one is 'sound-active')
        private bool            _peakMeterBusy;
        internal float          _leftChannel;
        internal float          _rightChannel;
        private LinearGradientBrush _peakMeterBrush;
        private Rectangle       _peakMeterRect;
        private int             _peakMeterHeight;

        // Dispose
        private bool            _disposed;

        #endregion

        // ******************************** Main

        #region Main

        // Initialize
        public MainWindow()
        {
            InitializeComponent();
            Icon = Properties.Resources.Media8b;

            _random = new Random();

            // used with finding subtitle files (on Form2)
            Globals.Subtitles = new FileSearch();

            // Set custom menus
            ToolStripManager.Renderer = new CustomMenuRenderer();

            // Set custom font
            InstallCustomFonts();
            countLabel1.Font = Globals.CrystalFont26;
            countLabel1.UseCompatibleTextRendering = true;
            countLabel2.Font = Globals.CrystalFont26;
            countLabel2.UseCompatibleTextRendering = true;

            // FlowLayoutPanel scroll and click eventhandlers - and background image layout
            flowLayoutPanel1.Scroll += FlowLayoutPanel1_Scroll;
            flowLayoutPanel1.MouseWheel += FlowLayoutPanel1_MouseWheel;

            // Adjust submenus margins
            ((ToolStripDropDownMenu)allMenuItem.DropDown).ShowImageMargin = false;
            ((ToolStripDropDownMenu)displayModeAllMenuItem.DropDown).ShowImageMargin = false;
            ((ToolStripDropDownMenu)displayShapeAllMenuItem.DropDown).ShowImageMargin = false;

            // Create slider labels
            CreateInfoLabels();

            // Load settings
            GetSettings();

            // Create a filelist (to store moviefilenames in a directory)
            _fileList = new List<string>(MAX_VIEW_PLAYERS);

            // Add text maximum number of files to tooltips
            mainWindowToolTip.SetToolTip(countLabel1, mainWindowToolTip.GetToolTip(countLabel1) + MAX_VIEW_PLAYERS.ToString() + ").");
            mainWindowToolTip.SetToolTip(countLabel2, mainWindowToolTip.GetToolTip(countLabel2) + MAX_VIEW_PLAYERS.ToString() + ").");

            // Allow keys
            KeyPreview = true;

            // Peak meter - shared with all PlayerWindows
            _peakMeterRect   = customPanel1.ClientRectangle;
            _peakMeterHeight = _peakMeterRect.Height;
            //_peakMeterBrush = new LinearGradientBrush(_peakMeterRect, Color.FromArgb(189, 159, 87), Color.Gold, LinearGradientMode.Horizontal);
            _peakMeterBrush = new LinearGradientBrush(_peakMeterRect, Color.FromArgb(0, 128, 0), Color.FromArgb(0, 220, 0), LinearGradientMode.Horizontal);
            _peakMeterBrush.SetBlendTriangularShape(0.5f);

            // finishing setup in Form1_Shown... (for 'smoother' form display)
            Opacity = 0;
        }

        private void CreateInfoLabels()
        {
            ItemViewLabel = new InfoLabel
            {
                RoundedCorners  = true,
                ForeColor       = NORMAL_COLOR,
                Text            = "00:00:00" // 'pre-size' small label for brush size
            };
            ItemViewLabel.BackBrush             = new LinearGradientBrush(
                new Rectangle(new Point(0, 0), ItemViewLabel.Size),
                Color.FromArgb(80, 80, 80), Color.Black, LinearGradientMode.Vertical);
            ItemViewLabel.AlignOffset           = new Point(0, 2);

            PlayerWindowLabel = new InfoLabel
            {
                Font                        = Globals.CrystalFont16,
                UseCompatibleTextRendering  = true,
                TextMargin                  = new Padding(4, 2, 3, 0),
                RoundedCorners              = true,
                ForeColor                   = NORMAL_COLOR
            };
            PlayerWindowLabel.BackBrush         = new LinearGradientBrush(
                new Rectangle(new Point(0, 0), PlayerWindowLabel.Size),
                Color.FromArgb(64, 64, 64), Color.Black, LinearGradientMode.Vertical);
            PlayerWindowLabel.AlignOffset       = new Point(0, -3);

        }

        private void MainWindow_Shown(object sender, EventArgs e)
        {
            // Set folderbrowser
            FolderBrowser_Init();
            FolderBrowser_SetPath(_prefs.InitialDirectory);
            FolderBrowser_HideScrollBar(true);

            Application.DoEvents();
            Opacity = 1; // make form visible

            // Set initial FolderView
            CreateFolderView(_prefs.InitialDirectory);
        }

        private void MainWindow_Activated(object sender, EventArgs e)
        {
            flowLayoutPanel1.Focus();
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                e.Handled = true;
                ShowAboutDialog();
            }
            else if (e.KeyCode == Keys.Escape || (e.KeyCode == Keys.Q && e.Control))
            {
                e.Handled = true;
                Close();
            }
        }

        private void ShowAboutDialog()
        {
            UrlClicked = false;

            AboutDialog aboutMessage = new AboutDialog(this);
            aboutMessage.ShowDialog(this);
            aboutMessage.Dispose();

            if (UrlClicked) AskOpenWebSite();
        }

        // Asks for opening Code Project website
        private void AskOpenWebSite()
        {
            string theWebPage = @"http://www.codeproject.com";

            WebSiteDialog webSiteDialog = new WebSiteDialog() { Selection = _goToArticle };
            if (webSiteDialog.ShowDialog(this) == DialogResult.OK)
            {
                _goToArticle = webSiteDialog.Selection;
                webSiteDialog.Dispose();

                if (_goToArticle == 1) theWebPage += @"/Articles/109714/PVS-MediaPlayer-Audio-and-Video-Player-Library";
                else if (_goToArticle == 2) theWebPage += @"/Articles/1116698/PVS-AVPlayer-MCI-Sound-Recorder";
                try
                {
                    System.Diagnostics.Process.Start(theWebPage);
                }
                catch
                {
                    MessageBox.Show(
                    caption: "Folder View",
                    icon: MessageBoxIcon.Exclamation,
                    text: "Could not open the requested webpage. Please check your Browser.",
                    buttons: MessageBoxButtons.OK,
                    owner: this);
                }
            }
            else
            {
                webSiteDialog.Dispose();
            }
        }

        // Repairing scroll redraw issues with paused players
        private void FlowLayoutPanel1_Scroll(object sender, ScrollEventArgs e)
        {
            flowLayoutPanel1.Invalidate(true);
        }
        // ... and with
        void FlowLayoutPanel1_MouseWheel(object sender, MouseEventArgs e)
        {
            flowLayoutPanel1.Invalidate(true);
        }

        // Don't close the Form (application) yet when a Player starts playing a mediafile (in method CreateFolderView)
        // (because a Player allows user interface actions while 'processing' a mediafile and
        // all Displays and Players will be 'disposed' when closing the Form)
        // 'sends a message' to CreateFolderView (if busy)
        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_busy)
            {
                _exit = true; // do Application.Exit() when finished
                _hasQueue = true; // don't create new ItemViews, Players or start playing a mediafile
                e.Cancel = true; // don't exit app (yet)
            }
            else
            {
                //RemoveFolderView();
                //_fileList.Clear();

                Hide();

                // Save settings
                SaveSettings();
                // Dispose all open Forms but this one
                for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
                {
                    if (Application.OpenForms[i] != this) Application.OpenForms[i].Dispose();
                }
            }
        }

        // Moved from 'Main Window.Designer.cs' to here and added a few things
        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                _disposed = true;

                if (disposing)
                {
                    RemoveFolderView();
                    _fileList.Clear();

                    if (ItemViewLabel != null)  ItemViewLabel.Dispose();
                    if (PlayerWindowLabel != null) PlayerWindowLabel.Dispose();

                    if (_peakMeterBrush != null) _peakMeterBrush.Dispose();

                    Globals.CrystalFont16.Dispose();
                    Globals.CrystalFont26.Dispose();
                    Globals.FontCollection1.Dispose();

                    if (components != null) components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #endregion

        // ******************************** Settings - Config File

        #region Settings - Config File

        private void GetSettings()
        {
            bool loadOk = false;

            _prefs.ItemDisplayMode = DisplayMode.ZoomCenter;
            _prefs.ItemDisplayShape = DisplayShape.Normal;
            _prefs.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            _prefs.SplitterDistance = 0;

            // Load and Apply Settings
            if (File.Exists(PREFS_PATH + PREFS_FILENAME))
            {
                try
                {
                    using (StreamReader reader = new StreamReader(PREFS_PATH + PREFS_FILENAME))
                    {
                        XmlSerializer xml = new XmlSerializer(typeof(Preferences));
                        _prefs = (Preferences)xml.Deserialize(reader);
                    }
                    loadOk = true;
                }
                catch { /* ignore */ }
            }

            if (loadOk)
            {
                // check window position (multiple screens)
                if (SystemInformation.VirtualScreen.Contains(_prefs.WindowBounds))
                {
                    StartPosition = FormStartPosition.Manual;
                    Bounds = _prefs.WindowBounds;
                }

                if (_prefs.WindowMaximized)
                {
                    if (StartPosition != FormStartPosition.Manual)
                    {
                        Top = (Screen.PrimaryScreen.WorkingArea.Height - Height) / 2;
                        Left = (Screen.PrimaryScreen.WorkingArea.Width - Width) / 2;
                    }
                    WindowState = FormWindowState.Maximized;
                }
                if (_prefs.SplitterDistance > 0) splitContainer1.SplitterDistance = _prefs.SplitterDistance;
            }
        }

        private void SaveSettings()
        {
            // Collect Settings
            _prefs.WindowBounds = WindowState == FormWindowState.Normal ? Bounds : RestoreBounds;
            _prefs.WindowMaximized = WindowState == FormWindowState.Maximized;
            _prefs.SplitterDistance = splitContainer1.SplitterDistance;

            // Save Settings
            try
            {
                Directory.CreateDirectory(PREFS_PATH); // create folder if not already existing
                using (StreamWriter writer = new StreamWriter(PREFS_PATH + PREFS_FILENAME))
                {
                    XmlSerializer xml = new XmlSerializer(typeof(Preferences));
                    xml.Serialize(writer, _prefs);
                }
            }
            catch { /* ignore */ }
        }

        #endregion

        // ******************************** Create / Remove FolderView / ResolveShortcut

        #region Create / Remove FolderView / ResolveShortcut

        // Create and display a new Folder view
        private void CreateFolderView(string path)
        {
            if (_busy)
            {
                _hasQueue = true;
                _queuePath = path;
                return;
            }
            _busy = true;

            do
            {
                RemoveFolderView();
                _fileList.Clear();

                if (_hasQueue)
                {
                    _hasQueue = false;
                    folderLabel.Text = _queuePath;
                }
                else folderLabel.Text = path;

                try
                {
                    // Get all mediafiles in folder
                    foreach (string file in Directory.GetFiles(folderLabel.Text))
                    {
                        int index = MOVIE_EXTENSIONS.IndexOf(Path.GetExtension(file), StringComparison.OrdinalIgnoreCase);
                        if (index == 0) // .lnk - shortcut file
                        {
                            string linkFile = ResolveShortcut(file);
                            if (MOVIE_EXTENSIONS.IndexOf(Path.GetExtension(linkFile), StringComparison.OrdinalIgnoreCase) > 0)
                            {
                                _fileList.Add(linkFile);
                            }
                        }
                        else if (index > 0)
                        {
                            _fileList.Add(file);
                        }
                    }
                }
                catch //(Exception e)
                {
                    //MessageBox.Show(e.Message);
                    continue;
                }

                if (_fileList.Count > 0)
                {
                    // Set (max) number of Players
                    _playerCount = _fileList.Count > MAX_VIEW_PLAYERS ? MAX_VIEW_PLAYERS : _fileList.Count;

                    // Create Displays and Players
                    _myItemViews = new ItemView[_playerCount];
                    _myPlayers = new Player[_playerCount];

                    for (int i = 0; i < _playerCount && !_hasQueue; i++)
                    {
                        _myItemViews[i] = new ItemView()
                        {
                            Name = i.ToString(),
                            ContextMenuStrip = itemViewMenu,
                        };

                        _myItemViews[i].FileName.Click              += FileName_Click; // label
                        _myItemViews[i].FileName.ForeColor          = NORMAL_COLOR;
                        _myItemViews[i].FileName.Text               = Path.GetFileName(_fileList[i]);

                        _myPlayers[i]                               = new Player();
                        _myPlayers[i].Display.Window                = _myItemViews[i].Display;
                        _myPlayers[i].Display.Mode                  = _prefs.ItemDisplayMode;
                        _myPlayers[i].Display.Shape                 = _prefs.ItemDisplayShape;
                        _myPlayers[i].Sliders.Position.TrackBar     = _myItemViews[i].customSlider1;
                        //_myPlayers[i].Sliders.Position.LiveUpdate   = false; // v. 0.95 default false
                        _myPlayers[i].Mute                          = true;
                        _myPlayers[i].Repeat                        = true;
                        _myPlayers[i].Events.MediaPeakLevelChanged  += Player_MediaPeakLevelChanged;

                        _myItemViews[i].ItemParent                  = this;
                        _myItemViews[i].ItemPlayer                  = _myPlayers[i];

                        //if (_playerCount > MAX_PLAYING_BACKGROUND_PLAYERS) _myPlayers[i].Paused = true;
                        _myPlayers[i].Paused                        = true;
                    }

                    // Add items to TableLayoutPanel
                    if (!_hasQueue)
                    {
                        flowLayoutPanel1.Controls.AddRange(_myItemViews);
                        countLabel1.Text = _playerCount.ToString("000");
                        for (int i = 0; i < _myPlayers.Length; i++)
                        {
                            _myPlayers[i].Display.Window.MouseClick += MediaDisplay_Click;
                        }
                    }

                    // Start Players
                    for (int i = 0; i < _playerCount && !_hasQueue; i++)
                    {
                        _myPlayers[i].Play(_fileList[i]);
                        if (_myPlayers[i].LastError)
                        {
                            _myPlayers[i].Dispose();
                            _myPlayers[i] = null;
                            _myItemViews[i].customSlider1.Enabled = false;
                            _myItemViews[i].FileName.ForeColor = ERROR_COLOR;
                        }
                        else
                        {
                            countLabel2.Text = (++_activeCount).ToString("000");
                            _myPlayers[i].Position.Progress = (float)(_random.NextDouble() / 2.5 + 0.1);
                        }
                    }

                    // See Form1_FormClosing eventhandler
                    if (_exit)
                    {
                        _hasQueue = false;
                        _busy = false;
                        Application.Exit();
                    }
                }
            } while (_hasQueue);

            // itemViewMenu all items
            allMenuItem.Enabled = _playerCount > 0;
            // contextmenustrip2
            bool menuEnabled = _playerCount > 0;

            _busy = false;
        }

        private void RemoveFolderView()
        {
            // reset counters
            _activeCount = 0;
            countLabel1.Text = "000";
            countLabel2.Text = "000";

            if (_playerCount > 0)
            {
                allMenuItem.Enabled = false;

                // Dispose Players and remove and dispose ItemViews
                for (int i = _playerCount - 1; i >= 0; i--)
                {
                    if (_myPlayers[i] != null)
                    {
                        _myPlayers[i].Dispose();
                        _myPlayers[i] = null;
                    }
                }

                for (int i = _playerCount - 1; i >= 0; i--)
                {
                    if (_myItemViews[i] != null)
                    {
                        _myItemViews[i].ContextMenuStrip = null;
                        _myItemViews[i].Dispose();
                        _myItemViews[i] = null;
                    }
                }

                flowLayoutPanel1.Controls.Clear();
                _playerCount = 0;
            }
        }

        // taken from: https://blez.wordpress.com/2013/02/18/get-file-shortcuts-target-with-c/
        private string ResolveShortcut(string fileName)
        {
            //if (!String.Equals(Path.GetExtension(fileName), ".lnk", StringComparison.OrdinalIgnoreCase)) return string.Empty;
            try
            {
                FileStream fileStream = File.Open(fileName, FileMode.Open, FileAccess.Read);
                using (BinaryReader fileReader = new BinaryReader(fileStream))
                {
                    fileStream.Seek(0x14, SeekOrigin.Begin);     // Seek to flags
                    uint flags = fileReader.ReadUInt32();        // Read flags
                    if ((flags & 1) == 1)
                    {
                        // Bit 1 set means we have to skip the shell item ID list
                        fileStream.Seek(0x4c, SeekOrigin.Begin); // Seek to the end of the header
                        uint offset = fileReader.ReadUInt16();   // Read the length of the Shell item ID list
                        fileStream.Seek(offset, SeekOrigin.Current); // Seek past it (to the file locator info)
                    }

                    long fileInfoStartsAt = fileStream.Position; // Store the offset where the file info
                    // structure begins
                    uint totalStructLength = fileReader.ReadUInt32(); // read the length of the whole struct
                    fileStream.Seek(0xc, SeekOrigin.Current); // seek to offset to base pathname
                    uint fileOffset = fileReader.ReadUInt32(); // read offset to base pathname
                    // the offset is from the beginning of the file info struct (fileInfoStartsAt)
                    fileStream.Seek((fileInfoStartsAt + fileOffset), SeekOrigin.Begin); // Seek to beginning of
                    // base pathname (target)
                    long pathLength = (totalStructLength + fileInfoStartsAt) - fileStream.Position - 2; // read
                    // the base pathname. I don't need the 2 terminating nulls.
                    char[] linkTarget = fileReader.ReadChars((int)pathLength); // should be unicode safe
                    string link = new string(linkTarget);

                    int begin = link.IndexOf("\0\0", StringComparison.Ordinal);
                    if (begin > -1)
                    {
                        int end = link.IndexOf("\\\\", begin + 2, StringComparison.Ordinal) + 2;
                        end = link.IndexOf('\0', end) + 1;

                        string firstPart = link.Substring(0, begin);
                        string secondPart = link.Substring(end);

                        return firstPart + secondPart;
                    }
                    return link;
                }
            }
            catch
            {
                return string.Empty;
            }
        }

        #endregion

        // ******************************** ItemView Click Eventhandlers

        #region ItemView Click Eventhandlers

        // Handle ItemView Player Display Click
        void MediaDisplay_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _playerId = Convert.ToInt32(((Panel)sender).Parent.Name);
                OpenMenuItem_Click(sender, EventArgs.Empty);
            }
        }

        // Handle ItemView Label Click
        void FileName_Click(object sender, EventArgs e)
        {
            //if (MouseButtons == MouseButtons.Left)
            {
                _playerId = Convert.ToInt32(((Label)sender).Parent.Name);
                OpenMenuItem_Click(sender, e);
            }
        }

        #endregion

        // ******************************** Contextmenu Items Handlers

        #region Contextmenu Items Handlers

        // ******************************** ContextMenu Opening and Closing

        // Before contextmenu is shown or closed:
        private void ItemViewMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _playerId = Convert.ToInt32(((ContextMenuStrip)sender).SourceControl.Name);
            bool enable = _myPlayers[_playerId] != null;

            pauseMenuItem.Enabled = enable;
            muteMenuItem.Enabled = enable;
            displayModeMenuItem.Enabled = enable;

            if (enable)
            {
                pauseMenuItem.Text = _myPlayers[_playerId].Paused ? "Play" : "Pause";
                muteMenuItem.Text = _myPlayers[_playerId].Mute ? "Mute Off" : "Mute";

                stretchMenuItem.Checked = coverMenuItem.Checked = zoomMenuItem.Checked = false;
                if (_myPlayers[_playerId].Display.Mode == DisplayMode.Stretch) stretchMenuItem.Checked = true;
                else if (_myPlayers[_playerId].Display.Mode == DisplayMode.CoverCenter) coverMenuItem.Checked = true;
                else zoomMenuItem.Checked = true;

                heartShapeMenuItem.Checked = ovalShapeMenuItem.Checked = roundedShapeMenuItem.Checked = starShapeMenuItem.Checked = normalShapeMenuItem.Checked = false;
                if (_myPlayers[_playerId].Display.Shape == DisplayShape.Heart) heartShapeMenuItem.Checked = true;
                else if (_myPlayers[_playerId].Display.Shape == DisplayShape.Oval) ovalShapeMenuItem.Checked = true;
                else if (_myPlayers[_playerId].Display.Shape == DisplayShape.Rounded) roundedShapeMenuItem.Checked = true;
                else if (_myPlayers[_playerId].Display.Shape == DisplayShape.Star) starShapeMenuItem.Checked = true;
                else normalShapeMenuItem.Checked = true;
            }
            else
            {
                pauseMenuItem.Text = "Play";
                muteMenuItem.Text = "Mute Off";
            }

            ((ItemView)itemViewMenu.SourceControl).FileName.BackColor = Color.FromArgb(64, 24, 24);
        }

        private void ItemViewMenu_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            ((ItemView)itemViewMenu.SourceControl).FileName.BackColor = BackColor; // Color.FromArgb(18, 18, 18);
        }


        // ******************************** All Items

        // Play (Resume) all Players
        private void PlayAllMenuItem_Click(object sender, EventArgs e)
        {
            PauseAllPlayers(false);
        }

        // Pause all Players
        private void PauseAllMenuItem_Click(object sender, EventArgs e)
        {
            PauseAllPlayers(true);
        }

        // Mute all Players
        private void MuteAllMenuItem_Click(object sender, EventArgs e)
        {
            AudioMuteAllPlayers();
        }


        // DisplayMode Stretch all Players
        private void StretchAllMenuItem_Click(object sender, EventArgs e)
        {
            _prefs.ItemDisplayMode = DisplayMode.Stretch;
            for (int i = 0; i < _myPlayers.Length; i++)
            {
                if (_myPlayers[i] != null) _myPlayers[i].Display.Mode = DisplayMode.Stretch;
            }
        }

        // DisplayMode Cover all Players
        private void CoverAllMenuItem_Click(object sender, EventArgs e)
        {
            _prefs.ItemDisplayMode = DisplayMode.CoverCenter;
            for (int i = 0; i < _myPlayers.Length; i++)
            {
                if (_myPlayers[i] != null) _myPlayers[i].Display.Mode = DisplayMode.CoverCenter;
            }
        }

        // DisplayMode ZoomAndCenter all Players
        private void ZoomAndCenterAllMenuItem_Click(object sender, EventArgs e)
        {
            _prefs.ItemDisplayMode = DisplayMode.ZoomCenter;
            for (int i = 0; i < _myPlayers.Length; i++)
            {
                if (_myPlayers[i] != null) _myPlayers[i].Display.Mode = DisplayMode.ZoomCenter;
            }
        }


        // Display Shape Heart all Players
        private void HeartShapeAllMenuItem_Click(object sender, EventArgs e)
        {
            _prefs.ItemDisplayShape = DisplayShape.Heart;
            for (int i = 0; i < _myPlayers.Length; i++)
            {
                if (_myPlayers[i] != null) _myPlayers[i].Display.Shape = DisplayShape.Heart;
            }
        }

        // Display Shape Oval all Players
        private void OvalShapeAllMenuItem_Click(object sender, EventArgs e)
        {
            _prefs.ItemDisplayShape = DisplayShape.Oval;
            for (int i = 0; i < _myPlayers.Length; i++)
            {
                if (_myPlayers[i] != null) _myPlayers[i].Display.Shape = DisplayShape.Oval;
            }
        }

        // Display Shape Rounded all Players
        private void RoundedShapeAllMenuItem_Click(object sender, EventArgs e)
        {
            _prefs.ItemDisplayShape = DisplayShape.Rounded;
            for (int i = 0; i < _myPlayers.Length; i++)
            {
                if (_myPlayers[i] != null) _myPlayers[i].Display.Shape = DisplayShape.Rounded;
            }
        }

        // Display Shape Star all Players
        private void StarShapeAllMenuItem_Click(object sender, EventArgs e)
        {
            _prefs.ItemDisplayShape = DisplayShape.Star;
            for (int i = 0; i < _myPlayers.Length; i++)
            {
                if (_myPlayers[i] != null) _myPlayers[i].Display.Shape = DisplayShape.Star;
            }
        }

        // Display Shape Normal all Players
        private void NormalShapeAllMenuItem_Click(object sender, EventArgs e)
        {
            _prefs.ItemDisplayShape = DisplayShape.Normal;
            for (int i = 0; i < _myPlayers.Length; i++)
            {
                if (_myPlayers[i] != null) _myPlayers[i].Display.Shape = DisplayShape.Normal;
            }
        }


        // ******************************** Selected Player

        // Play (Resume) / Pause selected Player
        private void PauseMenuItem_Click(object sender, EventArgs e)
        {
            _myPlayers[_playerId].Paused = !_myPlayers[_playerId].Paused;
        }

        // Mute On / Off selected Player
        private void MuteMenuItem_Click(object sender, EventArgs e)
        {
            if (_myPlayers[_playerId].Mute)
            {
                AudioMuteAllPlayers();
                //_myPlayers[_playerId].Mute = false;
                _myPlayers[_playerId].Audio.Enabled = true;
                _myItemViews[_playerId].FileName.ForeColor = AUDIO_ENABLED_COLOR;
            }
            else
            {
                //_myPlayers[_playerId].Mute = true;
                _myPlayers[_playerId].Audio.Enabled = false;
                _myItemViews[_playerId].FileName.ForeColor = NORMAL_COLOR;
            }
        }


        // DisplayMode Stretch selected Player
        private void StretchMenuItem_Click(object sender, EventArgs e)
        {
            _myPlayers[_playerId].Display.Mode = DisplayMode.Stretch;
        }

        // DisplayMode Cover selected Player
        private void CoverMenuItem_Click(object sender, EventArgs e)
        {
            _myPlayers[_playerId].Display.Mode = DisplayMode.CoverCenter;
        }

        // DisplayMode ZoomCenter selected Player
        private void ZoomCenterMenuItem_Click(object sender, EventArgs e)
        {
            _myPlayers[_playerId].Display.Mode = DisplayMode.ZoomCenter;
        }


        // DisplayShape Heart selected Player
        private void HeartShapeMenuItem_Click(object sender, EventArgs e)
        {
            _myPlayers[_playerId].Display.Shape = DisplayShape.Heart;
        }

        // DisplayShape Oval selected Player
        private void OvalShapeMenuItem_Click(object sender, EventArgs e)
        {
            _myPlayers[_playerId].Display.Shape = DisplayShape.Oval;
        }

        // DisplayShape Rounded selected Player
        private void RoundedShapeMenuItem_Click(object sender, EventArgs e)
        {
            _myPlayers[_playerId].Display.Shape = DisplayShape.Rounded;
        }

        // DisplayShape Star selected Player
        private void StarShapeMenuItem_Click(object sender, EventArgs e)
        {
            _myPlayers[_playerId].Display.Shape = DisplayShape.Star;
        }

        // DisplayShape Normal selected Player
        private void NormalShapeMenuItem_Click(object sender, EventArgs e)
        {
            _myPlayers[_playerId].Display.Shape = DisplayShape.Normal;
        }


        // ******************************** Open, Open With..., Properties

        // Open mediafile in new window or in other application
        private void OpenMenuItem_Click(object sender, EventArgs e)
        {
            OpenItem(false);
        }

        // Open at in item shown position
        private void OpenAtMenuItem_Click(object sender, EventArgs e)
        {
            OpenItem(true);
        }

        private void OpenItem(bool fromStart)
        {
            if (_myPlayers.Length > MAX_PLAYING_BACKGROUND_PLAYERS) PauseAllPlayers(true);
            AudioMuteAllPlayers();

            if (_myPlayers[_playerId] != null)
            {
                PlayerWindow playerForm;

                if (fromStart || (Control.ModifierKeys == Keys.Shift || Control.ModifierKeys == Keys.Control)) playerForm = new PlayerWindow(this, _fileList[_playerId], TimeSpan.Zero);
                else playerForm = new PlayerWindow(this, _fileList[_playerId], _myPlayers[_playerId].Position.FromStart);

                if (playerForm._lastError)
                {
                    playerForm.Dispose();
                }
                else
                {
                    Point pos = MousePosition;
                    Rectangle screen = Screen.GetWorkingArea(pos);

                    // center the form on the mouse click position, but adjust if not fully visible on screen
                    if (pos.X > screen.Left + (playerForm.Width / 2))
                    {
                        pos.X -= (playerForm.Width / 2);
                        if (pos.X + playerForm.Width > screen.Left + screen.Width) pos.X = screen.Left + screen.Width - playerForm.Width - 8;
                    }
                    else pos.X = screen.Left + 8;
                    if (pos.Y > screen.Top + (playerForm.Height / 2))
                    {
                        pos.Y -= (playerForm.Height / 2);
                        if (pos.Y + playerForm.Height > screen.Top + screen.Height) pos.Y = screen.Top + screen.Height - playerForm.Height - 8;
                    }
                    else pos.Y = screen.Top + 8;

                    playerForm.StartPosition = FormStartPosition.Manual;
                    playerForm.Location = pos;
                    playerForm.Show(this);
                    return;
                }
            }

            try { System.Diagnostics.Process.Start(_fileList[_playerId]); }
            catch { }
        }

        // Select application to open mediafile
        private void OpenWithMenuItem_Click(object sender, EventArgs e)
        {
            if (_myPlayers.Length > MAX_PLAYING_BACKGROUND_PLAYERS) PauseAllPlayers(true);
            AudioMuteAllPlayers();

            try { System.Diagnostics.Process.Start("rundll32.exe", "shell32.dll,OpenAs_RunDLL " + _fileList[_playerId]); }
            catch { }
        }

        // Show mediafile Explorer properties dialog
        private void PropertiesMenuItem_Click(object sender, EventArgs e)
        {
            // 'dirty trick' to position the properties dialog - should have a second look at this (?)
            //Cursor.Position = PointToScreen(new Point(folderBrowser.Width + _myItemViews[_playerId].Left + (_myItemViews[_playerId].Width / 2), panel1.Height + _myItemViews[_playerId].Top + (_myItemViews[_playerId].Height / 3)));
            Cursor.Position = PointToScreen(new Point(folderBrowser.Width + _myItemViews[_playerId].Left + _myItemViews[_playerId].Width + 10, panel1.Height + _myItemViews[_playerId].Top + 3));

            try
            {
                SafeNativeMethods.SHELLEXECUTEINFO info = new SafeNativeMethods.SHELLEXECUTEINFO();
                info.cbSize = Marshal.SizeOf(info);
                info.lpVerb = "properties";
                info.lpParameters = "details";
                info.lpFile = _fileList[_playerId];
                info.nShow = SafeNativeMethods.SW_SHOW;
                info.fMask = SafeNativeMethods.SEE_MASK_INVOKEIDLIST;
                SafeNativeMethods.ShellExecuteEx(ref info);
            }
            catch { /* ignore */}
        }

        // ******************************** About / Quit

        // About application
        private void AboutMenuItem_Click(object sender, EventArgs e)
        {
            ShowAboutDialog();
        }

        // Quit application
        private void QuitMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        // ******************************** Contextmenu Helper methods

        // Pause / Resume playback all Players
        private void PauseAllPlayers(bool pause)
        {
            for (int i = 0; i < _myPlayers.Length; i++)
            {
                if (_myPlayers[i] != null) _myPlayers[i].Paused = pause;
            }
        }

        private void AudioMuteAllPlayers()
        {
            for (int i = 0; i < _myPlayers.Length; i++)
            {
                if (_myPlayers[i] != null && _myPlayers[i].Audio.Enabled)
                {
                    //_myPlayers[i].Mute = true;
                    _myPlayers[i].Audio.Enabled = false;
                    _myItemViews[i].FileName.ForeColor = NORMAL_COLOR;
                }
            }
        }

        #endregion

        // ******************************** Player Windows Contextmenu Handlers

        #region Player Windows Contextmenu Handlers

        // Pause all Player Windows
        internal void PauseAllWindows()
        {
            foreach (Form window in Application.OpenForms)
            {
                if (window != this && window.GetType() == typeof(PlayerWindow)) ((PlayerWindow)window).PauseMenuFromMain();
            }
        }

        // Resume all Player Windows
        internal void ResumeAllWindows()
        {
            foreach (Form window in Application.OpenForms)
            {
                if (window != this && window.GetType() == typeof(PlayerWindow)) ((PlayerWindow)window).ResumeMenuFromMain();
            }
        }

        // Mute all Player Windows
        internal void MuteAllWindows()
        {
            foreach (Form window in Application.OpenForms)
            {
                if (window != this && window.GetType() == typeof(PlayerWindow)) ((PlayerWindow)window).MuteMenuFromMain();
            }
        }

        // Mute Off all Player Windows
        internal void MuteOffAllWindows()
        {
            foreach (Form window in Application.OpenForms)
            {
                if (window != this && window.GetType() == typeof(PlayerWindow)) ((PlayerWindow)window).MuteOffMenuFromMain();
            }
        }

        // Stretch all Player Windows
        internal void StretchAllWindows()
        {
            foreach (Form window in Application.OpenForms)
            {
                if (window != this && window.GetType() == typeof(PlayerWindow)) ((PlayerWindow)window).StretchMenuFromMain();
            }
        }

        // Cover all Player Windows
        internal void CoverAllWindows()
        {
            foreach (Form window in Application.OpenForms)
            {
                if (window != this && window.GetType() == typeof(PlayerWindow)) ((PlayerWindow)window).CoverMenuFromMain();
            }
        }

        // Zoom all Player Windows
        internal void ZoomAllWindows()
        {
            foreach (Form window in Application.OpenForms)
            {
                if (window != this && window.GetType() == typeof(PlayerWindow)) ((PlayerWindow)window).ZoomMenuFromMain();
            }
        }

        // FullScreen Off all Player Windows
        internal void FullScreenOffAllWindows()
        {
            foreach (Form window in Application.OpenForms)
            {
                if (window != this && window.GetType() == typeof(PlayerWindow)) ((PlayerWindow)window).FullScreenOffFromMain();
            }
        }

        // Hide Subtitles all Player Windows
        internal void HideSubtitlesAllWindows()
        {
            Form topWindow = ActiveForm;
            foreach (Form window in Application.OpenForms)
            {
                if (window != this && window.GetType() == typeof(PlayerWindow)) ((PlayerWindow)window).SubtitlesOffFromMain();
            }
            if (topWindow != ActiveForm) topWindow.Activate();
        }

        // Show Subtitles all Player Windows
        internal void ShowSubtitlesAllWindows()
        {
            Form topWindow = ActiveForm;
            foreach (Form window in Application.OpenForms)
            {
                if (window != this && window.GetType() == typeof(PlayerWindow)) ((PlayerWindow)window).SubtitlesOnFromMain();
            }
            if (topWindow != ActiveForm) topWindow.Activate();
        }

        // Close all Player Windows
        internal void CloseAllWindows()
        {
            FormCollection forms = Application.OpenForms;
            for (int i = forms.Count - 1; i >= 0; i--)
            {
                if (forms[i] != this && forms[i].GetType() == typeof(PlayerWindow)) forms[i].Close();
            }
        }

        #endregion

        // ******************************** Peak Meters

        #region Peak Meters

        // peak meters shared by all players
        // but only one player is 'sound active' (usually)

        //  main window players
        private void Player_MediaPeakLevelChanged(object sender, PeakLevelEventArgs e)
        {
            PaintPeakMeters(e.ChannelsValues[0], e.ChannelsValues[1]);
        }

        internal void PaintPeakMeters(float leftChannel, float rightChannel)
        {
            if (!_peakMeterBusy)
            {
                _peakMeterBusy = true;

                _leftChannel = leftChannel;
                _rightChannel = rightChannel;

                customPanel1.Invalidate();
                customPanel2.Invalidate();

                _peakMeterBusy = false;
            }
        }

        private void CustomPanel1_Paint(object sender, PaintEventArgs e)
        {
            _peakMeterRect.Y = _peakMeterHeight - (int)(_leftChannel * _peakMeterHeight);
            e.Graphics.FillRectangle(_peakMeterBrush, _peakMeterRect);
        }

        private void CustomPanel2_Paint(object sender, PaintEventArgs e)
        {
            _peakMeterRect.Y = _peakMeterHeight - (int)(_rightChannel * _peakMeterHeight);
            e.Graphics.FillRectangle(_peakMeterBrush, _peakMeterRect);
        }

        #endregion

    }

}
