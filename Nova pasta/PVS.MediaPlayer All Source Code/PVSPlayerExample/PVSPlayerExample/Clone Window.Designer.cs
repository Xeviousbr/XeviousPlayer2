namespace PVSPlayerExample
{
    partial class CloneWindow
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
            this.components = new System.ComponentModel.Container();
            this.cloneWindowMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.displayModeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.coverMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stretchMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.hexagonalShapeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ovalShapeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rectangleShapeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ringShapeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.roundedShapeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.starShapeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tilesShapeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.triangleDownMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.triangleLeftMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.triangleRightMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.triangleUpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.normalShapeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.flipModeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flipXMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flipXYMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flipYMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.flipNoneMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cloneQualityMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.normalQualityMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.highQualityMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.opacityMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opacity25MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opacity50MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opacity75MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opacity100MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fullScreenMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.showInTaskbarMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alwaysOnTopMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.hideMainWindowMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hideWindowMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showWindowMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.closeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.squareShapeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cloneWindowMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // cloneWindowMenu
            // 
            this.cloneWindowMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.displayModeMenuItem,
            this.displayShapeMenuItem,
            this.toolStripSeparator5,
            this.flipModeMenuItem,
            this.cloneQualityMenuItem,
            this.toolStripSeparator4,
            this.opacityMenuItem,
            this.fullScreenMenuItem,
            this.toolStripSeparator1,
            this.showInTaskbarMenuItem,
            this.alwaysOnTopMenuItem,
            this.toolStripSeparator7,
            this.hideMainWindowMenuItem,
            this.toolStripSeparator3,
            this.closeMenuItem});
            this.cloneWindowMenu.Name = "cloneWindowMenu";
            this.cloneWindowMenu.Size = new System.Drawing.Size(181, 276);
            // 
            // displayModeMenuItem
            // 
            this.displayModeMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoomMenuItem,
            this.coverMenuItem,
            this.stretchMenuItem});
            this.displayModeMenuItem.Name = "displayModeMenuItem";
            this.displayModeMenuItem.Size = new System.Drawing.Size(180, 22);
            this.displayModeMenuItem.Text = "Display Mode";
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
            this.hexagonalShapeMenuItem,
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
            this.toolStripSeparator8,
            this.normalShapeMenuItem});
            this.displayShapeMenuItem.Name = "displayShapeMenuItem";
            this.displayShapeMenuItem.Size = new System.Drawing.Size(180, 22);
            this.displayShapeMenuItem.Text = "Display Shape";
            // 
            // arrowDownShapeMenuItem
            // 
            this.arrowDownShapeMenuItem.Name = "arrowDownShapeMenuItem";
            this.arrowDownShapeMenuItem.Size = new System.Drawing.Size(180, 22);
            this.arrowDownShapeMenuItem.Text = "Arrow Down";
            this.arrowDownShapeMenuItem.Click += new System.EventHandler(this.ArrowDownShapeMenuItem_Click);
            // 
            // arrowLeftShapeMenuItem
            // 
            this.arrowLeftShapeMenuItem.Name = "arrowLeftShapeMenuItem";
            this.arrowLeftShapeMenuItem.Size = new System.Drawing.Size(180, 22);
            this.arrowLeftShapeMenuItem.Text = "Arrow Left";
            this.arrowLeftShapeMenuItem.Click += new System.EventHandler(this.ArrowLeftShapeMenuItem_Click);
            // 
            // arrowRightShapeMenuItem
            // 
            this.arrowRightShapeMenuItem.Name = "arrowRightShapeMenuItem";
            this.arrowRightShapeMenuItem.Size = new System.Drawing.Size(180, 22);
            this.arrowRightShapeMenuItem.Text = "Arrow Right";
            this.arrowRightShapeMenuItem.Click += new System.EventHandler(this.ArrowRightShapeMenuItem_Click);
            // 
            // arrowUpShapeMenuItem
            // 
            this.arrowUpShapeMenuItem.Name = "arrowUpShapeMenuItem";
            this.arrowUpShapeMenuItem.Size = new System.Drawing.Size(180, 22);
            this.arrowUpShapeMenuItem.Text = "Arrow Up";
            this.arrowUpShapeMenuItem.Click += new System.EventHandler(this.ArrowUpShapeMenuItem_Click);
            // 
            // barsShapeMenuItem
            // 
            this.barsShapeMenuItem.Name = "barsShapeMenuItem";
            this.barsShapeMenuItem.Size = new System.Drawing.Size(180, 22);
            this.barsShapeMenuItem.Text = "Bars";
            this.barsShapeMenuItem.Click += new System.EventHandler(this.BarsShapeMenuItem_Click);
            // 
            // beamsShapeMenuItem
            // 
            this.beamsShapeMenuItem.Name = "beamsShapeMenuItem";
            this.beamsShapeMenuItem.Size = new System.Drawing.Size(180, 22);
            this.beamsShapeMenuItem.Text = "Beams";
            this.beamsShapeMenuItem.Click += new System.EventHandler(this.BeamsShapeMenuItem_Click);
            // 
            // circleShapeMenuItem
            // 
            this.circleShapeMenuItem.Name = "circleShapeMenuItem";
            this.circleShapeMenuItem.Size = new System.Drawing.Size(180, 22);
            this.circleShapeMenuItem.Text = "Circle";
            this.circleShapeMenuItem.Click += new System.EventHandler(this.CircleShapeMenuItem_Click);
            // 
            // crossShapeMenuItem
            // 
            this.crossShapeMenuItem.Name = "crossShapeMenuItem";
            this.crossShapeMenuItem.Size = new System.Drawing.Size(180, 22);
            this.crossShapeMenuItem.Text = "Cross";
            this.crossShapeMenuItem.Click += new System.EventHandler(this.CrossShapeMenuItem_Click);
            // 
            // diamondShapeMenuItem
            // 
            this.diamondShapeMenuItem.Name = "diamondShapeMenuItem";
            this.diamondShapeMenuItem.Size = new System.Drawing.Size(180, 22);
            this.diamondShapeMenuItem.Text = "Diamond";
            this.diamondShapeMenuItem.Click += new System.EventHandler(this.DiamondShapeMenuItem_Click);
            // 
            // frameShapeMenuItem
            // 
            this.frameShapeMenuItem.Name = "frameShapeMenuItem";
            this.frameShapeMenuItem.Size = new System.Drawing.Size(180, 22);
            this.frameShapeMenuItem.Text = "Frame";
            this.frameShapeMenuItem.Click += new System.EventHandler(this.FrameShapeMenuItem_Click);
            // 
            // heartShapeMenuItem
            // 
            this.heartShapeMenuItem.Name = "heartShapeMenuItem";
            this.heartShapeMenuItem.Size = new System.Drawing.Size(180, 22);
            this.heartShapeMenuItem.Text = "Heart";
            this.heartShapeMenuItem.Click += new System.EventHandler(this.HeartShapeMenuItem_Click);
            // 
            // hexagonalShapeMenuItem
            // 
            this.hexagonalShapeMenuItem.Name = "hexagonalShapeMenuItem";
            this.hexagonalShapeMenuItem.Size = new System.Drawing.Size(180, 22);
            this.hexagonalShapeMenuItem.Text = "Hexagon";
            this.hexagonalShapeMenuItem.Click += new System.EventHandler(this.HexagonShapeMenuItem_Click);
            // 
            // ovalShapeMenuItem
            // 
            this.ovalShapeMenuItem.Name = "ovalShapeMenuItem";
            this.ovalShapeMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ovalShapeMenuItem.Text = "Oval";
            this.ovalShapeMenuItem.Click += new System.EventHandler(this.OvalShapeMenuItem_Click);
            // 
            // rectangleShapeMenuItem
            // 
            this.rectangleShapeMenuItem.Name = "rectangleShapeMenuItem";
            this.rectangleShapeMenuItem.Size = new System.Drawing.Size(180, 22);
            this.rectangleShapeMenuItem.Text = "Rectangle";
            this.rectangleShapeMenuItem.Click += new System.EventHandler(this.RectangleShapeMenuItem_Click);
            // 
            // ringShapeMenuItem
            // 
            this.ringShapeMenuItem.Name = "ringShapeMenuItem";
            this.ringShapeMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ringShapeMenuItem.Text = "Ring";
            this.ringShapeMenuItem.Click += new System.EventHandler(this.RingShapeMenuItem_Click);
            // 
            // roundedShapeMenuItem
            // 
            this.roundedShapeMenuItem.Name = "roundedShapeMenuItem";
            this.roundedShapeMenuItem.Size = new System.Drawing.Size(180, 22);
            this.roundedShapeMenuItem.Text = "Rounded";
            this.roundedShapeMenuItem.Click += new System.EventHandler(this.RoundedShapeMenuItem_Click);
            // 
            // starShapeMenuItem
            // 
            this.starShapeMenuItem.Name = "starShapeMenuItem";
            this.starShapeMenuItem.Size = new System.Drawing.Size(180, 22);
            this.starShapeMenuItem.Text = "Star";
            this.starShapeMenuItem.Click += new System.EventHandler(this.StarShapeMenuItem_Click);
            // 
            // tilesShapeMenuItem
            // 
            this.tilesShapeMenuItem.Name = "tilesShapeMenuItem";
            this.tilesShapeMenuItem.Size = new System.Drawing.Size(180, 22);
            this.tilesShapeMenuItem.Text = "Tiles";
            this.tilesShapeMenuItem.Click += new System.EventHandler(this.TilesShapeMenuItem_Click);
            // 
            // triangleDownMenuItem
            // 
            this.triangleDownMenuItem.Name = "triangleDownMenuItem";
            this.triangleDownMenuItem.Size = new System.Drawing.Size(180, 22);
            this.triangleDownMenuItem.Text = "Triangle Down";
            this.triangleDownMenuItem.Click += new System.EventHandler(this.TriangleDownMenuItem_Click);
            // 
            // triangleLeftMenuItem
            // 
            this.triangleLeftMenuItem.Name = "triangleLeftMenuItem";
            this.triangleLeftMenuItem.Size = new System.Drawing.Size(180, 22);
            this.triangleLeftMenuItem.Text = "Triangle Left";
            this.triangleLeftMenuItem.Click += new System.EventHandler(this.TriangleLeftMenuItem_Click);
            // 
            // triangleRightMenuItem
            // 
            this.triangleRightMenuItem.Name = "triangleRightMenuItem";
            this.triangleRightMenuItem.Size = new System.Drawing.Size(180, 22);
            this.triangleRightMenuItem.Text = "Triangle Right";
            this.triangleRightMenuItem.Click += new System.EventHandler(this.TriangleRightMenuItem_Click);
            // 
            // triangleUpMenuItem
            // 
            this.triangleUpMenuItem.Name = "triangleUpMenuItem";
            this.triangleUpMenuItem.Size = new System.Drawing.Size(180, 22);
            this.triangleUpMenuItem.Text = "Triangle Up";
            this.triangleUpMenuItem.Click += new System.EventHandler(this.TriangleUpMenuItem_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(177, 6);
            // 
            // normalShapeMenuItem
            // 
            this.normalShapeMenuItem.Checked = true;
            this.normalShapeMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.normalShapeMenuItem.Name = "normalShapeMenuItem";
            this.normalShapeMenuItem.Size = new System.Drawing.Size(180, 22);
            this.normalShapeMenuItem.Text = "Normal Shape";
            this.normalShapeMenuItem.Click += new System.EventHandler(this.NormalShapeMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(177, 6);
            // 
            // flipModeMenuItem
            // 
            this.flipModeMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.flipXMenuItem,
            this.flipXYMenuItem,
            this.flipYMenuItem,
            this.toolStripSeparator2,
            this.flipNoneMenuItem});
            this.flipModeMenuItem.Name = "flipModeMenuItem";
            this.flipModeMenuItem.Size = new System.Drawing.Size(180, 22);
            this.flipModeMenuItem.Text = "Flip Mode";
            // 
            // flipXMenuItem
            // 
            this.flipXMenuItem.Name = "flipXMenuItem";
            this.flipXMenuItem.Size = new System.Drawing.Size(125, 22);
            this.flipXMenuItem.Text = "FlipX";
            this.flipXMenuItem.Click += new System.EventHandler(this.FlipXMenuItem_Click);
            // 
            // flipXYMenuItem
            // 
            this.flipXYMenuItem.Name = "flipXYMenuItem";
            this.flipXYMenuItem.Size = new System.Drawing.Size(125, 22);
            this.flipXYMenuItem.Text = "FlipXY";
            this.flipXYMenuItem.Click += new System.EventHandler(this.FlipXYMenuItem_Click);
            // 
            // flipYMenuItem
            // 
            this.flipYMenuItem.Name = "flipYMenuItem";
            this.flipYMenuItem.Size = new System.Drawing.Size(125, 22);
            this.flipYMenuItem.Text = "FlipY";
            this.flipYMenuItem.Click += new System.EventHandler(this.FlipYMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(122, 6);
            // 
            // flipNoneMenuItem
            // 
            this.flipNoneMenuItem.Checked = true;
            this.flipNoneMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.flipNoneMenuItem.Name = "flipNoneMenuItem";
            this.flipNoneMenuItem.Size = new System.Drawing.Size(125, 22);
            this.flipNoneMenuItem.Text = "Flip None";
            this.flipNoneMenuItem.Click += new System.EventHandler(this.FlipNoneMenuItem_Click);
            // 
            // cloneQualityMenuItem
            // 
            this.cloneQualityMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.normalQualityMenuItem,
            this.highQualityMenuItem});
            this.cloneQualityMenuItem.Name = "cloneQualityMenuItem";
            this.cloneQualityMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cloneQualityMenuItem.Text = "Quality Mode";
            // 
            // normalQualityMenuItem
            // 
            this.normalQualityMenuItem.Checked = true;
            this.normalQualityMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.normalQualityMenuItem.Name = "normalQualityMenuItem";
            this.normalQualityMenuItem.Size = new System.Drawing.Size(114, 22);
            this.normalQualityMenuItem.Text = "Normal";
            this.normalQualityMenuItem.Click += new System.EventHandler(this.NormalQualityMenuItem_Click);
            // 
            // highQualityMenuItem
            // 
            this.highQualityMenuItem.Name = "highQualityMenuItem";
            this.highQualityMenuItem.Size = new System.Drawing.Size(114, 22);
            this.highQualityMenuItem.Text = "High";
            this.highQualityMenuItem.Click += new System.EventHandler(this.HighQualityMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(177, 6);
            // 
            // opacityMenuItem
            // 
            this.opacityMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opacity25MenuItem,
            this.opacity50MenuItem,
            this.opacity75MenuItem,
            this.opacity100MenuItem});
            this.opacityMenuItem.Name = "opacityMenuItem";
            this.opacityMenuItem.Size = new System.Drawing.Size(180, 22);
            this.opacityMenuItem.Text = "Opacity";
            // 
            // opacity25MenuItem
            // 
            this.opacity25MenuItem.Name = "opacity25MenuItem";
            this.opacity25MenuItem.Size = new System.Drawing.Size(102, 22);
            this.opacity25MenuItem.Text = "  25%";
            this.opacity25MenuItem.Click += new System.EventHandler(this.Opacity25MenuItem_Click);
            // 
            // opacity50MenuItem
            // 
            this.opacity50MenuItem.Name = "opacity50MenuItem";
            this.opacity50MenuItem.Size = new System.Drawing.Size(102, 22);
            this.opacity50MenuItem.Text = "  50%";
            this.opacity50MenuItem.Click += new System.EventHandler(this.Opacity50MenuItem_Click);
            // 
            // opacity75MenuItem
            // 
            this.opacity75MenuItem.Name = "opacity75MenuItem";
            this.opacity75MenuItem.Size = new System.Drawing.Size(102, 22);
            this.opacity75MenuItem.Text = "  75%";
            this.opacity75MenuItem.Click += new System.EventHandler(this.Opacity75MenuItem_Click);
            // 
            // opacity100MenuItem
            // 
            this.opacity100MenuItem.Checked = true;
            this.opacity100MenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.opacity100MenuItem.Name = "opacity100MenuItem";
            this.opacity100MenuItem.Size = new System.Drawing.Size(102, 22);
            this.opacity100MenuItem.Text = "100%";
            this.opacity100MenuItem.Click += new System.EventHandler(this.Opacity100MenuItem_Click);
            // 
            // fullScreenMenuItem
            // 
            this.fullScreenMenuItem.Name = "fullScreenMenuItem";
            this.fullScreenMenuItem.Size = new System.Drawing.Size(180, 22);
            this.fullScreenMenuItem.Text = "FullScreen";
            this.fullScreenMenuItem.Click += new System.EventHandler(this.FullScreenMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // showInTaskbarMenuItem
            // 
            this.showInTaskbarMenuItem.Checked = true;
            this.showInTaskbarMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showInTaskbarMenuItem.Name = "showInTaskbarMenuItem";
            this.showInTaskbarMenuItem.Size = new System.Drawing.Size(180, 22);
            this.showInTaskbarMenuItem.Text = "Show In Taskbar";
            this.showInTaskbarMenuItem.Click += new System.EventHandler(this.ShowInTaskbarMenuItem_Click);
            // 
            // alwaysOnTopMenuItem
            // 
            this.alwaysOnTopMenuItem.Name = "alwaysOnTopMenuItem";
            this.alwaysOnTopMenuItem.Size = new System.Drawing.Size(180, 22);
            this.alwaysOnTopMenuItem.Text = "Always On Top";
            this.alwaysOnTopMenuItem.Click += new System.EventHandler(this.AlwaysOnTopMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(177, 6);
            // 
            // hideMainWindowMenuItem
            // 
            this.hideMainWindowMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hideWindowMenuItem,
            this.showWindowMenuItem});
            this.hideMainWindowMenuItem.Name = "hideMainWindowMenuItem";
            this.hideMainWindowMenuItem.Size = new System.Drawing.Size(180, 22);
            this.hideMainWindowMenuItem.Text = "Main Window";
            this.hideMainWindowMenuItem.DropDownOpening += new System.EventHandler(this.HideMainWindowMenuItem_DropDownOpening);
            // 
            // hideWindowMenuItem
            // 
            this.hideWindowMenuItem.Name = "hideWindowMenuItem";
            this.hideWindowMenuItem.Size = new System.Drawing.Size(150, 22);
            this.hideWindowMenuItem.Text = "Hide Window";
            this.hideWindowMenuItem.Click += new System.EventHandler(this.HideWindowMenuItem_Click);
            // 
            // showWindowMenuItem
            // 
            this.showWindowMenuItem.Name = "showWindowMenuItem";
            this.showWindowMenuItem.Size = new System.Drawing.Size(150, 22);
            this.showWindowMenuItem.Text = "Show Window";
            this.showWindowMenuItem.Click += new System.EventHandler(this.ShowWindowMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(177, 6);
            // 
            // closeMenuItem
            // 
            this.closeMenuItem.Name = "closeMenuItem";
            this.closeMenuItem.Size = new System.Drawing.Size(180, 22);
            this.closeMenuItem.Text = "Close";
            this.closeMenuItem.Click += new System.EventHandler(this.CloseMenuItem_Click);
            // 
            // squareShapeMenuItem
            // 
            this.squareShapeMenuItem.Name = "squareShapeMenuItem";
            this.squareShapeMenuItem.Size = new System.Drawing.Size(180, 22);
            this.squareShapeMenuItem.Text = "Square";
            this.squareShapeMenuItem.Click += new System.EventHandler(this.SquareShapeMenuItem_Click);
            // 
            // CloneWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.ClientSize = new System.Drawing.Size(520, 390);
            this.ContextMenuStrip = this.cloneWindowMenu;
            this.MinimumSize = new System.Drawing.Size(148, 148);
            this.Name = "CloneWindow";
            this.ShowIcon = false;
            this.Text = "Display Clone";
            this.TransparencyKey = System.Drawing.Color.Lime;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CloneWindow_FormClosed);
            this.Shown += new System.EventHandler(this.CloneWindow_Shown);
            this.cloneWindowMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip cloneWindowMenu;
        private System.Windows.Forms.ToolStripMenuItem displayModeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stretchMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cloneQualityMenuItem;
        private System.Windows.Forms.ToolStripMenuItem normalQualityMenuItem;
        private System.Windows.Forms.ToolStripMenuItem highQualityMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alwaysOnTopMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem closeMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem showInTaskbarMenuItem;
        private System.Windows.Forms.ToolStripMenuItem flipModeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem flipXMenuItem;
        private System.Windows.Forms.ToolStripMenuItem flipXYMenuItem;
        private System.Windows.Forms.ToolStripMenuItem flipYMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem flipNoneMenuItem;
        private System.Windows.Forms.ToolStripMenuItem displayShapeMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem fullScreenMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem opacityMenuItem;
        private System.Windows.Forms.ToolStripMenuItem opacity25MenuItem;
        private System.Windows.Forms.ToolStripMenuItem opacity50MenuItem;
        private System.Windows.Forms.ToolStripMenuItem opacity75MenuItem;
        private System.Windows.Forms.ToolStripMenuItem opacity100MenuItem;
        private System.Windows.Forms.ToolStripMenuItem arrowUpShapeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem arrowRightShapeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem crossShapeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem normalShapeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hideMainWindowMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem hideWindowMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showWindowMenuItem;
        private System.Windows.Forms.ToolStripMenuItem arrowLeftShapeMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem beamsShapeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem arrowDownShapeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem barsShapeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem diamondShapeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem frameShapeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem heartShapeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hexagonalShapeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ovalShapeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rectangleShapeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ringShapeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem roundedShapeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem starShapeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tilesShapeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem triangleDownMenuItem;
        private System.Windows.Forms.ToolStripMenuItem triangleLeftMenuItem;
        private System.Windows.Forms.ToolStripMenuItem triangleRightMenuItem;
        private System.Windows.Forms.ToolStripMenuItem triangleUpMenuItem;
        private System.Windows.Forms.ToolStripMenuItem coverMenuItem;
        private System.Windows.Forms.ToolStripMenuItem circleShapeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem squareShapeMenuItem;
    }
}