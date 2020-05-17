namespace FolderView
{
    partial class PlayerWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        ///// <summary>
        ///// Clean up any resources being used.
        ///// </summary>
        ///// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing && (components != null))
        //    {
        //        components.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.playerWindowMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.allWindowsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pauseAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resumeAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.muteAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.displayModeAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.coverAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stretchAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fullScreenOffAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.showSubtitlesAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hideSubtitlesAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.closeAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.pauseMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.muteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.audioHoldMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.displayMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.coverMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stretchMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayShapeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.heartShapeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ovalShapeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rectangleShapeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.roundedShapeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.starShapeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tilesShapeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.normalShapeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.fullScreenMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.showSubtitlesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showSubtitleOptionsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.propertiesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.closeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.positionLabel1 = new System.Windows.Forms.Label();
            this.positionLabel2 = new System.Windows.Forms.Label();
            this.customSlider21 = new FolderView.CustomSlider2();
            this.playerWindowMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customSlider21)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(632, 355);
            this.panel1.TabIndex = 0;
            this.panel1.TabStop = true;
            // 
            // playerWindowMenu
            // 
            this.playerWindowMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allWindowsMenuItem,
            this.toolStripSeparator7,
            this.pauseMenuItem,
            this.toolStripSeparator10,
            this.muteMenuItem,
            this.audioHoldMenuItem,
            this.toolStripSeparator2,
            this.displayMenuItem,
            this.displayShapeMenuItem,
            this.toolStripSeparator11,
            this.fullScreenMenuItem,
            this.toolStripSeparator3,
            this.showSubtitlesMenuItem,
            this.showSubtitleOptionsMenuItem,
            this.toolStripSeparator4,
            this.propertiesMenuItem,
            this.toolStripSeparator1,
            this.closeMenuItem});
            this.playerWindowMenu.Name = "contextMenuStrip1";
            this.playerWindowMenu.ShowImageMargin = false;
            this.playerWindowMenu.Size = new System.Drawing.Size(161, 288);
            this.playerWindowMenu.Opening += new System.ComponentModel.CancelEventHandler(this.PlayerWindowMenu_Opening);
            // 
            // allWindowsMenuItem
            // 
            this.allWindowsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pauseAllMenuItem,
            this.resumeAllMenuItem,
            this.toolStripSeparator9,
            this.muteAllMenuItem,
            this.toolStripSeparator6,
            this.displayModeAllMenuItem,
            this.fullScreenOffAllMenuItem,
            this.toolStripSeparator5,
            this.showSubtitlesAllMenuItem,
            this.hideSubtitlesAllMenuItem,
            this.toolStripSeparator8,
            this.closeAllMenuItem});
            this.allWindowsMenuItem.Name = "allWindowsMenuItem";
            this.allWindowsMenuItem.Size = new System.Drawing.Size(160, 22);
            this.allWindowsMenuItem.Text = "All Windows";
            // 
            // pauseAllMenuItem
            // 
            this.pauseAllMenuItem.Name = "pauseAllMenuItem";
            this.pauseAllMenuItem.Size = new System.Drawing.Size(168, 22);
            this.pauseAllMenuItem.Text = "Pause All";
            this.pauseAllMenuItem.Click += new System.EventHandler(this.PauseAllMenuItem_Click);
            // 
            // resumeAllMenuItem
            // 
            this.resumeAllMenuItem.Name = "resumeAllMenuItem";
            this.resumeAllMenuItem.Size = new System.Drawing.Size(168, 22);
            this.resumeAllMenuItem.Text = "Resume All";
            this.resumeAllMenuItem.Click += new System.EventHandler(this.ResumeAllMenuItem_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(165, 6);
            // 
            // muteAllMenuItem
            // 
            this.muteAllMenuItem.Name = "muteAllMenuItem";
            this.muteAllMenuItem.Size = new System.Drawing.Size(168, 22);
            this.muteAllMenuItem.Text = "Mute All";
            this.muteAllMenuItem.Click += new System.EventHandler(this.MuteAllMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(165, 6);
            // 
            // displayModeAllMenuItem
            // 
            this.displayModeAllMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoomAllMenuItem,
            this.coverAllMenuItem,
            this.stretchAllMenuItem});
            this.displayModeAllMenuItem.Name = "displayModeAllMenuItem";
            this.displayModeAllMenuItem.Size = new System.Drawing.Size(168, 22);
            this.displayModeAllMenuItem.Text = "Display Mode All";
            // 
            // zoomAllMenuItem
            // 
            this.zoomAllMenuItem.Name = "zoomAllMenuItem";
            this.zoomAllMenuItem.Size = new System.Drawing.Size(111, 22);
            this.zoomAllMenuItem.Text = "Zoom";
            this.zoomAllMenuItem.Click += new System.EventHandler(this.ZoomAllMenuItem_Click);
            // 
            // coverAllMenuItem
            // 
            this.coverAllMenuItem.Name = "coverAllMenuItem";
            this.coverAllMenuItem.Size = new System.Drawing.Size(111, 22);
            this.coverAllMenuItem.Text = "Cover";
            this.coverAllMenuItem.Click += new System.EventHandler(this.CoverAllMenuItem_Click);
            // 
            // stretchAllMenuItem
            // 
            this.stretchAllMenuItem.Name = "stretchAllMenuItem";
            this.stretchAllMenuItem.Size = new System.Drawing.Size(111, 22);
            this.stretchAllMenuItem.Text = "Stretch";
            this.stretchAllMenuItem.Click += new System.EventHandler(this.StretchAllMenuItem_Click);
            // 
            // fullScreenOffAllMenuItem
            // 
            this.fullScreenOffAllMenuItem.Name = "fullScreenOffAllMenuItem";
            this.fullScreenOffAllMenuItem.Size = new System.Drawing.Size(168, 22);
            this.fullScreenOffAllMenuItem.Text = "FullScreen Off All";
            this.fullScreenOffAllMenuItem.Click += new System.EventHandler(this.FullScreenOffAllMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(165, 6);
            // 
            // showSubtitlesAllMenuItem
            // 
            this.showSubtitlesAllMenuItem.Name = "showSubtitlesAllMenuItem";
            this.showSubtitlesAllMenuItem.Size = new System.Drawing.Size(168, 22);
            this.showSubtitlesAllMenuItem.Text = "Show Subtitles All";
            this.showSubtitlesAllMenuItem.Click += new System.EventHandler(this.ShowSubtitlesAllMenuItem_Click);
            // 
            // hideSubtitlesAllMenuItem
            // 
            this.hideSubtitlesAllMenuItem.Name = "hideSubtitlesAllMenuItem";
            this.hideSubtitlesAllMenuItem.Size = new System.Drawing.Size(168, 22);
            this.hideSubtitlesAllMenuItem.Text = "Hide Subtitles All";
            this.hideSubtitlesAllMenuItem.Click += new System.EventHandler(this.HideSubtitlesAllMenuItem_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(165, 6);
            // 
            // closeAllMenuItem
            // 
            this.closeAllMenuItem.Name = "closeAllMenuItem";
            this.closeAllMenuItem.Size = new System.Drawing.Size(168, 22);
            this.closeAllMenuItem.Text = "Close All";
            this.closeAllMenuItem.Click += new System.EventHandler(this.CloseAllMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(157, 6);
            // 
            // pauseMenuItem
            // 
            this.pauseMenuItem.Name = "pauseMenuItem";
            this.pauseMenuItem.Size = new System.Drawing.Size(160, 22);
            this.pauseMenuItem.Text = "Pause";
            this.pauseMenuItem.Click += new System.EventHandler(this.PauseMenuItem_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(157, 6);
            // 
            // muteMenuItem
            // 
            this.muteMenuItem.Name = "muteMenuItem";
            this.muteMenuItem.Size = new System.Drawing.Size(160, 22);
            this.muteMenuItem.Text = "Mute";
            this.muteMenuItem.Click += new System.EventHandler(this.MuteMenuItem_Click);
            // 
            // audioHoldMenuItem
            // 
            this.audioHoldMenuItem.Name = "audioHoldMenuItem";
            this.audioHoldMenuItem.Size = new System.Drawing.Size(160, 22);
            this.audioHoldMenuItem.Text = "Audio Hold";
            this.audioHoldMenuItem.Click += new System.EventHandler(this.AudioHoldMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(157, 6);
            // 
            // displayMenuItem
            // 
            this.displayMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoomMenuItem,
            this.coverMenuItem,
            this.stretchMenuItem});
            this.displayMenuItem.Name = "displayMenuItem";
            this.displayMenuItem.Size = new System.Drawing.Size(160, 22);
            this.displayMenuItem.Text = "Display Mode";
            // 
            // zoomMenuItem
            // 
            this.zoomMenuItem.Checked = true;
            this.zoomMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.zoomMenuItem.Name = "zoomMenuItem";
            this.zoomMenuItem.Size = new System.Drawing.Size(111, 22);
            this.zoomMenuItem.Text = "Zoom";
            this.zoomMenuItem.Click += new System.EventHandler(this.ZoomMenuItem_Click);
            // 
            // coverMenuItem
            // 
            this.coverMenuItem.Name = "coverMenuItem";
            this.coverMenuItem.Size = new System.Drawing.Size(111, 22);
            this.coverMenuItem.Text = "Cover";
            this.coverMenuItem.Click += new System.EventHandler(this.CoverMenuItem_Click);
            // 
            // stretchMenuItem
            // 
            this.stretchMenuItem.Name = "stretchMenuItem";
            this.stretchMenuItem.Size = new System.Drawing.Size(111, 22);
            this.stretchMenuItem.Text = "Stretch";
            this.stretchMenuItem.Click += new System.EventHandler(this.StretchMenuItem_Click);
            // 
            // displayShapeMenuItem
            // 
            this.displayShapeMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.heartShapeMenuItem,
            this.ovalShapeMenuItem,
            this.rectangleShapeMenuItem,
            this.roundedShapeMenuItem,
            this.starShapeMenuItem,
            this.tilesShapeMenuItem,
            this.toolStripSeparator12,
            this.normalShapeMenuItem});
            this.displayShapeMenuItem.Name = "displayShapeMenuItem";
            this.displayShapeMenuItem.Size = new System.Drawing.Size(160, 22);
            this.displayShapeMenuItem.Text = "Display Shape";
            // 
            // heartShapeMenuItem
            // 
            this.heartShapeMenuItem.Name = "heartShapeMenuItem";
            this.heartShapeMenuItem.Size = new System.Drawing.Size(149, 22);
            this.heartShapeMenuItem.Text = "Heart";
            this.heartShapeMenuItem.Click += new System.EventHandler(this.HeartShapeMenuItem_Click);
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
            // roundedShapeMenuItem
            // 
            this.roundedShapeMenuItem.Name = "roundedShapeMenuItem";
            this.roundedShapeMenuItem.Size = new System.Drawing.Size(149, 22);
            this.roundedShapeMenuItem.Text = "Rounded";
            this.roundedShapeMenuItem.Click += new System.EventHandler(this.RoundedShapeMenuItem_Click);
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
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(146, 6);
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
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(157, 6);
            // 
            // fullScreenMenuItem
            // 
            this.fullScreenMenuItem.Name = "fullScreenMenuItem";
            this.fullScreenMenuItem.Size = new System.Drawing.Size(160, 22);
            this.fullScreenMenuItem.Text = "FullScreen";
            this.fullScreenMenuItem.Click += new System.EventHandler(this.FullScreenMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(157, 6);
            // 
            // showSubtitlesMenuItem
            // 
            this.showSubtitlesMenuItem.Enabled = false;
            this.showSubtitlesMenuItem.Name = "showSubtitlesMenuItem";
            this.showSubtitlesMenuItem.Size = new System.Drawing.Size(160, 22);
            this.showSubtitlesMenuItem.Text = "Show Subtitles";
            this.showSubtitlesMenuItem.Click += new System.EventHandler(this.ShowSubtitlesMenuItem_Click);
            // 
            // showSubtitleOptionsMenuItem
            // 
            this.showSubtitleOptionsMenuItem.Enabled = false;
            this.showSubtitleOptionsMenuItem.Name = "showSubtitleOptionsMenuItem";
            this.showSubtitleOptionsMenuItem.Size = new System.Drawing.Size(160, 22);
            this.showSubtitleOptionsMenuItem.Text = "Show Subtitles Menu";
            this.showSubtitleOptionsMenuItem.Click += new System.EventHandler(this.ShowSubtitleOptionsMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(157, 6);
            // 
            // propertiesMenuItem
            // 
            this.propertiesMenuItem.Name = "propertiesMenuItem";
            this.propertiesMenuItem.Size = new System.Drawing.Size(160, 22);
            this.propertiesMenuItem.Text = "Properties";
            this.propertiesMenuItem.Click += new System.EventHandler(this.PropertiesMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(157, 6);
            // 
            // closeMenuItem
            // 
            this.closeMenuItem.Name = "closeMenuItem";
            this.closeMenuItem.Size = new System.Drawing.Size(160, 22);
            this.closeMenuItem.Text = "Close";
            this.closeMenuItem.Click += new System.EventHandler(this.CloseMenuItem_Click);
            // 
            // positionLabel1
            // 
            this.positionLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.positionLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.positionLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.positionLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.positionLabel1.Location = new System.Drawing.Point(2, 358);
            this.positionLabel1.Name = "positionLabel1";
            this.positionLabel1.Size = new System.Drawing.Size(84, 20);
            this.positionLabel1.TabIndex = 1;
            this.positionLabel1.Text = "00:00:00";
            // 
            // positionLabel2
            // 
            this.positionLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.positionLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.positionLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.positionLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(96)))), ((int)(((byte)(96)))));
            this.positionLabel2.Location = new System.Drawing.Point(550, 358);
            this.positionLabel2.Name = "positionLabel2";
            this.positionLabel2.Size = new System.Drawing.Size(84, 20);
            this.positionLabel2.TabIndex = 3;
            this.positionLabel2.Text = "00:00:00";
            // 
            // customSlider21
            // 
            this.customSlider21.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customSlider21.AutoSize = false;
            this.customSlider21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.customSlider21.Location = new System.Drawing.Point(80, 360);
            this.customSlider21.Name = "customSlider21";
            this.customSlider21.Size = new System.Drawing.Size(470, 30);
            this.customSlider21.TabIndex = 4;
            this.customSlider21.Scroll += new System.EventHandler(this.CustomSlider21_Scroll);
            // 
            // PlayerWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.ClientSize = new System.Drawing.Size(632, 381);
            this.ContextMenuStrip = this.playerWindowMenu;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.customSlider21);
            this.Controls.Add(this.positionLabel2);
            this.Controls.Add(this.positionLabel1);
            this.MinimumSize = new System.Drawing.Size(200, 166);
            this.Name = "PlayerWindow";
            this.Text = "Form2";
            this.Activated += new System.EventHandler(this.PlayerWindow_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PlayerWindow_FormClosed);
            this.Shown += new System.EventHandler(this.PlayerWindow_Shown);
            this.playerWindowMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.customSlider21)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ContextMenuStrip playerWindowMenu;
        private System.Windows.Forms.ToolStripMenuItem displayMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fullScreenMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem closeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem coverMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomMenuItem;
        private System.Windows.Forms.ToolStripMenuItem muteMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Label positionLabel1;
        private System.Windows.Forms.Label positionLabel2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem propertiesMenuItem;
        internal CustomSlider2 customSlider21;
        private System.Windows.Forms.ToolStripMenuItem showSubtitlesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showSubtitleOptionsMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem allWindowsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pauseAllMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resumeAllMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem muteAllMenuItem;
        private System.Windows.Forms.ToolStripMenuItem displayModeAllMenuItem;
        private System.Windows.Forms.ToolStripMenuItem coverAllMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomAllMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem closeAllMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem fullScreenOffAllMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hideSubtitlesAllMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        internal System.Windows.Forms.ToolStripMenuItem pauseMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showSubtitlesAllMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripMenuItem stretchMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stretchAllMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripMenuItem audioHoldMenuItem;
        private System.Windows.Forms.ToolStripMenuItem displayShapeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem heartShapeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ovalShapeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rectangleShapeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem roundedShapeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem starShapeMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.ToolStripMenuItem normalShapeMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripMenuItem tilesShapeMenuItem;
    }
}