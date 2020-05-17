using System.ComponentModel;
using System.Windows.Forms;

namespace PVSPlayerExample
{
    partial class MessageOverlay
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
            this.messagePanel = new System.Windows.Forms.Panel();
            this.setButton = new PVSPlayerExample.CustomButton();
            this.optionsButton = new PVSPlayerExample.DropDownButton();
            this.optionsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showTextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allTextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.showCenterTextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showBottomTextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.setFont_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gradientMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rainbow1MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rainbow2MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goldMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.silverMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blackMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.gradientOffMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.outlinedMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pixels2MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pixels4MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pixels8MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pixels12MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pixels16MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pixels24MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.outlineOffMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.fixedColor_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.randomColor_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opacityMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opacity25_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opacity50_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opacity75_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opacity100_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.randomOpacity_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.invertTransparency_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textboxPanel = new System.Windows.Forms.Panel();
            this.centerTextLabel = new PVSPlayerExample.SmoothLabel();
            this.scrollingTextLabel = new PVSPlayerExample.BlendLabel();
            this.messagePanel.SuspendLayout();
            this.optionsMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // messagePanel
            // 
            this.messagePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.messagePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.messagePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.messagePanel.Controls.Add(this.setButton);
            this.messagePanel.Controls.Add(this.optionsButton);
            this.messagePanel.Controls.Add(this.textBox1);
            this.messagePanel.Controls.Add(this.textboxPanel);
            this.messagePanel.Location = new System.Drawing.Point(12, 12);
            this.messagePanel.Name = "messagePanel";
            this.messagePanel.Size = new System.Drawing.Size(588, 27);
            this.messagePanel.TabIndex = 1;
            // 
            // setButton
            // 
            this.setButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.setButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.setButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.setButton.Location = new System.Drawing.Point(436, 2);
            this.setButton.Name = "setButton";
            this.setButton.Size = new System.Drawing.Size(73, 21);
            this.setButton.TabIndex = 1;
            this.setButton.Text = "Set";
            this.setButton.UseVisualStyleBackColor = false;
            this.setButton.Click += new System.EventHandler(this.SetButton_Click);
            // 
            // optionsButton
            // 
            this.optionsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.optionsButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.optionsButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.optionsButton.DropDown = this.optionsMenu;
            this.optionsButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.optionsButton.Location = new System.Drawing.Point(511, 2);
            this.optionsButton.Name = "optionsButton";
            this.optionsButton.Size = new System.Drawing.Size(73, 21);
            this.optionsButton.TabIndex = 2;
            this.optionsButton.Text = "Options ";
            this.optionsButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.optionsButton.UseVisualStyleBackColor = true;
            // 
            // optionsMenu
            // 
            this.optionsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showTextMenuItem,
            this.toolStripSeparator2,
            this.setFont_MenuItem,
            this.gradientMenuItem,
            this.outlinedMenuItem,
            this.toolStripSeparator1,
            this.fixedColor_MenuItem,
            this.randomColor_MenuItem,
            this.opacityMenuItem,
            this.toolStripSeparator5,
            this.invertTransparency_MenuItem});
            this.optionsMenu.Name = "contextMenuStrip1";
            this.optionsMenu.Size = new System.Drawing.Size(178, 198);
            this.optionsMenu.Closed += new System.Windows.Forms.ToolStripDropDownClosedEventHandler(this.OptionsMenu_Closed);
            // 
            // showTextMenuItem
            // 
            this.showTextMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allTextMenuItem,
            this.toolStripSeparator4,
            this.showCenterTextMenuItem,
            this.showBottomTextMenuItem});
            this.showTextMenuItem.Name = "showTextMenuItem";
            this.showTextMenuItem.Size = new System.Drawing.Size(177, 22);
            this.showTextMenuItem.Text = "Show Text";
            // 
            // allTextMenuItem
            // 
            this.allTextMenuItem.Checked = true;
            this.allTextMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.allTextMenuItem.Name = "allTextMenuItem";
            this.allTextMenuItem.Size = new System.Drawing.Size(166, 22);
            this.allTextMenuItem.Text = "All Text";
            this.allTextMenuItem.Click += new System.EventHandler(this.AllTextMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(163, 6);
            // 
            // showCenterTextMenuItem
            // 
            this.showCenterTextMenuItem.Name = "showCenterTextMenuItem";
            this.showCenterTextMenuItem.Size = new System.Drawing.Size(166, 22);
            this.showCenterTextMenuItem.Text = "Center Text Only";
            this.showCenterTextMenuItem.Click += new System.EventHandler(this.ShowCenterTextMenuItem_Click);
            // 
            // showBottomTextMenuItem
            // 
            this.showBottomTextMenuItem.Name = "showBottomTextMenuItem";
            this.showBottomTextMenuItem.Size = new System.Drawing.Size(166, 22);
            this.showBottomTextMenuItem.Text = "Bottom Text Only";
            this.showBottomTextMenuItem.Click += new System.EventHandler(this.ShowBottomTextMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(174, 6);
            // 
            // setFont_MenuItem
            // 
            this.setFont_MenuItem.Name = "setFont_MenuItem";
            this.setFont_MenuItem.Size = new System.Drawing.Size(177, 22);
            this.setFont_MenuItem.Text = "Font…";
            this.setFont_MenuItem.Click += new System.EventHandler(this.SetFont_MenuItem_Click);
            // 
            // gradientMenuItem
            // 
            this.gradientMenuItem.Checked = true;
            this.gradientMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.gradientMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rainbow1MenuItem,
            this.rainbow2MenuItem,
            this.goldMenuItem,
            this.silverMenuItem,
            this.blackMenuItem,
            this.toolStripSeparator7,
            this.gradientOffMenuItem});
            this.gradientMenuItem.Name = "gradientMenuItem";
            this.gradientMenuItem.Size = new System.Drawing.Size(177, 22);
            this.gradientMenuItem.Text = "Gradient";
            // 
            // rainbow1MenuItem
            // 
            this.rainbow1MenuItem.Name = "rainbow1MenuItem";
            this.rainbow1MenuItem.Size = new System.Drawing.Size(139, 22);
            this.rainbow1MenuItem.Text = "Rainbow 1";
            this.rainbow1MenuItem.Click += new System.EventHandler(this.Rainbow1MenuItem_Click);
            // 
            // rainbow2MenuItem
            // 
            this.rainbow2MenuItem.Checked = true;
            this.rainbow2MenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.rainbow2MenuItem.Name = "rainbow2MenuItem";
            this.rainbow2MenuItem.Size = new System.Drawing.Size(139, 22);
            this.rainbow2MenuItem.Text = "Rainbow 2";
            this.rainbow2MenuItem.Click += new System.EventHandler(this.Rainbow2MenuItem_Click);
            // 
            // goldMenuItem
            // 
            this.goldMenuItem.Name = "goldMenuItem";
            this.goldMenuItem.Size = new System.Drawing.Size(139, 22);
            this.goldMenuItem.Text = "Gold";
            this.goldMenuItem.Click += new System.EventHandler(this.GoldMenuItem_Click);
            // 
            // silverMenuItem
            // 
            this.silverMenuItem.Name = "silverMenuItem";
            this.silverMenuItem.Size = new System.Drawing.Size(139, 22);
            this.silverMenuItem.Text = "Silver";
            this.silverMenuItem.Click += new System.EventHandler(this.SilverMenuItem_Click);
            // 
            // blackMenuItem
            // 
            this.blackMenuItem.Name = "blackMenuItem";
            this.blackMenuItem.Size = new System.Drawing.Size(139, 22);
            this.blackMenuItem.Text = "Black";
            this.blackMenuItem.Click += new System.EventHandler(this.BlackMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(136, 6);
            // 
            // gradientOffMenuItem
            // 
            this.gradientOffMenuItem.Name = "gradientOffMenuItem";
            this.gradientOffMenuItem.Size = new System.Drawing.Size(139, 22);
            this.gradientOffMenuItem.Text = "Gradient Off";
            this.gradientOffMenuItem.Click += new System.EventHandler(this.GradientOffMenuItem_Click);
            // 
            // outlinedMenuItem
            // 
            this.outlinedMenuItem.Checked = true;
            this.outlinedMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.outlinedMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pixels2MenuItem,
            this.pixels4MenuItem,
            this.pixels8MenuItem,
            this.pixels12MenuItem,
            this.pixels16MenuItem,
            this.pixels24MenuItem,
            this.toolStripSeparator6,
            this.outlineOffMenuItem});
            this.outlinedMenuItem.Name = "outlinedMenuItem";
            this.outlinedMenuItem.Size = new System.Drawing.Size(177, 22);
            this.outlinedMenuItem.Text = "Outline";
            // 
            // pixels2MenuItem
            // 
            this.pixels2MenuItem.Name = "pixels2MenuItem";
            this.pixels2MenuItem.Size = new System.Drawing.Size(133, 22);
            this.pixels2MenuItem.Text = "2 pixels";
            this.pixels2MenuItem.Click += new System.EventHandler(this.Pixels2MenuItem_Click);
            // 
            // pixels4MenuItem
            // 
            this.pixels4MenuItem.Checked = true;
            this.pixels4MenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.pixels4MenuItem.Name = "pixels4MenuItem";
            this.pixels4MenuItem.Size = new System.Drawing.Size(133, 22);
            this.pixels4MenuItem.Text = "4 pixels";
            this.pixels4MenuItem.Click += new System.EventHandler(this.Pixels4MenuItem_Click);
            // 
            // pixels8MenuItem
            // 
            this.pixels8MenuItem.Name = "pixels8MenuItem";
            this.pixels8MenuItem.Size = new System.Drawing.Size(133, 22);
            this.pixels8MenuItem.Text = "8 pixels";
            this.pixels8MenuItem.Click += new System.EventHandler(this.Pixels8MenuItem_Click);
            // 
            // pixels12MenuItem
            // 
            this.pixels12MenuItem.Name = "pixels12MenuItem";
            this.pixels12MenuItem.Size = new System.Drawing.Size(133, 22);
            this.pixels12MenuItem.Text = "12 pixels";
            this.pixels12MenuItem.Click += new System.EventHandler(this.Pixels12MenuItem_Click);
            // 
            // pixels16MenuItem
            // 
            this.pixels16MenuItem.Name = "pixels16MenuItem";
            this.pixels16MenuItem.Size = new System.Drawing.Size(133, 22);
            this.pixels16MenuItem.Text = "16 pixels";
            this.pixels16MenuItem.Click += new System.EventHandler(this.Pixels16MenuItem_Click);
            // 
            // pixels24MenuItem
            // 
            this.pixels24MenuItem.Name = "pixels24MenuItem";
            this.pixels24MenuItem.Size = new System.Drawing.Size(133, 22);
            this.pixels24MenuItem.Text = "24 pixels";
            this.pixels24MenuItem.Click += new System.EventHandler(this.Pixels24MenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(130, 6);
            // 
            // outlineOffMenuItem
            // 
            this.outlineOffMenuItem.Name = "outlineOffMenuItem";
            this.outlineOffMenuItem.Size = new System.Drawing.Size(133, 22);
            this.outlineOffMenuItem.Text = "Outline Off";
            this.outlineOffMenuItem.Click += new System.EventHandler(this.OutlineOffMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(174, 6);
            // 
            // fixedColor_MenuItem
            // 
            this.fixedColor_MenuItem.Name = "fixedColor_MenuItem";
            this.fixedColor_MenuItem.Size = new System.Drawing.Size(177, 22);
            this.fixedColor_MenuItem.Text = "Color…";
            this.fixedColor_MenuItem.Click += new System.EventHandler(this.FixedColor_MenuItem_Click);
            // 
            // randomColor_MenuItem
            // 
            this.randomColor_MenuItem.Checked = true;
            this.randomColor_MenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.randomColor_MenuItem.Name = "randomColor_MenuItem";
            this.randomColor_MenuItem.Size = new System.Drawing.Size(177, 22);
            this.randomColor_MenuItem.Text = "Random Color";
            this.randomColor_MenuItem.Click += new System.EventHandler(this.RandomColorMenuItem_Click);
            // 
            // opacityMenuItem
            // 
            this.opacityMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opacity25_MenuItem,
            this.opacity50_MenuItem,
            this.opacity75_MenuItem,
            this.opacity100_MenuItem,
            this.toolStripSeparator3,
            this.randomOpacity_MenuItem});
            this.opacityMenuItem.Name = "opacityMenuItem";
            this.opacityMenuItem.Size = new System.Drawing.Size(177, 22);
            this.opacityMenuItem.Text = "Opacity";
            // 
            // opacity25_MenuItem
            // 
            this.opacity25_MenuItem.Name = "opacity25_MenuItem";
            this.opacity25_MenuItem.Size = new System.Drawing.Size(119, 22);
            this.opacity25_MenuItem.Text = "  25%";
            this.opacity25_MenuItem.Click += new System.EventHandler(this.Opacity25_MenuItem_Click);
            // 
            // opacity50_MenuItem
            // 
            this.opacity50_MenuItem.Name = "opacity50_MenuItem";
            this.opacity50_MenuItem.Size = new System.Drawing.Size(119, 22);
            this.opacity50_MenuItem.Text = "  50%";
            this.opacity50_MenuItem.Click += new System.EventHandler(this.Opacity50_MenuItem_Click);
            // 
            // opacity75_MenuItem
            // 
            this.opacity75_MenuItem.Name = "opacity75_MenuItem";
            this.opacity75_MenuItem.Size = new System.Drawing.Size(119, 22);
            this.opacity75_MenuItem.Text = "  75%";
            this.opacity75_MenuItem.Click += new System.EventHandler(this.Opacity75_MenuItem_Click);
            // 
            // opacity100_MenuItem
            // 
            this.opacity100_MenuItem.Checked = true;
            this.opacity100_MenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.opacity100_MenuItem.Name = "opacity100_MenuItem";
            this.opacity100_MenuItem.Size = new System.Drawing.Size(119, 22);
            this.opacity100_MenuItem.Text = "100%";
            this.opacity100_MenuItem.Click += new System.EventHandler(this.Opacity100_MenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(116, 6);
            // 
            // randomOpacity_MenuItem
            // 
            this.randomOpacity_MenuItem.Name = "randomOpacity_MenuItem";
            this.randomOpacity_MenuItem.Size = new System.Drawing.Size(119, 22);
            this.randomOpacity_MenuItem.Text = "Random";
            this.randomOpacity_MenuItem.Click += new System.EventHandler(this.RandomOpacity_MenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(174, 6);
            // 
            // invertTransparency_MenuItem
            // 
            this.invertTransparency_MenuItem.Name = "invertTransparency_MenuItem";
            this.invertTransparency_MenuItem.Size = new System.Drawing.Size(177, 22);
            this.invertTransparency_MenuItem.Text = "Invert Transparency";
            this.invertTransparency_MenuItem.Click += new System.EventHandler(this.InvertTransparency_MenuItem_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.textBox1.Location = new System.Drawing.Point(7, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(422, 13);
            this.textBox1.TabIndex = 0;
            // 
            // textboxPanel
            // 
            this.textboxPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textboxPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.textboxPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textboxPanel.Location = new System.Drawing.Point(2, 2);
            this.textboxPanel.Name = "textboxPanel";
            this.textboxPanel.Size = new System.Drawing.Size(432, 21);
            this.textboxPanel.TabIndex = 3;
            // 
            // centerTextLabel
            // 
            this.centerTextLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.centerTextLabel.Location = new System.Drawing.Point(0, 1);
            this.centerTextLabel.Name = "centerTextLabel";
            this.centerTextLabel.Size = new System.Drawing.Size(611, 221);
            this.centerTextLabel.TabIndex = 0;
            this.centerTextLabel.Text = "centerTextLabel";
            this.centerTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.centerTextLabel.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.centerTextLabel.SizeChanged += new System.EventHandler(this.CenterTextLabel_SizeChanged);
            this.centerTextLabel.Paint += new System.Windows.Forms.PaintEventHandler(this.CenterTextLabel_Paint);
            // 
            // scrollingTextLabel
            // 
            this.scrollingTextLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.scrollingTextLabel.AutoSize = true;
            this.scrollingTextLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scrollingTextLabel.Location = new System.Drawing.Point(3, 215);
            this.scrollingTextLabel.Name = "scrollingTextLabel";
            this.scrollingTextLabel.Size = new System.Drawing.Size(233, 31);
            this.scrollingTextLabel.TabIndex = 2;
            this.scrollingTextLabel.Text = "scrollingTextLabel";
            // 
            // MessageOverlay
            // 
            this.AcceptButton = this.setButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RosyBrown;
            this.ClientSize = new System.Drawing.Size(611, 262);
            this.Controls.Add(this.messagePanel);
            this.Controls.Add(this.centerTextLabel);
            this.Controls.Add(this.scrollingTextLabel);
            this.DoubleBuffered = true;
            this.Name = "MessageOverlay";
            this.Text = "MessageOverlay";
            this.VisibleChanged += new System.EventHandler(this.Form1_VisibleChanged);
            this.messagePanel.ResumeLayout(false);
            this.messagePanel.PerformLayout();
            this.optionsMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel messagePanel;
        private TextBox textBox1;
        private ContextMenuStrip optionsMenu;
        private ToolStripMenuItem setFont_MenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem fixedColor_MenuItem;
        private ToolStripMenuItem randomColor_MenuItem;
        private ToolStripMenuItem opacityMenuItem;
        private ToolStripMenuItem opacity25_MenuItem;
        private ToolStripMenuItem opacity50_MenuItem;
        private ToolStripMenuItem opacity75_MenuItem;
        private ToolStripMenuItem opacity100_MenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem randomOpacity_MenuItem;
        private ToolStripMenuItem invertTransparency_MenuItem;
        private DropDownButton optionsButton;
        private SmoothLabel centerTextLabel;
        private ToolStripMenuItem gradientMenuItem;
        private ToolStripMenuItem rainbow1MenuItem;
        private ToolStripMenuItem rainbow2MenuItem;
        private ToolStripMenuItem goldMenuItem;
        private ToolStripMenuItem silverMenuItem;
        private ToolStripMenuItem blackMenuItem;
        private ToolStripMenuItem outlinedMenuItem;
        private ToolStripMenuItem pixels2MenuItem;
        private ToolStripMenuItem pixels4MenuItem;
        private ToolStripMenuItem pixels8MenuItem;
        private ToolStripMenuItem pixels12MenuItem;
        private ToolStripMenuItem pixels16MenuItem;
        private ToolStripMenuItem pixels24MenuItem;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripMenuItem outlineOffMenuItem;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripMenuItem gradientOffMenuItem;
        private ToolStripSeparator toolStripSeparator5;
        private CustomButton setButton;
        private ToolStripMenuItem showTextMenuItem;
        private ToolStripMenuItem showCenterTextMenuItem;
        private ToolStripMenuItem showBottomTextMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem allTextMenuItem;
        private ToolStripSeparator toolStripSeparator4;
        private Panel textboxPanel;
        private BlendLabel scrollingTextLabel;
    }
}

