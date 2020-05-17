#Region "Imports"

Imports System.Drawing.Drawing2D
Imports System.Text
Imports PVS.MediaPlayer

#End Region

Public Class Form1

    ' PVS.MediaPlayer 0.99 Example Application - How To...

    ' This example application shows the use of some of the methods and properties of
    ' the PVS.MediaPlayer library version 0.99 - licensed under The Code Project Open License (CPOL)

    ' PVS.MediaPlayer uses (part of) the Media Foundation .NET library by nowinskie and snarfle (https://sourceforge.net/projects/mfnet).
    ' Licensed under either Lesser General Public License v2.1 or BSD.  See license.txt or BSDL.txt for details (http://mfnet.sourceforge.net).

    ' Contents:

    '  1. check if Microsoft Media Foundation is installed

    '  2. change the shape of the player's display window
    '  3. drag a form by dragging a player's display window
    '  4. automatically hide the mouse cursor during media playback

    '  5. add a display overlay
    '  5a.display overlay opacity with clones and copies
    '  6. make a display overlay always visible - from application start

    '  7. add one or more display clones

    '  8. get media ended information
    '  9. play (or repeat) only a part of a media file
    ' 10. add a taskbar progress indicator

    ' 11. continuously receive information about the playback position
    ' 12. add a position slider controlled by the player

    ' 13. set the audio output device used by the player
    ' 14. select an audio or video track

    ' 15. audio values: set and get audio volume and balance information
    ' 16. audio sliders: add audio volume and balance sliders controlled by the player
    ' 17. continuously receive information about the audio output levels

    ' 18. get media subtitles
    ' 19. get media metadata properties
    ' 20. add a custom info label to any slider (trackbar)


    ' These options are initialized and commented in the constructor (method Main: Form1()) of this class.

    ' Many options in de PVS.MediaPlayer library are available even when no media is playing, they
    ' are 'Player settings' not 'Media settings', e.g.: Display settings (e.g. fullscreen),
    ' Audio settings (volume/balance), Start/EndPosition, Pause/Resume and others.


    ' If you have questions about using the PVS.MediaPlayer library or this sample application, do not hesitate
    ' to ask a question in the PVS.MediaPlayer article's comments on The Code Project:
    ' https://www.codeproject.com/Articles/109714/PVS-MediaPlayer-Audio-and-Video-Player-Library


    ' Peter Vegter
    ' May 2020, The Netherlands


    ' **** Class Fields ***************************************************************************

#Region "Class Fields"

    Private myPlayer As Player
    Private myOverlay As Overlay                ' in file Overlay.vb

    Private shapeStatus As Integer              ' shapes - 0:none, 1:oval, 2:none, 3:rounded, 4:none, 5:star

    Private myInfoLabel As InfoLabel
    Private myInfoLabelText As StringBuilder = New StringBuilder(64)

    ' used with drawing audio output levels
    ' levelUnit = size of 1 unit (of 32767) / 140 = width of Panel4 and Panel5
    Private levelUnit As Double = 140           ' / 32767.0 - changed in PVS.MediaPlayer version 0.91
    Private leftLevel As Integer
    Private rightLevel As Integer
    Private levelBrush As Brush = New HatchBrush(HatchStyle.LightVertical, Color.FromArgb(179, 173, 146))

    Private myMetadata As Metadata              ' media metadata properties

    Private myOpenFileDlg As OpenFileDialog     ' used with selection of media to play
    Private Const OPENMEDIA_FILTER As String =
            " Media Files (*.*)|*.3g2; *.3gp; *.3gp2; *.3gpp; *.aac; *.adts; *.asf; *.avi; *.m4a; *.m4v; *.mkv; *.mov; *.mp3; *.mp4; *.mpeg; *.mpg; *.sami; *.smi; *.wav; *.webm; *.wma; *.wmv|" +
            " All Files|*.*"

    Private isInitializing As Boolean
    Private wasDisposed As Boolean
#End Region


    ' **** Main ***********************************************************************************

