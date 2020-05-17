using System.ComponentModel;
using System.Windows.Forms;

namespace PVSPlayerExample
{
    partial class Mp3CoverOverlay
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
            this.optionsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.textMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showTextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.textFontMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textColorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.coverImageMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showImageMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.coverSourceMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mp3OnlyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folderOnlyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mp3AndFolderMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.coverColorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.coverBlackWhiteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.coverGrayscaleMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.coverSepiaMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.coverInverseMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.coverNormalMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundColorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundImageMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundVideoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.restoreDefaultsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsPanel = new System.Windows.Forms.Panel();
            this.optionsButton = new PVSPlayerExample.DropDownButton();
            this.bottomLabel = new PVSPlayerExample.SmoothLabel();
            this.topLabel = new PVSPlayerExample.SmoothLabel();
            this.imageBox1 = new PVSPlayerExample.ImageBox();
            this.optionsMenu.SuspendLayout();
            this.optionsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // optionsMenu
            // 
            this.optionsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.textMenuItem,
            this.coverImageMenuItem,
            this.backgroundToolStripMenuItem,
            this.toolStripSeparator1,
            this.restoreDefaultsMenuItem});
            this.optionsMenu.Name = "optionsMenu";
            this.optionsMenu.ShowImageMargin = false;
            this.optionsMenu.Size = new System.Drawing.Size(167, 98);
            // 
            // textMenuItem
            // 
            this.textMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showTextMenuItem,
            this.toolStripSeparator3,
            this.textFontMenuItem,
            this.textColorMenuItem});
            this.textMenuItem.Name = "textMenuItem";
            this.textMenuItem.Size = new System.Drawing.Size(166, 22);
            this.textMenuItem.Text = "Title Text";
            // 
            // showTextMenuItem
            // 
            this.showTextMenuItem.Checked = true;
            this.showTextMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showTextMenuItem.Name = "showTextMenuItem";
            this.showTextMenuItem.Size = new System.Drawing.Size(136, 22);
            this.showTextMenuItem.Text = "Show Text";
            this.showTextMenuItem.Click += new System.EventHandler(this.ShowTextMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(133, 6);
            // 
            // textFontMenuItem
            // 
            this.textFontMenuItem.Name = "textFontMenuItem";
            this.textFontMenuItem.Size = new System.Drawing.Size(136, 22);
            this.textFontMenuItem.Text = "Text Font…";
            this.textFontMenuItem.Click += new System.EventHandler(this.TextFontMenuItem_Click);
            // 
            // textColorMenuItem
            // 
            this.textColorMenuItem.Name = "textColorMenuItem";
            this.textColorMenuItem.Size = new System.Drawing.Size(136, 22);
            this.textColorMenuItem.Text = "Text Color…";
            this.textColorMenuItem.Click += new System.EventHandler(this.TextColorMenuItem_Click);
            // 
            // coverImageMenuItem
            // 
            this.coverImageMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showImageMenuItem,
            this.toolStripSeparator2,
            this.coverSourceMenuItem,
            this.coverColorMenuItem});
            this.coverImageMenuItem.Name = "coverImageMenuItem";
            this.coverImageMenuItem.Size = new System.Drawing.Size(166, 22);
            this.coverImageMenuItem.Text = "Cover Image";
            // 
            // showImageMenuItem
            // 
            this.showImageMenuItem.Checked = true;
            this.showImageMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showImageMenuItem.Name = "showImageMenuItem";
            this.showImageMenuItem.Size = new System.Drawing.Size(146, 22);
            this.showImageMenuItem.Text = "Show Image";
            this.showImageMenuItem.Click += new System.EventHandler(this.ShowImageMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(143, 6);
            // 
            // coverSourceMenuItem
            // 
            this.coverSourceMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mp3OnlyMenuItem,
            this.folderOnlyMenuItem,
            this.mp3AndFolderMenuItem});
            this.coverSourceMenuItem.Name = "coverSourceMenuItem";
            this.coverSourceMenuItem.Size = new System.Drawing.Size(146, 22);
            this.coverSourceMenuItem.Text = "Image Source";
            // 
            // mp3OnlyMenuItem
            // 
            this.mp3OnlyMenuItem.Name = "mp3OnlyMenuItem";
            this.mp3OnlyMenuItem.Size = new System.Drawing.Size(142, 22);
            this.mp3OnlyMenuItem.Text = "File Only";
            this.mp3OnlyMenuItem.Click += new System.EventHandler(this.Mp3OnlyMenuItem_Click);
            // 
            // folderOnlyMenuItem
            // 
            this.folderOnlyMenuItem.Name = "folderOnlyMenuItem";
            this.folderOnlyMenuItem.Size = new System.Drawing.Size(142, 22);
            this.folderOnlyMenuItem.Text = "Folder Only";
            this.folderOnlyMenuItem.Click += new System.EventHandler(this.FolderOnlyMenuItem_Click);
            // 
            // mp3AndFolderMenuItem
            // 
            this.mp3AndFolderMenuItem.Checked = true;
            this.mp3AndFolderMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mp3AndFolderMenuItem.Name = "mp3AndFolderMenuItem";
            this.mp3AndFolderMenuItem.Size = new System.Drawing.Size(142, 22);
            this.mp3AndFolderMenuItem.Text = "File or Folder";
            this.mp3AndFolderMenuItem.Click += new System.EventHandler(this.Mp3AndFolderMenuItem_Click);
            // 
            // coverColorMenuItem
            // 
            this.coverColorMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.coverBlackWhiteMenuItem,
            this.coverGrayscaleMenuItem,
            this.coverSepiaMenuItem,
            this.coverInverseMenuItem,
            this.toolStripSeparator5,
            this.coverNormalMenuItem});
            this.coverColorMenuItem.Name = "coverColorMenuItem";
            this.coverColorMenuItem.Size = new System.Drawing.Size(146, 22);
            this.coverColorMenuItem.Text = "Image Color";
            // 
            // coverBlackWhiteMenuItem
            // 
            this.coverBlackWhiteMenuItem.Name = "coverBlackWhiteMenuItem";
            this.coverBlackWhiteMenuItem.Size = new System.Drawing.Size(159, 22);
            this.coverBlackWhiteMenuItem.Text = "Black and White";
            this.coverBlackWhiteMenuItem.Click += new System.EventHandler(this.CoverBlackWhiteMenuItem_Click);
            // 
            // coverGrayscaleMenuItem
            // 
            this.coverGrayscaleMenuItem.Name = "coverGrayscaleMenuItem";
            this.coverGrayscaleMenuItem.Size = new System.Drawing.Size(159, 22);
            this.coverGrayscaleMenuItem.Text = "GrayScale";
            this.coverGrayscaleMenuItem.Click += new System.EventHandler(this.CoverImageGrayScaleMenuItem_Click);
            // 
            // coverSepiaMenuItem
            // 
            this.coverSepiaMenuItem.Name = "coverSepiaMenuItem";
            this.coverSepiaMenuItem.Size = new System.Drawing.Size(159, 22);
            this.coverSepiaMenuItem.Text = "Sepia";
            this.coverSepiaMenuItem.Click += new System.EventHandler(this.CoverImageSepiaMenuItem_Click);
            // 
            // coverInverseMenuItem
            // 
            this.coverInverseMenuItem.Name = "coverInverseMenuItem";
            this.coverInverseMenuItem.Size = new System.Drawing.Size(159, 22);
            this.coverInverseMenuItem.Text = "Inverse";
            this.coverInverseMenuItem.Click += new System.EventHandler(this.CoverImageInverseMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(156, 6);
            // 
            // coverNormalMenuItem
            // 
            this.coverNormalMenuItem.Checked = true;
            this.coverNormalMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.coverNormalMenuItem.Name = "coverNormalMenuItem";
            this.coverNormalMenuItem.Size = new System.Drawing.Size(159, 22);
            this.coverNormalMenuItem.Text = "Normal";
            this.coverNormalMenuItem.Click += new System.EventHandler(this.CoverImageNormalMenuItem_Click);
            // 
            // backgroundToolStripMenuItem
            // 
            this.backgroundToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backgroundColorMenuItem,
            this.backgroundImageMenuItem,
            this.backgroundVideoMenuItem});
            this.backgroundToolStripMenuItem.Name = "backgroundToolStripMenuItem";
            this.backgroundToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.backgroundToolStripMenuItem.Text = "Background";
            // 
            // backgroundColorMenuItem
            // 
            this.backgroundColorMenuItem.Checked = true;
            this.backgroundColorMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.backgroundColorMenuItem.Name = "backgroundColorMenuItem";
            this.backgroundColorMenuItem.Size = new System.Drawing.Size(183, 22);
            this.backgroundColorMenuItem.Text = "Background Color…";
            this.backgroundColorMenuItem.Click += new System.EventHandler(this.BackgroundColorMenuItem_Click);
            // 
            // backgroundImageMenuItem
            // 
            this.backgroundImageMenuItem.Name = "backgroundImageMenuItem";
            this.backgroundImageMenuItem.Size = new System.Drawing.Size(183, 22);
            this.backgroundImageMenuItem.Text = "Background Image…";
            this.backgroundImageMenuItem.Click += new System.EventHandler(this.BackgroundImageMenuItem_Click);
            // 
            // backgroundVideoMenuItem
            // 
            this.backgroundVideoMenuItem.Name = "backgroundVideoMenuItem";
            this.backgroundVideoMenuItem.Size = new System.Drawing.Size(183, 22);
            this.backgroundVideoMenuItem.Text = "Background Video…";
            this.backgroundVideoMenuItem.Click += new System.EventHandler(this.BackgroundVideoMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(163, 6);
            // 
            // restoreDefaultsMenuItem
            // 
            this.restoreDefaultsMenuItem.Name = "restoreDefaultsMenuItem";
            this.restoreDefaultsMenuItem.Size = new System.Drawing.Size(166, 22);
            this.restoreDefaultsMenuItem.Text = "Restore Default Colors";
            this.restoreDefaultsMenuItem.Click += new System.EventHandler(this.RestoreDefaultsMenuItem_Click);
            // 
            // optionsPanel
            // 
            this.optionsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.optionsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.optionsPanel.Controls.Add(this.optionsButton);
            this.optionsPanel.Location = new System.Drawing.Point(12, 12);
            this.optionsPanel.Name = "optionsPanel";
            this.optionsPanel.Size = new System.Drawing.Size(79, 27);
            this.optionsPanel.TabIndex = 4;
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
            this.optionsButton.UseVisualStyleBackColor = true;
            // 
            // bottomLabel
            // 
            this.bottomLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bottomLabel.AutoEllipsis = true;
            this.bottomLabel.BackColor = System.Drawing.Color.Transparent;
            this.bottomLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bottomLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.bottomLabel.Location = new System.Drawing.Point(12, 189);
            this.bottomLabel.Name = "bottomLabel";
            this.bottomLabel.Size = new System.Drawing.Size(452, 152);
            this.bottomLabel.TabIndex = 2;
            this.bottomLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bottomLabel.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.bottomLabel.UseMnemonic = false;
            // 
            // topLabel
            // 
            this.topLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.topLabel.AutoEllipsis = true;
            this.topLabel.BackColor = System.Drawing.Color.Transparent;
            this.topLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.topLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.topLabel.Location = new System.Drawing.Point(12, 16);
            this.topLabel.Name = "topLabel";
            this.topLabel.Size = new System.Drawing.Size(452, 153);
            this.topLabel.TabIndex = 0;
            this.topLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.topLabel.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.topLabel.UseMnemonic = false;
            // 
            // imageBox1
            // 
            this.imageBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imageBox1.BackColor = System.Drawing.Color.Transparent;
            this.imageBox1.Location = new System.Drawing.Point(12, 56);
            this.imageBox1.Name = "imageBox1";
            this.imageBox1.Size = new System.Drawing.Size(452, 242);
            this.imageBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imageBox1.TabIndex = 1;
            this.imageBox1.TabStop = false;
            // 
            // Mp3CoverOverlay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(476, 354);
            this.Controls.Add(this.imageBox1);
            this.Controls.Add(this.optionsPanel);
            this.Controls.Add(this.bottomLabel);
            this.Controls.Add(this.topLabel);
            this.DoubleBuffered = true;
            this.Name = "Mp3CoverOverlay";
            this.Text = "MP3CoverOverlay";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.VisibleChanged += new System.EventHandler(this.MP3CoverOverlay_VisibleChanged);
            this.optionsMenu.ResumeLayout(false);
            this.optionsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SmoothLabel topLabel;
        private ImageBox imageBox1;
        private SmoothLabel bottomLabel;
        private ContextMenuStrip optionsMenu;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem restoreDefaultsMenuItem;
        private Panel optionsPanel;
        private DropDownButton optionsButton;
        private ToolStripMenuItem textMenuItem;
        private ToolStripMenuItem coverImageMenuItem;
        private ToolStripMenuItem coverSourceMenuItem;
        private ToolStripMenuItem mp3AndFolderMenuItem;
        private ToolStripMenuItem coverColorMenuItem;
        private ToolStripMenuItem coverBlackWhiteMenuItem;
        private ToolStripMenuItem coverGrayscaleMenuItem;
        private ToolStripMenuItem coverSepiaMenuItem;
        private ToolStripMenuItem coverInverseMenuItem;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripMenuItem coverNormalMenuItem;
        private ToolStripMenuItem backgroundToolStripMenuItem;
        private ToolStripMenuItem backgroundColorMenuItem;
        private ToolStripMenuItem backgroundVideoMenuItem;
        private ToolStripMenuItem backgroundImageMenuItem;
        private ToolStripMenuItem folderOnlyMenuItem;
        private ToolStripMenuItem textColorMenuItem;
        private ToolStripMenuItem textFontMenuItem;
        private ToolStripMenuItem showTextMenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem showImageMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem mp3OnlyMenuItem;
    }
}