'
' Created by SharpDevelop.
' User: Acer Valued Customer
' Date: 9/22/2008
' Time: 5:32 PM
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Partial Class MainForm
	Inherits System.Windows.Forms.Form
	
	''' <summary>
	''' Designer variable used to keep track of non-visual components.
	''' </summary>
	Private components As System.ComponentModel.IContainer
	
	''' <summary>
	''' Disposes resources used by the form.
	''' </summary>
	''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	Protected Overrides Sub Dispose(ByVal disposing As Boolean)
		If disposing Then
			If components IsNot Nothing Then
				components.Dispose()
            End If
            If _MediaPlayer IsNot Nothing Then
                _MediaPlayer.Dispose()
            End If
		End If
		MyBase.Dispose(disposing)
	End Sub
	
	''' <summary>
	''' This method is required for Windows Forms designer support.
	''' Do not change the method contents inside the source code editor. The Forms designer might
	''' not be able to load this method if it was changed manually.
	''' </summary>
	Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.ButtonPlay = New System.Windows.Forms.Button
        Me.ButtonStop = New System.Windows.Forms.Button
        Me.ListBoxMedia = New System.Windows.Forms.ListBox
        Me.ContextMenuStripListBox = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ContextToolStripMenuItemPlay = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItemSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ContextToolStripMenuItemDelete = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItemSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ContextToolStripMenuItemClearPlaylist = New System.Windows.Forms.ToolStripMenuItem
        Me.LabelArtist = New System.Windows.Forms.Label
        Me.LabelTotalTime = New System.Windows.Forms.Label
        Me.ButtonPause = New System.Windows.Forms.Button
        Me.TimerMain = New System.Windows.Forms.Timer(Me.components)
        Me.TimerTick = New System.Windows.Forms.Timer(Me.components)
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.ButtonOpen = New System.Windows.Forms.Button
        Me.ButtonSeekBeginning = New System.Windows.Forms.Button
        Me.ButtonSeekEnd = New System.Windows.Forms.Button
        Me.ButtonShuffle = New System.Windows.Forms.Button
        Me.ButtonSave = New System.Windows.Forms.Button
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItemOpenFiles = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItemSavePlaylistAs = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItemSeparator0 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripMenuItemExit = New System.Windows.Forms.ToolStripMenuItem
        Me.PlaylistToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItemPlay = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItemPause = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItemNextTrack = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItemPreviousTrack = New System.Windows.Forms.ToolStripMenuItem
        Me.StopToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItemSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripMenuItemShuffle = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItemSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripMenuItemClearPlaylist = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItemOptions = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItemChangePlaylistFolder = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItemLoadCurrentPlaylistOnStartup = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItemSaveCurrentPlaylistOnShutdown = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItemShuffleCurrentPlaylistOnStartup = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItemStartInNotificationArea = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItemStartWithWindows = New System.Windows.Forms.ToolStripMenuItem
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItemAbout = New System.Windows.Forms.ToolStripMenuItem
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabelInfo = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolStripProgressBarLoading = New System.Windows.Forms.ToolStripProgressBar
        Me.PictureBoxAlbumArt = New System.Windows.Forms.PictureBox
        Me.LabelSong = New System.Windows.Forms.Label
        Me.PictureBoxClose = New System.Windows.Forms.PictureBox
        Me.ColorSliderProgress = New VirtualSoftware.ColorSlider
        Me.ColorSliderVolume = New VirtualSoftware.ColorSlider
        Me.LabelVolume = New System.Windows.Forms.Label
        Me.PictureBoxMinimize = New System.Windows.Forms.PictureBox
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ContextMenuStripNotifyIcon = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItemShowForm = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItemPause2 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItemMute = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItemExit2 = New System.Windows.Forms.ToolStripMenuItem
        Me.LabelTitle1 = New System.Windows.Forms.Label
        Me.LabelTitle2 = New System.Windows.Forms.Label
        Me.LabelTitle3 = New System.Windows.Forms.Label
        Me.PictureBoxLogo = New System.Windows.Forms.PictureBox
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
        Me.ButtonMute = New System.Windows.Forms.Button
        Me.ContextMenuStripListBox.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.PictureBoxAlbumArt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxClose, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxMinimize, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStripNotifyIcon.SuspendLayout()
        CType(Me.PictureBoxLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ButtonPlay
        '
        Me.ButtonPlay.BackgroundImage = CType(resources.GetObject("ButtonPlay.BackgroundImage"), System.Drawing.Image)
        Me.ButtonPlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ButtonPlay.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ButtonPlay.Image = Global.MyMusicPlayer.My.Resources.Resources.Play
        Me.ButtonPlay.Location = New System.Drawing.Point(445, 395)
        Me.ButtonPlay.Name = "ButtonPlay"
        Me.ButtonPlay.Size = New System.Drawing.Size(54, 29)
        Me.ButtonPlay.TabIndex = 3
        Me.ButtonPlay.UseVisualStyleBackColor = True
        '
        'ButtonStop
        '
        Me.ButtonStop.BackgroundImage = CType(resources.GetObject("ButtonStop.BackgroundImage"), System.Drawing.Image)
        Me.ButtonStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ButtonStop.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ButtonStop.Image = Global.MyMusicPlayer.My.Resources.Resources.StopPlay
        Me.ButtonStop.Location = New System.Drawing.Point(517, 395)
        Me.ButtonStop.Name = "ButtonStop"
        Me.ButtonStop.Size = New System.Drawing.Size(54, 29)
        Me.ButtonStop.TabIndex = 4
        Me.ButtonStop.UseVisualStyleBackColor = True
        '
        'ListBoxMedia
        '
        Me.ListBoxMedia.AllowDrop = True
        Me.ListBoxMedia.BackColor = System.Drawing.Color.White
        Me.ListBoxMedia.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ListBoxMedia.FormattingEnabled = True
        Me.ListBoxMedia.Location = New System.Drawing.Point(445, 37)
        Me.ListBoxMedia.Name = "ListBoxMedia"
        Me.ListBoxMedia.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.ListBoxMedia.Size = New System.Drawing.Size(342, 342)
        Me.ListBoxMedia.TabIndex = 11
        '
        'ContextMenuStripListBox
        '
        Me.ContextMenuStripListBox.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ContextToolStripMenuItemPlay, Me.ToolStripMenuItemSeparator1, Me.ContextToolStripMenuItemDelete, Me.ToolStripMenuItemSeparator2, Me.ContextToolStripMenuItemClearPlaylist})
        Me.ContextMenuStripListBox.Name = "mnuSongOption"
        Me.ContextMenuStripListBox.Size = New System.Drawing.Size(211, 82)
        '
        'ContextToolStripMenuItemPlay
        '
        Me.ContextToolStripMenuItemPlay.Image = Global.MyMusicPlayer.My.Resources.Resources.Play
        Me.ContextToolStripMenuItemPlay.Name = "ContextToolStripMenuItemPlay"
        Me.ContextToolStripMenuItemPlay.Size = New System.Drawing.Size(210, 22)
        Me.ContextToolStripMenuItemPlay.Text = "Play"
        '
        'ToolStripMenuItemSeparator1
        '
        Me.ToolStripMenuItemSeparator1.Name = "ToolStripMenuItemSeparator1"
        Me.ToolStripMenuItemSeparator1.Size = New System.Drawing.Size(207, 6)
        '
        'ContextToolStripMenuItemDelete
        '
        Me.ContextToolStripMenuItemDelete.Name = "ContextToolStripMenuItemDelete"
        Me.ContextToolStripMenuItemDelete.ShortcutKeys = System.Windows.Forms.Keys.Delete
        Me.ContextToolStripMenuItemDelete.Size = New System.Drawing.Size(210, 22)
        Me.ContextToolStripMenuItemDelete.Text = "Remove from Playlist"
        '
        'ToolStripMenuItemSeparator2
        '
        Me.ToolStripMenuItemSeparator2.Name = "ToolStripMenuItemSeparator2"
        Me.ToolStripMenuItemSeparator2.Size = New System.Drawing.Size(207, 6)
        '
        'ContextToolStripMenuItemClearPlaylist
        '
        Me.ContextToolStripMenuItemClearPlaylist.Name = "ContextToolStripMenuItemClearPlaylist"
        Me.ContextToolStripMenuItemClearPlaylist.Size = New System.Drawing.Size(210, 22)
        Me.ContextToolStripMenuItemClearPlaylist.Text = "Clear Playlist"
        '
        'LabelArtist
        '
        Me.LabelArtist.BackColor = System.Drawing.Color.Transparent
        Me.LabelArtist.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelArtist.Location = New System.Drawing.Point(14, 382)
        Me.LabelArtist.Name = "LabelArtist"
        Me.LabelArtist.Size = New System.Drawing.Size(342, 17)
        Me.LabelArtist.TabIndex = 0
        Me.LabelArtist.Text = "Artist:"
        Me.LabelArtist.UseMnemonic = False
        '
        'LabelTotalTime
        '
        Me.LabelTotalTime.BackColor = System.Drawing.Color.Transparent
        Me.LabelTotalTime.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTotalTime.Location = New System.Drawing.Point(14, 416)
        Me.LabelTotalTime.Name = "LabelTotalTime"
        Me.LabelTotalTime.Size = New System.Drawing.Size(161, 17)
        Me.LabelTotalTime.TabIndex = 2
        Me.LabelTotalTime.Text = "Time:"
        '
        'ButtonPause
        '
        Me.ButtonPause.BackgroundImage = CType(resources.GetObject("ButtonPause.BackgroundImage"), System.Drawing.Image)
        Me.ButtonPause.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ButtonPause.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ButtonPause.Image = Global.MyMusicPlayer.My.Resources.Resources.PausePlay
        Me.ButtonPause.Location = New System.Drawing.Point(589, 395)
        Me.ButtonPause.Name = "ButtonPause"
        Me.ButtonPause.Size = New System.Drawing.Size(54, 29)
        Me.ButtonPause.TabIndex = 5
        Me.ButtonPause.UseVisualStyleBackColor = True
        '
        'TimerMain
        '
        Me.TimerMain.Interval = 1000
        '
        'TimerTick
        '
        Me.TimerTick.Interval = 1000
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.Multiselect = True
        '
        'ButtonOpen
        '
        Me.ButtonOpen.BackgroundImage = CType(resources.GetObject("ButtonOpen.BackgroundImage"), System.Drawing.Image)
        Me.ButtonOpen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ButtonOpen.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ButtonOpen.Location = New System.Drawing.Point(368, 245)
        Me.ButtonOpen.Name = "ButtonOpen"
        Me.ButtonOpen.Size = New System.Drawing.Size(64, 29)
        Me.ButtonOpen.TabIndex = 10
        Me.ButtonOpen.Text = "&Open"
        Me.ButtonOpen.UseVisualStyleBackColor = True
        '
        'ButtonSeekBeginning
        '
        Me.ButtonSeekBeginning.BackgroundImage = CType(resources.GetObject("ButtonSeekBeginning.BackgroundImage"), System.Drawing.Image)
        Me.ButtonSeekBeginning.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ButtonSeekBeginning.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ButtonSeekBeginning.Image = Global.MyMusicPlayer.My.Resources.Resources.SeekBeginning
        Me.ButtonSeekBeginning.ImageAlign = System.Drawing.ContentAlignment.TopRight
        Me.ButtonSeekBeginning.Location = New System.Drawing.Point(661, 395)
        Me.ButtonSeekBeginning.Name = "ButtonSeekBeginning"
        Me.ButtonSeekBeginning.Size = New System.Drawing.Size(54, 29)
        Me.ButtonSeekBeginning.TabIndex = 6
        Me.ButtonSeekBeginning.UseVisualStyleBackColor = True
        '
        'ButtonSeekEnd
        '
        Me.ButtonSeekEnd.BackgroundImage = CType(resources.GetObject("ButtonSeekEnd.BackgroundImage"), System.Drawing.Image)
        Me.ButtonSeekEnd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ButtonSeekEnd.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ButtonSeekEnd.Image = Global.MyMusicPlayer.My.Resources.Resources.SeekEnd
        Me.ButtonSeekEnd.ImageAlign = System.Drawing.ContentAlignment.TopRight
        Me.ButtonSeekEnd.Location = New System.Drawing.Point(733, 395)
        Me.ButtonSeekEnd.Name = "ButtonSeekEnd"
        Me.ButtonSeekEnd.Size = New System.Drawing.Size(54, 29)
        Me.ButtonSeekEnd.TabIndex = 7
        Me.ButtonSeekEnd.UseVisualStyleBackColor = True
        '
        'ButtonShuffle
        '
        Me.ButtonShuffle.BackgroundImage = Global.MyMusicPlayer.My.Resources.Resources.GrayGradient
        Me.ButtonShuffle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ButtonShuffle.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ButtonShuffle.Location = New System.Drawing.Point(368, 315)
        Me.ButtonShuffle.Name = "ButtonShuffle"
        Me.ButtonShuffle.Size = New System.Drawing.Size(64, 29)
        Me.ButtonShuffle.TabIndex = 8
        Me.ButtonShuffle.Text = "&Shuffle"
        Me.ButtonShuffle.UseVisualStyleBackColor = True
        '
        'ButtonSave
        '
        Me.ButtonSave.BackgroundImage = CType(resources.GetObject("ButtonSave.BackgroundImage"), System.Drawing.Image)
        Me.ButtonSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ButtonSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ButtonSave.Location = New System.Drawing.Point(368, 280)
        Me.ButtonSave.Name = "ButtonSave"
        Me.ButtonSave.Size = New System.Drawing.Size(64, 29)
        Me.ButtonSave.TabIndex = 15
        Me.ButtonSave.Text = "&Save"
        Me.ButtonSave.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackgroundImage = Global.MyMusicPlayer.My.Resources.Resources.GrayGradient
        Me.MenuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.PlaylistToolStripMenuItem, Me.ToolStripMenuItemOptions, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(800, 24)
        Me.MenuStrip1.TabIndex = 16
        Me.MenuStrip1.Text = "menuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemOpenFiles, Me.ToolStripMenuItemSavePlaylistAs, Me.ToolStripMenuItemSeparator0, Me.ToolStripMenuItemExit})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'ToolStripMenuItemOpenFiles
        '
        Me.ToolStripMenuItemOpenFiles.Name = "ToolStripMenuItemOpenFiles"
        Me.ToolStripMenuItemOpenFiles.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.ToolStripMenuItemOpenFiles.Size = New System.Drawing.Size(203, 22)
        Me.ToolStripMenuItemOpenFiles.Text = "&Open Files"
        '
        'ToolStripMenuItemSavePlaylistAs
        '
        Me.ToolStripMenuItemSavePlaylistAs.Name = "ToolStripMenuItemSavePlaylistAs"
        Me.ToolStripMenuItemSavePlaylistAs.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.ToolStripMenuItemSavePlaylistAs.Size = New System.Drawing.Size(203, 22)
        Me.ToolStripMenuItemSavePlaylistAs.Text = "&Save Playlist As..."
        '
        'ToolStripMenuItemSeparator0
        '
        Me.ToolStripMenuItemSeparator0.Name = "ToolStripMenuItemSeparator0"
        Me.ToolStripMenuItemSeparator0.Size = New System.Drawing.Size(200, 6)
        '
        'ToolStripMenuItemExit
        '
        Me.ToolStripMenuItemExit.Name = "ToolStripMenuItemExit"
        Me.ToolStripMenuItemExit.Size = New System.Drawing.Size(203, 22)
        Me.ToolStripMenuItemExit.Text = "E&xit"
        '
        'PlaylistToolStripMenuItem
        '
        Me.PlaylistToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemPlay, Me.ToolStripMenuItemPause, Me.ToolStripMenuItemNextTrack, Me.ToolStripMenuItemPreviousTrack, Me.StopToolStripMenuItem, Me.ToolStripMenuItemSeparator3, Me.ToolStripMenuItemShuffle, Me.ToolStripMenuItemSeparator4, Me.ToolStripMenuItemClearPlaylist})
        Me.PlaylistToolStripMenuItem.Name = "PlaylistToolStripMenuItem"
        Me.PlaylistToolStripMenuItem.Size = New System.Drawing.Size(56, 20)
        Me.PlaylistToolStripMenuItem.Text = "Play&list"
        '
        'ToolStripMenuItemPlay
        '
        Me.ToolStripMenuItemPlay.Image = Global.MyMusicPlayer.My.Resources.Resources.Play
        Me.ToolStripMenuItemPlay.Name = "ToolStripMenuItemPlay"
        Me.ToolStripMenuItemPlay.Size = New System.Drawing.Size(151, 22)
        Me.ToolStripMenuItemPlay.Text = "&Play"
        '
        'ToolStripMenuItemPause
        '
        Me.ToolStripMenuItemPause.Image = Global.MyMusicPlayer.My.Resources.Resources.PausePlay
        Me.ToolStripMenuItemPause.Name = "ToolStripMenuItemPause"
        Me.ToolStripMenuItemPause.Size = New System.Drawing.Size(151, 22)
        Me.ToolStripMenuItemPause.Text = "P&ause"
        '
        'ToolStripMenuItemNextTrack
        '
        Me.ToolStripMenuItemNextTrack.Name = "ToolStripMenuItemNextTrack"
        Me.ToolStripMenuItemNextTrack.Size = New System.Drawing.Size(151, 22)
        Me.ToolStripMenuItemNextTrack.Text = "&Next Track"
        '
        'ToolStripMenuItemPreviousTrack
        '
        Me.ToolStripMenuItemPreviousTrack.Name = "ToolStripMenuItemPreviousTrack"
        Me.ToolStripMenuItemPreviousTrack.Size = New System.Drawing.Size(151, 22)
        Me.ToolStripMenuItemPreviousTrack.Text = "Previous &Track"
        '
        'StopToolStripMenuItem
        '
        Me.StopToolStripMenuItem.Image = Global.MyMusicPlayer.My.Resources.Resources.StopPlay
        Me.StopToolStripMenuItem.Name = "StopToolStripMenuItem"
        Me.StopToolStripMenuItem.Size = New System.Drawing.Size(151, 22)
        Me.StopToolStripMenuItem.Text = "&Stop"
        '
        'ToolStripMenuItemSeparator3
        '
        Me.ToolStripMenuItemSeparator3.Name = "ToolStripMenuItemSeparator3"
        Me.ToolStripMenuItemSeparator3.Size = New System.Drawing.Size(148, 6)
        '
        'ToolStripMenuItemShuffle
        '
        Me.ToolStripMenuItemShuffle.Name = "ToolStripMenuItemShuffle"
        Me.ToolStripMenuItemShuffle.Size = New System.Drawing.Size(151, 22)
        Me.ToolStripMenuItemShuffle.Text = "S&huffle"
        '
        'ToolStripMenuItemSeparator4
        '
        Me.ToolStripMenuItemSeparator4.Name = "ToolStripMenuItemSeparator4"
        Me.ToolStripMenuItemSeparator4.Size = New System.Drawing.Size(148, 6)
        '
        'ToolStripMenuItemClearPlaylist
        '
        Me.ToolStripMenuItemClearPlaylist.Name = "ToolStripMenuItemClearPlaylist"
        Me.ToolStripMenuItemClearPlaylist.Size = New System.Drawing.Size(151, 22)
        Me.ToolStripMenuItemClearPlaylist.Text = "&Clear Playlist"
        '
        'ToolStripMenuItemOptions
        '
        Me.ToolStripMenuItemOptions.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemChangePlaylistFolder, Me.ToolStripMenuItemLoadCurrentPlaylistOnStartup, Me.ToolStripMenuItemSaveCurrentPlaylistOnShutdown, Me.ToolStripMenuItemShuffleCurrentPlaylistOnStartup, Me.ToolStripMenuItemStartInNotificationArea, Me.ToolStripMenuItemStartWithWindows})
        Me.ToolStripMenuItemOptions.Name = "ToolStripMenuItemOptions"
        Me.ToolStripMenuItemOptions.Size = New System.Drawing.Size(61, 20)
        Me.ToolStripMenuItemOptions.Text = "&Options"
        '
        'ToolStripMenuItemChangePlaylistFolder
        '
        Me.ToolStripMenuItemChangePlaylistFolder.Name = "ToolStripMenuItemChangePlaylistFolder"
        Me.ToolStripMenuItemChangePlaylistFolder.Size = New System.Drawing.Size(255, 22)
        Me.ToolStripMenuItemChangePlaylistFolder.Text = "&Change Playlist Folder"
        '
        'ToolStripMenuItemLoadCurrentPlaylistOnStartup
        '
        Me.ToolStripMenuItemLoadCurrentPlaylistOnStartup.Name = "ToolStripMenuItemLoadCurrentPlaylistOnStartup"
        Me.ToolStripMenuItemLoadCurrentPlaylistOnStartup.Size = New System.Drawing.Size(255, 22)
        Me.ToolStripMenuItemLoadCurrentPlaylistOnStartup.Text = "&Load Current Playlist on Startup"
        '
        'ToolStripMenuItemSaveCurrentPlaylistOnShutdown
        '
        Me.ToolStripMenuItemSaveCurrentPlaylistOnShutdown.Name = "ToolStripMenuItemSaveCurrentPlaylistOnShutdown"
        Me.ToolStripMenuItemSaveCurrentPlaylistOnShutdown.Size = New System.Drawing.Size(255, 22)
        Me.ToolStripMenuItemSaveCurrentPlaylistOnShutdown.Text = "&Save Current Playlist on Shutdown"
        '
        'ToolStripMenuItemShuffleCurrentPlaylistOnStartup
        '
        Me.ToolStripMenuItemShuffleCurrentPlaylistOnStartup.Name = "ToolStripMenuItemShuffleCurrentPlaylistOnStartup"
        Me.ToolStripMenuItemShuffleCurrentPlaylistOnStartup.Size = New System.Drawing.Size(255, 22)
        Me.ToolStripMenuItemShuffleCurrentPlaylistOnStartup.Text = "Shuffle &Current Playlist on Startup"
        '
        'ToolStripMenuItemStartInNotificationArea
        '
        Me.ToolStripMenuItemStartInNotificationArea.Name = "ToolStripMenuItemStartInNotificationArea"
        Me.ToolStripMenuItemStartInNotificationArea.Size = New System.Drawing.Size(255, 22)
        Me.ToolStripMenuItemStartInNotificationArea.Text = "Start in Notification Area"
        '
        'ToolStripMenuItemStartWithWindows
        '
        Me.ToolStripMenuItemStartWithWindows.Name = "ToolStripMenuItemStartWithWindows"
        Me.ToolStripMenuItemStartWithWindows.Size = New System.Drawing.Size(255, 22)
        Me.ToolStripMenuItemStartWithWindows.Text = "Start with Windows"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemAbout})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "&Help"
        '
        'ToolStripMenuItemAbout
        '
        Me.ToolStripMenuItemAbout.Name = "ToolStripMenuItemAbout"
        Me.ToolStripMenuItemAbout.Size = New System.Drawing.Size(116, 22)
        Me.ToolStripMenuItemAbout.Text = "About..."
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackgroundImage = Global.MyMusicPlayer.My.Resources.Resources.GrayGradient
        Me.StatusStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabelInfo, Me.ToolStripProgressBarLoading})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 478)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(800, 22)
        Me.StatusStrip1.TabIndex = 17
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabelInfo
        '
        Me.ToolStripStatusLabelInfo.AutoSize = False
        Me.ToolStripStatusLabelInfo.Name = "ToolStripStatusLabelInfo"
        Me.ToolStripStatusLabelInfo.Size = New System.Drawing.Size(652, 17)
        Me.ToolStripStatusLabelInfo.Text = "Songs:"
        Me.ToolStripStatusLabelInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripProgressBarLoading
        '
        Me.ToolStripProgressBarLoading.Name = "ToolStripProgressBarLoading"
        Me.ToolStripProgressBarLoading.Size = New System.Drawing.Size(100, 16)
        Me.ToolStripProgressBarLoading.Visible = False
        '
        'PictureBoxAlbumArt
        '
        Me.PictureBoxAlbumArt.BackColor = System.Drawing.Color.White
        Me.PictureBoxAlbumArt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBoxAlbumArt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBoxAlbumArt.Location = New System.Drawing.Point(14, 37)
        Me.PictureBoxAlbumArt.Name = "PictureBoxAlbumArt"
        Me.PictureBoxAlbumArt.Size = New System.Drawing.Size(342, 342)
        Me.PictureBoxAlbumArt.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBoxAlbumArt.TabIndex = 19
        Me.PictureBoxAlbumArt.TabStop = False
        '
        'LabelSong
        '
        Me.LabelSong.BackColor = System.Drawing.Color.Transparent
        Me.LabelSong.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelSong.Location = New System.Drawing.Point(14, 399)
        Me.LabelSong.Name = "LabelSong"
        Me.LabelSong.Size = New System.Drawing.Size(342, 17)
        Me.LabelSong.TabIndex = 20
        Me.LabelSong.Text = "Track:"
        Me.LabelSong.UseMnemonic = False
        '
        'PictureBoxClose
        '
        Me.PictureBoxClose.Image = Global.MyMusicPlayer.My.Resources.Resources.CloseMouse
        Me.PictureBoxClose.Location = New System.Drawing.Point(778, 3)
        Me.PictureBoxClose.Name = "PictureBoxClose"
        Me.PictureBoxClose.Size = New System.Drawing.Size(16, 16)
        Me.PictureBoxClose.TabIndex = 21
        Me.PictureBoxClose.TabStop = False
        '
        'ColorSliderProgress
        '
        Me.ColorSliderProgress.BackColor = System.Drawing.Color.Transparent
        Me.ColorSliderProgress.BorderRoundRectSize = New System.Drawing.Size(10, 10)
        Me.ColorSliderProgress.LargeChange = CType(5UI, UInteger)
        Me.ColorSliderProgress.Location = New System.Drawing.Point(14, 444)
        Me.ColorSliderProgress.Name = "ColorSliderProgress"
        Me.ColorSliderProgress.Size = New System.Drawing.Size(773, 17)
        Me.ColorSliderProgress.SmallChange = CType(1UI, UInteger)
        Me.ColorSliderProgress.TabIndex = 22
        Me.ColorSliderProgress.ThumbRoundRectSize = New System.Drawing.Size(8, 8)
        Me.ColorSliderProgress.ThumbSize = 25
        Me.ColorSliderProgress.Value = 0
        '
        'ColorSliderVolume
        '
        Me.ColorSliderVolume.BackColor = System.Drawing.Color.Transparent
        Me.ColorSliderVolume.BorderRoundRectSize = New System.Drawing.Size(10, 10)
        Me.ColorSliderVolume.LargeChange = CType(5UI, UInteger)
        Me.ColorSliderVolume.Location = New System.Drawing.Point(370, 401)
        Me.ColorSliderVolume.Maximum = 1000
        Me.ColorSliderVolume.Name = "ColorSliderVolume"
        Me.ColorSliderVolume.Size = New System.Drawing.Size(64, 17)
        Me.ColorSliderVolume.SmallChange = CType(1UI, UInteger)
        Me.ColorSliderVolume.TabIndex = 23
        Me.ColorSliderVolume.ThumbRoundRectSize = New System.Drawing.Size(8, 8)
        Me.ColorSliderVolume.ThumbSize = 25
        Me.ColorSliderVolume.Value = 100
        '
        'LabelVolume
        '
        Me.LabelVolume.AutoSize = True
        Me.LabelVolume.BackColor = System.Drawing.Color.Transparent
        Me.LabelVolume.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelVolume.Location = New System.Drawing.Point(376, 421)
        Me.LabelVolume.Name = "LabelVolume"
        Me.LabelVolume.Size = New System.Drawing.Size(48, 15)
        Me.LabelVolume.TabIndex = 24
        Me.LabelVolume.Text = "Volume"
        '
        'PictureBoxMinimize
        '
        Me.PictureBoxMinimize.Image = Global.MyMusicPlayer.My.Resources.Resources.MinimizeMouse
        Me.PictureBoxMinimize.Location = New System.Drawing.Point(756, 3)
        Me.PictureBoxMinimize.Name = "PictureBoxMinimize"
        Me.PictureBoxMinimize.Size = New System.Drawing.Size(16, 16)
        Me.PictureBoxMinimize.TabIndex = 26
        Me.PictureBoxMinimize.TabStop = False
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.ContextMenuStrip = Me.ContextMenuStripNotifyIcon
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "My Music Player"
        '
        'ContextMenuStripNotifyIcon
        '
        Me.ContextMenuStripNotifyIcon.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemShowForm, Me.ToolStripMenuItemPause2, Me.ToolStripMenuItemMute, Me.ToolStripMenuItemExit2})
        Me.ContextMenuStripNotifyIcon.Name = "ContextMenuStripNotifyIcon"
        Me.ContextMenuStripNotifyIcon.Size = New System.Drawing.Size(135, 92)
        '
        'ToolStripMenuItemShowForm
        '
        Me.ToolStripMenuItemShowForm.Name = "ToolStripMenuItemShowForm"
        Me.ToolStripMenuItemShowForm.Size = New System.Drawing.Size(134, 22)
        Me.ToolStripMenuItemShowForm.Text = "Show Form"
        '
        'ToolStripMenuItemPause2
        '
        Me.ToolStripMenuItemPause2.Image = Global.MyMusicPlayer.My.Resources.Resources.PausePlay
        Me.ToolStripMenuItemPause2.Name = "ToolStripMenuItemPause2"
        Me.ToolStripMenuItemPause2.Size = New System.Drawing.Size(134, 22)
        Me.ToolStripMenuItemPause2.Text = "Pause"
        '
        'ToolStripMenuItemMute
        '
        Me.ToolStripMenuItemMute.Image = Global.MyMusicPlayer.My.Resources.Resources.UnMute
        Me.ToolStripMenuItemMute.Name = "ToolStripMenuItemMute"
        Me.ToolStripMenuItemMute.Size = New System.Drawing.Size(134, 22)
        Me.ToolStripMenuItemMute.Text = "Mute"
        '
        'ToolStripMenuItemExit2
        '
        Me.ToolStripMenuItemExit2.Name = "ToolStripMenuItemExit2"
        Me.ToolStripMenuItemExit2.Size = New System.Drawing.Size(134, 22)
        Me.ToolStripMenuItemExit2.Text = "Exit"
        '
        'LabelTitle1
        '
        Me.LabelTitle1.AutoSize = True
        Me.LabelTitle1.BackColor = System.Drawing.Color.Transparent
        Me.LabelTitle1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTitle1.Location = New System.Drawing.Point(383, 37)
        Me.LabelTitle1.Name = "LabelTitle1"
        Me.LabelTitle1.Size = New System.Drawing.Size(34, 21)
        Me.LabelTitle1.TabIndex = 28
        Me.LabelTitle1.Text = "My"
        '
        'LabelTitle2
        '
        Me.LabelTitle2.AutoSize = True
        Me.LabelTitle2.BackColor = System.Drawing.Color.Transparent
        Me.LabelTitle2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTitle2.Location = New System.Drawing.Point(373, 58)
        Me.LabelTitle2.Name = "LabelTitle2"
        Me.LabelTitle2.Size = New System.Drawing.Size(55, 21)
        Me.LabelTitle2.TabIndex = 29
        Me.LabelTitle2.Text = "Music"
        '
        'LabelTitle3
        '
        Me.LabelTitle3.AutoSize = True
        Me.LabelTitle3.BackColor = System.Drawing.Color.Transparent
        Me.LabelTitle3.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTitle3.Location = New System.Drawing.Point(371, 79)
        Me.LabelTitle3.Name = "LabelTitle3"
        Me.LabelTitle3.Size = New System.Drawing.Size(58, 21)
        Me.LabelTitle3.TabIndex = 30
        Me.LabelTitle3.Text = "Player"
        '
        'PictureBoxLogo
        '
        Me.PictureBoxLogo.BackColor = System.Drawing.Color.Transparent
        Me.PictureBoxLogo.Image = Global.MyMusicPlayer.My.Resources.Resources.MyMusicPlayer
        Me.PictureBoxLogo.Location = New System.Drawing.Point(376, 114)
        Me.PictureBoxLogo.Name = "PictureBoxLogo"
        Me.PictureBoxLogo.Size = New System.Drawing.Size(48, 48)
        Me.PictureBoxLogo.TabIndex = 32
        Me.PictureBoxLogo.TabStop = False
        '
        'ButtonMute
        '
        Me.ButtonMute.BackgroundImage = Global.MyMusicPlayer.My.Resources.Resources.GrayGradient
        Me.ButtonMute.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ButtonMute.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ButtonMute.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonMute.Location = New System.Drawing.Point(368, 350)
        Me.ButtonMute.Name = "ButtonMute"
        Me.ButtonMute.Size = New System.Drawing.Size(64, 29)
        Me.ButtonMute.TabIndex = 33
        Me.ButtonMute.Text = "&Mute"
        Me.ButtonMute.UseVisualStyleBackColor = True
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackgroundImage = Global.MyMusicPlayer.My.Resources.Resources.GrayGradient
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(800, 500)
        Me.Controls.Add(Me.ButtonMute)
        Me.Controls.Add(Me.PictureBoxLogo)
        Me.Controls.Add(Me.LabelTitle3)
        Me.Controls.Add(Me.LabelTitle2)
        Me.Controls.Add(Me.LabelTitle1)
        Me.Controls.Add(Me.PictureBoxMinimize)
        Me.Controls.Add(Me.LabelVolume)
        Me.Controls.Add(Me.ColorSliderProgress)
        Me.Controls.Add(Me.PictureBoxClose)
        Me.Controls.Add(Me.LabelSong)
        Me.Controls.Add(Me.PictureBoxAlbumArt)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ColorSliderVolume)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.ButtonSeekEnd)
        Me.Controls.Add(Me.ButtonShuffle)
        Me.Controls.Add(Me.ButtonSave)
        Me.Controls.Add(Me.ButtonOpen)
        Me.Controls.Add(Me.ButtonSeekBeginning)
        Me.Controls.Add(Me.ButtonPause)
        Me.Controls.Add(Me.ListBoxMedia)
        Me.Controls.Add(Me.ButtonPlay)
        Me.Controls.Add(Me.LabelTotalTime)
        Me.Controls.Add(Me.ButtonStop)
        Me.Controls.Add(Me.LabelArtist)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "My Music Player"
        Me.ContextMenuStripListBox.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.PictureBoxAlbumArt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxClose, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxMinimize, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStripNotifyIcon.ResumeLayout(False)
        CType(Me.PictureBoxLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents ToolStripMenuItemPreviousTrack As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ToolStripMenuItemNextTrack As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ToolStripMenuItemPause As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ToolStripMenuItemSeparator3 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents StopToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ToolStripMenuItemShuffle As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ToolStripMenuItemAbout As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ToolStripMenuItemClearPlaylist As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ToolStripMenuItemSeparator4 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents ToolStripMenuItemPlay As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents PlaylistToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ToolStripMenuItemExit As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ToolStripMenuItemSeparator0 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents ToolStripMenuItemSavePlaylistAs As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ToolStripMenuItemOpenFiles As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Private WithEvents ContextToolStripMenuItemClearPlaylist As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ToolStripMenuItemSeparator2 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents ToolStripMenuItemSeparator1 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents ContextToolStripMenuItemPlay As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ContextToolStripMenuItemDelete As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ContextMenuStripListBox As System.Windows.Forms.ContextMenuStrip
    Private WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Private WithEvents ButtonSave As System.Windows.Forms.Button
    Private WithEvents ButtonShuffle As System.Windows.Forms.Button
    Private WithEvents ButtonSeekEnd As System.Windows.Forms.Button
    Private WithEvents ButtonSeekBeginning As System.Windows.Forms.Button
    Private WithEvents ListBoxMedia As System.Windows.Forms.ListBox
    Private WithEvents ButtonOpen As System.Windows.Forms.Button
    Private WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Private WithEvents TimerTick As System.Windows.Forms.Timer
    Private WithEvents TimerMain As System.Windows.Forms.Timer
    Private WithEvents LabelTotalTime As System.Windows.Forms.Label
    Private WithEvents ButtonPause As System.Windows.Forms.Button
    Private WithEvents LabelArtist As System.Windows.Forms.Label
    Private WithEvents ButtonStop As System.Windows.Forms.Button
    Private WithEvents ButtonPlay As System.Windows.Forms.Button
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabelInfo As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents PictureBoxAlbumArt As System.Windows.Forms.PictureBox
    Private WithEvents LabelSong As System.Windows.Forms.Label
    Friend WithEvents PictureBoxClose As System.Windows.Forms.PictureBox
    Private WithEvents ColorSliderProgress As VirtualSoftware.ColorSlider
    Private WithEvents ColorSliderVolume As VirtualSoftware.ColorSlider
    Private WithEvents LabelVolume As System.Windows.Forms.Label
    Friend WithEvents PictureBoxMinimize As System.Windows.Forms.PictureBox
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents ContextMenuStripNotifyIcon As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItemShowForm As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemMute As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemExit2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LabelTitle1 As System.Windows.Forms.Label
    Friend WithEvents LabelTitle2 As System.Windows.Forms.Label
    Friend WithEvents LabelTitle3 As System.Windows.Forms.Label
    Friend WithEvents PictureBoxLogo As System.Windows.Forms.PictureBox
    Friend WithEvents ToolStripProgressBarLoading As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents ToolStripMenuItemOptions As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemChangePlaylistFolder As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemLoadCurrentPlaylistOnStartup As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemSaveCurrentPlaylistOnShutdown As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemStartInNotificationArea As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents ToolStripMenuItemShuffleCurrentPlaylistOnStartup As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemStartWithWindows As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemPause2 As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ButtonMute As System.Windows.Forms.Button

End Class
