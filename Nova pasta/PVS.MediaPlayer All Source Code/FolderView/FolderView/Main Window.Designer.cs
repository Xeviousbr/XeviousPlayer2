namespace FolderView
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.itemViewMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.allMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pauseAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.muteAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.displayModeAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.coverAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stretchAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayShapeAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.heartShapeAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ovalShapeAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.roundedShapeAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.starShapeAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.normalShapeAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.pauseMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.muteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.displayModeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.coverMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stretchMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayShapeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.heartShapeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ovalShapeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.roundedShapeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.starShapeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.normalShapeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.openMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openAtMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openWithMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.propertiesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.quitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.customPanel2 = new FolderView.CustomPanel();
            this.customPanel1 = new FolderView.CustomPanel();
            this.folderLabel = new System.Windows.Forms.Label();
            this.countLabel2 = new System.Windows.Forms.Label();
            this.countLabel1 = new System.Windows.Forms.Label();
            this.mainWindowToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.folderBrowser = new System.Windows.Forms.TreeView();
            this.folderBrowserImages = new System.Windows.Forms.ImageList(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.resetButton = new FolderView.CustomButton();
            this.selectButton = new FolderView.CustomButton();
            this.itemViewMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(546, 494);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.MouseEnter += new System.EventHandler(this.FlowLayoutPanel1_MouseEnter);
            // 
            // itemViewMenu
            // 
            this.itemViewMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allMenuItem,
            this.toolStripSeparator2,
            this.pauseMenuItem,
            this.muteMenuItem,
            this.toolStripSeparator8,
            this.displayModeMenuItem,
            this.displayShapeToolStripMenuItem,
            this.toolStripSeparator3,
            this.openMenuItem,
            this.openAtMenuItem,
            this.openWithMenuItem,
            this.toolStripSeparator7,
            this.propertiesMenuItem,
            this.toolStripSeparator4,
            this.aboutMenuItem,
            this.toolStripSeparator1,
            this.quitMenuItem});
            this.itemViewMenu.Name = "contextMenuStrip1";
            this.itemViewMenu.ShowImageMargin = false;
            this.itemViewMenu.Size = new System.Drawing.Size(144, 282);
            this.itemViewMenu.Closing += new System.Windows.Forms.ToolStripDropDownClosingEventHandler(this.ItemViewMenu_Closing);
            this.itemViewMenu.Opening += new System.ComponentModel.CancelEventHandler(this.ItemViewMenu_Opening);
            // 
            // allMenuItem
            // 
            this.allMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playAllMenuItem,
            this.pauseAllMenuItem,
            this.muteAllMenuItem,
            this.toolStripSeparator5,
            this.displayModeAllMenuItem,
            this.displayShapeAllMenuItem});
            this.allMenuItem.Enabled = false;
            this.allMenuItem.Name = "allMenuItem";
            this.allMenuItem.Size = new System.Drawing.Size(143, 22);
            this.allMenuItem.Text = "All Items";
            // 
            // playAllMenuItem
            // 
            this.playAllMenuItem.Name = "playAllMenuItem";
            this.playAllMenuItem.Size = new System.Drawing.Size(180, 22);
            this.playAllMenuItem.Text = "Play";
            this.playAllMenuItem.Click += new System.EventHandler(this.PlayAllMenuItem_Click);
            // 
            // pauseAllMenuItem
            // 
            this.pauseAllMenuItem.Name = "pauseAllMenuItem";
            this.pauseAllMenuItem.Size = new System.Drawing.Size(180, 22);
            this.pauseAllMenuItem.Text = "Pause";
            this.pauseAllMenuItem.Click += new System.EventHandler(this.PauseAllMenuItem_Click);
            // 
            // muteAllMenuItem
            // 
            this.muteAllMenuItem.Name = "muteAllMenuItem";
            this.muteAllMenuItem.Size = new System.Drawing.Size(180, 22);
            this.muteAllMenuItem.Text = "Mute";
            this.muteAllMenuItem.Click += new System.EventHandler(this.MuteAllMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(177, 6);
            // 
            // displayModeAllMenuItem
            // 
            this.displayModeAllMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoomAllMenuItem,
            this.coverAllMenuItem,
            this.stretchAllMenuItem});
            this.displayModeAllMenuItem.Name = "displayModeAllMenuItem";
            this.displayModeAllMenuItem.Size = new System.Drawing.Size(180, 22);
            this.displayModeAllMenuItem.Text = "Display Mode";
            // 
            // zoomAllMenuItem
            // 
            this.zoomAllMenuItem.Name = "zoomAllMenuItem";
            this.zoomAllMenuItem.Size = new System.Drawing.Size(111, 22);
            this.zoomAllMenuItem.Text = "Zoom";
            this.zoomAllMenuItem.Click += new System.EventHandler(this.ZoomAndCenterAllMenuItem_Click);
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
            // displayShapeAllMenuItem
            // 
            this.displayShapeAllMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.heartShapeAllMenuItem,
            this.ovalShapeAllMenuItem,
            this.roundedShapeAllMenuItem,
            this.starShapeAllMenuItem,
            this.toolStripSeparator6,
            this.normalShapeAllMenuItem});
            this.displayShapeAllMenuItem.Name = "displayShapeAllMenuItem";
            this.displayShapeAllMenuItem.Size = new System.Drawing.Size(180, 22);
            this.displayShapeAllMenuItem.Text = "Display Shape";
            // 
            // heartShapeAllMenuItem
            // 
            this.heartShapeAllMenuItem.Name = "heartShapeAllMenuItem";
            this.heartShapeAllMenuItem.Size = new System.Drawing.Size(180, 22);
            this.heartShapeAllMenuItem.Text = "Heart";
            this.heartShapeAllMenuItem.Click += new System.EventHandler(this.HeartShapeAllMenuItem_Click);
            // 
            // ovalShapeAllMenuItem
            // 
            this.ovalShapeAllMenuItem.Name = "ovalShapeAllMenuItem";
            this.ovalShapeAllMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ovalShapeAllMenuItem.Text = "Oval";
            this.ovalShapeAllMenuItem.Click += new System.EventHandler(this.OvalShapeAllMenuItem_Click);
            // 
            // roundedShapeAllMenuItem
            // 
            this.roundedShapeAllMenuItem.Name = "roundedShapeAllMenuItem";
            this.roundedShapeAllMenuItem.Size = new System.Drawing.Size(180, 22);
            this.roundedShapeAllMenuItem.Text = "Rounded";
            this.roundedShapeAllMenuItem.Click += new System.EventHandler(this.RoundedShapeAllMenuItem_Click);
            // 
            // starShapeAllMenuItem
            // 
            this.starShapeAllMenuItem.Name = "starShapeAllMenuItem";
            this.starShapeAllMenuItem.Size = new System.Drawing.Size(180, 22);
            this.starShapeAllMenuItem.Text = "Star";
            this.starShapeAllMenuItem.Click += new System.EventHandler(this.StarShapeAllMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(177, 6);
            // 
            // normalShapeAllMenuItem
            // 
            this.normalShapeAllMenuItem.Name = "normalShapeAllMenuItem";
            this.normalShapeAllMenuItem.Size = new System.Drawing.Size(180, 22);
            this.normalShapeAllMenuItem.Text = "Normal Shape";
            this.normalShapeAllMenuItem.Click += new System.EventHandler(this.NormalShapeAllMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(140, 6);
            // 
            // pauseMenuItem
            // 
            this.pauseMenuItem.Name = "pauseMenuItem";
            this.pauseMenuItem.Size = new System.Drawing.Size(143, 22);
            this.pauseMenuItem.Text = "Pause";
            this.pauseMenuItem.Click += new System.EventHandler(this.PauseMenuItem_Click);
            // 
            // muteMenuItem
            // 
            this.muteMenuItem.Name = "muteMenuItem";
            this.muteMenuItem.Size = new System.Drawing.Size(143, 22);
            this.muteMenuItem.Text = "Mute";
            this.muteMenuItem.Click += new System.EventHandler(this.MuteMenuItem_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(140, 6);
            // 
            // displayModeMenuItem
            // 
            this.displayModeMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoomMenuItem,
            this.coverMenuItem,
            this.stretchMenuItem});
            this.displayModeMenuItem.Name = "displayModeMenuItem";
            this.displayModeMenuItem.Size = new System.Drawing.Size(143, 22);
            this.displayModeMenuItem.Text = "Display Mode";
            // 
            // zoomMenuItem
            // 
            this.zoomMenuItem.Name = "zoomMenuItem";
            this.zoomMenuItem.Size = new System.Drawing.Size(111, 22);
            this.zoomMenuItem.Text = "Zoom";
            this.zoomMenuItem.Click += new System.EventHandler(this.ZoomCenterMenuItem_Click);
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
            // displayShapeToolStripMenuItem
            // 
            this.displayShapeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.heartShapeMenuItem,
            this.ovalShapeMenuItem,
            this.roundedShapeMenuItem,
            this.starShapeMenuItem,
            this.toolStripSeparator9,
            this.normalShapeMenuItem});
            this.displayShapeToolStripMenuItem.Name = "displayShapeToolStripMenuItem";
            this.displayShapeToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.displayShapeToolStripMenuItem.Text = "Display Shape";
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
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(146, 6);
            // 
            // normalShapeMenuItem
            // 
            this.normalShapeMenuItem.Name = "normalShapeMenuItem";
            this.normalShapeMenuItem.Size = new System.Drawing.Size(149, 22);
            this.normalShapeMenuItem.Text = "Normal Shape";
            this.normalShapeMenuItem.Click += new System.EventHandler(this.NormalShapeMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(140, 6);
            // 
            // openMenuItem
            // 
            this.openMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.openMenuItem.Name = "openMenuItem";
            this.openMenuItem.Size = new System.Drawing.Size(143, 22);
            this.openMenuItem.Text = "Open";
            this.openMenuItem.Click += new System.EventHandler(this.OpenMenuItem_Click);
            // 
            // openAtMenuItem
            // 
            this.openAtMenuItem.Name = "openAtMenuItem";
            this.openAtMenuItem.Size = new System.Drawing.Size(143, 22);
            this.openAtMenuItem.Text = "Open At Begin";
            this.openAtMenuItem.Click += new System.EventHandler(this.OpenAtMenuItem_Click);
            // 
            // openWithMenuItem
            // 
            this.openWithMenuItem.Name = "openWithMenuItem";
            this.openWithMenuItem.Size = new System.Drawing.Size(143, 22);
            this.openWithMenuItem.Text = "Open With…";
            this.openWithMenuItem.Click += new System.EventHandler(this.OpenWithMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(140, 6);
            // 
            // propertiesMenuItem
            // 
            this.propertiesMenuItem.Name = "propertiesMenuItem";
            this.propertiesMenuItem.Size = new System.Drawing.Size(143, 22);
            this.propertiesMenuItem.Text = "Properties";
            this.propertiesMenuItem.Click += new System.EventHandler(this.PropertiesMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(140, 6);
            // 
            // aboutMenuItem
            // 
            this.aboutMenuItem.Name = "aboutMenuItem";
            this.aboutMenuItem.Size = new System.Drawing.Size(143, 22);
            this.aboutMenuItem.Text = "About FolderView";
            this.aboutMenuItem.Click += new System.EventHandler(this.AboutMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(140, 6);
            // 
            // quitMenuItem
            // 
            this.quitMenuItem.Name = "quitMenuItem";
            this.quitMenuItem.Size = new System.Drawing.Size(143, 22);
            this.quitMenuItem.Text = "Quit";
            this.quitMenuItem.Click += new System.EventHandler(this.QuitMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.customPanel2);
            this.panel1.Controls.Add(this.customPanel1);
            this.panel1.Controls.Add(this.folderLabel);
            this.panel1.Controls.Add(this.countLabel2);
            this.panel1.Controls.Add(this.countLabel1);
            this.panel1.Location = new System.Drawing.Point(-1, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(951, 55);
            this.panel1.TabIndex = 1;
            // 
            // customPanel2
            // 
            this.customPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.customPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.customPanel2.Location = new System.Drawing.Point(929, 9);
            this.customPanel2.Name = "customPanel2";
            this.customPanel2.Size = new System.Drawing.Size(12, 37);
            this.customPanel2.TabIndex = 4;
            this.customPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.CustomPanel2_Paint);
            // 
            // customPanel1
            // 
            this.customPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.customPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.customPanel1.Location = new System.Drawing.Point(915, 9);
            this.customPanel1.Name = "customPanel1";
            this.customPanel1.Size = new System.Drawing.Size(12, 37);
            this.customPanel1.TabIndex = 3;
            this.customPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.CustomPanel1_Paint);
            // 
            // folderLabel
            // 
            this.folderLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.folderLabel.AutoEllipsis = true;
            this.folderLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.folderLabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.folderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.folderLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.folderLabel.Location = new System.Drawing.Point(164, 9);
            this.folderLabel.Name = "folderLabel";
            this.folderLabel.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.folderLabel.Size = new System.Drawing.Size(743, 37);
            this.folderLabel.TabIndex = 2;
            this.folderLabel.Text = "folder";
            this.folderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // countLabel2
            // 
            this.countLabel2.BackColor = System.Drawing.Color.Black;
            this.countLabel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.countLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.countLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.countLabel2.Location = new System.Drawing.Point(85, 9);
            this.countLabel2.Name = "countLabel2";
            this.countLabel2.Size = new System.Drawing.Size(72, 37);
            this.countLabel2.TabIndex = 1;
            this.countLabel2.Text = "000";
            this.countLabel2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.mainWindowToolTip.SetToolTip(this.countLabel2, "The number of playable movies found in the selected folder (max. ");
            // 
            // countLabel1
            // 
            this.countLabel1.BackColor = System.Drawing.Color.Black;
            this.countLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.countLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.countLabel1.ForeColor = System.Drawing.Color.Red;
            this.countLabel1.Location = new System.Drawing.Point(8, 9);
            this.countLabel1.Name = "countLabel1";
            this.countLabel1.Size = new System.Drawing.Size(72, 37);
            this.countLabel1.TabIndex = 0;
            this.countLabel1.Text = "000";
            this.countLabel1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.mainWindowToolTip.SetToolTip(this.countLabel1, "The number of movies found in the selected folder (max. ");
            // 
            // mainWindowToolTip
            // 
            this.mainWindowToolTip.AutomaticDelay = 0;
            this.mainWindowToolTip.AutoPopDelay = 0;
            this.mainWindowToolTip.InitialDelay = 0;
            this.mainWindowToolTip.IsBalloon = true;
            this.mainWindowToolTip.ReshowDelay = 0;
            this.mainWindowToolTip.ToolTipTitle = "FolderView";
            // 
            // folderBrowser
            // 
            this.folderBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.folderBrowser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.folderBrowser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.folderBrowser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.folderBrowser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.folderBrowser.ImageIndex = 0;
            this.folderBrowser.ImageList = this.folderBrowserImages;
            this.folderBrowser.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(159)))), ((int)(((byte)(87)))));
            this.folderBrowser.Location = new System.Drawing.Point(0, -1);
            this.folderBrowser.Name = "folderBrowser";
            this.folderBrowser.SelectedImageIndex = 0;
            this.folderBrowser.Size = new System.Drawing.Size(400, 473);
            this.folderBrowser.TabIndex = 2;
            this.folderBrowser.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.FolderBrowser_BeforeExpand);
            this.folderBrowser.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.FolderBrowser_NodeMouseDoubleClick);
            this.folderBrowser.Enter += new System.EventHandler(this.FolderBrowser_Enter);
            this.folderBrowser.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FolderBrowser_KeyPress);
            this.folderBrowser.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FolderBrowser_MouseDown);
            this.folderBrowser.MouseLeave += new System.EventHandler(this.FolderBrowser_MouseLeave);
            this.folderBrowser.MouseHover += new System.EventHandler(this.FolderBrowser_MouseHover);
            // 
            // folderBrowserImages
            // 
            this.folderBrowserImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("folderBrowserImages.ImageStream")));
            this.folderBrowserImages.TransparentColor = System.Drawing.Color.Transparent;
            this.folderBrowserImages.Images.SetKeyName(0, "1346238561_folder_classic.png");
            this.folderBrowserImages.Images.SetKeyName(1, "1346238604_folder_classic_opened.png");
            this.folderBrowserImages.Images.SetKeyName(2, "1346228331_drive.png");
            this.folderBrowserImages.Images.SetKeyName(3, "1346228337_drive_cd.png");
            this.folderBrowserImages.Images.SetKeyName(4, "1346228356_drive_cd_empty.png");
            this.folderBrowserImages.Images.SetKeyName(5, "1346228364_drive_disk.png");
            this.folderBrowserImages.Images.SetKeyName(6, "1346228591_drive_network.png");
            this.folderBrowserImages.Images.SetKeyName(7, "1346228618_drive_link.png");
            this.folderBrowserImages.Images.SetKeyName(8, "1346228623_drive_error.png");
            this.folderBrowserImages.Images.SetKeyName(9, "1346228633_drive_go.png");
            this.folderBrowserImages.Images.SetKeyName(10, "1346228636_drive_delete.png");
            this.folderBrowserImages.Images.SetKeyName(11, "1346228639_drive_burn.png");
            this.folderBrowserImages.Images.SetKeyName(12, "1346238642_folder_classic_locked.png");
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 54);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.folderBrowser);
            this.splitContainer1.Panel1.Controls.Add(this.resetButton);
            this.splitContainer1.Panel1.Controls.Add(this.selectButton);
            this.splitContainer1.Panel1.Resize += new System.EventHandler(this.SplitContainer1_Panel1_Resize);
            this.splitContainer1.Panel1MinSize = 200;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.flowLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(950, 494);
            this.splitContainer1.SplitterDistance = 400;
            this.splitContainer1.TabIndex = 5;
            // 
            // resetButton
            // 
            this.resetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.resetButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.resetButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.resetButton.Location = new System.Drawing.Point(0, 471);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(200, 23);
            this.resetButton.TabIndex = 3;
            this.resetButton.Text = "Restore Selection";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // selectButton
            // 
            this.selectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.selectButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.selectButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.selectButton.Location = new System.Drawing.Point(200, 471);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(200, 23);
            this.selectButton.TabIndex = 4;
            this.selectButton.Text = "Open Folder";
            this.selectButton.UseVisualStyleBackColor = true;
            this.selectButton.Click += new System.EventHandler(this.SelectButton_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.ClientSize = new System.Drawing.Size(949, 548);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(620, 422);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FolderView";
            this.Activated += new System.EventHandler(this.MainWindow_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Shown += new System.EventHandler(this.MainWindow_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
            this.itemViewMenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ContextMenuStrip itemViewMenu;
        private System.Windows.Forms.ToolStripMenuItem allMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem pauseMenuItem;
        private System.Windows.Forms.ToolStripMenuItem muteMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem quitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem displayModeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem coverMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openWithMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playAllMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pauseAllMenuItem;
        private System.Windows.Forms.ToolStripMenuItem muteAllMenuItem;
        private System.Windows.Forms.ToolStripMenuItem displayModeAllMenuItem;
        private System.Windows.Forms.ToolStripMenuItem coverAllMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomAllMenuItem;
        private System.Windows.Forms.ToolStripMenuItem propertiesMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label countLabel1;
        private System.Windows.Forms.Label countLabel2;
        private System.Windows.Forms.ToolTip mainWindowToolTip;
        private System.Windows.Forms.Label folderLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.TreeView folderBrowser;
        private CustomButton resetButton;
        private CustomButton selectButton;
        private System.Windows.Forms.ImageList folderBrowserImages;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripMenuItem aboutMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem openAtMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stretchAllMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stretchMenuItem;
        internal CustomPanel customPanel2;
        internal CustomPanel customPanel1;
        private System.Windows.Forms.ToolStripMenuItem displayShapeAllMenuItem;
        private System.Windows.Forms.ToolStripMenuItem heartShapeAllMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ovalShapeAllMenuItem;
        private System.Windows.Forms.ToolStripMenuItem roundedShapeAllMenuItem;
        private System.Windows.Forms.ToolStripMenuItem starShapeAllMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem normalShapeAllMenuItem;
        private System.Windows.Forms.ToolStripMenuItem displayShapeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem heartShapeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ovalShapeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem roundedShapeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem starShapeMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripMenuItem normalShapeMenuItem;
    }
}

