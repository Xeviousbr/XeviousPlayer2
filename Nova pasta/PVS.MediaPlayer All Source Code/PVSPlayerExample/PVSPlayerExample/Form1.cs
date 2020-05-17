#region Usings

using PVS.AVPlayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

#endregion

[assembly: CLSCompliant(true)]

namespace AVPlayerExample
{
    // ******************************** About this application

    /*

    PVS.AVPlayer - Example Application version 0.46
    
    This example application shows the use of some of the methods and properties of
    the PVS.AVPlayer library version 0.46.
    
    As with many (smaller) applications most of the code is related to the user interface.
    Actually, this example application doesn't do much more than handling the on-screen controls
    to send instructions to the PVS.AVPlayer library and receiving back and displaying information
    (like error messages) from the library (and even most of the on-screen controls are directly
    (like the position slider) or indirectly (through media events) controlled by the library).
    
    A large part of the application's functionality is created by using Microsoft Visual Studio Designer.
    
    Many thanks to Microsoft (Windows, .NET Framework, Visual Studio Express, etc.), all the people
    writing about programming on the internet (a great source for ideas and solving problems),
    the websites publishing those or other writings about programming, the people responding
    to the PVS.AVPlayer article with comments and suggestions and, of course, The Code Project:
    thank you Deeksha, Smitha and Sean for the beautiful article and all!.

    Fontfile 'Crystal Italic' by Allen R. Walden (FontInfo.txt in Resources folder. Thank you Allen!)
    added to Project Resources and 'Build Action' set to 'Embedded Resource'.
    
    Peter Vegter
    August 2015, The Netherlands
    
    Microsoft Windows 7 (64-bit)
    Microsoft Visual Studio 2015 Community
    Dell Studio XPS 8000 (i7 CPU 870, NVIDIA GeForce GTS 240)
    Samsung SyncMaster T220 22-inch widescreen monitor
    Dell E173FP 17-inch monitor

    */

    public partial class Form1 : Form
    {
        // ******************************** Fields

        #region Fields

        // The application
        internal const string       APPLICATION_NAME = "PVS.AVPlayer Example 0.46";
        private const string        PREFERENCES_NAME = "AVPlayerPreferences";
        private const string        PLAYLIST_NAME = "AVPlayerPlayList";
        private const string        SCREENCOPY_NAME = "AVPlayerScreenCopy";
        private static string       _appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\AVPlayerExample\";

        private int                 _errorCount;    // Used to break out of a row of errors with autoPlayNext and onErrorPlayNext;
        internal static bool        UrlClicked;     // URL (article website link) clicked on the About Form

        // Preferences
        private string              _prefsFile = _appDataPath + PREFERENCES_NAME + ".inf"; // preferences file path
        [Serializable] public class Preferences
        {
            public int Version;

            // Window
            public bool SaveWindow;
            public bool Maximized;
            public Rectangle Bounds;
            public bool Fullscreen;
            public FullScreenMode FullScreenMode;

            // DisplayMode
            public bool SaveDisplayMode;
            public DisplayMode DisplayMode;
            public Rectangle VideoBounds;

            // Overlay
            public bool AutoOverlay;
            public bool SaveOverlay;
            public int Overlay;

            // Repeat
            public bool SaveRepeat;
            public int Repeat; // 0 = off, 1 = one, 2 = all, 3 = shuffle

            // Speed
            public bool SaveSpeed;
            public int Speed;

            // Audio
            public bool SaveAudio;
            public int AudioVolume;
            public int AudioBalance;

            // Folders
            public bool SaveMediaFilesFolder;
            public string MediaFilesFolder;
            public bool SavePlaylistsFolder;
            public string PlaylistsFolder;

            // Continue Playing Media
            public bool ContinuePlay;
            public int MediaToPlay;
            public double Position;
            public double StartPosition;
            public double EndPosition;
            public bool Paused;
            public int RewindSecs;
            public bool VideoPresent;

            // Various
            public bool AutoPlayStart;
            public bool AutoPlayAdded;
            public bool AutoPlayNext;
            public bool OnErrorPlayNext;
            public bool OnErrorRemove;
            public bool ShowErrorMessages;

            // Tooltips & Dialog MiniPlayers
            public bool ShowTooltips;
            public bool ShowMiniPlayers;
        }
        internal static Preferences Prefs;

        // Custom Fonts
        internal PrivateFontCollection FontCollection;
        private Font                _crystalFont16;     // used with positionSlider counters
        private Font                _wingDng38;        // used with video zoom/move/stretch buttons

        // The Player
        internal Player             Player1;
        private const int           NO_ERROR = 0;

        // Repeat options
        private Random              _random = new Random();
        private int[]               _shuffleList;
        private int                 _shuffleToPlay;
        internal bool               RepeatOne;
        internal bool               RepeatAll;
        internal bool               RepeatShuffle;

        // The interface
        internal bool               StopAndPlay; // used with preventing 'flashing' interface elements:
        // when a mediafile is stopped and another is about to be played, the interface is not fully updated
        private double              _oldOpacity; // used at start up

        // Used with Play button contextmenu and submenu
        private int                 _playMenuItemIndex;
        private bool                _playMenuRightButton;
        private Point               _playMenuPopUpLocation = new Point(0, 0);

        // Position slider options
        private bool                _sliderHide;
        private bool                _sliderVisible = true;
        private TimeSpan            _mark1 = TimeSpan.Zero;

        // Open / Save file dialogs
        internal OpenFileDialog     OpenFileDialog1;
        internal SaveFileDialog     SaveFileDialog1;

        // Used with selecting mediafiles
        internal const string       OPENMEDIA_DIALOG_TITLE = APPLICATION_NAME + " - Add Mediafile(s)";
        internal static string      MediaDirectory;

        // Used with opening and saving playlists
        internal bool               AskSavePlayList;
        internal const string       OPENPLAYLIST_DIALOG_TITLE = APPLICATION_NAME + " - Open PlayList";
        internal const string       ADDPLAYLIST_DIALOG_TITLE = APPLICATION_NAME + " - Add PlayList";
        internal const string       SAVEPLAYLIST_DIALOG_TITLE = APPLICATION_NAME + " - Save PlayList";
        internal const string       PLAYLIST_DIALOG_FILTER = "PVS.AVPlayer PlayList|*.ppl|All files|*.*";
        internal static string      PlayListDirectory;

        // ScreenCopy
        private string              _screenCopyFile = _appDataPath + SCREENCOPY_NAME + ".png";
        private ImageFormat         _screenCopyFormat = ImageFormat.Png;

        // PlayList - a simple playlist with mediafilenames
        internal List<string>       PlayList;
        internal string             PlayListFile = _appDataPath + PLAYLIST_NAME + ".inf"; // default playlist
        private int                 _mediaToPlay; // the next mediafile in the playlist to play
        private const int           START_PLAYITEMS = 5; // used to skip the first playmenu items (like 'add mediafiles')

        // Display Overlay Examples
        private bool                _overlayMenuEnabled; // the visibility of an overlay menu is controlled from the main application
        private bool                _overlayHold; // overlay hold set by application
        private bool                _userOverlay; // overlay set by user (used with AutoOverlay)

        private MessageOverlay      _messageOverlay;
        private ScribbleOverlay     _scribbleOverlay;
        private TileOverlay         _tileOverlay;
        private BouncingOverlay     _bouncingOverlay;
        private PIPOverlay          _pipOverlay;
        private SubtitlesOverlay    _subtitlesOverlay;
        private ZoomSelectOverlay   _zoomSelectOverlay;
        private VideoWall           _allScreensOverlay;
        private Mp3CoverOverlay     _mp3CoverOverlay;
        private Mp3KaraokeOverlay   _mp3KaraokeOverlay;
        private BigTimeOverlay      _bigTimeOverlay;
        private StatusInfoOverlay   _statusInfoOverlay;

        // Used with Open webSite dialog
        private bool                _goToArticle = true;

        // Used with dialog mini players
        private Player[]            _dialogMiniPlayers = { null, null, null };

        // Voice Recorder and Voice Player
        private VoiceRecorder       _voiceRecorder;
        private VoicePlayer         _voicePlayer;

        // Position Changed eventhandler
        private bool                _posTimerBusy;
        private TimeSpan[]          _posTimes;

        // PlayMenu Drag and Drop
        private bool                _ddMouseDown;
        private bool                _ddOurDrag;
        private int                 _ddSourceIndex;
        private Point               _ddMouseLocation;
        private ToolStripMenuItem   _ddDragMenuItem;

        // Disposing
        private bool                _disposed;

        #endregion

        // ******************************** Main - Initializing / About

        #region Main - Initializing / About

        // Start up sequence:
        // 1. method Form1(): initialize all 'standard' items (player, overlays, etc.)
        // 2. method Form1_Shown(): check for (open with) arguments and set preferences, auto start etc.
        //
        // Using 2. because player needs form to be first time shown/activated for certain options (set overlay)


        // Application starting point (for us):
        public Form1()
        {
            InitializeComponent();                              // set designer items
            Icon = SystemIcons.Application;                     // set main window icon
            try { Directory.CreateDirectory(_appDataPath); }    // create preferences folder
            catch {}

            // Allow dropping media files on the form (handled in source file: DragDrop.cs):
            AllowDrop = true;
            DragEnter += Form1_DragEnter;
            DragDrop += Form1_DragDrop;

            // Install custom font
            InstallFontCollection();

            // fix: first time display of custom contextmenus is usually at wrong position (.NET bug))
            screenCopyMenu.AutoSize = false; screenCopyMenu.Height = 0; screenCopyMenu.Show(0, 0); screenCopyMenu.Close(); screenCopyMenu.AutoSize = true;
            copyModeMenu.AutoSize = false; copyModeMenu.Height = 0; copyModeMenu.Show(0, 0); copyModeMenu.Close(); copyModeMenu.AutoSize = true; 

            // Create the main Player:
            CreatePlayer();
            LoadPreferences(); // and load and set preferences (some prefs are set in Form1_Show())

            // Create voice recorder and voice player:
            CreateVoiceRecorder();
            // This comes after creating a player because some interface elements use player-settings:
            InitializeInterface(); // set up the user interface
            // Create a PlayList:
            CreatePlayList();
            // Create the Display Overlays:
            CreateDisplayOverlays();
            // (Almost) Ready to go:
            SetInterfaceOnMediaStop(true);

            _oldOpacity = Opacity;
            Opacity = 0; // 'continues' at Form1_Shown()
        }

        // Create the main Player
        private void CreatePlayer()
        {
            // Create a Player with display - Redraw ('Invalidate') resized Form with certain displaymodes
            Player1 = new Player(displayPanel) { ResizeFormRefresh = true };

            // Add Player EventHandlers:

            // Add a player media start eventhandler to update interface:
            Player1.MediaStarted += Player1_MediaStarted;
            // Add a player media end eventhandler to update interface and playing 'next' mediafiles (if autoPlayNext == true):
            Player1.MediaEnded += Player1_MediaEnded;
            // Add a player media stop eventhandler to update interface:
            Player1.MediaStopped += Player1_MediaStopped;
            // Add a player start- endposition changed event of the next media to play (to update start/end textbox values):
            Player1.MediaStartEndChanged += Player1_MediaStartEndChanged;
            // Add a media start- endposition changed event for the playing media (to update start/end textbox values):
            Player1.MediaStartEndMediaChanged += Player1_MediaStartEndMediaChanged;
            // Add a player media position eventhandler for showing position time strings (labels on both sides of the position slider):
            Player1.MediaPositionChanged += Player1_MediaPositionChanged;
            // Add a player display mode eventhandler for setting the displaymode menu when changed (with move and zoom):
            Player1.MediaDisplayModeChanged += Player1_MediaDisplayModeChanged;
            // Add a player pause and resume eventhandler (using same handler) to update the Pause button and text of display contextmenu:
            Player1.MediaPaused += Player1_MediaPausedResumed;
            Player1.MediaResumed += Player1_MediaPausedResumed;
            // Display the playback relative speed next to the speedslider:
            Player1.MediaSpeedChanged += Player1_MediaSpeedChanged;
            // Display audio volume and balance info next to audiosliders:
            Player1.MediaAudioVolumeChanged += Player1_MediaAudioVolumeChanged;
            Player1.MediaAudioBalanceChanged += Player1_MediaAudioBalanceChanged;
            // Fullscreen / Fullscreenmode may be set from preferences
            Player1.MediaFullScreenChanged += Player1_MediaFullScreenSettingsChanged;
            Player1.MediaFullScreenModeChanged += Player1_MediaFullScreenSettingsChanged;

            // User (app) actions (Next and Previous buttons/menu) - just generates events
            Player1.MediaNextRequested += Player1_MediaNextRequested;
            Player1.MediaPreviousRequested += Player1_MediaPreviousRequested;

            // Used to keep voice recorder windows on top
            Player1.MediaOverlayChanged += player1_MediaOverlayChanged;
        }

        // Create voice recorder and voice player
        private void CreateVoiceRecorder()
        {
            _voicePlayer = new VoicePlayer(this);
            _voiceRecorder = new VoiceRecorder(this, _voicePlayer);
        }

