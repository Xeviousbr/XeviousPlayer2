using System.ComponentModel;
using System.Windows.Forms;

namespace PVSPlayerExample
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.leftFramePanel = new System.Windows.Forms.Panel();
            this.speedPanel = new System.Windows.Forms.Panel();
            this.sliderMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.sliderMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.sliderMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.sliderMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.sliderMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.sliderMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.repeatPanel = new System.Windows.Forms.Panel();
            this.repeatMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.repeatOneMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.repeatAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator18 = new System.Windows.Forms.ToolStripSeparator();
            this.shuffleMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator19 = new System.Windows.Forms.ToolStripSeparator();
            this.repeatOffMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.repeatMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopTimeTextBox = new System.Windows.Forms.MaskedTextBox();
            this.startTimeTextBox = new System.Windows.Forms.MaskedTextBox();
            this.stopTimeNextTextBox = new System.Windows.Forms.MaskedTextBox();
            this.startTimeNextTextBox = new System.Windows.Forms.MaskedTextBox();
            this.displayModePanel = new System.Windows.Forms.Panel();
            this.videoTracksLabel = new System.Windows.Forms.Label();
            this.displayOverlayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.overlayModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.videoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.overlayHoldMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.messageMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scribbleMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator24 = new System.Windows.Forms.ToolStripSeparator();
            this.tilesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bouncingMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator23 = new System.Windows.Forms.ToolStripSeparator();
            this.PiPMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subtitlesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator25 = new System.Windows.Forms.ToolStripSeparator();
            this.zoomSelectMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.videoWallMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator21 = new System.Windows.Forms.ToolStripSeparator();
            this.MP3CoverMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MP3KaraokeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator22 = new System.Windows.Forms.ToolStripSeparator();
            this.bigTimeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusInfoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.overlayOffMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayOverlayMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fullScreenModeMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.fullScreenFormMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fullScreenFormAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fullScreenParentMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fullScreenParentAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fullScreenDisplayMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fullScreenDisplayAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.fullScreenOffMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fullScreenModeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayModeMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.displayModeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playPanel = new System.Windows.Forms.Panel();
            this.playMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.playListMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newPlayListMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.openPlayListMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addPlayListMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.savePlayListMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.webcamsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noWebcamsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
            this.addMediaFilesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addMediaURLMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.playDisplayMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.displayPanel = new System.Windows.Forms.Panel();
            this.displayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.previousMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pauseMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.audioTracksMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.audioTracks = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.videoTracksMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.videoTracks = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tracksMenuSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.displayShapeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arrowDownShapeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arrowLeftShapeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arrowRightShapeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arrowUpShapeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.barsShapeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.beamsShapeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.circleShapeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crossShapeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.diamondShapeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.frameShapeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.heartShapeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hexagonShapeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ovalShapeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rectangleShapeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ringShapeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.roundedShapeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.squareShapeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.starShapeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tilesShapeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.triangleDownMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.triangleLeftMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.triangleRightMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.triangleUpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator34 = new System.Windows.Forms.ToolStripSeparator();
            this.useVideoBoundsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setOverlayShapeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator38 = new System.Windows.Forms.ToolStripSeparator();
            this.normalShapeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayClonesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addCloneMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator36 = new System.Windows.Forms.ToolStripSeparator();
            this.showOverlayMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshRateMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fps01MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fps02MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fps05MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fps10MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fps15MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fps20MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fps25MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fps30MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fps40MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fps50MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fps60MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator20 = new System.Windows.Forms.ToolStripSeparator();
            this.removeAllClonesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator39 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.overlayMenuMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
            this.videoSizeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomVideoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomInMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomOutToolMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveVideoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveUpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveDownMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator32 = new System.Windows.Forms.ToolStripSeparator();
            this.moveLeftMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveRightMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stretchVideoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stretchHeightMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shrinkHeightMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator33 = new System.Windows.Forms.ToolStripSeparator();
            this.stretchWidthMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shrinkWidthMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.videoColorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator41 = new System.Windows.Forms.ToolStripSeparator();
            this.screencopyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.screenCopyMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyModeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyModeMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.videoCopyModeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayCopyModeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parentCopyModeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formCopyModeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.screenCopyModeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.openCopyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openWithCopyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.clearCopyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator17 = new System.Windows.Forms.ToolStripSeparator();
            this.systemMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.systemDisplayMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator26 = new System.Windows.Forms.ToolStripSeparator();
            this.systemSoundMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.systemMixerMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator37 = new System.Windows.Forms.ToolStripSeparator();
            this.channelMixerMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preferencesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.quitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.balanceDialLabel = new System.Windows.Forms.Label();
            this.volumeDialLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.channelCountLabel = new System.Windows.Forms.Label();
            this.audioDeviceMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.audioDevicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.audioMixerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.channelVolumesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator31 = new System.Windows.Forms.ToolStripSeparator();
            this.systemDefaultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.positionSliderMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.sliderAlwaysVisibleMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sliderShowsProgressMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator40 = new System.Windows.Forms.ToolStripSeparator();
            this.slidersShowInfoLabelsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sliderMousePreviewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator35 = new System.Windows.Forms.ToolStripSeparator();
            this.sliderSeekLiveUpdateMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sliderSeekSilentMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.mouseWheelMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sec12MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sec1MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sec5MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sec10MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sec15MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sec30MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sec60MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator30 = new System.Windows.Forms.ToolStripSeparator();
            this.secOffMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator27 = new System.Windows.Forms.ToolStripSeparator();
            this.chaptersAppleMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noChaptersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chaptersNeroMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noChaptersToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator42 = new System.Windows.Forms.ToolStripSeparator();
            this.markStartPositionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.markEndPositionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goToStartMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.markPositionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mark1_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mark2_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mark3_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mark4_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goToMarkMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goToMark1_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goToMark2_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goToMark3_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goToMark4_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayParentPanel = new System.Windows.Forms.Panel();
            this.rightFramePanel = new System.Windows.Forms.Panel();
            this.shuttlePanel = new System.Windows.Forms.Panel();
            this.screencopyPanel = new System.Windows.Forms.Panel();
            this.zoomPanel = new System.Windows.Forms.Panel();
            this.audioPanel = new System.Windows.Forms.Panel();
            this.balanceDialTitle = new System.Windows.Forms.Label();
            this.volumeDialTitle = new System.Windows.Forms.Label();
            this.playSubMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.playMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator28 = new System.Windows.Forms.ToolStripSeparator();
            this.openLocationMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.propertiesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator29 = new System.Windows.Forms.ToolStripSeparator();
            this.removeFromListMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.sortListMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shuttleSlider = new PVSPlayerExample.CustomSlider2();
            this.shuttleLabel = new PVSPlayerExample.HeadLabel();
            this.copyLabelPanel = new PVSPlayerExample.CustomPanel();
            this.copyModeLabel = new System.Windows.Forms.Label();
            this.copyModeLabelText = new System.Windows.Forms.Label();
            this.stretchRightButton = new PVSPlayerExample.CustomButton();
            this.stretchLeftButton = new PVSPlayerExample.CustomButton();
            this.stretchDownButton = new PVSPlayerExample.CustomButton();
            this.stretchUpButton = new PVSPlayerExample.CustomButton();
            this.zoomOutButton = new PVSPlayerExample.CustomButton();
            this.zoomInButton = new PVSPlayerExample.CustomButton();
            this.stretchLabel = new PVSPlayerExample.HeadLabel();
            this.zoomLabel = new PVSPlayerExample.HeadLabel();
            this.rightLevelMeterPanel = new PVSPlayerExample.BufferedPanel();
            this.leftLevelMeterPanel = new PVSPlayerExample.BufferedPanel();
            this.audioDeviceButton = new PVSPlayerExample.DropDownButton();
            this.balanceDial = new PVSPlayerExample.Dial();
            this.volumeDial = new PVSPlayerExample.Dial();
            this.volumeLabelPanel = new PVSPlayerExample.CustomPanel();
            this.audioLight = new PVSPlayerExample.LightPanel();
            this.audioTracksLabel = new System.Windows.Forms.Label();
            this.audioVolumeLabelText = new System.Windows.Forms.Label();
            this.positionSliderPanel = new PVSPlayerExample.SliderPanel();
            this.positionSlider = new PVSPlayerExample.CustomSlider();
            this.positionLabel2 = new System.Windows.Forms.Label();
            this.positionLabel1 = new System.Windows.Forms.Label();
            this.speedSlider = new PVSPlayerExample.CustomSlider2();
            this.speedLabelPanel = new PVSPlayerExample.CustomPanel();
            this.speedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.speedLight = new PVSPlayerExample.LightPanel();
            this.speedLabelText = new System.Windows.Forms.Label();
            this.repeatLight = new PVSPlayerExample.LightPanel();
            this.repeatButton = new PVSPlayerExample.DropDownButton();
            this.nextFromLabel = new PVSPlayerExample.HeadLabel();
            this.currentFromLabel = new PVSPlayerExample.HeadLabel();
            this.displayLight = new PVSPlayerExample.LightPanel();
            this.overlayMenuLight = new PVSPlayerExample.LightPanel();
            this.overlayLight = new PVSPlayerExample.LightPanel();
            this.displayOverlayButton = new PVSPlayerExample.DropDownButton();
            this.fullScreenLight = new PVSPlayerExample.LightPanel();
            this.fullScreenModeButton = new PVSPlayerExample.DropDownButton();
            this.displayModeLight = new PVSPlayerExample.LightPanel();
            this.displayModeButton = new PVSPlayerExample.DropDownButton();
            this.displayModeLabel = new PVSPlayerExample.HeadLabel();
            this.overlayMenuButton = new PVSPlayerExample.CustomButton();
            this.stopButton = new PVSPlayerExample.CustomButton();
            this.nextButton = new PVSPlayerExample.CustomButton();
            this.previousButton = new PVSPlayerExample.CustomButton();
            this.pauseButton = new PVSPlayerExample.CustomButton();
            this.playButtonLight = new PVSPlayerExample.LightPanel();
            this.playButton = new PVSPlayerExample.DropDownButton();
            this.titlePanel = new PVSPlayerExample.CustomPanel();
            this.clockLabel = new System.Windows.Forms.Label();
            this.webSiteLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.leftFramePanel.SuspendLayout();
            this.speedPanel.SuspendLayout();
            this.sliderMenu.SuspendLayout();
            this.repeatPanel.SuspendLayout();
            this.repeatMenu.SuspendLayout();
            this.displayModePanel.SuspendLayout();
            this.displayOverlayMenu.SuspendLayout();
            this.fullScreenModeMenu.SuspendLayout();
            this.playPanel.SuspendLayout();
            this.playMenu.SuspendLayout();
            this.displayMenu.SuspendLayout();
            this.audioTracks.SuspendLayout();
            this.videoTracks.SuspendLayout();
            this.screenCopyMenu.SuspendLayout();
            this.copyModeMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.audioDeviceMenu.SuspendLayout();
            this.positionSliderMenu.SuspendLayout();
            this.displayParentPanel.SuspendLayout();
            this.rightFramePanel.SuspendLayout();
            this.shuttlePanel.SuspendLayout();
            this.screencopyPanel.SuspendLayout();
            this.zoomPanel.SuspendLayout();
            this.audioPanel.SuspendLayout();
            this.playSubMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shuttleSlider)).BeginInit();
            this.copyLabelPanel.SuspendLayout();
            this.volumeLabelPanel.SuspendLayout();
            this.positionSliderPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.positionSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedSlider)).BeginInit();
            this.speedLabelPanel.SuspendLayout();
            this.titlePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // leftFramePanel
            // 
            this.leftFramePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.leftFramePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.leftFramePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.leftFramePanel.Controls.Add(this.speedPanel);
            this.leftFramePanel.Controls.Add(this.repeatPanel);
            this.leftFramePanel.Controls.Add(this.displayModePanel);
            this.leftFramePanel.Controls.Add(this.playPanel);
            this.leftFramePanel.Controls.Add(this.titlePanel);
            this.leftFramePanel.Location = new System.Drawing.Point(7, 8);
            this.leftFramePanel.Name = "leftFramePanel";
            this.leftFramePanel.Size = new System.Drawing.Size(155, 505);
            this.leftFramePanel.TabIndex = 0;
            // 
            // speedPanel
            // 
            this.speedPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.speedPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.speedPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.speedPanel.Controls.Add(this.speedSlider);
            this.speedPanel.Controls.Add(this.speedLabelPanel);
            this.speedPanel.Location = new System.Drawing.Point(6, 417);
            this.speedPanel.Name = "speedPanel";
            this.speedPanel.Size = new System.Drawing.Size(141, 80);
            this.speedPanel.TabIndex = 4;
            // 
            // sliderMenu
            // 
            this.sliderMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sliderMenuItem1,
            this.sliderMenuItem2,
            this.sliderMenuItem3,
            this.sliderMenuItem4,
            this.sliderMenuItem5});
            this.sliderMenu.Name = "sliderMenu";
            this.sliderMenu.ShowImageMargin = false;
            this.sliderMenu.Size = new System.Drawing.Size(56, 114);
            this.sliderMenu.Opening += new System.ComponentModel.CancelEventHandler(this.SliderMenu_Opening);
            // 
            // sliderMenuItem1
            // 
            this.sliderMenuItem1.Name = "sliderMenuItem1";
            this.sliderMenuItem1.Size = new System.Drawing.Size(55, 22);
            this.sliderMenuItem1.Text = "1";
            this.sliderMenuItem1.Click += new System.EventHandler(this.SliderMenuItem1_Click);
            // 
            // sliderMenuItem2
            // 
            this.sliderMenuItem2.Name = "sliderMenuItem2";
            this.sliderMenuItem2.Size = new System.Drawing.Size(55, 22);
            this.sliderMenuItem2.Text = "2";
            this.sliderMenuItem2.Click += new System.EventHandler(this.SliderMenuItem2_Click);
            // 
            // sliderMenuItem3
            // 
            this.sliderMenuItem3.Name = "sliderMenuItem3";
            this.sliderMenuItem3.Size = new System.Drawing.Size(55, 22);
            this.sliderMenuItem3.Text = "3";
            this.sliderMenuItem3.Click += new System.EventHandler(this.SliderMenuItem3_Click);
            // 
            // sliderMenuItem4
            // 
            this.sliderMenuItem4.Name = "sliderMenuItem4";
            this.sliderMenuItem4.Size = new System.Drawing.Size(55, 22);
            this.sliderMenuItem4.Text = "4";
            this.sliderMenuItem4.Click += new System.EventHandler(this.SliderMenuItem4_Click);
            // 
            // sliderMenuItem5
            // 
            this.sliderMenuItem5.Name = "sliderMenuItem5";
            this.sliderMenuItem5.Size = new System.Drawing.Size(55, 22);
            this.sliderMenuItem5.Text = "5";
            this.sliderMenuItem5.Click += new System.EventHandler(this.SliderMenuItem5_Click);
            // 
            // repeatPanel
            // 
            this.repeatPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.repeatPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.repeatPanel.Controls.Add(this.repeatLight);
            this.repeatPanel.Controls.Add(this.repeatButton);
            this.repeatPanel.Controls.Add(this.nextFromLabel);
            this.repeatPanel.Controls.Add(this.stopTimeTextBox);
            this.repeatPanel.Controls.Add(this.startTimeTextBox);
            this.repeatPanel.Controls.Add(this.currentFromLabel);
            this.repeatPanel.Controls.Add(this.stopTimeNextTextBox);
            this.repeatPanel.Controls.Add(this.startTimeNextTextBox);
            this.repeatPanel.Location = new System.Drawing.Point(6, 279);
            this.repeatPanel.Name = "repeatPanel";
            this.repeatPanel.Size = new System.Drawing.Size(141, 133);
            this.repeatPanel.TabIndex = 3;
            // 
            // repeatMenu
            // 
            this.repeatMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.repeatOneMenuItem,
            this.repeatAllMenuItem,
            this.toolStripSeparator18,
            this.shuffleMenuItem,
            this.toolStripSeparator19,
            this.repeatOffMenuItem});
            this.repeatMenu.Name = "repeatMenu";
            this.repeatMenu.OwnerItem = this.repeatMenuItem;
            this.repeatMenu.Size = new System.Drawing.Size(204, 104);
            this.repeatMenu.Closed += new System.Windows.Forms.ToolStripDropDownClosedEventHandler(this.RepeatMenu_Closed);
            this.repeatMenu.Opening += new System.ComponentModel.CancelEventHandler(this.RepeatMenu_Opening);
            // 
            // repeatOneMenuItem
            // 
            this.repeatOneMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.repeatOneMenuItem.Name = "repeatOneMenuItem";
            this.repeatOneMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.repeatOneMenuItem.Size = new System.Drawing.Size(203, 22);
            this.repeatOneMenuItem.Text = "Repeat One";
            this.repeatOneMenuItem.Click += new System.EventHandler(this.RepeatOneMenuItem_Click);
            // 
            // repeatAllMenuItem
            // 
            this.repeatAllMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.repeatAllMenuItem.Name = "repeatAllMenuItem";
            this.repeatAllMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.repeatAllMenuItem.Size = new System.Drawing.Size(203, 22);
            this.repeatAllMenuItem.Text = "Repeat All";
            this.repeatAllMenuItem.Click += new System.EventHandler(this.RepeatAllMenuItem_Click);
            // 
            // toolStripSeparator18
            // 
            this.toolStripSeparator18.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolStripSeparator18.Name = "toolStripSeparator18";
            this.toolStripSeparator18.Size = new System.Drawing.Size(200, 6);
            // 
            // shuffleMenuItem
            // 
            this.shuffleMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.shuffleMenuItem.Name = "shuffleMenuItem";
            this.shuffleMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.shuffleMenuItem.Size = new System.Drawing.Size(203, 22);
            this.shuffleMenuItem.Text = "Shuffle";
            this.shuffleMenuItem.Click += new System.EventHandler(this.ShuffleMenuItem_Click);
            // 
            // toolStripSeparator19
            // 
            this.toolStripSeparator19.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolStripSeparator19.Name = "toolStripSeparator19";
            this.toolStripSeparator19.Size = new System.Drawing.Size(200, 6);
            // 
            // repeatOffMenuItem
            // 
            this.repeatOffMenuItem.Checked = true;
            this.repeatOffMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.repeatOffMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.repeatOffMenuItem.Name = "repeatOffMenuItem";
            this.repeatOffMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.R)));
            this.repeatOffMenuItem.Size = new System.Drawing.Size(203, 22);
            this.repeatOffMenuItem.Text = "Repeat Off";
            this.repeatOffMenuItem.Click += new System.EventHandler(this.RepeatOffMenuItem_Click);
            // 
            // repeatMenuItem
            // 
            this.repeatMenuItem.DropDown = this.repeatMenu;
            this.repeatMenuItem.Name = "repeatMenuItem";
            this.repeatMenuItem.Size = new System.Drawing.Size(155, 22);
            this.repeatMenuItem.Text = "Repeat";
            // 
            // stopTimeTextBox
            // 
            this.stopTimeTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.stopTimeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.stopTimeTextBox.Enabled = false;
            this.stopTimeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stopTimeTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.stopTimeTextBox.Location = new System.Drawing.Point(69, 101);
            this.stopTimeTextBox.Mask = "00:00:00";
            this.stopTimeTextBox.Name = "stopTimeTextBox";
            this.stopTimeTextBox.Size = new System.Drawing.Size(61, 21);
            this.stopTimeTextBox.TabIndex = 7;
            this.stopTimeTextBox.Text = "000000";
            this.stopTimeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.stopTimeTextBox, "Player.Media.StopTime - the stop (repeat) time of the playing media.");
            this.stopTimeTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PositionTextBoxes_KeyPress);
            this.stopTimeTextBox.Validated += new System.EventHandler(this.StopTimeTextBox_Validated);
            // 
            // startTimeTextBox
            // 
            this.startTimeTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.startTimeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.startTimeTextBox.Enabled = false;
            this.startTimeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startTimeTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.startTimeTextBox.Location = new System.Drawing.Point(9, 101);
            this.startTimeTextBox.Mask = "00:00:00";
            this.startTimeTextBox.Name = "startTimeTextBox";
            this.startTimeTextBox.Size = new System.Drawing.Size(61, 21);
            this.startTimeTextBox.TabIndex = 6;
            this.startTimeTextBox.Text = "000000";
            this.startTimeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.startTimeTextBox, "Player.Media.StartTime - the start (repeat) time of the playing media.");
            this.startTimeTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PositionTextBoxes_KeyPress);
            this.startTimeTextBox.Validated += new System.EventHandler(this.StartTimeTextBox_Validated);
            // 
            // stopTimeNextTextBox
            // 
            this.stopTimeNextTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.stopTimeNextTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.stopTimeNextTextBox.Culture = new System.Globalization.CultureInfo("");
            this.stopTimeNextTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stopTimeNextTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.stopTimeNextTextBox.Location = new System.Drawing.Point(69, 55);
            this.stopTimeNextTextBox.Mask = "00:00:00";
            this.stopTimeNextTextBox.Name = "stopTimeNextTextBox";
            this.stopTimeNextTextBox.Size = new System.Drawing.Size(61, 21);
            this.stopTimeNextTextBox.TabIndex = 4;
            this.stopTimeNextTextBox.Text = "000000";
            this.stopTimeNextTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.stopTimeNextTextBox, "The stop (repeat) time for the next media to be played.");
            this.stopTimeNextTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PositionTextBoxes_KeyPress);
            this.stopTimeNextTextBox.Validated += new System.EventHandler(this.StopTimeNextTextBox_Validated);
            // 
            // startTimeNextTextBox
            // 
            this.startTimeNextTextBox.AsciiOnly = true;
            this.startTimeNextTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.startTimeNextTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.startTimeNextTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startTimeNextTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.startTimeNextTextBox.Location = new System.Drawing.Point(9, 55);
            this.startTimeNextTextBox.Mask = "00:00:00";
            this.startTimeNextTextBox.Name = "startTimeNextTextBox";
            this.startTimeNextTextBox.Size = new System.Drawing.Size(61, 21);
            this.startTimeNextTextBox.TabIndex = 3;
            this.startTimeNextTextBox.Text = "000000";
            this.startTimeNextTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.startTimeNextTextBox, "The start (repeat) time for the next media to be played.");
            this.startTimeNextTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PositionTextBoxes_KeyPress);
            this.startTimeNextTextBox.Validated += new System.EventHandler(this.StartTimeNextTextBox_Validated);
            // 
            // displayModePanel
            // 
            this.displayModePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.displayModePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.displayModePanel.Controls.Add(this.displayLight);
            this.displayModePanel.Controls.Add(this.videoTracksLabel);
            this.displayModePanel.Controls.Add(this.overlayMenuLight);
            this.displayModePanel.Controls.Add(this.overlayLight);
            this.displayModePanel.Controls.Add(this.displayOverlayButton);
            this.displayModePanel.Controls.Add(this.fullScreenLight);
            this.displayModePanel.Controls.Add(this.fullScreenModeButton);
            this.displayModePanel.Controls.Add(this.displayModeLight);
            this.displayModePanel.Controls.Add(this.displayModeButton);
            this.displayModePanel.Controls.Add(this.displayModeLabel);
            this.displayModePanel.Controls.Add(this.overlayMenuButton);
            this.displayModePanel.Location = new System.Drawing.Point(6, 130);
            this.displayModePanel.Name = "displayModePanel";
            this.displayModePanel.Size = new System.Drawing.Size(141, 144);
            this.displayModePanel.TabIndex = 2;
            // 
            // videoTracksLabel
            // 
            this.videoTracksLabel.BackColor = System.Drawing.Color.Transparent;
            this.videoTracksLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.videoTracksLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.videoTracksLabel.ForeColor = System.Drawing.Color.Lime;
            this.videoTracksLabel.Location = new System.Drawing.Point(109, 14);
            this.videoTracksLabel.Name = "videoTracksLabel";
            this.videoTracksLabel.Size = new System.Drawing.Size(16, 10);
            this.videoTracksLabel.TabIndex = 10;
            this.videoTracksLabel.Text = "1";
            this.videoTracksLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.toolTip1.SetToolTip(this.videoTracksLabel, "Player.Media.VideoTrackCount - the number of video tracks in the playing media.");
            this.videoTracksLabel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.VideoTracksLabel_MouseClick);
            // 
            // displayOverlayMenu
            // 
            this.displayOverlayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.overlayModeToolStripMenuItem,
            this.overlayHoldMenuItem,
            this.toolStripSeparator5,
            this.messageMenuItem,
            this.scribbleMenuItem,
            this.toolStripSeparator24,
            this.tilesMenuItem,
            this.bouncingMenuItem,
            this.toolStripSeparator23,
            this.PiPMenuItem,
            this.subtitlesMenuItem,
            this.toolStripSeparator25,
            this.zoomSelectMenuItem,
            this.videoWallMenuItem,
            this.toolStripSeparator21,
            this.MP3CoverMenuItem,
            this.MP3KaraokeMenuItem,
            this.toolStripSeparator22,
            this.bigTimeMenuItem,
            this.statusInfoMenuItem,
            this.toolStripSeparator6,
            this.overlayOffMenuItem});
            this.displayOverlayMenu.Name = "displayOverlayMenu";
            this.displayOverlayMenu.OwnerItem = this.displayOverlayMenuItem;
            this.displayOverlayMenu.ShowItemToolTips = false;
            this.displayOverlayMenu.Size = new System.Drawing.Size(259, 376);
            this.displayOverlayMenu.Closing += new System.Windows.Forms.ToolStripDropDownClosingEventHandler(this.DisplayOverlayMenu_Closing);
            this.displayOverlayMenu.Opening += new System.ComponentModel.CancelEventHandler(this.DisplayOverlayMenu_Opening);
            // 
            // overlayModeToolStripMenuItem
            // 
            this.overlayModeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.videoMenuItem,
            this.displayMenuItem});
            this.overlayModeToolStripMenuItem.Name = "overlayModeToolStripMenuItem";
            this.overlayModeToolStripMenuItem.Size = new System.Drawing.Size(258, 22);
            this.overlayModeToolStripMenuItem.Text = "Overlay Mode";
            // 
            // videoMenuItem
            // 
            this.videoMenuItem.Checked = true;
            this.videoMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.videoMenuItem.Name = "videoMenuItem";
            this.videoMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.V)));
            this.videoMenuItem.Size = new System.Drawing.Size(150, 22);
            this.videoMenuItem.Text = "Video";
            this.videoMenuItem.Click += new System.EventHandler(this.VideoMenuItem_Click);
            // 
            // displayMenuItem
            // 
            this.displayMenuItem.Name = "displayMenuItem";
            this.displayMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D)));
            this.displayMenuItem.Size = new System.Drawing.Size(150, 22);
            this.displayMenuItem.Text = "Display";
            this.displayMenuItem.Click += new System.EventHandler(this.DisplayMenuItem_Click);
            // 
            // overlayHoldMenuItem
            // 
            this.overlayHoldMenuItem.Name = "overlayHoldMenuItem";
            this.overlayHoldMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.H)));
            this.overlayHoldMenuItem.Size = new System.Drawing.Size(258, 22);
            this.overlayHoldMenuItem.Text = "Overlay Hold";
            this.overlayHoldMenuItem.Click += new System.EventHandler(this.OverlayHoldMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(255, 6);
            // 
            // messageMenuItem
            // 
            this.messageMenuItem.Name = "messageMenuItem";
            this.messageMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F1)));
            this.messageMenuItem.Size = new System.Drawing.Size(258, 22);
            this.messageMenuItem.Text = "Example \"Message\"";
            this.messageMenuItem.Click += new System.EventHandler(this.MessageMenuItem_Click);
            // 
            // scribbleMenuItem
            // 
            this.scribbleMenuItem.Name = "scribbleMenuItem";
            this.scribbleMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F2)));
            this.scribbleMenuItem.Size = new System.Drawing.Size(258, 22);
            this.scribbleMenuItem.Text = "Example \"Scribble\"";
            this.scribbleMenuItem.Click += new System.EventHandler(this.ScribbleMenuItem_Click);
            // 
            // toolStripSeparator24
            // 
            this.toolStripSeparator24.Name = "toolStripSeparator24";
            this.toolStripSeparator24.Size = new System.Drawing.Size(255, 6);
            // 
            // tilesMenuItem
            // 
            this.tilesMenuItem.Name = "tilesMenuItem";
            this.tilesMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F3)));
            this.tilesMenuItem.Size = new System.Drawing.Size(258, 22);
            this.tilesMenuItem.Text = "Example \"Tiles && Puzzle\"";
            this.tilesMenuItem.Click += new System.EventHandler(this.TilesMenuItem_Click);
            // 
            // bouncingMenuItem
            // 
            this.bouncingMenuItem.Name = "bouncingMenuItem";
            this.bouncingMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.bouncingMenuItem.Size = new System.Drawing.Size(258, 22);
            this.bouncingMenuItem.Text = "Example \"Bounce && Pong\"";
            this.bouncingMenuItem.Click += new System.EventHandler(this.BouncingMenuItem_Click);
            // 
            // toolStripSeparator23
            // 
            this.toolStripSeparator23.Name = "toolStripSeparator23";
            this.toolStripSeparator23.Size = new System.Drawing.Size(255, 6);
            // 
            // PiPMenuItem
            // 
            this.PiPMenuItem.Name = "PiPMenuItem";
            this.PiPMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F5)));
            this.PiPMenuItem.Size = new System.Drawing.Size(258, 22);
            this.PiPMenuItem.Text = "Example \"PiP\"";
            this.PiPMenuItem.Click += new System.EventHandler(this.PiPMenuItem_Click);
            // 
            // subtitlesMenuItem
            // 
            this.subtitlesMenuItem.Name = "subtitlesMenuItem";
            this.subtitlesMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F6)));
            this.subtitlesMenuItem.Size = new System.Drawing.Size(258, 22);
            this.subtitlesMenuItem.Text = "Example \"Subtitles\"";
            this.subtitlesMenuItem.Click += new System.EventHandler(this.SubtitlesMenuItem_Click);
            // 
            // toolStripSeparator25
            // 
            this.toolStripSeparator25.Name = "toolStripSeparator25";
            this.toolStripSeparator25.Size = new System.Drawing.Size(255, 6);
            // 
            // zoomSelectMenuItem
            // 
            this.zoomSelectMenuItem.Name = "zoomSelectMenuItem";
            this.zoomSelectMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F7)));
            this.zoomSelectMenuItem.Size = new System.Drawing.Size(258, 22);
            this.zoomSelectMenuItem.Text = "Example \"Zoom && Drag\"";
            this.zoomSelectMenuItem.Click += new System.EventHandler(this.ZoomSelectMenuItem_Click);
            // 
            // videoWallMenuItem
            // 
            this.videoWallMenuItem.Name = "videoWallMenuItem";
            this.videoWallMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F8)));
            this.videoWallMenuItem.Size = new System.Drawing.Size(258, 22);
            this.videoWallMenuItem.Text = "Example \"Video Wall\"";
            this.videoWallMenuItem.Click += new System.EventHandler(this.VideoWallMenuItem_Click);
            // 
            // toolStripSeparator21
            // 
            this.toolStripSeparator21.Name = "toolStripSeparator21";
            this.toolStripSeparator21.Size = new System.Drawing.Size(255, 6);
            // 
            // MP3CoverMenuItem
            // 
            this.MP3CoverMenuItem.Name = "MP3CoverMenuItem";
            this.MP3CoverMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F9)));
            this.MP3CoverMenuItem.Size = new System.Drawing.Size(258, 22);
            this.MP3CoverMenuItem.Text = "Example \"MP3 Cover\"";
            this.MP3CoverMenuItem.Click += new System.EventHandler(this.MP3CoverMenuItem_Click);
            // 
            // MP3KaraokeMenuItem
            // 
            this.MP3KaraokeMenuItem.Name = "MP3KaraokeMenuItem";
            this.MP3KaraokeMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F10)));
            this.MP3KaraokeMenuItem.Size = new System.Drawing.Size(258, 22);
            this.MP3KaraokeMenuItem.Text = "Example \"MP3 Karaoke\"";
            this.MP3KaraokeMenuItem.Click += new System.EventHandler(this.MP3KaraokeMenuItem_Click);
            // 
            // toolStripSeparator22
            // 
            this.toolStripSeparator22.Name = "toolStripSeparator22";
            this.toolStripSeparator22.Size = new System.Drawing.Size(255, 6);
            // 
            // bigTimeMenuItem
            // 
            this.bigTimeMenuItem.Name = "bigTimeMenuItem";
            this.bigTimeMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F11)));
            this.bigTimeMenuItem.Size = new System.Drawing.Size(258, 22);
            this.bigTimeMenuItem.Text = "Example \"Big Time && VU\"";
            this.bigTimeMenuItem.Click += new System.EventHandler(this.BigTimeMenuItem_Click);
            // 
            // statusInfoMenuItem
            // 
            this.statusInfoMenuItem.Name = "statusInfoMenuItem";
            this.statusInfoMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F12)));
            this.statusInfoMenuItem.Size = new System.Drawing.Size(258, 22);
            this.statusInfoMenuItem.Text = "Example \"Status Info\"";
            this.statusInfoMenuItem.Click += new System.EventHandler(this.StatusInfoMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(255, 6);
            // 
            // overlayOffMenuItem
            // 
            this.overlayOffMenuItem.Checked = true;
            this.overlayOffMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.overlayOffMenuItem.Name = "overlayOffMenuItem";
            this.overlayOffMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D0)));
            this.overlayOffMenuItem.Size = new System.Drawing.Size(258, 22);
            this.overlayOffMenuItem.Text = "Overlay Off";
            this.overlayOffMenuItem.Click += new System.EventHandler(this.OverlayOffMenuItem_Click);
            // 
            // displayOverlayMenuItem
            // 
            this.displayOverlayMenuItem.DropDown = this.displayOverlayMenu;
            this.displayOverlayMenuItem.Name = "displayOverlayMenuItem";
            this.displayOverlayMenuItem.Size = new System.Drawing.Size(155, 22);
            this.displayOverlayMenuItem.Text = "Display Overlay";
            // 
            // fullScreenModeMenu
            // 
            this.fullScreenModeMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fullScreenFormMenuItem,
            this.fullScreenFormAllMenuItem,
            this.fullScreenParentMenuItem,
            this.fullScreenParentAllMenuItem,
            this.fullScreenDisplayMenuItem,
            this.fullScreenDisplayAllMenuItem,
            this.toolStripSeparator3,
            this.fullScreenOffMenuItem});
            this.fullScreenModeMenu.Name = "fullScreenModeMenu";
            this.fullScreenModeMenu.OwnerItem = this.fullScreenModeMenuItem;
            this.fullScreenModeMenu.Size = new System.Drawing.Size(233, 164);
            this.fullScreenModeMenu.Closed += new System.Windows.Forms.ToolStripDropDownClosedEventHandler(this.FullScreenModeMenu_Closed);
            this.fullScreenModeMenu.Opening += new System.ComponentModel.CancelEventHandler(this.FullScreenModeMenu_Opening);
            this.fullScreenModeMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.FullScreenModeMenu_ItemClicked);
            // 
            // fullScreenFormMenuItem
            // 
            this.fullScreenFormMenuItem.Name = "fullScreenFormMenuItem";
            this.fullScreenFormMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.fullScreenFormMenuItem.Size = new System.Drawing.Size(232, 22);
            this.fullScreenFormMenuItem.Text = "Full Screen Form";
            // 
            // fullScreenFormAllMenuItem
            // 
            this.fullScreenFormAllMenuItem.Name = "fullScreenFormAllMenuItem";
            this.fullScreenFormAllMenuItem.Size = new System.Drawing.Size(232, 22);
            this.fullScreenFormAllMenuItem.Text = "Full Screen Form All Screens";
            // 
            // fullScreenParentMenuItem
            // 
            this.fullScreenParentMenuItem.Name = "fullScreenParentMenuItem";
            this.fullScreenParentMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F9;
            this.fullScreenParentMenuItem.Size = new System.Drawing.Size(232, 22);
            this.fullScreenParentMenuItem.Text = "Full Screen Parent";
            // 
            // fullScreenParentAllMenuItem
            // 
            this.fullScreenParentAllMenuItem.Name = "fullScreenParentAllMenuItem";
            this.fullScreenParentAllMenuItem.Size = new System.Drawing.Size(232, 22);
            this.fullScreenParentAllMenuItem.Text = "Full Screen Parent All Screens";
            // 
            // fullScreenDisplayMenuItem
            // 
            this.fullScreenDisplayMenuItem.Name = "fullScreenDisplayMenuItem";
            this.fullScreenDisplayMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F10;
            this.fullScreenDisplayMenuItem.Size = new System.Drawing.Size(232, 22);
            this.fullScreenDisplayMenuItem.Text = "Full Screen Display";
            // 
            // fullScreenDisplayAllMenuItem
            // 
            this.fullScreenDisplayAllMenuItem.Name = "fullScreenDisplayAllMenuItem";
            this.fullScreenDisplayAllMenuItem.Size = new System.Drawing.Size(232, 22);
            this.fullScreenDisplayAllMenuItem.Text = "Full Screen Display All Screens";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(229, 6);
            // 
            // fullScreenOffMenuItem
            // 
            this.fullScreenOffMenuItem.Checked = true;
            this.fullScreenOffMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.fullScreenOffMenuItem.Name = "fullScreenOffMenuItem";
            this.fullScreenOffMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F11;
            this.fullScreenOffMenuItem.Size = new System.Drawing.Size(232, 22);
            this.fullScreenOffMenuItem.Text = "Full Screen Off";
            // 
            // fullScreenModeMenuItem
            // 
            this.fullScreenModeMenuItem.DropDown = this.fullScreenModeMenu;
            this.fullScreenModeMenuItem.Name = "fullScreenModeMenuItem";
            this.fullScreenModeMenuItem.Size = new System.Drawing.Size(155, 22);
            this.fullScreenModeMenuItem.Text = "FullScreen Mode";
            // 
            // displayModeMenu
            // 
            this.displayModeMenu.Name = "displayModeMenu";
            this.displayModeMenu.OwnerItem = this.displayModeMenuItem;
            this.displayModeMenu.ShowItemToolTips = false;
            this.displayModeMenu.Size = new System.Drawing.Size(61, 4);
            this.displayModeMenu.Closed += new System.Windows.Forms.ToolStripDropDownClosedEventHandler(this.DisplayModeMenu_Closed);
            this.displayModeMenu.Opening += new System.ComponentModel.CancelEventHandler(this.DisplayModeMenu_Opening);
            this.displayModeMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.DisplayModeMenu_ItemClicked);
            // 
            // displayModeMenuItem
            // 
            this.displayModeMenuItem.DropDown = this.displayModeMenu;
            this.displayModeMenuItem.Name = "displayModeMenuItem";
            this.displayModeMenuItem.Size = new System.Drawing.Size(155, 22);
            this.displayModeMenuItem.Text = "Display Mode";
            // 
            // playPanel
            // 
            this.playPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.playPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.playPanel.Controls.Add(this.stopButton);
            this.playPanel.Controls.Add(this.nextButton);
            this.playPanel.Controls.Add(this.previousButton);
            this.playPanel.Controls.Add(this.pauseButton);
            this.playPanel.Controls.Add(this.playButtonLight);
            this.playPanel.Controls.Add(this.playButton);
            this.playPanel.Location = new System.Drawing.Point(6, 62);
            this.playPanel.Name = "playPanel";
            this.playPanel.Size = new System.Drawing.Size(141, 63);
            this.playPanel.TabIndex = 1;
            // 
            // playMenu
            // 
            this.playMenu.AllowDrop = true;
            this.playMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playListMenuItem,
            this.webcamsMenuItem,
            this.toolStripSeparator16,
            this.addMediaFilesMenuItem,
            this.addMediaURLMenuItem,
            this.menuSeparator1});
            this.playMenu.Name = "playMenu";
            this.playMenu.OwnerItem = this.playDisplayMenuItem;
            this.playMenu.ShowItemToolTips = false;
            this.playMenu.Size = new System.Drawing.Size(213, 104);
            this.playMenu.Closing += new System.Windows.Forms.ToolStripDropDownClosingEventHandler(this.PlayMenu_Closing);
            this.playMenu.Opening += new System.ComponentModel.CancelEventHandler(this.PlayMenu_Opening);
            this.playMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.PlayMenu_ItemClicked);
            this.playMenu.DragDrop += new System.Windows.Forms.DragEventHandler(this.PlayMenu_DragDrop);
            this.playMenu.DragOver += new System.Windows.Forms.DragEventHandler(this.PlayMenu_DragOver);
            this.playMenu.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PlayMenu_MouseClick);
            // 
            // playListMenuItem
            // 
            this.playListMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newPlayListMenuItem,
            this.toolStripSeparator2,
            this.openPlayListMenuItem,
            this.addPlayListMenuItem,
            this.toolStripSeparator4,
            this.savePlayListMenuItem});
            this.playListMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.playListMenuItem.Name = "playListMenuItem";
            this.playListMenuItem.Size = new System.Drawing.Size(212, 22);
            this.playListMenuItem.Text = "Playlists";
            // 
            // newPlayListMenuItem
            // 
            this.newPlayListMenuItem.Enabled = false;
            this.newPlayListMenuItem.Name = "newPlayListMenuItem";
            this.newPlayListMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newPlayListMenuItem.Size = new System.Drawing.Size(203, 22);
            this.newPlayListMenuItem.Text = "New Playlist";
            this.newPlayListMenuItem.Click += new System.EventHandler(this.NewPlayListMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(200, 6);
            // 
            // openPlayListMenuItem
            // 
            this.openPlayListMenuItem.Name = "openPlayListMenuItem";
            this.openPlayListMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openPlayListMenuItem.Size = new System.Drawing.Size(203, 22);
            this.openPlayListMenuItem.Text = "Open Playlist…";
            this.openPlayListMenuItem.Click += new System.EventHandler(this.OpenPlayListMenuItem_Click);
            // 
            // addPlayListMenuItem
            // 
            this.addPlayListMenuItem.Enabled = false;
            this.addPlayListMenuItem.Name = "addPlayListMenuItem";
            this.addPlayListMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.addPlayListMenuItem.Size = new System.Drawing.Size(203, 22);
            this.addPlayListMenuItem.Text = "Add Playlist…";
            this.addPlayListMenuItem.Click += new System.EventHandler(this.AddPlayListMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(200, 6);
            // 
            // savePlayListMenuItem
            // 
            this.savePlayListMenuItem.Enabled = false;
            this.savePlayListMenuItem.Name = "savePlayListMenuItem";
            this.savePlayListMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.savePlayListMenuItem.Size = new System.Drawing.Size(203, 22);
            this.savePlayListMenuItem.Text = "Save Playlist As…";
            this.savePlayListMenuItem.Click += new System.EventHandler(this.SavePlayListMenuItem_Click);
            // 
            // webcamsMenuItem
            // 
            this.webcamsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.noWebcamsToolStripMenuItem});
            this.webcamsMenuItem.Enabled = false;
            this.webcamsMenuItem.Name = "webcamsMenuItem";
            this.webcamsMenuItem.Size = new System.Drawing.Size(212, 22);
            this.webcamsMenuItem.Text = "Webcams";
            // 
            // noWebcamsToolStripMenuItem
            // 
            this.noWebcamsToolStripMenuItem.Enabled = false;
            this.noWebcamsToolStripMenuItem.Name = "noWebcamsToolStripMenuItem";
            this.noWebcamsToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.noWebcamsToolStripMenuItem.Text = "No Webcams";
            // 
            // toolStripSeparator16
            // 
            this.toolStripSeparator16.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolStripSeparator16.Name = "toolStripSeparator16";
            this.toolStripSeparator16.Size = new System.Drawing.Size(209, 6);
            // 
            // addMediaFilesMenuItem
            // 
            this.addMediaFilesMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.addMediaFilesMenuItem.Name = "addMediaFilesMenuItem";
            this.addMediaFilesMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.addMediaFilesMenuItem.Size = new System.Drawing.Size(212, 22);
            this.addMediaFilesMenuItem.Text = "Add Media Files…";
            // 
            // addMediaURLMenuItem
            // 
            this.addMediaURLMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.addMediaURLMenuItem.Name = "addMediaURLMenuItem";
            this.addMediaURLMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U)));
            this.addMediaURLMenuItem.Size = new System.Drawing.Size(212, 22);
            this.addMediaURLMenuItem.Text = "Add Media URLs…";
            // 
            // menuSeparator1
            // 
            this.menuSeparator1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.menuSeparator1.Name = "menuSeparator1";
            this.menuSeparator1.Size = new System.Drawing.Size(209, 6);
            // 
            // playDisplayMenuItem
            // 
            this.playDisplayMenuItem.DropDown = this.playMenu;
            this.playDisplayMenuItem.Name = "playDisplayMenuItem";
            this.playDisplayMenuItem.Size = new System.Drawing.Size(155, 22);
            this.playDisplayMenuItem.Text = "Play";
            // 
            // toolTip1
            // 
            this.toolTip1.Active = false;
            this.toolTip1.AutoPopDelay = 20000;
            this.toolTip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.toolTip1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.IsBalloon = true;
            this.toolTip1.OwnerDraw = true;
            this.toolTip1.ReshowDelay = 100;
            this.toolTip1.ToolTipTitle = "PVS.MediaPlayer";
            this.toolTip1.Draw += new System.Windows.Forms.DrawToolTipEventHandler(this.ToolTip1_Draw);
            // 
            // displayPanel
            // 
            this.displayPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.displayPanel.ContextMenuStrip = this.displayMenu;
            this.displayPanel.Location = new System.Drawing.Point(0, 0);
            this.displayPanel.Name = "displayPanel";
            this.displayPanel.Size = new System.Drawing.Size(640, 480);
            this.displayPanel.TabIndex = 1;
            this.toolTip1.SetToolTip(this.displayPanel, "Player.Display.Window - the control that is used to display video and overlays.");
            // 
            // displayMenu
            // 
            this.displayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playDisplayMenuItem,
            this.previousMenuItem,
            this.nextMenuItem,
            this.pauseMenuItem,
            this.stopMenuItem,
            this.toolStripSeparator8,
            this.audioTracksMenuItem,
            this.videoTracksMenuItem,
            this.tracksMenuSeparator,
            this.displayModeMenuItem,
            this.displayShapeMenuItem,
            this.displayClonesMenuItem,
            this.toolStripSeparator39,
            this.fullScreenModeMenuItem,
            this.toolStripSeparator10,
            this.displayOverlayMenuItem,
            this.overlayMenuMenuItem,
            this.toolStripSeparator9,
            this.repeatMenuItem,
            this.toolStripSeparator15,
            this.videoSizeMenuItem,
            this.videoColorMenuItem,
            this.toolStripSeparator41,
            this.screencopyMenuItem,
            this.toolStripSeparator17,
            this.systemMenuItem,
            this.preferencesMenuItem,
            this.toolStripSeparator11,
            this.quitMenuItem});
            this.displayMenu.Name = "displayMenu";
            this.displayMenu.ShowImageMargin = false;
            this.displayMenu.Size = new System.Drawing.Size(156, 498);
            this.displayMenu.Closing += new System.Windows.Forms.ToolStripDropDownClosingEventHandler(this.DisplayMenu_Closing);
            this.displayMenu.Opening += new System.ComponentModel.CancelEventHandler(this.DisplayMenu_Opening);
            // 
            // previousMenuItem
            // 
            this.previousMenuItem.Name = "previousMenuItem";
            this.previousMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.previousMenuItem.Size = new System.Drawing.Size(155, 22);
            this.previousMenuItem.Text = "Previous";
            this.previousMenuItem.Click += new System.EventHandler(this.PreviousButton_Click);
            // 
            // nextMenuItem
            // 
            this.nextMenuItem.Name = "nextMenuItem";
            this.nextMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.nextMenuItem.Size = new System.Drawing.Size(155, 22);
            this.nextMenuItem.Text = "Next";
            this.nextMenuItem.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // pauseMenuItem
            // 
            this.pauseMenuItem.Name = "pauseMenuItem";
            this.pauseMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Space)));
            this.pauseMenuItem.Size = new System.Drawing.Size(155, 22);
            this.pauseMenuItem.Text = "Pause";
            this.pauseMenuItem.Click += new System.EventHandler(this.PauseButton_Click);
            // 
            // stopMenuItem
            // 
            this.stopMenuItem.Name = "stopMenuItem";
            this.stopMenuItem.Size = new System.Drawing.Size(155, 22);
            this.stopMenuItem.Text = "Stop";
            this.stopMenuItem.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(152, 6);
            // 
            // audioTracksMenuItem
            // 
            this.audioTracksMenuItem.DropDown = this.audioTracks;
            this.audioTracksMenuItem.Enabled = false;
            this.audioTracksMenuItem.Name = "audioTracksMenuItem";
            this.audioTracksMenuItem.Size = new System.Drawing.Size(155, 22);
            this.audioTracksMenuItem.Text = "Audio Tracks";
            // 
            // audioTracks
            // 
            this.audioTracks.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.audioTracks.Name = "audioTracks";
            this.audioTracks.OwnerItem = this.audioTracksMenuItem;
            this.audioTracks.Size = new System.Drawing.Size(126, 26);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Enabled = false;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(125, 22);
            this.toolStripMenuItem1.Text = "No Tracks";
            // 
            // videoTracksMenuItem
            // 
            this.videoTracksMenuItem.DropDown = this.videoTracks;
            this.videoTracksMenuItem.Enabled = false;
            this.videoTracksMenuItem.Name = "videoTracksMenuItem";
            this.videoTracksMenuItem.Size = new System.Drawing.Size(155, 22);
            this.videoTracksMenuItem.Text = "Video Tracks";
            // 
            // videoTracks
            // 
            this.videoTracks.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2});
            this.videoTracks.Name = "videoTracks";
            this.videoTracks.OwnerItem = this.videoTracksMenuItem;
            this.videoTracks.Size = new System.Drawing.Size(126, 26);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Enabled = false;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(125, 22);
            this.toolStripMenuItem2.Text = "No Tracks";
            // 
            // tracksMenuSeparator
            // 
            this.tracksMenuSeparator.Name = "tracksMenuSeparator";
            this.tracksMenuSeparator.Size = new System.Drawing.Size(152, 6);
            // 
            // displayShapeMenuItem
            // 
            this.displayShapeMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arrowDownShapeMenuItem,
            this.arrowLeftShapeMenuItem,
            this.arrowRightShapeMenuItem,
            this.arrowUpShapeMenuItem,
            this.barsShapeMenuItem,
            this.beamsShapeMenuItem,
            this.circleShapeMenuItem,
            this.crossShapeMenuItem,
            this.diamondShapeMenuItem,
            this.frameShapeMenuItem,
            this.heartShapeMenuItem,
            this.hexagonShapeMenuItem,
            this.ovalShapeMenuItem,
            this.rectangleShapeMenuItem,
            this.ringShapeMenuItem,
            this.roundedShapeMenuItem,
            this.squareShapeMenuItem,
            this.starShapeMenuItem,
            this.tilesShapeMenuItem,
            this.triangleDownMenuItem,
            this.triangleLeftMenuItem,
            this.triangleRightMenuItem,
            this.triangleUpMenuItem,
            this.toolStripSeparator34,
            this.useVideoBoundsMenuItem,
            this.setOverlayShapeMenuItem,
            this.toolStripSeparator38,
            this.normalShapeMenuItem});
            this.displayShapeMenuItem.Name = "displayShapeMenuItem";
            this.displayShapeMenuItem.Size = new System.Drawing.Size(155, 22);
            this.displayShapeMenuItem.Text = "Display Shape";
            // 
            // arrowDownShapeMenuItem
            // 
            this.arrowDownShapeMenuItem.Name = "arrowDownShapeMenuItem";
            this.arrowDownShapeMenuItem.Size = new System.Drawing.Size(149, 22);
            this.arrowDownShapeMenuItem.Text = "Arrow Down";
            this.arrowDownShapeMenuItem.Click += new System.EventHandler(this.ArrowDownShapeMenuItem_Click);
            // 
            // arrowLeftShapeMenuItem
            // 
            this.arrowLeftShapeMenuItem.Name = "arrowLeftShapeMenuItem";
            this.arrowLeftShapeMenuItem.Size = new System.Drawing.Size(149, 22);
            this.arrowLeftShapeMenuItem.Text = "Arrow Left";
            this.arrowLeftShapeMenuItem.Click += new System.EventHandler(this.ArrowLeftShapeMenuItem_Click);
            // 
            // arrowRightShapeMenuItem
            // 
            this.arrowRightShapeMenuItem.Name = "arrowRightShapeMenuItem";
            this.arrowRightShapeMenuItem.Size = new System.Drawing.Size(149, 22);
            this.arrowRightShapeMenuItem.Text = "Arrow Right";
            this.arrowRightShapeMenuItem.Click += new System.EventHandler(this.ArrowRightShapeMenuItem_Click);
            // 
            // arrowUpShapeMenuItem
            // 
            this.arrowUpShapeMenuItem.Name = "arrowUpShapeMenuItem";
            this.arrowUpShapeMenuItem.Size = new System.Drawing.Size(149, 22);
            this.arrowUpShapeMenuItem.Text = "Arrow Up";
            this.arrowUpShapeMenuItem.Click += new System.EventHandler(this.ArrowUpShapeMenuItem_Click);
            // 
            // barsShapeMenuItem
            // 
            this.barsShapeMenuItem.Name = "barsShapeMenuItem";
            this.barsShapeMenuItem.Size = new System.Drawing.Size(149, 22);
            this.barsShapeMenuItem.Text = "Bars";
            this.barsShapeMenuItem.Click += new System.EventHandler(this.BarsShapeMenuItem_Click);
            // 
            // beamsShapeMenuItem
            // 
            this.beamsShapeMenuItem.Name = "beamsShapeMenuItem";
            this.beamsShapeMenuItem.Size = new System.Drawing.Size(149, 22);
            this.beamsShapeMenuItem.Text = "Beams";
            this.beamsShapeMenuItem.Click += new System.EventHandler(this.BeamsShapeMenuItem_Click);
            // 
            // circleShapeMenuItem
            // 
            this.circleShapeMenuItem.Name = "circleShapeMenuItem";
            this.circleShapeMenuItem.Size = new System.Drawing.Size(149, 22);
            this.circleShapeMenuItem.Text = "Circle";
            this.circleShapeMenuItem.Click += new System.EventHandler(this.CircleShapeMenuItem_Click);
            // 
            // crossShapeMenuItem
            // 
            this.crossShapeMenuItem.Name = "crossShapeMenuItem";
            this.crossShapeMenuItem.Size = new System.Drawing.Size(149, 22);
            this.crossShapeMenuItem.Text = "Cross";
            this.crossShapeMenuItem.Click += new System.EventHandler(this.CrossShapeMenuItem_Click);
            // 
            // diamondShapeMenuItem
            // 
            this.diamondShapeMenuItem.Name = "diamondShapeMenuItem";
            this.diamondShapeMenuItem.Size = new System.Drawing.Size(149, 22);
            this.diamondShapeMenuItem.Text = "Diamond";
            this.diamondShapeMenuItem.Click += new System.EventHandler(this.DiamondShapeMenuItem_Click);
            // 
            // frameShapeMenuItem
            // 
            this.frameShapeMenuItem.Name = "frameShapeMenuItem";
            this.frameShapeMenuItem.Size = new System.Drawing.Size(149, 22);
            this.frameShapeMenuItem.Text = "Frame";
            this.frameShapeMenuItem.Click += new System.EventHandler(this.FrameShapeMenuItem_Click);
            // 
            // heartShapeMenuItem
            // 
            this.heartShapeMenuItem.Name = "heartShapeMenuItem";
            this.heartShapeMenuItem.Size = new System.Drawing.Size(149, 22);
            this.heartShapeMenuItem.Text = "Heart";
            this.heartShapeMenuItem.Click += new System.EventHandler(this.HeartShapeMenuItem_Click);
            // 
            // hexagonShapeMenuItem
            // 
            this.hexagonShapeMenuItem.Name = "hexagonShapeMenuItem";
            this.hexagonShapeMenuItem.Size = new System.Drawing.Size(149, 22);
            this.hexagonShapeMenuItem.Text = "Hexagon";
            this.hexagonShapeMenuItem.Click += new System.EventHandler(this.HexagonShapeMenuItem_Click);
            // 
            // ovalShapeMenuItem
            // 
            this.ovalShapeMenuItem.Name = "ovalShapeMenuItem";
            this.ovalShapeMenuItem.Size = new System.Drawing.Size(149, 22);
            this.ovalShapeMenuItem.Text = "Oval";
            this.ovalShapeMenuItem.Click += new System.EventHandler(this.OvalShapeMenuItem_Click);
            // 
            // rectangleShapeMenuItem
            // 
            this.rectangleShapeMenuItem.Name = "rectangleShapeMenuItem";
            this.rectangleShapeMenuItem.Size = new System.Drawing.Size(149, 22);
            this.rectangleShapeMenuItem.Text = "Rectangle";
            this.rectangleShapeMenuItem.Click += new System.EventHandler(this.RectangleShapeMenuItem_Click);
            // 
            // ringShapeMenuItem
            // 
            this.ringShapeMenuItem.Name = "ringShapeMenuItem";
            this.ringShapeMenuItem.Size = new System.Drawing.Size(149, 22);
            this.ringShapeMenuItem.Text = "Ring";
            this.ringShapeMenuItem.Click += new System.EventHandler(this.RingShapeMenuItem_Click);
            // 
            // roundedShapeMenuItem
            // 
            this.roundedShapeMenuItem.Name = "roundedShapeMenuItem";
            this.roundedShapeMenuItem.Size = new System.Drawing.Size(149, 22);
            this.roundedShapeMenuItem.Text = "Rounded";
            this.roundedShapeMenuItem.Click += new System.EventHandler(this.RoundedShapeMenuItem_Click);
            // 
            // squareShapeMenuItem
            // 
            this.squareShapeMenuItem.Name = "squareShapeMenuItem";
            this.squareShapeMenuItem.Size = new System.Drawing.Size(149, 22);
            this.squareShapeMenuItem.Text = "Square";
            this.squareShapeMenuItem.Click += new System.EventHandler(this.SquareShapeMenuItem_Click);
            // 
            // starShapeMenuItem
            // 
            this.starShapeMenuItem.Name = "starShapeMenuItem";
            this.starShapeMenuItem.Size = new System.Drawing.Size(149, 22);
            this.starShapeMenuItem.Text = "Star";
            this.starShapeMenuItem.Click += new System.EventHandler(this.StarShapeMenuItem_Click);
            // 
            // tilesShapeMenuItem
            // 
            this.tilesShapeMenuItem.Name = "tilesShapeMenuItem";
            this.tilesShapeMenuItem.Size = new System.Drawing.Size(149, 22);
            this.tilesShapeMenuItem.Text = "Tiles";
            this.tilesShapeMenuItem.Click += new System.EventHandler(this.TilesShapeMenuItem_Click);
            // 
            // triangleDownMenuItem
            // 
            this.triangleDownMenuItem.Name = "triangleDownMenuItem";
            this.triangleDownMenuItem.Size = new System.Drawing.Size(149, 22);
            this.triangleDownMenuItem.Text = "Triangle Down";
            this.triangleDownMenuItem.Click += new System.EventHandler(this.TriangleDownMenuItem_Click);
            // 
            // triangleLeftMenuItem
            // 
            this.triangleLeftMenuItem.Name = "triangleLeftMenuItem";
            this.triangleLeftMenuItem.Size = new System.Drawing.Size(149, 22);
            this.triangleLeftMenuItem.Text = "Triangle Left";
            this.triangleLeftMenuItem.Click += new System.EventHandler(this.TriangleLeftMenuItem_Click);
            // 
            // triangleRightMenuItem
            // 
            this.triangleRightMenuItem.Name = "triangleRightMenuItem";
            this.triangleRightMenuItem.Size = new System.Drawing.Size(149, 22);
            this.triangleRightMenuItem.Text = "Triangle Right";
            this.triangleRightMenuItem.Click += new System.EventHandler(this.TriangleRightMenuItem_Click);
            // 
            // triangleUpMenuItem
            // 
            this.triangleUpMenuItem.Name = "triangleUpMenuItem";
            this.triangleUpMenuItem.Size = new System.Drawing.Size(149, 22);
            this.triangleUpMenuItem.Text = "Triangle Up";
            this.triangleUpMenuItem.Click += new System.EventHandler(this.TriangleUpMenuItem_Click);
            // 
            // toolStripSeparator34
            // 
            this.toolStripSeparator34.Name = "toolStripSeparator34";
            this.toolStripSeparator34.Size = new System.Drawing.Size(146, 6);
            // 
            // useVideoBoundsMenuItem
            // 
            this.useVideoBoundsMenuItem.Checked = true;
            this.useVideoBoundsMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.useVideoBoundsMenuItem.Name = "useVideoBoundsMenuItem";
            this.useVideoBoundsMenuItem.Size = new System.Drawing.Size(149, 22);
            this.useVideoBoundsMenuItem.Text = "Video Shape";
            this.useVideoBoundsMenuItem.Click += new System.EventHandler(this.UseVideoBoundsMenuItem_Click);
            // 
            // setOverlayShapeMenuItem
            // 
            this.setOverlayShapeMenuItem.Name = "setOverlayShapeMenuItem";
            this.setOverlayShapeMenuItem.Size = new System.Drawing.Size(149, 22);
            this.setOverlayShapeMenuItem.Text = "Overlay Shape";
            this.setOverlayShapeMenuItem.Click += new System.EventHandler(this.SetOverlayShapeMenuItem_Click);
            // 
            // toolStripSeparator38
            // 
            this.toolStripSeparator38.Name = "toolStripSeparator38";
            this.toolStripSeparator38.Size = new System.Drawing.Size(146, 6);
            // 
            // normalShapeMenuItem
            // 
            this.normalShapeMenuItem.Checked = true;
            this.normalShapeMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.normalShapeMenuItem.Name = "normalShapeMenuItem";
            this.normalShapeMenuItem.Size = new System.Drawing.Size(149, 22);
            this.normalShapeMenuItem.Text = "Normal Shape";
            this.normalShapeMenuItem.Click += new System.EventHandler(this.NormalShapeMenuItem_Click);
            // 
            // displayClonesMenuItem
            // 
            this.displayClonesMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addCloneMenuItem,
            this.toolStripSeparator36,
            this.showOverlayMenuItem,
            this.refreshRateMenuItem,
            this.toolStripSeparator20,
            this.removeAllClonesMenuItem});
            this.displayClonesMenuItem.Name = "displayClonesMenuItem";
            this.displayClonesMenuItem.Size = new System.Drawing.Size(155, 22);
            this.displayClonesMenuItem.Text = "Display Clones";
            // 
            // addCloneMenuItem
            // 
            this.addCloneMenuItem.Name = "addCloneMenuItem";
            this.addCloneMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.addCloneMenuItem.Size = new System.Drawing.Size(213, 22);
            this.addCloneMenuItem.Text = "Add Display Clone";
            this.addCloneMenuItem.Click += new System.EventHandler(this.AddCloneMenuItem_Click);
            // 
            // toolStripSeparator36
            // 
            this.toolStripSeparator36.Name = "toolStripSeparator36";
            this.toolStripSeparator36.Size = new System.Drawing.Size(210, 6);
            // 
            // showOverlayMenuItem
            // 
            this.showOverlayMenuItem.Name = "showOverlayMenuItem";
            this.showOverlayMenuItem.Size = new System.Drawing.Size(213, 22);
            this.showOverlayMenuItem.Text = "Hide Clone Overlays";
            this.showOverlayMenuItem.Click += new System.EventHandler(this.ShowOverlayMenuItem_Click);
            // 
            // refreshRateMenuItem
            // 
            this.refreshRateMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fps01MenuItem,
            this.fps02MenuItem,
            this.fps05MenuItem,
            this.fps10MenuItem,
            this.fps15MenuItem,
            this.fps20MenuItem,
            this.fps25MenuItem,
            this.fps30MenuItem,
            this.fps40MenuItem,
            this.fps50MenuItem,
            this.fps60MenuItem});
            this.refreshRateMenuItem.Name = "refreshRateMenuItem";
            this.refreshRateMenuItem.Size = new System.Drawing.Size(213, 22);
            this.refreshRateMenuItem.Text = "Clones Frame Rate";
            // 
            // fps01MenuItem
            // 
            this.fps01MenuItem.Name = "fps01MenuItem";
            this.fps01MenuItem.Size = new System.Drawing.Size(105, 22);
            this.fps01MenuItem.Text = "01 fps";
            this.fps01MenuItem.Click += new System.EventHandler(this.Fps01MenuItem_Click);
            // 
            // fps02MenuItem
            // 
            this.fps02MenuItem.Name = "fps02MenuItem";
            this.fps02MenuItem.Size = new System.Drawing.Size(105, 22);
            this.fps02MenuItem.Text = "02 fps";
            this.fps02MenuItem.Click += new System.EventHandler(this.Fps02MenuItem_Click);
            // 
            // fps05MenuItem
            // 
            this.fps05MenuItem.Name = "fps05MenuItem";
            this.fps05MenuItem.Size = new System.Drawing.Size(105, 22);
            this.fps05MenuItem.Text = "05 fps";
            this.fps05MenuItem.Click += new System.EventHandler(this.Fps05MenuItem_Click);
            // 
            // fps10MenuItem
            // 
            this.fps10MenuItem.Name = "fps10MenuItem";
            this.fps10MenuItem.Size = new System.Drawing.Size(105, 22);
            this.fps10MenuItem.Text = "10 fps";
            this.fps10MenuItem.Click += new System.EventHandler(this.Fps10MenuItem_Click);
            // 
            // fps15MenuItem
            // 
            this.fps15MenuItem.Name = "fps15MenuItem";
            this.fps15MenuItem.Size = new System.Drawing.Size(105, 22);
            this.fps15MenuItem.Text = "15 fps";
            this.fps15MenuItem.Click += new System.EventHandler(this.Fps15MenuItem_Click);
            // 
            // fps20MenuItem
            // 
            this.fps20MenuItem.Name = "fps20MenuItem";
            this.fps20MenuItem.Size = new System.Drawing.Size(105, 22);
            this.fps20MenuItem.Text = "20 fps";
            this.fps20MenuItem.Click += new System.EventHandler(this.Fps20MenuItem_Click);
            // 
            // fps25MenuItem
            // 
            this.fps25MenuItem.Name = "fps25MenuItem";
            this.fps25MenuItem.Size = new System.Drawing.Size(105, 22);
            this.fps25MenuItem.Text = "25 fps";
            this.fps25MenuItem.Click += new System.EventHandler(this.Fps25MenuItem_Click);
            // 
            // fps30MenuItem
            // 
            this.fps30MenuItem.Checked = true;
            this.fps30MenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.fps30MenuItem.Name = "fps30MenuItem";
            this.fps30MenuItem.Size = new System.Drawing.Size(105, 22);
            this.fps30MenuItem.Text = "30 fps";
            this.fps30MenuItem.Click += new System.EventHandler(this.Fps30MenuItem_Click);
            // 
            // fps40MenuItem
            // 
            this.fps40MenuItem.Name = "fps40MenuItem";
            this.fps40MenuItem.Size = new System.Drawing.Size(105, 22);
            this.fps40MenuItem.Text = "40 fps";
            this.fps40MenuItem.Click += new System.EventHandler(this.Fps40MenuItem_Click);
            // 
            // fps50MenuItem
            // 
            this.fps50MenuItem.Name = "fps50MenuItem";
            this.fps50MenuItem.Size = new System.Drawing.Size(105, 22);
            this.fps50MenuItem.Text = "50 fps";
            this.fps50MenuItem.Click += new System.EventHandler(this.Fps50MenuItem_Click);
            // 
            // fps60MenuItem
            // 
            this.fps60MenuItem.Name = "fps60MenuItem";
            this.fps60MenuItem.Size = new System.Drawing.Size(105, 22);
            this.fps60MenuItem.Text = "60 fps";
            this.fps60MenuItem.Click += new System.EventHandler(this.Fps60MenuItem_Click);
            // 
            // toolStripSeparator20
            // 
            this.toolStripSeparator20.Name = "toolStripSeparator20";
            this.toolStripSeparator20.Size = new System.Drawing.Size(210, 6);
            // 
            // removeAllClonesMenuItem
            // 
            this.removeAllClonesMenuItem.Enabled = false;
            this.removeAllClonesMenuItem.Name = "removeAllClonesMenuItem";
            this.removeAllClonesMenuItem.Size = new System.Drawing.Size(213, 22);
            this.removeAllClonesMenuItem.Text = "Remove All Clones";
            this.removeAllClonesMenuItem.Click += new System.EventHandler(this.RemoveAllClonesMenuItem_Click);
            // 
            // toolStripSeparator39
            // 
            this.toolStripSeparator39.Name = "toolStripSeparator39";
            this.toolStripSeparator39.Size = new System.Drawing.Size(152, 6);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(152, 6);
            // 
            // overlayMenuMenuItem
            // 
            this.overlayMenuMenuItem.Name = "overlayMenuMenuItem";
            this.overlayMenuMenuItem.Size = new System.Drawing.Size(155, 22);
            this.overlayMenuMenuItem.Text = "Show Overlay Menu";
            this.overlayMenuMenuItem.Click += new System.EventHandler(this.OverlayMenuMenuItem_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(152, 6);
            // 
            // toolStripSeparator15
            // 
            this.toolStripSeparator15.Name = "toolStripSeparator15";
            this.toolStripSeparator15.Size = new System.Drawing.Size(152, 6);
            // 
            // videoSizeMenuItem
            // 
            this.videoSizeMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoomVideoMenuItem,
            this.moveVideoMenuItem,
            this.stretchVideoMenuItem});
            this.videoSizeMenuItem.Name = "videoSizeMenuItem";
            this.videoSizeMenuItem.Size = new System.Drawing.Size(155, 22);
            this.videoSizeMenuItem.Text = "Video Size";
            // 
            // zoomVideoMenuItem
            // 
            this.zoomVideoMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoomInMenuItem,
            this.zoomOutToolMenuItem});
            this.zoomVideoMenuItem.Name = "zoomVideoMenuItem";
            this.zoomVideoMenuItem.Size = new System.Drawing.Size(144, 22);
            this.zoomVideoMenuItem.Text = "Zoom Video";
            // 
            // zoomInMenuItem
            // 
            this.zoomInMenuItem.Name = "zoomInMenuItem";
            this.zoomInMenuItem.Size = new System.Drawing.Size(129, 22);
            this.zoomInMenuItem.Text = "Zoom In";
            this.zoomInMenuItem.Click += new System.EventHandler(this.ZoomInMenuItem_Click);
            // 
            // zoomOutToolMenuItem
            // 
            this.zoomOutToolMenuItem.Name = "zoomOutToolMenuItem";
            this.zoomOutToolMenuItem.Size = new System.Drawing.Size(129, 22);
            this.zoomOutToolMenuItem.Text = "Zoom Out";
            this.zoomOutToolMenuItem.Click += new System.EventHandler(this.ZoomOutMenuItem_Click);
            // 
            // moveVideoMenuItem
            // 
            this.moveVideoMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.moveUpMenuItem,
            this.moveDownMenuItem,
            this.toolStripSeparator32,
            this.moveLeftMenuItem,
            this.moveRightMenuItem});
            this.moveVideoMenuItem.Name = "moveVideoMenuItem";
            this.moveVideoMenuItem.Size = new System.Drawing.Size(144, 22);
            this.moveVideoMenuItem.Text = "Move Video";
            // 
            // moveUpMenuItem
            // 
            this.moveUpMenuItem.Name = "moveUpMenuItem";
            this.moveUpMenuItem.Size = new System.Drawing.Size(138, 22);
            this.moveUpMenuItem.Text = "Move Up";
            this.moveUpMenuItem.Click += new System.EventHandler(this.MoveUpMenuItem_Click);
            // 
            // moveDownMenuItem
            // 
            this.moveDownMenuItem.Name = "moveDownMenuItem";
            this.moveDownMenuItem.Size = new System.Drawing.Size(138, 22);
            this.moveDownMenuItem.Text = "Move Down";
            this.moveDownMenuItem.Click += new System.EventHandler(this.MoveDownMenuItem_Click);
            // 
            // toolStripSeparator32
            // 
            this.toolStripSeparator32.Name = "toolStripSeparator32";
            this.toolStripSeparator32.Size = new System.Drawing.Size(135, 6);
            // 
            // moveLeftMenuItem
            // 
            this.moveLeftMenuItem.Name = "moveLeftMenuItem";
            this.moveLeftMenuItem.Size = new System.Drawing.Size(138, 22);
            this.moveLeftMenuItem.Text = "Move Left";
            this.moveLeftMenuItem.Click += new System.EventHandler(this.MoveLeftMenuItem_Click);
            // 
            // moveRightMenuItem
            // 
            this.moveRightMenuItem.Name = "moveRightMenuItem";
            this.moveRightMenuItem.Size = new System.Drawing.Size(138, 22);
            this.moveRightMenuItem.Text = "Move Right";
            this.moveRightMenuItem.Click += new System.EventHandler(this.MoveRightMenuItem_Click);
            // 
            // stretchVideoMenuItem
            // 
            this.stretchVideoMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stretchHeightMenuItem,
            this.shrinkHeightMenuItem,
            this.toolStripSeparator33,
            this.stretchWidthMenuItem,
            this.shrinkWidthMenuItem});
            this.stretchVideoMenuItem.Name = "stretchVideoMenuItem";
            this.stretchVideoMenuItem.Size = new System.Drawing.Size(144, 22);
            this.stretchVideoMenuItem.Text = "Stretch Video";
            // 
            // stretchHeightMenuItem
            // 
            this.stretchHeightMenuItem.Name = "stretchHeightMenuItem";
            this.stretchHeightMenuItem.Size = new System.Drawing.Size(150, 22);
            this.stretchHeightMenuItem.Text = "Stretch Height";
            this.stretchHeightMenuItem.Click += new System.EventHandler(this.StretchHeightMenuItem_Click);
            // 
            // shrinkHeightMenuItem
            // 
            this.shrinkHeightMenuItem.Name = "shrinkHeightMenuItem";
            this.shrinkHeightMenuItem.Size = new System.Drawing.Size(150, 22);
            this.shrinkHeightMenuItem.Text = "Shrink Height";
            this.shrinkHeightMenuItem.Click += new System.EventHandler(this.ShrinkHeightMenuItem_Click);
            // 
            // toolStripSeparator33
            // 
            this.toolStripSeparator33.Name = "toolStripSeparator33";
            this.toolStripSeparator33.Size = new System.Drawing.Size(147, 6);
            // 
            // stretchWidthMenuItem
            // 
            this.stretchWidthMenuItem.Name = "stretchWidthMenuItem";
            this.stretchWidthMenuItem.Size = new System.Drawing.Size(150, 22);
            this.stretchWidthMenuItem.Text = "Stretch Width";
            this.stretchWidthMenuItem.Click += new System.EventHandler(this.StretchWidthMenuItem_Click);
            // 
            // shrinkWidthMenuItem
            // 
            this.shrinkWidthMenuItem.Name = "shrinkWidthMenuItem";
            this.shrinkWidthMenuItem.Size = new System.Drawing.Size(150, 22);
            this.shrinkWidthMenuItem.Text = "Shrink Width";
            this.shrinkWidthMenuItem.Click += new System.EventHandler(this.ShrinkWidthMenuItem_Click);
            // 
            // videoColorMenuItem
            // 
            this.videoColorMenuItem.Name = "videoColorMenuItem";
            this.videoColorMenuItem.Size = new System.Drawing.Size(155, 22);
            this.videoColorMenuItem.Text = "Video Color";
            this.videoColorMenuItem.Click += new System.EventHandler(this.VideoColorMenuItem_Click);
            // 
            // toolStripSeparator41
            // 
            this.toolStripSeparator41.Name = "toolStripSeparator41";
            this.toolStripSeparator41.Size = new System.Drawing.Size(152, 6);
            // 
            // screencopyMenuItem
            // 
            this.screencopyMenuItem.DropDown = this.screenCopyMenu;
            this.screencopyMenuItem.Name = "screencopyMenuItem";
            this.screencopyMenuItem.Size = new System.Drawing.Size(155, 22);
            this.screencopyMenuItem.Text = "Screen Copy";
            // 
            // screenCopyMenu
            // 
            this.screenCopyMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyMenuItem,
            this.copyModeMenuItem,
            this.toolStripSeparator1,
            this.openCopyMenuItem,
            this.openWithCopyMenuItem,
            this.toolStripSeparator12,
            this.clearCopyMenuItem});
            this.screenCopyMenu.Name = "screenCopyMenu";
            this.screenCopyMenu.OwnerItem = this.screencopyMenuItem;
            this.screenCopyMenu.ShowImageMargin = false;
            this.screenCopyMenu.Size = new System.Drawing.Size(135, 126);
            // 
            // copyMenuItem
            // 
            this.copyMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.copyMenuItem.Name = "copyMenuItem";
            this.copyMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.copyMenuItem.Size = new System.Drawing.Size(134, 22);
            this.copyMenuItem.Text = "Copy";
            this.copyMenuItem.Click += new System.EventHandler(this.CopyMenuItem_Click);
            // 
            // copyModeMenuItem
            // 
            this.copyModeMenuItem.DropDown = this.copyModeMenu;
            this.copyModeMenuItem.Name = "copyModeMenuItem";
            this.copyModeMenuItem.Size = new System.Drawing.Size(134, 22);
            this.copyModeMenuItem.Text = "Copy Mode";
            // 
            // copyModeMenu
            // 
            this.copyModeMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.videoCopyModeMenuItem,
            this.displayCopyModeMenuItem,
            this.parentCopyModeMenuItem,
            this.formCopyModeMenuItem,
            this.screenCopyModeMenuItem});
            this.copyModeMenu.Name = "copyModeMenu";
            this.copyModeMenu.OwnerItem = this.copyModeMenuItem;
            this.copyModeMenu.Size = new System.Drawing.Size(113, 114);
            this.copyModeMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.CopyModeMenu_ItemClicked);
            // 
            // videoCopyModeMenuItem
            // 
            this.videoCopyModeMenuItem.Checked = true;
            this.videoCopyModeMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.videoCopyModeMenuItem.Name = "videoCopyModeMenuItem";
            this.videoCopyModeMenuItem.Size = new System.Drawing.Size(112, 22);
            this.videoCopyModeMenuItem.Text = "Video";
            // 
            // displayCopyModeMenuItem
            // 
            this.displayCopyModeMenuItem.Name = "displayCopyModeMenuItem";
            this.displayCopyModeMenuItem.Size = new System.Drawing.Size(112, 22);
            this.displayCopyModeMenuItem.Text = "Display";
            // 
            // parentCopyModeMenuItem
            // 
            this.parentCopyModeMenuItem.Name = "parentCopyModeMenuItem";
            this.parentCopyModeMenuItem.Size = new System.Drawing.Size(112, 22);
            this.parentCopyModeMenuItem.Text = "Parent";
            // 
            // formCopyModeMenuItem
            // 
            this.formCopyModeMenuItem.Name = "formCopyModeMenuItem";
            this.formCopyModeMenuItem.Size = new System.Drawing.Size(112, 22);
            this.formCopyModeMenuItem.Text = "Form";
            // 
            // screenCopyModeMenuItem
            // 
            this.screenCopyModeMenuItem.Name = "screenCopyModeMenuItem";
            this.screenCopyModeMenuItem.Size = new System.Drawing.Size(112, 22);
            this.screenCopyModeMenuItem.Text = "Screen";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(131, 6);
            // 
            // openCopyMenuItem
            // 
            this.openCopyMenuItem.Enabled = false;
            this.openCopyMenuItem.Name = "openCopyMenuItem";
            this.openCopyMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.openCopyMenuItem.Size = new System.Drawing.Size(134, 22);
            this.openCopyMenuItem.Text = "Open";
            this.openCopyMenuItem.Click += new System.EventHandler(this.OpenCopyMenuItem_Click);
            // 
            // openWithCopyMenuItem
            // 
            this.openWithCopyMenuItem.Enabled = false;
            this.openWithCopyMenuItem.Name = "openWithCopyMenuItem";
            this.openWithCopyMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.openWithCopyMenuItem.Size = new System.Drawing.Size(134, 22);
            this.openWithCopyMenuItem.Text = "Open With…";
            this.openWithCopyMenuItem.Click += new System.EventHandler(this.OpenWithMenuItem_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(131, 6);
            // 
            // clearCopyMenuItem
            // 
            this.clearCopyMenuItem.Enabled = false;
            this.clearCopyMenuItem.Name = "clearCopyMenuItem";
            this.clearCopyMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F3)));
            this.clearCopyMenuItem.Size = new System.Drawing.Size(134, 22);
            this.clearCopyMenuItem.Text = "Clear";
            this.clearCopyMenuItem.Click += new System.EventHandler(this.ClearCopyMenuItem_Click);
            // 
            // toolStripSeparator17
            // 
            this.toolStripSeparator17.Name = "toolStripSeparator17";
            this.toolStripSeparator17.Size = new System.Drawing.Size(152, 6);
            // 
            // systemMenuItem
            // 
            this.systemMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.systemDisplayMenuItem,
            this.toolStripSeparator26,
            this.systemSoundMenuItem,
            this.systemMixerMenuItem,
            this.toolStripSeparator37,
            this.channelMixerMenuItem});
            this.systemMenuItem.Name = "systemMenuItem";
            this.systemMenuItem.Size = new System.Drawing.Size(155, 22);
            this.systemMenuItem.Text = "System Settings";
            // 
            // systemDisplayMenuItem
            // 
            this.systemDisplayMenuItem.Name = "systemDisplayMenuItem";
            this.systemDisplayMenuItem.Size = new System.Drawing.Size(151, 22);
            this.systemDisplayMenuItem.Text = "Display";
            this.systemDisplayMenuItem.Click += new System.EventHandler(this.DisplayModeLabel_Click);
            // 
            // toolStripSeparator26
            // 
            this.toolStripSeparator26.Name = "toolStripSeparator26";
            this.toolStripSeparator26.Size = new System.Drawing.Size(148, 6);
            // 
            // systemSoundMenuItem
            // 
            this.systemSoundMenuItem.Name = "systemSoundMenuItem";
            this.systemSoundMenuItem.Size = new System.Drawing.Size(151, 22);
            this.systemSoundMenuItem.Text = "Audio Devices";
            this.systemSoundMenuItem.Click += new System.EventHandler(this.SystemSoundMenuItem_Click);
            // 
            // systemMixerMenuItem
            // 
            this.systemMixerMenuItem.Name = "systemMixerMenuItem";
            this.systemMixerMenuItem.Size = new System.Drawing.Size(151, 22);
            this.systemMixerMenuItem.Text = "Volume Mixer";
            this.systemMixerMenuItem.Click += new System.EventHandler(this.SystemMixerMenuItem_Click);
            // 
            // toolStripSeparator37
            // 
            this.toolStripSeparator37.Name = "toolStripSeparator37";
            this.toolStripSeparator37.Size = new System.Drawing.Size(148, 6);
            // 
            // channelMixerMenuItem
            // 
            this.channelMixerMenuItem.Name = "channelMixerMenuItem";
            this.channelMixerMenuItem.Size = new System.Drawing.Size(151, 22);
            this.channelMixerMenuItem.Text = "Channel Mixer";
            this.channelMixerMenuItem.Click += new System.EventHandler(this.AudioVolumesMenuItem_Click);
            // 
            // preferencesMenuItem
            // 
            this.preferencesMenuItem.Name = "preferencesMenuItem";
            this.preferencesMenuItem.Size = new System.Drawing.Size(155, 22);
            this.preferencesMenuItem.Text = "Preferences";
            this.preferencesMenuItem.Click += new System.EventHandler(this.PreferencesMenuItem_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(152, 6);
            // 
            // quitMenuItem
            // 
            this.quitMenuItem.Name = "quitMenuItem";
            this.quitMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.quitMenuItem.Size = new System.Drawing.Size(155, 22);
            this.quitMenuItem.Text = "Quit";
            this.quitMenuItem.Click += new System.EventHandler(this.QuitMenuItem_Click);
            // 
            // balanceDialLabel
            // 
            this.balanceDialLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.balanceDialLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.balanceDialLabel.ContextMenuStrip = this.sliderMenu;
            this.balanceDialLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.balanceDialLabel.Location = new System.Drawing.Point(70, 117);
            this.balanceDialLabel.Name = "balanceDialLabel";
            this.balanceDialLabel.Size = new System.Drawing.Size(59, 21);
            this.balanceDialLabel.TabIndex = 9;
            this.balanceDialLabel.Text = "Center";
            this.balanceDialLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.balanceDialLabel, "Player.Audio.Balance - shows the audio balance setting of the player.");
            // 
            // volumeDialLabel
            // 
            this.volumeDialLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.volumeDialLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.volumeDialLabel.ContextMenuStrip = this.sliderMenu;
            this.volumeDialLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.volumeDialLabel.Location = new System.Drawing.Point(9, 117);
            this.volumeDialLabel.Name = "volumeDialLabel";
            this.volumeDialLabel.Size = new System.Drawing.Size(59, 21);
            this.volumeDialLabel.TabIndex = 8;
            this.volumeDialLabel.Text = "Max";
            this.volumeDialLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.volumeDialLabel, "Player.Audio.Volume - shows the audio volume setting of the player.");
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.ContextMenuStrip = this.screenCopyMenu;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Location = new System.Drawing.Point(9, 31);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(121, 68);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox1, "Player.ScreenCopy - copies (part of) the screen.");
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBox_MouseDown);
            this.pictureBox1.MouseEnter += new System.EventHandler(this.PictureBox1_MouseEnter);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.PictureBox1_MouseLeave);
            // 
            // channelCountLabel
            // 
            this.channelCountLabel.BackColor = System.Drawing.Color.Transparent;
            this.channelCountLabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.channelCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.channelCountLabel.ForeColor = System.Drawing.Color.Lime;
            this.channelCountLabel.Location = new System.Drawing.Point(62, 59);
            this.channelCountLabel.Name = "channelCountLabel";
            this.channelCountLabel.Size = new System.Drawing.Size(14, 10);
            this.channelCountLabel.TabIndex = 13;
            this.channelCountLabel.Text = "0";
            this.channelCountLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolTip1.SetToolTip(this.channelCountLabel, "Player.Audio.ChannelCount - the number of channels in the active audio track.");
            this.channelCountLabel.Visible = false;
            // 
            // audioDeviceMenu
            // 
            this.audioDeviceMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.audioDevicesToolStripMenuItem,
            this.audioMixerToolStripMenuItem,
            this.channelVolumesMenuItem,
            this.toolStripSeparator31,
            this.systemDefaultToolStripMenuItem});
            this.audioDeviceMenu.Name = "audioDeviceMenu";
            this.audioDeviceMenu.Size = new System.Drawing.Size(168, 98);
            this.audioDeviceMenu.Closing += new System.Windows.Forms.ToolStripDropDownClosingEventHandler(this.AudioDeviceMenu_Closing);
            this.audioDeviceMenu.Opening += new System.ComponentModel.CancelEventHandler(this.AudioDeviceMenu_Opening);
            this.audioDeviceMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.AudioDeviceMenu_ItemClicked);
            // 
            // audioDevicesToolStripMenuItem
            // 
            this.audioDevicesToolStripMenuItem.Name = "audioDevicesToolStripMenuItem";
            this.audioDevicesToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.audioDevicesToolStripMenuItem.Text = "Audio Devices";
            // 
            // audioMixerToolStripMenuItem
            // 
            this.audioMixerToolStripMenuItem.Name = "audioMixerToolStripMenuItem";
            this.audioMixerToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.audioMixerToolStripMenuItem.Text = "Volume Mixer";
            // 
            // channelVolumesMenuItem
            // 
            this.channelVolumesMenuItem.Name = "channelVolumesMenuItem";
            this.channelVolumesMenuItem.Size = new System.Drawing.Size(167, 22);
            this.channelVolumesMenuItem.Text = "Channel Mixer";
            this.channelVolumesMenuItem.Click += new System.EventHandler(this.AudioVolumesMenuItem_Click);
            // 
            // toolStripSeparator31
            // 
            this.toolStripSeparator31.Name = "toolStripSeparator31";
            this.toolStripSeparator31.Size = new System.Drawing.Size(164, 6);
            // 
            // systemDefaultToolStripMenuItem
            // 
            this.systemDefaultToolStripMenuItem.Checked = true;
            this.systemDefaultToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.systemDefaultToolStripMenuItem.Name = "systemDefaultToolStripMenuItem";
            this.systemDefaultToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.systemDefaultToolStripMenuItem.Text = "[ System Default ]";
            // 
            // positionSliderMenu
            // 
            this.positionSliderMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sliderAlwaysVisibleMenuItem,
            this.sliderShowsProgressMenuItem,
            this.toolStripSeparator40,
            this.slidersShowInfoLabelsMenuItem,
            this.sliderMousePreviewMenuItem,
            this.toolStripSeparator35,
            this.sliderSeekLiveUpdateMenuItem,
            this.sliderSeekSilentMenuItem,
            this.toolStripSeparator13,
            this.mouseWheelMenuItem,
            this.toolStripSeparator27,
            this.markStartPositionMenuItem,
            this.markEndPositionMenuItem,
            this.goToStartMenuItem,
            this.toolStripSeparator14,
            this.markPositionMenuItem,
            this.goToMarkMenuItem,
            this.toolStripSeparator42,
            this.chaptersAppleMenuItem,
            this.chaptersNeroMenuItem});
            this.positionSliderMenu.Name = "positionSliderMenu";
            this.positionSliderMenu.Size = new System.Drawing.Size(220, 348);
            this.positionSliderMenu.Closing += new System.Windows.Forms.ToolStripDropDownClosingEventHandler(this.PositionSliderMenu_Closing);
            this.positionSliderMenu.Opening += new System.ComponentModel.CancelEventHandler(this.PositionSliderMenu_Opening);
            // 
            // sliderAlwaysVisibleMenuItem
            // 
            this.sliderAlwaysVisibleMenuItem.Checked = true;
            this.sliderAlwaysVisibleMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.sliderAlwaysVisibleMenuItem.Name = "sliderAlwaysVisibleMenuItem";
            this.sliderAlwaysVisibleMenuItem.Size = new System.Drawing.Size(219, 22);
            this.sliderAlwaysVisibleMenuItem.Text = "Slider Always Visible";
            this.sliderAlwaysVisibleMenuItem.Click += new System.EventHandler(this.SliderAlwayVisibleMenuItem_Click);
            // 
            // sliderShowsProgressMenuItem
            // 
            this.sliderShowsProgressMenuItem.Name = "sliderShowsProgressMenuItem";
            this.sliderShowsProgressMenuItem.Size = new System.Drawing.Size(219, 22);
            this.sliderShowsProgressMenuItem.Text = "Slider Shows Progress";
            this.sliderShowsProgressMenuItem.Click += new System.EventHandler(this.SliderShowsProgressMenuItem_Click);
            // 
            // toolStripSeparator40
            // 
            this.toolStripSeparator40.Name = "toolStripSeparator40";
            this.toolStripSeparator40.Size = new System.Drawing.Size(216, 6);
            // 
            // slidersShowInfoLabelsMenuItem
            // 
            this.slidersShowInfoLabelsMenuItem.Name = "slidersShowInfoLabelsMenuItem";
            this.slidersShowInfoLabelsMenuItem.Size = new System.Drawing.Size(219, 22);
            this.slidersShowInfoLabelsMenuItem.Text = "Slider Shows Scroll Label";
            this.slidersShowInfoLabelsMenuItem.Click += new System.EventHandler(this.SlidersShowInfoLabelsMenuItem_Click);
            // 
            // sliderMousePreviewMenuItem
            // 
            this.sliderMousePreviewMenuItem.Name = "sliderMousePreviewMenuItem";
            this.sliderMousePreviewMenuItem.Size = new System.Drawing.Size(219, 22);
            this.sliderMousePreviewMenuItem.Text = "Slider Shows Hover Preview";
            this.sliderMousePreviewMenuItem.Click += new System.EventHandler(this.SliderMousePreviewMenuItem_Click);
            // 
            // toolStripSeparator35
            // 
            this.toolStripSeparator35.Name = "toolStripSeparator35";
            this.toolStripSeparator35.Size = new System.Drawing.Size(216, 6);
            // 
            // sliderSeekLiveUpdateMenuItem
            // 
            this.sliderSeekLiveUpdateMenuItem.Name = "sliderSeekLiveUpdateMenuItem";
            this.sliderSeekLiveUpdateMenuItem.Size = new System.Drawing.Size(219, 22);
            this.sliderSeekLiveUpdateMenuItem.Text = "Slider Seek Live Update";
            this.sliderSeekLiveUpdateMenuItem.Click += new System.EventHandler(this.SliderSeekLiveUpdateMenuItem_Click);
            // 
            // sliderSeekSilentMenuItem
            // 
            this.sliderSeekSilentMenuItem.Name = "sliderSeekSilentMenuItem";
            this.sliderSeekSilentMenuItem.Size = new System.Drawing.Size(219, 22);
            this.sliderSeekSilentMenuItem.Text = "Slider Seek Always Silent";
            this.sliderSeekSilentMenuItem.Click += new System.EventHandler(this.SliderSeekSilentMenuItem_Click);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(216, 6);
            // 
            // mouseWheelMenuItem
            // 
            this.mouseWheelMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sec12MenuItem,
            this.sec1MenuItem,
            this.sec5MenuItem,
            this.sec10MenuItem,
            this.sec15MenuItem,
            this.sec30MenuItem,
            this.sec60MenuItem,
            this.toolStripSeparator30,
            this.secOffMenuItem});
            this.mouseWheelMenuItem.Name = "mouseWheelMenuItem";
            this.mouseWheelMenuItem.Size = new System.Drawing.Size(219, 22);
            this.mouseWheelMenuItem.Text = "Slider Mouse Wheel";
            // 
            // sec12MenuItem
            // 
            this.sec12MenuItem.Name = "sec12MenuItem";
            this.sec12MenuItem.Size = new System.Drawing.Size(132, 22);
            this.sec12MenuItem.Text = "½ second";
            this.sec12MenuItem.Click += new System.EventHandler(this.Sec12MenuItem_Click);
            // 
            // sec1MenuItem
            // 
            this.sec1MenuItem.Name = "sec1MenuItem";
            this.sec1MenuItem.Size = new System.Drawing.Size(132, 22);
            this.sec1MenuItem.Text = "  1 second";
            this.sec1MenuItem.Click += new System.EventHandler(this.Sec1MenuItem_Click);
            // 
            // sec5MenuItem
            // 
            this.sec5MenuItem.Name = "sec5MenuItem";
            this.sec5MenuItem.Size = new System.Drawing.Size(132, 22);
            this.sec5MenuItem.Text = "  5 seconds";
            this.sec5MenuItem.Click += new System.EventHandler(this.Sec5MenuItem_Click);
            // 
            // sec10MenuItem
            // 
            this.sec10MenuItem.Name = "sec10MenuItem";
            this.sec10MenuItem.Size = new System.Drawing.Size(132, 22);
            this.sec10MenuItem.Text = "10 seconds";
            this.sec10MenuItem.Click += new System.EventHandler(this.Sec10MenuItem_Click);
            // 
            // sec15MenuItem
            // 
            this.sec15MenuItem.Name = "sec15MenuItem";
            this.sec15MenuItem.Size = new System.Drawing.Size(132, 22);
            this.sec15MenuItem.Text = "15 seconds";
            this.sec15MenuItem.Click += new System.EventHandler(this.Sec15MenuItem_Click);
            // 
            // sec30MenuItem
            // 
            this.sec30MenuItem.Name = "sec30MenuItem";
            this.sec30MenuItem.Size = new System.Drawing.Size(132, 22);
            this.sec30MenuItem.Text = "30 seconds";
            this.sec30MenuItem.Click += new System.EventHandler(this.Sec30MenuItem_Click);
            // 
            // sec60MenuItem
            // 
            this.sec60MenuItem.Name = "sec60MenuItem";
            this.sec60MenuItem.Size = new System.Drawing.Size(132, 22);
            this.sec60MenuItem.Text = "60 seconds";
            this.sec60MenuItem.Click += new System.EventHandler(this.Sec60MenuItem_Click);
            // 
            // toolStripSeparator30
            // 
            this.toolStripSeparator30.Name = "toolStripSeparator30";
            this.toolStripSeparator30.Size = new System.Drawing.Size(129, 6);
            // 
            // secOffMenuItem
            // 
            this.secOffMenuItem.Checked = true;
            this.secOffMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.secOffMenuItem.Name = "secOffMenuItem";
            this.secOffMenuItem.Size = new System.Drawing.Size(132, 22);
            this.secOffMenuItem.Text = "Off";
            this.secOffMenuItem.Click += new System.EventHandler(this.SecOffMenuItem_Click);
            // 
            // toolStripSeparator27
            // 
            this.toolStripSeparator27.Name = "toolStripSeparator27";
            this.toolStripSeparator27.Size = new System.Drawing.Size(216, 6);
            // 
            // chaptersAppleMenuItem
            // 
            this.chaptersAppleMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.noChaptersToolStripMenuItem});
            this.chaptersAppleMenuItem.Enabled = false;
            this.chaptersAppleMenuItem.Name = "chaptersAppleMenuItem";
            this.chaptersAppleMenuItem.Size = new System.Drawing.Size(219, 22);
            this.chaptersAppleMenuItem.Text = "Chapters I";
            // 
            // noChaptersToolStripMenuItem
            // 
            this.noChaptersToolStripMenuItem.Enabled = false;
            this.noChaptersToolStripMenuItem.Name = "noChaptersToolStripMenuItem";
            this.noChaptersToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.noChaptersToolStripMenuItem.Text = "No Chapters";
            // 
            // chaptersNeroMenuItem
            // 
            this.chaptersNeroMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.noChaptersToolStripMenuItem1});
            this.chaptersNeroMenuItem.Enabled = false;
            this.chaptersNeroMenuItem.Name = "chaptersNeroMenuItem";
            this.chaptersNeroMenuItem.Size = new System.Drawing.Size(219, 22);
            this.chaptersNeroMenuItem.Text = "Chapters II";
            // 
            // noChaptersToolStripMenuItem1
            // 
            this.noChaptersToolStripMenuItem1.Enabled = false;
            this.noChaptersToolStripMenuItem1.Name = "noChaptersToolStripMenuItem1";
            this.noChaptersToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.noChaptersToolStripMenuItem1.Text = "No Chapters";
            // 
            // toolStripSeparator42
            // 
            this.toolStripSeparator42.Name = "toolStripSeparator42";
            this.toolStripSeparator42.Size = new System.Drawing.Size(216, 6);
            // 
            // markStartPositionMenuItem
            // 
            this.markStartPositionMenuItem.Enabled = false;
            this.markStartPositionMenuItem.Name = "markStartPositionMenuItem";
            this.markStartPositionMenuItem.Size = new System.Drawing.Size(219, 22);
            this.markStartPositionMenuItem.Text = "Mark Repeat Start Position";
            this.markStartPositionMenuItem.Click += new System.EventHandler(this.MarkStartPositionMenuItem_Click);
            // 
            // markEndPositionMenuItem
            // 
            this.markEndPositionMenuItem.Enabled = false;
            this.markEndPositionMenuItem.Name = "markEndPositionMenuItem";
            this.markEndPositionMenuItem.Size = new System.Drawing.Size(219, 22);
            this.markEndPositionMenuItem.Text = "Mark Repeat Stop Position";
            this.markEndPositionMenuItem.Click += new System.EventHandler(this.MarkStopPositionMenuItem_Click);
            // 
            // goToStartMenuItem
            // 
            this.goToStartMenuItem.Enabled = false;
            this.goToStartMenuItem.Name = "goToStartMenuItem";
            this.goToStartMenuItem.Size = new System.Drawing.Size(219, 22);
            this.goToStartMenuItem.Text = "Go to Start Position";
            this.goToStartMenuItem.Click += new System.EventHandler(this.GoToStartMenuItem_Click);
            // 
            // toolStripSeparator14
            // 
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            this.toolStripSeparator14.Size = new System.Drawing.Size(216, 6);
            // 
            // markPositionMenuItem
            // 
            this.markPositionMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mark1_MenuItem,
            this.mark2_MenuItem,
            this.mark3_MenuItem,
            this.mark4_MenuItem});
            this.markPositionMenuItem.Enabled = false;
            this.markPositionMenuItem.Name = "markPositionMenuItem";
            this.markPositionMenuItem.Size = new System.Drawing.Size(219, 22);
            this.markPositionMenuItem.Text = "Mark Position #";
            // 
            // mark1_MenuItem
            // 
            this.mark1_MenuItem.Name = "mark1_MenuItem";
            this.mark1_MenuItem.Size = new System.Drawing.Size(117, 22);
            this.mark1_MenuItem.Text = "Mark #1";
            this.mark1_MenuItem.Click += new System.EventHandler(this.Mark1_MenuItem_Click);
            // 
            // mark2_MenuItem
            // 
            this.mark2_MenuItem.Name = "mark2_MenuItem";
            this.mark2_MenuItem.Size = new System.Drawing.Size(117, 22);
            this.mark2_MenuItem.Text = "Mark #2";
            this.mark2_MenuItem.Click += new System.EventHandler(this.Mark2_MenuItem_Click);
            // 
            // mark3_MenuItem
            // 
            this.mark3_MenuItem.Name = "mark3_MenuItem";
            this.mark3_MenuItem.Size = new System.Drawing.Size(117, 22);
            this.mark3_MenuItem.Text = "Mark #3";
            this.mark3_MenuItem.Click += new System.EventHandler(this.Mark3_MenuItem_Click);
            // 
            // mark4_MenuItem
            // 
            this.mark4_MenuItem.Name = "mark4_MenuItem";
            this.mark4_MenuItem.Size = new System.Drawing.Size(117, 22);
            this.mark4_MenuItem.Text = "Mark #4";
            this.mark4_MenuItem.Click += new System.EventHandler(this.Mark4_MenuItem_Click);
            // 
            // goToMarkMenuItem
            // 
            this.goToMarkMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.goToMark1_MenuItem,
            this.goToMark2_MenuItem,
            this.goToMark3_MenuItem,
            this.goToMark4_MenuItem});
            this.goToMarkMenuItem.Enabled = false;
            this.goToMarkMenuItem.Name = "goToMarkMenuItem";
            this.goToMarkMenuItem.Size = new System.Drawing.Size(219, 22);
            this.goToMarkMenuItem.Text = "Go to Position #";
            // 
            // goToMark1_MenuItem
            // 
            this.goToMark1_MenuItem.Name = "goToMark1_MenuItem";
            this.goToMark1_MenuItem.Size = new System.Drawing.Size(149, 22);
            this.goToMark1_MenuItem.Text = "Go to Mark #1";
            this.goToMark1_MenuItem.Click += new System.EventHandler(this.GoToMark1_MenuItem_Click);
            // 
            // goToMark2_MenuItem
            // 
            this.goToMark2_MenuItem.Name = "goToMark2_MenuItem";
            this.goToMark2_MenuItem.Size = new System.Drawing.Size(149, 22);
            this.goToMark2_MenuItem.Text = "Go to Mark #2";
            this.goToMark2_MenuItem.Click += new System.EventHandler(this.GoToMark2_MenuItem_Click);
            // 
            // goToMark3_MenuItem
            // 
            this.goToMark3_MenuItem.Name = "goToMark3_MenuItem";
            this.goToMark3_MenuItem.Size = new System.Drawing.Size(149, 22);
            this.goToMark3_MenuItem.Text = "Go to Mark #3";
            this.goToMark3_MenuItem.Click += new System.EventHandler(this.GoToMark3_MenuItem_Click);
            // 
            // goToMark4_MenuItem
            // 
            this.goToMark4_MenuItem.Name = "goToMark4_MenuItem";
            this.goToMark4_MenuItem.Size = new System.Drawing.Size(149, 22);
            this.goToMark4_MenuItem.Text = "Go to Mark #4";
            this.goToMark4_MenuItem.Click += new System.EventHandler(this.GoToMark4_MenuItem_Click);
            // 
            // displayParentPanel
            // 
            this.displayParentPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.displayParentPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.displayParentPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.displayParentPanel.Controls.Add(this.displayPanel);
            this.displayParentPanel.Controls.Add(this.positionSliderPanel);
            this.displayParentPanel.Location = new System.Drawing.Point(166, 8);
            this.displayParentPanel.Name = "displayParentPanel";
            this.displayParentPanel.Size = new System.Drawing.Size(642, 505);
            this.displayParentPanel.TabIndex = 1;
            // 
            // rightFramePanel
            // 
            this.rightFramePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rightFramePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.rightFramePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rightFramePanel.Controls.Add(this.shuttlePanel);
            this.rightFramePanel.Controls.Add(this.screencopyPanel);
            this.rightFramePanel.Controls.Add(this.zoomPanel);
            this.rightFramePanel.Controls.Add(this.audioPanel);
            this.rightFramePanel.Location = new System.Drawing.Point(812, 8);
            this.rightFramePanel.Name = "rightFramePanel";
            this.rightFramePanel.Size = new System.Drawing.Size(155, 505);
            this.rightFramePanel.TabIndex = 2;
            // 
            // shuttlePanel
            // 
            this.shuttlePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.shuttlePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.shuttlePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.shuttlePanel.Controls.Add(this.shuttleSlider);
            this.shuttlePanel.Controls.Add(this.shuttleLabel);
            this.shuttlePanel.Location = new System.Drawing.Point(6, 417);
            this.shuttlePanel.Name = "shuttlePanel";
            this.shuttlePanel.Size = new System.Drawing.Size(141, 80);
            this.shuttlePanel.TabIndex = 3;
            // 
            // screencopyPanel
            // 
            this.screencopyPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.screencopyPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.screencopyPanel.Controls.Add(this.pictureBox1);
            this.screencopyPanel.Controls.Add(this.copyLabelPanel);
            this.screencopyPanel.Location = new System.Drawing.Point(6, 301);
            this.screencopyPanel.Name = "screencopyPanel";
            this.screencopyPanel.Size = new System.Drawing.Size(141, 111);
            this.screencopyPanel.TabIndex = 2;
            // 
            // zoomPanel
            // 
            this.zoomPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.zoomPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.zoomPanel.Controls.Add(this.stretchRightButton);
            this.zoomPanel.Controls.Add(this.stretchLeftButton);
            this.zoomPanel.Controls.Add(this.stretchDownButton);
            this.zoomPanel.Controls.Add(this.stretchUpButton);
            this.zoomPanel.Controls.Add(this.zoomOutButton);
            this.zoomPanel.Controls.Add(this.zoomInButton);
            this.zoomPanel.Controls.Add(this.stretchLabel);
            this.zoomPanel.Controls.Add(this.zoomLabel);
            this.zoomPanel.Location = new System.Drawing.Point(6, 190);
            this.zoomPanel.Name = "zoomPanel";
            this.zoomPanel.Size = new System.Drawing.Size(141, 106);
            this.zoomPanel.TabIndex = 1;
            // 
            // audioPanel
            // 
            this.audioPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.audioPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.audioPanel.Controls.Add(this.channelCountLabel);
            this.audioPanel.Controls.Add(this.rightLevelMeterPanel);
            this.audioPanel.Controls.Add(this.leftLevelMeterPanel);
            this.audioPanel.Controls.Add(this.audioDeviceButton);
            this.audioPanel.Controls.Add(this.balanceDialLabel);
            this.audioPanel.Controls.Add(this.volumeDialLabel);
            this.audioPanel.Controls.Add(this.balanceDial);
            this.audioPanel.Controls.Add(this.volumeDial);
            this.audioPanel.Controls.Add(this.balanceDialTitle);
            this.audioPanel.Controls.Add(this.volumeDialTitle);
            this.audioPanel.Controls.Add(this.volumeLabelPanel);
            this.audioPanel.Location = new System.Drawing.Point(6, 6);
            this.audioPanel.Name = "audioPanel";
            this.audioPanel.Size = new System.Drawing.Size(141, 179);
            this.audioPanel.TabIndex = 0;
            // 
            // balanceDialTitle
            // 
            this.balanceDialTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.balanceDialTitle.Location = new System.Drawing.Point(73, 44);
            this.balanceDialTitle.Name = "balanceDialTitle";
            this.balanceDialTitle.Size = new System.Drawing.Size(55, 13);
            this.balanceDialTitle.TabIndex = 5;
            this.balanceDialTitle.Text = "Balance";
            this.balanceDialTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // volumeDialTitle
            // 
            this.volumeDialTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.volumeDialTitle.Location = new System.Drawing.Point(11, 44);
            this.volumeDialTitle.Name = "volumeDialTitle";
            this.volumeDialTitle.Size = new System.Drawing.Size(55, 13);
            this.volumeDialTitle.TabIndex = 4;
            this.volumeDialTitle.Text = "Volume";
            this.volumeDialTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // playSubMenu
            // 
            this.playSubMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playMenuItem,
            this.toolStripSeparator28,
            this.openLocationMenuItem,
            this.propertiesMenuItem,
            this.toolStripSeparator29,
            this.removeFromListMenuItem,
            this.toolStripSeparator7,
            this.sortListMenuItem,
            this.copyListToolStripMenuItem});
            this.playSubMenu.Name = "playSubMenu";
            this.playSubMenu.ShowImageMargin = false;
            this.playSubMenu.Size = new System.Drawing.Size(144, 154);
            this.playSubMenu.Closed += new System.Windows.Forms.ToolStripDropDownClosedEventHandler(this.PlaySubMenu_Closed);
            this.playSubMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.PlaySubMenu_ItemClicked);
            this.playSubMenu.MouseLeave += new System.EventHandler(this.PlaySubMenu_MouseLeave);
            // 
            // playMenuItem
            // 
            this.playMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.playMenuItem.Name = "playMenuItem";
            this.playMenuItem.Size = new System.Drawing.Size(143, 22);
            this.playMenuItem.Text = "Play";
            // 
            // toolStripSeparator28
            // 
            this.toolStripSeparator28.Name = "toolStripSeparator28";
            this.toolStripSeparator28.Size = new System.Drawing.Size(140, 6);
            // 
            // openLocationMenuItem
            // 
            this.openLocationMenuItem.Name = "openLocationMenuItem";
            this.openLocationMenuItem.Size = new System.Drawing.Size(143, 22);
            this.openLocationMenuItem.Text = "Open file location";
            // 
            // propertiesMenuItem
            // 
            this.propertiesMenuItem.Name = "propertiesMenuItem";
            this.propertiesMenuItem.Size = new System.Drawing.Size(143, 22);
            this.propertiesMenuItem.Text = "Properties";
            // 
            // toolStripSeparator29
            // 
            this.toolStripSeparator29.Name = "toolStripSeparator29";
            this.toolStripSeparator29.Size = new System.Drawing.Size(140, 6);
            // 
            // removeFromListMenuItem
            // 
            this.removeFromListMenuItem.Name = "removeFromListMenuItem";
            this.removeFromListMenuItem.Size = new System.Drawing.Size(143, 22);
            this.removeFromListMenuItem.Text = "Remove from List";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(140, 6);
            // 
            // sortListMenuItem
            // 
            this.sortListMenuItem.Name = "sortListMenuItem";
            this.sortListMenuItem.Size = new System.Drawing.Size(143, 22);
            this.sortListMenuItem.Text = "Sort List";
            // 
            // copyListToolStripMenuItem
            // 
            this.copyListToolStripMenuItem.Name = "copyListToolStripMenuItem";
            this.copyListToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.copyListToolStripMenuItem.Text = "Copy List as Text";
            // 
            // shuttleSlider
            // 
            this.shuttleSlider.AutoSize = false;
            this.shuttleSlider.Location = new System.Drawing.Point(2, 31);
            this.shuttleSlider.Name = "shuttleSlider";
            this.shuttleSlider.Size = new System.Drawing.Size(135, 45);
            this.shuttleSlider.TabIndex = 1;
            this.shuttleSlider.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.toolTip1.SetToolTip(this.shuttleSlider, "Player.Sliders.Shuttle - changes the media playback position by (video) frames.");
            this.shuttleSlider.Value = 5;
            // 
            // shuttleLabel
            // 
            this.shuttleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.shuttleLabel.Location = new System.Drawing.Point(9, 9);
            this.shuttleLabel.Name = "shuttleLabel";
            this.shuttleLabel.Size = new System.Drawing.Size(121, 21);
            this.shuttleLabel.TabIndex = 0;
            this.shuttleLabel.Text = "Shuttle";
            this.shuttleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // copyLabelPanel
            // 
            this.copyLabelPanel.Controls.Add(this.copyModeLabel);
            this.copyLabelPanel.Controls.Add(this.copyModeLabelText);
            this.copyLabelPanel.Location = new System.Drawing.Point(9, 10);
            this.copyLabelPanel.Name = "copyLabelPanel";
            this.copyLabelPanel.Size = new System.Drawing.Size(121, 22);
            this.copyLabelPanel.TabIndex = 0;
            // 
            // copyModeLabel
            // 
            this.copyModeLabel.BackColor = System.Drawing.Color.Transparent;
            this.copyModeLabel.ContextMenuStrip = this.copyModeMenu;
            this.copyModeLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.copyModeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.copyModeLabel.Location = new System.Drawing.Point(68, 3);
            this.copyModeLabel.Name = "copyModeLabel";
            this.copyModeLabel.Size = new System.Drawing.Size(51, 13);
            this.copyModeLabel.TabIndex = 1;
            this.copyModeLabel.Text = "Video";
            this.copyModeLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.toolTip1.SetToolTip(this.copyModeLabel, "Player.ScreenCopy.Mode - selects the part of the screen to copy.");
            this.copyModeLabel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CopyModeLabel_MouseClick);
            // 
            // copyModeLabelText
            // 
            this.copyModeLabelText.AutoSize = true;
            this.copyModeLabelText.BackColor = System.Drawing.Color.Transparent;
            this.copyModeLabelText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.copyModeLabelText.Location = new System.Drawing.Point(3, 3);
            this.copyModeLabelText.Name = "copyModeLabelText";
            this.copyModeLabelText.Size = new System.Drawing.Size(68, 13);
            this.copyModeLabelText.TabIndex = 0;
            this.copyModeLabelText.Text = "Screen Copy";
            // 
            // stretchRightButton
            // 
            this.stretchRightButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.stretchRightButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.stretchRightButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.stretchRightButton.Location = new System.Drawing.Point(101, 74);
            this.stretchRightButton.Name = "stretchRightButton";
            this.stretchRightButton.Size = new System.Drawing.Size(29, 20);
            this.stretchRightButton.TabIndex = 12;
            this.stretchRightButton.Text = "Æ";
            this.toolTip1.SetToolTip(this.stretchRightButton, "Player.Video.Move/Stretch - moves or changes the size of the video image on the d" +
        "isplay of the player.");
            this.stretchRightButton.UseVisualStyleBackColor = true;
            this.stretchRightButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.StretchRightButton_MouseDown);
            // 
            // stretchLeftButton
            // 
            this.stretchLeftButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.stretchLeftButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.stretchLeftButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.stretchLeftButton.Location = new System.Drawing.Point(70, 74);
            this.stretchLeftButton.Name = "stretchLeftButton";
            this.stretchLeftButton.Size = new System.Drawing.Size(29, 20);
            this.stretchLeftButton.TabIndex = 11;
            this.stretchLeftButton.Text = "Å";
            this.toolTip1.SetToolTip(this.stretchLeftButton, "Player.Video.Move/Stretch - moves or changes the size of the video image on the d" +
        "isplay of the player.");
            this.stretchLeftButton.UseVisualStyleBackColor = true;
            this.stretchLeftButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.StretchLeftButton_MouseDown);
            // 
            // stretchDownButton
            // 
            this.stretchDownButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.stretchDownButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.stretchDownButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.stretchDownButton.Location = new System.Drawing.Point(40, 74);
            this.stretchDownButton.Name = "stretchDownButton";
            this.stretchDownButton.Size = new System.Drawing.Size(28, 20);
            this.stretchDownButton.TabIndex = 10;
            this.stretchDownButton.Text = "È";
            this.toolTip1.SetToolTip(this.stretchDownButton, "Player.Video.Move/Stretch - moves or changes the size of the video image on the d" +
        "isplay of the player.");
            this.stretchDownButton.UseVisualStyleBackColor = true;
            this.stretchDownButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.StretchDownButton_MouseDown);
            // 
            // stretchUpButton
            // 
            this.stretchUpButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.stretchUpButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.stretchUpButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.stretchUpButton.Location = new System.Drawing.Point(9, 74);
            this.stretchUpButton.Name = "stretchUpButton";
            this.stretchUpButton.Size = new System.Drawing.Size(29, 20);
            this.stretchUpButton.TabIndex = 9;
            this.stretchUpButton.Text = "Ç";
            this.toolTip1.SetToolTip(this.stretchUpButton, "Player.Video.Move/Stretch - moves or changes the size of the video image on the d" +
        "isplay of the player.");
            this.stretchUpButton.UseVisualStyleBackColor = true;
            this.stretchUpButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.StretchUpButton_MouseDown);
            // 
            // zoomOutButton
            // 
            this.zoomOutButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.zoomOutButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.zoomOutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.zoomOutButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.zoomOutButton.Location = new System.Drawing.Point(70, 29);
            this.zoomOutButton.Name = "zoomOutButton";
            this.zoomOutButton.Size = new System.Drawing.Size(60, 20);
            this.zoomOutButton.TabIndex = 2;
            this.zoomOutButton.Text = "È";
            this.toolTip1.SetToolTip(this.zoomOutButton, "Player.Video.Zoom - changes the size of the video image on the display of the pla" +
        "yer.");
            this.zoomOutButton.UseVisualStyleBackColor = true;
            this.zoomOutButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ZoomOutButton_MouseDown);
            // 
            // zoomInButton
            // 
            this.zoomInButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.zoomInButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.zoomInButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.zoomInButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.zoomInButton.Location = new System.Drawing.Point(9, 29);
            this.zoomInButton.Name = "zoomInButton";
            this.zoomInButton.Size = new System.Drawing.Size(59, 20);
            this.zoomInButton.TabIndex = 1;
            this.zoomInButton.Text = "Ç";
            this.toolTip1.SetToolTip(this.zoomInButton, "Player.Video.Zoom - changes the size of the video image on the display of the pla" +
        "yer.");
            this.zoomInButton.UseVisualStyleBackColor = true;
            this.zoomInButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ZoomInButton_MouseDown);
            // 
            // stretchLabel
            // 
            this.stretchLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.stretchLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.stretchLabel.Location = new System.Drawing.Point(9, 55);
            this.stretchLabel.Name = "stretchLabel";
            this.stretchLabel.Size = new System.Drawing.Size(121, 19);
            this.stretchLabel.TabIndex = 8;
            this.stretchLabel.Text = "  Video Stretch ↨";
            this.stretchLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.stretchLabel, "Click to change between Video Move and Video Stretch mode.");
            this.stretchLabel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.StretchLabel_MouseClick);
            // 
            // zoomLabel
            // 
            this.zoomLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zoomLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.zoomLabel.Location = new System.Drawing.Point(9, 10);
            this.zoomLabel.Name = "zoomLabel";
            this.zoomLabel.Size = new System.Drawing.Size(121, 19);
            this.zoomLabel.TabIndex = 0;
            this.zoomLabel.Text = "Video Zoom";
            this.zoomLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rightLevelMeterPanel
            // 
            this.rightLevelMeterPanel.Location = new System.Drawing.Point(71, 31);
            this.rightLevelMeterPanel.Name = "rightLevelMeterPanel";
            this.rightLevelMeterPanel.Size = new System.Drawing.Size(59, 4);
            this.rightLevelMeterPanel.TabIndex = 12;
            this.toolTip1.SetToolTip(this.rightLevelMeterPanel, "Player.Events.MediaPeakLevelChanged - shows audio output level values.");
            this.rightLevelMeterPanel.Click += new System.EventHandler(this.LevelMeterPanels_Click);
            this.rightLevelMeterPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.RightLevelMeterPanel_Paint);
            // 
            // leftLevelMeterPanel
            // 
            this.leftLevelMeterPanel.Location = new System.Drawing.Point(9, 31);
            this.leftLevelMeterPanel.Name = "leftLevelMeterPanel";
            this.leftLevelMeterPanel.Size = new System.Drawing.Size(59, 4);
            this.leftLevelMeterPanel.TabIndex = 11;
            this.toolTip1.SetToolTip(this.leftLevelMeterPanel, "Player.Events.MediaPeakLevelChanged - shows audio output level values.");
            this.leftLevelMeterPanel.Click += new System.EventHandler(this.LevelMeterPanels_Click);
            this.leftLevelMeterPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.LeftLevelMeterPanel_Paint);
            // 
            // audioDeviceButton
            // 
            this.audioDeviceButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.audioDeviceButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.audioDeviceButton.DropDown = this.audioDeviceMenu;
            this.audioDeviceButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.audioDeviceButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.audioDeviceButton.Location = new System.Drawing.Point(9, 146);
            this.audioDeviceButton.Name = "audioDeviceButton";
            this.audioDeviceButton.Size = new System.Drawing.Size(121, 21);
            this.audioDeviceButton.TabIndex = 10;
            this.audioDeviceButton.Text = "Audio Device";
            this.audioDeviceButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.audioDeviceButton, "Player.Audio.Device - sets the audio output device of the player.");
            this.audioDeviceButton.UseMnemonic = false;
            this.audioDeviceButton.UseVisualStyleBackColor = true;
            // 
            // balanceDial
            // 
            this.balanceDial.ContextMenuStrip = this.sliderMenu;
            this.balanceDial.Image = global::PVSPlayerExample.Properties.Resources.Dial_Normal_2;
            this.balanceDial.IndicatorType = 1;
            this.balanceDial.Location = new System.Drawing.Point(73, 59);
            this.balanceDial.MaximumSize = new System.Drawing.Size(55, 55);
            this.balanceDial.MinimumSize = new System.Drawing.Size(55, 55);
            this.balanceDial.Name = "balanceDial";
            this.balanceDial.Size = new System.Drawing.Size(55, 55);
            this.balanceDial.TabIndex = 7;
            this.balanceDial.Text = "dial2";
            this.toolTip1.SetToolTip(this.balanceDial, "Player.Audio.Balance - sets the audio balance of the player.");
            this.balanceDial.Value = 500;
            // 
            // volumeDial
            // 
            this.volumeDial.ContextMenuStrip = this.sliderMenu;
            this.volumeDial.Image = global::PVSPlayerExample.Properties.Resources.Dial_Normal_2;
            this.volumeDial.IndicatorType = 0;
            this.volumeDial.Location = new System.Drawing.Point(11, 59);
            this.volumeDial.MaximumSize = new System.Drawing.Size(55, 55);
            this.volumeDial.MinimumSize = new System.Drawing.Size(55, 55);
            this.volumeDial.Name = "volumeDial";
            this.volumeDial.Size = new System.Drawing.Size(55, 55);
            this.volumeDial.TabIndex = 6;
            this.volumeDial.Text = "dial1";
            this.toolTip1.SetToolTip(this.volumeDial, "Player.Audio.Volume - sets the audio volume of the player.");
            this.volumeDial.Value = 1000;
            // 
            // volumeLabelPanel
            // 
            this.volumeLabelPanel.Controls.Add(this.audioLight);
            this.volumeLabelPanel.Controls.Add(this.audioTracksLabel);
            this.volumeLabelPanel.Controls.Add(this.audioVolumeLabelText);
            this.volumeLabelPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.volumeLabelPanel.Location = new System.Drawing.Point(9, 10);
            this.volumeLabelPanel.Name = "volumeLabelPanel";
            this.volumeLabelPanel.Size = new System.Drawing.Size(121, 22);
            this.volumeLabelPanel.TabIndex = 0;
            this.toolTip1.SetToolTip(this.volumeLabelPanel, "Player.Audio.Mute - disables the audio output of the player.");
            this.volumeLabelPanel.Click += new System.EventHandler(this.VolumeLabelPanel_Click);
            // 
            // audioLight
            // 
            this.audioLight.BackColor = System.Drawing.Color.Lime;
            this.audioLight.LightOn = true;
            this.audioLight.Location = new System.Drawing.Point(7, 7);
            this.audioLight.Name = "audioLight";
            this.audioLight.Size = new System.Drawing.Size(2, 6);
            this.audioLight.TabIndex = 10;
            this.toolTip1.SetToolTip(this.audioLight, "This indicator shows whether the player\'s audio is enabled.");
            // 
            // audioTracksLabel
            // 
            this.audioTracksLabel.BackColor = System.Drawing.Color.Transparent;
            this.audioTracksLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.audioTracksLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.audioTracksLabel.ForeColor = System.Drawing.Color.Lime;
            this.audioTracksLabel.Location = new System.Drawing.Point(100, 4);
            this.audioTracksLabel.Name = "audioTracksLabel";
            this.audioTracksLabel.Size = new System.Drawing.Size(16, 10);
            this.audioTracksLabel.TabIndex = 9;
            this.audioTracksLabel.Text = "1";
            this.audioTracksLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.toolTip1.SetToolTip(this.audioTracksLabel, "Player.Media.AudioTrackCount - the number of audio tracks in the playing media.");
            this.audioTracksLabel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.AudioTracksLabel_MouseClick);
            // 
            // audioVolumeLabelText
            // 
            this.audioVolumeLabelText.AutoSize = true;
            this.audioVolumeLabelText.BackColor = System.Drawing.Color.Transparent;
            this.audioVolumeLabelText.Cursor = System.Windows.Forms.Cursors.Hand;
            this.audioVolumeLabelText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.audioVolumeLabelText.Location = new System.Drawing.Point(45, 4);
            this.audioVolumeLabelText.Name = "audioVolumeLabelText";
            this.audioVolumeLabelText.Size = new System.Drawing.Size(34, 13);
            this.audioVolumeLabelText.TabIndex = 1;
            this.audioVolumeLabelText.Text = "Audio";
            this.toolTip1.SetToolTip(this.audioVolumeLabelText, "Player.Audio.Mute - disables the audio output of the player.");
            this.audioVolumeLabelText.Click += new System.EventHandler(this.VolumeLabelPanel_Click);
            // 
            // positionSliderPanel
            // 
            this.positionSliderPanel.ContextMenuStrip = this.positionSliderMenu;
            this.positionSliderPanel.Controls.Add(this.positionSlider);
            this.positionSliderPanel.Controls.Add(this.positionLabel2);
            this.positionSliderPanel.Controls.Add(this.positionLabel1);
            this.positionSliderPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.positionSliderPanel.Location = new System.Drawing.Point(0, 480);
            this.positionSliderPanel.Name = "positionSliderPanel";
            this.positionSliderPanel.Size = new System.Drawing.Size(640, 23);
            this.positionSliderPanel.TabIndex = 0;
            // 
            // positionSlider
            // 
            this.positionSlider.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.positionSlider.AutoSize = false;
            this.positionSlider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.positionSlider.ContextMenuStrip = this.positionSliderMenu;
            this.positionSlider.Enabled = false;
            this.positionSlider.Location = new System.Drawing.Point(81, 2);
            this.positionSlider.Name = "positionSlider";
            this.positionSlider.Size = new System.Drawing.Size(476, 26);
            this.positionSlider.TabIndex = 1;
            this.toolTip1.SetToolTip(this.positionSlider, "Player.Sliders.Position.TrackBar - shows and allows changing of the playback posi" +
        "tion of the playing media.");
            // 
            // positionLabel2
            // 
            this.positionLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.positionLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.positionLabel2.ContextMenuStrip = this.positionSliderMenu;
            this.positionLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.positionLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.positionLabel2.Location = new System.Drawing.Point(557, 1);
            this.positionLabel2.Name = "positionLabel2";
            this.positionLabel2.Size = new System.Drawing.Size(81, 18);
            this.positionLabel2.TabIndex = 2;
            this.positionLabel2.Text = "00:00:00";
            this.toolTip1.SetToolTip(this.positionLabel2, "Player.Position.ToEnd (.ToStop) - the duration of the playing media to the end of" +
        " the media (or to the \'StopTime\').");
            // 
            // positionLabel1
            // 
            this.positionLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.positionLabel1.ContextMenuStrip = this.positionSliderMenu;
            this.positionLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.positionLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.positionLabel1.Location = new System.Drawing.Point(3, 1);
            this.positionLabel1.Name = "positionLabel1";
            this.positionLabel1.Size = new System.Drawing.Size(82, 18);
            this.positionLabel1.TabIndex = 0;
            this.positionLabel1.Text = "00:00:00";
            this.toolTip1.SetToolTip(this.positionLabel1, "Player.Position.FromBegin (.FromStart) - the duration of the playing media from t" +
        "he beginning of the media (or from the \'StartTime\').");
            // 
            // speedSlider
            // 
            this.speedSlider.AutoSize = false;
            this.speedSlider.ContextMenuStrip = this.sliderMenu;
            this.speedSlider.Location = new System.Drawing.Point(2, 32);
            this.speedSlider.Name = "speedSlider";
            this.speedSlider.Size = new System.Drawing.Size(135, 45);
            this.speedSlider.TabIndex = 1;
            this.speedSlider.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.toolTip1.SetToolTip(this.speedSlider, "Player.Sliders.Speed - sets the media playback speed of the player.");
            this.speedSlider.Value = 5;
            // 
            // speedLabelPanel
            // 
            this.speedLabelPanel.Controls.Add(this.speedTextBox);
            this.speedLabelPanel.Controls.Add(this.speedLight);
            this.speedLabelPanel.Controls.Add(this.speedLabelText);
            this.speedLabelPanel.Location = new System.Drawing.Point(9, 9);
            this.speedLabelPanel.Name = "speedLabelPanel";
            this.speedLabelPanel.Size = new System.Drawing.Size(121, 22);
            this.speedLabelPanel.TabIndex = 0;
            // 
            // speedTextBox
            // 
            this.speedTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.speedTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.speedTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.speedTextBox.Location = new System.Drawing.Point(92, 4);
            this.speedTextBox.Mask = "0.00";
            this.speedTextBox.Name = "speedTextBox";
            this.speedTextBox.Size = new System.Drawing.Size(23, 13);
            this.speedTextBox.TabIndex = 2;
            this.speedTextBox.Text = "100";
            this.toolTip1.SetToolTip(this.speedTextBox, "Player.Speed.Rate - sets the media playback speed of the player.");
            this.speedTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SpeedTextBox_KeyPress);
            this.speedTextBox.Validated += new System.EventHandler(this.SpeedTextBox_Validated);
            // 
            // speedLight
            // 
            this.speedLight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.speedLight.Location = new System.Drawing.Point(7, 8);
            this.speedLight.Name = "speedLight";
            this.speedLight.Size = new System.Drawing.Size(2, 6);
            this.speedLight.TabIndex = 0;
            this.toolTip1.SetToolTip(this.speedLight, "This indicator shows whether the playback speed is different from the normal play" +
        "back speed.");
            // 
            // speedLabelText
            // 
            this.speedLabelText.AutoSize = true;
            this.speedLabelText.BackColor = System.Drawing.Color.Transparent;
            this.speedLabelText.ContextMenuStrip = this.sliderMenu;
            this.speedLabelText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.speedLabelText.Location = new System.Drawing.Point(41, 4);
            this.speedLabelText.Name = "speedLabelText";
            this.speedLabelText.Size = new System.Drawing.Size(38, 13);
            this.speedLabelText.TabIndex = 1;
            this.speedLabelText.Text = "Speed";
            // 
            // repeatLight
            // 
            this.repeatLight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.repeatLight.Location = new System.Drawing.Point(16, 17);
            this.repeatLight.Name = "repeatLight";
            this.repeatLight.Size = new System.Drawing.Size(2, 6);
            this.repeatLight.TabIndex = 1;
            this.toolTip1.SetToolTip(this.repeatLight, "This indicator shows whether a repeat option is active.");
            // 
            // repeatButton
            // 
            this.repeatButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.repeatButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.repeatButton.DropDown = this.repeatMenu;
            this.repeatButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.repeatButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.repeatButton.Location = new System.Drawing.Point(9, 9);
            this.repeatButton.Name = "repeatButton";
            this.repeatButton.Size = new System.Drawing.Size(121, 21);
            this.repeatButton.TabIndex = 0;
            this.repeatButton.Text = "Repeat Off";
            this.repeatButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.repeatButton, "Player.Repeat - repeats media playback from \'StartTime\' to \'StopTime\'.");
            this.repeatButton.UseVisualStyleBackColor = false;
            // 
            // nextFromLabel
            // 
            this.nextFromLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.nextFromLabel.Location = new System.Drawing.Point(9, 35);
            this.nextFromLabel.Name = "nextFromLabel";
            this.nextFromLabel.Size = new System.Drawing.Size(121, 19);
            this.nextFromLabel.TabIndex = 2;
            this.nextFromLabel.Text = "Play Next From - To";
            this.nextFromLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // currentFromLabel
            // 
            this.currentFromLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.currentFromLabel.Location = new System.Drawing.Point(9, 81);
            this.currentFromLabel.Name = "currentFromLabel";
            this.currentFromLabel.Size = new System.Drawing.Size(121, 19);
            this.currentFromLabel.TabIndex = 5;
            this.currentFromLabel.Text = "Play Current From - To";
            this.currentFromLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // displayLight
            // 
            this.displayLight.BackColor = System.Drawing.Color.Lime;
            this.displayLight.LightOn = true;
            this.displayLight.Location = new System.Drawing.Point(16, 17);
            this.displayLight.Name = "displayLight";
            this.displayLight.Size = new System.Drawing.Size(2, 6);
            this.displayLight.TabIndex = 11;
            this.toolTip1.SetToolTip(this.displayLight, "This indicator shows whether the player has a display.");
            // 
            // overlayMenuLight
            // 
            this.overlayMenuLight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.overlayMenuLight.Location = new System.Drawing.Point(16, 120);
            this.overlayMenuLight.Name = "overlayMenuLight";
            this.overlayMenuLight.Size = new System.Drawing.Size(2, 6);
            this.overlayMenuLight.TabIndex = 8;
            this.toolTip1.SetToolTip(this.overlayMenuLight, "This indicator shows whether a display overlay menu is active.");
            // 
            // overlayLight
            // 
            this.overlayLight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.overlayLight.Location = new System.Drawing.Point(16, 94);
            this.overlayLight.Name = "overlayLight";
            this.overlayLight.Size = new System.Drawing.Size(2, 6);
            this.overlayLight.TabIndex = 6;
            this.toolTip1.SetToolTip(this.overlayLight, "This indicator shows whether a display overlay is active.");
            // 
            // displayOverlayButton
            // 
            this.displayOverlayButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.displayOverlayButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.displayOverlayButton.DropDown = this.displayOverlayMenu;
            this.displayOverlayButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displayOverlayButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.displayOverlayButton.Location = new System.Drawing.Point(9, 86);
            this.displayOverlayButton.Name = "displayOverlayButton";
            this.displayOverlayButton.Size = new System.Drawing.Size(121, 21);
            this.displayOverlayButton.TabIndex = 5;
            this.displayOverlayButton.Text = "Overlay Off";
            this.displayOverlayButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.displayOverlayButton, "Player.Overlay.Window - shows or hides a display overlay of the player.");
            this.displayOverlayButton.UseVisualStyleBackColor = true;
            // 
            // fullScreenLight
            // 
            this.fullScreenLight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.fullScreenLight.Location = new System.Drawing.Point(16, 68);
            this.fullScreenLight.Name = "fullScreenLight";
            this.fullScreenLight.Size = new System.Drawing.Size(2, 6);
            this.fullScreenLight.TabIndex = 4;
            this.toolTip1.SetToolTip(this.fullScreenLight, "This indicator shows whether a fullscreen mode is selected.");
            // 
            // fullScreenModeButton
            // 
            this.fullScreenModeButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.fullScreenModeButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fullScreenModeButton.DropDown = this.fullScreenModeMenu;
            this.fullScreenModeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fullScreenModeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.fullScreenModeButton.Location = new System.Drawing.Point(9, 60);
            this.fullScreenModeButton.Name = "fullScreenModeButton";
            this.fullScreenModeButton.Size = new System.Drawing.Size(121, 21);
            this.fullScreenModeButton.TabIndex = 3;
            this.fullScreenModeButton.Text = "Full Screen Off";
            this.fullScreenModeButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.fullScreenModeButton, "Player.FullScreen / Player.FullScreenMode - sets the full screen display mode of " +
        "the player.");
            this.fullScreenModeButton.UseVisualStyleBackColor = true;
            // 
            // displayModeLight
            // 
            this.displayModeLight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.displayModeLight.Location = new System.Drawing.Point(16, 42);
            this.displayModeLight.Name = "displayModeLight";
            this.displayModeLight.Size = new System.Drawing.Size(2, 6);
            this.displayModeLight.TabIndex = 2;
            this.toolTip1.SetToolTip(this.displayModeLight, "This indicator shows whether the display mode is different from the standard disp" +
        "lay mode.");
            // 
            // displayModeButton
            // 
            this.displayModeButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.displayModeButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.displayModeButton.DropDown = this.displayModeMenu;
            this.displayModeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(163)))), ((int)(((byte)(136)))));
            this.displayModeButton.Location = new System.Drawing.Point(9, 34);
            this.displayModeButton.Name = "displayModeButton";
            this.displayModeButton.Size = new System.Drawing.Size(121, 21);
            this.displayModeButton.TabIndex = 1;
            this.displayModeButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.displayModeButton, "Player.Display.Mode - sets the size and position of the video on the display of t" +
        "he player.");
            this.displayModeButton.UseVisualStyleBackColor = true;
            // 
            // displayModeLabel
            // 
            this.displayModeLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.displayModeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.displayModeLabel.Location = new System.Drawing.Point(9, 9);
            this.displayModeLabel.Name = "displayModeLabel";
            this.displayModeLabel.Size = new System.Drawing.Size(121, 21);
            this.displayModeLabel.TabIndex = 0;
            this.displayModeLabel.Text = "Display";
            this.displayModeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.displayModeLabel, "Player.ControlPanels.ShowDisplaySettings - opens the system\'s Display Control Pan" +
        "el.");
            this.displayModeLabel.Click += new System.EventHandler(this.DisplayModeLabel_Click);
            // 
            // overlayMenuButton
            // 
            this.overlayMenuButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.overlayMenuButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.overlayMenuButton.Location = new System.Drawing.Point(9, 112);
            this.overlayMenuButton.Name = "overlayMenuButton";
            this.overlayMenuButton.Size = new System.Drawing.Size(121, 21);
            this.overlayMenuButton.TabIndex = 7;
            this.overlayMenuButton.Text = "Overlay Menu";
            this.toolTip1.SetToolTip(this.overlayMenuButton, "Shows or hides the menu (if any) of the active display overlay.");
            this.overlayMenuButton.UseVisualStyleBackColor = true;
            this.overlayMenuButton.Click += new System.EventHandler(this.OverlayMenuButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.stopButton.Font = new System.Drawing.Font("Webdings", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.stopButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.stopButton.Location = new System.Drawing.Point(101, 32);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(29, 20);
            this.stopButton.TabIndex = 5;
            this.stopButton.Text = "<";
            this.stopButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.stopButton, "Player.Stop - stops playing media.");
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // nextButton
            // 
            this.nextButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.nextButton.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.nextButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.nextButton.Location = new System.Drawing.Point(70, 32);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(29, 20);
            this.nextButton.TabIndex = 4;
            this.nextButton.Text = ":";
            this.nextButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.nextButton, "Plays the next item in the playlist.");
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // previousButton
            // 
            this.previousButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.previousButton.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.previousButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.previousButton.Location = new System.Drawing.Point(40, 32);
            this.previousButton.Name = "previousButton";
            this.previousButton.Size = new System.Drawing.Size(28, 20);
            this.previousButton.TabIndex = 3;
            this.previousButton.Text = "9";
            this.previousButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.previousButton, "Plays the previous item in the playlist.");
            this.previousButton.UseVisualStyleBackColor = true;
            this.previousButton.Click += new System.EventHandler(this.PreviousButton_Click);
            // 
            // pauseButton
            // 
            this.pauseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pauseButton.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.pauseButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.pauseButton.Location = new System.Drawing.Point(9, 32);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(29, 20);
            this.pauseButton.TabIndex = 2;
            this.pauseButton.Text = ";";
            this.pauseButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.pauseButton, "Player.Pause - pauses playing media / Player.Resume - resumes paused media.");
            this.pauseButton.Click += new System.EventHandler(this.PauseButton_Click);
            // 
            // playButtonLight
            // 
            this.playButtonLight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.playButtonLight.Location = new System.Drawing.Point(16, 17);
            this.playButtonLight.Name = "playButtonLight";
            this.playButtonLight.Size = new System.Drawing.Size(2, 6);
            this.playButtonLight.TabIndex = 1;
            this.toolTip1.SetToolTip(this.playButtonLight, "This indicator shows whether media is playing.");
            // 
            // playButton
            // 
            this.playButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.playButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.playButton.DropDown = this.playMenu;
            this.playButton.Font = new System.Drawing.Font("Webdings", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.playButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.playButton.Location = new System.Drawing.Point(9, 9);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(121, 21);
            this.playButton.TabIndex = 0;
            this.playButton.Text = "4";
            this.playButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.playButton, "Player.Play - plays media.");
            this.playButton.UseVisualStyleBackColor = true;
            // 
            // titlePanel
            // 
            this.titlePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.titlePanel.Controls.Add(this.clockLabel);
            this.titlePanel.Controls.Add(this.webSiteLabel);
            this.titlePanel.Controls.Add(this.nameLabel);
            this.titlePanel.Location = new System.Drawing.Point(6, 6);
            this.titlePanel.Name = "titlePanel";
            this.titlePanel.Size = new System.Drawing.Size(141, 51);
            this.titlePanel.TabIndex = 0;
            // 
            // clockLabel
            // 
            this.clockLabel.BackColor = System.Drawing.Color.Transparent;
            this.clockLabel.Cursor = System.Windows.Forms.Cursors.Help;
            this.clockLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clockLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.clockLabel.Location = new System.Drawing.Point(7, 8);
            this.clockLabel.Name = "clockLabel";
            this.clockLabel.Size = new System.Drawing.Size(128, 34);
            this.clockLabel.TabIndex = 0;
            this.clockLabel.Text = "00:00:00";
            this.toolTip1.SetToolTip(this.clockLabel, "About the PVS.MediaPlayer library.");
            this.clockLabel.Visible = false;
            this.clockLabel.Click += new System.EventHandler(this.NameLabel_Click);
            // 
            // webSiteLabel
            // 
            this.webSiteLabel.AutoSize = true;
            this.webSiteLabel.BackColor = System.Drawing.Color.Transparent;
            this.webSiteLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.webSiteLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.webSiteLabel.Location = new System.Drawing.Point(14, 26);
            this.webSiteLabel.Name = "webSiteLabel";
            this.webSiteLabel.Size = new System.Drawing.Size(113, 13);
            this.webSiteLabel.TabIndex = 1;
            this.webSiteLabel.Text = "www.codeproject.com";
            this.toolTip1.SetToolTip(this.webSiteLabel, "About the CodeProject® website.");
            this.webSiteLabel.Click += new System.EventHandler(this.WebSiteLabel_Click);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.BackColor = System.Drawing.Color.Transparent;
            this.nameLabel.Cursor = System.Windows.Forms.Cursors.Help;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.nameLabel.Location = new System.Drawing.Point(13, 8);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(115, 16);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "PVS.MediaPlayer";
            this.toolTip1.SetToolTip(this.nameLabel, "About the PVS.MediaPlayer library.");
            this.nameLabel.Click += new System.EventHandler(this.NameLabel_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(974, 519);
            this.Controls.Add(this.rightFramePanel);
            this.Controls.Add(this.displayParentPanel);
            this.Controls.Add(this.leftFramePanel);
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(557, 558);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.Resize += new System.EventHandler(this.MainWindow_Resize);
            this.leftFramePanel.ResumeLayout(false);
            this.speedPanel.ResumeLayout(false);
            this.sliderMenu.ResumeLayout(false);
            this.repeatPanel.ResumeLayout(false);
            this.repeatPanel.PerformLayout();
            this.repeatMenu.ResumeLayout(false);
            this.displayModePanel.ResumeLayout(false);
            this.displayOverlayMenu.ResumeLayout(false);
            this.fullScreenModeMenu.ResumeLayout(false);
            this.playPanel.ResumeLayout(false);
            this.playMenu.ResumeLayout(false);
            this.displayMenu.ResumeLayout(false);
            this.audioTracks.ResumeLayout(false);
            this.videoTracks.ResumeLayout(false);
            this.screenCopyMenu.ResumeLayout(false);
            this.copyModeMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.audioDeviceMenu.ResumeLayout(false);
            this.positionSliderMenu.ResumeLayout(false);
            this.displayParentPanel.ResumeLayout(false);
            this.rightFramePanel.ResumeLayout(false);
            this.shuttlePanel.ResumeLayout(false);
            this.screencopyPanel.ResumeLayout(false);
            this.zoomPanel.ResumeLayout(false);
            this.audioPanel.ResumeLayout(false);
            this.playSubMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.shuttleSlider)).EndInit();
            this.copyLabelPanel.ResumeLayout(false);
            this.copyLabelPanel.PerformLayout();
            this.volumeLabelPanel.ResumeLayout(false);
            this.volumeLabelPanel.PerformLayout();
            this.positionSliderPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.positionSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedSlider)).EndInit();
            this.speedLabelPanel.ResumeLayout(false);
            this.speedLabelPanel.PerformLayout();
            this.titlePanel.ResumeLayout(false);
            this.titlePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel leftFramePanel;
        private CustomPanel titlePanel;
        private Label webSiteLabel;
        private ToolTip toolTip1;
        private Label nameLabel;
        private Panel playPanel;
        private LightPanel playButtonLight;
        private DropDownButton playButton;
        private Panel displayModePanel;
        private DropDownButton displayModeButton;
        private HeadLabel displayModeLabel;
        private LightPanel fullScreenLight;
        private DropDownButton fullScreenModeButton;
        private LightPanel displayModeLight;
        private DropDownButton displayOverlayButton;
        private LightPanel overlayLight;
        private Panel repeatPanel;
        private MaskedTextBox stopTimeNextTextBox;
        private MaskedTextBox startTimeNextTextBox;
        private HeadLabel nextFromLabel;
        private MaskedTextBox stopTimeTextBox;
        private MaskedTextBox startTimeTextBox;
        private HeadLabel currentFromLabel;
        private Panel speedPanel;
        private CustomPanel speedLabelPanel;
        private Label speedLabelText;
        private Panel displayParentPanel;
        private Label positionLabel2;
        private Label positionLabel1;
        private Panel rightFramePanel;
        private Panel audioPanel;
        private CustomPanel volumeLabelPanel;
        private Label audioVolumeLabelText;
        private Panel zoomPanel;
        private HeadLabel zoomLabel;
        private Panel screencopyPanel;
        private CustomPanel copyLabelPanel;
        private PictureBox pictureBox1;
        private Label copyModeLabel;
        private Label copyModeLabelText;
        private Panel shuttlePanel;
        private HeadLabel shuttleLabel;
        private ToolStripMenuItem playListMenuItem;
        private ToolStripMenuItem addMediaFilesMenuItem;
        private ToolStripSeparator menuSeparator1;
        private ContextMenuStrip displayModeMenu;
        private ContextMenuStrip fullScreenModeMenu;
        private ToolStripMenuItem fullScreenFormMenuItem;
        private ToolStripMenuItem fullScreenParentMenuItem;
        private ToolStripMenuItem fullScreenDisplayMenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem fullScreenOffMenuItem;
        private ContextMenuStrip displayOverlayMenu;
        private ToolStripMenuItem overlayModeToolStripMenuItem;
        private ToolStripMenuItem videoMenuItem;
        private ToolStripMenuItem displayMenuItem;
        private ToolStripMenuItem overlayHoldMenuItem;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripMenuItem messageMenuItem;
        private ToolStripMenuItem scribbleMenuItem;
        private ToolStripMenuItem bouncingMenuItem;
        private ToolStripMenuItem PiPMenuItem;
        private ToolStripMenuItem tilesMenuItem;
        private ToolStripMenuItem MP3CoverMenuItem;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripMenuItem overlayOffMenuItem;
        private ContextMenuStrip playSubMenu;
        private ToolStripMenuItem playMenuItem;
        private ToolStripMenuItem removeFromListMenuItem;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripMenuItem sortListMenuItem;
        private ContextMenuStrip displayMenu;
        private ToolStripMenuItem playDisplayMenuItem;
        private ToolStripMenuItem pauseMenuItem;
        private ToolStripMenuItem stopMenuItem;
        private ToolStripSeparator toolStripSeparator8;
        private ToolStripMenuItem displayModeMenuItem;
        private ToolStripMenuItem fullScreenModeMenuItem;
        private ToolStripMenuItem displayOverlayMenuItem;
        private ToolStripSeparator toolStripSeparator9;
        private ToolStripMenuItem videoSizeMenuItem;
        private ToolStripMenuItem zoomVideoMenuItem;
        private ToolStripMenuItem moveVideoMenuItem;
        private ToolStripMenuItem screencopyMenuItem;
        private ToolStripSeparator toolStripSeparator11;
        private ToolStripMenuItem newPlayListMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem openPlayListMenuItem;
        private ToolStripMenuItem addPlayListMenuItem;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem savePlayListMenuItem;
        private ContextMenuStrip screenCopyMenu;
        private ToolStripMenuItem copyMenuItem;
        private ToolStripMenuItem copyModeMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem openCopyMenuItem;
        private ToolStripMenuItem openWithCopyMenuItem;
        private ToolStripSeparator toolStripSeparator12;
        private ToolStripMenuItem clearCopyMenuItem;
        private ContextMenuStrip positionSliderMenu;
        private ToolStripMenuItem sliderAlwaysVisibleMenuItem;
        private ToolStripMenuItem sliderShowsProgressMenuItem;
        private ToolStripMenuItem sliderSeekLiveUpdateMenuItem;
        private ToolStripSeparator toolStripSeparator13;
        private ToolStripMenuItem markStartPositionMenuItem;
        private ToolStripMenuItem markEndPositionMenuItem;
        private ToolStripSeparator toolStripSeparator14;
        private ToolStripMenuItem markPositionMenuItem;
        private ToolStripMenuItem goToMarkMenuItem;
        private ToolStripMenuItem goToStartMenuItem;
        private ContextMenuStrip sliderMenu;
        private ToolStripMenuItem sliderMenuItem1;
        private ToolStripMenuItem sliderMenuItem2;
        private ToolStripMenuItem sliderMenuItem3;
        private ToolStripMenuItem subtitlesMenuItem;
        private ContextMenuStrip copyModeMenu;
        private ToolStripMenuItem videoCopyModeMenuItem;
        private ToolStripMenuItem displayCopyModeMenuItem;
        private ToolStripMenuItem parentCopyModeMenuItem;
        private ToolStripMenuItem formCopyModeMenuItem;
        private ToolStripMenuItem screenCopyModeMenuItem;
        internal ContextMenuStrip playMenu;
        private ToolStripMenuItem addMediaURLMenuItem;
        private ToolStripSeparator toolStripSeparator16;
        private ToolStripMenuItem quitMenuItem;
        private ToolStripSeparator toolStripSeparator17;
        private ToolStripMenuItem zoomSelectMenuItem;
        private ToolStripMenuItem statusInfoMenuItem;
        private HeadLabel stretchLabel;
        private ToolStripMenuItem nextMenuItem;
        private ToolStripMenuItem previousMenuItem;
        private ToolStripMenuItem bigTimeMenuItem;
        private SliderPanel positionSliderPanel;
        private CustomSlider2 speedSlider;
        private CustomSlider2 shuttleSlider;
        private CustomButton zoomInButton;
        private CustomButton zoomOutButton;
        private CustomButton stretchRightButton;
        private CustomButton stretchLeftButton;
        private CustomButton stretchDownButton;
        private CustomButton stretchUpButton;
        private CustomButton pauseButton;
        private CustomButton previousButton;
        private CustomButton stopButton;
        private CustomButton nextButton;
        private LightPanel repeatLight;
        private DropDownButton repeatButton;
        private ContextMenuStrip repeatMenu;
        private ToolStripMenuItem repeatOneMenuItem;
        private ToolStripMenuItem repeatAllMenuItem;
        private ToolStripSeparator toolStripSeparator18;
        private ToolStripMenuItem shuffleMenuItem;
        private ToolStripSeparator toolStripSeparator19;
        private ToolStripMenuItem repeatOffMenuItem;
        private LightPanel speedLight;
        private LightPanel overlayMenuLight;
        private CustomButton overlayMenuButton;
        private ToolStripSeparator tracksMenuSeparator;
        private ToolStripMenuItem repeatMenuItem;
        private ToolStripSeparator toolStripSeparator21;
        private ToolStripSeparator toolStripSeparator22;
        private ToolStripSeparator toolStripSeparator24;
        private ToolStripSeparator toolStripSeparator23;
        private ToolStripSeparator toolStripSeparator25;
        private ToolStripMenuItem MP3KaraokeMenuItem;
        private MaskedTextBox speedTextBox;
        private ToolStripMenuItem systemMenuItem;
        private ToolStripMenuItem systemDisplayMenuItem;
        private ToolStripSeparator toolStripSeparator26;
        private ToolStripMenuItem systemSoundMenuItem;
        private ToolStripMenuItem systemMixerMenuItem;
        private ToolStripMenuItem zoomInMenuItem;
        private ToolStripMenuItem zoomOutToolMenuItem;
        private ToolStripMenuItem moveUpMenuItem;
        private ToolStripMenuItem moveDownMenuItem;
        private ToolStripSeparator toolStripSeparator32;
        private ToolStripMenuItem moveLeftMenuItem;
        private ToolStripMenuItem moveRightMenuItem;
        private ToolStripMenuItem stretchVideoMenuItem;
        private ToolStripMenuItem stretchHeightMenuItem;
        private ToolStripMenuItem shrinkHeightMenuItem;
        private ToolStripSeparator toolStripSeparator33;
        private ToolStripMenuItem stretchWidthMenuItem;
        private ToolStripMenuItem shrinkWidthMenuItem;
        private ToolStripSeparator toolStripSeparator10;
        private ToolStripMenuItem videoWallMenuItem;
        private ToolStripMenuItem propertiesMenuItem;
        private ToolStripSeparator toolStripSeparator28;
        private ToolStripMenuItem openLocationMenuItem;
        private ToolStripSeparator toolStripSeparator29;
        private ToolStripMenuItem preferencesMenuItem;
        internal Panel displayPanel;
        private Label clockLabel;
        private Label volumeDialTitle;
        private Dial balanceDial;
        private Dial volumeDial;
        private Label balanceDialTitle;
        private Label balanceDialLabel;
        private Label volumeDialLabel;
        private ToolStripMenuItem audioTracksMenuItem;
        private ContextMenuStrip audioTracks;
        private ToolStripMenuItem videoTracksMenuItem;
        private ContextMenuStrip videoTracks;
        private ToolStripSeparator toolStripSeparator15;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem2;
        private Label audioTracksLabel;
        private Label videoTracksLabel;
        private ToolStripMenuItem displayClonesMenuItem;
        private ToolStripMenuItem addCloneMenuItem;
        private ToolStripSeparator toolStripSeparator20;
        private ToolStripMenuItem removeAllClonesMenuItem;
        private ToolStripSeparator toolStripSeparator36;
        private ToolStripMenuItem showOverlayMenuItem;
        private ToolStripMenuItem refreshRateMenuItem;
        private ToolStripMenuItem fps01MenuItem;
        private ToolStripMenuItem fps02MenuItem;
        private ToolStripMenuItem fps05MenuItem;
        private ToolStripMenuItem fps10MenuItem;
        private ToolStripMenuItem fps15MenuItem;
        private ToolStripMenuItem fps20MenuItem;
        private ToolStripMenuItem fps25MenuItem;
        private ToolStripMenuItem fps30MenuItem;
        private ToolStripMenuItem fps40MenuItem;
        private ToolStripMenuItem fps50MenuItem;
        private ToolStripMenuItem fps60MenuItem;
        private ToolStripMenuItem sliderMousePreviewMenuItem;
        private ToolStripMenuItem slidersShowInfoLabelsMenuItem;
        private ToolStripMenuItem mark1_MenuItem;
        private ToolStripMenuItem mark2_MenuItem;
        private ToolStripMenuItem mark3_MenuItem;
        private ToolStripMenuItem mark4_MenuItem;
        private ToolStripMenuItem goToMark1_MenuItem;
        private ToolStripMenuItem goToMark2_MenuItem;
        private ToolStripMenuItem goToMark3_MenuItem;
        private ToolStripMenuItem goToMark4_MenuItem;
        private ToolStripMenuItem mouseWheelMenuItem;
        private ToolStripMenuItem sec12MenuItem;
        private ToolStripMenuItem sec1MenuItem;
        private ToolStripMenuItem sec5MenuItem;
        private ToolStripMenuItem sec10MenuItem;
        private ToolStripMenuItem sec15MenuItem;
        private ToolStripMenuItem sec30MenuItem;
        private ToolStripMenuItem sec60MenuItem;
        private ToolStripSeparator toolStripSeparator27;
        internal CustomSlider positionSlider;
        private ToolStripSeparator toolStripSeparator30;
        private ToolStripMenuItem secOffMenuItem;
        private ToolStripSeparator toolStripSeparator35;
        private ToolStripMenuItem sliderMenuItem4;
        private ToolStripMenuItem sliderMenuItem5;
        private ToolStripMenuItem displayShapeMenuItem;
        private ToolStripMenuItem ovalShapeMenuItem;
        private ToolStripMenuItem roundedShapeMenuItem;
        private ToolStripMenuItem crossShapeMenuItem;
        private ToolStripMenuItem diamondShapeMenuItem;
        private ToolStripMenuItem starShapeMenuItem;
        private ToolStripMenuItem arrowUpShapeMenuItem;
        private ToolStripMenuItem arrowDownShapeMenuItem;
        private ToolStripMenuItem arrowLeftShapeMenuItem;
        private ToolStripMenuItem arrowRightShapeMenuItem;
        private ToolStripMenuItem hexagonShapeMenuItem;
        private ToolStripSeparator toolStripSeparator34;
        private ToolStripMenuItem useVideoBoundsMenuItem;
        private ToolStripMenuItem setOverlayShapeMenuItem;
        private ToolStripSeparator toolStripSeparator38;
        private ToolStripMenuItem normalShapeMenuItem;
        private ToolStripMenuItem triangleDownMenuItem;
        private ToolStripMenuItem barsShapeMenuItem;
        private ToolStripMenuItem beamsShapeMenuItem;
        private ToolStripMenuItem tilesShapeMenuItem;
        private ToolStripSeparator toolStripSeparator39;
        private ToolStripMenuItem heartShapeMenuItem;
        private ContextMenuStrip audioDeviceMenu;
        private ToolStripMenuItem audioDevicesToolStripMenuItem;
        private ToolStripMenuItem audioMixerToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator31;
        private ToolStripMenuItem systemDefaultToolStripMenuItem;
        private ToolStripMenuItem copyListToolStripMenuItem;
        internal ToolStripMenuItem overlayMenuMenuItem;
        private BufferedPanel rightLevelMeterPanel;
        private BufferedPanel leftLevelMeterPanel;
        private ToolStripSeparator toolStripSeparator40;
        private ToolStripMenuItem sliderSeekSilentMenuItem;
        private LightPanel displayLight;
        private LightPanel audioLight;
        private ToolStripMenuItem frameShapeMenuItem;
        private ToolStripMenuItem rectangleShapeMenuItem;
        private ToolStripMenuItem ringShapeMenuItem;
        internal DropDownButton audioDeviceButton;
        private Label channelCountLabel;
        private ToolStripMenuItem triangleLeftMenuItem;
        private ToolStripMenuItem triangleRightMenuItem;
        private ToolStripMenuItem triangleUpMenuItem;
        private ToolStripMenuItem videoColorMenuItem;
        private ToolStripSeparator toolStripSeparator41;
        private ToolStripMenuItem channelVolumesMenuItem;
        private ToolStripMenuItem channelMixerMenuItem;
        private ToolStripSeparator toolStripSeparator37;
        private ToolStripMenuItem webcamsMenuItem;
        private ToolStripMenuItem noWebcamsToolStripMenuItem;
        private ToolStripMenuItem fullScreenFormAllMenuItem;
        private ToolStripMenuItem fullScreenParentAllMenuItem;
        private ToolStripMenuItem fullScreenDisplayAllMenuItem;
        private ToolStripMenuItem circleShapeMenuItem;
        private ToolStripMenuItem squareShapeMenuItem;
        private ToolStripSeparator toolStripSeparator42;
        private ToolStripMenuItem chaptersAppleMenuItem;
        private ToolStripMenuItem noChaptersToolStripMenuItem;
        private ToolStripMenuItem chaptersNeroMenuItem;
        private ToolStripMenuItem noChaptersToolStripMenuItem1;
    }
}

