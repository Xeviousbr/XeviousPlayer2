using System.ComponentModel;
using System.Windows.Forms;

namespace PVSPlayerExample
{
    partial class BigTimeOverlay
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
            this.endTimerLabel = new System.Windows.Forms.Label();
            this.optionsPanel = new System.Windows.Forms.Panel();
            this.optionsButton = new PVSPlayerExample.DropDownButton();
            this.optionsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.timeModeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trackTimeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.progressTimeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.showVUMetersMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.opacityMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opacity25MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opacity50MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opacity75MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opacity100MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startTimerLabel = new System.Windows.Forms.Label();
            this.optionsPanel.SuspendLayout();
            this.optionsMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // endTimerLabel
            // 
            this.endTimerLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.endTimerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endTimerLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.endTimerLabel.Location = new System.Drawing.Point(383, 314);
            this.endTimerLabel.Name = "endTimerLabel";
            this.endTimerLabel.Size = new System.Drawing.Size(328, 61);
            this.endTimerLabel.TabIndex = 1;
            this.endTimerLabel.Text = "00:00:00.000";
            // 
            // optionsPanel
            // 
            this.optionsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.optionsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.optionsPanel.Controls.Add(this.optionsButton);
            this.optionsPanel.Location = new System.Drawing.Point(12, 12);
            this.optionsPanel.Name = "optionsPanel";
            this.optionsPanel.Size = new System.Drawing.Size(79, 27);
            this.optionsPanel.TabIndex = 2;
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
            this.timeModeMenuItem,
            this.colorMenuItem,
            this.toolStripSeparator1,
            this.showVUMetersMenuItem,
            this.toolStripSeparator2,
            this.opacityMenuItem});
            this.optionsMenu.Name = "optionsMenu";
            this.optionsMenu.ShowImageMargin = false;
            this.optionsMenu.Size = new System.Drawing.Size(136, 104);
            // 
            // timeModeMenuItem
            // 
            this.timeModeMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trackTimeMenuItem,
            this.progressTimeMenuItem});
            this.timeModeMenuItem.Name = "timeModeMenuItem";
            this.timeModeMenuItem.Size = new System.Drawing.Size(135, 22);
            this.timeModeMenuItem.Text = "Time Mode";
            // 
            // trackTimeMenuItem
            // 
            this.trackTimeMenuItem.Name = "trackTimeMenuItem";
            this.trackTimeMenuItem.Size = new System.Drawing.Size(149, 22);
            this.trackTimeMenuItem.Text = "Track Time";
            this.trackTimeMenuItem.Click += new System.EventHandler(this.TrackTimeMenuItem_Click);
            // 
            // progressTimeMenuItem
            // 
            this.progressTimeMenuItem.Checked = true;
            this.progressTimeMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.progressTimeMenuItem.Name = "progressTimeMenuItem";
            this.progressTimeMenuItem.Size = new System.Drawing.Size(149, 22);
            this.progressTimeMenuItem.Text = "Progress Time";
            this.progressTimeMenuItem.Click += new System.EventHandler(this.ProgressTimeMenuItem_Click);
            // 
            // colorMenuItem
            // 
            this.colorMenuItem.Name = "colorMenuItem";
            this.colorMenuItem.Size = new System.Drawing.Size(135, 22);
            this.colorMenuItem.Text = "Time Color…";
            this.colorMenuItem.Click += new System.EventHandler(this.ColorMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(132, 6);
            // 
            // showVUMetersMenuItem
            // 
            this.showVUMetersMenuItem.Name = "showVUMetersMenuItem";
            this.showVUMetersMenuItem.Size = new System.Drawing.Size(135, 22);
            this.showVUMetersMenuItem.Text = "Show VU Meters";
            this.showVUMetersMenuItem.Click += new System.EventHandler(this.ShowVUMetersMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(132, 6);
            // 
            // opacityMenuItem
            // 
            this.opacityMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opacity25MenuItem,
            this.opacity50MenuItem,
            this.opacity75MenuItem,
            this.opacity100MenuItem});
            this.opacityMenuItem.Name = "opacityMenuItem";
            this.opacityMenuItem.Size = new System.Drawing.Size(135, 22);
            this.opacityMenuItem.Text = "Opacity";
            // 
            // opacity25MenuItem
            // 
            this.opacity25MenuItem.Name = "opacity25MenuItem";
            this.opacity25MenuItem.Size = new System.Drawing.Size(102, 22);
            this.opacity25MenuItem.Text = "  25%";
            this.opacity25MenuItem.Click += new System.EventHandler(this.Opacity25_MenuItem_Click);
            // 
            // opacity50MenuItem
            // 
            this.opacity50MenuItem.Name = "opacity50MenuItem";
            this.opacity50MenuItem.Size = new System.Drawing.Size(102, 22);
            this.opacity50MenuItem.Text = "  50%";
            this.opacity50MenuItem.Click += new System.EventHandler(this.Opacity50_MenuItem_Click);
            // 
            // opacity75MenuItem
            // 
            this.opacity75MenuItem.Name = "opacity75MenuItem";
            this.opacity75MenuItem.Size = new System.Drawing.Size(102, 22);
            this.opacity75MenuItem.Text = "  75%";
            this.opacity75MenuItem.Click += new System.EventHandler(this.Opacity75_MenuItem_Click);
            // 
            // opacity100MenuItem
            // 
            this.opacity100MenuItem.Checked = true;
            this.opacity100MenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.opacity100MenuItem.Name = "opacity100MenuItem";
            this.opacity100MenuItem.Size = new System.Drawing.Size(102, 22);
            this.opacity100MenuItem.Text = "100%";
            this.opacity100MenuItem.Click += new System.EventHandler(this.Opacity100_MenuItem_Click);
            // 
            // startTimerLabel
            // 
            this.startTimerLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.startTimerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startTimerLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.startTimerLabel.Location = new System.Drawing.Point(5, 314);
            this.startTimerLabel.Name = "startTimerLabel";
            this.startTimerLabel.Size = new System.Drawing.Size(328, 61);
            this.startTimerLabel.TabIndex = 3;
            this.startTimerLabel.Text = "00:00:00.000";
            // 
            // BigTimeOverlay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(171)))), ((int)(((byte)(144)))));
            this.ClientSize = new System.Drawing.Size(706, 375);
            this.Controls.Add(this.endTimerLabel);
            this.Controls.Add(this.startTimerLabel);
            this.Controls.Add(this.optionsPanel);
            this.Name = "BigTimeOverlay";
            this.Text = "BigTimeOverlay";
            this.VisibleChanged += new System.EventHandler(this.BigTimeOverlay_VisibleChanged);
            this.optionsPanel.ResumeLayout(false);
            this.optionsMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Label endTimerLabel;
        private Panel optionsPanel;
        private DropDownButton optionsButton;
        private ContextMenuStrip optionsMenu;
        private ToolStripMenuItem timeModeMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem colorMenuItem;
        private ToolStripMenuItem opacityMenuItem;
        private ToolStripMenuItem opacity25MenuItem;
        private ToolStripMenuItem opacity50MenuItem;
        private ToolStripMenuItem opacity75MenuItem;
        private ToolStripMenuItem opacity100MenuItem;
        private ToolStripMenuItem trackTimeMenuItem;
        private ToolStripMenuItem progressTimeMenuItem;
        private ToolStripMenuItem showVUMetersMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private Label startTimerLabel;
    }
}