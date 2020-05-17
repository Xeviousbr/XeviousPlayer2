using System.ComponentModel;
using System.Windows.Forms;

namespace PVSPlayerExample
{
    partial class ScribbleOverlay
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
            this.scribblePanel = new System.Windows.Forms.Panel();
            this.clearButton = new PVSPlayerExample.CustomButton();
            this.optionsButton = new PVSPlayerExample.DropDownButton();
            this.optionsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.scribbleMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawLineMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawArrowMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawEllipseMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawRectangleMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.lineColorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lineThicknessMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pixel1_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pixels2_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pixels4_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pixels8_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pixels16_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pixels24_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pixels32_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pixels40_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pixels48_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pixels56_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pixels64_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.opacityMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opacity25_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opacity50_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opacity75_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opacity100_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.autoScaleMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.drawCircleMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scribblePanel.SuspendLayout();
            this.optionsMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // scribblePanel
            // 
            this.scribblePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.scribblePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.scribblePanel.Controls.Add(this.clearButton);
            this.scribblePanel.Controls.Add(this.optionsButton);
            this.scribblePanel.Controls.Add(this.panel7);
            this.scribblePanel.Controls.Add(this.panel1);
            this.scribblePanel.Controls.Add(this.panel6);
            this.scribblePanel.Controls.Add(this.panel2);
            this.scribblePanel.Controls.Add(this.panel5);
            this.scribblePanel.Controls.Add(this.panel3);
            this.scribblePanel.Controls.Add(this.panel4);
            this.scribblePanel.Location = new System.Drawing.Point(12, 12);
            this.scribblePanel.Name = "scribblePanel";
            this.scribblePanel.Size = new System.Drawing.Size(323, 27);
            this.scribblePanel.TabIndex = 0;
            // 
            // clearButton
            // 
            this.clearButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.clearButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.clearButton.Location = new System.Drawing.Point(2, 2);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(73, 21);
            this.clearButton.TabIndex = 0;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // optionsButton
            // 
            this.optionsButton.Appearance = System.Windows.Forms.Appearance.Button;
            this.optionsButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.optionsButton.DropDown = this.optionsMenu;
            this.optionsButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.optionsButton.Location = new System.Drawing.Point(246, 2);
            this.optionsButton.Name = "optionsButton";
            this.optionsButton.Size = new System.Drawing.Size(73, 21);
            this.optionsButton.TabIndex = 8;
            this.optionsButton.Text = "Options ";
            this.optionsButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.optionsButton.UseVisualStyleBackColor = true;
            // 
            // optionsMenu
            // 
            this.optionsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scribbleMenuItem,
            this.drawLineMenuItem,
            this.drawArrowMenuItem,
            this.drawCircleMenuItem,
            this.drawEllipseMenuItem,
            this.drawRectangleMenuItem,
            this.toolStripSeparator1,
            this.lineColorMenuItem,
            this.lineThicknessMenuItem,
            this.toolStripSeparator3,
            this.opacityMenuItem,
            this.toolStripSeparator2,
            this.autoScaleMenuItem});
            this.optionsMenu.Name = "contextMenuStrip1";
            this.optionsMenu.Size = new System.Drawing.Size(181, 264);
            this.optionsMenu.Closing += new System.Windows.Forms.ToolStripDropDownClosingEventHandler(this.OptionsMenu_Closing);
            this.optionsMenu.Opening += new System.ComponentModel.CancelEventHandler(this.OptionsMenu_Opening);
            // 
            // scribbleMenuItem
            // 
            this.scribbleMenuItem.Checked = true;
            this.scribbleMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.scribbleMenuItem.Name = "scribbleMenuItem";
            this.scribbleMenuItem.ShortcutKeyDisplayString = "S";
            this.scribbleMenuItem.Size = new System.Drawing.Size(180, 22);
            this.scribbleMenuItem.Text = "Scribble";
            this.scribbleMenuItem.Click += new System.EventHandler(this.ScribbleMenuItem_Click);
            // 
            // drawLineMenuItem
            // 
            this.drawLineMenuItem.Name = "drawLineMenuItem";
            this.drawLineMenuItem.ShortcutKeyDisplayString = "L";
            this.drawLineMenuItem.Size = new System.Drawing.Size(180, 22);
            this.drawLineMenuItem.Text = "Draw Lines";
            this.drawLineMenuItem.Click += new System.EventHandler(this.DrawLineMenuItem_Click);
            // 
            // drawArrowMenuItem
            // 
            this.drawArrowMenuItem.Name = "drawArrowMenuItem";
            this.drawArrowMenuItem.ShortcutKeyDisplayString = "A";
            this.drawArrowMenuItem.Size = new System.Drawing.Size(180, 22);
            this.drawArrowMenuItem.Text = "Draw Arrows";
            this.drawArrowMenuItem.Click += new System.EventHandler(this.DrawArrowMenuItem_Click);
            // 
            // drawEllipseMenuItem
            // 
            this.drawEllipseMenuItem.Name = "drawEllipseMenuItem";
            this.drawEllipseMenuItem.ShortcutKeyDisplayString = "E";
            this.drawEllipseMenuItem.Size = new System.Drawing.Size(180, 22);
            this.drawEllipseMenuItem.Text = "Draw Ellipses";
            this.drawEllipseMenuItem.Click += new System.EventHandler(this.DrawEllipseMenuItem_Click);
            // 
            // drawRectangleMenuItem
            // 
            this.drawRectangleMenuItem.Name = "drawRectangleMenuItem";
            this.drawRectangleMenuItem.ShortcutKeyDisplayString = "R";
            this.drawRectangleMenuItem.Size = new System.Drawing.Size(180, 22);
            this.drawRectangleMenuItem.Text = "Draw Rectangles";
            this.drawRectangleMenuItem.Click += new System.EventHandler(this.DrawRectangleMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // lineColorMenuItem
            // 
            this.lineColorMenuItem.Name = "lineColorMenuItem";
            this.lineColorMenuItem.Size = new System.Drawing.Size(180, 22);
            this.lineColorMenuItem.Text = "Line Color…";
            this.lineColorMenuItem.Click += new System.EventHandler(this.LineColorMenuItem_Click);
            // 
            // lineThicknessMenuItem
            // 
            this.lineThicknessMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pixel1_MenuItem,
            this.pixels2_MenuItem,
            this.pixels4_MenuItem,
            this.pixels8_MenuItem,
            this.pixels16_MenuItem,
            this.pixels24_MenuItem,
            this.pixels32_MenuItem,
            this.pixels40_MenuItem,
            this.pixels48_MenuItem,
            this.pixels56_MenuItem,
            this.pixels64_MenuItem});
            this.lineThicknessMenuItem.Name = "lineThicknessMenuItem";
            this.lineThicknessMenuItem.Size = new System.Drawing.Size(180, 22);
            this.lineThicknessMenuItem.Text = "Line Thickness";
            // 
            // pixel1_MenuItem
            // 
            this.pixel1_MenuItem.Name = "pixel1_MenuItem";
            this.pixel1_MenuItem.ShortcutKeyDisplayString = "+/-";
            this.pixel1_MenuItem.Size = new System.Drawing.Size(144, 22);
            this.pixel1_MenuItem.Text = "  1 pixel";
            this.pixel1_MenuItem.Click += new System.EventHandler(this.Pixel1_MenuItem_Click);
            // 
            // pixels2_MenuItem
            // 
            this.pixels2_MenuItem.Checked = true;
            this.pixels2_MenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.pixels2_MenuItem.Name = "pixels2_MenuItem";
            this.pixels2_MenuItem.ShortcutKeyDisplayString = "+/-";
            this.pixels2_MenuItem.Size = new System.Drawing.Size(144, 22);
            this.pixels2_MenuItem.Text = "  2 pixels";
            this.pixels2_MenuItem.Click += new System.EventHandler(this.Pixels2_MenuItem_Click);
            // 
            // pixels4_MenuItem
            // 
            this.pixels4_MenuItem.Name = "pixels4_MenuItem";
            this.pixels4_MenuItem.ShortcutKeyDisplayString = "+/-";
            this.pixels4_MenuItem.Size = new System.Drawing.Size(144, 22);
            this.pixels4_MenuItem.Text = "  4 pixels";
            this.pixels4_MenuItem.Click += new System.EventHandler(this.Pixels4_MenuItem_Click);
            // 
            // pixels8_MenuItem
            // 
            this.pixels8_MenuItem.Name = "pixels8_MenuItem";
            this.pixels8_MenuItem.ShortcutKeyDisplayString = "+/-";
            this.pixels8_MenuItem.Size = new System.Drawing.Size(144, 22);
            this.pixels8_MenuItem.Text = "  8 pixels";
            this.pixels8_MenuItem.Click += new System.EventHandler(this.Pixels8_MenuItem_Click);
            // 
            // pixels16_MenuItem
            // 
            this.pixels16_MenuItem.Name = "pixels16_MenuItem";
            this.pixels16_MenuItem.ShortcutKeyDisplayString = "+/-";
            this.pixels16_MenuItem.Size = new System.Drawing.Size(144, 22);
            this.pixels16_MenuItem.Text = "16 pixels";
            this.pixels16_MenuItem.Click += new System.EventHandler(this.Pixels16_MenuItem_Click);
            // 
            // pixels24_MenuItem
            // 
            this.pixels24_MenuItem.Name = "pixels24_MenuItem";
            this.pixels24_MenuItem.ShortcutKeyDisplayString = "+/-";
            this.pixels24_MenuItem.Size = new System.Drawing.Size(144, 22);
            this.pixels24_MenuItem.Text = "24 pixels";
            this.pixels24_MenuItem.Click += new System.EventHandler(this.Pixels24_MenuItem_Click);
            // 
            // pixels32_MenuItem
            // 
            this.pixels32_MenuItem.Name = "pixels32_MenuItem";
            this.pixels32_MenuItem.ShortcutKeyDisplayString = "+/-";
            this.pixels32_MenuItem.Size = new System.Drawing.Size(144, 22);
            this.pixels32_MenuItem.Text = "32 pixels";
            this.pixels32_MenuItem.Click += new System.EventHandler(this.Pixels32_MenuItem_Click);
            // 
            // pixels40_MenuItem
            // 
            this.pixels40_MenuItem.Name = "pixels40_MenuItem";
            this.pixels40_MenuItem.ShortcutKeyDisplayString = "+/-";
            this.pixels40_MenuItem.Size = new System.Drawing.Size(144, 22);
            this.pixels40_MenuItem.Text = "40 pixels";
            this.pixels40_MenuItem.Click += new System.EventHandler(this.Pixels40_MenuItem_Click);
            // 
            // pixels48_MenuItem
            // 
            this.pixels48_MenuItem.Name = "pixels48_MenuItem";
            this.pixels48_MenuItem.ShortcutKeyDisplayString = "+/-";
            this.pixels48_MenuItem.Size = new System.Drawing.Size(144, 22);
            this.pixels48_MenuItem.Text = "48 pixels";
            this.pixels48_MenuItem.Click += new System.EventHandler(this.Pixels48_MenuItem_Click);
            // 
            // pixels56_MenuItem
            // 
            this.pixels56_MenuItem.Name = "pixels56_MenuItem";
            this.pixels56_MenuItem.ShortcutKeyDisplayString = "+/-";
            this.pixels56_MenuItem.Size = new System.Drawing.Size(144, 22);
            this.pixels56_MenuItem.Text = "56 pixels";
            this.pixels56_MenuItem.Click += new System.EventHandler(this.Pixels56_MenuItem_Click);
            // 
            // pixels64_MenuItem
            // 
            this.pixels64_MenuItem.Name = "pixels64_MenuItem";
            this.pixels64_MenuItem.ShortcutKeyDisplayString = "+/-";
            this.pixels64_MenuItem.Size = new System.Drawing.Size(144, 22);
            this.pixels64_MenuItem.Text = "64 pixels";
            this.pixels64_MenuItem.Click += new System.EventHandler(this.Pixels64_MenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(177, 6);
            // 
            // opacityMenuItem
            // 
            this.opacityMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opacity25_MenuItem,
            this.opacity50_MenuItem,
            this.opacity75_MenuItem,
            this.opacity100_MenuItem});
            this.opacityMenuItem.Name = "opacityMenuItem";
            this.opacityMenuItem.Size = new System.Drawing.Size(180, 22);
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
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // autoScaleMenuItem
            // 
            this.autoScaleMenuItem.Checked = true;
            this.autoScaleMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoScaleMenuItem.Name = "autoScaleMenuItem";
            this.autoScaleMenuItem.Size = new System.Drawing.Size(180, 22);
            this.autoScaleMenuItem.Text = "AutoScale";
            this.autoScaleMenuItem.Click += new System.EventHandler(this.AutoScaleMenuItem_Click);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.RosyBrown;
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Location = new System.Drawing.Point(222, 2);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(21, 21);
            this.panel7.TabIndex = 7;
            this.panel7.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseDown);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(78, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(21, 21);
            this.panel1.TabIndex = 1;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseDown);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Black;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Location = new System.Drawing.Point(198, 2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(21, 21);
            this.panel6.TabIndex = 6;
            this.panel6.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseDown);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Red;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(102, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(21, 21);
            this.panel2.TabIndex = 2;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseDown);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Yellow;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Location = new System.Drawing.Point(174, 2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(21, 21);
            this.panel5.TabIndex = 5;
            this.panel5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseDown);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Green;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Location = new System.Drawing.Point(126, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(21, 21);
            this.panel3.TabIndex = 3;
            this.panel3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseDown);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Blue;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Location = new System.Drawing.Point(150, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(21, 21);
            this.panel4.TabIndex = 4;
            this.panel4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseDown);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(7, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // drawCircleMenuItem
            // 
            this.drawCircleMenuItem.Name = "drawCircleMenuItem";
            this.drawCircleMenuItem.ShortcutKeyDisplayString = "C";
            this.drawCircleMenuItem.Size = new System.Drawing.Size(180, 22);
            this.drawCircleMenuItem.Text = "Draw Circles";
            this.drawCircleMenuItem.Click += new System.EventHandler(this.DrawCircleMenuItem_Click);
            // 
            // ScribbleOverlay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RosyBrown;
            this.ClientSize = new System.Drawing.Size(424, 194);
            this.Controls.Add(this.scribblePanel);
            this.DoubleBuffered = true;
            this.Name = "ScribbleOverlay";
            this.Text = "ScribbleOverlay";
            this.SizeChanged += new System.EventHandler(this.ScribbleOverlay_SizeChanged);
            this.VisibleChanged += new System.EventHandler(this.ScribbleOverlay_VisibleChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ScribbleOverlay_Paint);
            this.scribblePanel.ResumeLayout(false);
            this.optionsMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel scribblePanel;
        private Panel panel7;
        private Button button1;
        private Panel panel1;
        private Panel panel6;
        private Panel panel2;
        private Panel panel5;
        private Panel panel3;
        private Panel panel4;
        private ContextMenuStrip optionsMenu;
        private ToolStripMenuItem lineThicknessMenuItem;
        private ToolStripMenuItem pixel1_MenuItem;
        private ToolStripMenuItem pixels2_MenuItem;
        private ToolStripMenuItem pixels4_MenuItem;
        private ToolStripMenuItem pixels8_MenuItem;
        private ToolStripMenuItem pixels16_MenuItem;
        private ToolStripMenuItem lineColorMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem opacityMenuItem;
        private ToolStripMenuItem opacity25_MenuItem;
        private ToolStripMenuItem opacity50_MenuItem;
        private ToolStripMenuItem opacity75_MenuItem;
        private ToolStripMenuItem opacity100_MenuItem;
        private DropDownButton optionsButton;
        private CustomButton clearButton;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem autoScaleMenuItem;
        private ToolStripMenuItem drawRectangleMenuItem;
        private ToolStripMenuItem drawEllipseMenuItem;
        private ToolStripMenuItem drawLineMenuItem;
        private ToolStripMenuItem scribbleMenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem pixels24_MenuItem;
        private ToolStripMenuItem pixels32_MenuItem;
        private ToolStripMenuItem drawArrowMenuItem;
        private ToolStripMenuItem pixels40_MenuItem;
        private ToolStripMenuItem pixels48_MenuItem;
        private ToolStripMenuItem pixels56_MenuItem;
        private ToolStripMenuItem pixels64_MenuItem;
        private ToolStripMenuItem drawCircleMenuItem;
    }
}