        // Set up the part of the user interface that hasn't been done by using the Visual Studio designer
        private void InitializeInterface()
        {
            // Set custom colored menus
            ToolStripManager.Renderer = new CustomMenuRenderer();

            // Set custom fonts
            positionLabel1.Font = _crystalFont16; positionLabel1.UseCompatibleTextRendering = true;
            positionLabel2.Font = _crystalFont16; positionLabel2.UseCompatibleTextRendering = true;

            zoomInButton.Font = _wingDng38; zoomInButton.UseCompatibleTextRendering = true;
            zoomOutButton.Font = _wingDng38; zoomOutButton.UseCompatibleTextRendering = true;

            moveUpButton.Font = _wingDng38; moveUpButton.UseCompatibleTextRendering = true;
            moveDownButton.Font = _wingDng38; moveDownButton.UseCompatibleTextRendering = true;
            moveLeftButton.Font = _wingDng38; moveLeftButton.UseCompatibleTextRendering = true;
            moveRightButton.Font = _wingDng38; moveLeftButton.UseCompatibleTextRendering = true;

            stretchUpButton.Font = _wingDng38; stretchUpButton.UseCompatibleTextRendering = true;
            stretchDownButton.Font = _wingDng38; stretchDownButton.UseCompatibleTextRendering = true;
            stretchLeftButton.Font = _wingDng38; stretchLeftButton.UseCompatibleTextRendering = true;
            stretchRightButton.Font = _wingDng38; stretchRightButton.UseCompatibleTextRendering = true;

            // This can't be done in the designer (?): remove left (check) margin in some menus:
            ((ToolStripDropDownMenu)playListMenuItem.DropDown).ShowImageMargin = false;
            ((ToolStripDropDownMenu)videoSizeMenuItem.DropDown).ShowImageMargin = false;
            ((ToolStripDropDownMenu)zoomVideoMenuItem.DropDown).ShowImageMargin = false;
            ((ToolStripDropDownMenu)moveVideoMenuItem.DropDown).ShowImageMargin = false;
            ((ToolStripDropDownMenu)stretchVideoMenuItem.DropDown).ShowImageMargin = false;
            ((ToolStripDropDownMenu)systemMenuItem.DropDown).ShowImageMargin = false;
            ((ToolStripDropDownMenu)voiceRecorderMenuItem.DropDown).ShowImageMargin = false;

            // Fill the DisplayMode dropdown menu and set the DisplayMode buttontext
            foreach (string item in Enum.GetNames(typeof(DisplayMode))) displayModeMenu.Items.Add(item);
            SetDisplayModeMenu(Player1.DisplayMode, false);

            // When one of the zoom or move buttons has focus (also set after selecting the option from
            // the pop-up display menu - so these options can also be used with fullscreen view)
            // you can also use the mouse scrollwheel to zoom in/out, move left/right or move up/down
            zoomInButton.MouseWheel += zoomInButton_MouseWheel;
            zoomOutButton.MouseWheel += zoomInButton_MouseWheel;

            moveUpButton.MouseWheel += moveUpButton_MouseWheel;
            moveDownButton.MouseWheel += moveUpButton_MouseWheel;
            moveLeftButton.MouseWheel += moveLeftButton_MouseWheel;
            moveRightButton.MouseWheel += moveLeftButton_MouseWheel;

            stretchUpButton.MouseWheel += stretchUpButton_MouseWheel;
            stretchDownButton.MouseWheel += stretchUpButton_MouseWheel;
            stretchLeftButton.MouseWheel += stretchLeftButton_MouseWheel;
            stretchRightButton.MouseWheel += stretchLeftButton_MouseWheel;

            // Let the player handle all the sliders (trackbars)
            Player1.SpeedSlider = speedSlider;
            Player1.PositionSlider = positionSlider;
            Player1.AudioVolumeSlider = volumeSlider;
            Player1.AudioBalanceSlider = balanceSlider;
            Player1.ShuttleSlider = shuttleSlider;

            // Create Open and Save FileDialogs:
            CreateFileDialogs();

            // Set contextmenus shortcut keys:
            SetShortCutKeys();

            // Besides the player's display contextmenu the ESC-key can be used to switch off fullscreen mode
            // Also handles a few media keyboard keys and others
            KeyPreview = true;
        }

        // Set the shortcut keys for some contextmenus that couldn't be set properly with the designer
        private void SetShortCutKeys()
        {
            // displayMenu
            stopMenuItem.ShortcutKeys = Keys.Control | Keys.OemPeriod;
            stopMenuItem.ShortcutKeyDisplayString = "Ctrl+.";

            // displayModeMenu
            // this Items[index] is used because the menu is generated from code (enums) and the items have no name
            ((ToolStripMenuItem)displayModeMenu.Items[2]).ShortcutKeys = Keys.F6;
            ((ToolStripMenuItem)displayModeMenu.Items[4]).ShortcutKeys = Keys.F7;
        }

        // Create the Display Overlays
        private void CreateDisplayOverlays()
        {
            _messageOverlay = new MessageOverlay(this);
            _scribbleOverlay = new ScribbleOverlay();
            _tileOverlay = new TileOverlay(this, Player1); // Interacts with the player
            _bouncingOverlay = new BouncingOverlay(Player1); // Interacts with the player
            _pipOverlay = new PIPOverlay(this); // Uses various 'things' from this Form (PlayList)
            _subtitlesOverlay = new SubtitlesOverlay(this, Player1); // Interacts with the player
            _zoomSelectOverlay = new ZoomSelectOverlay(Player1); // Interacts with the player
            _allScreensOverlay = new VideoWall(this, Player1);  // Interacts with the player
            _mp3CoverOverlay = new Mp3CoverOverlay(this, Player1); // Interacts with the player
            _mp3KaraokeOverlay = new Mp3KaraokeOverlay(Player1); // Interacts with the player
            _bigTimeOverlay = new BigTimeOverlay(this, Player1, FontCollection);  // Interacts with the player and uses custom font
            _statusInfoOverlay = new StatusInfoOverlay(this, Player1); // Interacts with the player
        }

        // Create a PlayList
        private void CreatePlayList()
        {
            PlayList = new List<string>();
        }

        // Create Open and Save FileDialogs
        private void CreateFileDialogs()
        {
            // Create an OpenFileDialog for selecting mediafiles / playlists
            OpenFileDialog1 = new OpenFileDialog();
            MediaDirectory = Prefs.MediaFilesFolder;

            // Create a SaveFileDialog for saving playlists
            SaveFileDialog1 = new SaveFileDialog {Title = SAVEPLAYLIST_DIALOG_TITLE, Filter = PLAYLIST_DIALOG_FILTER};
            PlayListDirectory = Prefs.PlaylistsFolder;
        }

        // Show the About message
        private void ShowAbout()
        {
            AboutDialog aboutMessage = new AboutDialog();
            SetDialogMiniPlayers(aboutMessage.panel1, aboutMessage.panel2, aboutMessage.panel3);
            CenterDialog(this, aboutMessage);
            aboutMessage.ShowDialog(this);
            DisposeDialogMiniPlayers();
            aboutMessage.Dispose();

            toolTip1.Active = Prefs.ShowTooltips;
            if (UrlClicked) webSiteLabel_Click(this, EventArgs.Empty);
        }

        #endregion

        // ******************************** Main Form EventHandling / Player EventHandling

        #region Main Form EventHandling - Shown / Closed / KeyDown / Textboxes Enter Key / Dispose

        // When the main form (already initialized) is shown for the first time
        private void Form1_Shown(object sender, EventArgs e)
        {
            bool autoPlayArg = false;
            bool autoPlayMp3 = false;

            // Initial position Voice Recorder windows
            _voicePlayer.Left = Left + (Width - _voicePlayer.Width) / 2;
            _voicePlayer.Top = 40 + Top + (Height - _voicePlayer.Height) / 2;
            _voiceRecorder.Left = _voicePlayer.Left;
            _voiceRecorder.Top = _voicePlayer.Top - _voiceRecorder.Height - 3;

            // Set Window Size and Position Preference:
            if (Prefs.SaveWindow || (Prefs.ContinuePlay && Prefs.MediaToPlay >= 0))
            {
                if (Prefs.Maximized) WindowState = FormWindowState.Maximized;
                Player1.FullScreenMode = Prefs.FullScreenMode;
                Player1.FullScreen = Prefs.Fullscreen;
            }
            toolTip1.Active = Prefs.ShowTooltips;

            #region Get commandline args or load standard PlayList

            // Get commandline args ('open with') or (if no args) load the (default) playlist
            string[] clArgs = Environment.GetCommandLineArgs();
            if (clArgs.Length > 1)
            {
                string[] copyArgs = new string[clArgs.Length - 1];
                for (int i = 1; i < clArgs.Length; i++) { copyArgs[i - 1] = clArgs[i]; }

                if (string.Equals(Path.GetExtension(copyArgs[0]), ".ppl", StringComparison.OrdinalIgnoreCase))
                {
                    try
                    {
                        PlayList = new List<string>(File.ReadAllLines(copyArgs[0]));
                        ReBuildPlayListMenu();
                    }
                    catch { LoadPlayList(); }
                }
                else AddToPlayList(copyArgs);

                if (PlayList.Count > 0)
                {
                    if (!Prefs.AutoOverlay)
                    {
                        string extension = Path.GetExtension(PlayList[0]);
                        autoPlayMp3 = string.Equals(extension, ".mp3", StringComparison.OrdinalIgnoreCase) || string.Equals(extension, ".wma", StringComparison.OrdinalIgnoreCase);
                    }
                    if (!Prefs.AutoPlayStart) autoPlayArg = true;
                }
            }
            else LoadPlayList();

            #endregion

            if (autoPlayArg)
            {
                PlayNextMedia();
                if (autoPlayMp3) SetOverlay(MP3CoverMenuItem, _mp3CoverOverlay, false, true);
            }
            else // if not playing from 'Open With':
            {
                // Continue Play Preference:
                if (Prefs.ContinuePlay && Prefs.MediaToPlay >= 0 && PlayList.Count > Prefs.MediaToPlay)
                {
                    // Start- / EndPosition / Paused
                    if (Prefs.Paused || !Prefs.VideoPresent) Player1.StartPosition = TimeSpan.FromMilliseconds(Prefs.Position);
                    else
                    {
                        double startPos = Prefs.Position - (Prefs.RewindSecs * 1000);
                        Player1.StartPosition = startPos < Prefs.StartPosition ? TimeSpan.FromMilliseconds(Prefs.StartPosition) : TimeSpan.FromMilliseconds(startPos);
                    }
                    Player1.EndPosition = TimeSpan.FromMilliseconds(Prefs.EndPosition);
                    Player1.Paused = Prefs.Paused;

                    // Overlay
                    if (Prefs.Overlay >= 0) displayOverlayMenu.Items[Prefs.Overlay].PerformClick();

                    _mediaToPlay = Prefs.MediaToPlay;
                    PlayNextMedia();

                    // Startposition reset
                    Player1.StartPositionMedia = TimeSpan.FromMilliseconds(Prefs.StartPosition);

                    // Overlay mode reset
                    if (Prefs.Overlay >= 0 && Prefs.AutoOverlay) _userOverlay = false;
                }
                // Auto Play at Program Start Preference?
                else if (Prefs.AutoPlayStart && PlayList.Count > 0)
                {
                    _mediaToPlay = 0;
                    PlayNextMedia();
                }

                if (Player1.Overlay == null && Prefs.SaveOverlay && Prefs.Overlay >= 0) displayOverlayMenu.Items[Prefs.Overlay].PerformClick();
                if (Prefs.SaveRepeat || Player1.Playing)
                {
                    switch (Prefs.Repeat)
                    {
                        case 1:
                            repeatOneMenuItem.PerformClick();
                            break;
                        case 2:
                            repeatAllMenuItem.PerformClick();
                            break;
                        case 3:
                            shuffleMenuItem.PerformClick();
                            break;
                    }
                }
            }

            Application.DoEvents();
            Opacity = _oldOpacity; // reduce flicker on opening

            // application now is up and running and ready for user input
        }

        // Save the preferences file (that needs, among others, the latest window settings)
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.DoEvents();
            SavePreferences();
        }

