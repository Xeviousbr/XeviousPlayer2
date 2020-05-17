using System.ComponentModel;
using System.Windows.Forms;

namespace FolderView
{
    partial class SubtitlesOverlay
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
            this.textEncodingMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aSCIIMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bigEndianMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unicodeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uTF32MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uTF7MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uTF8MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.defaultEncodingMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.fontMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textColorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.backgroundMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fillBackMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shadowBackMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.offBackMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backColorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.autoSizeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoSizeLargeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoSizeMediumMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoSizeSmallMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.autoSizeOffMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opacityMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opacity25MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opacity50MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opacity75MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opacity100MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.synchronizingMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subtitleSelectorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.add01SecondMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.add05SecondsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.add10SecondMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.subtract01SecondMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subtract05SecondsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subtract10SecondMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.resetMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.restoreDefaultSettingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.antiAliasMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.antiAliasGridFitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearTypeGridFitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.singleBitPerPixelMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.singleBitPerPixelGridFitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.antiAliasSystemDefaultMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.noAntiAliasingMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsPanel = new System.Windows.Forms.Panel();
            this.optionsButton = new FolderView.DropDownButton();
            this.subtitleListBox = new System.Windows.Forms.ListBox();
            this.findPanel1 = new System.Windows.Forms.Panel();
            this.findCancelButton = new FolderView.CustomButton();
            this.findSetButton = new FolderView.CustomButton();
            this.findPanel2 = new System.Windows.Forms.Panel();
            this.findPanel3 = new System.Windows.Forms.Panel();
            this.findTextBox = new System.Windows.Forms.TextBox();
            this.findButton = new FolderView.CustomButton();
            this.optionsMenu.SuspendLayout();
            this.optionsPanel.SuspendLayout();
            this.findPanel1.SuspendLayout();
            this.findPanel2.SuspendLayout();
            this.findPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // textEncodingMenuItem
            // 
            this.textEncodingMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aSCIIMenuItem,
            this.bigEndianMenuItem,
            this.unicodeMenuItem,
            this.uTF32MenuItem,
            this.uTF7MenuItem,
            this.uTF8MenuItem,
            this.toolStripSeparator3,
            this.defaultEncodingMenuItem});
            this.textEncodingMenuItem.Name = "textEncodingMenuItem";
            this.textEncodingMenuItem.Size = new System.Drawing.Size(199, 22);
            this.textEncodingMenuItem.Text = "Encoding";
            // 
            // aSCIIMenuItem
            // 
            this.aSCIIMenuItem.Name = "aSCIIMenuItem";
            this.aSCIIMenuItem.Size = new System.Drawing.Size(177, 22);
            this.aSCIIMenuItem.Text = "ASCII";
            this.aSCIIMenuItem.Click += new System.EventHandler(this.ASCIIMenuItem_Click);
            // 
            // bigEndianMenuItem
            // 
            this.bigEndianMenuItem.Name = "bigEndianMenuItem";
            this.bigEndianMenuItem.Size = new System.Drawing.Size(177, 22);
            this.bigEndianMenuItem.Text = "Big Endian Unicode";
            this.bigEndianMenuItem.Click += new System.EventHandler(this.BigEndianMenuItem_Click);
            // 
            // unicodeMenuItem
            // 
            this.unicodeMenuItem.Name = "unicodeMenuItem";
            this.unicodeMenuItem.Size = new System.Drawing.Size(177, 22);
            this.unicodeMenuItem.Text = "Unicode";
            this.unicodeMenuItem.Click += new System.EventHandler(this.UnicodeMenuItem_Click);
            // 
            // uTF32MenuItem
            // 
            this.uTF32MenuItem.Name = "uTF32MenuItem";
            this.uTF32MenuItem.Size = new System.Drawing.Size(177, 22);
            this.uTF32MenuItem.Text = "UTF-32";
            this.uTF32MenuItem.Click += new System.EventHandler(this.UTF32MenuItem_Click);
            // 
            // uTF7MenuItem
            // 
            this.uTF7MenuItem.Name = "uTF7MenuItem";
            this.uTF7MenuItem.Size = new System.Drawing.Size(177, 22);
            this.uTF7MenuItem.Text = "UTF-7";
            this.uTF7MenuItem.Click += new System.EventHandler(this.UTF7MenuItem_Click);
            // 
            // uTF8MenuItem
            // 
            this.uTF8MenuItem.Name = "uTF8MenuItem";
            this.uTF8MenuItem.Size = new System.Drawing.Size(177, 22);
            this.uTF8MenuItem.Text = "UTF-8";
            this.uTF8MenuItem.Click += new System.EventHandler(this.UTF8MenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(174, 6);
            // 
            // defaultEncodingMenuItem
            // 
            this.defaultEncodingMenuItem.Checked = true;
            this.defaultEncodingMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.defaultEncodingMenuItem.Name = "defaultEncodingMenuItem";
            this.defaultEncodingMenuItem.Size = new System.Drawing.Size(177, 22);
            this.defaultEncodingMenuItem.Text = "Default";
            this.defaultEncodingMenuItem.Click += new System.EventHandler(this.DefaultMenuItem_Click);
            // 
            // optionsMenu
            // 
            this.optionsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fontMenuItem,
            this.textColorMenuItem,
            this.toolStripSeparator11,
            this.backgroundMenuItem,
            this.backColorMenuItem,
            this.toolStripSeparator4,
            this.autoSizeMenuItem,
            this.opacityMenuItem,
            this.toolStripSeparator12,
            this.textEncodingMenuItem,
            this.synchronizingMenuItem,
            this.toolStripSeparator5,
            this.restoreDefaultSettingsMenuItem});
            this.optionsMenu.Name = "optionsMenu";
            this.optionsMenu.Size = new System.Drawing.Size(200, 226);
            // 
            // fontMenuItem
            // 
            this.fontMenuItem.Name = "fontMenuItem";
            this.fontMenuItem.Size = new System.Drawing.Size(199, 22);
            this.fontMenuItem.Text = "Text Font…";
            this.fontMenuItem.Click += new System.EventHandler(this.FontMenuItem_Click);
            // 
            // textColorMenuItem
            // 
            this.textColorMenuItem.Name = "textColorMenuItem";
            this.textColorMenuItem.Size = new System.Drawing.Size(199, 22);
            this.textColorMenuItem.Text = "Text Color…";
            this.textColorMenuItem.Click += new System.EventHandler(this.TextColorMenuItem_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(196, 6);
            // 
            // backgroundMenuItem
            // 
            this.backgroundMenuItem.Checked = true;
            this.backgroundMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.backgroundMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fillBackMenuItem,
            this.shadowBackMenuItem,
            this.toolStripSeparator10,
            this.offBackMenuItem});
            this.backgroundMenuItem.Name = "backgroundMenuItem";
            this.backgroundMenuItem.Size = new System.Drawing.Size(199, 22);
            this.backgroundMenuItem.Text = "Background";
            // 
            // fillBackMenuItem
            // 
            this.fillBackMenuItem.Name = "fillBackMenuItem";
            this.fillBackMenuItem.Size = new System.Drawing.Size(116, 22);
            this.fillBackMenuItem.Text = "Fill";
            this.fillBackMenuItem.Click += new System.EventHandler(this.FillBackMenuItem_Click);
            // 
            // shadowBackMenuItem
            // 
            this.shadowBackMenuItem.Checked = true;
            this.shadowBackMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.shadowBackMenuItem.Name = "shadowBackMenuItem";
            this.shadowBackMenuItem.Size = new System.Drawing.Size(116, 22);
            this.shadowBackMenuItem.Text = "Shadow";
            this.shadowBackMenuItem.Click += new System.EventHandler(this.ShadowBackMenuItem_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(113, 6);
            // 
            // offBackMenuItem
            // 
            this.offBackMenuItem.Name = "offBackMenuItem";
            this.offBackMenuItem.Size = new System.Drawing.Size(116, 22);
            this.offBackMenuItem.Text = "Off";
            this.offBackMenuItem.Click += new System.EventHandler(this.OffBackMenuItem_Click);
            // 
            // backColorMenuItem
            // 
            this.backColorMenuItem.Name = "backColorMenuItem";
            this.backColorMenuItem.Size = new System.Drawing.Size(199, 22);
            this.backColorMenuItem.Text = "Background Color…";
            this.backColorMenuItem.Click += new System.EventHandler(this.BackColorMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(196, 6);
            // 
            // autoSizeMenuItem
            // 
            this.autoSizeMenuItem.Checked = true;
            this.autoSizeMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoSizeMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autoSizeLargeMenuItem,
            this.autoSizeMediumMenuItem,
            this.autoSizeSmallMenuItem,
            this.toolStripSeparator2,
            this.autoSizeOffMenuItem});
            this.autoSizeMenuItem.Name = "autoSizeMenuItem";
            this.autoSizeMenuItem.Size = new System.Drawing.Size(199, 22);
            this.autoSizeMenuItem.Text = "AutoSize";
            // 
            // autoSizeLargeMenuItem
            // 
            this.autoSizeLargeMenuItem.Name = "autoSizeLargeMenuItem";
            this.autoSizeLargeMenuItem.Size = new System.Drawing.Size(119, 22);
            this.autoSizeLargeMenuItem.Text = "Large";
            this.autoSizeLargeMenuItem.Click += new System.EventHandler(this.AutoSizeLargeMenuItem_Click);
            // 
            // autoSizeMediumMenuItem
            // 
            this.autoSizeMediumMenuItem.Checked = true;
            this.autoSizeMediumMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoSizeMediumMenuItem.Name = "autoSizeMediumMenuItem";
            this.autoSizeMediumMenuItem.Size = new System.Drawing.Size(119, 22);
            this.autoSizeMediumMenuItem.Text = "Medium";
            this.autoSizeMediumMenuItem.Click += new System.EventHandler(this.AutoSizeMediumMenuItem_Click);
            // 
            // autoSizeSmallMenuItem
            // 
            this.autoSizeSmallMenuItem.Name = "autoSizeSmallMenuItem";
            this.autoSizeSmallMenuItem.Size = new System.Drawing.Size(119, 22);
            this.autoSizeSmallMenuItem.Text = "Small";
            this.autoSizeSmallMenuItem.Click += new System.EventHandler(this.AutoSizeSmallMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(116, 6);
            // 
            // autoSizeOffMenuItem
            // 
            this.autoSizeOffMenuItem.Name = "autoSizeOffMenuItem";
            this.autoSizeOffMenuItem.Size = new System.Drawing.Size(119, 22);
            this.autoSizeOffMenuItem.Text = "Off";
            this.autoSizeOffMenuItem.Click += new System.EventHandler(this.AutoSizeOffMenuItem_Click);
            // 
            // opacityMenuItem
            // 
            this.opacityMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opacity25MenuItem,
            this.opacity50MenuItem,
            this.opacity75MenuItem,
            this.opacity100MenuItem});
            this.opacityMenuItem.Name = "opacityMenuItem";
            this.opacityMenuItem.Size = new System.Drawing.Size(199, 22);
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
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(196, 6);
            // 
            // synchronizingMenuItem
            // 
            this.synchronizingMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subtitleSelectorMenuItem,
            this.toolStripSeparator6,
            this.add01SecondMenuItem,
            this.add05SecondsMenuItem,
            this.add10SecondMenuItem,
            this.toolStripSeparator7,
            this.subtract01SecondMenuItem,
            this.subtract05SecondsMenuItem,
            this.subtract10SecondMenuItem,
            this.toolStripSeparator8,
            this.resetMenuItem});
            this.synchronizingMenuItem.Name = "synchronizingMenuItem";
            this.synchronizingMenuItem.Size = new System.Drawing.Size(199, 22);
            this.synchronizingMenuItem.Text = "Synchronization";
            // 
            // subtitleSelectorMenuItem
            // 
            this.subtitleSelectorMenuItem.Name = "subtitleSelectorMenuItem";
            this.subtitleSelectorMenuItem.Size = new System.Drawing.Size(191, 22);
            this.subtitleSelectorMenuItem.Text = "Show Subtitle Selector";
            this.subtitleSelectorMenuItem.Click += new System.EventHandler(this.TextSelectorMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(188, 6);
            // 
            // add01SecondMenuItem
            // 
            this.add01SecondMenuItem.Name = "add01SecondMenuItem";
            this.add01SecondMenuItem.Size = new System.Drawing.Size(191, 22);
            this.add01SecondMenuItem.Text = "-  0.1 Seconds";
            this.add01SecondMenuItem.Click += new System.EventHandler(this.Add01SecondMenuItem_Click);
            // 
            // add05SecondsMenuItem
            // 
            this.add05SecondsMenuItem.Name = "add05SecondsMenuItem";
            this.add05SecondsMenuItem.Size = new System.Drawing.Size(191, 22);
            this.add05SecondsMenuItem.Text = "-  0.5 Seconds";
            this.add05SecondsMenuItem.Click += new System.EventHandler(this.AddSecondsMenuItem_Click);
            // 
            // add10SecondMenuItem
            // 
            this.add10SecondMenuItem.Name = "add10SecondMenuItem";
            this.add10SecondMenuItem.Size = new System.Drawing.Size(191, 22);
            this.add10SecondMenuItem.Text = "-  1.0 Second";
            this.add10SecondMenuItem.Click += new System.EventHandler(this.Add10SecondMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(188, 6);
            // 
            // subtract01SecondMenuItem
            // 
            this.subtract01SecondMenuItem.Name = "subtract01SecondMenuItem";
            this.subtract01SecondMenuItem.Size = new System.Drawing.Size(191, 22);
            this.subtract01SecondMenuItem.Text = "+ 0.1 Seconds";
            this.subtract01SecondMenuItem.Click += new System.EventHandler(this.Subtract01SecondMenuItem_Click);
            // 
            // subtract05SecondsMenuItem
            // 
            this.subtract05SecondsMenuItem.Name = "subtract05SecondsMenuItem";
            this.subtract05SecondsMenuItem.Size = new System.Drawing.Size(191, 22);
            this.subtract05SecondsMenuItem.Text = "+ 0.5 Seconds";
            this.subtract05SecondsMenuItem.Click += new System.EventHandler(this.SubtractSecondsMenuItem_Click);
            // 
            // subtract10SecondMenuItem
            // 
            this.subtract10SecondMenuItem.Name = "subtract10SecondMenuItem";
            this.subtract10SecondMenuItem.Size = new System.Drawing.Size(191, 22);
            this.subtract10SecondMenuItem.Text = "+ 1.0 Second";
            this.subtract10SecondMenuItem.Click += new System.EventHandler(this.Subtract10SecondMenuItem_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(188, 6);
            // 
            // resetMenuItem
            // 
            this.resetMenuItem.Name = "resetMenuItem";
            this.resetMenuItem.Size = new System.Drawing.Size(191, 22);
            this.resetMenuItem.Text = "Reset";
            this.resetMenuItem.Click += new System.EventHandler(this.ResetMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(196, 6);
            // 
            // restoreDefaultSettingsMenuItem
            // 
            this.restoreDefaultSettingsMenuItem.Name = "restoreDefaultSettingsMenuItem";
            this.restoreDefaultSettingsMenuItem.Size = new System.Drawing.Size(199, 22);
            this.restoreDefaultSettingsMenuItem.Text = "Restore Default Settings";
            this.restoreDefaultSettingsMenuItem.Click += new System.EventHandler(this.RestoreDefaultSettingsMenuItem_Click);
            // 
            // antiAliasMenuItem
            // 
            this.antiAliasMenuItem.Name = "antiAliasMenuItem";
            this.antiAliasMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // antiAliasGridFitMenuItem
            // 
            this.antiAliasGridFitMenuItem.Name = "antiAliasGridFitMenuItem";
            this.antiAliasGridFitMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // clearTypeGridFitMenuItem
            // 
            this.clearTypeGridFitMenuItem.Name = "clearTypeGridFitMenuItem";
            this.clearTypeGridFitMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // singleBitPerPixelMenuItem
            // 
            this.singleBitPerPixelMenuItem.Name = "singleBitPerPixelMenuItem";
            this.singleBitPerPixelMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // singleBitPerPixelGridFitMenuItem
            // 
            this.singleBitPerPixelGridFitMenuItem.Name = "singleBitPerPixelGridFitMenuItem";
            this.singleBitPerPixelGridFitMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // antiAliasSystemDefaultMenuItem
            // 
            this.antiAliasSystemDefaultMenuItem.Name = "antiAliasSystemDefaultMenuItem";
            this.antiAliasSystemDefaultMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 6);
            // 
            // noAntiAliasingMenuItem
            // 
            this.noAntiAliasingMenuItem.Name = "noAntiAliasingMenuItem";
            this.noAntiAliasingMenuItem.Size = new System.Drawing.Size(32, 19);
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
            this.optionsButton.Text = "Subtitles  ";
            this.optionsButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.optionsButton.UseVisualStyleBackColor = true;
            // 
            // subtitleListBox
            // 
            this.subtitleListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.subtitleListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.subtitleListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.subtitleListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subtitleListBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.subtitleListBox.ItemHeight = 18;
            this.subtitleListBox.Location = new System.Drawing.Point(13, 50);
            this.subtitleListBox.Name = "subtitleListBox";
            this.subtitleListBox.Size = new System.Drawing.Size(513, 306);
            this.subtitleListBox.TabIndex = 3;
            this.subtitleListBox.UseTabStops = false;
            this.subtitleListBox.Visible = false;
            // 
            // findPanel1
            // 
            this.findPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.findPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.findPanel1.Controls.Add(this.findCancelButton);
            this.findPanel1.Controls.Add(this.findSetButton);
            this.findPanel1.Location = new System.Drawing.Point(93, 12);
            this.findPanel1.Name = "findPanel1";
            this.findPanel1.Size = new System.Drawing.Size(158, 27);
            this.findPanel1.TabIndex = 4;
            this.findPanel1.Visible = false;
            // 
            // findCancelButton
            // 
            this.findCancelButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.findCancelButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.findCancelButton.Location = new System.Drawing.Point(79, 2);
            this.findCancelButton.Name = "findCancelButton";
            this.findCancelButton.Size = new System.Drawing.Size(75, 21);
            this.findCancelButton.TabIndex = 1;
            this.findCancelButton.Text = "Cancel";
            this.findCancelButton.UseVisualStyleBackColor = true;
            this.findCancelButton.Click += new System.EventHandler(this.FindCancelButton_Click);
            // 
            // findSetButton
            // 
            this.findSetButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.findSetButton.Enabled = false;
            this.findSetButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.findSetButton.Location = new System.Drawing.Point(2, 2);
            this.findSetButton.Name = "findSetButton";
            this.findSetButton.Size = new System.Drawing.Size(75, 21);
            this.findSetButton.TabIndex = 0;
            this.findSetButton.Text = "Set";
            this.findSetButton.UseVisualStyleBackColor = true;
            this.findSetButton.Click += new System.EventHandler(this.FindSetButton_Click);
            // 
            // findPanel2
            // 
            this.findPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.findPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.findPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.findPanel2.Controls.Add(this.findPanel3);
            this.findPanel2.Controls.Add(this.findButton);
            this.findPanel2.Location = new System.Drawing.Point(253, 12);
            this.findPanel2.Name = "findPanel2";
            this.findPanel2.Size = new System.Drawing.Size(274, 27);
            this.findPanel2.TabIndex = 5;
            this.findPanel2.Visible = false;
            // 
            // findPanel3
            // 
            this.findPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.findPanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.findPanel3.Controls.Add(this.findTextBox);
            this.findPanel3.Location = new System.Drawing.Point(79, 2);
            this.findPanel3.Name = "findPanel3";
            this.findPanel3.Size = new System.Drawing.Size(191, 21);
            this.findPanel3.TabIndex = 1;
            // 
            // findTextBox
            // 
            this.findTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.findTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.findTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.findTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.findTextBox.Location = new System.Drawing.Point(5, 3);
            this.findTextBox.MaxLength = 64;
            this.findTextBox.Name = "findTextBox";
            this.findTextBox.Size = new System.Drawing.Size(179, 13);
            this.findTextBox.TabIndex = 1;
            this.findTextBox.TextChanged += new System.EventHandler(this.FindTextBox_TextChanged);
            this.findTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FindTextBox_KeyPress);
            // 
            // findButton
            // 
            this.findButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.findButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.findButton.Location = new System.Drawing.Point(2, 2);
            this.findButton.Name = "findButton";
            this.findButton.Size = new System.Drawing.Size(75, 21);
            this.findButton.TabIndex = 0;
            this.findButton.Text = "Find";
            this.findButton.UseVisualStyleBackColor = true;
            this.findButton.Click += new System.EventHandler(this.FindButton_Click);
            // 
            // SubtitlesOverlay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(0)))), ((int)(((byte)(18)))));
            this.ClientSize = new System.Drawing.Size(538, 376);
            this.Controls.Add(this.findPanel2);
            this.Controls.Add(this.findPanel1);
            this.Controls.Add(this.subtitleListBox);
            this.Controls.Add(this.optionsPanel);
            this.DoubleBuffered = true;
            this.Name = "SubtitlesOverlay";
            this.Text = "SubTitlesOverlay";
            this.SizeChanged += new System.EventHandler(this.SubtitlesOverlay_SizeChanged);
            this.VisibleChanged += new System.EventHandler(this.Form1_VisibleChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.optionsMenu.ResumeLayout(false);
            this.optionsPanel.ResumeLayout(false);
            this.findPanel1.ResumeLayout(false);
            this.findPanel2.ResumeLayout(false);
            this.findPanel3.ResumeLayout(false);
            this.findPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ContextMenuStrip optionsMenu;
        private ToolStripMenuItem fontMenuItem;
        private ToolStripMenuItem textColorMenuItem;
        private ToolStripMenuItem textEncodingMenuItem;
        private Panel optionsPanel;
        private DropDownButton optionsButton;
        private ToolStripMenuItem aSCIIMenuItem;
        private ToolStripMenuItem bigEndianMenuItem;
        private ToolStripMenuItem unicodeMenuItem;
        private ToolStripMenuItem uTF32MenuItem;
        private ToolStripMenuItem uTF7MenuItem;
        private ToolStripMenuItem uTF8MenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem defaultEncodingMenuItem;
        private ToolStripMenuItem autoSizeMenuItem;
        private ToolStripMenuItem autoSizeLargeMenuItem;
        private ToolStripMenuItem autoSizeMediumMenuItem;
        private ToolStripMenuItem autoSizeSmallMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem autoSizeOffMenuItem;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem opacityMenuItem;
        private ToolStripMenuItem opacity25MenuItem;
        private ToolStripMenuItem opacity50MenuItem;
        private ToolStripMenuItem opacity75MenuItem;
        private ToolStripMenuItem opacity100MenuItem;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripMenuItem synchronizingMenuItem;
        private ToolStripMenuItem add05SecondsMenuItem;
        private ToolStripMenuItem subtract05SecondsMenuItem;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripMenuItem resetMenuItem;
        private ToolStripMenuItem add01SecondMenuItem;
        private ToolStripMenuItem add10SecondMenuItem;
        private ToolStripMenuItem subtract01SecondMenuItem;
        private ToolStripMenuItem subtract10SecondMenuItem;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripMenuItem backgroundMenuItem;
        private ListBox subtitleListBox;
        private ToolStripMenuItem subtitleSelectorMenuItem;
        private ToolStripSeparator toolStripSeparator8;
        private Panel findPanel1;
        private CustomButton findCancelButton;
        private CustomButton findSetButton;
        private Panel findPanel2;
        private TextBox findTextBox;
        private CustomButton findButton;
        private Panel findPanel3;
        private ToolStripMenuItem antiAliasMenuItem;
        private ToolStripMenuItem antiAliasGridFitMenuItem;
        private ToolStripMenuItem clearTypeGridFitMenuItem;
        private ToolStripMenuItem singleBitPerPixelMenuItem;
        private ToolStripMenuItem singleBitPerPixelGridFitMenuItem;
        private ToolStripMenuItem antiAliasSystemDefaultMenuItem;
        private ToolStripSeparator toolStripSeparator9;
        private ToolStripMenuItem noAntiAliasingMenuItem;
        private ToolStripMenuItem shadowBackMenuItem;
        private ToolStripMenuItem fillBackMenuItem;
        private ToolStripSeparator toolStripSeparator10;
        private ToolStripMenuItem offBackMenuItem;
        private ToolStripMenuItem backColorMenuItem;
        private ToolStripSeparator toolStripSeparator11;
        private ToolStripMenuItem restoreDefaultSettingsMenuItem;
        private ToolStripSeparator toolStripSeparator12;
    }
}