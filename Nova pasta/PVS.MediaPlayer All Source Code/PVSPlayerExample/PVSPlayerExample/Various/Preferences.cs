#region Usings

using PVS.MediaPlayer;
using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

#endregion

namespace PVSPlayerExample
{
    public partial class MainWindow
    {
        // ******************************** Preferences

        #region Preferences Fields

        [Serializable]
        public class Preferences
        {
            // Preferences Version
            public int              Version;

            // Window
            public bool             SaveWindow;
            public bool             Maximized;
            public Rectangle        Bounds;
            public bool             Fullscreen;
            public FullScreenMode   FullScreenMode;

            // DisplayMode
            public bool             SaveDisplayMode;
            public DisplayMode      DisplayMode;
            public Rectangle        VideoBounds;

            // Overlay
            public bool             SaveOverlay;
            public bool             AutoOverlay;
            public int              Overlay;
            public OverlayMode      OverlayMode;

            // Position Slider
            public bool             SaveSlider;
            public bool             SliderVisible;
            public bool             SliderProgress;
            public bool             SliderLiveUpdate;
            public bool             SliderSeekSilent;
            public int              SliderMouseWheel;

            // Repeat
            public bool             SaveRepeat;
            public int              Repeat; // 0 = off, 1 = one, 2 = all, 3 = shuffle

            // Speed
            public bool             SaveSpeed;
            public float            Speed;

            // Audio
            public bool             SaveAudio;
            public float            AudioVolume;
            public float            AudioBalance;
            public string           AudioDeviceId;

            // Folders
            public bool             SaveMediaFilesFolder;
            public string           MediaFilesFolder;
            public bool             SavePlaylistsFolder;
            public string           PlaylistsFolder;

            // Continue Playing Media
            public bool             ContinuePlay;
            public int              MediaToPlay;
            public double           Position;
            public double           StartPosition;
            public double           EndPosition;
            public bool             Paused;
            public int              RewindSecs;
            public bool             VideoPresent;

            // PlayList
            public bool             PlayListShowExtensions;
            public bool             PlayListChanged;
            public string           PlayListTitle;

            // Various
            public bool             AutoPlayStart;
            public bool             AutoPlayAdded;
            public bool             AutoPlayNext;
            public bool             OnErrorPlayNext; // non-persistent, same as AutoPlayNext but can for one time be changed in error dialog
            public bool             AutoHideCursor;
            public int              AutoHideCursorSeconds;
            public bool             OnErrorRemove;
            public bool             ShowErrorMessages;

            public bool             ClockShow;
            public bool             Clock24Hr;
            public Color            ClockColor;

            // Tooltips & Dialog MiniPlayers
            public bool             ShowTooltips;
            public bool             ShowMiniPlayers;

            // Output Level Meters
            public bool             MainLevelMeterShow;
            public Color            MainLevelMeterColor;
            public int              MainLevelMeterGain;
            public int              MainLevelMeterDecay;
            public Color            SoundLevelMeterColor;
            public Color            RecorderLevelMeterColor;

            // Slider Preview
            public bool             ShowSliderPreview;
            public int              SliderPreviewSize;
            public bool             SliderPreviewTimeOnly;

            public bool             ShowInfoLabels;
        }

        private const int           PREFERENCES_VERSION         = 11;
        private const int           DEFAULT_HIDE_CURSOR_SECONDS = 2;

        private string              _prefsFile                  = _appDataPath + PREFERENCES_NAME + ".inf"; // preferences file path
        internal static Preferences Prefs;

        #endregion

        private void LoadPreferences()
        {
            bool loadOk = false;
            if (Prefs == null) Prefs = new Preferences();

            if (File.Exists(_prefsFile))
            {
                //Use this for loading an xml-type file:
                //try
                //{
                //    using (StreamReader reader = new StreamReader(_prefsFile))
                //    {
                //        XmlSerializer xml = new XmlSerializer(typeof(Preferences));
                //        Prefs = (Preferences)xml.Deserialize(reader);
                //    }
                //    loadOk = true;
                //}
                //catch { /* ignore */ }

                // Use this for loading a binary-type file:
                try
                {
                    using (FileStream stream = File.Open(_prefsFile, FileMode.Open))
                    {
                        BinaryFormatter bin = new BinaryFormatter();
                        Prefs = (Preferences)bin.Deserialize(stream);
                    }
                    loadOk = true;
                }
                catch { /* ignore */ }
            }

            if (loadOk && Prefs.Version <= PREFERENCES_VERSION)
            {
                SetPreferences();
            }
            else SetDefaultPreferences();
        }

