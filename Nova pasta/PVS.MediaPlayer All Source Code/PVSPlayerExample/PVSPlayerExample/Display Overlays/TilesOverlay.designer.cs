using System.ComponentModel;
using System.Windows.Forms;

namespace PVSPlayerExample
{
    partial class TilesOverlay
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
            this.tilesPanel = new System.Windows.Forms.Panel();
            this.setButton = new PVSPlayerExample.CustomButton();
            this.optionsButton = new PVSPlayerExample.DropDownButton();
            this.optionsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tileSourceMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.videoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.baseTileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.baseNormalMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.baseFlipXMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.baseFlipXYMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.baseFlipYMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileModeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileNormalMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileFlipXMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileFlipXYMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileFlipYMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.opacityMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opacity25_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opacity50_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opacity75_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opacity100_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshRateMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fps01_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fps02_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fps05_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fps10_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fps15_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fps20_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fps25_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fps30_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fps40_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fps50_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fps60_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.puzzleMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newPuzzleMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.showGridMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showIndicatorsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.tilesPanel.SuspendLayout();
            this.optionsMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // tilesPanel
            // 
            this.tilesPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.tilesPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tilesPanel.Controls.Add(this.setButton);
            this.tilesPanel.Controls.Add(this.optionsButton);
            this.tilesPanel.Controls.Add(this.numericUpDown2);
            this.tilesPanel.Controls.Add(this.numericUpDown1);
            this.tilesPanel.Location = new System.Drawing.Point(12, 12);
            this.tilesPanel.Name = "tilesPanel";
            this.tilesPanel.Size = new System.Drawing.Size(254, 27);
            this.tilesPanel.TabIndex = 0;
            // 
            // setButton
            // 
            this.setButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.setButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.setButton.Location = new System.Drawing.Point(102, 2);
            this.setButton.Name = "setButton";
            this.setButton.Size = new System.Drawing.Size(73, 21);
            this.setButton.TabIndex = 2;
            this.setButton.Text = "Set";
            this.setButton.UseVisualStyleBackColor = true;
            this.setButton.Click += new System.EventHandler(this.SetButton_Click);
            // 
            // optionsButton
            // 
            this.optionsButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.optionsButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.optionsButton.DropDown = this.optionsMenu;
            this.optionsButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.optionsButton.Location = new System.Drawing.Point(177, 2);
            this.optionsButton.Name = "optionsButton";
            this.optionsButton.Size = new System.Drawing.Size(73, 21);
            this.optionsButton.TabIndex = 3;
            this.optionsButton.Text = "Options ";
            this.optionsButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.optionsButton.UseVisualStyleBackColor = true;
            // 
            // optionsMenu
            // 
            this.optionsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tileSourceMenuItem,
            this.toolStripSeparator3,
            this.baseTileMenuItem,
            this.tileModeMenuItem,
            this.toolStripSeparator4,
            this.opacityMenuItem,
            this.refreshRateMenuItem,
            this.toolStripSeparator2,
            this.puzzleMenuItem});
            this.optionsMenu.Name = "contextMenuStrip1";
            this.optionsMenu.ShowImageMargin = false;
            this.optionsMenu.Size = new System.Drawing.Size(115, 154);
            this.optionsMenu.Closed += new System.Windows.Forms.ToolStripDropDownClosedEventHandler(this.OptionsMenu_Closed);
            // 
            // tileSourceMenuItem
            // 
            this.tileSourceMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.videoMenuItem,
            this.displayMenuItem});
            this.tileSourceMenuItem.Name = "tileSourceMenuItem";
            this.tileSourceMenuItem.Size = new System.Drawing.Size(114, 22);
            this.tileSourceMenuItem.Text = "Tile Source";
            // 
            // videoMenuItem
            // 
            this.videoMenuItem.Checked = true;
            this.videoMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.videoMenuItem.Name = "videoMenuItem";
            this.videoMenuItem.Size = new System.Drawing.Size(112, 22);
            this.videoMenuItem.Text = "Video";
            this.videoMenuItem.Click += new System.EventHandler(this.VideoMenuItem_Click);
            // 
            // displayMenuItem
            // 
            this.displayMenuItem.Name = "displayMenuItem";
            this.displayMenuItem.Size = new System.Drawing.Size(112, 22);
            this.displayMenuItem.Text = "Display";
            this.displayMenuItem.Click += new System.EventHandler(this.DisplayMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(111, 6);
            // 
            // baseTileMenuItem
            // 
            this.baseTileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.baseNormalMenuItem,
            this.baseFlipXMenuItem,
            this.baseFlipXYMenuItem,
            this.baseFlipYMenuItem});
            this.baseTileMenuItem.Name = "baseTileMenuItem";
            this.baseTileMenuItem.Size = new System.Drawing.Size(114, 22);
            this.baseTileMenuItem.Text = "BaseTile";
            // 
            // baseNormalMenuItem
            // 
            this.baseNormalMenuItem.Checked = true;
            this.baseNormalMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.baseNormalMenuItem.Name = "baseNormalMenuItem";
            this.baseNormalMenuItem.Size = new System.Drawing.Size(114, 22);
            this.baseNormalMenuItem.Text = "Normal";
            this.baseNormalMenuItem.Click += new System.EventHandler(this.BaseNormalMenuItem_Click);
            // 
            // baseFlipXMenuItem
            // 
            this.baseFlipXMenuItem.Name = "baseFlipXMenuItem";
            this.baseFlipXMenuItem.Size = new System.Drawing.Size(114, 22);
            this.baseFlipXMenuItem.Text = "FlipX";
            this.baseFlipXMenuItem.Click += new System.EventHandler(this.BaseFlipXMenuItem_Click);
            // 
            // baseFlipXYMenuItem
            // 
            this.baseFlipXYMenuItem.Name = "baseFlipXYMenuItem";
            this.baseFlipXYMenuItem.Size = new System.Drawing.Size(114, 22);
            this.baseFlipXYMenuItem.Text = "FlipXY";
            this.baseFlipXYMenuItem.Click += new System.EventHandler(this.BaseFlipXYMenuItem_Click);
            // 
            // baseFlipYMenuItem
            // 
            this.baseFlipYMenuItem.Name = "baseFlipYMenuItem";
            this.baseFlipYMenuItem.Size = new System.Drawing.Size(114, 22);
            this.baseFlipYMenuItem.Text = "FlipY";
            this.baseFlipYMenuItem.Click += new System.EventHandler(this.BaseFlipYMenuItem_Click);
            // 
            // tileModeMenuItem
            // 
            this.tileModeMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tileNormalMenuItem,
            this.tileFlipXMenuItem,
            this.tileFlipXYMenuItem,
            this.tileFlipYMenuItem});
            this.tileModeMenuItem.Name = "tileModeMenuItem";
            this.tileModeMenuItem.Size = new System.Drawing.Size(114, 22);
            this.tileModeMenuItem.Text = "TileMode";
            // 
            // tileNormalMenuItem
            // 
            this.tileNormalMenuItem.Checked = true;
            this.tileNormalMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tileNormalMenuItem.Name = "tileNormalMenuItem";
            this.tileNormalMenuItem.Size = new System.Drawing.Size(126, 22);
            this.tileNormalMenuItem.Text = "Normal";
            this.tileNormalMenuItem.Click += new System.EventHandler(this.TileNormalMenuItem_Click);
            // 
            // tileFlipXMenuItem
            // 
            this.tileFlipXMenuItem.Name = "tileFlipXMenuItem";
            this.tileFlipXMenuItem.Size = new System.Drawing.Size(126, 22);
            this.tileFlipXMenuItem.Text = "TileFlipX";
            this.tileFlipXMenuItem.Click += new System.EventHandler(this.TileFlipXMenuItem_Click);
            // 
            // tileFlipXYMenuItem
            // 
            this.tileFlipXYMenuItem.Name = "tileFlipXYMenuItem";
            this.tileFlipXYMenuItem.Size = new System.Drawing.Size(126, 22);
            this.tileFlipXYMenuItem.Text = "TileFlipXY";
            this.tileFlipXYMenuItem.Click += new System.EventHandler(this.TileFlipXYMenuItem_Click);
            // 
            // tileFlipYMenuItem
            // 
            this.tileFlipYMenuItem.Name = "tileFlipYMenuItem";
            this.tileFlipYMenuItem.Size = new System.Drawing.Size(126, 22);
            this.tileFlipYMenuItem.Text = "TileFlipY";
            this.tileFlipYMenuItem.Click += new System.EventHandler(this.TileFlipYMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(111, 6);
            // 
            // opacityMenuItem
            // 
            this.opacityMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opacity25_MenuItem,
            this.opacity50_MenuItem,
            this.opacity75_MenuItem,
            this.opacity100_MenuItem});
            this.opacityMenuItem.Name = "opacityMenuItem";
            this.opacityMenuItem.Size = new System.Drawing.Size(114, 22);
            this.opacityMenuItem.Text = "Opacity";
            // 
            // opacity25_MenuItem
            // 
            this.opacity25_MenuItem.Name = "opacity25_MenuItem";
            this.opacity25_MenuItem.Size = new System.Drawing.Size(102, 22);
            this.opacity25_MenuItem.Text = "  25%";
            this.opacity25_MenuItem.Click += new System.EventHandler(this.Opacity25_MenuItem_Click);
            // 
            // opacity50_MenuItem
            // 
            this.opacity50_MenuItem.Name = "opacity50_MenuItem";
            this.opacity50_MenuItem.Size = new System.Drawing.Size(102, 22);
            this.opacity50_MenuItem.Text = "  50%";
            this.opacity50_MenuItem.Click += new System.EventHandler(this.Opacity50_MenuItem_Click);
            // 
            // opacity75_MenuItem
            // 
            this.opacity75_MenuItem.Name = "opacity75_MenuItem";
            this.opacity75_MenuItem.Size = new System.Drawing.Size(102, 22);
            this.opacity75_MenuItem.Text = "  75%";
            this.opacity75_MenuItem.Click += new System.EventHandler(this.Opacity75_MenuItem_Click);
            // 
            // opacity100_MenuItem
            // 
            this.opacity100_MenuItem.Checked = true;
            this.opacity100_MenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.opacity100_MenuItem.Name = "opacity100_MenuItem";
            this.opacity100_MenuItem.Size = new System.Drawing.Size(102, 22);
            this.opacity100_MenuItem.Text = "100%";
            this.opacity100_MenuItem.Click += new System.EventHandler(this.Opacity100_MenuItem_Click);
            // 
            // refreshRateMenuItem
            // 
            this.refreshRateMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fps01_MenuItem,
            this.fps02_MenuItem,
            this.fps05_MenuItem,
            this.fps10_MenuItem,
            this.fps15_MenuItem,
            this.fps20_MenuItem,
            this.fps25_MenuItem,
            this.fps30_MenuItem,
            this.fps40_MenuItem,
            this.fps50_MenuItem,
            this.fps60_MenuItem});
            this.refreshRateMenuItem.Name = "refreshRateMenuItem";
            this.refreshRateMenuItem.Size = new System.Drawing.Size(114, 22);
            this.refreshRateMenuItem.Text = "Refresh Rate";
            // 
            // fps01_MenuItem
            // 
            this.fps01_MenuItem.Name = "fps01_MenuItem";
            this.fps01_MenuItem.Size = new System.Drawing.Size(105, 22);
            this.fps01_MenuItem.Text = "01 fps";
            this.fps01_MenuItem.Click += new System.EventHandler(this.Fps01_MenuItem_Click);
            // 
            // fps02_MenuItem
            // 
            this.fps02_MenuItem.Name = "fps02_MenuItem";
            this.fps02_MenuItem.Size = new System.Drawing.Size(105, 22);
            this.fps02_MenuItem.Text = "02 fps";
            this.fps02_MenuItem.Click += new System.EventHandler(this.Fps02_MenuItem_Click);
            // 
            // fps05_MenuItem
            // 
            this.fps05_MenuItem.Name = "fps05_MenuItem";
            this.fps05_MenuItem.Size = new System.Drawing.Size(105, 22);
            this.fps05_MenuItem.Text = "05 fps";
            this.fps05_MenuItem.Click += new System.EventHandler(this.Fps05_MenuItem_Click);
            // 
            // fps10_MenuItem
            // 
            this.fps10_MenuItem.Name = "fps10_MenuItem";
            this.fps10_MenuItem.Size = new System.Drawing.Size(105, 22);
            this.fps10_MenuItem.Text = "10 fps";
            this.fps10_MenuItem.Click += new System.EventHandler(this.Fps10_MenuItem_Click);
            // 
            // fps15_MenuItem
            // 
            this.fps15_MenuItem.Name = "fps15_MenuItem";
            this.fps15_MenuItem.Size = new System.Drawing.Size(105, 22);
            this.fps15_MenuItem.Text = "15 fps";
            this.fps15_MenuItem.Click += new System.EventHandler(this.Fps15_MenuItem_Click);
            // 
            // fps20_MenuItem
            // 
            this.fps20_MenuItem.Name = "fps20_MenuItem";
            this.fps20_MenuItem.Size = new System.Drawing.Size(105, 22);
            this.fps20_MenuItem.Text = "20 fps";
            this.fps20_MenuItem.Click += new System.EventHandler(this.Fps20_MenuItem_Click);
            // 
            // fps25_MenuItem
            // 
            this.fps25_MenuItem.Checked = true;
            this.fps25_MenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.fps25_MenuItem.Name = "fps25_MenuItem";
            this.fps25_MenuItem.Size = new System.Drawing.Size(105, 22);
            this.fps25_MenuItem.Text = "25 fps";
            this.fps25_MenuItem.Click += new System.EventHandler(this.Fps25_MenuItem_Click);
            // 
            // fps30_MenuItem
            // 
            this.fps30_MenuItem.Name = "fps30_MenuItem";
            this.fps30_MenuItem.Size = new System.Drawing.Size(105, 22);
            this.fps30_MenuItem.Text = "30 fps";
            this.fps30_MenuItem.Click += new System.EventHandler(this.Fps30_MenuItem_Click);
            // 
            // fps40_MenuItem
            // 
            this.fps40_MenuItem.Name = "fps40_MenuItem";
            this.fps40_MenuItem.Size = new System.Drawing.Size(105, 22);
            this.fps40_MenuItem.Text = "40 fps";
            this.fps40_MenuItem.Click += new System.EventHandler(this.Fps40_MenuItem_Click);
            // 
            // fps50_MenuItem
            // 
            this.fps50_MenuItem.Name = "fps50_MenuItem";
            this.fps50_MenuItem.Size = new System.Drawing.Size(105, 22);
            this.fps50_MenuItem.Text = "50 fps";
            this.fps50_MenuItem.Click += new System.EventHandler(this.Fps50_MenuItem_Click);
            // 
            // fps60_MenuItem
            // 
            this.fps60_MenuItem.Name = "fps60_MenuItem";
            this.fps60_MenuItem.Size = new System.Drawing.Size(105, 22);
            this.fps60_MenuItem.Text = "60 fps";
            this.fps60_MenuItem.Click += new System.EventHandler(this.Fps60_MenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(111, 6);
            // 
            // puzzleMenuItem
            // 
            this.puzzleMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newPuzzleMenuItem,
            this.toolStripSeparator6,
            this.showGridMenuItem,
            this.showIndicatorsMenuItem});
            this.puzzleMenuItem.Name = "puzzleMenuItem";
            this.puzzleMenuItem.Size = new System.Drawing.Size(114, 22);
            this.puzzleMenuItem.Text = "Puzzle";
            // 
            // newPuzzleMenuItem
            // 
            this.newPuzzleMenuItem.Name = "newPuzzleMenuItem";
            this.newPuzzleMenuItem.Size = new System.Drawing.Size(172, 22);
            this.newPuzzleMenuItem.Text = "Start Puzzle";
            this.newPuzzleMenuItem.Click += new System.EventHandler(this.NewPuzzleMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(169, 6);
            // 
            // showGridMenuItem
            // 
            this.showGridMenuItem.Name = "showGridMenuItem";
            this.showGridMenuItem.Size = new System.Drawing.Size(172, 22);
            this.showGridMenuItem.Text = "Show Grid";
            this.showGridMenuItem.Click += new System.EventHandler(this.ShowGridMenuItem_Click);
            // 
            // showIndicatorsMenuItem
            // 
            this.showIndicatorsMenuItem.Name = "showIndicatorsMenuItem";
            this.showIndicatorsMenuItem.Size = new System.Drawing.Size(172, 22);
            this.showIndicatorsMenuItem.Text = "Show Correct Tiles";
            this.showIndicatorsMenuItem.Click += new System.EventHandler(this.ShowIndicatorsMenuItem_Click);
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.numericUpDown2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDown2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.numericUpDown2.Location = new System.Drawing.Point(52, 2);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.numericUpDown2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(48, 21);
            this.numericUpDown2.TabIndex = 1;
            this.numericUpDown2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown2.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.numericUpDown1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDown1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.numericUpDown1.Location = new System.Drawing.Point(2, 2);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(48, 21);
            this.numericUpDown1.TabIndex = 0;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown1.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(88, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Set";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // TilesOverlay
            // 
            this.AcceptButton = this.setButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.ClientSize = new System.Drawing.Size(323, 183);
            this.Controls.Add(this.tilesPanel);
            this.Name = "TilesOverlay";
            this.Text = "TileOverlay";
            this.TransparencyKey = System.Drawing.Color.RosyBrown;
            this.SizeChanged += new System.EventHandler(this.TileOverlay_SizeChanged);
            this.VisibleChanged += new System.EventHandler(this.TileOverlay_VisibleChanged);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TilesOverlay_MouseDown);
            this.tilesPanel.ResumeLayout(false);
            this.optionsMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel tilesPanel;
        private Button button1;
        private NumericUpDown numericUpDown2;
        private NumericUpDown numericUpDown1;
        private ContextMenuStrip optionsMenu;
        private ToolStripMenuItem tileSourceMenuItem;
        private ToolStripMenuItem videoMenuItem;
        private ToolStripMenuItem displayMenuItem;
        private ToolStripMenuItem tileModeMenuItem;
        private ToolStripMenuItem tileNormalMenuItem;
        private ToolStripMenuItem tileFlipXMenuItem;
        private ToolStripMenuItem tileFlipXYMenuItem;
        private ToolStripMenuItem tileFlipYMenuItem;
        private ToolStripMenuItem opacityMenuItem;
        private ToolStripMenuItem opacity25_MenuItem;
        private ToolStripMenuItem opacity50_MenuItem;
        private ToolStripMenuItem opacity75_MenuItem;
        private ToolStripMenuItem opacity100_MenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem refreshRateMenuItem;
        private ToolStripMenuItem fps30_MenuItem;
        private ToolStripMenuItem fps25_MenuItem;
        private ToolStripMenuItem fps20_MenuItem;
        private ToolStripMenuItem fps15_MenuItem;
        private ToolStripMenuItem baseTileMenuItem;
        private ToolStripMenuItem baseNormalMenuItem;
        private ToolStripMenuItem baseFlipXMenuItem;
        private ToolStripMenuItem baseFlipXYMenuItem;
        private ToolStripMenuItem baseFlipYMenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private DropDownButton optionsButton;
        private CustomButton setButton;
        private ToolStripMenuItem fps01_MenuItem;
        private ToolStripMenuItem fps02_MenuItem;
        private ToolStripMenuItem fps05_MenuItem;
        private ToolStripMenuItem fps10_MenuItem;
        private ToolStripMenuItem fps40_MenuItem;
        private ToolStripMenuItem fps50_MenuItem;
        private ToolStripMenuItem fps60_MenuItem;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem puzzleMenuItem;
        private ToolStripMenuItem showGridMenuItem;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripMenuItem showIndicatorsMenuItem;
        private ToolStripMenuItem newPuzzleMenuItem;
    }
}