#Region "Main"

    Public Sub New()

        ' Check if Media Foundation is installed - PVS.MediaPlayer cannot be used without.
        If Not Player.MFPresent Then

            ' Media Foundation is not installed - show a message and exit the application
            MessageBox.Show("Microsoft Media Foundation" + vbNewLine + vbNewLine +
                    Player.MFPresent_ResultString + ".",
                    "PVS.MediaPlayer How To ...",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Stop)

            Throw New ApplicationException("Media Foundation not installed.")

        End If

        isInitializing = True
        InitializeComponent()               ' this call is required by the designer
        isInitializing = False

        myPlayer = New Player()             ' create a player
        myPlayer.Display.Window = Panel1    ' and set its display to Panel1
        myPlayer.Repeat = True              ' repeat media playback when finished

        myPlayer.SleepDisabled = True       ' prevent the computer from entering sleep mode

        ' create a file selector
        myOpenFileDlg = New OpenFileDialog() With
        {
            .Title = "Play Media",
            .Filter = OPENMEDIA_FILTER,
            .FilterIndex = 1                ' 1 = Media Files
        }

        ' mouse down eventhandlers to switch between stretch and zoom of clone displays 
        AddHandler Panel2.MouseDown, AddressOf Clone_MouseClick
        AddHandler Panel3.MouseDown, AddressOf Clone_MouseClick


        ' You may want to add one or more of the following options to your player:


        ' **** 1. CHECK IF MICROSOFT MEDIA FOUNDATION IS INSTALLED ********************************

        ' Check if Media Foundation is installed - PVS.MediaPlayer cannot be used without.

        ' See the code at the beginning of this constructor (New()). The check has to be performed
        ' before a player is created. If a player is created without Media Foundation installed,
        ' an exception is generated.



        ' **** 2. CHANGE THE SHAPE OF THE PLAYER'S DISPLAY WINDOW *********************************

        ' The shape of a player's display can be changed from the usual rectangular shape to one
        ' of the preset shapes provided by the player with the Player.Display.SetShape method.

        ' For example:
        ' myPlayer.Display.SetShape(DisplayShape.Oval)

        ' To restore the original display shape, use:
        ' myPlayer.Display.SetShape(DisplayShape.Normal)



        ' **** 3. DRAG A FORM BY DRAGGING A PLAYER'S DISPLAY WINDOW *******************************

        ' In some cases it may be convenient to drag a form not only by its title bar but also by a
        ' player's display window on the form. You can enable this option with:

        myPlayer.Display.DragEnabled = True

        ' You can specify the mouse cursor being used while dragging the form/display window, for
        ' example:

        myPlayer.Display.DragCursor = Cursors.SizeAll ' 'SizeAll' is also the default drag cursor

        ' From version 0.95 the PVS.MediaPlayer library no longer uses global mouse hooks. The use of
        ' dragging the display of a player with a display overlay has therefore changed.
        ' For more information see: 4. ADD A DISPLAY OVERLAY



        ' **** 4. AUTOMATICALLY HIDE THE MOUSE CURSOR DURING MEDIA PLAYBACK ***********************

        ' If you want to keep the mouse cursor 'out of the way' when a movie (or any other media)
        ' is playing, you can use the "Player.CursorHide" methods of the player.

        ' By specifying the form(s) on which the cursor is to be hidden, the player automatically
        ' hides the cursor on those forms (when in the foreground) when media is played and the mouse
        ' has not been used for a while, for example on this form:

        myPlayer.CursorHide.Add(Me)

        ' You can add as many "cursor hiding" forms to the player as you like, for example forms
        ' that contain a display clone of the player or even forms that are not directly related
        ' to the player.

        ' You can change the number of seconds to wait before hiding a non-active mouse with, for
        ' example:

        myPlayer.CursorHide.Delay = 3 ' 3 seconds is also the default waiting time



        ' **** 5. ADD A DISPLAY OVERLAY ***********************************************************

        ' A display overlay is a form that allows you to display items on top of a movie.
        ' The sample overlay 'Overlay' is created with the Visual Studio designer.

        myOverlay = New Overlay(myPlayer)     ' create (an instance of) the overlay
        myPlayer.Overlay.Window = myOverlay   ' and attach it to the player

        ' To remove a display overlay from the player set the overlay window to another overlay
        ' or to Nothing: myPlayer.Overlay.Window = Nothing

        ' From version 0.95 of the PVS.MediaPlayer library the player's display window behaviour has
        ' changed. The display can now be used as any other control: you can add controls to it and
        ' get mouse events from it. PVS.MediaPlayer does not use global mouse hooks anymore.

        ' This also changes the display window dragging option (see 2. above). The library provides
        ' now a method (eventhandler) to drag a player's display window from a display overlay:
        ' myPlayer.Display.Drag_MouseDown

        ' The use of display overlays is explained in more detail in the file Overlay.vb



        ' **** 5A. DISPLAY OVERLAY OPACITY WITH CLONES AND COPIES ********************************

        ' To have the same opacity of display overlays on the player's display clones and with
        ' certain screen copies, you can use, for example:

        myPlayer.Overlay.Blend = OverlayBlend.Transparent

        ' This option is not activated by default because it does not work well with with some
        ' standard interface items such as buttons, labels and panels.
        ' In this example labels are used with a custom paint method. They use the Graphics.DrawString
        ' method instead of the standard method. And that works as it should. See the file Overlay.vb



        ' **** 6. MAKE A DISPLAY OVERLAY ALWAYS VISIBLE - FROM APPLICATION START ******************

        ' A display overlay is usually only shown when media is playing, but if you want to always
        ' show the overlay you can use: myPlayer.Overlay.Hold = True

        ' The player's display has to be created and visible for this, so if you want
        ' to show the overlay right from the start of your application (without media playing) you
        ' have to put the 'Overlay.Hold' instruction in the Form1.Shown event handler (see below).



        ' **** 7. ADD ONE OR MORE DISPLAY CLONES **************************************************

        ' For special purposes you can create one or more player display clones (display copies).
        ' Display clones require sufficient computing (CPU) power and may slow some computers:

        myPlayer.DisplayClones.AddRange(New Control() {Panel2, Panel3})

        ' CPU load can be reduced by lowering the framerate, quality or size of the clones.

        ' Display clones use a CloneProperties data structure to get or set its properties,
        ' for example to set the 'stretch' option for a display clone:

        Dim props As CloneProperties = myPlayer.DisplayClones.GetProperties(Panel2)
        props.Layout = CloneLayout.Stretch
        myPlayer.DisplayClones.SetProperties(Panel2, props)

        ' Display clones can now also have a custom shape, just like the player's display window, for example:
        ' myPlayer.DisplayClones.SetProperties(Panel2, New CloneProperties With {.Shape = DisplayShape.Oval})

        ' To remove display clones from the player use one of the clones remove methods, for example:
        ' myPlayer.DisplayClones.Remove(panel2)



        ' **** 8. GET MEDIA ENDED INFORMATION *****************************************************

        ' You may want to know when media has finished playing to play other (next) media and/or
        ' stop certain processes (e.g. animation on a display overlay).
        ' To detect that media has finished playing just subscribe to the MediaEnded event:

        AddHandler myPlayer.Events.MediaEnded, AddressOf MyPlayer_MediaEnded  ' see eventhandler below

        ' You don't want to start playing next media from the MediaEnded event before all processes
        ' have been notified that the previous media has finished playing, so there's another event:

        AddHandler myPlayer.Events.MediaEndedNotice, AddressOf MyPlayer_MediaEndedNotice  ' see below

        ' you can use this event to just stop any active processes (and not start any new media).
        ' (With the MediaStarted event you can (re)start processes when new media starts playing.)

        ' To unsubscribe from the event you can use the RemoveHandler statement.



        ' **** 9. PLAY (OR REPEAT) ONLY PART OF A MEDIA FILE **************************************

        ' N.B. 'Begin' and 'End' is used to indicate the natural begin and end of media
        '      'Start' and 'Stop' is used to indicate the actual start and stop times of media
        '      If not changed, 'Start' and 'Stop' values are the same as 'Begin' and 'End' values.

        ' You can play (or repeat) only a part of a media file by specifying the start- and/or stop time:

        ' a. to start playing media from a certain time just use the Play method, for instance:
        ' myPlayer.Play(fileName, TimeSpan.FromSeconds(30), TimeSpan.Zero)

        ' b. to start repeating a certain part of the media (for example 10 seconds), for instance:
        ' myPlayer.Play(fileName, TimeSpan.FromSeconds(30), TimeSpan.FromSeconds(40), True)

        ' c. while media is playing, for example, finish in 10 minutes from the current position:
        ' myPlayer.Media.StopTime = myPlayer.Position.FromBegin + TimeSpan.FromMinutes(10)

        ' d. to stop repeating (playing) media, use:
        ' myPlayer.Repeat = False



        ' **** 10. ADD A TASKBAR PROGRESS INDICATOR ***********************************************

        ' To add a progress indicator in the taskbar button of a form, all you have to do is instruct
        ' the player to do so by specifying the form:

        myPlayer.TaskbarProgress.Add(Me)

        ' You can specify any form you like (not just the form the display of the player is on) and use
        ' multiple and/or duplicate Forms.

        ' You can specify the mode of the progress indicator (progress (default) or track (= 'begin to end')):

        myPlayer.TaskbarProgress.Mode = TaskbarProgressMode.Track

        ' You can remove a progress indicator with, for example: myPlayer.TaskbarProgress.Remove(Me)



        ' **** 11. CONTINUOUSLY RECEIVE INFORMATION ABOUT THE PLAYBACK POSITION *******************

        ' If you want to display the elapsed and/or remaining media playback time (or use your
        ' 'own' position slider) you can get continuous media playback positions information with:

        AddHandler myPlayer.Events.MediaPositionChanged, AddressOf MyPlayer_MediaPositionChanged ' see below

        ' The information is sent by the player every 100 milliseconds (10 times a second)
        ' This interval (and other timings) can be changed with the property myPlayer.TimerInterval

        ' To unsubscribe from the event you can use the RemoveHandler statement.



        ' **** 12. ADD A POSITION SLIDER CONTROLLED BY THE PLAYER *********************************

        ' The player can control your media playback position slider (trackbar) with:

        myPlayer.Sliders.Position.TrackBar = TrackBar1

        ' The position slider controlled by the player is only for input by the user. The value of
        ' the slider should not be set from code. If you want to change the playback position (and
        ' the slider value), use the position methods of the player, for example:
        ' myPlayer.Position.FromBegin = TimeSpan.FromSeconds(30).

        ' There are various options available for the position slider, for example:
        ' myPlayer.Sliders.Position.LiveUpdate = False

        ' To remove a slider from the player set the slider to Nothing:
        ' myPlayer.Sliders.Position.TrackBar = Nothing;



        ' **** 13. SET THE AUDIO OUTPUT DEVICE USED BY THE PLAYER *********************************

        ' By default, the player uses the system's default audio output device (if any), but this
        ' can be changed using the Player.Audio.Device property.

        ' This property uses an 'AudioDevice' data structure that contains the following 3 fields:
        ' Id - the identifier of the audio device - this is actually used to set the output device
        ' Name - the name of the device, for instance "Speakers"
        ' Adapter - the name of the adapter of the device, for instance "XYZ Audio Adapter"

        ' The AudioDevice data structures of the system's enabled audio devices can be retrieved with:
        ' Dim devices() As AudioDevice = myPlayer.Audio.GetDevices()
        ' If there are no enabled audio output devices this method returns Nothing.

        ' To select one of the devices retrieved from GetDevices (usually selected from a menu) use:
        ' myPlayer.Audio.Device = devices(index) ' where index represents a device in the zero-based list

        ' To get the system's default audio device (or Nothing if none) you can use:
        ' Dim defaultDevice as AudioDevice = myPlayer.Audio.GetDefaultDevice()

        ' To restore the use of the system's default audio device use myPlayer.Audio.Device = Nothing
        ' This property also returns Nothing if the player uses the system's default audio device.

        ' To be informed of changes in the system's audio devices, subscribe to the devices event, for example:
        ' AddHandler myPlayer.Events.MediaSystemAudioDevicesChanged, AddressOf MyPlayer_SystemAudioDevicesChanged

        ' There's also an event for when the player's audio device has changed, for example:
        ' AddHandler myPlayer.Events.MediaAudioDeviceChanged, AddressOf MyPlayer_AudioDeviceChanged

        ' *****************************************************************************************
        ' Note: PVS.MediaPlayer handles all audio devices and related events. This includes any changes
        ' to the system audio devices and, for example, peak level information. You only need to use
        ' the audio device events to update a user interface (for example, a devices menu).
        ' *****************************************************************************************

        ' If the audio device used by the player is disabled or removed (with the system's sound
        ' control panel), the sound is output through the (new) standard audio device.

        ' For a small but complete system of handling audio devices see the source code of the main
        ' sample application PVSPlayerExample.



        ' **** 14. SELECT AN AUDIO OR VIDEO TRACK *************************************************

        ' A media file can contain multiple audio and video tracks. The media starts playing the
        ' standard selected tracks, but these can easily be changed. For example, you can display
        ' the tracks in a menu and let the user select one of the tracks.

        ' For example, to select another audio track use:
        ' myPlayer.Audio.Track = 1 ' select the second audio track (if present)

        ' Information about the available audio tracks can be obtained with:
        ' Dim count As Integer = myPlayer.Media.AudioTrackCount ' gets the number of audio tracks
        ' Dim tracks() as AudioTrack = myPlayer.Media.GetAudioTracks() ' gets information about each track
        ' If there are no audio tracks in the media, this function returns Nothing.

        ' The information can be used to display properties of the track, for example in a menu:
        ' myMenu.Items.Add(tracks(0).Name + " " + tracks(0).Language)


        ' Another video track can be selected in the same way:
        ' myPlayer.Video.Track = 0 ' select the first video track (if present)

        ' Information about the available video tracks can be obtained with:
        ' Dim count As integer = myPlayer.Media.VideoTrackCount ' gets the number of video tracks
        ' Dim tracks() As VideoTrack = myPlayer.Media.GetVideoTracks() ' gets information about each track
        ' If there are no video tracks in the media, this function returns Nothing.



        ' **** 15. AUDIO VALUES *******************************************************************

        ' The audio volume and balance values of the player can be set with, for example:
        ' myPlayer.Audio.Volume = 0.5
        ' myPlayer.Audio.Balance = -0.5

        ' If the playing media contains more than 2 audio channels and you have a suitable audio set
        ' connected to your computer, you can also set the volume of each channel:

        ' You can check the number of audio channels in the playing media with:
        ' Dim channelCount As Integer = myPlayer.Audio.ChannelCount

        ' You can get the audio volumes for each channel with:
        ' Dim channelVolumes() As Single = myPlayer.Audio.ChannelVolumes

        ' To change the volume of, for example, the right (or 2nd) channel, use:
        ' channelVolumes(1) = 0.7
        ' myPlayer.Audio.ChannelVolumes = channelVolumes

        ' To get the changed values of the player's audio volume and balance use these events:
        AddHandler myPlayer.Events.MediaAudioVolumeChanged, AddressOf MyPlayer_MediaAudioVolumeChanged
        AddHandler myPlayer.Events.MediaAudioBalanceChanged, AddressOf MyPlayer_MediaAudioBalanceChanged ' see below

        ' To unsubscribe from the event you can use the RemoveHandler statement.



        ' **** 16. AUDIO SLIDERS ******************************************************************

        ' The player can also control your audio sliders (trackbars) with:

        myPlayer.Sliders.AudioVolume = TrackBar2    ' audio volume slider
        myPlayer.Sliders.AudioBalance = TrackBar3   ' audio balance slider

        ' The audio sliders controlled by the player are only for input by the user. The values of
        ' the sliders should not be set from code. If you want to change the audio properties (and
        ' the sliders values) of the player, use the audio methods of the player, for example:
        ' myPlayer.Audio.Volume = 0.5

        ' To remove a slider from the player set the slider to Nothing:
        ' myPlayer.Sliders.AudioVolume = Nothing



        ' **** 17. AUDIO OUTPUT PEAK LEVELS ******************************************************

        ' Audio output levels can be used to display the peak levels of the player's audio output
        ' device (for instance 'speakers') in a numeric or graphical (for example level/vu meters)
        ' form or for other purposes.

        ' To get the audio peak values from the audio device used by the player you can use the
        ' MediaPeakLevelChanged event of the player:

        AddHandler myPlayer.Events.MediaPeakLevelChanged, AddressOf MyPlayer_MediaPeakLevelChanged
        ' see the eventhandler below.

        ' check if there is an audio device or if this function is not supported (Windows Vista or
        ' higher only) with:

        ' If (myPlayer.LastError) Then ' Not supported

        ' The values received in the eventhandler are between 0.0 and 1.0 (inclusive) or -1 when media
        ' playback has paused, stopped or ended - for every audio channel (usually 2 for stereo).

        ' To unsubscribe from the event you can use the RemoveHandler statement.



        ' **** 18. MEDIA SUBTITLES ****************************************************************

        ' You can get the SubRip (.srt) subtitles (if any) of the playing media by subscribing to
        ' the MediaSubtitleChanged event:

        AddHandler myPlayer.Events.MediaSubtitleChanged, AddressOf MyPlayer_MediaSubtitleChanged
        ' see the eventhandler below.

        ' By default the subtitles file should be in the same folder and with the same name (but
        ' with the .srt extension) as the media file, or one of its containing folders. You can
        ' specify to search in any containing folders with (0 = media file 'base' folder):

        myPlayer.Subtitles.DirectoryDepth = 1 ' search base folder and containing folders 1 level deep

        ' If the subtitles file is located somewhere else or it has another name, you can specify
        ' where to search with the myPlayer.Subtitles.Directory and/or myPlayer.Subtitles.FileName
        ' functions. The Folder depth search applies also to this location.

        ' There are some more convenient functions, e.g. to synchronize subtitles (TimeShift).

        ' To unsubscribe from the event you can use the RemoveHandler statement.



        ' **** 19. MEDIA METADATA PROPERTIES ******************************************************

        ' You can get media metadata properties (like mp3 tags) with, for example:

        ' Dim data As Metadata = myPlayer.Media.GetMetadata()

        ' If no information is available for a specific item, the value of that item is null (Nothing).
        ' Use for example:  If String.IsNullOrEmpty(data.Artist) Then ...

        ' You can also extract this information from any (non-playing) file by specifying the file name.

        ' See the methods PlayMedia, MyPlayer_MediaEnded, MyPlayer_MediaStopped and
        ' DisposeMetadata for an example of the use of the media metadata properties option.



        ' **** 20. ADD AN INFO LABEL TO THE PLAYER'S POSITION SLIDER ******************************

        ' Displaying slider information with an info label is made easy with the slider methods:
        ' myPlayer.Sliders.ValueToPoint gives the x/y-coordinate of a value on the slider and
        ' myPlayer.Sliders.PointToValue gives the value of the slider at a certain x/y-coordinate.
        ' These methods can be used for any .net trackbar (not just the PVS.MediaPlayer sliders).
        ' (Without a player you can use: SliderValue.ToPoint or SliderValue.FromPoint)

        ' Info Labels can be used 'everywhere', not just with sliders as in this example.
        ' Just use the info label Show method to display an info label wherever you want.

        ' The location of the info label is determined by the specified location in the Show method
        ' and the Align (e.g. TopCenter (default)) and AlignOffset settings.
        ' The size of the info label is determined by font, bordersize, etc. but the 'additional' size
        ' is set with the TextMargin (or TextSize for a fixed size info label) option.

        ' Most options will probably be clear, but here's some tips:
        ' - border and other brushes: first set the full size of the info label (e.g. fontsize,
        ' bordersize etc. etc. and, in most cases, also a 'dummy' text) then create the brush
        ' - setting a fixed size info label, same as with brushes and then use:
        ' myInfoLabel.TextSize = myInfoLabel.TextSize; // this sets the current size and autosize to false
        ' - the order in which the settings are made can be important.

        ' Create an info label for use with all sliders in this application:
        myInfoLabel = New InfoLabel With
        {
            .RoundedCorners = True,                 ' use rounded corners
            .FontSize = 9.75F,                      ' set font size (same as main window)
            .TextMargin = New Padding(2, 0, 2, 0),  ' fine tuning inner spacing
            .AlignOffset = New Point(0, 7)          ' move closer to slider thumb
        }


        ' Here are some more examples (uncomment one at a time):

        ' for the background any type of brush can be used (uncomment only this one to use)
        Dim myBackBrush As LinearGradientBrush = New LinearGradientBrush(New Rectangle(New Point(0, 0), myInfoLabel.Size), SystemColors.ButtonHighlight, SystemColors.ButtonShadow, LinearGradientMode.Vertical)
        myInfoLabel.BackBrush = myBackBrush

        ' or maybe no background at all (uncomment only this one to use):
        'myInfoLabel.ForeColor = Color.Red
        'myInfoLabel.BackColor = Color.OrangeRed ' reduce visible edges around the text (anti-aliasing on transparent background)
        'myInfoLabel.BorderThickness = New Padding(0)
        'myInfoLabel.FontSize = 36
        'myInfoLabel.Transparent = True

        ' here's a fixed size info label with a background picture (uncomment only this one to use):
        'myInfoLabel.TextMargin = New Padding(10, 70, 10, 10)
        'myInfoLabel.ForeColor = Color.White
        'myInfoLabel.Text = "Balance: Right 10.0" ' set size with the 'longest' possible text
        'myInfoLabel.TextSize = myInfoLabel.TextSize ' set size + autosize off
        'Dim infoImage As Image = Image.FromFile("C:\Users\Public\Pictures\Sample Pictures\Desert.jpg")
        'myInfoLabel.BackImage = infoImage ' set image after turning off autosize (with TextSize)


        ' Display an info label above the position slider's thumb using the slider's scroll event:
        AddHandler TrackBar1.Scroll, AddressOf TrackBar1_Scroll     ' see eventhandler below

        ' Same for the audio volume and balance sliders:
        AddHandler TrackBar2.Scroll, AddressOf TrackBar2_Scroll     ' see eventhandler below
        AddHandler TrackBar3.Scroll, AddressOf TrackBar3_Scroll     ' see eventhandler below

    End Sub

    ' Display overlay right from the start - handler created from the designer
    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        ' show the display overlay at the start of the application (even if no movie is playing):
        ' this instruction is put here because the player's display has to be 'created and visible'
        ' to show the overlay
        myPlayer.Overlay.Hold = True
    End Sub

    ' Clean Up - this is moved here from the 'Form1.Designer.vb' file and appended:
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If Not wasDisposed Then
                wasDisposed = True
                If disposing Then

                    ' disposing a player also stops its overlay, display clones, eventhandlers etc.
                    myPlayer.Dispose()      ' dispose the player
                    myOverlay.Dispose()     ' dispose the display overlay
                    myOpenFileDlg.Dispose() ' dispose the file selector

                    If levelBrush IsNot Nothing Then
                        levelBrush.Dispose()
                    End If

                    If myMetadata IsNot Nothing Then
                        myMetadata.Dispose()
                    End If

                    If myInfoLabel IsNot Nothing Then
                        myInfoLabel.Dispose()
                    End If

                    ' used by the designer - clean up
                    If components IsNot Nothing Then components.Dispose()
                End If
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    ' Dispose media metadata properties
    Private Sub DisposeMetadata()
        If myMetadata IsNot Nothing Then
            myOverlay.subtitlesLabel.Text = String.Empty
            Panel1.BackgroundImage = Nothing
            myMetadata.Dispose()
            myMetadata = Nothing
        End If
    End Sub

