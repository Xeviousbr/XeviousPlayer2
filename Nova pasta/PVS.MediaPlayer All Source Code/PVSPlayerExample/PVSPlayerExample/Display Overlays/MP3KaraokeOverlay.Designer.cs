using System.ComponentModel;
using System.Windows.Forms;

namespace PVSPlayerExample
{
    partial class Mp3KaraokeOverlay
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
            this.optionsPanel = new System.Windows.Forms.Panel();
            this.optionsButton = new PVSPlayerExample.DropDownButton();
            this.optionsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.sizeModeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stretchMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.backgroundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transparentMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.normalMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backModeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bgZoomMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bgStretchMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bgMatchForegroundMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.playCDGFileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.optionsPanel.SuspendLayout();
            this.optionsMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // optionsPanel
            // 
            this.optionsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.optionsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.optionsPanel.Controls.Add(this.optionsButton);
            this.optionsPanel.Location = new System.Drawing.Point(12, 12);
            this.optionsPanel.Name = "optionsPanel";
            this.optionsPanel.Size = new System.Drawing.Size(79, 27);
            this.optionsPanel.TabIndex = 0;
            this.optionsPanel.Visible = false;
            // 
            // optionsButton
            // 
            this.optionsButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.optionsButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.optionsButton.DropDown = this.optionsMenu;
            this.optionsButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.optionsButton.Location = new System.Drawing.Point(2, 2);
            this.optionsButton.Name = "optionsButton";
            this.optionsButton.Size = new System.Drawing.Size(73, 21);
            this.optionsButton.TabIndex = 0;
            this.optionsButton.Text = "Options ";
            this.optionsButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.optionsButton.UseVisualStyleBackColor = true;
            // 
            // optionsMenu
            // 
            this.optionsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sizeModeMenuItem,
            this.toolStripSeparator2,
            this.backgroundToolStripMenuItem,
            this.backModeMenuItem,
            this.toolStripSeparator3,
            this.playCDGFileMenuItem});
            this.optionsMenu.Name = "optionsMenu";
            this.optionsMenu.ShowImageMargin = false;
            this.optionsMenu.Size = new System.Drawing.Size(171, 104);
            // 
            // sizeModeMenuItem
            // 
            this.sizeModeMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoomMenuItem,
            this.stretchMenuItem});
            this.sizeModeMenuItem.Name = "sizeModeMenuItem";
            this.sizeModeMenuItem.Size = new System.Drawing.Size(170, 22);
            this.sizeModeMenuItem.Text = "Foreground Size Mode";
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
            // stretchMenuItem
            // 
            this.stretchMenuItem.Name = "stretchMenuItem";
            this.stretchMenuItem.Size = new System.Drawing.Size(111, 22);
            this.stretchMenuItem.Text = "Stretch";
            this.stretchMenuItem.Click += new System.EventHandler(this.StretchMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(167, 6);
            // 
            // backgroundToolStripMenuItem
            // 
            this.backgroundToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.colorMenuItem,
            this.imageMenuItem,
            this.transparentMenuItem,
            this.toolStripSeparator1,
            this.normalMenuItem});
            this.backgroundToolStripMenuItem.Name = "backgroundToolStripMenuItem";
            this.backgroundToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.backgroundToolStripMenuItem.Text = "Background";
            // 
            // colorMenuItem
            // 
            this.colorMenuItem.Name = "colorMenuItem";
            this.colorMenuItem.Size = new System.Drawing.Size(136, 22);
            this.colorMenuItem.Text = "Color…";
            this.colorMenuItem.Click += new System.EventHandler(this.ColorMenuItem_Click);
            // 
            // imageMenuItem
            // 
            this.imageMenuItem.Name = "imageMenuItem";
            this.imageMenuItem.Size = new System.Drawing.Size(136, 22);
            this.imageMenuItem.Text = "Image…";
            this.imageMenuItem.Click += new System.EventHandler(this.ImageMenuItem_Click);
            // 
            // transparentMenuItem
            // 
            this.transparentMenuItem.Name = "transparentMenuItem";
            this.transparentMenuItem.Size = new System.Drawing.Size(136, 22);
            this.transparentMenuItem.Text = "Transparent";
            this.transparentMenuItem.Click += new System.EventHandler(this.TransparentMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(133, 6);
            // 
            // normalMenuItem
            // 
            this.normalMenuItem.Checked = true;
            this.normalMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.normalMenuItem.Name = "normalMenuItem";
            this.normalMenuItem.Size = new System.Drawing.Size(136, 22);
            this.normalMenuItem.Text = "Normal";
            this.normalMenuItem.Click += new System.EventHandler(this.NormalMenuItem_Click);
            // 
            // backModeMenuItem
            // 
            this.backModeMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bgZoomMenuItem,
            this.bgStretchMenuItem,
            this.bgMatchForegroundMenuItem});
            this.backModeMenuItem.Enabled = false;
            this.backModeMenuItem.Name = "backModeMenuItem";
            this.backModeMenuItem.Size = new System.Drawing.Size(170, 22);
            this.backModeMenuItem.Text = "Background Size Mode";
            // 
            // bgZoomMenuItem
            // 
            this.bgZoomMenuItem.Checked = true;
            this.bgZoomMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.bgZoomMenuItem.Enabled = false;
            this.bgZoomMenuItem.Name = "bgZoomMenuItem";
            this.bgZoomMenuItem.Size = new System.Drawing.Size(159, 22);
            this.bgZoomMenuItem.Text = "Zoom";
            this.bgZoomMenuItem.Click += new System.EventHandler(this.BgZoomMenuItem_Click);
            // 
            // bgStretchMenuItem
            // 
            this.bgStretchMenuItem.Enabled = false;
            this.bgStretchMenuItem.Name = "bgStretchMenuItem";
            this.bgStretchMenuItem.Size = new System.Drawing.Size(159, 22);
            this.bgStretchMenuItem.Text = "Stretch";
            this.bgStretchMenuItem.Click += new System.EventHandler(this.BgStretchMenuItem_Click);
            // 
            // bgMatchForegroundMenuItem
            // 
            this.bgMatchForegroundMenuItem.Enabled = false;
            this.bgMatchForegroundMenuItem.Name = "bgMatchForegroundMenuItem";
            this.bgMatchForegroundMenuItem.Size = new System.Drawing.Size(159, 22);
            this.bgMatchForegroundMenuItem.Text = "Foreground Size";
            this.bgMatchForegroundMenuItem.Click += new System.EventHandler(this.BgMatchForegroundMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(167, 6);
            // 
            // playCDGFileMenuItem
            // 
            this.playCDGFileMenuItem.Name = "playCDGFileMenuItem";
            this.playCDGFileMenuItem.Size = new System.Drawing.Size(170, 22);
            this.playCDGFileMenuItem.Text = "Play Karaoke File…";
            this.playCDGFileMenuItem.Click += new System.EventHandler(this.PlayCDGFileMenuItem_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.label1.Location = new System.Drawing.Point(0, 239);
            this.label1.MinimumSize = new System.Drawing.Size(200, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(361, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "No Karaoke File";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Mp3KaraokeOverlay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RosyBrown;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(361, 270);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.optionsPanel);
            this.Name = "Mp3KaraokeOverlay";
            this.Text = "MP3KaraokeOverlay";
            this.TransparencyKey = System.Drawing.Color.RosyBrown;
            this.VisibleChanged += new System.EventHandler(this.MP3KaraokeOverlay_VisibleChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MP3KaraokeOverlay_Paint);
            this.optionsPanel.ResumeLayout(false);
            this.optionsMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel optionsPanel;
        private DropDownButton optionsButton;
        private ContextMenuStrip optionsMenu;
        private ToolStripMenuItem sizeModeMenuItem;
        private ToolStripMenuItem stretchMenuItem;
        private ToolStripMenuItem zoomMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem backgroundToolStripMenuItem;
        private ToolStripMenuItem colorMenuItem;
        private ToolStripMenuItem imageMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem normalMenuItem;
        private ToolStripMenuItem backModeMenuItem;
        private ToolStripMenuItem bgStretchMenuItem;
        private ToolStripMenuItem bgZoomMenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem playCDGFileMenuItem;
        private ToolStripMenuItem transparentMenuItem;
        private ToolStripMenuItem bgMatchForegroundMenuItem;
        private Label label1;
    }
}