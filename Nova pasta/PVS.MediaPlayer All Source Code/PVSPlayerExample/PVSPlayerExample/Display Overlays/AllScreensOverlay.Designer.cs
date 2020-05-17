using System.ComponentModel;
using System.Windows.Forms;

namespace AVPlayerExample
{
    partial class AllScreensOverlay
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.screensPanel = new System.Windows.Forms.Panel();
            this.optionsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.displayModeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stretchMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tilesStretchMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tilesZoomMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshRateMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fps15MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fps20MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fps25MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fps30MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.backColorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opacityMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opacity25MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opacity50MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opacity75MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opacity100MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.overlayInfoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displaySettingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.startMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsButton = new AVPlayerExample.DropDownButton();
            this.startButton = new AVPlayerExample.CustomButton();
            this.screensPanel.SuspendLayout();
            this.optionsMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // screensPanel
            // 
            this.screensPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.screensPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.screensPanel.Controls.Add(this.optionsButton);
            this.screensPanel.Controls.Add(this.startButton);
            this.screensPanel.Location = new System.Drawing.Point(12, 12);
            this.screensPanel.Name = "screensPanel";
            this.screensPanel.Size = new System.Drawing.Size(156, 27);
            this.screensPanel.TabIndex = 0;
            // 
            // optionsMenu
            // 
            this.optionsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.displayModeMenuItem,
            this.refreshRateMenuItem,
            this.toolStripSeparator3,
            this.backColorMenuItem,
            this.opacityMenuItem,
            this.toolStripSeparator4,
            this.overlayInfoMenuItem,
            this.displaySettingsMenuItem,
            this.toolStripSeparator2,
            this.startMenuItem});
            this.optionsMenu.Name = "contextMenuStrip1";
            this.optionsMenu.ShowImageMargin = false;
            this.optionsMenu.Size = new System.Drawing.Size(155, 176);
            // 
            // displayModeMenuItem
            // 
            this.displayModeMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stretchMenuItem,
            this.zoomMenuItem,
            this.tilesStretchMenuItem,
            this.tilesZoomMenuItem});
            this.displayModeMenuItem.Name = "displayModeMenuItem";
            this.displayModeMenuItem.Size = new System.Drawing.Size(154, 22);
            this.displayModeMenuItem.Text = "DisplayMode";
            // 
            // stretchMenuItem
            // 
            this.stretchMenuItem.Checked = true;
            this.stretchMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.stretchMenuItem.Name = "stretchMenuItem";
            this.stretchMenuItem.Size = new System.Drawing.Size(138, 22);
            this.stretchMenuItem.Text = "Stretch";
            this.stretchMenuItem.Click += new System.EventHandler(this.stretchMenuItem_Click);
            // 
            // zoomMenuItem
            // 
            this.zoomMenuItem.Name = "zoomMenuItem";
            this.zoomMenuItem.Size = new System.Drawing.Size(138, 22);
            this.zoomMenuItem.Text = "Zoom";
            this.zoomMenuItem.Click += new System.EventHandler(this.zoomMenuItem_Click);
            // 
            // tilesStretchMenuItem
            // 
            this.tilesStretchMenuItem.Name = "tilesStretchMenuItem";
            this.tilesStretchMenuItem.Size = new System.Drawing.Size(138, 22);
            this.tilesStretchMenuItem.Text = "Tiles Stretch";
            this.tilesStretchMenuItem.Click += new System.EventHandler(this.tilesStretchMenuItem_Click);
            // 
            // tilesZoomMenuItem
            // 
            this.tilesZoomMenuItem.Name = "tilesZoomMenuItem";
            this.tilesZoomMenuItem.Size = new System.Drawing.Size(138, 22);
            this.tilesZoomMenuItem.Text = "Tiles Zoom";
            this.tilesZoomMenuItem.Click += new System.EventHandler(this.tilesZoomMenuItem_Click);
            // 
            // refreshRateMenuItem
            // 
            this.refreshRateMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fps15MenuItem,
            this.fps20MenuItem,
            this.fps25MenuItem,
            this.fps30MenuItem});
            this.refreshRateMenuItem.Name = "refreshRateMenuItem";
            this.refreshRateMenuItem.Size = new System.Drawing.Size(154, 22);
            this.refreshRateMenuItem.Text = "Refresh Rate";
            // 
            // fps15MenuItem
            // 
            this.fps15MenuItem.Name = "fps15MenuItem";
            this.fps15MenuItem.Size = new System.Drawing.Size(105, 22);
            this.fps15MenuItem.Text = "15 fps";
            this.fps15MenuItem.Click += new System.EventHandler(this.fps15MenuItem_Click);
            // 
            // fps20MenuItem
            // 
            this.fps20MenuItem.Name = "fps20MenuItem";
            this.fps20MenuItem.Size = new System.Drawing.Size(105, 22);
            this.fps20MenuItem.Text = "20 fps";
            this.fps20MenuItem.Click += new System.EventHandler(this.fps20MenuItem_Click);
            // 
            // fps25MenuItem
            // 
            this.fps25MenuItem.Checked = true;
            this.fps25MenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.fps25MenuItem.Name = "fps25MenuItem";
            this.fps25MenuItem.Size = new System.Drawing.Size(105, 22);
            this.fps25MenuItem.Text = "25 fps";
            this.fps25MenuItem.Click += new System.EventHandler(this.fps25MenuItem_Click);
            // 
            // fps30MenuItem
            // 
            this.fps30MenuItem.Name = "fps30MenuItem";
            this.fps30MenuItem.Size = new System.Drawing.Size(105, 22);
            this.fps30MenuItem.Text = "30 fps";
            this.fps30MenuItem.Click += new System.EventHandler(this.fps30MenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(151, 6);
            // 
            // backColorMenuItem
            // 
            this.backColorMenuItem.Name = "backColorMenuItem";
            this.backColorMenuItem.Size = new System.Drawing.Size(154, 22);
            this.backColorMenuItem.Text = "Background Color…";
            this.backColorMenuItem.Click += new System.EventHandler(this.backColorMenuItem_Click);
            // 
            // opacityMenuItem
            // 
            this.opacityMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opacity25MenuItem,
            this.opacity50MenuItem,
            this.opacity75MenuItem,
            this.opacity100MenuItem});
            this.opacityMenuItem.Name = "opacityMenuItem";
            this.opacityMenuItem.Size = new System.Drawing.Size(154, 22);
            this.opacityMenuItem.Text = "Opacity";
            // 
            // opacity25MenuItem
            // 
            this.opacity25MenuItem.Name = "opacity25MenuItem";
            this.opacity25MenuItem.Size = new System.Drawing.Size(102, 22);
            this.opacity25MenuItem.Text = "  25%";
            this.opacity25MenuItem.Click += new System.EventHandler(this.opacity25MenuItem_Click);
            // 
            // opacity50MenuItem
            // 
            this.opacity50MenuItem.Name = "opacity50MenuItem";
            this.opacity50MenuItem.Size = new System.Drawing.Size(102, 22);
            this.opacity50MenuItem.Text = "  50%";
            this.opacity50MenuItem.Click += new System.EventHandler(this.opacity50MenuItem_Click);
            // 
            // opacity75MenuItem
            // 
            this.opacity75MenuItem.Name = "opacity75MenuItem";
            this.opacity75MenuItem.Size = new System.Drawing.Size(102, 22);
            this.opacity75MenuItem.Text = "  75%";
            this.opacity75MenuItem.Click += new System.EventHandler(this.opacity75MenuItem_Click);
            // 
            // opacity100MenuItem
            // 
            this.opacity100MenuItem.Checked = true;
            this.opacity100MenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.opacity100MenuItem.Name = "opacity100MenuItem";
            this.opacity100MenuItem.Size = new System.Drawing.Size(102, 22);
            this.opacity100MenuItem.Text = "100%";
            this.opacity100MenuItem.Click += new System.EventHandler(this.opacity100MenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(151, 6);
            // 
            // overlayInfoMenuItem
            // 
            this.overlayInfoMenuItem.Name = "overlayInfoMenuItem";
            this.overlayInfoMenuItem.Size = new System.Drawing.Size(154, 22);
            this.overlayInfoMenuItem.Text = "Overlay Info…";
            this.overlayInfoMenuItem.Click += new System.EventHandler(this.overlayInfoMenuItem_Click);
            // 
            // displaySettingsMenuItem
            // 
            this.displaySettingsMenuItem.Name = "displaySettingsMenuItem";
            this.displaySettingsMenuItem.Size = new System.Drawing.Size(154, 22);
            this.displaySettingsMenuItem.Text = "Display Settings…";
            this.displaySettingsMenuItem.Click += new System.EventHandler(this.displaySettingsMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(151, 6);
            // 
            // startMenuItem
            // 
            this.startMenuItem.Name = "startMenuItem";
            this.startMenuItem.Size = new System.Drawing.Size(154, 22);
            this.startMenuItem.Text = "Start \'All Screens\'";
            this.startMenuItem.Click += new System.EventHandler(this.startMenuItem_Click);
            // 
            // optionsButton
            // 
            this.optionsButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.optionsButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.optionsButton.DropDown = this.optionsMenu;
            this.optionsButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(159)))), ((int)(((byte)(87)))));
            this.optionsButton.Location = new System.Drawing.Point(79, 2);
            this.optionsButton.Name = "optionsButton";
            this.optionsButton.Size = new System.Drawing.Size(73, 21);
            this.optionsButton.TabIndex = 1;
            this.optionsButton.Text = "Options ";
            this.optionsButton.UseVisualStyleBackColor = true;
            // 
            // startButton
            // 
            this.startButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.startButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(159)))), ((int)(((byte)(87)))));
            this.startButton.Location = new System.Drawing.Point(2, 2);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 21);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // AllScreensOverlay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RosyBrown;
            this.ClientSize = new System.Drawing.Size(492, 279);
            this.Controls.Add(this.screensPanel);
            this.Name = "AllScreensOverlay";
            this.Text = "AllScreensOverlay";
            this.VisibleChanged += new System.EventHandler(this.AllScreensOverlay_VisibleChanged);
            this.screensPanel.ResumeLayout(false);
            this.optionsMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel screensPanel;
        private CustomButton startButton;
        private DropDownButton optionsButton;
        private ContextMenuStrip optionsMenu;
        private ToolStripMenuItem displayModeMenuItem;
        private ToolStripMenuItem stretchMenuItem;
        private ToolStripMenuItem zoomMenuItem;
        private ToolStripMenuItem tilesStretchMenuItem;
        private ToolStripMenuItem tilesZoomMenuItem;
        private ToolStripMenuItem backColorMenuItem;
        private ToolStripMenuItem refreshRateMenuItem;
        private ToolStripMenuItem fps15MenuItem;
        private ToolStripMenuItem fps20MenuItem;
        private ToolStripMenuItem fps25MenuItem;
        private ToolStripMenuItem fps30MenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem startMenuItem;
        private ToolStripMenuItem opacityMenuItem;
        private ToolStripMenuItem opacity25MenuItem;
        private ToolStripMenuItem opacity50MenuItem;
        private ToolStripMenuItem opacity75MenuItem;
        private ToolStripMenuItem opacity100MenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem displaySettingsMenuItem;
        private ToolStripMenuItem overlayInfoMenuItem;
        private ToolStripSeparator toolStripSeparator4;
    }
}