#End Region

    ' **** Media Play / Pause - Resume / Stop *****************************************************

#Region "Media Play / Pause - Resume / Stop"

    Private Sub PlayMedia()
        ' select and play media
        If (myOpenFileDlg.ShowDialog() = DialogResult.OK) Then
            myPlayer.Play(myOpenFileDlg.FileName)
            If (myPlayer.LastError) Then
                MessageBox.Show(myPlayer.LastErrorString)
            Else
                ' show media metadata properties (here for audio media only)
                If Not myPlayer.Has.Video Then
                    myMetadata = myPlayer.Media.GetMetadata
                    Panel1.BackgroundImageLayout = ImageLayout.Zoom

                    Panel1.BackgroundImage = myMetadata.Image
                    myOverlay.subtitlesLabel.Text = myMetadata.Artist + vbNewLine + myMetadata.Title
                End If
            End If
        End If
    End Sub

    Private Sub PauseMedia()
        myPlayer.Paused = Not myPlayer.Paused
        If (myPlayer.Paused) Then
            Button2.Text = "Resume"
        Else
            Button2.Text = "Pause"
        End If
    End Sub

    Private Sub StopMedia()
        myPlayer.Stop()
    End Sub

#End Region

    ' **** Player Eventhandlers *******************************************************************

#Region "Player Eventhandlers"

    ' Show changed audio volume value
    Private Sub MyPlayer_MediaAudioVolumeChanged(sender As Object, e As EventArgs)
        Label3.Text = (myPlayer.Audio.Volume).ToString("0.00")
    End Sub

    ' Show changed audio balance value
    Private Sub MyPlayer_MediaAudioBalanceChanged(sender As Object, e As EventArgs)
        Label4.Text = (myPlayer.Audio.Balance).ToString("0.00")
    End Sub

    ' Display the elapsed and remaining playback time
    Private Sub MyPlayer_MediaPositionChanged(sender As Object, e As PositionEventArgs)

        Label1.Text = TimeSpan.FromTicks(e.FromStart).ToString().Substring(0, 8) ' "hh:mm:ss"
        Label2.Text = TimeSpan.FromTicks(e.ToStop).ToString().Substring(0, 8)    ' "hh:mm:ss"

        ' from .NET 4.0 TimeSpan supports (custom) format strings e.g.
        ' Label1.Text = TimeSpan.FromTicks(e.FromStart).ToString("hh\:mm\:ss")   ' "hh:mm:ss"

    End Sub

    ' Handle media audio output peak levels - calculate the values and paint the level displays
    Private Sub MyPlayer_MediaPeakLevelChanged(sender As Object, e As PeakLevelEventArgs)
        ' you could add some 'logic' here to make the movements of the indicators less 'jumpy'

        If e.MasterPeakValue = -1 Then ' Media playback has stopped or paused or volume set to 0
            ' graphical presentation
            leftLevel = 0
            rightLevel = 0

            ' value display
            Label5.Text = "0.00" ' same format as below
            Label6.Text = "0.00"
        Else
            ' check e.ChannelCount for more than 2 (= stereo) channels
            ' if you want to display the peak levels of all audio channels

            ' graphical presentation
            leftLevel = CInt(e.ChannelsValues(0) * levelUnit) ' levelUnit is the width of panel4 and 5
            rightLevel = CInt(e.ChannelsValues(1) * levelUnit)

            ' value display (use string format because of 'Single' rounding errors - zero can become a small value):
            Label5.Text = e.ChannelsValues(0).ToString("0.00")
            Label6.Text = e.ChannelsValues(1).ToString("0.00")
        End If
        Panel4.Invalidate() ' draw the new values
        Panel5.Invalidate()
    End Sub

    ' Paint the left channel audio output level display - handler created from the designer
    Private Sub Panel4_Paint(sender As Object, e As PaintEventArgs) Handles Panel4.Paint
        e.Graphics.FillRectangle(levelBrush, 0, 0, leftLevel, Panel4.ClientRectangle.Height)
    End Sub

    ' Paint the right channel audio output level display - handler created from the designer
    Private Sub Panel5_Paint(sender As Object, e As PaintEventArgs) Handles Panel5.Paint
        e.Graphics.FillRectangle(levelBrush, 0, 0, rightLevel, Panel5.ClientRectangle.Height)
    End Sub

    ' Mouse clicked on player display - movie, overlay or just display
    Private Sub MyPlayer_MediaMouseClick(sender As Object, e As MouseEventArgs)
        If (myPlayer.Display.Mode = DisplayMode.Stretch) Then
            myPlayer.Display.Mode = DisplayMode.ZoomCenter
        Else
            myPlayer.Display.Mode = DisplayMode.Stretch
        End If
    End Sub

    ' Mouse clicked on player display clone
    Private Sub Clone_MouseClick(sender As Object, e As MouseEventArgs)

        Dim clickedPanel As Panel = CType(sender, Panel)

        Dim props As CloneProperties = myPlayer.DisplayClones.GetProperties(clickedPanel)
        If props.Layout = CloneLayout.Stretch Then
            props.Layout = CloneLayout.Zoom
        Else
            props.Layout = CloneLayout.Stretch
        End If
        myPlayer.DisplayClones.SetProperties(clickedPanel, props)

    End Sub

    ' Media has finished playing (1)
    Private Sub MyPlayer_MediaEndedNotice(sender As Object, e As EndedEventArgs)

        ' you can just stop any processes (and not starting new media) from the
        ' MediaEndedNotice eventhandler that is fired just before the MediaEnded event.

        'Select Case e.StopReason

        '    Case StopReason.Finished

        '    Case StopReason.AutoStop

        '    Case StopReason.UserStop

        'End Select

    End Sub

    ' Media has finished playing (2)
    Private Sub MyPlayer_MediaEnded(sender As Object, e As EndedEventArgs)

        DisposeMetadata()

        'Select Case e.StopReason

        '    Case StopReason.Finished
        '        ' play next media ...

        '    Case StopReason.AutoStop

        '    Case StopReason.UserStop

        'End Select

    End Sub

    ' Get media subtitles / media subtitle changed
    Private Sub MyPlayer_MediaSubtitleChanged(sender As Object, e As SubtitleEventArgs)
        ' In this example the subtitle's text is shown in a label on a display overlay.
        myOverlay.subtitlesLabel.Text = e.Subtitle
    End Sub

    ' Show an infolabel on the position slider of the player when scrolled
    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs)

        ' Get the position slider's x-coordinate of the current position (= thumb location)
        ' (myInfoLabel.AlignOffset has been set to 0, 7)
        Dim myInfoLabelLocation As Point = myPlayer.Sliders.ValueToPoint(TrackBar1, TrackBar1.Value)

        ' Show the infolabel
        myInfoLabel.Show(myPlayer.Position.FromStart.ToString().Substring(0, 8), TrackBar1, myInfoLabelLocation)

    End Sub

    ' Show an infolabel on the audio volume slider of the player when scrolled
    Private Sub TrackBar2_Scroll(sender As Object, e As EventArgs)

        ' Get the audio volume slider's x-coordinate of the current volume (= thumb location)
        ' (myInfoLabel.AlignOffset has been set to 0, 7)
        Dim myInfoLabelLocation As Point = myPlayer.Sliders.ValueToPoint(TrackBar2, TrackBar2.Value)

        ' Show the infolabel
        myInfoLabel.Show("Volume: " + (myPlayer.Audio.Volume).ToString("0.00"), TrackBar2, myInfoLabelLocation)

    End Sub

    ' Show an infolabel on the audio balance slider of the player when scrolled
    Private Sub TrackBar3_Scroll(sender As Object, e As EventArgs)

        ' Get the position slider's x-coordinate of the current position (= thumb location)
        ' (myInfoLabel.AlignOffset has been set to 0, 7)
        Dim myInfoLabelLocation As Point = myPlayer.Sliders.ValueToPoint(TrackBar3, TrackBar3.Value)

        ' Calculate balance display value
        Dim val As Double = myPlayer.Audio.Balance

        ' Set the text for the infolabel (using StringBuilder)
        myInfoLabelText.Length = 0
        If val = 0 Then
            myInfoLabelText.Append("Balance: Center")
        Else
            If val < 0 Then
                myInfoLabelText.Append("Balance: Left ").Append((-val).ToString("0.00"))
            Else
                myInfoLabelText.Append("Balance: Right ").Append(val.ToString("0.00"))
            End If
        End If

        ' Show the infolabel
        myInfoLabel.Show(myInfoLabelText.ToString, TrackBar3, myInfoLabelLocation)

    End Sub


