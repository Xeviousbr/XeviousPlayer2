using System.ComponentModel;
using System.Windows.Forms;

namespace AVPlayerExample
{
    partial class Form1
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
            this.speedSlider = new AVPlayerExample.CustomSlider2();
            this.sliderMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.sliderMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.sliderMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.sliderMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.speedLabelPanel = new AVPlayerExample.CustomPanel();
            this.speedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.speedLight = new AVPlayerExample.LightPanel();
            this.speedLabelText = new System.Windows.Forms.Label();
            this.repeatPanel = new System.Windows.Forms.Panel();
            this.repeatLight = new AVPlayerExample.LightPanel();
            this.repeatButton = new AVPlayerExample.DropDownButton();
            this.repeatMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.repeatOneMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.repeatAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator18 = new System.Windows.Forms.ToolStripSeparator();
            this.shuffleMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator19 = new System.Windows.Forms.ToolStripSeparator();
            this.repeatOffMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.repeatMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nextFromLabel = new AVPlayerExample.HeadLabel();
            this.endPositionMediaTextBox = new System.Windows.Forms.MaskedTextBox();
            this.startPositionMediaTextBox = new System.Windows.Forms.MaskedTextBox();
            this.currentFromLabel = new AVPlayerExample.HeadLabel();
            this.endPositionTextBox = new System.Windows.Forms.MaskedTextBox();
            this.startPositionTextBox = new System.Windows.Forms.MaskedTextBox();
            this.displayModePanel = new System.Windows.Forms.Panel();
            this.overlayMenuLight = new AVPlayerExample.LightPanel();
            this.overlayLight = new AVPlayerExample.LightPanel();
            this.displayOverlayButton = new AVPlayerExample.DropDownButton();
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
            this.fullScreenLight = new AVPlayerExample.LightPanel();
            this.fullScreenModeButton = new AVPlayerExample.DropDownButton();
            this.fullScreenModeMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.fullScreenFormMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fullScreenParentMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fullScreenDisplayMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.fullScreenOffMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fullScreenModeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayModeLight = new AVPlayerExample.LightPanel();
            this.displayModeButton = new AVPlayerExample.DropDownButton();
            this.displayModeMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.displayModeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayModeLabel = new AVPlayerExample.HeadLabel();
            this.overlayMenuButton = new AVPlayerExample.CustomButton();
            this.playPanel = new System.Windows.Forms.Panel();
            this.stopButton = new AVPlayerExample.CustomButton();
            this.nextButton = new AVPlayerExample.CustomButton();
            this.previousButton = new AVPlayerExample.CustomButton();
            this.pauseButton = new AVPlayerExample.CustomButton();
            this.playButtonLight = new AVPlayerExample.LightPanel();
            this.playButton = new AVPlayerExample.DropDownButton();
            this.playMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.playListMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newPlayListMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.openPlayListMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addPlayListMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.savePlayListMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
            this.addMediaFilesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addMediaURLMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.playDisplayMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.titlePanel = new AVPlayerExample.CustomPanel();
            this.webSiteLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
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
            this.screencopyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayPanel = new System.Windows.Forms.Panel();
            this.displayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.previousMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pauseMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.overlayMenuMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator20 = new System.Windows.Forms.ToolStripSeparator();
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
            this.toolStripSeparator17 = new System.Windows.Forms.ToolStripSeparator();
            this.voiceRecorderMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showRecorderMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showPlayerMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator27 = new System.Windows.Forms.ToolStripSeparator();
            this.showAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hideAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator30 = new System.Windows.Forms.ToolStripSeparator();
            this.closeRecorderMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator31 = new System.Windows.Forms.ToolStripSeparator();
            this.systemMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.systemDisplayMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator26 = new System.Windows.Forms.ToolStripSeparator();
            this.systemSoundMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.systemMixerMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preferencesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.quitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shuttleSlider = new AVPlayerExample.CustomSlider2();
            this.copyModeLabel = new System.Windows.Forms.Label();
            this.stretchRightButton = new AVPlayerExample.CustomButton();
            this.stretchLeftButton = new AVPlayerExample.CustomButton();
            this.stretchDownButton = new AVPlayerExample.CustomButton();
            this.stretchUpButton = new AVPlayerExample.CustomButton();
            this.moveRightButton = new AVPlayerExample.CustomButton();
            this.moveLeftButton = new AVPlayerExample.CustomButton();
            this.moveDownButton = new AVPlayerExample.CustomButton();
            this.moveUpButton = new AVPlayerExample.CustomButton();
            this.zoomOutButton = new AVPlayerExample.CustomButton();
            this.zoomInButton = new AVPlayerExample.CustomButton();
            this.balanceSlider = new AVPlayerExample.CustomSlider2();
            this.volumeSlider = new AVPlayerExample.CustomSlider2();
            this.audioBalanceLabelText = new System.Windows.Forms.Label();
            this.audioVolumeLabelText = new System.Windows.Forms.Label();
            this.positionSlider = new AVPlayerExample.CustomSlider();
            this.positionSliderMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.sliderAlwaysVisibleMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sliderShowsProgressMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sliderSeekLiveUpdateMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.markStartPositionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.markEndPositionMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startRepeatMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.mark1MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goToMark1MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
            this.goToStartMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.positionLabel2 = new System.Windows.Forms.Label();
            this.positionLabel1 = new System.Windows.Forms.Label();
            this.displayParentPanel = new System.Windows.Forms.Panel();
            this.positionSliderPanel = new AVPlayerExample.SliderPanel();
            this.rightFramePanel = new System.Windows.Forms.Panel();
            this.shuttlePanel = new System.Windows.Forms.Panel();
            this.shuttleLabel = new AVPlayerExample.HeadLabel();
            this.sceencopyPanel = new System.Windows.Forms.Panel();
            this.copyLabelPanel = new AVPlayerExample.CustomPanel();
            this.copyModeLabelText = new System.Windows.Forms.Label();
            this.zoomPanel = new System.Windows.Forms.Panel();
            this.headLabel1 = new AVPlayerExample.HeadLabel();
            this.moveLabel = new AVPlayerExample.HeadLabel();
            this.zoomLabel = new AVPlayerExample.HeadLabel();
            this.audioPanel = new System.Windows.Forms.Panel();
            this.balanceLabelPanel = new AVPlayerExample.CustomPanel();
            this.audioBalanceLabel = new System.Windows.Forms.Label();
            this.volumeLabelPanel = new AVPlayerExample.CustomPanel();
            this.volumeLight = new AVPlayerExample.LightPanel();
            this.audioVolumeLabel = new System.Windows.Forms.Label();
            this.playSubMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.playMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator28 = new System.Windows.Forms.ToolStripSeparator();
            this.openLocationMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.propertiesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator29 = new System.Windows.Forms.ToolStripSeparator();
            this.removeFromListMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.sortListMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.leftFramePanel.SuspendLayout();
            this.speedPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speedSlider)).BeginInit();
            this.sliderMenu.SuspendLayout();
            this.speedLabelPanel.SuspendLayout();
            this.repeatPanel.SuspendLayout();
            this.repeatMenu.SuspendLayout();
            this.displayModePanel.SuspendLayout();
            this.displayOverlayMenu.SuspendLayout();
            this.fullScreenModeMenu.SuspendLayout();
            this.playPanel.SuspendLayout();
            this.playMenu.SuspendLayout();
            this.titlePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.screenCopyMenu.SuspendLayout();
            this.copyModeMenu.SuspendLayout();
            this.displayMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shuttleSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.balanceSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.volumeSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.positionSlider)).BeginInit();
            this.positionSliderMenu.SuspendLayout();
            this.displayParentPanel.SuspendLayout();
            this.positionSliderPanel.SuspendLayout();
            this.rightFramePanel.SuspendLayout();
            this.shuttlePanel.SuspendLayout();
            this.sceencopyPanel.SuspendLayout();
            this.copyLabelPanel.SuspendLayout();
            this.zoomPanel.SuspendLayout();
            this.audioPanel.SuspendLayout();
            this.balanceLabelPanel.SuspendLayout();
            this.volumeLabelPanel.SuspendLayout();
            this.playSubMenu.SuspendLayout();
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
            this.leftFramePanel.Size = new System.Drawing.Size(154, 503);
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
            this.speedPanel.Size = new System.Drawing.Size(140, 78);
            this.speedPanel.TabIndex = 4;
            // 
            // speedSlider
            // 
            this.speedSlider.AutoSize = false;
            this.speedSlider.ContextMenuStrip = this.sliderMenu;
            this.speedSlider.Location = new System.Drawing.Point(2, 31);
            this.speedSlider.Name = "speedSlider";
            this.speedSlider.Size = new System.Drawing.Size(135, 45);
            this.speedSlider.TabIndex = 1;
            this.speedSlider.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.toolTip1.SetToolTip(this.speedSlider, "Player.SpeedSlider - sets the player\'s media playback speed.");
            this.speedSlider.Value = 5;
            // 
            // sliderMenu
            // 
            this.sliderMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sliderMenuItem1,
            this.sliderMenuItem2,
            this.sliderMenuItem3});
            this.sliderMenu.Name = "sliderMenu";
            this.sliderMenu.ShowImageMargin = false;
            this.sliderMenu.Size = new System.Drawing.Size(56, 70);
            this.sliderMenu.Opening += new System.ComponentModel.CancelEventHandler(this.sliderMenu_Opening);
            // 
            // sliderMenuItem1
            // 
            this.sliderMenuItem1.Name = "sliderMenuItem1";
            this.sliderMenuItem1.Size = new System.Drawing.Size(55, 22);
            this.sliderMenuItem1.Text = "1";
            this.sliderMenuItem1.Click += new System.EventHandler(this.sliderMenuItem1_Click);
            // 
            // sliderMenuItem2
            // 
            this.sliderMenuItem2.Name = "sliderMenuItem2";
            this.sliderMenuItem2.Size = new System.Drawing.Size(55, 22);
            this.sliderMenuItem2.Text = "2";
            this.sliderMenuItem2.Click += new System.EventHandler(this.sliderMenuItem2_Click);
            // 
            // sliderMenuItem3
            // 
            this.sliderMenuItem3.Name = "sliderMenuItem3";
            this.sliderMenuItem3.Size = new System.Drawing.Size(55, 22);
            this.sliderMenuItem3.Text = "3";
            this.sliderMenuItem3.Click += new System.EventHandler(this.sliderMenuItem3_Click);
            // 
            // speedLabelPanel
            // 
            this.speedLabelPanel.Controls.Add(this.speedTextBox);
            this.speedLabelPanel.Controls.Add(this.speedLight);
            this.speedLabelPanel.Controls.Add(this.speedLabelText);
            this.speedLabelPanel.Location = new System.Drawing.Point(9, 8);
            this.speedLabelPanel.Name = "speedLabelPanel";
            this.speedLabelPanel.Size = new System.Drawing.Size(121, 22);
            this.speedLabelPanel.TabIndex = 0;
            // 
            // speedTextBox
            // 
            this.speedTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.speedTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.speedTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(159)))), ((int)(((byte)(87)))));
            this.speedTextBox.Location = new System.Drawing.Point(92, 4);
            this.speedTextBox.Mask = "0.00";
            this.speedTextBox.Name = "speedTextBox";
            this.speedTextBox.Size = new System.Drawing.Size(23, 13);
            this.speedTextBox.TabIndex = 2;
            this.speedTextBox.Text = "100";
            this.toolTip1.SetToolTip(this.speedTextBox, "Player.Speed - sets the player\'s media playback speed.");
            this.speedTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.speedTextBox_KeyPress);
            this.speedTextBox.Validated += new System.EventHandler(this.speedTextBox_Validated);
            // 
            // speedLight
            // 
            this.speedLight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.speedLight.ForeColor = System.Drawing.Color.Red;
            this.speedLight.Location = new System.Drawing.Point(7, 8);
            this.speedLight.Name = "speedLight";
            this.speedLight.Size = new System.Drawing.Size(3, 6);
            this.speedLight.TabIndex = 0;
            // 
            // speedLabelText
            // 
            this.speedLabelText.AutoSize = true;
            this.speedLabelText.BackColor = System.Drawing.Color.Transparent;
            this.speedLabelText.ContextMenuStrip = this.sliderMenu;
            this.speedLabelText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(159)))), ((int)(((byte)(87)))));
            this.speedLabelText.Location = new System.Drawing.Point(41, 4);
            this.speedLabelText.Name = "speedLabelText";
            this.speedLabelText.Size = new System.Drawing.Size(38, 13);
            this.speedLabelText.TabIndex = 1;
            this.speedLabelText.Text = "Speed";
            // 
            // repeatPanel
            // 
            this.repeatPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.repeatPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.repeatPanel.Controls.Add(this.repeatLight);
            this.repeatPanel.Controls.Add(this.repeatButton);
            this.repeatPanel.Controls.Add(this.nextFromLabel);
            this.repeatPanel.Controls.Add(this.endPositionMediaTextBox);
            this.repeatPanel.Controls.Add(this.startPositionMediaTextBox);
            this.repeatPanel.Controls.Add(this.currentFromLabel);
            this.repeatPanel.Controls.Add(this.endPositionTextBox);
            this.repeatPanel.Controls.Add(this.startPositionTextBox);
            this.repeatPanel.Location = new System.Drawing.Point(6, 279);
            this.repeatPanel.Name = "repeatPanel";
            this.repeatPanel.Size = new System.Drawing.Size(140, 133);
            this.repeatPanel.TabIndex = 3;
            // 
            // repeatLight
            // 
            this.repeatLight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.repeatLight.ForeColor = System.Drawing.Color.Lime;
            this.repeatLight.Location = new System.Drawing.Point(16, 17);
            this.repeatLight.Name = "repeatLight";
            this.repeatLight.Size = new System.Drawing.Size(3, 6);
            this.repeatLight.TabIndex = 1;
            // 
            // repeatButton
            // 
            this.repeatButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.repeatButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.repeatButton.DropDown = this.repeatMenu;
            this.repeatButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.repeatButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(159)))), ((int)(((byte)(87)))));
            this.repeatButton.Location = new System.Drawing.Point(9, 9);
            this.repeatButton.Name = "repeatButton";
            this.repeatButton.Size = new System.Drawing.Size(121, 21);
            this.repeatButton.TabIndex = 0;
            this.repeatButton.Text = "Repeat Off";
            this.repeatButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.repeatButton, "Player.Repeat - repeats media playback from \'StartPosition\' to \'EndPosition\'.");
            this.repeatButton.UseVisualStyleBackColor = false;
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
            // 
            // repeatOneMenuItem
            // 
            this.repeatOneMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.repeatOneMenuItem.Name = "repeatOneMenuItem";
            this.repeatOneMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.repeatOneMenuItem.Size = new System.Drawing.Size(203, 22);
            this.repeatOneMenuItem.Text = "Repeat One";
            this.repeatOneMenuItem.Click += new System.EventHandler(this.repeatOneMenuItem_Click);
            // 
            // repeatAllMenuItem
            // 
            this.repeatAllMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.repeatAllMenuItem.Name = "repeatAllMenuItem";
            this.repeatAllMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.repeatAllMenuItem.Size = new System.Drawing.Size(203, 22);
            this.repeatAllMenuItem.Text = "Repeat All";
            this.repeatAllMenuItem.Click += new System.EventHandler(this.repeatAllMenuItem_Click);
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
            this.shuffleMenuItem.Click += new System.EventHandler(this.shuffleMenuItem_Click);
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
            this.repeatOffMenuItem.Click += new System.EventHandler(this.repeatOffMenuItem_Click);
            // 
            // repeatMenuItem
            // 
            this.repeatMenuItem.DropDown = this.repeatMenu;
            this.repeatMenuItem.Name = "repeatMenuItem";
            this.repeatMenuItem.Size = new System.Drawing.Size(155, 22);
            this.repeatMenuItem.Text = "Repeat";
            // 
            // nextFromLabel
            // 
            this.nextFromLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(159)))), ((int)(((byte)(87)))));
            this.nextFromLabel.Location = new System.Drawing.Point(9, 35);
            this.nextFromLabel.Name = "nextFromLabel";
            this.nextFromLabel.Size = new System.Drawing.Size(121, 19);
            this.nextFromLabel.TabIndex = 2;
            this.nextFromLabel.Text = "Play Next From - To";
            this.nextFromLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // endPositionMediaTextBox
            // 
            this.endPositionMediaTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.endPositionMediaTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.endPositionMediaTextBox.Enabled = false;
            this.endPositionMediaTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endPositionMediaTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(159)))), ((int)(((byte)(87)))));
            this.endPositionMediaTextBox.Location = new System.Drawing.Point(69, 101);
            this.endPositionMediaTextBox.Mask = "00:00:00";
            this.endPositionMediaTextBox.Name = "endPositionMediaTextBox";
            this.endPositionMediaTextBox.Size = new System.Drawing.Size(61, 21);
            this.endPositionMediaTextBox.TabIndex = 7;
            this.endPositionMediaTextBox.Text = "000000";
            this.endPositionMediaTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.endPositionMediaTextBox, "Player.EndPositionMedia - the end position of the playing media.");
            this.endPositionMediaTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.positionTextBoxes_KeyPress);
            this.endPositionMediaTextBox.Validated += new System.EventHandler(this.endPositionMediaTextBox_Validated);
            // 
            // startPositionMediaTextBox
            // 
            this.startPositionMediaTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.startPositionMediaTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.startPositionMediaTextBox.Enabled = false;
            this.startPositionMediaTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startPositionMediaTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(159)))), ((int)(((byte)(87)))));
            this.startPositionMediaTextBox.Location = new System.Drawing.Point(9, 101);
            this.startPositionMediaTextBox.Mask = "00:00:00";
            this.startPositionMediaTextBox.Name = "startPositionMediaTextBox";
            this.startPositionMediaTextBox.Size = new System.Drawing.Size(61, 21);
            this.startPositionMediaTextBox.TabIndex = 6;
            this.startPositionMediaTextBox.Text = "000000";
            this.startPositionMediaTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.startPositionMediaTextBox, "Player.StartPositionMedia - the start position of the playing media.");
            this.startPositionMediaTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.positionTextBoxes_KeyPress);
            this.startPositionMediaTextBox.Validated += new System.EventHandler(this.startPositionMediaTextBox_Validated);
            // 
            // currentFromLabel
            // 
            this.currentFromLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(159)))), ((int)(((byte)(87)))));
            this.currentFromLabel.Location = new System.Drawing.Point(9, 81);
            this.currentFromLabel.Name = "currentFromLabel";
            this.currentFromLabel.Size = new System.Drawing.Size(121, 19);
            this.currentFromLabel.TabIndex = 5;
            this.currentFromLabel.Text = "Play Current From - To";
            this.currentFromLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // endPositionTextBox
            // 
            this.endPositionTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.endPositionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.endPositionTextBox.Culture = new System.Globalization.CultureInfo("");
            this.endPositionTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endPositionTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(159)))), ((int)(((byte)(87)))));
            this.endPositionTextBox.Location = new System.Drawing.Point(69, 55);
            this.endPositionTextBox.Mask = "00:00:00";
            this.endPositionTextBox.Name = "endPositionTextBox";
            this.endPositionTextBox.Size = new System.Drawing.Size(61, 21);
            this.endPositionTextBox.TabIndex = 4;
            this.endPositionTextBox.Text = "000000";
            this.endPositionTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.endPositionTextBox, "Player.EndPosition - the end position of the next media to play.");
            this.endPositionTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.positionTextBoxes_KeyPress);
            this.endPositionTextBox.Validated += new System.EventHandler(this.endPositionTextBox_Validated);
            // 
            // startPositionTextBox
            // 
            this.startPositionTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.startPositionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.startPositionTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startPositionTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(159)))), ((int)(((byte)(87)))));
            this.startPositionTextBox.Location = new System.Drawing.Point(9, 55);
            this.startPositionTextBox.Mask = "00:00:00";
            this.startPositionTextBox.Name = "startPositionTextBox";
            this.startPositionTextBox.Size = new System.Drawing.Size(61, 21);
            this.startPositionTextBox.TabIndex = 3;
            this.startPositionTextBox.Text = "000000";
            this.startPositionTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.startPositionTextBox, "Player.StartPosition - the start position of the next media to play.");
            this.startPositionTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.positionTextBoxes_KeyPress);
            this.startPositionTextBox.Validated += new System.EventHandler(this.startPositionTextBox_Validated);
            // 
            // displayModePanel
            // 
            this.displayModePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.displayModePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
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
            this.displayModePanel.Size = new System.Drawing.Size(140, 144);
            this.displayModePanel.TabIndex = 2;
            // 
            // overlayMenuLight
            // 
            this.overlayMenuLight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.overlayMenuLight.ForeColor = System.Drawing.Color.Lime;
            this.overlayMenuLight.Location = new System.Drawing.Point(16, 120);
            this.overlayMenuLight.Name = "overlayMenuLight";
            this.overlayMenuLight.Size = new System.Drawing.Size(3, 6);
            this.overlayMenuLight.TabIndex = 8;
            // 
            // overlayLight
            // 
            this.overlayLight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.overlayLight.ForeColor = System.Drawing.Color.Lime;
            this.overlayLight.Location = new System.Drawing.Point(16, 94);
            this.overlayLight.Name = "overlayLight";
            this.overlayLight.Size = new System.Drawing.Size(3, 6);
            this.overlayLight.TabIndex = 6;
            // 
            // displayOverlayButton
            // 
            this.displayOverlayButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.displayOverlayButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.displayOverlayButton.DropDown = this.displayOverlayMenu;
            this.displayOverlayButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displayOverlayButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(159)))), ((int)(((byte)(87)))));
            this.displayOverlayButton.Location = new System.Drawing.Point(9, 86);
            this.displayOverlayButton.Name = "displayOverlayButton";
            this.displayOverlayButton.Size = new System.Drawing.Size(121, 21);
            this.displayOverlayButton.TabIndex = 5;
            this.displayOverlayButton.Text = "Overlay Off";
            this.displayOverlayButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.displayOverlayButton, "Player.Overlay - shows or hides a player\'s display overlay.");
            this.displayOverlayButton.UseVisualStyleBackColor = true;
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
            this.displayOverlayMenu.ShowItemToolTips = false;
            this.displayOverlayMenu.Size = new System.Drawing.Size(249, 376);
            // 
            // overlayModeToolStripMenuItem
            // 
            this.overlayModeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.videoMenuItem,
            this.displayMenuItem});
            this.overlayModeToolStripMenuItem.Name = "overlayModeToolStripMenuItem";
            this.overlayModeToolStripMenuItem.Size = new System.Drawing.Size(248, 22);
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
            this.videoMenuItem.Click += new System.EventHandler(this.videoMenuItem_Click);
            // 
            // displayMenuItem
            // 
            this.displayMenuItem.Name = "displayMenuItem";
            this.displayMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D)));
            this.displayMenuItem.Size = new System.Drawing.Size(150, 22);
            this.displayMenuItem.Text = "Display";
            this.displayMenuItem.Click += new System.EventHandler(this.displayMenuItem_Click);
            // 
            // overlayHoldMenuItem
            // 
            this.overlayHoldMenuItem.Name = "overlayHoldMenuItem";
            this.overlayHoldMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.H)));
            this.overlayHoldMenuItem.Size = new System.Drawing.Size(248, 22);
            this.overlayHoldMenuItem.Text = "Overlay Hold";
            this.overlayHoldMenuItem.Click += new System.EventHandler(this.overlayHoldMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(245, 6);
            // 
            // messageMenuItem
            // 
            this.messageMenuItem.Name = "messageMenuItem";
            this.messageMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F1)));
            this.messageMenuItem.Size = new System.Drawing.Size(248, 22);
            this.messageMenuItem.Text = "Example \"Message\"";
            this.messageMenuItem.Click += new System.EventHandler(this.messageMenuItem_Click);
            // 
            // scribbleMenuItem
            // 
            this.scribbleMenuItem.Name = "scribbleMenuItem";
            this.scribbleMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F2)));
            this.scribbleMenuItem.Size = new System.Drawing.Size(248, 22);
            this.scribbleMenuItem.Text = "Example \"Scribble\"";
            this.scribbleMenuItem.Click += new System.EventHandler(this.scribbleMenuItem_Click);
            // 
            // toolStripSeparator24
            // 
            this.toolStripSeparator24.Name = "toolStripSeparator24";
            this.toolStripSeparator24.Size = new System.Drawing.Size(245, 6);
            // 
            // tilesMenuItem
            // 
            this.tilesMenuItem.Name = "tilesMenuItem";
            this.tilesMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F3)));
            this.tilesMenuItem.Size = new System.Drawing.Size(248, 22);
            this.tilesMenuItem.Text = "Example \"Tiles\"";
            this.tilesMenuItem.Click += new System.EventHandler(this.tilesMenuItem_Click);
            // 
            // bouncingMenuItem
            // 
            this.bouncingMenuItem.Name = "bouncingMenuItem";
            this.bouncingMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.bouncingMenuItem.Size = new System.Drawing.Size(248, 22);
            this.bouncingMenuItem.Text = "Example \"Bouncing\"";
            this.bouncingMenuItem.Click += new System.EventHandler(this.bouncingMenuItem_Click);
            // 
            // toolStripSeparator23
            // 
            this.toolStripSeparator23.Name = "toolStripSeparator23";
            this.toolStripSeparator23.Size = new System.Drawing.Size(245, 6);
            // 
            // PiPMenuItem
            // 
            this.PiPMenuItem.Name = "PiPMenuItem";
            this.PiPMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F5)));
            this.PiPMenuItem.Size = new System.Drawing.Size(248, 22);
            this.PiPMenuItem.Text = "Example \"PiP\"";
            this.PiPMenuItem.Click += new System.EventHandler(this.PiPMenuItem_Click);
            // 
            // subtitlesMenuItem
            // 
            this.subtitlesMenuItem.Name = "subtitlesMenuItem";
            this.subtitlesMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F6)));
            this.subtitlesMenuItem.Size = new System.Drawing.Size(248, 22);
            this.subtitlesMenuItem.Text = "Example \"Subtitles\"";
            this.subtitlesMenuItem.Click += new System.EventHandler(this.subtitlesMenuItem_Click);
            // 
            // toolStripSeparator25
            // 
            this.toolStripSeparator25.Name = "toolStripSeparator25";
            this.toolStripSeparator25.Size = new System.Drawing.Size(245, 6);
            // 
            // zoomSelectMenuItem
            // 
            this.zoomSelectMenuItem.Name = "zoomSelectMenuItem";
            this.zoomSelectMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F7)));
            this.zoomSelectMenuItem.Size = new System.Drawing.Size(248, 22);
            this.zoomSelectMenuItem.Text = "Example \"Zoom Select\"";
            this.zoomSelectMenuItem.Click += new System.EventHandler(this.zoomSelectMenuItem_Click);
            // 
            // videoWallMenuItem
            // 
            this.videoWallMenuItem.Name = "videoWallMenuItem";
            this.videoWallMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F8)));
            this.videoWallMenuItem.Size = new System.Drawing.Size(248, 22);
            this.videoWallMenuItem.Text = "Example \"Video Wall\"";
            this.videoWallMenuItem.Click += new System.EventHandler(this.videoWallMenuItem_Click);
            // 
            // toolStripSeparator21
            // 
            this.toolStripSeparator21.Name = "toolStripSeparator21";
            this.toolStripSeparator21.Size = new System.Drawing.Size(245, 6);
            // 
            // MP3CoverMenuItem
            // 
            this.MP3CoverMenuItem.Name = "MP3CoverMenuItem";
            this.MP3CoverMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F9)));
            this.MP3CoverMenuItem.Size = new System.Drawing.Size(248, 22);
            this.MP3CoverMenuItem.Text = "Example \"MP3 Cover\"";
            this.MP3CoverMenuItem.Click += new System.EventHandler(this.MP3CoverMenuItem_Click);
            // 
            // MP3KaraokeMenuItem
            // 
            this.MP3KaraokeMenuItem.Name = "MP3KaraokeMenuItem";
            this.MP3KaraokeMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F10)));
            this.MP3KaraokeMenuItem.Size = new System.Drawing.Size(248, 22);
            this.MP3KaraokeMenuItem.Text = "Example \"MP3 Karaoke\"";
            this.MP3KaraokeMenuItem.Click += new System.EventHandler(this.MP3KaraokeMenuItem_Click);
            // 
            // toolStripSeparator22
            // 
            this.toolStripSeparator22.Name = "toolStripSeparator22";
            this.toolStripSeparator22.Size = new System.Drawing.Size(245, 6);
            // 
            // bigTimeMenuItem
            // 
            this.bigTimeMenuItem.Name = "bigTimeMenuItem";
            this.bigTimeMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F11)));
            this.bigTimeMenuItem.Size = new System.Drawing.Size(248, 22);
            this.bigTimeMenuItem.Text = "Example \"Big Time\"";
            this.bigTimeMenuItem.Click += new System.EventHandler(this.bigTimeMenuItem_Click);
            // 
            // statusInfoMenuItem
            // 
            this.statusInfoMenuItem.Name = "statusInfoMenuItem";
            this.statusInfoMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F12)));
            this.statusInfoMenuItem.Size = new System.Drawing.Size(248, 22);
            this.statusInfoMenuItem.Text = "Example \"Status Info\"";
            this.statusInfoMenuItem.Click += new System.EventHandler(this.statusInfoMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(245, 6);
            // 
            // overlayOffMenuItem
            // 
            this.overlayOffMenuItem.Checked = true;
            this.overlayOffMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.overlayOffMenuItem.Name = "overlayOffMenuItem";
            this.overlayOffMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D0)));
            this.overlayOffMenuItem.Size = new System.Drawing.Size(248, 22);
            this.overlayOffMenuItem.Text = "Overlay Off";
            this.overlayOffMenuItem.Click += new System.EventHandler(this.overlayOffMenuItem_Click);
            // 
            // displayOverlayMenuItem
            // 
            this.displayOverlayMenuItem.DropDown = this.displayOverlayMenu;
            this.displayOverlayMenuItem.Name = "displayOverlayMenuItem";
            this.displayOverlayMenuItem.Size = new System.Drawing.Size(155, 22);
            this.displayOverlayMenuItem.Text = "Display Overlay";
            // 
            // fullScreenLight
            // 
            this.fullScreenLight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.fullScreenLight.ForeColor = System.Drawing.Color.Lime;
            this.fullScreenLight.Location = new System.Drawing.Point(16, 68);
            this.fullScreenLight.Name = "fullScreenLight";
            this.fullScreenLight.Size = new System.Drawing.Size(3, 6);
            this.fullScreenLight.TabIndex = 4;
            // 
            // fullScreenModeButton
            // 
            this.fullScreenModeButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.fullScreenModeButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fullScreenModeButton.DropDown = this.fullScreenModeMenu;
            this.fullScreenModeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fullScreenModeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(159)))), ((int)(((byte)(87)))));
            this.fullScreenModeButton.Location = new System.Drawing.Point(9, 60);
            this.fullScreenModeButton.Name = "fullScreenModeButton";
            this.fullScreenModeButton.Size = new System.Drawing.Size(121, 21);
            this.fullScreenModeButton.TabIndex = 3;
            this.fullScreenModeButton.Text = "FullScreen Off";
            this.fullScreenModeButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.fullScreenModeButton, "Player.FullScreen / Player.FullScreenMode - shows the player\'s display full scree" +
        "n.");
            this.fullScreenModeButton.UseVisualStyleBackColor = true;
            // 
            // fullScreenModeMenu
            // 
            this.fullScreenModeMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fullScreenFormMenuItem,
            this.fullScreenParentMenuItem,
            this.fullScreenDisplayMenuItem,
            this.toolStripSeparator3,
            this.fullScreenOffMenuItem});
            this.fullScreenModeMenu.Name = "fullScreenModeMenu";
            this.fullScreenModeMenu.OwnerItem = this.fullScreenModeMenuItem;
            this.fullScreenModeMenu.Size = new System.Drawing.Size(195, 98);
            this.fullScreenModeMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.fullScreenModeMenu_ItemClicked);
            // 
            // fullScreenFormMenuItem
            // 
            this.fullScreenFormMenuItem.Name = "fullScreenFormMenuItem";
            this.fullScreenFormMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.fullScreenFormMenuItem.Size = new System.Drawing.Size(194, 22);
            this.fullScreenFormMenuItem.Text = "FullScreen Form";
            // 
            // fullScreenParentMenuItem
            // 
            this.fullScreenParentMenuItem.Name = "fullScreenParentMenuItem";
            this.fullScreenParentMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F9;
            this.fullScreenParentMenuItem.Size = new System.Drawing.Size(194, 22);
            this.fullScreenParentMenuItem.Text = "FullScreen Parent";
            // 
            // fullScreenDisplayMenuItem
            // 
            this.fullScreenDisplayMenuItem.Name = "fullScreenDisplayMenuItem";
            this.fullScreenDisplayMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F10;
            this.fullScreenDisplayMenuItem.Size = new System.Drawing.Size(194, 22);
            this.fullScreenDisplayMenuItem.Text = "FullScreen Display";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(191, 6);
            // 
            // fullScreenOffMenuItem
            // 
            this.fullScreenOffMenuItem.Checked = true;
            this.fullScreenOffMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.fullScreenOffMenuItem.Name = "fullScreenOffMenuItem";
            this.fullScreenOffMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F11;
            this.fullScreenOffMenuItem.Size = new System.Drawing.Size(194, 22);
            this.fullScreenOffMenuItem.Text = "FullScreen Off";
            // 
            // fullScreenModeMenuItem
            // 
            this.fullScreenModeMenuItem.DropDown = this.fullScreenModeMenu;
            this.fullScreenModeMenuItem.Name = "fullScreenModeMenuItem";
            this.fullScreenModeMenuItem.Size = new System.Drawing.Size(155, 22);
            this.fullScreenModeMenuItem.Text = "FullScreen Mode";
            // 
            // displayModeLight
            // 
            this.displayModeLight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.displayModeLight.ForeColor = System.Drawing.Color.Red;
            this.displayModeLight.Location = new System.Drawing.Point(16, 42);
            this.displayModeLight.Name = "displayModeLight";
            this.displayModeLight.Size = new System.Drawing.Size(3, 6);
            this.displayModeLight.TabIndex = 2;
            // 
            // displayModeButton
            // 
            this.displayModeButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.displayModeButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.displayModeButton.DropDown = this.displayModeMenu;
            this.displayModeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(159)))), ((int)(((byte)(87)))));
            this.displayModeButton.Location = new System.Drawing.Point(9, 34);
            this.displayModeButton.Name = "displayModeButton";
            this.displayModeButton.Size = new System.Drawing.Size(121, 21);
            this.displayModeButton.TabIndex = 1;
            this.displayModeButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.displayModeButton, "Player.DisplayMode - sets the size and position of the video inside the player\'s " +
        "display.");
            this.displayModeButton.UseVisualStyleBackColor = true;
            // 
            // displayModeMenu
            // 
            this.displayModeMenu.Name = "displayModeMenu";
            this.displayModeMenu.OwnerItem = this.displayModeMenuItem;
            this.displayModeMenu.ShowItemToolTips = false;
            this.displayModeMenu.Size = new System.Drawing.Size(61, 4);
            this.displayModeMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.displayModeMenu_ItemClicked);
            // 
            // displayModeMenuItem
            // 
            this.displayModeMenuItem.DropDown = this.displayModeMenu;
            this.displayModeMenuItem.Name = "displayModeMenuItem";
            this.displayModeMenuItem.Size = new System.Drawing.Size(155, 22);
            this.displayModeMenuItem.Text = "Display Mode";
            // 
            // displayModeLabel
            // 
            this.displayModeLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.displayModeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(159)))), ((int)(((byte)(87)))));
            this.displayModeLabel.Location = new System.Drawing.Point(9, 9);
            this.displayModeLabel.Name = "displayModeLabel";
            this.displayModeLabel.Size = new System.Drawing.Size(121, 21);
            this.displayModeLabel.TabIndex = 0;
            this.displayModeLabel.Text = "Display";
            this.displayModeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.displayModeLabel, "Player.ShowDisplaySettingsPanel - opens the system\'s Display Control Panel.");
            this.displayModeLabel.Click += new System.EventHandler(this.displayModeLabel_Click);
            // 
            // overlayMenuButton
            // 
            this.overlayMenuButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.overlayMenuButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(159)))), ((int)(((byte)(87)))));
            this.overlayMenuButton.Location = new System.Drawing.Point(9, 112);
            this.overlayMenuButton.Name = "overlayMenuButton";
            this.overlayMenuButton.Size = new System.Drawing.Size(121, 21);
            this.overlayMenuButton.TabIndex = 7;
            this.overlayMenuButton.Text = "Overlay Menu";
            this.toolTip1.SetToolTip(this.overlayMenuButton, "Shows or hides a display overlay\'s menu (if any).");
            this.overlayMenuButton.UseVisualStyleBackColor = true;
            this.overlayMenuButton.Click += new System.EventHandler(this.overlayMenuButton_Click);
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
            this.playPanel.Size = new System.Drawing.Size(140, 63);
            this.playPanel.TabIndex = 1;
            // 
            // stopButton
            // 
            this.stopButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.stopButton.Font = new System.Drawing.Font("Webdings", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.stopButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(159)))), ((int)(((byte)(87)))));
            this.stopButton.Location = new System.Drawing.Point(101, 32);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(29, 20);
            this.stopButton.TabIndex = 5;
            this.stopButton.Text = "<";
            this.stopButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.stopButton, "Player.Stop - stops playing media.");
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // nextButton
            // 
            this.nextButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.nextButton.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.nextButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(159)))), ((int)(((byte)(87)))));
            this.nextButton.Location = new System.Drawing.Point(70, 32);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(29, 20);
            this.nextButton.TabIndex = 4;
            this.nextButton.Text = ":";
            this.nextButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.nextButton, "Player.PlayNext - requests to play next media.");
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // previousButton
            // 
            this.previousButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.previousButton.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.previousButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(159)))), ((int)(((byte)(87)))));
            this.previousButton.Location = new System.Drawing.Point(40, 32);
            this.previousButton.Name = "previousButton";
            this.previousButton.Size = new System.Drawing.Size(28, 20);
            this.previousButton.TabIndex = 3;
            this.previousButton.Text = "9";
            this.previousButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.previousButton, "Player.PlayPrevious - requests to play previous media.");
            this.previousButton.UseVisualStyleBackColor = true;
            this.previousButton.Click += new System.EventHandler(this.previousButton_Click);
            // 
            // pauseButton
            // 
            this.pauseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pauseButton.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.pauseButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(159)))), ((int)(((byte)(87)))));
            this.pauseButton.Location = new System.Drawing.Point(9, 32);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(29, 20);
            this.pauseButton.TabIndex = 2;
            this.pauseButton.Text = ";";
            this.pauseButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.pauseButton, "Player.Pause - pauses playing media / Player.Resume - resumes paused media.");
            this.pauseButton.Click += new System.EventHandler(this.pauseButton_Click);
            // 
            // playButtonLight
            // 
            this.playButtonLight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.playButtonLight.ForeColor = System.Drawing.Color.Lime;
            this.playButtonLight.Location = new System.Drawing.Point(16, 17);
            this.playButtonLight.Name = "playButtonLight";
            this.playButtonLight.Size = new System.Drawing.Size(3, 6);
            this.playButtonLight.TabIndex = 1;
            // 
            // playButton
            // 
            this.playButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.playButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.playButton.DropDown = this.playMenu;
            this.playButton.Font = new System.Drawing.Font("Webdings", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.playButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(159)))), ((int)(((byte)(87)))));
            this.playButton.Location = new System.Drawing.Point(9, 9);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(121, 21);
            this.playButton.TabIndex = 0;
            this.playButton.Text = "4";
            this.playButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolTip1.SetToolTip(this.playButton, "Player.Play - plays media.");
            this.playButton.UseVisualStyleBackColor = true;
            // 
            // playMenu
            // 
            this.playMenu.AllowDrop = true;
            this.playMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playListMenuItem,
            this.toolStripSeparator16,
            this.addMediaFilesMenuItem,
            this.addMediaURLMenuItem,
            this.menuSeparator1});
            this.playMenu.Name = "playMenu";
            this.playMenu.OwnerItem = this.playDisplayMenuItem;
            this.playMenu.ShowItemToolTips = false;
            this.playMenu.Size = new System.Drawing.Size(213, 82);
            this.playMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.playMenu_ItemClicked);
            this.playMenu.DragDrop += new System.Windows.Forms.DragEventHandler(this.playMenu_DragDrop);
            this.playMenu.DragOver += new System.Windows.Forms.DragEventHandler(this.playMenu_DragOver);
            this.playMenu.MouseClick += new System.Windows.Forms.MouseEventHandler(this.playMenu_MouseClick);
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
            this.playListMenuItem.Text = "PlayLists";
            // 
            // newPlayListMenuItem
            // 
            this.newPlayListMenuItem.Enabled = false;
            this.newPlayListMenuItem.Name = "newPlayListMenuItem";
            this.newPlayListMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newPlayListMenuItem.Size = new System.Drawing.Size(206, 22);
            this.newPlayListMenuItem.Text = "New PlayList";
            this.newPlayListMenuItem.Click += new System.EventHandler(this.newPlayListMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(203, 6);
            // 
            // openPlayListMenuItem
            // 
            this.openPlayListMenuItem.Name = "openPlayListMenuItem";
            this.openPlayListMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openPlayListMenuItem.Size = new System.Drawing.Size(206, 22);
            this.openPlayListMenuItem.Text = "Open PlayList…";
            this.openPlayListMenuItem.Click += new System.EventHandler(this.openPlayListMenuItem_Click);
            // 
            // addPlayListMenuItem
            // 
            this.addPlayListMenuItem.Enabled = false;
            this.addPlayListMenuItem.Name = "addPlayListMenuItem";
            this.addPlayListMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.addPlayListMenuItem.Size = new System.Drawing.Size(206, 22);
            this.addPlayListMenuItem.Text = "Add PlayList…";
            this.addPlayListMenuItem.Click += new System.EventHandler(this.addPlayListMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(203, 6);
            // 
            // savePlayListMenuItem
            // 
            this.savePlayListMenuItem.Enabled = false;
            this.savePlayListMenuItem.Name = "savePlayListMenuItem";
            this.savePlayListMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.savePlayListMenuItem.Size = new System.Drawing.Size(206, 22);
            this.savePlayListMenuItem.Text = "Save PlayList As…";
            this.savePlayListMenuItem.Click += new System.EventHandler(this.savePlayListMenuItem_Click);
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
            this.addMediaFilesMenuItem.Text = "Add MediaFiles…";
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
            // titlePanel
            // 
            this.titlePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.titlePanel.Controls.Add(this.webSiteLabel);
            this.titlePanel.Controls.Add(this.nameLabel);
            this.titlePanel.Location = new System.Drawing.Point(6, 6);
            this.titlePanel.Name = "titlePanel";
            this.titlePanel.Size = new System.Drawing.Size(140, 51);
            this.titlePanel.TabIndex = 0;
            // 
            // webSiteLabel
            // 
            this.webSiteLabel.AutoSize = true;
            this.webSiteLabel.BackColor = System.Drawing.Color.Transparent;
            this.webSiteLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.webSiteLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(159)))), ((int)(((byte)(87)))));
            this.webSiteLabel.Location = new System.Drawing.Point(13, 26);
            this.webSiteLabel.Name = "webSiteLabel";
            this.webSiteLabel.Size = new System.Drawing.Size(113, 13);
            this.webSiteLabel.TabIndex = 1;
            this.webSiteLabel.Text = "www.codeproject.com";
            this.toolTip1.SetToolTip(this.webSiteLabel, "Open The Code Project® website...");
            this.webSiteLabel.Click += new System.EventHandler(this.webSiteLabel_Click);
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.BackColor = System.Drawing.Color.Transparent;
            this.nameLabel.Cursor = System.Windows.Forms.Cursors.Help;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(159)))), ((int)(((byte)(87)))));
            this.nameLabel.Location = new System.Drawing.Point(22, 8);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(95, 16);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "PVS.AVPlayer";
            this.toolTip1.SetToolTip(this.nameLabel, "About PVS.AVPlayer...");
            this.nameLabel.Click += new System.EventHandler(this.nameLabel_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.Active = false;
            this.toolTip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.toolTip1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(159)))), ((int)(((byte)(87)))));
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.ContextMenuStrip = this.screenCopyMenu;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Location = new System.Drawing.Point(9, 30);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(121, 61);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox1, "Player.ScreenCopy - copies (part of) the screen.");
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
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
            this.copyMenuItem.Click += new System.EventHandler(this.copyMenuItem_Click);
            // 
            // copyModeMenuItem
            // 
            this.copyModeMenuItem.DropDown = this.copyModeMenu;
            this.copyModeMenuItem.Name = "copyModeMenuItem";
            this.copyModeMenuItem.Size = new System.Drawing.Size(134, 22);
            this.copyModeMenuItem.Text = "CopyMode";
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
            this.copyModeMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.copyModeMenu_ItemClicked);
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
            this.openCopyMenuItem.Click += new System.EventHandler(this.openCopyMenuItem_Click);
            // 
            // openWithCopyMenuItem
            // 
            this.openWithCopyMenuItem.Enabled = false;
            this.openWithCopyMenuItem.Name = "openWithCopyMenuItem";
            this.openWithCopyMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.openWithCopyMenuItem.Size = new System.Drawing.Size(134, 22);
            this.openWithCopyMenuItem.Text = "Open With…";
            this.openWithCopyMenuItem.Click += new System.EventHandler(this.openWithMenuItem_Click);
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
            this.clearCopyMenuItem.Click += new System.EventHandler(this.clearCopyMenuItem_Click);
            // 
            // screencopyMenuItem
            // 
            this.screencopyMenuItem.DropDown = this.screenCopyMenu;
            this.screencopyMenuItem.Name = "screencopyMenuItem";
            this.screencopyMenuItem.Size = new System.Drawing.Size(155, 22);
            this.screencopyMenuItem.Text = "Screencopy";
            // 
            // displayPanel
            // 
            this.displayPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.displayPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.displayPanel.ContextMenuStrip = this.displayMenu;
            this.displayPanel.Location = new System.Drawing.Point(0, 0);
            this.displayPanel.Name = "displayPanel";
            this.displayPanel.Size = new System.Drawing.Size(652, 478);
            this.displayPanel.TabIndex = 1;
            this.toolTip1.SetToolTip(this.displayPanel, "Player.Display - used for displaying video and display overlays.");
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
            this.displayModeMenuItem,
            this.fullScreenModeMenuItem,
            this.toolStripSeparator10,
            this.displayOverlayMenuItem,
            this.overlayMenuMenuItem,
            this.toolStripSeparator9,
            this.repeatMenuItem,
            this.toolStripSeparator20,
            this.videoSizeMenuItem,
            this.screencopyMenuItem,
            this.toolStripSeparator17,
            this.voiceRecorderMenuItem,
            this.toolStripSeparator31,
            this.systemMenuItem,
            this.preferencesMenuItem,
            this.toolStripSeparator11,
            this.quitMenuItem});
            this.displayMenu.Name = "displayMenu";
            this.displayMenu.ShowImageMargin = false;
            this.displayMenu.Size = new System.Drawing.Size(156, 398);
            // 
            // previousMenuItem
            // 
            this.previousMenuItem.Name = "previousMenuItem";
            this.previousMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.previousMenuItem.Size = new System.Drawing.Size(155, 22);
            this.previousMenuItem.Text = "Previous";
            this.previousMenuItem.Click += new System.EventHandler(this.previousButton_Click);
            // 
            // nextMenuItem
            // 
            this.nextMenuItem.Name = "nextMenuItem";
            this.nextMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.nextMenuItem.Size = new System.Drawing.Size(155, 22);
            this.nextMenuItem.Text = "Next";
            this.nextMenuItem.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // pauseMenuItem
            // 
            this.pauseMenuItem.Name = "pauseMenuItem";
            this.pauseMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Space)));
            this.pauseMenuItem.Size = new System.Drawing.Size(155, 22);
            this.pauseMenuItem.Text = "Pause";
            this.pauseMenuItem.Click += new System.EventHandler(this.pauseButton_Click);
            // 
            // stopMenuItem
            // 
            this.stopMenuItem.Name = "stopMenuItem";
            this.stopMenuItem.Size = new System.Drawing.Size(155, 22);
            this.stopMenuItem.Text = "Stop";
            this.stopMenuItem.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(152, 6);
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
            this.overlayMenuMenuItem.Click += new System.EventHandler(this.overlayMenuMenuItem_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(152, 6);
            // 
            // toolStripSeparator20
            // 
            this.toolStripSeparator20.Name = "toolStripSeparator20";
            this.toolStripSeparator20.Size = new System.Drawing.Size(152, 6);
            // 
            // videoSizeMenuItem
            // 
            this.videoSizeMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoomVideoMenuItem,
            this.moveVideoMenuItem,
            this.stretchVideoMenuItem});
            this.videoSizeMenuItem.Name = "videoSizeMenuItem";
            this.videoSizeMenuItem.Size = new System.Drawing.Size(155, 22);
            this.videoSizeMenuItem.Text = "Video Resizing";
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
            this.zoomInMenuItem.Click += new System.EventHandler(this.zoomInMenuItem_Click);
            // 
            // zoomOutToolMenuItem
            // 
            this.zoomOutToolMenuItem.Name = "zoomOutToolMenuItem";
            this.zoomOutToolMenuItem.Size = new System.Drawing.Size(129, 22);
            this.zoomOutToolMenuItem.Text = "Zoom Out";
            this.zoomOutToolMenuItem.Click += new System.EventHandler(this.zoomOutMenuItem_Click);
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
            this.moveUpMenuItem.Click += new System.EventHandler(this.moveUpMenuItem_Click);
            // 
            // moveDownMenuItem
            // 
            this.moveDownMenuItem.Name = "moveDownMenuItem";
            this.moveDownMenuItem.Size = new System.Drawing.Size(138, 22);
            this.moveDownMenuItem.Text = "Move Down";
            this.moveDownMenuItem.Click += new System.EventHandler(this.moveDownMenuItem_Click);
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
            this.moveLeftMenuItem.Click += new System.EventHandler(this.moveLeftMenuItem_Click);
            // 
            // moveRightMenuItem
            // 
            this.moveRightMenuItem.Name = "moveRightMenuItem";
            this.moveRightMenuItem.Size = new System.Drawing.Size(138, 22);
            this.moveRightMenuItem.Text = "Move Right";
            this.moveRightMenuItem.Click += new System.EventHandler(this.moveRightMenuItem_Click);
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
            this.stretchHeightMenuItem.Click += new System.EventHandler(this.stretchHeightMenuItem_Click);
            // 
            // shrinkHeightMenuItem
            // 
            this.shrinkHeightMenuItem.Name = "shrinkHeightMenuItem";
            this.shrinkHeightMenuItem.Size = new System.Drawing.Size(150, 22);
            this.shrinkHeightMenuItem.Text = "Shrink Height";
            this.shrinkHeightMenuItem.Click += new System.EventHandler(this.shrinkHeightMenuItem_Click);
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
            this.stretchWidthMenuItem.Click += new System.EventHandler(this.stretchWidthMenuItem_Click);
            // 
            // shrinkWidthMenuItem
            // 
            this.shrinkWidthMenuItem.Name = "shrinkWidthMenuItem";
            this.shrinkWidthMenuItem.Size = new System.Drawing.Size(150, 22);
            this.shrinkWidthMenuItem.Text = "Shrink Width";
            this.shrinkWidthMenuItem.Click += new System.EventHandler(this.shrinkWidthMenuItem_Click);
            // 
            // toolStripSeparator17
            // 
            this.toolStripSeparator17.Name = "toolStripSeparator17";
            this.toolStripSeparator17.Size = new System.Drawing.Size(152, 6);
            // 
            // voiceRecorderMenuItem
            // 
            this.voiceRecorderMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showRecorderMenuItem,
            this.showPlayerMenuItem,
            this.toolStripSeparator27,
            this.showAllMenuItem,
            this.hideAllMenuItem,
            this.toolStripSeparator30,
            this.closeRecorderMenuItem});
            this.voiceRecorderMenuItem.Name = "voiceRecorderMenuItem";
            this.voiceRecorderMenuItem.Size = new System.Drawing.Size(155, 22);
            this.voiceRecorderMenuItem.Text = "Voice Recorder";
            // 
            // showRecorderMenuItem
            // 
            this.showRecorderMenuItem.Name = "showRecorderMenuItem";
            this.showRecorderMenuItem.Size = new System.Drawing.Size(153, 22);
            this.showRecorderMenuItem.Text = "Show Recorder";
            this.showRecorderMenuItem.Click += new System.EventHandler(this.showRecorderMenuItem_Click);
            // 
            // showPlayerMenuItem
            // 
            this.showPlayerMenuItem.Name = "showPlayerMenuItem";
            this.showPlayerMenuItem.Size = new System.Drawing.Size(153, 22);
            this.showPlayerMenuItem.Text = "Show Player";
            this.showPlayerMenuItem.Click += new System.EventHandler(this.showPlayerMenuItem_Click);
            // 
            // toolStripSeparator27
            // 
            this.toolStripSeparator27.Name = "toolStripSeparator27";
            this.toolStripSeparator27.Size = new System.Drawing.Size(150, 6);
            // 
            // showAllMenuItem
            // 
            this.showAllMenuItem.Name = "showAllMenuItem";
            this.showAllMenuItem.Size = new System.Drawing.Size(153, 22);
            this.showAllMenuItem.Text = "Show All";
            this.showAllMenuItem.Click += new System.EventHandler(this.showAllMenuItem_Click);
            // 
            // hideAllMenuItem
            // 
            this.hideAllMenuItem.Name = "hideAllMenuItem";
            this.hideAllMenuItem.Size = new System.Drawing.Size(153, 22);
            this.hideAllMenuItem.Text = "Hide All";
            this.hideAllMenuItem.Click += new System.EventHandler(this.hideAllMenuItem_Click);
            // 
            // toolStripSeparator30
            // 
            this.toolStripSeparator30.Name = "toolStripSeparator30";
            this.toolStripSeparator30.Size = new System.Drawing.Size(150, 6);
            // 
            // closeRecorderMenuItem
            // 
            this.closeRecorderMenuItem.Name = "closeRecorderMenuItem";
            this.closeRecorderMenuItem.Size = new System.Drawing.Size(153, 22);
            this.closeRecorderMenuItem.Text = "Close All";
            this.closeRecorderMenuItem.Click += new System.EventHandler(this.closeRecorderMenuItem_Click);
            // 
            // toolStripSeparator31
            // 
            this.toolStripSeparator31.Name = "toolStripSeparator31";
            this.toolStripSeparator31.Size = new System.Drawing.Size(152, 6);
            // 
            // systemMenuItem
            // 
            this.systemMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.systemDisplayMenuItem,
            this.toolStripSeparator26,
            this.systemSoundMenuItem,
            this.systemMixerMenuItem});
            this.systemMenuItem.Name = "systemMenuItem";
            this.systemMenuItem.Size = new System.Drawing.Size(155, 22);
            this.systemMenuItem.Text = "System Settings";
            // 
            // systemDisplayMenuItem
            // 
            this.systemDisplayMenuItem.Name = "systemDisplayMenuItem";
            this.systemDisplayMenuItem.Size = new System.Drawing.Size(156, 22);
            this.systemDisplayMenuItem.Text = "Display…";
            this.systemDisplayMenuItem.Click += new System.EventHandler(this.displayModeLabel_Click);
            // 
            // toolStripSeparator26
            // 
            this.toolStripSeparator26.Name = "toolStripSeparator26";
            this.toolStripSeparator26.Size = new System.Drawing.Size(153, 6);
            // 
            // systemSoundMenuItem
            // 
            this.systemSoundMenuItem.Name = "systemSoundMenuItem";
            this.systemSoundMenuItem.Size = new System.Drawing.Size(156, 22);
            this.systemSoundMenuItem.Text = "Sound…";
            this.systemSoundMenuItem.Click += new System.EventHandler(this.volumeLabelPanel_Click);
            // 
            // systemMixerMenuItem
            // 
            this.systemMixerMenuItem.Name = "systemMixerMenuItem";
            this.systemMixerMenuItem.Size = new System.Drawing.Size(156, 22);
            this.systemMixerMenuItem.Text = "Volume Mixer…";
            this.systemMixerMenuItem.Click += new System.EventHandler(this.balanceLabelPanel_Click);
            // 
            // preferencesMenuItem
            // 
            this.preferencesMenuItem.Name = "preferencesMenuItem";
            this.preferencesMenuItem.Size = new System.Drawing.Size(155, 22);
            this.preferencesMenuItem.Text = "Preferences…";
            this.preferencesMenuItem.Click += new System.EventHandler(this.preferencesMenuItem_Click);
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
            this.quitMenuItem.Click += new System.EventHandler(this.quitMenuItem_Click);
            // 
            // shuttleSlider
            // 
            this.shuttleSlider.AutoSize = false;
            this.shuttleSlider.Location = new System.Drawing.Point(2, 31);
            this.shuttleSlider.Name = "shuttleSlider";
            this.shuttleSlider.Size = new System.Drawing.Size(135, 45);
            this.shuttleSlider.TabIndex = 1;
            this.shuttleSlider.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.toolTip1.SetToolTip(this.shuttleSlider, "Player.ShuttleSlider - changes the media playback position by (video) frames.");
            this.shuttleSlider.Value = 5;
            // 
            // copyModeLabel
            // 
            this.copyModeLabel.BackColor = System.Drawing.Color.Transparent;
            this.copyModeLabel.ContextMenuStrip = this.copyModeMenu;
            this.copyModeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(159)))), ((int)(((byte)(87)))));
            this.copyModeLabel.Location = new System.Drawing.Point(68, 3);
            this.copyModeLabel.Name = "copyModeLabel";
            this.copyModeLabel.Size = new System.Drawing.Size(51, 13);
            this.copyModeLabel.TabIndex = 1;
            this.copyModeLabel.Text = "Video";
            this.copyModeLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.toolTip1.SetToolTip(this.copyModeLabel, "Player.ScreenCopyMode - selects the part of the screen to copy.");
            // 
            // stretchRightButton
            // 
            this.stretchRightButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.stretchRightButton.Font = new System.Drawing.Font("Wingdings 3", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.stretchRightButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(159)))), ((int)(((byte)(87)))));
            this.stretchRightButton.Location = new System.Drawing.Point(101, 117);
            this.stretchRightButton.Name = "stretchRightButton";
            this.stretchRightButton.Size = new System.Drawing.Size(29, 20);
            this.stretchRightButton.TabIndex = 12;
            this.stretchRightButton.Text = "Æ";
            this.toolTip1.SetToolTip(this.stretchRightButton, "Player.VideoStretch - changes the size of  the video inside the player\'s display." +
        "");
            this.stretchRightButton.UseVisualStyleBackColor = true;
            this.stretchRightButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.stretchRightButton_MouseDown);
            // 
            // stretchLeftButton
            // 
            this.stretchLeftButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.stretchLeftButton.Font = new System.Drawing.Font("Wingdings 3", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.stretchLeftButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(159)))), ((int)(((byte)(87)))));
            this.stretchLeftButton.Location = new System.Drawing.Point(70, 117);
            this.stretchLeftButton.Name = "stretchLeftButton";
            this.stretchLeftButton.Size = new System.Drawing.Size(29, 20);
            this.stretchLeftButton.TabIndex = 11;
            this.stretchLeftButton.Text = "Å";
            this.toolTip1.SetToolTip(this.stretchLeftButton, "Player.VideoStretch - changes the size of  the video inside the player\'s display." +
        "");
            this.stretchLeftButton.UseVisualStyleBackColor = true;
            this.stretchLeftButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.stretchLeftButton_MouseDown);
            // 
            // stretchDownButton
            // 
            this.stretchDownButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.stretchDownButton.Font = new System.Drawing.Font("Wingdings 3", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.stretchDownButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(159)))), ((int)(((byte)(87)))));
            this.stretchDownButton.Location = new System.Drawing.Point(40, 117);
            this.stretchDownButton.Name = "stretchDownButton";
            this.stretchDownButton.Size = new System.Drawing.Size(28, 20);
            this.stretchDownButton.TabIndex = 10;
            this.stretchDownButton.Text = "È";
            this.toolTip1.SetToolTip(this.stretchDownButton, "Player.VideoStretch - changes the size of  the video inside the player\'s display." +
        "");
            this.stretchDownButton.UseVisualStyleBackColor = true;
            this.stretchDownButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.stretchDownButton_MouseDown);
            // 
            // stretchUpButton
            // 
            this.stretchUpButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.stretchUpButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(159)))), ((int)(((byte)(87)))));
            this.stretchUpButton.Location = new System.Drawing.Point(9, 117);
            this.stretchUpButton.Name = "stretchUpButton";
            this.stretchUpButton.Size = new System.Drawing.Size(29, 20);
            this.stretchUpButton.TabIndex = 9;
            this.stretchUpButton.Text = "Ç";
            this.toolTip1.SetToolTip(this.stretchUpButton, "Player.VideoStretch - changes the size of  the video inside the player\'s display." +
        "");
            this.stretchUpButton.UseVisualStyleBackColor = true;
            this.stretchUpButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.stretchUpButton_MouseDown);
            // 
            // moveRightButton
            // 
            this.moveRightButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.moveRightButton.Font = new System.Drawing.Font("Wingdings 3", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.moveRightButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(159)))), ((int)(((byte)(87)))));
            this.moveRightButton.Location = new System.Drawing.Point(101, 73);
            this.moveRightButton.Name = "moveRightButton";
            this.moveRightButton.Size = new System.Drawing.Size(29, 20);
            this.moveRightButton.TabIndex = 7;
            this.moveRightButton.Text = "Æ";
            this.toolTip1.SetToolTip(this.moveRightButton, "Player.VideoMove - moves the video inside the player\'s display.");
            this.moveRightButton.UseVisualStyleBackColor = true;
            this.moveRightButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.moveRightButton_MouseDown);
            // 
            // moveLeftButton
            // 
            this.moveLeftButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.moveLeftButton.Font = new System.Drawing.Font("Wingdings 3", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.moveLeftButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(159)))), ((int)(((byte)(87)))));
            this.moveLeftButton.Location = new System.Drawing.Point(70, 73);
            this.moveLeftButton.Name = "moveLeftButton";
            this.moveLeftButton.Size = new System.Drawing.Size(29, 20);
            this.moveLeftButton.TabIndex = 6;
            this.moveLeftButton.Text = "Å";
            this.toolTip1.SetToolTip(this.moveLeftButton, "Player.VideoMove - moves the video inside the player\'s display.");
            this.moveLeftButton.UseVisualStyleBackColor = true;
            this.moveLeftButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.moveLeftButton_MouseDown);
            // 
            // moveDownButton
            // 
            this.moveDownButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.moveDownButton.Font = new System.Drawing.Font("Wingdings 3", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.moveDownButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(159)))), ((int)(((byte)(87)))));
            this.moveDownButton.Location = new System.Drawing.Point(40, 73);
            this.moveDownButton.Name = "moveDownButton";
            this.moveDownButton.Size = new System.Drawing.Size(28, 20);
            this.moveDownButton.TabIndex = 5;
            this.moveDownButton.Text = "È";
            this.toolTip1.SetToolTip(this.moveDownButton, "Player.VideoMove - moves the video inside the player\'s display.");
            this.moveDownButton.UseVisualStyleBackColor = true;
            this.moveDownButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.moveDownButton_MouseDown);
            // 
            // moveUpButton
            // 
            this.moveUpButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.moveUpButton.Font = new System.Drawing.Font("Wingdings 3", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.moveUpButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(159)))), ((int)(((byte)(87)))));
            this.moveUpButton.Location = new System.Drawing.Point(9, 73);
            this.moveUpButton.Name = "moveUpButton";
            this.moveUpButton.Size = new System.Drawing.Size(29, 20);
            this.moveUpButton.TabIndex = 4;
            this.moveUpButton.Text = "Ç";
            this.toolTip1.SetToolTip(this.moveUpButton, "Player.VideoMove - moves the video inside the player\'s display.");
            this.moveUpButton.UseVisualStyleBackColor = true;
            this.moveUpButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.moveUpButton_MouseDown);
            // 
            // zoomOutButton
            // 
            this.zoomOutButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.zoomOutButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.zoomOutButton.Font = new System.Drawing.Font("Wingdings 3", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.zoomOutButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(159)))), ((int)(((byte)(87)))));
            this.zoomOutButton.Location = new System.Drawing.Point(70, 29);
            this.zoomOutButton.Name = "zoomOutButton";
            this.zoomOutButton.Size = new System.Drawing.Size(60, 20);
            this.zoomOutButton.TabIndex = 2;
            this.zoomOutButton.Text = "È";
            this.toolTip1.SetToolTip(this.zoomOutButton, "Player.VideoZoom - changes the size of the video inside the player\'s display.");
            this.zoomOutButton.UseVisualStyleBackColor = true;
            this.zoomOutButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.zoomOutButton_MouseDown);
            // 
            // zoomInButton
            // 
            this.zoomInButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.zoomInButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.zoomInButton.Font = new System.Drawing.Font("Wingdings 3", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.zoomInButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(159)))), ((int)(((byte)(87)))));
            this.zoomInButton.Location = new System.Drawing.Point(9, 29);
            this.zoomInButton.Name = "zoomInButton";
            this.zoomInButton.Size = new System.Drawing.Size(59, 20);
            this.zoomInButton.TabIndex = 1;
            this.zoomInButton.Text = "Ç";
            this.toolTip1.SetToolTip(this.zoomInButton, "Player.VideoZoom - changes the size of the video inside the player\'s display.");
            this.zoomInButton.UseVisualStyleBackColor = true;
            this.zoomInButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.zoomInButton_MouseDown);
            // 
            // balanceSlider
            // 
            this.balanceSlider.AutoSize = false;
            this.balanceSlider.ContextMenuStrip = this.sliderMenu;
            this.balanceSlider.Location = new System.Drawing.Point(2, 99);
            this.balanceSlider.Name = "balanceSlider";
            this.balanceSlider.Size = new System.Drawing.Size(135, 45);
            this.balanceSlider.TabIndex = 3;
            this.balanceSlider.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.toolTip1.SetToolTip(this.balanceSlider, "Player.AudioBalanceSlider - sets the player\'s audio balance.");
            this.balanceSlider.Value = 5;
            // 
            // volumeSlider
            // 
            this.volumeSlider.AutoSize = false;
            this.volumeSlider.ContextMenuStrip = this.sliderMenu;
            this.volumeSlider.Location = new System.Drawing.Point(2, 31);
            this.volumeSlider.Name = "volumeSlider";
            this.volumeSlider.Size = new System.Drawing.Size(135, 45);
            this.volumeSlider.TabIndex = 1;
            this.volumeSlider.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.toolTip1.SetToolTip(this.volumeSlider, "Player.AudioVolumeSlider - sets the player\'s audio volume.");
            this.volumeSlider.Value = 10;
            // 
            // audioBalanceLabelText
            // 
            this.audioBalanceLabelText.AutoSize = true;
            this.audioBalanceLabelText.BackColor = System.Drawing.Color.Transparent;
            this.audioBalanceLabelText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(159)))), ((int)(((byte)(87)))));
            this.audioBalanceLabelText.Location = new System.Drawing.Point(3, 4);
            this.audioBalanceLabelText.Name = "audioBalanceLabelText";
            this.audioBalanceLabelText.Size = new System.Drawing.Size(46, 13);
            this.audioBalanceLabelText.TabIndex = 0;
            this.audioBalanceLabelText.Text = "Balance";
            this.toolTip1.SetToolTip(this.audioBalanceLabelText, "Player.ShowAudioMixerPanel - opens the system\'s Volume Mixer Control Panel.");
            this.audioBalanceLabelText.Click += new System.EventHandler(this.balanceLabelPanel_Click);
            // 
            // audioVolumeLabelText
            // 
            this.audioVolumeLabelText.AutoSize = true;
            this.audioVolumeLabelText.BackColor = System.Drawing.Color.Transparent;
            this.audioVolumeLabelText.Cursor = System.Windows.Forms.Cursors.Hand;
            this.audioVolumeLabelText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(159)))), ((int)(((byte)(87)))));
            this.audioVolumeLabelText.Location = new System.Drawing.Point(39, 4);
            this.audioVolumeLabelText.Name = "audioVolumeLabelText";
            this.audioVolumeLabelText.Size = new System.Drawing.Size(34, 13);
            this.audioVolumeLabelText.TabIndex = 1;
            this.audioVolumeLabelText.Text = "Audio";
            this.toolTip1.SetToolTip(this.audioVolumeLabelText, "Player.ShowAudioOutputPanel - opens the system\'s Sound Control Panel.");
            this.audioVolumeLabelText.Click += new System.EventHandler(this.volumeLabelPanel_Click);
            // 
            // positionSlider
            // 
            this.positionSlider.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.positionSlider.AutoSize = false;
            this.positionSlider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.positionSlider.ContextMenuStrip = this.positionSliderMenu;
            this.positionSlider.Location = new System.Drawing.Point(81, 2);
            this.positionSlider.Name = "positionSlider";
            this.positionSlider.Size = new System.Drawing.Size(488, 26);
            this.positionSlider.TabIndex = 1;
            this.toolTip1.SetToolTip(this.positionSlider, "Player.PositionSlider - shows and allows changing of the playback position of med" +
        "ia.");
            // 
            // positionSliderMenu
            // 
            this.positionSliderMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sliderAlwaysVisibleMenuItem,
            this.sliderShowsProgressMenuItem,
            this.sliderSeekLiveUpdateMenuItem,
            this.toolStripSeparator13,
            this.markStartPositionMenuItem,
            this.markEndPositionMenuItem,
            this.startRepeatMenuItem,
            this.toolStripSeparator14,
            this.mark1MenuItem,
            this.goToMark1MenuItem,
            this.toolStripSeparator15,
            this.goToStartMenuItem});
            this.positionSliderMenu.Name = "positionSliderMenu";
            this.positionSliderMenu.Size = new System.Drawing.Size(191, 220);
            // 
            // sliderAlwaysVisibleMenuItem
            // 
            this.sliderAlwaysVisibleMenuItem.Checked = true;
            this.sliderAlwaysVisibleMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.sliderAlwaysVisibleMenuItem.Name = "sliderAlwaysVisibleMenuItem";
            this.sliderAlwaysVisibleMenuItem.Size = new System.Drawing.Size(190, 22);
            this.sliderAlwaysVisibleMenuItem.Text = "Slider always visible";
            this.sliderAlwaysVisibleMenuItem.Click += new System.EventHandler(this.sliderAlwayVisibleMenuItem_Click);
            // 
            // sliderShowsProgressMenuItem
            // 
            this.sliderShowsProgressMenuItem.Name = "sliderShowsProgressMenuItem";
            this.sliderShowsProgressMenuItem.Size = new System.Drawing.Size(190, 22);
            this.sliderShowsProgressMenuItem.Text = "Slider shows progress";
            this.sliderShowsProgressMenuItem.Click += new System.EventHandler(this.sliderShowsProgressMenuItem_Click);
            // 
            // sliderSeekLiveUpdateMenuItem
            // 
            this.sliderSeekLiveUpdateMenuItem.Checked = true;
            this.sliderSeekLiveUpdateMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.sliderSeekLiveUpdateMenuItem.Name = "sliderSeekLiveUpdateMenuItem";
            this.sliderSeekLiveUpdateMenuItem.Size = new System.Drawing.Size(190, 22);
            this.sliderSeekLiveUpdateMenuItem.Text = "Slider seek live update";
            this.sliderSeekLiveUpdateMenuItem.Click += new System.EventHandler(this.sliderSeekLiveUpdateMenuItem_Click);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(187, 6);
            // 
            // markStartPositionMenuItem
            // 
            this.markStartPositionMenuItem.Enabled = false;
            this.markStartPositionMenuItem.Name = "markStartPositionMenuItem";
            this.markStartPositionMenuItem.Size = new System.Drawing.Size(190, 22);
            this.markStartPositionMenuItem.Text = "Mark start position";
            this.markStartPositionMenuItem.Click += new System.EventHandler(this.markStartPositionMenuItem_Click);
            // 
            // markEndPositionMenuItem
            // 
            this.markEndPositionMenuItem.Enabled = false;
            this.markEndPositionMenuItem.Name = "markEndPositionMenuItem";
            this.markEndPositionMenuItem.Size = new System.Drawing.Size(190, 22);
            this.markEndPositionMenuItem.Text = "Mark end position";
            this.markEndPositionMenuItem.Click += new System.EventHandler(this.markEndPositionMenuItem_Click);
            // 
            // startRepeatMenuItem
            // 
            this.startRepeatMenuItem.Enabled = false;
            this.startRepeatMenuItem.Name = "startRepeatMenuItem";
            this.startRepeatMenuItem.Size = new System.Drawing.Size(190, 22);
            this.startRepeatMenuItem.Text = "Start repeat";
            this.startRepeatMenuItem.Click += new System.EventHandler(this.startRepeatMenuItem_Click);
            // 
            // toolStripSeparator14
            // 
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            this.toolStripSeparator14.Size = new System.Drawing.Size(187, 6);
            // 
            // mark1MenuItem
            // 
            this.mark1MenuItem.Enabled = false;
            this.mark1MenuItem.Name = "mark1MenuItem";
            this.mark1MenuItem.Size = new System.Drawing.Size(190, 22);
            this.mark1MenuItem.Text = "Mark #1";
            this.mark1MenuItem.Click += new System.EventHandler(this.mark1MenuItem_Click);
            // 
            // goToMark1MenuItem
            // 
            this.goToMark1MenuItem.Enabled = false;
            this.goToMark1MenuItem.Name = "goToMark1MenuItem";
            this.goToMark1MenuItem.Size = new System.Drawing.Size(190, 22);
            this.goToMark1MenuItem.Text = "Go to Mark #1";
            this.goToMark1MenuItem.Click += new System.EventHandler(this.goToMark1MenuItem_Click);
            // 
            // toolStripSeparator15
            // 
            this.toolStripSeparator15.Name = "toolStripSeparator15";
            this.toolStripSeparator15.Size = new System.Drawing.Size(187, 6);
            // 
            // goToStartMenuItem
            // 
            this.goToStartMenuItem.Enabled = false;
            this.goToStartMenuItem.Name = "goToStartMenuItem";
            this.goToStartMenuItem.Size = new System.Drawing.Size(190, 22);
            this.goToStartMenuItem.Text = "Go to Start";
            this.goToStartMenuItem.Click += new System.EventHandler(this.goToStartMenuItem_Click);
            // 
            // positionLabel2
            // 
            this.positionLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.positionLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.positionLabel2.ContextMenuStrip = this.positionSliderMenu;
            this.positionLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.positionLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(159)))), ((int)(((byte)(87)))));
            this.positionLabel2.Location = new System.Drawing.Point(569, 1);
            this.positionLabel2.Name = "positionLabel2";
            this.positionLabel2.Size = new System.Drawing.Size(81, 18);
            this.positionLabel2.TabIndex = 2;
            this.positionLabel2.Text = "00:00:00";
            this.toolTip1.SetToolTip(this.positionLabel2, "Player.GetMediaLength - duration to end of media or to \'EndPosition\'.");
            // 
            // positionLabel1
            // 
            this.positionLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.positionLabel1.ContextMenuStrip = this.positionSliderMenu;
            this.positionLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.positionLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(159)))), ((int)(((byte)(87)))));
            this.positionLabel1.Location = new System.Drawing.Point(3, 1);
            this.positionLabel1.Name = "positionLabel1";
            this.positionLabel1.Size = new System.Drawing.Size(82, 18);
            this.positionLabel1.TabIndex = 0;
            this.positionLabel1.Text = "00:00:00";
            this.toolTip1.SetToolTip(this.positionLabel1, "Player.Position - duration from beginning of media or from \'StartPosition\'.");
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
            this.displayParentPanel.Location = new System.Drawing.Point(165, 8);
            this.displayParentPanel.Name = "displayParentPanel";
            this.displayParentPanel.Size = new System.Drawing.Size(654, 503);
            this.displayParentPanel.TabIndex = 1;
            // 
            // positionSliderPanel
            // 
            this.positionSliderPanel.ContextMenuStrip = this.positionSliderMenu;
            this.positionSliderPanel.Controls.Add(this.positionSlider);
            this.positionSliderPanel.Controls.Add(this.positionLabel2);
            this.positionSliderPanel.Controls.Add(this.positionLabel1);
            this.positionSliderPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.positionSliderPanel.Location = new System.Drawing.Point(0, 478);
            this.positionSliderPanel.Name = "positionSliderPanel";
            this.positionSliderPanel.Size = new System.Drawing.Size(652, 23);
            this.positionSliderPanel.TabIndex = 0;
            // 
            // rightFramePanel
            // 
            this.rightFramePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rightFramePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.rightFramePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rightFramePanel.Controls.Add(this.shuttlePanel);
            this.rightFramePanel.Controls.Add(this.sceencopyPanel);
            this.rightFramePanel.Controls.Add(this.zoomPanel);
            this.rightFramePanel.Controls.Add(this.audioPanel);
            this.rightFramePanel.Location = new System.Drawing.Point(823, 8);
            this.rightFramePanel.Name = "rightFramePanel";
            this.rightFramePanel.Size = new System.Drawing.Size(154, 503);
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
            this.shuttlePanel.Size = new System.Drawing.Size(140, 78);
            this.shuttlePanel.TabIndex = 3;
            // 
            // shuttleLabel
            // 
            this.shuttleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(159)))), ((int)(((byte)(87)))));
            this.shuttleLabel.Location = new System.Drawing.Point(9, 9);
            this.shuttleLabel.Name = "shuttleLabel";
            this.shuttleLabel.Size = new System.Drawing.Size(121, 21);
            this.shuttleLabel.TabIndex = 0;
            this.shuttleLabel.Text = "Shuttle";
            this.shuttleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sceencopyPanel
            // 
            this.sceencopyPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.sceencopyPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sceencopyPanel.Controls.Add(this.pictureBox1);
            this.sceencopyPanel.Controls.Add(this.copyLabelPanel);
            this.sceencopyPanel.Location = new System.Drawing.Point(6, 310);
            this.sceencopyPanel.Name = "sceencopyPanel";
            this.sceencopyPanel.Size = new System.Drawing.Size(140, 102);
            this.sceencopyPanel.TabIndex = 2;
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
            // copyModeLabelText
            // 
            this.copyModeLabelText.AutoSize = true;
            this.copyModeLabelText.BackColor = System.Drawing.Color.Transparent;
            this.copyModeLabelText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(159)))), ((int)(((byte)(87)))));
            this.copyModeLabelText.Location = new System.Drawing.Point(3, 3);
            this.copyModeLabelText.Name = "copyModeLabelText";
            this.copyModeLabelText.Size = new System.Drawing.Size(64, 13);
            this.copyModeLabelText.TabIndex = 0;
            this.copyModeLabelText.Text = "Screencopy";
            // 
            // zoomPanel
            // 
            this.zoomPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.zoomPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.zoomPanel.Controls.Add(this.stretchRightButton);
            this.zoomPanel.Controls.Add(this.stretchLeftButton);
            this.zoomPanel.Controls.Add(this.stretchDownButton);
            this.zoomPanel.Controls.Add(this.stretchUpButton);
            this.zoomPanel.Controls.Add(this.moveRightButton);
            this.zoomPanel.Controls.Add(this.moveLeftButton);
            this.zoomPanel.Controls.Add(this.moveDownButton);
            this.zoomPanel.Controls.Add(this.moveUpButton);
            this.zoomPanel.Controls.Add(this.zoomOutButton);
            this.zoomPanel.Controls.Add(this.zoomInButton);
            this.zoomPanel.Controls.Add(this.headLabel1);
            this.zoomPanel.Controls.Add(this.moveLabel);
            this.zoomPanel.Controls.Add(this.zoomLabel);
            this.zoomPanel.Location = new System.Drawing.Point(6, 158);
            this.zoomPanel.Name = "zoomPanel";
            this.zoomPanel.Size = new System.Drawing.Size(140, 147);
            this.zoomPanel.TabIndex = 1;
            // 
            // headLabel1
            // 
            this.headLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(159)))), ((int)(((byte)(87)))));
            this.headLabel1.Location = new System.Drawing.Point(9, 98);
            this.headLabel1.Name = "headLabel1";
            this.headLabel1.Size = new System.Drawing.Size(121, 19);
            this.headLabel1.TabIndex = 8;
            this.headLabel1.Text = "Video Stretch";
            this.headLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // moveLabel
            // 
            this.moveLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(159)))), ((int)(((byte)(87)))));
            this.moveLabel.Location = new System.Drawing.Point(9, 54);
            this.moveLabel.Name = "moveLabel";
            this.moveLabel.Size = new System.Drawing.Size(121, 19);
            this.moveLabel.TabIndex = 3;
            this.moveLabel.Text = "Video Move";
            this.moveLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // zoomLabel
            // 
            this.zoomLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(159)))), ((int)(((byte)(87)))));
            this.zoomLabel.Location = new System.Drawing.Point(9, 10);
            this.zoomLabel.Name = "zoomLabel";
            this.zoomLabel.Size = new System.Drawing.Size(121, 19);
            this.zoomLabel.TabIndex = 0;
            this.zoomLabel.Text = "Video Zoom";
            this.zoomLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // audioPanel
            // 
            this.audioPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.audioPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.audioPanel.Controls.Add(this.balanceSlider);
            this.audioPanel.Controls.Add(this.volumeSlider);
            this.audioPanel.Controls.Add(this.balanceLabelPanel);
            this.audioPanel.Controls.Add(this.volumeLabelPanel);
            this.audioPanel.Location = new System.Drawing.Point(6, 6);
            this.audioPanel.Name = "audioPanel";
            this.audioPanel.Size = new System.Drawing.Size(140, 147);
            this.audioPanel.TabIndex = 0;
            // 
            // balanceLabelPanel
            // 
            this.balanceLabelPanel.Controls.Add(this.audioBalanceLabel);
            this.balanceLabelPanel.Controls.Add(this.audioBalanceLabelText);
            this.balanceLabelPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.balanceLabelPanel.Location = new System.Drawing.Point(9, 77);
            this.balanceLabelPanel.Name = "balanceLabelPanel";
            this.balanceLabelPanel.Size = new System.Drawing.Size(121, 22);
            this.balanceLabelPanel.TabIndex = 2;
            this.balanceLabelPanel.Click += new System.EventHandler(this.balanceLabelPanel_Click);
            // 
            // audioBalanceLabel
            // 
            this.audioBalanceLabel.BackColor = System.Drawing.Color.Transparent;
            this.audioBalanceLabel.ContextMenuStrip = this.sliderMenu;
            this.audioBalanceLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(159)))), ((int)(((byte)(87)))));
            this.audioBalanceLabel.Location = new System.Drawing.Point(60, 4);
            this.audioBalanceLabel.Name = "audioBalanceLabel";
            this.audioBalanceLabel.Size = new System.Drawing.Size(59, 13);
            this.audioBalanceLabel.TabIndex = 1;
            this.audioBalanceLabel.Text = "Center";
            this.audioBalanceLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.audioBalanceLabel.Click += new System.EventHandler(this.balanceLabelPanel_Click);
            // 
            // volumeLabelPanel
            // 
            this.volumeLabelPanel.Controls.Add(this.volumeLight);
            this.volumeLabelPanel.Controls.Add(this.audioVolumeLabel);
            this.volumeLabelPanel.Controls.Add(this.audioVolumeLabelText);
            this.volumeLabelPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.volumeLabelPanel.Location = new System.Drawing.Point(9, 9);
            this.volumeLabelPanel.Name = "volumeLabelPanel";
            this.volumeLabelPanel.Size = new System.Drawing.Size(121, 22);
            this.volumeLabelPanel.TabIndex = 0;
            this.volumeLabelPanel.Click += new System.EventHandler(this.volumeLabelPanel_Click);
            // 
            // volumeLight
            // 
            this.volumeLight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.volumeLight.ForeColor = System.Drawing.Color.Red;
            this.volumeLight.Location = new System.Drawing.Point(7, 8);
            this.volumeLight.Name = "volumeLight";
            this.volumeLight.Size = new System.Drawing.Size(3, 6);
            this.volumeLight.TabIndex = 0;
            // 
            // audioVolumeLabel
            // 
            this.audioVolumeLabel.BackColor = System.Drawing.Color.Transparent;
            this.audioVolumeLabel.ContextMenuStrip = this.sliderMenu;
            this.audioVolumeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(159)))), ((int)(((byte)(87)))));
            this.audioVolumeLabel.Location = new System.Drawing.Point(73, 4);
            this.audioVolumeLabel.Name = "audioVolumeLabel";
            this.audioVolumeLabel.Size = new System.Drawing.Size(46, 13);
            this.audioVolumeLabel.TabIndex = 2;
            this.audioVolumeLabel.Text = "Max";
            this.audioVolumeLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.audioVolumeLabel.Click += new System.EventHandler(this.volumeLabelPanel_Click);
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
            this.sortListMenuItem});
            this.playSubMenu.Name = "playSubMenu";
            this.playSubMenu.ShowImageMargin = false;
            this.playSubMenu.Size = new System.Drawing.Size(144, 132);
            this.playSubMenu.Closed += new System.Windows.Forms.ToolStripDropDownClosedEventHandler(this.playSubMenu_Closed);
            this.playSubMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.playSubMenu_ItemClicked);
            this.playSubMenu.MouseLeave += new System.EventHandler(this.playSubMenu_MouseLeave);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(984, 517);
            this.Controls.Add(this.rightFramePanel);
            this.Controls.Add(this.displayParentPanel);
            this.Controls.Add(this.leftFramePanel);
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(557, 555);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.leftFramePanel.ResumeLayout(false);
            this.speedPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.speedSlider)).EndInit();
            this.sliderMenu.ResumeLayout(false);
            this.speedLabelPanel.ResumeLayout(false);
            this.speedLabelPanel.PerformLayout();
            this.repeatPanel.ResumeLayout(false);
            this.repeatPanel.PerformLayout();
            this.repeatMenu.ResumeLayout(false);
            this.displayModePanel.ResumeLayout(false);
            this.displayOverlayMenu.ResumeLayout(false);
            this.fullScreenModeMenu.ResumeLayout(false);
            this.playPanel.ResumeLayout(false);
            this.playMenu.ResumeLayout(false);
            this.titlePanel.ResumeLayout(false);
            this.titlePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.screenCopyMenu.ResumeLayout(false);
            this.copyModeMenu.ResumeLayout(false);
            this.displayMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.shuttleSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.balanceSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.volumeSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.positionSlider)).EndInit();
            this.positionSliderMenu.ResumeLayout(false);
            this.displayParentPanel.ResumeLayout(false);
            this.positionSliderPanel.ResumeLayout(false);
            this.rightFramePanel.ResumeLayout(false);
            this.shuttlePanel.ResumeLayout(false);
            this.sceencopyPanel.ResumeLayout(false);
            this.copyLabelPanel.ResumeLayout(false);
            this.copyLabelPanel.PerformLayout();
            this.zoomPanel.ResumeLayout(false);
            this.audioPanel.ResumeLayout(false);
            this.balanceLabelPanel.ResumeLayout(false);
            this.balanceLabelPanel.PerformLayout();
            this.volumeLabelPanel.ResumeLayout(false);
            this.volumeLabelPanel.PerformLayout();
            this.playSubMenu.ResumeLayout(false);
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
        private MaskedTextBox endPositionTextBox;
        private MaskedTextBox startPositionTextBox;
        private HeadLabel nextFromLabel;
        private MaskedTextBox endPositionMediaTextBox;
        private MaskedTextBox startPositionMediaTextBox;
        private HeadLabel currentFromLabel;
        private Panel speedPanel;
        private CustomPanel speedLabelPanel;
        private Label speedLabelText;
        private Panel displayParentPanel;
        private Label positionLabel2;
        private Label positionLabel1;
        private Panel displayPanel;
        private Panel rightFramePanel;
        private Panel audioPanel;
        private CustomPanel volumeLabelPanel;
        private Label audioVolumeLabel;
        private Label audioVolumeLabelText;
        private CustomPanel balanceLabelPanel;
        private Label audioBalanceLabel;
        private Label audioBalanceLabelText;
        private Panel zoomPanel;
        private HeadLabel moveLabel;
        private HeadLabel zoomLabel;
        private Panel sceencopyPanel;
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
        private ToolStripMenuItem startRepeatMenuItem;
        private ToolStripSeparator toolStripSeparator14;
        private ToolStripMenuItem mark1MenuItem;
        private ToolStripMenuItem goToMark1MenuItem;
        private ToolStripSeparator toolStripSeparator15;
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
        private HeadLabel headLabel1;
        private ToolStripMenuItem nextMenuItem;
        private ToolStripMenuItem previousMenuItem;
        private ToolStripMenuItem bigTimeMenuItem;
        private CustomSlider positionSlider;
        private SliderPanel positionSliderPanel;
        private CustomSlider2 speedSlider;
        private CustomSlider2 volumeSlider;
        private CustomSlider2 balanceSlider;
        private CustomSlider2 shuttleSlider;
        private CustomButton zoomInButton;
        private CustomButton zoomOutButton;
        private CustomButton moveUpButton;
        private CustomButton moveDownButton;
        private CustomButton moveLeftButton;
        private CustomButton moveRightButton;
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
        private LightPanel volumeLight;
        private CustomButton overlayMenuButton;
        private ToolStripMenuItem overlayMenuMenuItem;
        private ToolStripSeparator toolStripSeparator20;
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
        private ToolStripMenuItem voiceRecorderMenuItem;
        private ToolStripMenuItem showRecorderMenuItem;
        private ToolStripMenuItem showPlayerMenuItem;
        private ToolStripSeparator toolStripSeparator27;
        private ToolStripMenuItem closeRecorderMenuItem;
        private ToolStripMenuItem showAllMenuItem;
        private ToolStripMenuItem hideAllMenuItem;
        private ToolStripSeparator toolStripSeparator30;
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
        private ToolStripSeparator toolStripSeparator31;
        private ToolStripMenuItem preferencesMenuItem;
    }
}

