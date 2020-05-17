using System.ComponentModel;
using System.Windows.Forms;

namespace PVSPlayerExample
{
    partial class BouncingOverlay
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
            this.bouncingPanel = new System.Windows.Forms.Panel();
            this.setButton = new PVSPlayerExample.CustomButton();
            this.optionsButton = new PVSPlayerExample.DropDownButton();
            this.optionsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.bubbleShapeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.roundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.squareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.diamondToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.starToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bubbleSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.overlaySize3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.overlaySize4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.overlaySize5ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.overlaySizeBubblesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.backColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opacityMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.opacity50MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opacity75MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opacity100MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.invertTransparancyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.pongToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startPongMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.slowPongMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.normalPongMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fastPongMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fasterPongMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.bouncingPanel.SuspendLayout();
            this.optionsMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // bouncingPanel
            // 
            this.bouncingPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.bouncingPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bouncingPanel.Controls.Add(this.setButton);
            this.bouncingPanel.Controls.Add(this.optionsButton);
            this.bouncingPanel.Controls.Add(this.numericUpDown1);
            this.bouncingPanel.Location = new System.Drawing.Point(12, 12);
            this.bouncingPanel.Name = "bouncingPanel";
            this.bouncingPanel.Size = new System.Drawing.Size(228, 27);
            this.bouncingPanel.TabIndex = 0;
            // 
            // setButton
            // 
            this.setButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.setButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.setButton.Location = new System.Drawing.Point(76, 2);
            this.setButton.Name = "setButton";
            this.setButton.Size = new System.Drawing.Size(73, 21);
            this.setButton.TabIndex = 1;
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
            this.optionsButton.Location = new System.Drawing.Point(151, 2);
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
            this.bubbleShapeToolStripMenuItem,
            this.bubbleSizeToolStripMenuItem,
            this.toolStripSeparator1,
            this.backColorToolStripMenuItem,
            this.opacityMenuItem,
            this.toolStripSeparator3,
            this.invertTransparancyToolStripMenuItem,
            this.toolStripSeparator4,
            this.pongToolStripMenuItem});
            this.optionsMenu.Name = "contextMenuStrip1";
            this.optionsMenu.ShowImageMargin = false;
            this.optionsMenu.Size = new System.Drawing.Size(153, 154);
            this.optionsMenu.Closed += new System.Windows.Forms.ToolStripDropDownClosedEventHandler(this.ContextMenuStrip1_Closed);
            // 
            // bubbleShapeToolStripMenuItem
            // 
            this.bubbleShapeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.roundToolStripMenuItem,
            this.squareToolStripMenuItem,
            this.diamondToolStripMenuItem,
            this.starToolStripMenuItem});
            this.bubbleShapeToolStripMenuItem.Name = "bubbleShapeToolStripMenuItem";
            this.bubbleShapeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.bubbleShapeToolStripMenuItem.Text = "Shape";
            // 
            // roundToolStripMenuItem
            // 
            this.roundToolStripMenuItem.Checked = true;
            this.roundToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.roundToolStripMenuItem.Name = "roundToolStripMenuItem";
            this.roundToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.roundToolStripMenuItem.Text = "Round";
            this.roundToolStripMenuItem.Click += new System.EventHandler(this.RoundToolStripMenuItem_Click);
            // 
            // squareToolStripMenuItem
            // 
            this.squareToolStripMenuItem.Name = "squareToolStripMenuItem";
            this.squareToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.squareToolStripMenuItem.Text = "Square";
            this.squareToolStripMenuItem.Click += new System.EventHandler(this.SquareToolStripMenuItem_Click);
            // 
            // diamondToolStripMenuItem
            // 
            this.diamondToolStripMenuItem.Name = "diamondToolStripMenuItem";
            this.diamondToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.diamondToolStripMenuItem.Text = "Diamond";
            this.diamondToolStripMenuItem.Click += new System.EventHandler(this.DiamondToolStripMenuItem_Click);
            // 
            // starToolStripMenuItem
            // 
            this.starToolStripMenuItem.Name = "starToolStripMenuItem";
            this.starToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.starToolStripMenuItem.Text = "Star";
            this.starToolStripMenuItem.Click += new System.EventHandler(this.StarToolStripMenuItem_Click);
            // 
            // bubbleSizeToolStripMenuItem
            // 
            this.bubbleSizeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.overlaySize3ToolStripMenuItem,
            this.overlaySize4ToolStripMenuItem,
            this.overlaySize5ToolStripMenuItem,
            this.toolStripSeparator2,
            this.overlaySizeBubblesToolStripMenuItem});
            this.bubbleSizeToolStripMenuItem.Name = "bubbleSizeToolStripMenuItem";
            this.bubbleSizeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.bubbleSizeToolStripMenuItem.Text = "Shape Size";
            // 
            // overlaySize3ToolStripMenuItem
            // 
            this.overlaySize3ToolStripMenuItem.Checked = true;
            this.overlaySize3ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.overlaySize3ToolStripMenuItem.Name = "overlaySize3ToolStripMenuItem";
            this.overlaySize3ToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.overlaySize3ToolStripMenuItem.Text = "OverlaySize/3";
            this.overlaySize3ToolStripMenuItem.Click += new System.EventHandler(this.OverlaySize3ToolStripMenuItem_Click);
            // 
            // overlaySize4ToolStripMenuItem
            // 
            this.overlaySize4ToolStripMenuItem.Name = "overlaySize4ToolStripMenuItem";
            this.overlaySize4ToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.overlaySize4ToolStripMenuItem.Text = "OverlaySize/4";
            this.overlaySize4ToolStripMenuItem.Click += new System.EventHandler(this.OverlaySize4ToolStripMenuItem_Click);
            // 
            // overlaySize5ToolStripMenuItem
            // 
            this.overlaySize5ToolStripMenuItem.Name = "overlaySize5ToolStripMenuItem";
            this.overlaySize5ToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.overlaySize5ToolStripMenuItem.Text = "OverlaySize/5";
            this.overlaySize5ToolStripMenuItem.Click += new System.EventHandler(this.OverlaySize5ToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(173, 6);
            // 
            // overlaySizeBubblesToolStripMenuItem
            // 
            this.overlaySizeBubblesToolStripMenuItem.Name = "overlaySizeBubblesToolStripMenuItem";
            this.overlaySizeBubblesToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.overlaySizeBubblesToolStripMenuItem.Text = "OverlaySize/Shapes";
            this.overlaySizeBubblesToolStripMenuItem.Click += new System.EventHandler(this.OverlaySizeBubblesToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // backColorToolStripMenuItem
            // 
            this.backColorToolStripMenuItem.Name = "backColorToolStripMenuItem";
            this.backColorToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.backColorToolStripMenuItem.Text = "Color…";
            this.backColorToolStripMenuItem.Click += new System.EventHandler(this.BackColorToolStripMenuItem_Click);
            // 
            // opacityMenuItem
            // 
            this.opacityMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem8,
            this.opacity50MenuItem,
            this.opacity75MenuItem,
            this.opacity100MenuItem});
            this.opacityMenuItem.Name = "opacityMenuItem";
            this.opacityMenuItem.Size = new System.Drawing.Size(152, 22);
            this.opacityMenuItem.Text = "Opacity";
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(102, 22);
            this.toolStripMenuItem8.Text = "  25%";
            this.toolStripMenuItem8.Click += new System.EventHandler(this.HandleToolStripOpacity);
            // 
            // opacity50MenuItem
            // 
            this.opacity50MenuItem.Name = "opacity50MenuItem";
            this.opacity50MenuItem.Size = new System.Drawing.Size(102, 22);
            this.opacity50MenuItem.Text = "  50%";
            this.opacity50MenuItem.Click += new System.EventHandler(this.HandleToolStripOpacity);
            // 
            // opacity75MenuItem
            // 
            this.opacity75MenuItem.Name = "opacity75MenuItem";
            this.opacity75MenuItem.Size = new System.Drawing.Size(102, 22);
            this.opacity75MenuItem.Text = "  75%";
            this.opacity75MenuItem.Click += new System.EventHandler(this.HandleToolStripOpacity);
            // 
            // opacity100MenuItem
            // 
            this.opacity100MenuItem.Checked = true;
            this.opacity100MenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.opacity100MenuItem.Name = "opacity100MenuItem";
            this.opacity100MenuItem.Size = new System.Drawing.Size(102, 22);
            this.opacity100MenuItem.Text = "100%";
            this.opacity100MenuItem.Click += new System.EventHandler(this.HandleToolStripOpacity);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(149, 6);
            // 
            // invertTransparancyToolStripMenuItem
            // 
            this.invertTransparancyToolStripMenuItem.Name = "invertTransparancyToolStripMenuItem";
            this.invertTransparancyToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.invertTransparancyToolStripMenuItem.Text = "Invert Transparency";
            this.invertTransparancyToolStripMenuItem.Click += new System.EventHandler(this.InvertTransparencyToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(149, 6);
            // 
            // pongToolStripMenuItem
            // 
            this.pongToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startPongMenuItem,
            this.toolStripSeparator5,
            this.slowPongMenuItem,
            this.normalPongMenuItem,
            this.fastPongMenuItem,
            this.fasterPongMenuItem});
            this.pongToolStripMenuItem.Name = "pongToolStripMenuItem";
            this.pongToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.pongToolStripMenuItem.Text = "Pong Game";
            // 
            // startPongMenuItem
            // 
            this.startPongMenuItem.Name = "startPongMenuItem";
            this.startPongMenuItem.Size = new System.Drawing.Size(129, 22);
            this.startPongMenuItem.Text = "Start Pong";
            this.startPongMenuItem.Click += new System.EventHandler(this.StartPongMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(126, 6);
            // 
            // slowPongMenuItem
            // 
            this.slowPongMenuItem.Name = "slowPongMenuItem";
            this.slowPongMenuItem.Size = new System.Drawing.Size(129, 22);
            this.slowPongMenuItem.Text = "Slow";
            this.slowPongMenuItem.Click += new System.EventHandler(this.SlowPongMenuItem_Click);
            // 
            // normalPongMenuItem
            // 
            this.normalPongMenuItem.Checked = true;
            this.normalPongMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.normalPongMenuItem.Name = "normalPongMenuItem";
            this.normalPongMenuItem.Size = new System.Drawing.Size(129, 22);
            this.normalPongMenuItem.Text = "Normal";
            this.normalPongMenuItem.Click += new System.EventHandler(this.NormalPongMenuItem_Click);
            // 
            // fastPongMenuItem
            // 
            this.fastPongMenuItem.Name = "fastPongMenuItem";
            this.fastPongMenuItem.Size = new System.Drawing.Size(129, 22);
            this.fastPongMenuItem.Text = "Fast";
            this.fastPongMenuItem.Click += new System.EventHandler(this.FastPongMenuItem_Click);
            // 
            // fasterPongMenuItem
            // 
            this.fasterPongMenuItem.Name = "fasterPongMenuItem";
            this.fasterPongMenuItem.Size = new System.Drawing.Size(129, 22);
            this.fasterPongMenuItem.Text = "Faster";
            this.fasterPongMenuItem.Click += new System.EventHandler(this.FasterPongMenuItem_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.numericUpDown1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDown1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.numericUpDown1.Location = new System.Drawing.Point(2, 2);
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(72, 21);
            this.numericUpDown1.TabIndex = 0;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // BouncingOverlay
            // 
            this.AcceptButton = this.setButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.ClientSize = new System.Drawing.Size(503, 380);
            this.Controls.Add(this.bouncingPanel);
            this.Name = "BouncingOverlay";
            this.Text = "BouncingOverlay";
            this.TransparencyKey = System.Drawing.Color.RosyBrown;
            this.VisibleChanged += new System.EventHandler(this.Form1_VisibleChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.bouncingPanel.ResumeLayout(false);
            this.optionsMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel bouncingPanel;
        private NumericUpDown numericUpDown1;
        private ContextMenuStrip optionsMenu;
        private ToolStripMenuItem bubbleSizeToolStripMenuItem;
        private ToolStripMenuItem overlaySize3ToolStripMenuItem;
        private ToolStripMenuItem overlaySize4ToolStripMenuItem;
        private ToolStripMenuItem overlaySize5ToolStripMenuItem;
        private ToolStripMenuItem overlaySizeBubblesToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem backColorToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem opacityMenuItem;
        private ToolStripMenuItem opacity50MenuItem;
        private ToolStripMenuItem opacity75MenuItem;
        private ToolStripMenuItem opacity100MenuItem;
        private ToolStripMenuItem toolStripMenuItem8;
        private ToolStripMenuItem bubbleShapeToolStripMenuItem;
        private ToolStripMenuItem roundToolStripMenuItem;
        private ToolStripMenuItem squareToolStripMenuItem;
        private ToolStripMenuItem diamondToolStripMenuItem;
        private ToolStripMenuItem starToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem invertTransparancyToolStripMenuItem;
        private DropDownButton optionsButton;
        private CustomButton setButton;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem pongToolStripMenuItem;
        private ToolStripMenuItem startPongMenuItem;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripMenuItem slowPongMenuItem;
        private ToolStripMenuItem normalPongMenuItem;
        private ToolStripMenuItem fastPongMenuItem;
        private ToolStripMenuItem fasterPongMenuItem;
    }
}