#End Region

    ' **** Controls Handling **********************************************************************

#Region "Checkboxes"

    ' Set player display overlay
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If isInitializing Then Return

        If CheckBox1.Checked Then
            myPlayer.Overlay.Window = myOverlay
        Else
            myPlayer.Overlay.Window = Nothing
        End If
    End Sub

    ' Set player display clones overlay
    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If isInitializing Then Return
        myPlayer.DisplayClones.ShowOverlay = CheckBox2.Checked
    End Sub

    ' Set position slider live update
    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged
        If isInitializing Then Return
        myPlayer.Sliders.Position.LiveUpdate = CheckBox3.Checked
    End Sub

    ' Set taskbar progress indicator
    Private Sub TaskbarBox_CheckedChanged(sender As Object, e As EventArgs) Handles TaskbarBox.CheckedChanged
        If isInitializing Then Return
        If (TaskbarBox.Checked) Then
            myPlayer.TaskbarProgress.Add(Me)
        Else
            myPlayer.TaskbarProgress.Remove(Me)
        End If
    End Sub

    ' Set display window shapes
    Private Sub CheckBox4_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox4.CheckedChanged

        shapeStatus += 1
        If shapeStatus > 5 Then shapeStatus = 0

        Select Case shapeStatus

            Case 1 ' oval shaped video and overlay
                myPlayer.Display.SetShape(DisplayShape.Oval, True, True)
                Panel2.BackColor = Me.BackColor
                Panel3.BackColor = Me.BackColor

            Case 3 ' rounded rectangle shaped video and overlay
                myPlayer.Display.SetShape(DisplayShape.Rounded, True, True)
                Panel2.BackColor = Me.BackColor
                Panel3.BackColor = Me.BackColor

            Case 5 ' star shaped video and overlay
                myPlayer.Display.SetShape(DisplayShape.Star, True, True)
                Panel2.BackColor = Me.BackColor
                Panel3.BackColor = Me.BackColor

            Case Else
                ' normal shaped display and overlay
                myPlayer.Display.SetShape(DisplayShape.Normal)
                Panel2.BackColor = Color.FromArgb(32, 32, 32)
                Panel3.BackColor = Color.FromArgb(32, 32, 32)

        End Select

    End Sub

#End Region

#Region "Buttons"

    ' Play
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PlayMedia()
    End Sub

    ' Pause / Resume
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        PauseMedia()
    End Sub

    ' Stop
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        StopMedia()
    End Sub

    ' Quit
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Application.Exit()
    End Sub


#End Region

End Class
