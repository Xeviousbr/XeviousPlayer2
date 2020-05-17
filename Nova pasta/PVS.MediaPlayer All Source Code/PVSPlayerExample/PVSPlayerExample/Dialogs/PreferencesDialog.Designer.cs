namespace PVSPlayerExample
{
    partial class PreferencesDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pvsPanel = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cancelButton = new PVSPlayerExample.CustomButton();
            this.OKButton = new PVSPlayerExample.CustomButton();
            this.saveWindowBox = new System.Windows.Forms.CheckBox();
            this.autoOverlayBox = new System.Windows.Forms.CheckBox();
            this.mediaFilesLabel = new System.Windows.Forms.Label();
            this.playlistsLabel = new System.Windows.Forms.Label();
            this.continuePlayBox = new System.Windows.Forms.CheckBox();
            this.showToolTipsBox = new System.Windows.Forms.CheckBox();
            this.saveDisplayModeBox = new System.Windows.Forms.CheckBox();
            this.saveOverlayBox = new System.Windows.Forms.CheckBox();
            this.saveRepeatBox = new System.Windows.Forms.CheckBox();
            this.autoPlayNextBox = new System.Windows.Forms.CheckBox();
            this.onErrorRemoveBox = new System.Windows.Forms.CheckBox();
            this.autoHideCursorBox = new System.Windows.Forms.CheckBox();
            this.noMessageBox = new System.Windows.Forms.CheckBox();
            this.saveMediaFolderBox = new System.Windows.Forms.CheckBox();
            this.savePlaylistBox = new System.Windows.Forms.CheckBox();
            this.enablePlayersBox = new System.Windows.Forms.CheckBox();
            this.saveAudioBox = new System.Windows.Forms.CheckBox();
            this.secondsLabel = new System.Windows.Forms.Label();
            this.secondsBox = new System.Windows.Forms.NumericUpDown();
            this.autoPlayStartBox = new System.Windows.Forms.CheckBox();
            this.saveSpeedBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.showExtensionsBox = new System.Windows.Forms.CheckBox();
            this.saveSliderBox = new System.Windows.Forms.CheckBox();
            this.showClockBox = new System.Windows.Forms.CheckBox();
            this.autoPlayAddedBox = new System.Windows.Forms.CheckBox();
            this.clockColorPanel = new System.Windows.Forms.Panel();
            this.clock24hLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.secondsBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.pvsPanel);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.cancelButton);
            this.panel1.Controls.Add(this.OKButton);
            this.panel1.Location = new System.Drawing.Point(1, 359);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(539, 49);
            this.panel1.TabIndex = 28;
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(259, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(78, 41);
            this.panel4.TabIndex = 6;
            // 
            // pvsPanel
            // 
            this.pvsPanel.Location = new System.Drawing.Point(10, 10);
            this.pvsPanel.Name = "pvsPanel";
            this.pvsPanel.Size = new System.Drawing.Size(42, 33);
            this.pvsPanel.TabIndex = 5;
            this.pvsPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.PvsPanel_Paint);
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(163, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(78, 41);
            this.panel3.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(64, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(78, 41);
            this.panel2.TabIndex = 0;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FocusBorder = true;
            this.cancelButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.cancelButton.Location = new System.Drawing.Point(442, 14);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(84, 23);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // OKButton
            // 
            this.OKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.OKButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKButton.FocusBorder = true;
            this.OKButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.OKButton.Location = new System.Drawing.Point(349, 14);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(84, 23);
            this.OKButton.TabIndex = 3;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // saveWindowBox
            // 
            this.saveWindowBox.AutoSize = true;
            this.saveWindowBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveWindowBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.saveWindowBox.Location = new System.Drawing.Point(26, 23);
            this.saveWindowBox.Name = "saveWindowBox";
            this.saveWindowBox.Size = new System.Drawing.Size(234, 19);
            this.saveWindowBox.TabIndex = 0;
            this.saveWindowBox.Text = "Remember Window Size and Position";
            this.saveWindowBox.UseVisualStyleBackColor = true;
            // 
            // autoOverlayBox
            // 
            this.autoOverlayBox.AutoSize = true;
            this.autoOverlayBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoOverlayBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.autoOverlayBox.Location = new System.Drawing.Point(26, 198);
            this.autoOverlayBox.Name = "autoOverlayBox";
            this.autoOverlayBox.Size = new System.Drawing.Size(262, 19);
            this.autoOverlayBox.TabIndex = 7;
            this.autoOverlayBox.Text = "Enable Automatic Display Overlay Selection";
            this.autoOverlayBox.UseVisualStyleBackColor = true;
            // 
            // mediaFilesLabel
            // 
            this.mediaFilesLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mediaFilesLabel.AutoEllipsis = true;
            this.mediaFilesLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mediaFilesLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.mediaFilesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mediaFilesLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.mediaFilesLabel.Location = new System.Drawing.Point(174, 248);
            this.mediaFilesLabel.Name = "mediaFilesLabel";
            this.mediaFilesLabel.Size = new System.Drawing.Size(345, 20);
            this.mediaFilesLabel.TabIndex = 12;
            this.mediaFilesLabel.Click += new System.EventHandler(this.MediaFilesLabel_Click);
            // 
            // playlistsLabel
            // 
            this.playlistsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.playlistsLabel.AutoEllipsis = true;
            this.playlistsLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.playlistsLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.playlistsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playlistsLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.playlistsLabel.Location = new System.Drawing.Point(174, 273);
            this.playlistsLabel.Name = "playlistsLabel";
            this.playlistsLabel.Size = new System.Drawing.Size(345, 20);
            this.playlistsLabel.TabIndex = 14;
            this.playlistsLabel.Click += new System.EventHandler(this.PlaylistsLabel_Click);
            // 
            // continuePlayBox
            // 
            this.continuePlayBox.AutoSize = true;
            this.continuePlayBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.continuePlayBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.continuePlayBox.Location = new System.Drawing.Point(26, 298);
            this.continuePlayBox.Name = "continuePlayBox";
            this.continuePlayBox.Size = new System.Drawing.Size(362, 19);
            this.continuePlayBox.TabIndex = 15;
            this.continuePlayBox.Text = "Continue Playing Media at Next Program Start - Rewind Video";
            this.continuePlayBox.UseVisualStyleBackColor = true;
            // 
            // showToolTipsBox
            // 
            this.showToolTipsBox.AutoSize = true;
            this.showToolTipsBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showToolTipsBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.showToolTipsBox.Location = new System.Drawing.Point(323, 198);
            this.showToolTipsBox.Name = "showToolTipsBox";
            this.showToolTipsBox.Size = new System.Drawing.Size(186, 19);
            this.showToolTipsBox.TabIndex = 26;
            this.showToolTipsBox.Text = "Show Programmers ToolTips";
            this.showToolTipsBox.UseVisualStyleBackColor = true;
            // 
            // saveDisplayModeBox
            // 
            this.saveDisplayModeBox.AutoSize = true;
            this.saveDisplayModeBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveDisplayModeBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.saveDisplayModeBox.Location = new System.Drawing.Point(26, 73);
            this.saveDisplayModeBox.Name = "saveDisplayModeBox";
            this.saveDisplayModeBox.Size = new System.Drawing.Size(208, 19);
            this.saveDisplayModeBox.TabIndex = 2;
            this.saveDisplayModeBox.Text = "Remember Display Mode Setting";
            this.saveDisplayModeBox.UseVisualStyleBackColor = true;
            // 
            // saveOverlayBox
            // 
            this.saveOverlayBox.AutoSize = true;
            this.saveOverlayBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveOverlayBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.saveOverlayBox.Location = new System.Drawing.Point(26, 173);
            this.saveOverlayBox.Name = "saveOverlayBox";
            this.saveOverlayBox.Size = new System.Drawing.Size(226, 19);
            this.saveOverlayBox.TabIndex = 6;
            this.saveOverlayBox.Text = "Remember Selected Display Overlay";
            this.saveOverlayBox.UseVisualStyleBackColor = true;
            // 
            // saveRepeatBox
            // 
            this.saveRepeatBox.AutoSize = true;
            this.saveRepeatBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveRepeatBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.saveRepeatBox.Location = new System.Drawing.Point(26, 98);
            this.saveRepeatBox.Name = "saveRepeatBox";
            this.saveRepeatBox.Size = new System.Drawing.Size(225, 19);
            this.saveRepeatBox.TabIndex = 3;
            this.saveRepeatBox.Text = "Remember Playback Repeat Setting";
            this.saveRepeatBox.UseVisualStyleBackColor = true;
            // 
            // autoPlayNextBox
            // 
            this.autoPlayNextBox.AutoSize = true;
            this.autoPlayNextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoPlayNextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.autoPlayNextBox.Location = new System.Drawing.Point(323, 73);
            this.autoPlayNextBox.Name = "autoPlayNextBox";
            this.autoPlayNextBox.Size = new System.Drawing.Size(173, 19);
            this.autoPlayNextBox.TabIndex = 21;
            this.autoPlayNextBox.Text = "Auto Play Next from Playlist";
            this.autoPlayNextBox.UseVisualStyleBackColor = true;
            // 
            // onErrorRemoveBox
            // 
            this.onErrorRemoveBox.AutoSize = true;
            this.onErrorRemoveBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.onErrorRemoveBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.onErrorRemoveBox.Location = new System.Drawing.Point(323, 123);
            this.onErrorRemoveBox.Name = "onErrorRemoveBox";
            this.onErrorRemoveBox.Size = new System.Drawing.Size(190, 19);
            this.onErrorRemoveBox.TabIndex = 23;
            this.onErrorRemoveBox.Text = "On Error Remove from Playlist";
            this.onErrorRemoveBox.UseVisualStyleBackColor = true;
            // 
            // autoHideCursorBox
            // 
            this.autoHideCursorBox.AutoSize = true;
            this.autoHideCursorBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoHideCursorBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.autoHideCursorBox.Location = new System.Drawing.Point(323, 98);
            this.autoHideCursorBox.Name = "autoHideCursorBox";
            this.autoHideCursorBox.Size = new System.Drawing.Size(194, 19);
            this.autoHideCursorBox.TabIndex = 22;
            this.autoHideCursorBox.Text = "Auto Hide Cursor when Playing";
            this.autoHideCursorBox.UseVisualStyleBackColor = true;
            // 
            // noMessageBox
            // 
            this.noMessageBox.AutoSize = true;
            this.noMessageBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noMessageBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.noMessageBox.Location = new System.Drawing.Point(323, 148);
            this.noMessageBox.Name = "noMessageBox";
            this.noMessageBox.Size = new System.Drawing.Size(179, 19);
            this.noMessageBox.TabIndex = 24;
            this.noMessageBox.Text = "Don\'t Show Error Messages";
            this.noMessageBox.UseVisualStyleBackColor = true;
            // 
            // saveMediaFolderBox
            // 
            this.saveMediaFolderBox.AutoSize = true;
            this.saveMediaFolderBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveMediaFolderBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.saveMediaFolderBox.Location = new System.Drawing.Point(26, 248);
            this.saveMediaFolderBox.Name = "saveMediaFolderBox";
            this.saveMediaFolderBox.Size = new System.Drawing.Size(134, 19);
            this.saveMediaFolderBox.TabIndex = 11;
            this.saveMediaFolderBox.Text = "Initial Media Folder:";
            this.saveMediaFolderBox.UseVisualStyleBackColor = true;
            // 
            // savePlaylistBox
            // 
            this.savePlaylistBox.AutoSize = true;
            this.savePlaylistBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.savePlaylistBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.savePlaylistBox.Location = new System.Drawing.Point(26, 273);
            this.savePlaylistBox.Name = "savePlaylistBox";
            this.savePlaylistBox.Size = new System.Drawing.Size(143, 19);
            this.savePlaylistBox.TabIndex = 13;
            this.savePlaylistBox.Text = "Initial Playlists Folder:";
            this.savePlaylistBox.UseVisualStyleBackColor = true;
            // 
            // enablePlayersBox
            // 
            this.enablePlayersBox.AutoSize = true;
            this.enablePlayersBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enablePlayersBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.enablePlayersBox.Location = new System.Drawing.Point(323, 223);
            this.enablePlayersBox.Name = "enablePlayersBox";
            this.enablePlayersBox.Size = new System.Drawing.Size(190, 19);
            this.enablePlayersBox.TabIndex = 27;
            this.enablePlayersBox.Text = "Enable Mini Videos in Dialogs";
            this.enablePlayersBox.UseVisualStyleBackColor = true;
            this.enablePlayersBox.CheckedChanged += new System.EventHandler(this.EnablePlayersBox_CheckedChanged);
            // 
            // saveAudioBox
            // 
            this.saveAudioBox.AutoSize = true;
            this.saveAudioBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveAudioBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.saveAudioBox.Location = new System.Drawing.Point(26, 48);
            this.saveAudioBox.Name = "saveAudioBox";
            this.saveAudioBox.Size = new System.Drawing.Size(240, 19);
            this.saveAudioBox.TabIndex = 1;
            this.saveAudioBox.Text = "Remember Audio Volume and Balance";
            this.saveAudioBox.UseVisualStyleBackColor = true;
            // 
            // secondsLabel
            // 
            this.secondsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.secondsLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.secondsLabel.Location = new System.Drawing.Point(447, 299);
            this.secondsLabel.Name = "secondsLabel";
            this.secondsLabel.Size = new System.Drawing.Size(71, 20);
            this.secondsLabel.TabIndex = 17;
            this.secondsLabel.Text = "second(s).";
            this.secondsLabel.Click += new System.EventHandler(this.SecondsLabel_Click);
            // 
            // secondsBox
            // 
            this.secondsBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.secondsBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.secondsBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.secondsBox.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.secondsBox.Location = new System.Drawing.Point(386, 299);
            this.secondsBox.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.secondsBox.Name = "secondsBox";
            this.secondsBox.Size = new System.Drawing.Size(60, 20);
            this.secondsBox.TabIndex = 16;
            this.secondsBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.secondsBox.Click += new System.EventHandler(this.SecondsBox_Click);
            this.secondsBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SecondsBox_KeyDown);
            // 
            // autoPlayStartBox
            // 
            this.autoPlayStartBox.AutoSize = true;
            this.autoPlayStartBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoPlayStartBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.autoPlayStartBox.Location = new System.Drawing.Point(323, 23);
            this.autoPlayStartBox.Name = "autoPlayStartBox";
            this.autoPlayStartBox.Size = new System.Drawing.Size(168, 19);
            this.autoPlayStartBox.TabIndex = 19;
            this.autoPlayStartBox.Text = "Auto Play at Program Start";
            this.autoPlayStartBox.UseVisualStyleBackColor = true;
            // 
            // saveSpeedBox
            // 
            this.saveSpeedBox.AutoSize = true;
            this.saveSpeedBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveSpeedBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.saveSpeedBox.Location = new System.Drawing.Point(26, 123);
            this.saveSpeedBox.Name = "saveSpeedBox";
            this.saveSpeedBox.Size = new System.Drawing.Size(221, 19);
            this.saveSpeedBox.TabIndex = 4;
            this.saveSpeedBox.Text = "Remember Playback Speed Setting";
            this.saveSpeedBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(43, 321);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(473, 15);
            this.label1.TabIndex = 18;
            this.label1.Text = "- This option also saves all relevant playback settings (Window Size and Position" +
    ", etc.).";
            // 
            // showExtensionsBox
            // 
            this.showExtensionsBox.AutoSize = true;
            this.showExtensionsBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showExtensionsBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.showExtensionsBox.Location = new System.Drawing.Point(323, 173);
            this.showExtensionsBox.Name = "showExtensionsBox";
            this.showExtensionsBox.Size = new System.Drawing.Size(197, 19);
            this.showExtensionsBox.TabIndex = 25;
            this.showExtensionsBox.Text = "Show File Extensions in Playlist";
            this.showExtensionsBox.UseVisualStyleBackColor = true;
            // 
            // saveSliderBox
            // 
            this.saveSliderBox.AutoSize = true;
            this.saveSliderBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveSliderBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.saveSliderBox.Location = new System.Drawing.Point(26, 148);
            this.saveSliderBox.Name = "saveSliderBox";
            this.saveSliderBox.Size = new System.Drawing.Size(218, 19);
            this.saveSliderBox.TabIndex = 5;
            this.saveSliderBox.Text = "Remember Position Slider Settings";
            this.saveSliderBox.UseVisualStyleBackColor = true;
            // 
            // showClockBox
            // 
            this.showClockBox.AutoSize = true;
            this.showClockBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showClockBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.showClockBox.Location = new System.Drawing.Point(26, 223);
            this.showClockBox.Name = "showClockBox";
            this.showClockBox.Size = new System.Drawing.Size(202, 19);
            this.showClockBox.TabIndex = 8;
            this.showClockBox.Text = "Show System Time in Info Panel";
            this.showClockBox.UseVisualStyleBackColor = true;
            this.showClockBox.CheckedChanged += new System.EventHandler(this.SystemTimeBox_CheckedChanged);
            // 
            // autoPlayAddedBox
            // 
            this.autoPlayAddedBox.AutoSize = true;
            this.autoPlayAddedBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.autoPlayAddedBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.autoPlayAddedBox.Location = new System.Drawing.Point(323, 48);
            this.autoPlayAddedBox.Name = "autoPlayAddedBox";
            this.autoPlayAddedBox.Size = new System.Drawing.Size(184, 19);
            this.autoPlayAddedBox.TabIndex = 20;
            this.autoPlayAddedBox.Text = "Auto Play Added Media if Idle";
            this.autoPlayAddedBox.UseVisualStyleBackColor = true;
            // 
            // clockColorPanel
            // 
            this.clockColorPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(163)))), ((int)(((byte)(136)))));
            this.clockColorPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.clockColorPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.clockColorPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.clockColorPanel.Location = new System.Drawing.Point(265, 225);
            this.clockColorPanel.Name = "clockColorPanel";
            this.clockColorPanel.Size = new System.Drawing.Size(16, 16);
            this.clockColorPanel.TabIndex = 10;
            this.clockColorPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ClockColorPanel_MouseClick);
            // 
            // clock24hLabel
            // 
            this.clock24hLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.clock24hLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.clock24hLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.clock24hLabel.Location = new System.Drawing.Point(226, 225);
            this.clock24hLabel.Name = "clock24hLabel";
            this.clock24hLabel.Size = new System.Drawing.Size(38, 16);
            this.clock24hLabel.TabIndex = 9;
            this.clock24hLabel.Text = "24 hr";
            this.clock24hLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.clock24hLabel.Click += new System.EventHandler(this.Clock24hLabel_Click);
            // 
            // PreferencesDialog
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(541, 409);
            this.Controls.Add(this.clock24hLabel);
            this.Controls.Add(this.clockColorPanel);
            this.Controls.Add(this.autoPlayAddedBox);
            this.Controls.Add(this.showClockBox);
            this.Controls.Add(this.saveSliderBox);
            this.Controls.Add(this.showExtensionsBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.saveSpeedBox);
            this.Controls.Add(this.autoPlayStartBox);
            this.Controls.Add(this.secondsBox);
            this.Controls.Add(this.secondsLabel);
            this.Controls.Add(this.saveAudioBox);
            this.Controls.Add(this.enablePlayersBox);
            this.Controls.Add(this.savePlaylistBox);
            this.Controls.Add(this.saveMediaFolderBox);
            this.Controls.Add(this.noMessageBox);
            this.Controls.Add(this.autoHideCursorBox);
            this.Controls.Add(this.onErrorRemoveBox);
            this.Controls.Add(this.autoPlayNextBox);
            this.Controls.Add(this.saveRepeatBox);
            this.Controls.Add(this.saveOverlayBox);
            this.Controls.Add(this.saveDisplayModeBox);
            this.Controls.Add(this.showToolTipsBox);
            this.Controls.Add(this.continuePlayBox);
            this.Controls.Add(this.playlistsLabel);
            this.Controls.Add(this.mediaFilesLabel);
            this.Controls.Add(this.autoOverlayBox);
            this.Controls.Add(this.saveWindowBox);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PreferencesDialog";
            this.Opacity = 0.95D;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Preferences";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PreferencesDialog_FormClosing);
            this.Shown += new System.EventHandler(this.PreferencesDialog_Shown);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.secondsBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private CustomButton OKButton;
        private CustomButton cancelButton;
        private System.Windows.Forms.CheckBox saveWindowBox;
        private System.Windows.Forms.CheckBox autoOverlayBox;
        private System.Windows.Forms.Label mediaFilesLabel;
        private System.Windows.Forms.Label playlistsLabel;
        private System.Windows.Forms.CheckBox continuePlayBox;
        private System.Windows.Forms.CheckBox showToolTipsBox;
        private System.Windows.Forms.CheckBox saveDisplayModeBox;
        private System.Windows.Forms.CheckBox saveOverlayBox;
        private System.Windows.Forms.CheckBox saveRepeatBox;
        private System.Windows.Forms.CheckBox autoPlayNextBox;
        private System.Windows.Forms.CheckBox onErrorRemoveBox;
        private System.Windows.Forms.CheckBox autoHideCursorBox;
        private System.Windows.Forms.CheckBox noMessageBox;
        private System.Windows.Forms.CheckBox saveMediaFolderBox;
        private System.Windows.Forms.CheckBox savePlaylistBox;
        internal System.Windows.Forms.Panel panel2;
        internal System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox enablePlayersBox;
        private System.Windows.Forms.CheckBox saveAudioBox;
        private System.Windows.Forms.Label secondsLabel;
        private System.Windows.Forms.NumericUpDown secondsBox;
        private System.Windows.Forms.CheckBox autoPlayStartBox;
        private System.Windows.Forms.CheckBox saveSpeedBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox showExtensionsBox;
        private System.Windows.Forms.CheckBox saveSliderBox;
        private System.Windows.Forms.CheckBox showClockBox;
        private System.Windows.Forms.CheckBox autoPlayAddedBox;
        private System.Windows.Forms.Panel clockColorPanel;
        private System.Windows.Forms.Label clock24hLabel;
        private System.Windows.Forms.Panel pvsPanel;
        internal System.Windows.Forms.Panel panel4;
    }
}