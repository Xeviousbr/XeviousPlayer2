using System.ComponentModel;
using System.Windows.Forms;

namespace PVSPlayerExample
{
    partial class PIPOverlay
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
            this.pipPanel = new System.Windows.Forms.Panel();
            this.stopButton = new PVSPlayerExample.CustomButton();
            this.pauseButton = new PVSPlayerExample.CustomButton();
            this.playButton = new PVSPlayerExample.DropDownButton();
            this.playMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addMediaFilesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.sizePanelNWSE = new System.Windows.Forms.Panel();
            this.sizePanelWE = new System.Windows.Forms.Panel();
            this.displayPanel = new System.Windows.Forms.Panel();
            this.displayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.playMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pauseMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.enableControlsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enableMovingMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enableResizingMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.opacityMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opacity25_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opacity50_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opacity75_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opacity100_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.switchScreensMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sizePanelNS = new System.Windows.Forms.Panel();
            this.positionSlider = new PVSPlayerExample.CustomSlider();
            this.playSubMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.playSubMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeFromListMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.sortListMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pipPanel.SuspendLayout();
            this.playMenu.SuspendLayout();
            this.displayMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.positionSlider)).BeginInit();
            this.playSubMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pipPanel
            // 
            this.pipPanel.Controls.Add(this.stopButton);
            this.pipPanel.Controls.Add(this.pauseButton);
            this.pipPanel.Controls.Add(this.playButton);
            this.pipPanel.Controls.Add(this.sizePanelNWSE);
            this.pipPanel.Controls.Add(this.sizePanelWE);
            this.pipPanel.Controls.Add(this.displayPanel);
            this.pipPanel.Controls.Add(this.sizePanelNS);
            this.pipPanel.Controls.Add(this.positionSlider);
            this.pipPanel.Location = new System.Drawing.Point(8, 7);
            this.pipPanel.MinimumSize = new System.Drawing.Size(193, 140);
            this.pipPanel.Name = "pipPanel";
            this.pipPanel.Size = new System.Drawing.Size(194, 173);
            this.pipPanel.TabIndex = 0;
            this.pipPanel.MouseEnter += new System.EventHandler(this.DisplayPanel_MouseEnter);
            this.pipPanel.MouseLeave += new System.EventHandler(this.PipPanel_MouseLeave);
            // 
            // stopButton
            // 
            this.stopButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.stopButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.stopButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.stopButton.Location = new System.Drawing.Point(125, 141);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(59, 21);
            this.stopButton.TabIndex = 8;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Visible = false;
            this.stopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // pauseButton
            // 
            this.pauseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pauseButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pauseButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.pauseButton.Location = new System.Drawing.Point(65, 141);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(59, 21);
            this.pauseButton.TabIndex = 7;
            this.pauseButton.Text = "Pause";
            this.pauseButton.UseVisualStyleBackColor = true;
            this.pauseButton.Visible = false;
            this.pauseButton.Click += new System.EventHandler(this.PauseButton_Click);
            // 
            // playButton
            // 
            this.playButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.playButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.playButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.playButton.DropDown = this.playMenu;
            this.playButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.playButton.Location = new System.Drawing.Point(8, 141);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(56, 21);
            this.playButton.TabIndex = 6;
            this.playButton.Text = "Play  ";
            this.playButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Visible = false;
            // 
            // playMenu
            // 
            this.playMenu.AllowDrop = true;
            this.playMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addMediaFilesMenuItem,
            this.toolStripSeparator1});
            this.playMenu.Name = "playMenu";
            this.playMenu.ShowImageMargin = false;
            this.playMenu.Size = new System.Drawing.Size(140, 32);
            this.playMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.PlayMenu_ItemClicked);
            this.playMenu.DragDrop += new System.Windows.Forms.DragEventHandler(this.PlayMenu_DragDrop);
            this.playMenu.DragOver += new System.Windows.Forms.DragEventHandler(this.PlayMenu_DragOver);
            this.playMenu.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PlayMenu_MouseClick);
            this.playMenu.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PlayMenu_MouseDown);
            this.playMenu.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PlayMenu_MouseMove);
            this.playMenu.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PlayMenu_MouseUp);
            // 
            // addMediaFilesMenuItem
            // 
            this.addMediaFilesMenuItem.Name = "addMediaFilesMenuItem";
            this.addMediaFilesMenuItem.Size = new System.Drawing.Size(139, 22);
            this.addMediaFilesMenuItem.Text = "Add MediaFiles…";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(136, 6);
            // 
            // sizePanelNWSE
            // 
            this.sizePanelNWSE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sizePanelNWSE.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.sizePanelNWSE.Location = new System.Drawing.Point(183, 119);
            this.sizePanelNWSE.Name = "sizePanelNWSE";
            this.sizePanelNWSE.Size = new System.Drawing.Size(6, 6);
            this.sizePanelNWSE.TabIndex = 5;
            this.sizePanelNWSE.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SizePanelSizing_MouseDown);
            this.sizePanelNWSE.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SizePanelSizing_MouseMove);
            this.sizePanelNWSE.MouseUp += new System.Windows.Forms.MouseEventHandler(this.SizePanelSizing_MouseUp);
            // 
            // sizePanelWE
            // 
            this.sizePanelWE.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sizePanelWE.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.sizePanelWE.Location = new System.Drawing.Point(183, 6);
            this.sizePanelWE.Name = "sizePanelWE";
            this.sizePanelWE.Size = new System.Drawing.Size(4, 113);
            this.sizePanelWE.TabIndex = 2;
            this.sizePanelWE.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SizePanelSizing_MouseDown);
            this.sizePanelWE.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SizePanelSizing_MouseMove);
            this.sizePanelWE.MouseUp += new System.Windows.Forms.MouseEventHandler(this.SizePanelSizing_MouseUp);
            // 
            // displayPanel
            // 
            this.displayPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.displayPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.displayPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.displayPanel.ContextMenuStrip = this.displayMenu;
            this.displayPanel.Location = new System.Drawing.Point(8, 8);
            this.displayPanel.Name = "displayPanel";
            this.displayPanel.Size = new System.Drawing.Size(175, 112);
            this.displayPanel.TabIndex = 1;
            this.displayPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SizePanelSizing_MouseDown);
            this.displayPanel.MouseEnter += new System.EventHandler(this.DisplayPanel_MouseEnter);
            this.displayPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SizePanelSizing_MouseMove);
            this.displayPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.SizePanelSizing_MouseUp);
            // 
            // displayMenu
            // 
            this.displayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playMenuItem,
            this.pauseMenuItem,
            this.stopMenuItem,
            this.toolStripSeparator3,
            this.enableControlsMenuItem,
            this.enableMovingMenuItem,
            this.enableResizingMenuItem,
            this.toolStripSeparator4,
            this.opacityMenuItem,
            this.toolStripSeparator5,
            this.switchScreensMenuItem});
            this.displayMenu.Name = "displayContextMenuStrip1";
            this.displayMenu.Size = new System.Drawing.Size(158, 198);
            // 
            // playMenuItem
            // 
            this.playMenuItem.Name = "playMenuItem";
            this.playMenuItem.Size = new System.Drawing.Size(157, 22);
            this.playMenuItem.Text = "Play";
            // 
            // pauseMenuItem
            // 
            this.pauseMenuItem.Name = "pauseMenuItem";
            this.pauseMenuItem.Size = new System.Drawing.Size(157, 22);
            this.pauseMenuItem.Text = "Pause";
            this.pauseMenuItem.Click += new System.EventHandler(this.PauseMenuItem_Click);
            // 
            // stopMenuItem
            // 
            this.stopMenuItem.Name = "stopMenuItem";
            this.stopMenuItem.Size = new System.Drawing.Size(157, 22);
            this.stopMenuItem.Text = "Stop";
            this.stopMenuItem.Click += new System.EventHandler(this.StopMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(154, 6);
            // 
            // enableControlsMenuItem
            // 
            this.enableControlsMenuItem.Checked = true;
            this.enableControlsMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.enableControlsMenuItem.Name = "enableControlsMenuItem";
            this.enableControlsMenuItem.Size = new System.Drawing.Size(157, 22);
            this.enableControlsMenuItem.Text = "Enable Controls";
            this.enableControlsMenuItem.Click += new System.EventHandler(this.EnableControlsMenuItem_Click);
            // 
            // enableMovingMenuItem
            // 
            this.enableMovingMenuItem.Checked = true;
            this.enableMovingMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.enableMovingMenuItem.Name = "enableMovingMenuItem";
            this.enableMovingMenuItem.Size = new System.Drawing.Size(157, 22);
            this.enableMovingMenuItem.Text = "Enable Moving";
            this.enableMovingMenuItem.Click += new System.EventHandler(this.EnableMovingMenuItem_Click);
            // 
            // enableResizingMenuItem
            // 
            this.enableResizingMenuItem.Checked = true;
            this.enableResizingMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.enableResizingMenuItem.Name = "enableResizingMenuItem";
            this.enableResizingMenuItem.Size = new System.Drawing.Size(157, 22);
            this.enableResizingMenuItem.Text = "Enable Resizing";
            this.enableResizingMenuItem.Click += new System.EventHandler(this.EnableResizingMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(154, 6);
            // 
            // opacityMenuItem
            // 
            this.opacityMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opacity25_MenuItem,
            this.opacity50_MenuItem,
            this.opacity75_MenuItem,
            this.opacity100_MenuItem});
            this.opacityMenuItem.Name = "opacityMenuItem";
            this.opacityMenuItem.Size = new System.Drawing.Size(157, 22);
            this.opacityMenuItem.Text = "Opacity";
            // 
            // opacity25_MenuItem
            // 
            this.opacity25_MenuItem.Name = "opacity25_MenuItem";
            this.opacity25_MenuItem.Size = new System.Drawing.Size(102, 22);
            this.opacity25_MenuItem.Text = "  25%";
            this.opacity25_MenuItem.Click += new System.EventHandler(this.HandleToolStripOpacity);
            // 
            // opacity50_MenuItem
            // 
            this.opacity50_MenuItem.Name = "opacity50_MenuItem";
            this.opacity50_MenuItem.Size = new System.Drawing.Size(102, 22);
            this.opacity50_MenuItem.Text = "  50%";
            this.opacity50_MenuItem.Click += new System.EventHandler(this.HandleToolStripOpacity);
            // 
            // opacity75_MenuItem
            // 
            this.opacity75_MenuItem.Name = "opacity75_MenuItem";
            this.opacity75_MenuItem.Size = new System.Drawing.Size(102, 22);
            this.opacity75_MenuItem.Text = "  75%";
            this.opacity75_MenuItem.Click += new System.EventHandler(this.HandleToolStripOpacity);
            // 
            // opacity100_MenuItem
            // 
            this.opacity100_MenuItem.Checked = true;
            this.opacity100_MenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.opacity100_MenuItem.Name = "opacity100_MenuItem";
            this.opacity100_MenuItem.Size = new System.Drawing.Size(102, 22);
            this.opacity100_MenuItem.Text = "100%";
            this.opacity100_MenuItem.Click += new System.EventHandler(this.HandleToolStripOpacity);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(154, 6);
            // 
            // switchScreensMenuItem
            // 
            this.switchScreensMenuItem.Name = "switchScreensMenuItem";
            this.switchScreensMenuItem.Size = new System.Drawing.Size(157, 22);
            this.switchScreensMenuItem.Text = "Switch Screens";
            this.switchScreensMenuItem.Click += new System.EventHandler(this.SwitchScreensMenuItem_Click);
            // 
            // sizePanelNS
            // 
            this.sizePanelNS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sizePanelNS.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.sizePanelNS.Location = new System.Drawing.Point(9, 120);
            this.sizePanelNS.Name = "sizePanelNS";
            this.sizePanelNS.Size = new System.Drawing.Size(174, 3);
            this.sizePanelNS.TabIndex = 4;
            this.sizePanelNS.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SizePanelSizing_MouseDown);
            this.sizePanelNS.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SizePanelSizing_MouseMove);
            this.sizePanelNS.MouseUp += new System.Windows.Forms.MouseEventHandler(this.SizePanelSizing_MouseUp);
            // 
            // positionSlider
            // 
            this.positionSlider.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.positionSlider.AutoSize = false;
            this.positionSlider.BackColor = System.Drawing.Color.RosyBrown;
            this.positionSlider.Location = new System.Drawing.Point(0, 121);
            this.positionSlider.Name = "positionSlider";
            this.positionSlider.Size = new System.Drawing.Size(191, 26);
            this.positionSlider.TabIndex = 3;
            this.positionSlider.Visible = false;
            // 
            // playSubMenu
            // 
            this.playSubMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playSubMenuItem,
            this.removeFromListMenuItem,
            this.toolStripSeparator2,
            this.sortListMenuItem});
            this.playSubMenu.Name = "playSubMenu";
            this.playSubMenu.ShowImageMargin = false;
            this.playSubMenu.Size = new System.Drawing.Size(145, 76);
            this.playSubMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.PlaySubMenu_ItemClicked);
            // 
            // playSubMenuItem
            // 
            this.playSubMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.playSubMenuItem.Name = "playSubMenuItem";
            this.playSubMenuItem.Size = new System.Drawing.Size(144, 22);
            this.playSubMenuItem.Text = "Play";
            // 
            // removeFromListMenuItem
            // 
            this.removeFromListMenuItem.Name = "removeFromListMenuItem";
            this.removeFromListMenuItem.Size = new System.Drawing.Size(144, 22);
            this.removeFromListMenuItem.Text = "Remove From List";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(141, 6);
            // 
            // sortListMenuItem
            // 
            this.sortListMenuItem.Name = "sortListMenuItem";
            this.sortListMenuItem.Size = new System.Drawing.Size(144, 22);
            this.sortListMenuItem.Text = "Sort List";
            // 
            // PIPOverlay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RosyBrown;
            this.ClientSize = new System.Drawing.Size(365, 261);
            this.Controls.Add(this.pipPanel);
            this.DoubleBuffered = true;
            this.Name = "PIPOverlay";
            this.Text = "PIPOverlay";
            this.VisibleChanged += new System.EventHandler(this.PIPOverlay_VisibleChanged);
            this.Resize += new System.EventHandler(this.PIPOverlay_Resize);
            this.pipPanel.ResumeLayout(false);
            this.playMenu.ResumeLayout(false);
            this.displayMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.positionSlider)).EndInit();
            this.playSubMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel pipPanel;
        private Panel displayPanel;
        private Panel sizePanelWE;
        private Panel sizePanelNS;
        private Panel sizePanelNWSE;
        private ToolStripMenuItem playMenuItem;
        private ToolStripMenuItem pauseMenuItem;
        private ToolStripMenuItem stopMenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem enableControlsMenuItem;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem switchScreensMenuItem;
        private ToolStripMenuItem enableMovingMenuItem;
        private ToolStripMenuItem enableResizingMenuItem;
        private ToolStripMenuItem opacityMenuItem;
        private ToolStripMenuItem opacity25_MenuItem;
        private ToolStripMenuItem opacity50_MenuItem;
        private ToolStripMenuItem opacity75_MenuItem;
        private ToolStripMenuItem opacity100_MenuItem;
        private ToolStripSeparator toolStripSeparator5;
        private DropDownButton playButton;
        internal ContextMenuStrip displayMenu;
        private ContextMenuStrip playMenu;
        private ToolStripMenuItem addMediaFilesMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ContextMenuStrip playSubMenu;
        private ToolStripMenuItem playSubMenuItem;
        private ToolStripMenuItem removeFromListMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem sortListMenuItem;
        private CustomButton stopButton;
        private CustomButton pauseButton;
        private CustomSlider positionSlider;
    }
}