        private void SavePreferences()
        {
            GetPreferences(); // collect settings

            // Use this for saving an xml-type file:
            //try
            //{
            //    using (StreamWriter writer = new StreamWriter(_prefsFile))
            //    {
            //        XmlSerializer xml = new XmlSerializer(typeof(Preferences));
            //        xml.Serialize(writer, Prefs);
            //    }
            //}
            //catch { /* ignore */ }

            // Use this for saving a binary-type file:
            try
            {
                using (FileStream stream = File.Open(_prefsFile, FileMode.Create))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, Prefs);
                }
            }
            catch { /* ignore */ }
        }


        private void SetPreferences()
        {
            // Versions handling
            if (Prefs.Version < 11)
            {
                Prefs.AudioDeviceId     = string.Empty;
                Prefs.SliderSeekSilent  = false;

                if (Prefs.Version < 10)
                {
                    // interface colors changed
                    Prefs.MainLevelMeterColor   = UIColors.MenuTextEnabledColor;
                    Prefs.SoundLevelMeterColor  = UIColors.MenuTextEnabledColor;
                    Prefs.ClockColor            = UIColors.MenuTextEnabledColor;

                    if (Prefs.Version < 9)
                    {
                        Prefs.SliderMouseWheel = 0;
                        if (Prefs.Version < 8)
                        {
                            Prefs.ShowSliderPreview     = true;
                            Prefs.SliderPreviewSize     = 0;
                            Prefs.SliderPreviewTimeOnly = false;
                            Prefs.ShowInfoLabels        = true;

                            if (Prefs.Version < 7)
                            {
                                // because of renaming pref items
                                Prefs.MainLevelMeterShow        = true;
                                Prefs.MainLevelMeterColor       = UIColors.MenuTextEnabledColor;
                                Prefs.MainLevelMeterGain        = 1;
                                Prefs.MainLevelMeterDecay       = 0;
                                Prefs.SoundLevelMeterColor      = UIColors.MenuTextEnabledColor;
                                Prefs.RecorderLevelMeterColor   = UIColors.MenuTextEnabledColor;

                                if (Prefs.Version < 6)
                                {
                                    // you can change the peak level meters colors again (and it will be remembered),
                                    // but it was intended to have the same color as the other (foreground) interface items
                                    Prefs.MainLevelMeterColor       = UIColors.MenuTextEnabledColor;
                                    Prefs.SoundLevelMeterColor      = UIColors.MenuTextEnabledColor;
                                    Prefs.RecorderLevelMeterColor   = UIColors.MenuTextEnabledColor;

                                    Prefs.MainLevelMeterDecay = 0;

                                    if (Prefs.Version < 5)
                                    {
                                        Prefs.MainLevelMeterShow        = true;
                                        Prefs.MainLevelMeterColor       = UIColors.MenuTextEnabledColor;
                                        Prefs.MainLevelMeterGain        = 1;
                                        Prefs.MainLevelMeterDecay       = 0;
                                        Prefs.SoundLevelMeterColor      = UIColors.MenuTextEnabledColor;
                                        Prefs.RecorderLevelMeterColor   = UIColors.MenuTextEnabledColor;

                                        if (Prefs.Version < 4)
                                        {
                                            Prefs.OverlayMode           = OverlayMode.Video;
                                            Prefs.AutoHideCursor        = true;
                                            Prefs.AutoHideCursorSeconds = DEFAULT_HIDE_CURSOR_SECONDS;

                                            if (Prefs.Version < 3)
                                            {
                                                Prefs.AutoPlayAdded = true;
                                                Prefs.Clock24Hr     = CultureInfo.CurrentUICulture.DateTimeFormat.ShortTimePattern.StartsWith("H");
                                                Prefs.ClockColor    = UIColors.MenuTextEnabledColor;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            // Window
            if (Prefs.SaveWindow || (Prefs.ContinuePlay && Prefs.MediaToPlay >= 0))
            {
                // check if bounds are on (fully) any current screen (if saved with multiple screens setup)
                Rectangle r = Prefs.Bounds;
                r.Inflate(-16, -16); // add a little (off-screen) margin
                for (int i = 0; i < Screen.AllScreens.Length; i++)
                {
                    if (Screen.AllScreens[i].Bounds.Contains(r))
                    {
                        StartPosition   = FormStartPosition.Manual;
                        Bounds          = Prefs.Bounds;
                        break;
                    }
                }
                // FullScreen and others are set in Form1_Shown eventhandler
            }

            // Audio
            if (Prefs.SaveAudio || (Prefs.ContinuePlay && Prefs.MediaToPlay >= 0))
            {
                Player1.Audio.Volume    = Prefs.AudioVolume;
                Player1.Audio.Balance   = Prefs.AudioBalance;
            }

            // Position Slider
            if (Prefs.SaveSlider || (Prefs.ContinuePlay && Prefs.MediaToPlay >= 0))
            {
                SetSliderVisibility(!Prefs.SliderVisible);
                SetSliderProgress(Prefs.SliderProgress);
                SetSliderLiveUpdate(Prefs.SliderLiveUpdate);
                SetSliderSeekSilent(Prefs.SliderSeekSilent);
                //SetSliderPreview(Prefs.ShowSliderPreview); // moved to Form1_Shown to prevent crash (no base window)
                SetSliderMouseWheel(Prefs.SliderMouseWheel, false);
            }
            else
            {
                Prefs.ShowSliderPreview = false;
                Prefs.ShowInfoLabels = true;
            }
            // the SetInfoLabels(Prefs.ShowInfoLabels) is called from InitInterface
            // for the reason described there (= after setting the player sliders).

            // DisplayMode
            if (Prefs.SaveDisplayMode || (Prefs.ContinuePlay && Prefs.MediaToPlay >= 0))
            {
                if (Prefs.DisplayMode == DisplayMode.Manual)
                {
                    if(StartPosition == FormStartPosition.Manual) Player1.Video.Bounds = Prefs.VideoBounds;
                    else Player1.Display.Mode = DisplayMode.ZoomCenter;
                }
                else Player1.Display.Mode = Prefs.DisplayMode;
            }

            // Speed
            if (Prefs.SaveSpeed || (Prefs.ContinuePlay && Prefs.MediaToPlay >= 0))
            {
                Player1.Speed.Rate = Prefs.Speed;
            }

            Prefs.ShowTooltips = false;

            // Overlay - set in Form1_Shown
            // Repeat - set in Form1_Shown
            // FullScreen and others - set in Form1_Shown
        }

        private void SetDefaultPreferences()
        {
            Prefs.Version                   = PREFERENCES_VERSION;

            Prefs.SaveWindow                = false;
            Prefs.Maximized                 = false;
            Prefs.Bounds                    = Bounds;
            Prefs.Fullscreen                = false;
            Prefs.FullScreenMode            = FullScreenMode.Display;

            Prefs.SaveAudio                 = false;
            Prefs.AudioVolume               = 1000;
            Prefs.AudioBalance              = 500;
            Prefs.AudioDeviceId             = string.Empty;

            Prefs.SaveDisplayMode           = false;
            Prefs.DisplayMode               = DisplayMode.ZoomCenter;
            Prefs.VideoBounds               = Rectangle.Empty;

            Prefs.SaveSlider                = false;
            Prefs.SliderVisible             = true;
            Prefs.SliderProgress            = true;
            Prefs.SliderLiveUpdate          = false;
            Prefs.SliderSeekSilent          = false;
            Prefs.SliderMouseWheel          = 0;

            Prefs.SaveRepeat                = false;
            Prefs.Repeat                    = 0;

            Prefs.SaveOverlay               = false;
            Prefs.AutoOverlay               = true;
            Prefs.Overlay                   = -1;
            Prefs.OverlayMode               = OverlayMode.Video;

            Prefs.SaveSpeed                 = false;
            Prefs.Speed                     = 1000;

            Prefs.SaveMediaFilesFolder      = false;
            Prefs.MediaFilesFolder          = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            Prefs.SavePlaylistsFolder       = false;
            Prefs.PlaylistsFolder           = Prefs.MediaFilesFolder;

            Prefs.ContinuePlay              = false;
            Prefs.MediaToPlay               = -1;
            Prefs.Position                  = 0;
            Prefs.StartPosition             = 0;
            Prefs.EndPosition               = 0;
            Prefs.Paused                    = false;
            Prefs.RewindSecs                = 10;
            Prefs.VideoPresent              = false;

            Prefs.PlayListShowExtensions    = true;
            Prefs.PlayListChanged           = false;
            Prefs.PlayListTitle             = DEFAULT_PLAYLIST_TITLE;

            Prefs.AutoPlayStart             = false;
            Prefs.AutoPlayAdded             = true;
            Prefs.AutoPlayNext              = true;
            //Prefs.OnErrorPlayNext = true;
            Prefs.AutoHideCursor            = true;
            Prefs.AutoHideCursorSeconds     = DEFAULT_HIDE_CURSOR_SECONDS;
            Prefs.OnErrorRemove             = false;
            Prefs.ShowErrorMessages         = true;

            Prefs.ClockShow                 = false;
            Prefs.Clock24Hr                 = CultureInfo.CurrentUICulture.DateTimeFormat.ShortTimePattern.StartsWith("H");
            Prefs.ClockColor                = UIColors.MenuTextEnabledColor;

            Prefs.ShowTooltips              = false;
            Prefs.ShowMiniPlayers           = false;

            Prefs.MainLevelMeterShow        = true;
            Prefs.MainLevelMeterColor       = UIColors.MenuTextEnabledColor;
            Prefs.MainLevelMeterGain        = 1;
            Prefs.MainLevelMeterDecay       = 0;
            Prefs.SoundLevelMeterColor      = UIColors.MenuTextEnabledColor;
            Prefs.RecorderLevelMeterColor   = UIColors.MenuTextEnabledColor;

            Prefs.ShowSliderPreview         = false;
            Prefs.SliderPreviewSize         = 0;
            Prefs.SliderPreviewTimeOnly     = false;

            Prefs.ShowInfoLabels            = true;
        }


        private void GetPreferences()
        {
            // Version
            Prefs.Version           = PREFERENCES_VERSION;

            // Window
            Prefs.Fullscreen        = Player1.FullScreen;
            Prefs.FullScreenMode    = Player1.FullScreenMode;
            Prefs.Maximized         = WindowState == FormWindowState.Maximized;
            Prefs.Bounds            = Player1.Display.RestoreBounds;

            // Audio
            Prefs.AudioVolume       = Player1.Audio.Volume;
            Prefs.AudioBalance      = Player1.Audio.Balance;

            // DisplayMode
            Prefs.DisplayMode       = Player1.Display.Mode;
            Prefs.VideoBounds       = Player1.Video.Bounds;

            // Repeat
            if (RepeatOne)          Prefs.Repeat = 1;
            else if (RepeatAll)     Prefs.Repeat = 2;
            else if (RepeatShuffle) Prefs.Repeat = 3;
            else                    Prefs.Repeat = 0;

            // Position Slider
            Prefs.SliderVisible     = sliderAlwaysVisibleMenuItem.Checked;
            Prefs.SliderProgress    = sliderShowsProgressMenuItem.Checked;
            Prefs.SliderLiveUpdate  = sliderSeekLiveUpdateMenuItem.Checked;
            Prefs.SliderSeekSilent  = sliderSeekSilentMenuItem.Checked;
            // Prefs.SliderPreview etc. used and set by application.
            Prefs.SliderMouseWheel  = Player1.Sliders.Position.MouseWheel;

            // Display Overlay (stores the selected menu item - there are other ways to store the overlay)
            Prefs.Overlay           = -1;
            if (Player1.Overlay.Window != null)
            {
                for (int i = 3; i < displayOverlayMenu.Items.Count; i++) // find selected overlay menu item
                {
                    if (displayOverlayMenu.Items[i].GetType() == typeof(ToolStripMenuItem) && ((ToolStripMenuItem)displayOverlayMenu.Items[i]).Checked)
                    {
                        Prefs.Overlay = i;
                        break;
                    }
                }
            }
            Prefs.OverlayMode       = Player1.Overlay.Mode;

            // Speed
            Prefs.Speed             = Player1.Speed.Rate;

            // Continue Play
            if (Prefs.ContinuePlay && Player1.Playing)
            {
                // save current media (playlist entry)
                Prefs.MediaToPlay   = _mediaToPlay - 1;
                Prefs.Position      = Player1.Position.FromBegin.TotalMilliseconds;
                Prefs.StartPosition = Player1.Media.StartTime.TotalMilliseconds;
                Prefs.EndPosition   = Player1.Media.StopTime.TotalMilliseconds;
                Prefs.Paused        = Player1.Paused;
                Prefs.VideoPresent  = Player1.Video.Present;
            }
            else
            {
                Prefs.MediaToPlay   = -1;
            }

            // other options set elsewhere (Form1_Shown and some Prefs are used as 'normal' fields)
        }
    }
}