        // Handles keyboard keys
        // As there is a problem with the position of the contextmenus (see DropDownButton)
        // there's also a problem (?) with the shortcut keys... they don't work before the menu has been opened once.
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control) // Handle CTRL combinations
            {
                #region Handle CTRL KeyCodes

                switch (e.KeyCode)
                {
                    case Keys.Enter: // Play - start playing first item in playlist
                        if (!Player1.Playing && PlayList.Count > 0)
                        {
                            _mediaToPlay = 0;
                            if (RepeatShuffle) SetShuffleList();
                            PlayNextMedia();
                        }
                        e.Handled = true;
                        break;

                    case Keys.N: // New Playlist
                        newPlayListMenuItem.PerformClick();
                        e.Handled = true;
                        break;
                    case Keys.O: // Open Playlist
                        openPlayListMenuItem.PerformClick();
                        e.Handled = true;
                        break;
                    case Keys.A: // Add Playlist
                        addPlayListMenuItem.PerformClick();
                        e.Handled = true;
                        break;
                    case Keys.S: // Save Playlist As
                        savePlayListMenuItem.PerformClick();
                        e.Handled = true;
                        break;

                    case Keys.M: // Add MediaFiles
                        addMediaFilesMenuItem.PerformClick();
                        e.Handled = true;
                        break;
                    case Keys.U: // Add Media Urls
                        addMediaURLMenuItem.PerformClick();
                        e.Handled = true;
                        break;

                    case Keys.B: // Play Previous
                        previousMenuItem.PerformClick();
                        e.Handled = true;
                        break;
                    case Keys.F: // Play Next
                        nextMenuItem.PerformClick();
                        e.Handled = true;
                        break;
                    case Keys.Q: // Quit Application
                        e.Handled = true;
                        quitMenuItem.PerformClick();
                        break;
                    case Keys.Space: // Pause/Resume Playing
                        pauseMenuItem.PerformClick();
                        e.Handled = true;
                        break;
                    case Keys.OemPeriod: // Stop Playing
                        stopMenuItem.PerformClick();
                        e.Handled = true;
                        break;

                    // Speed
                    case Keys.Add:
                    case Keys.Oemplus: // Speed Increase
                        Player1.Speed += 100;
                        e.Handled = true;
                        break;
                    case Keys.Subtract:
                    case Keys.OemMinus: // Speed Decrease
                        Player1.Speed -= 100;
                        e.Handled = true;
                        break;

                    // Audio
                    case Keys.Up: // Audio Volume Up
                        Player1.AudioVolume += 100;
                        e.Handled = true;
                        break;
                    case Keys.Down: // Audio Volume Down
                        Player1.AudioVolume -= 100;
                        e.Handled = true;
                        break;
                    case Keys.Left: // Audio Balance Left
                        Player1.AudioBalance -= 100;
                        e.Handled = true;
                        break;
                    case Keys.Right: // Audio Balance Right
                        Player1.AudioBalance += 100;
                        e.Handled = true;
                        break;
                    case Keys.NumPad0:
                    case Keys.D0: // Audio Mute On/Off
                        Player1.AudioVolume = Player1.AudioVolume == 0 ? 1000 : 0;
                        e.Handled = true;
                        break;
                }

                #endregion
            }
            else if (e.Alt) // Handle ALT combinations (Display Overlays)
            {
                #region Handle ALT KeyCodes

                switch (e.KeyCode)
                {
                    // Display Overlays

                    // Toggle Overlay Mode
                    case Keys.D: // Overlay Display
                    case Keys.V: // Overlay Video
                        if (Player1.OverlayMode == OverlayMode.Display) videoMenuItem.PerformClick();
                        else displayMenuItem.PerformClick();
                        e.Handled = true;
                        break;

                    case Keys.H: // Overlay Hold
                        overlayHoldMenuItem.PerformClick();
                        e.Handled = true;
                        break;

                    // Activate example overlay
                    case Keys.F1:
                            messageMenuItem.PerformClick();
                            e.Handled = true;
                            break;
                    case Keys.F2:
                            scribbleMenuItem.PerformClick();
                            e.Handled = true;
                            break;
                    case Keys.F3:
                            tilesMenuItem.PerformClick();
                            break;
                    case Keys.F4:
                            bouncingMenuItem.PerformClick();
                            e.Handled = true;
                            break;
                    case Keys.F5:
                            PiPMenuItem.PerformClick();
                            break;
                    case Keys.F6:
                            subtitlesMenuItem.PerformClick();
                            break;
                    case Keys.F7:
                            zoomSelectMenuItem.PerformClick();
                            e.Handled = true;
                            break;
                    case Keys.F8:
                            videoWallMenuItem.PerformClick();
                            e.Handled = true;
                            break;
                    case Keys.F9:
                            MP3CoverMenuItem.PerformClick();
                            e.Handled = true;
                            break;
                    case Keys.F10:
                            MP3KaraokeMenuItem.PerformClick();
                            e.Handled = true;
                            break;
                    case Keys.F11:
                            bigTimeMenuItem.PerformClick();
                            e.Handled = true;
                            break;
                    case Keys.F12:
                            statusInfoMenuItem.PerformClick();
                            e.Handled = true;
                            break;

                    case Keys.O:
                    case Keys.D0: // Overlay Off
                            overlayOffMenuItem.PerformClick();
                            e.Handled = true;
                            break;

                    case Keys.S:
                    case Keys.M: // Show Overlay Menu On/Off
                            overlayMenuMenuItem.PerformClick();
                            e.Handled = true;
                            break;
                }

                #endregion
            }
            else
            {
                #region Handle KeyCodes

                switch (e.KeyCode)
                {
                    // handle a few media keyboard keys:
                    // (audio (volume/mute) is handled by Windows)
                    case Keys.MediaNextTrack: // Play Next
                        nextMenuItem.PerformClick();
                        e.Handled = true;
                        break;
                    case Keys.MediaPlayPause: // Pause/Resume Playing
                        pauseMenuItem.PerformClick();
                        e.Handled = true;
                        break;
                    case Keys.MediaPreviousTrack: // Play Previous
                        previousMenuItem.PerformClick();
                        e.Handled = true;
                        break;
                    case Keys.MediaStop: // Stop Playing
                        stopMenuItem.PerformClick();
                        e.Handled = true;
                        break;

                    // Function keys
                    case Keys.F1: // Show About
                        e.Handled = true;
                        nameLabel_Click(nameLabel, EventArgs.Empty);
                        break;
                    case Keys.F2: // Ask Open WebSite
                        e.Handled = true;
                        webSiteLabel_Click(webSiteLabel, EventArgs.Empty);
                        break;

                    case Keys.F3: // Screencopy Copy
                        e.Handled = true;
                        if (e.Shift) clearCopyMenuItem.PerformClick();
                        else copyMenuItem.PerformClick();
                        break;
                    case Keys.F4: // Screencopy Open
                        e.Handled = true;
                        openCopyMenuItem.PerformClick();
                        break;
                    case Keys.F5: // Screencopy Open With
                        e.Handled = true;
                        openWithCopyMenuItem.PerformClick();
                        break;

                    case Keys.F6: // DisplayMode Stretch
                        e.Handled = true;
                        SetDisplayModeMenu(DisplayMode.Stretch, true);
                        break;
                    case Keys.F7: // DisplayMode ZoomAndCenter
                        e.Handled = true;
                        SetDisplayModeMenu(DisplayMode.ZoomAndCenter, true);
                        break;

                    case Keys.F8: // FullScreen Form
                        e.Handled = true;
                        fullScreenFormMenuItem.PerformClick();
                        break;
                    case Keys.F9: // // FullScreen Parent
                        e.Handled = true;
                        fullScreenParentMenuItem.PerformClick();
                        break;
                    case Keys.F10: // // FullScreen Display
                        e.Handled = true;
                        fullScreenDisplayMenuItem.PerformClick();
                        break;
                    case Keys.F11: // // FullScreen On/Off
                        e.Handled = true;
                        fullScreenOffMenuItem.PerformClick();
                        break;

                    // ESC key
                    case Keys.Escape:
                        if (Player1.FullScreen)
                        {
                            Player1.FullScreen = false;
                            SetFullScreenModeMenu();
                        }
                        else stopMenuItem.PerformClick();
                        e.Handled = true;
                        break;
                }

                #endregion
            }
        }

        // Position textboxes Enter key
        private void positionTextBoxes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                if (sender == startPositionTextBox || sender == startPositionMediaTextBox) ProcessTabKey(true);
                else ProcessTabKey(false);
            }
        }

        // Speed textbox Enter key
        private void speedTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                ProcessTabKey(true);
                //ProcessTabKey(false); // cursor back to textbox
            }
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // stop (if) playing and free overlay (if any)
                    Player1.Stop();
                    Player1.Overlay = null;

                    // Clean up example display overlays
                    _messageOverlay.Dispose(); _messageOverlay = null;
                    _scribbleOverlay.Dispose(); _scribbleOverlay = null;
                    _tileOverlay.Dispose(); _tileOverlay = null;
                    _bouncingOverlay.Dispose(); _bouncingOverlay = null;
                    _pipOverlay.Dispose(); _pipOverlay = null;
                    _subtitlesOverlay.Dispose(); _subtitlesOverlay = null;
                    _zoomSelectOverlay.Dispose(); _zoomSelectOverlay = null;
                    _allScreensOverlay.Dispose(); _allScreensOverlay = null;
                    _mp3CoverOverlay.Dispose(); _mp3CoverOverlay = null;
                    _mp3KaraokeOverlay.Dispose(); _mp3KaraokeOverlay = null;
                    _bigTimeOverlay.Dispose(); _bigTimeOverlay = null;
                    _statusInfoOverlay.Dispose(); _statusInfoOverlay = null;

                    // unsubscribe from flashing button timer
                    if (Player1.Paused) ButtonFlash.Remove(pauseButton);

                    // reset preventing computer going to sleep
                    // not really needed as player.dispose resets sleep mode
                    Player1.SleepDisabled = false;

                    // Clean up player
                    Player1.Dispose(); Player1 = null;

                    // Clean up voice recorder and player
                    _voiceRecorder.Dispose(); _voiceRecorder = null;
                    _voicePlayer.Dispose(); _voicePlayer = null;

                    // Clean up custom fonts
                    _crystalFont16.Dispose(); _crystalFont16 = null;
                    FontCollection.Dispose(); FontCollection = null;

                    // Clean up file dialogs
                    OpenFileDialog1.Dispose(); OpenFileDialog1 = null;
                    SaveFileDialog1.Dispose(); SaveFileDialog1 = null;

                    // Clear playlist
                    PlayList.Clear();

                    if (components != null) components.Dispose();
                }
                _disposed = true;
                base.Dispose(disposing);
            }
        }

        #endregion

        #region Player EventHandling

        // A mediafile has started playing
        void Player1_MediaStarted(object sender, EventArgs e)
        {
            SetInterfaceOnMediaStart();
        }

        // A mediafile has finished playing
        void Player1_MediaEnded(object sender, EventArgs e)
        {
            if (Prefs.AutoPlayNext)
            {
                // doesn't get here with repeatOne
                SetInterfaceOnMediaStop(false);

                if (RepeatAll || RepeatShuffle || _mediaToPlay < PlayList.Count) PlayNextMedia();
                else SetInterfaceOnMediaStop(true);
            }
            else SetInterfaceOnMediaStop(true);
        }

        // The player's start/endposition (for the next media to play) has changed.
        void Player1_MediaStartEndChanged(object sender, EventArgs e)
        {
            startPositionTextBox.SuspendLayout();
            endPositionTextBox.SuspendLayout();

            startPositionTextBox.Text = Player1.StartPosition.ToString().Substring(0, 8);
            endPositionTextBox.Text = Player1.EndPosition.ToString().Substring(0, 8);

            if (Player1.StartPosition.TotalMilliseconds == 0)
            {
                if (Player1.EndPosition.TotalMilliseconds == 0)
                {
                    startPositionTextBox.ForeColor = endPositionTextBox.ForeColor = Color.FromArgb(189, 159, 87);
                }
                else
                {
                    startPositionTextBox.ForeColor = Color.Green;
                    endPositionTextBox.ForeColor = Color.Firebrick;
                }
            }
            else
            {
                startPositionTextBox.ForeColor = Color.Firebrick;
                endPositionTextBox.ForeColor = Player1.EndPosition.TotalMilliseconds == 0 ? Color.Green : Color.Firebrick;
            }

            endPositionTextBox.ResumeLayout();
            startPositionTextBox.ResumeLayout();
        }

        // The playing media's start/endposition has changed.
        void Player1_MediaStartEndMediaChanged(object sender, EventArgs e)
        {
            startPositionMediaTextBox.SuspendLayout();
            endPositionMediaTextBox.SuspendLayout();

            startPositionMediaTextBox.Text = Player1.StartPositionMedia.ToString().Substring(0, 8);
            endPositionMediaTextBox.Text = Player1.EndPositionMedia.ToString().Substring(0, 8);

            if (Player1.StartPositionMedia.TotalMilliseconds == 0)
            {
                if (Player1.EndPositionMedia.TotalMilliseconds == 0 || Player1.EndPositionMedia == Player1.GetMediaLength(MediaLength.Total))
                {
                    startPositionMediaTextBox.ForeColor = endPositionMediaTextBox.ForeColor = Color.FromArgb(189, 159, 87);
                }
                else
                {
                    startPositionMediaTextBox.ForeColor = Color.Green;
                    endPositionMediaTextBox.ForeColor = Color.Firebrick;
                }
            }
            else
            {
                startPositionMediaTextBox.ForeColor = Color.Firebrick;
                if (Player1.EndPositionMedia.TotalMilliseconds == 0 || Player1.EndPositionMedia == Player1.GetMediaLength(MediaLength.Total)) endPositionMediaTextBox.ForeColor = Color.Green;
                else endPositionMediaTextBox.ForeColor = Color.Firebrick;
            }

            endPositionMediaTextBox.ResumeLayout();
            startPositionMediaTextBox.ResumeLayout();
        }

        // A mediafile has stopped playing (by user command Stop)
        void Player1_MediaStopped(object sender, EventArgs e)
        {
            SetInterfaceOnMediaStop(!StopAndPlay);
            StopAndPlay = false;
        }

        // The playback position of a mediafile has changed - update position info labels
        void Player1_MediaPositionChanged(object sender, EventArgs e)
        {
            if (_posTimerBusy) return;
            _posTimerBusy = true;

            if (Player1.PositionSliderMode == PositionSliderMode.Track)
            {
                _posTimes = Player1.GetTrackTimes();
                positionLabel1.Text = _posTimes[0].ToString().Substring(0, 8);
                positionLabel2.Text = _posTimes[1].ToString().Substring(0, 8);
            }
            else
            {
                _posTimes = Player1.GetProgressTimes(false);
                positionLabel1.Text = string.Format("{0:00;00}:{1:00;00}:{2:00;00}", (int)_posTimes[0].TotalHours, _posTimes[0].Minutes, _posTimes[0].Seconds);
                positionLabel2.Text = string.Format("{0:00;00}:{1:00;00}:{2:00;00}", (int)_posTimes[1].TotalHours, _posTimes[1].Minutes, _posTimes[1].Seconds);
            }

            _posTimerBusy = false;
        }

        // The player's displaymode has changed (to 'Manual' with VideoMove or VideoZoom) - set the displaymode menu
        void Player1_MediaDisplayModeChanged(object sender, EventArgs e)
        {
            // false = no need to set the player's displaymode (again)
            SetDisplayModeMenu(Player1.DisplayMode, false);
        }

        // This handler is used for both the player's pause and resume events
        void Player1_MediaPausedResumed(object sender, EventArgs e)
        {
            if (Player1.Paused)
            {
                ButtonFlash.Add(pauseButton, pauseButton.ForeColor, Color.Black);
                pauseMenuItem.Text = "Resume";
                Player1.SleepDisabled = false;
            }
            else
            {
                ButtonFlash.Remove(pauseButton);
                pauseMenuItem.Text = "Pause";
                if (Player1.Playing) Player1.SleepDisabled = true;
            }
        }

        // The player's playback speed has changed - show the playback speed next to the speedslider
        void Player1_MediaSpeedChanged(object sender, EventArgs e)
        {
            speedTextBox.Text = ((double)Player1.Speed / 1000).ToString("0.00");
            speedLight.LightOn = Player1.Speed != 1000;
        }

        // The player's audio volume has changed - show the value next to the audiovolumeslider
        void Player1_MediaAudioVolumeChanged(object sender, EventArgs e)
        {
            if (Player1.AudioVolume == 0)
            {
                audioVolumeLabel.Text = "Mute";
                volumeLight.LightOn = true;
            }
            else
            {
                audioVolumeLabel.Text = Player1.AudioVolume == 1000 ? "Max" : ((double)Player1.AudioVolume / 100).ToString("0.0");
                volumeLight.LightOn = false;
            }
        }

        // The player's audio balance has changed - show the value next to the audiobalanceslider
        void Player1_MediaAudioBalanceChanged(object sender, EventArgs e)
        {
            if (Player1.AudioBalance == 500) audioBalanceLabel.Text = "Center";
            else if (Player1.AudioBalance < 500) audioBalanceLabel.Text = ((500 - (double)Player1.AudioBalance) / 50).ToString("Left 0.0");
            else audioBalanceLabel.Text = (((double)Player1.AudioBalance - 500) / 50).ToString("Right 0.0");
        }

        // The user (app) has requested previous media (button/menu)
        void Player1_MediaPreviousRequested(object sender, EventArgs e)
        {
            PlayPreviousMedia();
        }

        // The user (app) has requested next media (button/menu)
        void Player1_MediaNextRequested(object sender, EventArgs e)
        {
            PlayNextMedia();
        }

        // Fullscreen / FullscreenMode settings has changed (from preferences settings)
        void Player1_MediaFullScreenSettingsChanged(object sender, EventArgs e)
        {
            SetFullScreenModeMenu();
        }

        // Keep voice recorder windows on top
        void player1_MediaOverlayChanged(object sender, EventArgs e)
        {
            if (Player1.Overlay == null)
            {
                _voiceRecorder.Owner = this;
                _voicePlayer.Owner = this;
            }
            else
            {
                _voiceRecorder.Owner = Player1.Overlay;
                _voicePlayer.Owner = Player1.Overlay;
            }
        }

        #endregion

        // ******************************** Set Interface On Media Start and Media End/Stop

        #region Set Interface On Media Start and Media End/Stop

        // When a mediafile starts or ends/stops playing a few things in the interface may have to be changed
        // Called from MediaStart, MediaEnd and MediaStop eventhandlers

        private void SetInterfaceOnMediaStart()
        {
            // Set the (position) sliderContextMenu
            markStartPositionMenuItem.Enabled = true;
            markEndPositionMenuItem.Enabled = true;
            startRepeatMenuItem.Enabled = true;
            mark1MenuItem.Enabled = true;
            if (_mark1 != TimeSpan.Zero) goToMark1MenuItem.Enabled = true;
            goToStartMenuItem.Enabled = true;

            startPositionMediaTextBox.Enabled = true;
            endPositionMediaTextBox.Enabled = true;

            // Set window title
            Text = Player1.GetMediaName(MediaName.FileNameWithoutExtension) + " - " + APPLICATION_NAME;

            // Set zoom and move buttons enabled/disabled
            SetZoomPanelStatus(Player1.VideoPresent);

            // Turn on the Play button light
            playButtonLight.LightOn = true;
            _errorCount = 0;

            // Set checkmark playlist
            ((ToolStripMenuItem)playMenu.Items[_mediaToPlay + START_PLAYITEMS - 1]).Checked = true;

            // set overlay hold by application
            if (_overlayHold)
            {
                if(!Player1.OverlayHold && Player1.Overlay != null) overlayHoldMenuItem.Checked = Player1.OverlayHold = true;
            }

            // prevent computer going to sleep while playing a mediafile
            // PVS lib takes care of everything, no need to test if already on
            Player1.SleepDisabled = true;
        }

        private void SetInterfaceOnMediaStop(bool setAll)
        {
            // Reset position slider marks
            _mark1 = TimeSpan.Zero;

            // Reset checkmark playlist
            UnCheckMenuItems(playMenu, START_PLAYITEMS, 0);

            if (setAll) // used to prevent 'flashing' interface elements - see PlayMedia
            {
                if (Player1.Overlay != null)
                {
                    if (!_userOverlay) overlayOffMenuItem.PerformClick();
                    else ((IOverlay)Player1.Overlay).MediaStopped();
                }

                // Turn off the Play button light
                playButtonLight.LightOn = false;
                _errorCount = 0; // reset error count

                // Set the (position) sliderContextMenu
                markStartPositionMenuItem.Enabled = false;
                markEndPositionMenuItem.Enabled = false;
                startRepeatMenuItem.Enabled = false;
                mark1MenuItem.Enabled = false;
                goToMark1MenuItem.Enabled = false;
                goToStartMenuItem.Enabled = false;

                startPositionMediaTextBox.Enabled = false;
                endPositionMediaTextBox.Enabled = false;

                SetZoomPanelStatus(false);

                // Set window title
                Text = APPLICATION_NAME;

                // reset overlay hold by application
                if (_overlayHold)
                {
                    overlayHoldMenuItem.Checked = Player1.OverlayHold = false;
                }

                // reset preventing computer going to sleep (if no other players are using SleepDisabled)
                // PVS lib takes care of everything, no need to test if already off
                Player1.SleepDisabled = false;
            }
        }

        private void SetZoomPanelStatus(bool status)
        {
            zoomInButton.Enabled = status;
            zoomOutButton.Enabled = status;

            moveUpButton.Enabled = status;
            moveLeftButton.Enabled = status;
            moveRightButton.Enabled = status;
            moveDownButton.Enabled = status;

            stretchUpButton.Enabled = status;
            stretchLeftButton.Enabled = status;
            stretchRightButton.Enabled = status;
            stretchDownButton.Enabled = status;

            zoomVideoMenuItem.Enabled = status;
            zoomVideoMenuItem.DropDown.Enabled = status;
            moveVideoMenuItem.Enabled = status;
            moveVideoMenuItem.DropDown.Enabled = status;
            stretchVideoMenuItem.Enabled = status;
            stretchVideoMenuItem.DropDown.Enabled = status;
        }

        #endregion

        // ******************************** Player PlayMedia (includes errormessagebox) / PlayNextMedia / PlayPreviousMedia

        #region Player PlayMedia / PlayNextMedia / PlayPreviousMedia

        // Play a mediafile
        private void PlayMedia(string fileName)
        {
            StopAndPlay = Player1.Playing;

            if (Player1.Play(fileName) != NO_ERROR)
            {
                if (Prefs.ShowErrorMessages)
                {
                    string errorHint = "";
                    if (Player1.LastErrorCode == 277) // Error initializing MCI
                    {
                        if (fileName.EndsWith(".mp3", StringComparison.OrdinalIgnoreCase)) errorHint = "\r\n\r\nThe mp3 file may be damaged or may have albumart embedded that causes trouble (albumart can be removed with an mp3 tag editor).";
                        else if (fileName.StartsWith("http:", StringComparison.OrdinalIgnoreCase)) errorHint = "";
                        else errorHint = "\r\n\r\nThe file may be damaged or you have to install additional codecs on your computer (e.g. K-Lite Codec Pack) to play this file.";
                    }

                    ErrorDialog errorDialog = new ErrorDialog(APPLICATION_NAME, "Media:\r\n" + fileName + "\r\n\r\n" + Player1.LastErrorString + errorHint, false);
                    CenterDialog(this, errorDialog);

                    errorDialog.PlayNext = Prefs.OnErrorPlayNext;
                    errorDialog.OnErrorRemove = Prefs.OnErrorRemove;

                    if (PlayList.Count < 2) errorDialog.PlayNextVisible = false;

                    errorDialog.ShowDialog(this);

                    Prefs.OnErrorPlayNext = errorDialog.PlayNext;
                    Prefs.OnErrorRemove = errorDialog.OnErrorRemove;

                    errorDialog.Dispose();
                }

                // Remove error mediafile from playlist
                if (Prefs.OnErrorRemove)
                {
                    PlayList.RemoveAt(--_mediaToPlay);
                    ReBuildPlayListMenu();
                    SavePlayList();
                    if (RepeatShuffle)
                    {
                        CreateShuffleList();
                        SetShuffleList();
                    }
                }

                // Continue playing next mediafile
                if (Prefs.OnErrorPlayNext && PlayList.Count > 1 && ++_errorCount < 2)
                {
                    if (RepeatAll || RepeatShuffle || _mediaToPlay < PlayList.Count) PlayNextMedia();
                    else SetInterfaceOnMediaStop(true);
                }
                else SetInterfaceOnMediaStop(true);
            }
            else
            {
                _errorCount = 0;

                // automatic detection of overlay (only if user has not selected an overlay)
                if (Prefs.AutoOverlay && !_userOverlay)
                {
                    bool overlaySet = false;
                    if (Player1.VideoPresent)
                    {
                        // Subtitles Overlay
                        if (File.Exists(Path.ChangeExtension(Player1.GetMediaName(MediaName.FullPath), "srt")))
                        {
                            subtitlesMenuItem.PerformClick();
                            overlaySet = true;
                        }
                    }
                    else
                    {
                        // MP3Cover or MP3Karaoke Overlay
                        if (String.Equals(Player1.GetMediaName(MediaName.Extension), ".mp3", StringComparison.OrdinalIgnoreCase) 
                            && File.Exists(Path.ChangeExtension(Player1.GetMediaName(MediaName.FullPath), "cdg")))
                        {
                            MP3KaraokeMenuItem.PerformClick();
                        }
                        else MP3CoverMenuItem.PerformClick();
                        overlaySet = true;
                    }
                    if (!overlaySet) overlayOffMenuItem.PerformClick();
                    else _userOverlay = false;
                }
            }
        }

        // Play next mediafile and update the 'next' counter
        private void PlayNextMedia()
        {
            if (PlayList.Count > 0)
            {
                if (RepeatShuffle)
                {
                    if (_shuffleToPlay >= _shuffleList.Length)
                    {
                        // create new shufflelist and prevent new first = old last
                        int i = _shuffleList[_shuffleList.Length - 1];
                        CreateShuffleList();
                        if (_shuffleList[0] == i)
                        {
                            _shuffleList[0] = _shuffleList[_shuffleList.Length - 1];
                            _shuffleList[_shuffleList.Length - 1] = i;
                        }
                    }
                    _mediaToPlay = _shuffleList[_shuffleToPlay++];
                }
                else
                {
                    if (_mediaToPlay >= PlayList.Count) _mediaToPlay = 0;
                }
                PlayMedia(PlayList[_mediaToPlay++]);
            }
        }

        // Play previous mediafile and update the 'next' counter
        private void PlayPreviousMedia()
        {
            if (PlayList.Count > 0)
            {
                if (RepeatShuffle)
                {
                    _shuffleToPlay -= 2;
                    if (_shuffleToPlay < 0) _shuffleToPlay = _shuffleList.Length - 1;
                    _mediaToPlay = _shuffleList[_shuffleToPlay++];
                }
                else
                {
                    _mediaToPlay -= 2;
                    if (_mediaToPlay < 0) _mediaToPlay = PlayList.Count - 1;
                }
                PlayMedia(PlayList[_mediaToPlay++]);
            }
        }

        #endregion

        // ******************************** User Interface Handling

        // About the menus:
        // All (dropdown/pop-up) menus are handled by a usercontrol (dropdownbutton) or the standard windows
        // contextmenu handler (right mousebutton), so all there is to do is to handle the menu items selected,
        // except for the playmenu, which has an additional pop-up menu and drag & drop.

        // ******************************** Dialog Mini Players

        #region Dialog Mini Players

        // Dialog Mini Players are players with small displays on dialogs...
        // Just for (example) fun...
        internal void SetDialogMiniPlayers(Control display1, Control display2, Control display3)
        {
            // player1 is the example's app main player
            if (Prefs.ShowMiniPlayers && Player1.VideoPresent)
            {
                Control[] miniDisplays = { display1, display2, display3 };
                int i = 0;

                while (i < 3 && miniDisplays[i] != null)
                {
                    _dialogMiniPlayers[i] = new Player()
                    {
                        Display = miniDisplays[i],
                        StartPosition = Player1.Position,
                        EndPosition = Player1.EndPositionMedia, // (Start/End Position vs Start/End PositionMedia)
                        Repeat = Player1.Repeat,
                        AudioEnabled = false,
                        Speed = Player1.Speed,
                        Paused = Player1.Paused
                    };
                    _dialogMiniPlayers[i].Play(Player1.GetMediaName(MediaName.FullPath));
                    _dialogMiniPlayers[i++].StartPositionMedia = Player1.StartPositionMedia;
                }
            }
        }

        private void DisposeDialogMiniPlayers()
        {
            int i = 0;
            while (i < 3 && _dialogMiniPlayers[i] != null)
            {
                _dialogMiniPlayers[i].Dispose();
                _dialogMiniPlayers[i++] = null;
            }
        }

        #endregion

        // ******************************** Name and WebSite Label Click (Show About message / Open WebSite)

        #region Name and WebSite Label Click (Show About message / Open WebSite)

        // Clicking on the nameLabel shows the About message
        private void nameLabel_Click(object sender, EventArgs e)
        {
            ShowAbout();
        }

        // Clicking on the webSiteLabel asks for opening a website
        private void webSiteLabel_Click(object sender, EventArgs e)
        {
            string theWebPage = @"http://www.codeproject.com";

            WebSiteDialog webSiteDialog = new WebSiteDialog {Text = APPLICATION_NAME, Selection = _goToArticle};
            CenterDialog(this, webSiteDialog);

            SetDialogMiniPlayers(webSiteDialog.panel3, webSiteDialog.panel4, null);

            if (webSiteDialog.ShowDialog(this) == DialogResult.OK)
            {
                _goToArticle = webSiteDialog.Selection;
                DisposeDialogMiniPlayers();
                webSiteDialog.Dispose();

                if (_goToArticle) theWebPage += @"/KB/dotnet/PVS_AVPlayer.aspx";
                try
                {
                    Process.Start(theWebPage);
                }
                catch
                {
                    MessageBox.Show(
                    caption: APPLICATION_NAME,
                    icon: MessageBoxIcon.Exclamation,
                    text: "Could not open the requested webpage. Please check your Browser.",
                    buttons: MessageBoxButtons.OK,
                    owner: this);
                }
            }
            else
            {
                DisposeDialogMiniPlayers();
                webSiteDialog.Dispose();
            }
        }

        #endregion

        // ******************************** Play Button / PlayMenu Drag and Drop / Pause Button / Stop Button

        #region Play Button / Play Menu

        // When the Playbutton is clicked a Play contextmenu will be shown
        // The Play contextmenu has a pop-up submenu that is activated (shown) when the right mousebutton is clicked
        // The Play contextmenu is also used as a dropdown menu with the player's display contextmenu

        // Check which mouse button is clicked on the Play contextmenu
        private void playMenu_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                _playMenuRightButton = true;
                _playMenuPopUpLocation.X = e.Location.X - 1;
                _playMenuPopUpLocation.Y = e.Location.Y - 1;
            }
        }

        // An item has been selected on the Play contextmenu
        private void playMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            _playMenuItemIndex = playMenu.Items.IndexOf(e.ClickedItem);
            if (_playMenuItemIndex < 2 || _playMenuItemIndex == START_PLAYITEMS - 1) return; // ignore playlist and separator lines

            // Submenu Playlist has it's own menuhandler
            if (_playMenuItemIndex == 2) // This is menu item 'Add MediaFiles'
            {
                playMenu.Close();
                if (displayMenu.Visible) displayMenu.Close();
                SelectMediaFiles();
            }
            else if (_playMenuItemIndex == 3) // This is menu item 'Add URLs'
            {
                playMenu.Close();
                if (displayMenu.Visible) displayMenu.Close();
                ShowAddUrlDialog();
            }
            else
            {
                // If right mousebutton pressed
                if (_playMenuRightButton)
                {
                    _playMenuRightButton = false;
                    playMenu.AutoClose = false;
                    if (displayMenu.Visible) displayMenu.AutoClose = false;
                    playMenu.Items[_playMenuItemIndex].BackColor = Color.Maroon; // TODO - use global color def.

                    if (PlayList[_playMenuItemIndex - START_PLAYITEMS].StartsWith("http:", StringComparison.OrdinalIgnoreCase)) openLocationMenuItem.Enabled = propertiesMenuItem.Enabled = false;
                    else openLocationMenuItem.Enabled = propertiesMenuItem.Enabled = true;

                    // Selected item gets passed on with (global) playMenuItemIndex:
                    playSubMenu.Show(playMenu.PointToScreen(_playMenuPopUpLocation));
                }
                else
                {
                    playMenu.Close();
                    if (displayMenu.Visible) displayMenu.Close();
                    // Play the selected mediafile
                    _mediaToPlay = _playMenuItemIndex - START_PLAYITEMS;
                    if (RepeatShuffle) SetShuffleList();
                    PlayNextMedia();
                }
            }
        }

        // The Play contextmenu submenu handler
        private void playSubMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            playSubMenu.Close();
            switch (playSubMenu.Items.IndexOf(e.ClickedItem))
            {
                case 0: // Play the mediafile
                    playMenu.Close();
                    if (displayMenu.Visible) displayMenu.Close();
                    _mediaToPlay = _playMenuItemIndex - START_PLAYITEMS;
                    if (RepeatShuffle) SetShuffleList();
                    PlayNextMedia();
                    break;

                case 2: // Open file location
                    playMenu.Close();
                    if (displayMenu.Visible) displayMenu.Close();

                    if (!PlayList[_playMenuItemIndex - START_PLAYITEMS].StartsWith("http:", StringComparison.OrdinalIgnoreCase))
                    {
                        try
                        {
                            Process.Start("explorer.exe", "/select," + PlayList[_playMenuItemIndex - START_PLAYITEMS]);
                        }
                        catch { }
                    }
                    break;

                case 3: // Properties
                    playMenu.Close();
                    bool menuOn = displayMenu.Visible;
                    if (menuOn) displayMenu.Close();

                    if (!PlayList[_playMenuItemIndex - START_PLAYITEMS].StartsWith("http:", StringComparison.OrdinalIgnoreCase))
                    {
                        if (File.Exists(PlayList[_playMenuItemIndex - START_PLAYITEMS]))
                        {
                            Cursor.Position = menuOn ? displayMenu.PointToScreen(Point.Empty) : playPanel.PointToScreen(Point.Empty);
                            try
                            {
                                SafeNativeMethods.SHELLEXECUTEINFO info = new SafeNativeMethods.SHELLEXECUTEINFO();
                                info.cbSize = Marshal.SizeOf(info);
                                info.lpVerb = "properties";
                                info.lpParameters = "details";
                                info.lpFile = PlayList[_playMenuItemIndex - START_PLAYITEMS];
                                info.nShow = SafeNativeMethods.SW_SHOW;
                                info.fMask = SafeNativeMethods.SEE_MASK_INVOKEIDLIST;
                                SafeNativeMethods.ShellExecuteEx(ref info);
                            }
                            catch { }
                        }
                        else // file not found
                        {
                            // This should not happen but shows how to
                            // get localized error text (Win32Exception(errorCode).Message)

                            StringBuilder infoText = new StringBuilder(450);
                            infoText.AppendLine("Properties\r\n")
                            .AppendLine(PlayList[_playMenuItemIndex - START_PLAYITEMS] + "\r\n")
                            .Append(new Win32Exception(2).Message) // 2 = Win32 file not found
                            .Append(".");

                            ErrorDialog errorDialog = new ErrorDialog(APPLICATION_NAME, infoText.ToString(), false);

                            errorDialog.checkBox1.Hide();
                            errorDialog.checkBox2.Hide();

                            CenterDialog(this, errorDialog);
                            errorDialog.ShowDialog();

                            errorDialog.Dispose();
                        }
                    }
                    break;

                case 5: // Remove from List
                    if (((ToolStripMenuItem)playMenu.Items[_playMenuItemIndex]).Checked)
                    {
                        Player1.Stop();
                        Application.DoEvents();
                    }
                    PlayList.RemoveAt(_playMenuItemIndex - START_PLAYITEMS);
                    if (RepeatShuffle) CreateShuffleList();
                    if (Player1.Playing)
                    {
                        if (_mediaToPlay > (_playMenuItemIndex - START_PLAYITEMS)) --_mediaToPlay;
                        if (RepeatShuffle) SetShuffleList();
                    }
                    ReBuildPlayListMenu();
                    SavePlayList();
                    break;

                case 7: // Sort List
                    PlayList.Sort(CompareFileNames);
                    if (Player1.Playing) _mediaToPlay = GetPlayListIndex() + 1; // Adjust menu checkmark and playing item
                    ReBuildPlayListMenu();
                    SavePlayList();
                    break;
            }
        }

        private int GetPlayListIndex()
        {
            if (Player1.Playing)
            {
                string target = Player1.GetMediaName(MediaName.FullPath);
                for (int i = PlayList.Count - 1; i >= 0; --i)
                {
                    if (PlayList[i] == target) return i;
                }
            }
            return -1;
        }

        // Sort PlayList - Compare filenames (not the full path)
        private int CompareFileNames(string x, string y)
        {
            return String.Compare(Path.GetFileName(x), Path.GetFileName(y), StringComparison.OrdinalIgnoreCase);
        }

        // Called when the pop-up submenu of the Play contextmenu is closed
        private void playSubMenu_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            if (displayMenu.Visible)
            {
                displayMenu.AutoClose = true;
                displayMenu.Show(); // this seems to have to be done to restore autoclose
            }
            playMenu.AutoClose = true;
            playMenu.Show(); // this seems to have to be done to restore autoclose

            playMenu.Items[_playMenuItemIndex].BackColor = playMenu.Items[0].BackColor;
        }

        // Close the submenu when the mouse leaves the menu
        private void playSubMenu_MouseLeave(object sender, EventArgs e)
        {
            //if (!menuCloseOnLeave) return; // maybe better not with this one
            if (playSubMenu.Visible) playSubMenu.Close();
        }

        #endregion

        #region PlayList Menu

        private void newPlayListMenuItem_Click(object sender, EventArgs e)
        {
            NewPlayList();
        }

        private void openPlayListMenuItem_Click(object sender, EventArgs e)
        {
            OpenPlayList();
        }

        private void addPlayListMenuItem_Click(object sender, EventArgs e)
        {
            AddPlayList();
        }

        private void savePlayListMenuItem_Click(object sender, EventArgs e)
        {
            SavePlayListByUser();
        }

        #endregion

        #region PlayMenu Drag and Drop

        // The ContextMenuStrip (playMenu) does not raise a mousedown event (?)

        private void PlayMenu_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _ddMouseLocation = e.Location;
                _ddDragMenuItem = (ToolStripMenuItem)sender;
                _ddDragMenuItem.MouseMove += PlayMenu_MouseMove;
                _ddDragMenuItem.MouseUp += PlayMenu_MouseUp;
                _ddSourceIndex = playMenu.Items.IndexOf((ToolStripMenuItem)sender);
                _ddMouseDown = true;
            }
        }

        private void PlayMenu_MouseMove(object sender, MouseEventArgs e)
        {
            if (_ddMouseDown && (Math.Abs(_ddMouseLocation.X - e.Location.X) > 2 || Math.Abs(_ddMouseLocation.Y - e.Location.Y) > 2))
            {
                _ddMouseDown = false; // we don't get a mouse up event after dodragdrop

                _ddDragMenuItem.MouseMove -= PlayMenu_MouseMove;
                _ddDragMenuItem.MouseUp -= PlayMenu_MouseUp;

                _ddOurDrag = true;
                playMenu.DoDragDrop(PlayList[_ddSourceIndex - START_PLAYITEMS], DragDropEffects.Move);
                _ddOurDrag = false;
            }
        }

        private void PlayMenu_MouseUp(object sender, MouseEventArgs e)
        {
            _ddDragMenuItem.MouseMove -= PlayMenu_MouseMove;
            _ddDragMenuItem.MouseUp -= PlayMenu_MouseUp;
            _ddMouseDown = false;
        }

        // DragEnter not needed - responding only to 'our drag'
        private void playMenu_DragOver(object sender, DragEventArgs e)
        {
            if (_ddOurDrag)
            {
                Point location = playMenu.PointToClient(new Point(e.X, e.Y));
                e.Effect = playMenu.Items.IndexOf(playMenu.GetItemAt(location)) >= START_PLAYITEMS ? DragDropEffects.Move : DragDropEffects.None;
            }
            else e.Effect = DragDropEffects.None;
        }

        private void playMenu_DragDrop(object sender, DragEventArgs e)
        {
            if (_ddOurDrag)
            {
                Point location = playMenu.PointToClient(new Point(e.X, e.Y));
                int ddDestIndex = playMenu.Items.IndexOf(playMenu.GetItemAt(location));
                if (ddDestIndex != _ddSourceIndex && ddDestIndex >= START_PLAYITEMS)
                {
                    ToolStripMenuItem menuItem = (ToolStripMenuItem)playMenu.Items[_ddSourceIndex];
                    playMenu.Items.RemoveAt(_ddSourceIndex);
                    playMenu.Items.Insert(ddDestIndex, menuItem);

                    string listItem = PlayList[_ddSourceIndex - START_PLAYITEMS];
                    PlayList.RemoveAt(_ddSourceIndex - START_PLAYITEMS);
                    PlayList.Insert(ddDestIndex - START_PLAYITEMS, listItem);

                    // Adjust next to play if dragging playing medianame
                    if (menuItem.Checked) _mediaToPlay = ddDestIndex - START_PLAYITEMS + 1;

                    SavePlayList();
                }
            }
        }

        #endregion

        #region Pause Button / Previous Button / Next Button / Stop Button

        // Pause and Resume
        private void pauseButton_Click(object sender, EventArgs e)
        {
            Player1.Paused = !Player1.Paused;
            // The interface changes are handled with the player's MediaPause/Resume eventhandler
        }

        // Previous (Backward)
        private void previousButton_Click(object sender, EventArgs e)
        {
            Player1.PlayPrevious();
        }

        // Next (Forward)
        private void nextButton_Click(object sender, EventArgs e)
        {
            if (!Player1.Playing && PlayList.Count > 0)
            {
                _mediaToPlay = 0;
                if (RepeatShuffle) SetShuffleList();
                PlayNextMedia();
            }
            else Player1.PlayNext();
        }

        // Stop
        private void stopButton_Click(object sender, EventArgs e)
        {
            Player1.Stop();
            // The interface changes are handled with the player's MediaStop eventhandler
        }

        #endregion

        // ******************************** Display Label Click / DisplayMode Button / FullScreenMode Button

        #region Display Label Click (Show Control Panel)

        // Display Label Click - Opens System Display Control Panel
        private void displayModeLabel_Click(object sender, EventArgs e)
        {
            Player1.ShowDisplaySettingsPanel(this);
        }

        #endregion

        #region DisplayMode Button

        private void displayModeMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // Translate the text of the clicked item into a displaymode enum value
            try { SetDisplayModeMenu((DisplayMode)Enum.Parse(typeof(DisplayMode), e.ClickedItem.Text), true); }
            catch { }
        }

        private void SetDisplayModeMenu(DisplayMode displayMode, bool setMode)
        {
            string displayModeName = displayMode.ToString();
            if (displayModeButton.Text != displayModeName)
            {
                if (setMode) Player1.DisplayMode = displayMode;

                displayModeLight.LightOn = displayMode == DisplayMode.Manual;

                displayModeButton.Text = displayModeName;
                foreach (ToolStripMenuItem menuItem in displayModeMenu.Items)
                {
                    menuItem.Checked = menuItem.Text == displayModeName;
                }
            }
        }

        #endregion

        #region FullScreenMode Button

        private void fullScreenModeMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string fullScreenModeName = e.ClickedItem.Text;
            if (fullScreenModeName == "") return; // ignore separator lines

            fullScreenLight.LightOn = true;
            switch (fullScreenModeMenu.Items.IndexOf(e.ClickedItem))
            {
                case 0: // FullscreenMode Form
                    Player1.FullScreenMode = FullScreenMode.Form;
                    Player1.FullScreen = true;
                    break;
                case 1: // FullscreenMode Parent
                    Player1.FullScreenMode = FullScreenMode.Parent;
                    Player1.FullScreen = true;
                    break;
                case 2: // FullscreenMode Display
                    Player1.FullScreenMode = FullScreenMode.Display;
                    Player1.FullScreen = true;
                    break;
                case 4: // FullscreenMode On/Off
                    Player1.FullScreen = !Player1.FullScreen;
                    break;
            }
            SetFullScreenModeMenu();
        }

        private void SetFullScreenModeMenu()
        {
            UnCheckMenuItems(fullScreenModeMenu, 0, 0);

            if (Player1.FullScreen)
            {
                switch (Player1.FullScreenMode)
                {
                    case FullScreenMode.Form:
                        ((ToolStripMenuItem)fullScreenModeMenu.Items[0]).Checked = true;
                        fullScreenModeButton.Text = fullScreenModeMenu.Items[0].Text;
                        break;
                    case FullScreenMode.Parent:
                        ((ToolStripMenuItem)fullScreenModeMenu.Items[1]).Checked = true;
                        fullScreenModeButton.Text = fullScreenModeMenu.Items[1].Text;
                        break;
                    case FullScreenMode.Display:
                        ((ToolStripMenuItem)fullScreenModeMenu.Items[2]).Checked = true;
                        fullScreenModeButton.Text = fullScreenModeMenu.Items[2].Text;
                        break;
                }
                fullScreenLight.LightOn = true;
            }
            else
            {
                ((ToolStripMenuItem)fullScreenModeMenu.Items[4]).Checked = true;
                fullScreenModeButton.Text = fullScreenModeMenu.Items[4].Text;
                fullScreenLight.LightOn = false;
            }
        }

        #endregion

        // ******************************** Display Overlay Button / Display Overlay Menu Button

        #region Display Overlay Button

        // Overlay Mode Video
        private void videoMenuItem_Click(object sender, EventArgs e)
        {
            Player1.OverlayMode = OverlayMode.Video;
            videoMenuItem.Checked = true;
            displayMenuItem.Checked = false;
        }

        // Overlay Mode Display
        private void displayMenuItem_Click(object sender, EventArgs e)
        {
            Player1.OverlayMode = OverlayMode.Display;
            videoMenuItem.Checked = false;
            displayMenuItem.Checked = true;
        }

        // Overlay Hold
        private void overlayHoldMenuItem_Click(object sender, EventArgs e)
        {
            Player1.OverlayHold = !Player1.OverlayHold;
            overlayHoldMenuItem.Checked = Player1.OverlayHold;

            _overlayHold = false; // reset overlay hold by application
        }

        // Message Overlay
        private void messageMenuItem_Click(object sender, EventArgs e)
        {
            SetOverlay(sender, _messageOverlay, true, true);
        }

        // Scribble Overlay
        private void scribbleMenuItem_Click(object sender, EventArgs e)
        {
            SetOverlay(sender, _scribbleOverlay, true, true);
        }

        // Tiles Overlay
        private void tilesMenuItem_Click(object sender, EventArgs e)
        {
            SetOverlay(sender, _tileOverlay, true, true);
        }

        // Bouncing Overlay
        private void bouncingMenuItem_Click(object sender, EventArgs e)
        {
            SetOverlay(sender, _bouncingOverlay, true, true);
        }

        // PiP Overlay
        private void PiPMenuItem_Click(object sender, EventArgs e)
        {
            SetOverlay(sender, _pipOverlay, true, true);
        }

        // SubTitles Overlay
        private void subtitlesMenuItem_Click(object sender, EventArgs e)
        {
            SetOverlay(sender, _subtitlesOverlay, true, true);
        }

        // Zoom Select Overlay
        private void zoomSelectMenuItem_Click(object sender, EventArgs e)
        {
            SetOverlay(sender, _zoomSelectOverlay, true, true);
        }

        // Video Wall Overlay
        private void videoWallMenuItem_Click(object sender, EventArgs e)
        {
            SetOverlay(sender, _allScreensOverlay, true, true);
        }

        // MP3 Cover Overlay
        private void MP3CoverMenuItem_Click(object sender, EventArgs e)
        {
            SetOverlay(sender, _mp3CoverOverlay, false, true);
        }

        // MP3 Karaoke Overlay
        private void MP3KaraokeMenuItem_Click(object sender, EventArgs e)
        {
            SetOverlay(sender, _mp3KaraokeOverlay, false, true);
        }

        // Big Time Overlay
        private void bigTimeMenuItem_Click(object sender, EventArgs e)
        {
            SetOverlay(sender, _bigTimeOverlay, false, true);
        }

        // Status Info Overlay
        private void statusInfoMenuItem_Click(object sender, EventArgs e)
        {
            SetOverlay(sender, _statusInfoOverlay, false, true);
        }

        // Overlay Off
        private void overlayOffMenuItem_Click(object sender, EventArgs e)
        {
            SetOverlay(sender, null, false, false);
        }

        // General set overlay method called by overlaymenu eventhandlers
        private void SetOverlay(object sender, Form theOverlay, bool canFocus, bool hold)
        {
            if (Player1.Overlay == theOverlay) return;

            // every overlay (in this application) has an IOverlay interface: HasMenu and a MenuEnabled property
            if (theOverlay != null)
            {
                if (((IOverlay)theOverlay).HasMenu)
                {
                    ((IOverlay)theOverlay).MenuEnabled = _overlayMenuEnabled;
                    Player1.OverlayCanFocus = _overlayMenuEnabled;
                }
                else Player1.OverlayCanFocus = canFocus;
            }

            // set / reset overlay hold by application
            if (hold)
            {
                if (!Player1.OverlayHold)
                {
                    if (Player1.Playing) overlayHoldMenuItem.Checked = Player1.OverlayHold = true;
                    _overlayHold = true;
                }
            }
            else if (_overlayHold)
            {
                overlayHoldMenuItem.Checked = Player1.OverlayHold = _overlayHold = false;
            }

            Player1.Overlay = theOverlay;

            UnCheckMenuItems(displayOverlayMenu, 3, 0);
            if (theOverlay == null)
            {
                overlayOffMenuItem.Checked = true;
                displayOverlayButton.Text = overlayOffMenuItem.Text;
                overlayLight.LightOn = false;
                _userOverlay = false;
            }
            else
            {
                ((ToolStripMenuItem)sender).Checked = true;
                displayOverlayButton.Text = ((ToolStripMenuItem)sender).Text.Substring(8); // Strip 'Example' from the name
                overlayLight.LightOn = true;
                _userOverlay = true;

                if (_voicePlayer.Visible) _voicePlayer.BringToFront();
                if (_voiceRecorder.Visible) _voiceRecorder.BringToFront();
            }
        }

        #endregion

        #region Display Overlay Menu Button

        private void overlayMenuButton_Click(object sender, EventArgs e)
        {
            _overlayMenuEnabled = !_overlayMenuEnabled;
            // every overlay (in this application) has an IOverlay interface: HasMenu and a MenuEnabled property
            if (Player1.Overlay != null)
            {
                if (((IOverlay)Player1.Overlay).HasMenu)
                {
                    ((IOverlay)Player1.Overlay).MenuEnabled = _overlayMenuEnabled;
                    Player1.OverlayCanFocus = _overlayMenuEnabled;
                }
            }
            overlayMenuLight.LightOn = _overlayMenuEnabled;
            overlayMenuMenuItem.Text = _overlayMenuEnabled ? "Hide Overlay Menu" : "Show Overlay Menu";
            //overlayMenuButton.Text = _overlayMenuEnabled ? "  Overlay Menu On" : "  Overlay Menu Off";
        }

        private void overlayMenuMenuItem_Click(object sender, EventArgs e)
        {
            overlayMenuButton_Click(overlayMenuButton, EventArgs.Empty);
            //overlayMenuButton.PerformClick();
        }

        #endregion

        // ******************************** Repeat / Start- and EndPosition

        #region Repeat

        // Repeat MenuHandler Repeat One
        private void repeatOneMenuItem_Click(object sender, EventArgs e)
        {
            UnCheckMenuItems(repeatMenu, 0, 0);
            repeatButton.Text = repeatOneMenuItem.Text;
            repeatOneMenuItem.Checked = true;
            repeatLight.LightOn = true;

            RepeatAll = RepeatShuffle = false;
            Player1.Repeat = RepeatOne = true;

            _shuffleList = null;
        }

        // Repeat MenuHandler Repeat All
        private void repeatAllMenuItem_Click(object sender, EventArgs e)
        {
            UnCheckMenuItems(repeatMenu, 0, 0);
            repeatButton.Text = repeatAllMenuItem.Text;
            repeatAllMenuItem.Checked = true;
            repeatLight.LightOn = true;

            if (Player1.Repeat) Player1.Repeat = false;
            RepeatOne = RepeatShuffle = false;
            RepeatAll = true;

            _shuffleList = null;
        }

        // Repeat MenuHandler Repeat Shuffle
        private void shuffleMenuItem_Click(object sender, EventArgs e)
        {
            UnCheckMenuItems(repeatMenu, 0, 0);
            repeatButton.Text = shuffleMenuItem.Text;
            shuffleMenuItem.Checked = true;
            repeatLight.LightOn = true;

            if (Player1.Repeat) Player1.Repeat = false;
            RepeatOne = RepeatAll = false;
            RepeatShuffle = true;

            CreateShuffleList();
        }

        // Create shuffle list
        private void CreateShuffleList()
        {
            if (PlayList.Count < 2)
            {
                repeatAllMenuItem_Click(repeatAllMenuItem, EventArgs.Empty);
                return;
            }

            int n = PlayList.Count;

            _shuffleList = new int[n];
            for (int i = 0; i < n; i++) _shuffleList[i] = i;

            while (n > 0)
            {
                n--;
                int k = _random.Next(n + 1);
                int value = _shuffleList[k];
                _shuffleList[k] = _shuffleList[n];
                _shuffleList[n] = value;
            }
            _shuffleToPlay = 0;
        }

        private void SetShuffleList()
        {
            if (_shuffleList != null)
            {
                int found = 0;
                for (int i = 0; i < _shuffleList.Length; i++)
                {
                    if (_shuffleList[i] == _mediaToPlay)
                    {
                        found = i;
                        break;
                    }
                }

                if (found > 0)
                {
                    _shuffleList[found] = _shuffleList[0];
                    _shuffleList[0] = _mediaToPlay;
                }
                _shuffleToPlay = 0;
            }
        }

        // Repeat MenuHandler Repeat Off
        private void repeatOffMenuItem_Click(object sender, EventArgs e)
        {
            UnCheckMenuItems(repeatMenu, 0, 0);
            repeatButton.Text = repeatOffMenuItem.Text;
            repeatOffMenuItem.Checked = true;
            repeatLight.LightOn = false;

            if (Player1.Repeat) Player1.Repeat = false;
            RepeatOne = RepeatAll = RepeatShuffle = false;

            _shuffleList = null;
        }

        #endregion

        #region Start- and EndPosition

        // Input StartPosition OK (for next media to play)
        private void startPositionTextBox_Validated(object sender, EventArgs e)
        {
            // the player allows any value - we could do a check here for startposition < endposition:
            // if (player1.Endposition == 0 || player1.StartPosition < player1.EndPosition) = OK
            TimeSpan startTimeSpan;
            if (TimeSpan.TryParse(startPositionTextBox.Text, out startTimeSpan)) Player1.StartPosition = startTimeSpan;
        }

        // Input EndPosition OK (for next media to play)
        private void endPositionTextBox_Validated(object sender, EventArgs e)
        {
            TimeSpan endTimeSpan;
            if (TimeSpan.TryParse(endPositionTextBox.Text, out endTimeSpan)) Player1.EndPosition = endTimeSpan;
        }

        // Input StartPositionMedia OK (for playing media)
        private void startPositionMediaTextBox_Validated(object sender, EventArgs e)
        {
            TimeSpan startMediaTimeSpan;
            if (TimeSpan.TryParse(startPositionMediaTextBox.Text, out startMediaTimeSpan)) Player1.StartPositionMedia = startMediaTimeSpan;
        }

        // Input EndPositionMedia OK (for playing media)
        private void endPositionMediaTextBox_Validated(object sender, EventArgs e)
        {
            TimeSpan endMediaTimeSpan;
            if (TimeSpan.TryParse(endPositionMediaTextBox.Text, out endMediaTimeSpan)) Player1.EndPositionMedia = endMediaTimeSpan;
        }

        #endregion

        // ******************************** Speed TextBox

        #region Speed TextBox

        private void speedTextBox_Validated(object sender, EventArgs e)
        {
            float speed;
            if (float.TryParse(speedTextBox.Text, out speed))
            {
                if (speed < 0.01) speed = 0.01F;
                else if(speed > 4) speed = 4F;
                Player1.Speed = (int)(speed * 1000);
            }
        }

        #endregion

        // ******************************** Audio and Balance Label Click (Show Control Panels)

        #region Audio and Balance Label Click

        // Audio Label Click - Opens System Audio Control Panel
        private void volumeLabelPanel_Click(object sender, EventArgs e)
        {
            Player1.ShowAudioOutputPanel(this);
        }

        // Balance Label Click - Opens System SndVol
        private void balanceLabelPanel_Click(object sender, EventArgs e)
        {
            Player1.ShowAudioMixerPanel(this);
        }

        #endregion

        // ******************************** Zoom, Move and Stretch Buttons and Menu

        #region Zoom, Move and Stretch Buttons and Menu

        // MenuItems

        // Zoom MenuItems
        private void zoomInMenuItem_Click(object sender, EventArgs e)
        {
            Player1.VideoZoom(1.1);
            zoomInButton.Focus(); // so the mousewheel can be used
        }

        private void zoomOutMenuItem_Click(object sender, EventArgs e)
        {
            Player1.VideoZoom(0.9);
            zoomInButton.Focus();
        }

        // Move MenuItems
        private void moveUpMenuItem_Click(object sender, EventArgs e)
        {
            Player1.VideoMove(0, -displayPanel.Height / 10);
            moveUpButton.Focus();
        }

        private void moveDownMenuItem_Click(object sender, EventArgs e)
        {
            Player1.VideoMove(0, displayPanel.Height / 10);
            moveDownButton.Focus();
        }

        private void moveLeftMenuItem_Click(object sender, EventArgs e)
        {
            Player1.VideoMove(-displayPanel.Width / 10, 0);
            moveLeftButton.Focus();
        }

        private void moveRightMenuItem_Click(object sender, EventArgs e)
        {
            Player1.VideoMove(displayPanel.Width / 10, 0);
            moveRightButton.Focus();
        }

        // Stretch MenuItems
        private void stretchHeightMenuItem_Click(object sender, EventArgs e)
        {
            DoStretch(0, 16);
            stretchUpButton.Focus();
        }

        private void shrinkHeightMenuItem_Click(object sender, EventArgs e)
        {
            DoStretch(0, -16);
            stretchDownButton.Focus();
        }

        private void stretchWidthMenuItem_Click(object sender, EventArgs e)
        {
            DoStretch(16, 0);
            stretchLeftButton.Focus();
        }

        private void shrinkWidthMenuItem_Click(object sender, EventArgs e)
        {
            DoStretch(-16, 0);
            stretchRightButton.Focus();
        }

        // MouseWheel (Buttons)
        // Micorosofts MouseEventArgs e.Delta is not always 120 anymore...

        // Zoom MouseWheel
        void zoomInButton_MouseWheel(object sender, MouseEventArgs e)
        {
            Player1.VideoZoom(e.Delta > 0 ? 1.1 : 0.9);
        }

        // Move MouseWheel
        void moveUpButton_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta < 0) Player1.VideoMove(0, 4);
            else Player1.VideoMove(0, -4);
        }

        void moveLeftButton_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta < 0) Player1.VideoMove(4, 0);
            else Player1.VideoMove(-4, 0);
        }

        // Stretch MouseWheel
        void stretchUpButton_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta < 0) DoStretch(0, -4);
            else DoStretch(0, 4);
        }

        void stretchLeftButton_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta < 0) DoStretch(-4, 0);
            else DoStretch(4, 0);
        }

        // Zoom Buttons
        private void zoomInButton_MouseDown(object sender, MouseEventArgs e)
        {
            Player1.VideoZoom(1.1);
        }

        private void zoomOutButton_MouseDown(object sender, MouseEventArgs e)
        {
            Player1.VideoZoom(0.9);
        }

        // Move Buttons
        private void moveUpButton_MouseDown(object sender, MouseEventArgs e)
        {
            DoMove(0, -1);
        }

        private void moveDownButton_MouseDown(object sender, MouseEventArgs e)
        {
            DoMove(0, 1);
        }

        private void moveLeftButton_MouseDown(object sender, MouseEventArgs e)
        {
            DoMove(-1, 0);
        }

        private void moveRightButton_MouseDown(object sender, MouseEventArgs e)
        {
            DoMove(1, 0);
        }

        private void DoMove(int x, int y)
        {
            do
            {
                Player1.VideoMove(x, y);
                Application.DoEvents();
                Thread.Sleep(2);
            }
            while ((MouseButtons & MouseButtons.Left) != 0);
        }

        // Stretch Buttons
        private void stretchUpButton_MouseDown(object sender, MouseEventArgs e)
        {
            DoStretch(0, 2);
        }

        private void stretchDownButton_MouseDown(object sender, MouseEventArgs e)
        {
            DoStretch(0, -2);
        }

        private void stretchLeftButton_MouseDown(object sender, MouseEventArgs e)
        {
            DoStretch(2, 0);
        }

        private void stretchRightButton_MouseDown(object sender, MouseEventArgs e)
        {
            DoStretch(-2, 0);
        }

        private void DoStretch(int x, int y)
        {
            do
            {
                Player1.VideoStretch(x, y);
                Application.DoEvents();
                Thread.Sleep(2);
            }
            while ((MouseButtons & MouseButtons.Left) != 0);
        }

        #endregion

        // ******************************** ScreenCopy Picturebox

        #region ScreenCopy Picturebox

        private void SetCopyMenu()
        {
            if (pictureBox1.Image == null)
            {
                openCopyMenuItem.Enabled = false;
                openWithCopyMenuItem.Enabled = false;
                clearCopyMenuItem.Enabled = false;
            }
            else
            {
                openCopyMenuItem.Enabled = true;
                openWithCopyMenuItem.Enabled = true;
                clearCopyMenuItem.Enabled = true;
            }
        }

        // Picturebox clicked - Copy
        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) DoScreenCopy();
        }

        private void DoScreenCopy()
        {
            if (pictureBox1.Image != null) pictureBox1.Image.Dispose();
            pictureBox1.Image = Player1.ScreenCopy;

            SetCopyMenu();
        }

        // The screencopy contextmenu items click events:

        // Copy
        private void copyMenuItem_Click(object sender, EventArgs e)
        {
            DoScreenCopy();
        }

        // ScreenCopyMode
        private void copyModeMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // Translate the text of the clicked item into a displaymode enum value
            try
            {
                SetScreenCopyModeMenu((ScreenCopyMode)Enum.Parse(typeof(ScreenCopyMode), e.ClickedItem.Text), true);
            }
            catch { }
        }

        // Set ScreenCopyMode
        private void SetScreenCopyModeMenu(ScreenCopyMode copyMode, bool setMode)
        {
            string screenCopyModeName = copyMode.ToString();

            if (setMode) Player1.ScreenCopyMode = copyMode;
            copyModeLabel.Text = screenCopyModeName;
            foreach (ToolStripMenuItem menuItem in copyModeMenu.Items)
            {
                menuItem.Checked = menuItem.Text == screenCopyModeName;
            }
        }

        // Open
        private void openCopyMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                try
                {
                    pictureBox1.Image.Save(_screenCopyFile, _screenCopyFormat);
                    Process.Start(_screenCopyFile);
                }
                catch { }
            }
        }

        // Open With
        private void openWithMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Image.Save(_screenCopyFile, _screenCopyFormat);
                Process.Start("rundll32.exe", "shell32.dll,OpenAs_RunDLL " + _screenCopyFile);
            }
            catch { }
        }

        // Clear
        private void clearCopyMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
                pictureBox1.Image = null;
                try { if (File.Exists(_screenCopyFile)) File.Delete(_screenCopyFile); }
                catch { }

                SetCopyMenu();
            }
        }

        #endregion

        // ******************************** Sliders ContextMenus: Reset (Speed and Audio), Display and PositionSlider

        #region Reset Sliders ContextMenus

        // Context menu used with the Speed, AudioVolume an AudioBalance Sliders (trackbars)

        private void sliderMenu_Opening(object sender, CancelEventArgs e)
        {
            if (sliderMenu.SourceControl == speedSlider || sliderMenu.SourceControl == speedLabelText)
            {
                sliderMenuItem1.Text = "Minimum Speed";
                sliderMenuItem2.Text = "Normal Speed";
                sliderMenuItem3.Text = "Maximum Speed";
            }
            else if (sliderMenu.SourceControl == volumeSlider || sliderMenu.SourceControl == audioVolumeLabel)
            {
                sliderMenuItem1.Text = "Mute";
                sliderMenuItem2.Text = "Average Volume";
                sliderMenuItem3.Text = "Maximum Volume";
            }
            else if (sliderMenu.SourceControl == balanceSlider || sliderMenu.SourceControl == audioBalanceLabel)
            {
                sliderMenuItem1.Text = "Left Balance";
                sliderMenuItem2.Text = "Center Balance";
                sliderMenuItem3.Text = "Right Balance";
            }
        }

        // Minimum
        private void sliderMenuItem1_Click(object sender, EventArgs e)
        {
            if (sliderMenu.SourceControl == speedSlider || sliderMenu.SourceControl == speedLabelText) Player1.Speed = 100;
            else if (sliderMenu.SourceControl == volumeSlider || sliderMenu.SourceControl == audioVolumeLabel) Player1.AudioVolume = 0;
            else if (sliderMenu.SourceControl == balanceSlider || sliderMenu.SourceControl == audioBalanceLabel) Player1.AudioBalance = 0;
        }

        // Center
        private void sliderMenuItem2_Click(object sender, EventArgs e)
        {
            if (sliderMenu.SourceControl == speedSlider || sliderMenu.SourceControl == speedLabelText) Player1.Speed = 1000;
            else if (sliderMenu.SourceControl == volumeSlider || sliderMenu.SourceControl == audioVolumeLabel) Player1.AudioVolume = 500;
            else if (sliderMenu.SourceControl == balanceSlider || sliderMenu.SourceControl == audioBalanceLabel) Player1.AudioBalance = 500;
        }

        // Maximum
        private void sliderMenuItem3_Click(object sender, EventArgs e)
        {
            if (sliderMenu.SourceControl == speedSlider || sliderMenu.SourceControl == speedLabelText) Player1.Speed = 4000;
            else if (sliderMenu.SourceControl == volumeSlider || sliderMenu.SourceControl == audioVolumeLabel) Player1.AudioVolume = 1000;
            else if (sliderMenu.SourceControl == balanceSlider || sliderMenu.SourceControl == audioBalanceLabel) Player1.AudioBalance = 1000;
        }

        #endregion

        #region PositionSlider Contextmenu

        // Handle the contextmenu items with the eventhandlers generated by the designer:

        // Always Visible
        private void sliderAlwayVisibleMenuItem_Click(object sender, EventArgs e)
        {
            _sliderHide = !_sliderHide;
            if (_sliderHide)
            {
                sliderAlwaysVisibleMenuItem.Checked = false;
                SliderPanelHide();

                positionSlider.MouseLeave += positionSliderPanel_MouseLeave;
                positionSliderPanel.MouseLeave += positionSliderPanel_MouseLeave;
                positionSliderPanel.MouseEnter += positionSliderPanel_MouseEnter;
            }
            else
            {
                positionSlider.MouseLeave -= positionSliderPanel_MouseLeave;
                positionSliderPanel.MouseLeave -= positionSliderPanel_MouseLeave;
                positionSliderPanel.MouseEnter -= positionSliderPanel_MouseEnter;

                sliderAlwaysVisibleMenuItem.Checked = true;
                SliderPanelShow();
            }
        }

        // Slider Track / Progress
        private void sliderShowsProgressMenuItem_Click(object sender, EventArgs e)
        {
            if (Player1.PositionSliderMode == PositionSliderMode.Track)
            {
                Player1.PositionSliderMode = PositionSliderMode.Progress;
                sliderShowsProgressMenuItem.Checked = true;
            }
            else
            {
                Player1.PositionSliderMode = PositionSliderMode.Track;
                sliderShowsProgressMenuItem.Checked = false;
            }
        }

        // Seek Live Update
        private void sliderSeekLiveUpdateMenuItem_Click(object sender, EventArgs e)
        {
            Player1.PositionSliderLiveUpdate = !Player1.PositionSliderLiveUpdate;
            sliderSeekLiveUpdateMenuItem.Checked = Player1.PositionSliderLiveUpdate;
        }

        // Mark Repeat StartPosition
        private void markStartPositionMenuItem_Click(object sender, EventArgs e)
        {
            // the player allows any value - we could do a check here for startposition < endposition
            // if (player1.Endposition == 0 || player1.StartPosition < player1.EndPosition) = OK
            Player1.StartPositionMedia = Player1.Position;
        }

        // Mark Repeat EndPosition
        private void markEndPositionMenuItem_Click(object sender, EventArgs e)
        {
            // see Mark Repeat Start above
            Player1.EndPositionMedia = Player1.Position;
        }

        // (Re)Start Repeat
        private void startRepeatMenuItem_Click(object sender, EventArgs e)
        {
            repeatOneMenuItem.PerformClick();
            Player1.Rewind();
        }

        // Mark #1
        private void mark1MenuItem_Click(object sender, EventArgs e)
        {
            _mark1 = Player1.Position;
            goToMark1MenuItem.Enabled = true;
        }

        // Goto Mark #1
        private void goToMark1MenuItem_Click(object sender, EventArgs e)
        {
            Player1.Position = _mark1;
        }

        // GoTo Start
        private void goToStartMenuItem_Click(object sender, EventArgs e)
        {
            Player1.Rewind();
        }

        #endregion

        #region Position Slider Visiblity

        // The position slider itself is handled by the player
        // Here the option is added to show and hide it when the mouse moves on/off it
        // The slider and the 2 position labels are inside a panel that triggers the mouse enter/leave events

        // Show position slider and labels
        private void positionSliderPanel_MouseEnter(object sender, EventArgs e)
        {
            SliderPanelShow();
        }

        // Hide position slider and labels
        private void positionSliderPanel_MouseLeave(object sender, EventArgs e)
        {
            if (_sliderHide && !positionSliderPanel.DisplayRectangle.Contains(positionSliderPanel.PointToClient(Cursor.Position)))
            {
                SliderPanelHide();
            }
        }

        // Show (the contents of) the position slider panel
        private void SliderPanelShow()
        {
            if (!_sliderVisible)
            {
                positionLabel1.Show();
                positionLabel2.Show();
                positionSlider.Show();
                _sliderVisible = true;
            }
        }

        // Hide (the contents of) the position slider panel
        private void SliderPanelHide()
        {
            if (_sliderVisible)
            {
                positionLabel1.Hide();
                positionLabel2.Hide();
                positionSlider.Hide();
                _sliderVisible = false;
            }
        }

        #endregion

        // ******************************** DisplayMenu Voice Recorder

        #region DisplayMenu Voice Recorder

        internal void showRecorderMenuItem_Click(object sender, EventArgs e)
        {
            _voiceRecorder.Visible = !_voiceRecorder.Visible;
            showRecorderMenuItem.Text = _voiceRecorder.Visible ? "Hide Recorder" : "Show Recorder";
        }

        internal void showPlayerMenuItem_Click(object sender, EventArgs e)
        {
            _voicePlayer.Visible = !_voicePlayer.Visible;
            showPlayerMenuItem.Text = _voicePlayer.Visible ? "Hide Player" : "Show Player";
        }

        private void showAllMenuItem_Click(object sender, EventArgs e)
        {
            if (!_voiceRecorder.Visible) showRecorderMenuItem.PerformClick();
            if (!_voicePlayer.Visible) showPlayerMenuItem.PerformClick();
        }

        private void hideAllMenuItem_Click(object sender, EventArgs e)
        {
            if (_voiceRecorder.Visible) showRecorderMenuItem.PerformClick();
            if (_voicePlayer.Visible) showPlayerMenuItem.PerformClick();
        }

        private void closeRecorderMenuItem_Click(object sender, EventArgs e)
        {
            _voiceRecorder.CloseRecorder();
            _voiceRecorder.Hide();
            showRecorderMenuItem.Text = "Show Recorder";

            _voicePlayer.ClosePlayer();
            _voicePlayer.Hide();
            showPlayerMenuItem.Text = "Show Player";
        }

        #endregion

        // ******************************** DisplayMenu Preferences

        #region DisplayMenu Preferences

        private void preferencesMenuItem_Click(object sender, EventArgs e)
        {
            PreferencesDialog prefsDialog = new PreferencesDialog(this) { Text = APPLICATION_NAME + " - Preferences" };
            SetDialogMiniPlayers(prefsDialog.panel2, prefsDialog.panel3, prefsDialog.panel4);
            CenterDialog(this, prefsDialog);
            prefsDialog.ShowDialog();
            DisposeDialogMiniPlayers();
            prefsDialog.Dispose();

            toolTip1.Active = Prefs.ShowTooltips;
        }

        #endregion

        // ******************************** DisplayMenu Quit

        #region DisplayMenu Quit

        private void quitMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            Application.Exit();
        }

        #endregion

        // ******************************** PlayList handling

        #region PlayList Handling

        // A simple playlist is used to store media filenames and URLs
        // It is saved as a textfile when changed and opened when the application starts

        // ******************************** PlayList New, Open, Add and Save As

        #region PlayList New, Open, Add and Save As

        // Ask and save current playlist with New, Open and Add PlayList
        private bool AskSaveCurrentPlayList(string text)
        {
            bool result = true;
            if (AskSavePlayList && PlayList.Count > 0)
            {
                PlayListDialog playListDialog = new PlayListDialog(text) {Text = APPLICATION_NAME};
                SetDialogMiniPlayers(playListDialog.panel3, null, null);

                CenterDialog(this, playListDialog);
                DialogResult r = playListDialog.ShowDialog();

                DisposeDialogMiniPlayers();
                playListDialog.Dispose();

                if (r == DialogResult.Yes) result = SavePlayListByUser();
                else if (r == DialogResult.Cancel) result = false;
            }
            return result;
        }

        // Clear playlist
        private void NewPlayList()
        {
            if (AskSaveCurrentPlayList("NEW PLAYLIST"))
            {
                Player1.Stop();

                _mediaToPlay = 0;
                PlayList.Clear();

                ReBuildPlayListMenu();
                AskSavePlayList = false;

                SelectMediaFiles();
            }
        }

        // Open a playlist
        private void OpenPlayList()
        {
            if (AskSaveCurrentPlayList("OPEN PLAYLIST"))
            {
                OpenFileDialog1.Title = OPENPLAYLIST_DIALOG_TITLE;
                OpenFileDialog1.Filter = PLAYLIST_DIALOG_FILTER;
                OpenFileDialog1.InitialDirectory = PlayListDirectory;
                OpenFileDialog1.Multiselect = false;
                OpenFileDialog1.FileName = string.Empty;

                if (OpenFileDialog1.ShowDialog(this) == DialogResult.OK)
                {
                    PlayListDirectory = Path.GetDirectoryName(OpenFileDialog1.FileName);
                    PlayList.Clear();
                    try
                    {
                        //playList = File.ReadAllLines(openFileDialog.FileName).Cast<string>().ToList();
                        PlayList = new List<string>(File.ReadAllLines(OpenFileDialog1.FileName));
                        ReBuildPlayListMenu();
                        AskSavePlayList = false;
                        _mediaToPlay = 0;
                        if (Prefs.AutoPlayNext) PlayNextMedia();  // && Prefs.AutoPlayAdded)
                        else Player1.Stop();
                    }
                    catch { }
                }
            }
        }

        // Add (merge) a playlist
        private void AddPlayList()
        {
            if (AskSaveCurrentPlayList("ADD PLAYLIST"))
            {
                OpenFileDialog1.Title = ADDPLAYLIST_DIALOG_TITLE;
                OpenFileDialog1.Filter = PLAYLIST_DIALOG_FILTER;
                OpenFileDialog1.InitialDirectory = PlayListDirectory;
                OpenFileDialog1.Multiselect = false;
                OpenFileDialog1.FileName = string.Empty;

                if (OpenFileDialog1.ShowDialog(this) == DialogResult.OK)
                {
                    PlayListDirectory = Path.GetDirectoryName(OpenFileDialog1.FileName);
                    try
                    {
                        PlayList.AddRange(File.ReadAllLines(OpenFileDialog1.FileName));
                        ReBuildPlayListMenu();
                        AskSavePlayList = true;
                    }
                    catch { }
                }
            }
        }

        // Save playlist (by user)
        private bool SavePlayListByUser()
        {
            bool result = true;
            if (PlayList.Count > 0)
            {
                SaveFileDialog1.InitialDirectory = PlayListDirectory;
                SaveFileDialog1.FileName = string.Empty;

                DialogResult r = SaveFileDialog1.ShowDialog(this);
                if (r == DialogResult.OK)
                {
                    PlayListDirectory = Path.GetDirectoryName(SaveFileDialog1.FileName);
                    try
                    {
                        File.WriteAllLines(SaveFileDialog1.FileName, PlayList.ToArray());
                        AskSavePlayList = false;
                    }
                    catch { }
                }
                else result = false;
            }
            return result;
        }

        #endregion

        // ******************************** PlayList Add Mediafiles, Add URLs, Handle default PlayList, ReBuildPlayListMenu

        #region PlayList Add Mediafiles, Add URLs, Handle default PlayList, ReBuildPlayListMenu

        // Use an OpenFileDialog to select mediafiles and add them to the PlayList
        internal void SelectMediaFiles()
        {
            OpenFileDialog1.Title = OPENMEDIA_DIALOG_TITLE;
            OpenFileDialog1.Filter = string.Empty;
            OpenFileDialog1.InitialDirectory = MediaDirectory;
            OpenFileDialog1.Multiselect = true;
            OpenFileDialog1.FileName = string.Empty;

            if (OpenFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                MediaDirectory = Path.GetDirectoryName(OpenFileDialog1.FileName);

                int newToPlay = PlayList.Count;
                AddToPlayList(OpenFileDialog1.FileNames);

                if (!Player1.Playing) // && Prefs.AutoPlayAdded)
                {
                    _mediaToPlay = newToPlay;
                    PlayNextMedia();
                }
            }
        }

        // Show the add URL dialog
        private void ShowAddUrlDialog()
        {
            AddUrlDialog addUrlDialog = new AddUrlDialog(this) {Text = APPLICATION_NAME};
            CenterDialog(this, addUrlDialog);

            int newToPlay = PlayList.Count;
            addUrlDialog.ShowDialog(this);
            if (addUrlDialog.UrlAdded && !Player1.Playing)  // && Prefs.AutoPlayAdded)
            {
                _mediaToPlay = newToPlay;
                PlayNextMedia();
            }
            addUrlDialog.Dispose();
        }
        
        // Add filenames to the PlayList
        internal void AddToPlayList(string[] fileNames)
        {
            //int contextMenuCount = playMenu.Items.Count;
            // Add names to playlist and Play contextmenu and save the PlayList
            PlayList.AddRange(fileNames);
            for (int i = 0; i < fileNames.Length; i++)
            {
                playMenu.Items.Add(Path.GetFileName(fileNames[i]));
            }
            ReBuildPlayListMenu();
            AskSavePlayList = true;
        }

        // Add the mediafilenames of the PlayList to the Play contextmenu
        internal void ReBuildPlayListMenu()
        {
            playMenu.SuspendLayout();

            // remove items from menu (if any; the first 4 items ('Playlists', 'Add mediaFiles', 'Add URL' and a separator) stay in place)
            while (playMenu.Items.Count > START_PLAYITEMS) playMenu.Items.RemoveAt(START_PLAYITEMS);

            // Add playlist names to Play contextmenu
            for (int i = 0; i < PlayList.Count; i++)
            {
                playMenu.Items.Add(Path.GetFileName(PlayList[i].Replace("&", "&&")));
                if (PlayList[i].StartsWith("http://", StringComparison.OrdinalIgnoreCase)) playMenu.Items[i + START_PLAYITEMS].ForeColor = Color.DarkKhaki;
                // 'we don't like this':
                playMenu.Items[i + START_PLAYITEMS].MouseDown += PlayMenu_MouseDown;
            }

            // Restore checkmark
            if (Player1.Playing)
            {
                if (_mediaToPlay == 0) ((ToolStripMenuItem)playMenu.Items[START_PLAYITEMS]).Checked = true;
                else if ((_mediaToPlay + START_PLAYITEMS - 1) < playMenu.Items.Count) ((ToolStripMenuItem)playMenu.Items[_mediaToPlay + START_PLAYITEMS - 1]).Checked = true;
            }

            // Adjust playlist menu
            if (PlayList.Count > 0)
            {
                newPlayListMenuItem.Enabled = true;
                addPlayListMenuItem.Enabled = true;
                savePlayListMenuItem.Enabled = true;
            }
            else
            {
                newPlayListMenuItem.Enabled = false;
                addPlayListMenuItem.Enabled = false;
                savePlayListMenuItem.Enabled = false;
            }

            playMenu.ResumeLayout();

            // Save the (default) playlist
            SavePlayList();

            // Also rebuild the PiPOverlay playlist
            _pipOverlay.ReBuildPIPPlayListMenu();

            // and shufflelist
            if (RepeatShuffle) CreateShuffleList();
        }

        // Save the (default) PlayList to disk (used when the PlayList has changed)
        private void SavePlayList()
        {
            try
            {
                if (PlayList.Count > 0)
                {
                    File.WriteAllLines(PlayListFile, PlayList.ToArray());
                }
                else File.Delete(PlayListFile);
            }
            catch { /* ignore */ }
        }

        // Load the previous saved PlayList (used when the application starts)
        private void LoadPlayList()
        {
            if (File.Exists(PlayListFile))
            {
                try
                {
                    PlayList = new List<string>(File.ReadAllLines(PlayListFile));
                    ReBuildPlayListMenu();
                }
                catch { /* ignore */ }
            }
        }

        #endregion

        #endregion


        // ******************************** Utility Functions - Uncheck MenuItems / Center Dialog

        #region Utility Functions - Uncheck MenuItems / Center Dialog

        private static void UnCheckMenuItems(ContextMenuStrip theMenu, int first, int last)
        {
            if (last == 0) last = theMenu.Items.Count - 1;
     
            for (int i = first; i <= last; i++)
            {
                if (theMenu.Items[i].GetType() == typeof(ToolStripMenuItem) && theMenu.Items[i] != null)
                {
                    ((ToolStripMenuItem)theMenu.Items[i]).Checked = false;
                }
            }
        }

        internal void CenterDialog(Form baseForm, Form centerForm)
        {
            Rectangle r = Screen.GetBounds(baseForm);

            centerForm.Left = baseForm.Left + ((baseForm.Width - centerForm.Width) / 2);
            if (centerForm.Left < r.Left) centerForm.Left = r.Left + 2;
            else if (centerForm.Left + centerForm.Width > r.Width) centerForm.Left = r.Width - centerForm.Width - 2;

            centerForm.Top = baseForm.Top + (baseForm.Height - centerForm.Height) / 2;
            if (centerForm.Top < r.Top) centerForm.Top = r.Top + 2;
            else if (centerForm.Top + centerForm.Height > r.Height - 48) centerForm.Top = r.Height - centerForm.Height - 48;
        }

        #endregion

        // ******************************** Install Private FontCollections and custom fonts

        #region Install Private FontCollections and custom fonts

        private void InstallFontCollection()
        {
            if (FontCollection != null) return;
            FontCollection = new PrivateFontCollection();

            // Crystal font
            Stream fontStream = GetType().Assembly.GetManifestResourceStream("AVPlayerExample.Resources.Crystal Italic1.ttf");
            byte[] fontData = new byte[fontStream.Length];
            fontStream.Read(fontData, 0, (int)fontStream.Length);
            fontStream.Close();
            unsafe
            {
                fixed (byte* pFontData = fontData)
                {
                    uint pcFonts = 0;
                    FontCollection.AddMemoryFont((IntPtr)pFontData, fontData.Length);
                    SafeNativeMethods.AddFontMemResourceEx((IntPtr)pFontData, (uint)fontData.Length, IntPtr.Zero, ref pcFonts);
                }
            }

            // WingDng3 font
            fontStream = GetType().Assembly.GetManifestResourceStream("AVPlayerExample.Resources.WingDings3a.ttf");
            fontData = new byte[fontStream.Length];
            fontStream.Read(fontData, 0, (int)fontStream.Length);
            fontStream.Close();
            unsafe
            {
                fixed (byte* pFontData = fontData)
                {
                    uint pcFonts = 0;
                    FontCollection.AddMemoryFont((IntPtr)pFontData, fontData.Length);
                    SafeNativeMethods.AddFontMemResourceEx((IntPtr)pFontData, (uint)fontData.Length, IntPtr.Zero, ref pcFonts);
                }
            }

            // Create fonts
            _crystalFont16 = new Font(FontCollection.Families[0], 16, FontStyle.Italic);
            _wingDng38 = new Font(FontCollection.Families[1], 8, FontStyle.Regular);
        }

        #endregion

    }

    // ******************************** Interface IOverlay

    #region Interface IOverlay

    // Interface used with overlays for easy access overlay menu setting
    // and main player MediaStopped notification
    internal interface IOverlay
    {
        bool HasMenu
        {
            get;
        }

        bool MenuEnabled
        {
            get;
            set;
        }

        void MediaStopped();
    }

    #endregion

}
