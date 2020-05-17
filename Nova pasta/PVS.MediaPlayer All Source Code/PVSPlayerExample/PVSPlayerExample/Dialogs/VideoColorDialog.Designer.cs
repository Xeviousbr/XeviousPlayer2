namespace PVSPlayerExample
{
    partial class VideoColorDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.panel1 = new System.Windows.Forms.Panel();
            this.brightnessLight = new PVSPlayerExample.LightPanel();
            this.brightnessValue = new System.Windows.Forms.Label();
            this.colorDialogMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.resetItemMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearItemMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.resetAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.brightnessLabel = new System.Windows.Forms.Label();
            this.brightnessSlider = new PVSPlayerExample.CustomSlider2();
            this.panel2 = new System.Windows.Forms.Panel();
            this.contrastLight = new PVSPlayerExample.LightPanel();
            this.contrastValue = new System.Windows.Forms.Label();
            this.contrastLabel = new System.Windows.Forms.Label();
            this.contrastSlider = new PVSPlayerExample.CustomSlider2();
            this.panel3 = new System.Windows.Forms.Panel();
            this.hueLight = new PVSPlayerExample.LightPanel();
            this.hueValue = new System.Windows.Forms.Label();
            this.hueLabel = new System.Windows.Forms.Label();
            this.hueSlider = new PVSPlayerExample.CustomSlider2();
            this.panel4 = new System.Windows.Forms.Panel();
            this.saturationLight = new PVSPlayerExample.LightPanel();
            this.saturationValue = new System.Windows.Forms.Label();
            this.saturationLabel = new System.Windows.Forms.Label();
            this.saturationSlider = new PVSPlayerExample.CustomSlider2();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.cancelButton = new PVSPlayerExample.CustomButton();
            this.OKButton = new PVSPlayerExample.CustomButton();
            this.panel1.SuspendLayout();
            this.colorDialogMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.brightnessSlider)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contrastSlider)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hueSlider)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.saturationSlider)).BeginInit();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.brightnessLight);
            this.panel1.Controls.Add(this.brightnessValue);
            this.panel1.Controls.Add(this.brightnessLabel);
            this.panel1.Controls.Add(this.brightnessSlider);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(323, 51);
            this.panel1.TabIndex = 0;
            // 
            // brightnessLight
            // 
            this.brightnessLight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.brightnessLight.Location = new System.Drawing.Point(9, 21);
            this.brightnessLight.Name = "brightnessLight";
            this.brightnessLight.Size = new System.Drawing.Size(2, 6);
            this.brightnessLight.TabIndex = 3;
            // 
            // brightnessValue
            // 
            this.brightnessValue.ContextMenuStrip = this.colorDialogMenu;
            this.brightnessValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.brightnessValue.Location = new System.Drawing.Point(277, 5);
            this.brightnessValue.Name = "brightnessValue";
            this.brightnessValue.Size = new System.Drawing.Size(44, 37);
            this.brightnessValue.TabIndex = 2;
            this.brightnessValue.Text = "0.00";
            this.brightnessValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // colorDialogMenu
            // 
            this.colorDialogMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resetItemMenuItem,
            this.clearItemMenuItem,
            this.toolStripSeparator2,
            this.resetAllMenuItem,
            this.clearAllMenuItem});
            this.colorDialogMenu.Name = "contextMenuStrip1";
            this.colorDialogMenu.ShowImageMargin = false;
            this.colorDialogMenu.Size = new System.Drawing.Size(140, 98);
            this.colorDialogMenu.Opening += new System.ComponentModel.CancelEventHandler(this.ColorDialogMenu_Opening);
            // 
            // resetItemMenuItem
            // 
            this.resetItemMenuItem.Name = "resetItemMenuItem";
            this.resetItemMenuItem.Size = new System.Drawing.Size(139, 22);
            this.resetItemMenuItem.Text = "Reset Item";
            this.resetItemMenuItem.Click += new System.EventHandler(this.ResetItemMenuItem_Click);
            // 
            // clearItemMenuItem
            // 
            this.clearItemMenuItem.Name = "clearItemMenuItem";
            this.clearItemMenuItem.Size = new System.Drawing.Size(139, 22);
            this.clearItemMenuItem.Text = "Clear Item";
            this.clearItemMenuItem.Click += new System.EventHandler(this.ClearItemMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(136, 6);
            // 
            // resetAllMenuItem
            // 
            this.resetAllMenuItem.Name = "resetAllMenuItem";
            this.resetAllMenuItem.Size = new System.Drawing.Size(139, 22);
            this.resetAllMenuItem.Text = "Reset All Settings";
            this.resetAllMenuItem.Click += new System.EventHandler(this.ResetAllMenuItem_Click);
            // 
            // clearAllMenuItem
            // 
            this.clearAllMenuItem.Name = "clearAllMenuItem";
            this.clearAllMenuItem.Size = new System.Drawing.Size(139, 22);
            this.clearAllMenuItem.Text = "Clear All Settings";
            this.clearAllMenuItem.Click += new System.EventHandler(this.ClearAllMenuItem_Click);
            // 
            // brightnessLabel
            // 
            this.brightnessLabel.ContextMenuStrip = this.colorDialogMenu;
            this.brightnessLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.brightnessLabel.Location = new System.Drawing.Point(16, 15);
            this.brightnessLabel.Name = "brightnessLabel";
            this.brightnessLabel.Size = new System.Drawing.Size(72, 19);
            this.brightnessLabel.TabIndex = 0;
            this.brightnessLabel.Text = "Brightness";
            // 
            // brightnessSlider
            // 
            this.brightnessSlider.AutoSize = false;
            this.brightnessSlider.ContextMenuStrip = this.colorDialogMenu;
            this.brightnessSlider.LargeChange = 10;
            this.brightnessSlider.Location = new System.Drawing.Point(84, 4);
            this.brightnessSlider.Maximum = 100;
            this.brightnessSlider.Minimum = -100;
            this.brightnessSlider.Name = "brightnessSlider";
            this.brightnessSlider.Size = new System.Drawing.Size(200, 45);
            this.brightnessSlider.TabIndex = 1;
            this.brightnessSlider.TickFrequency = 10;
            this.brightnessSlider.TickStyle = System.Windows.Forms.TickStyle.Both;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.contrastLight);
            this.panel2.Controls.Add(this.contrastValue);
            this.panel2.Controls.Add(this.contrastLabel);
            this.panel2.Controls.Add(this.contrastSlider);
            this.panel2.Location = new System.Drawing.Point(0, 50);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(323, 51);
            this.panel2.TabIndex = 1;
            // 
            // contrastLight
            // 
            this.contrastLight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.contrastLight.Location = new System.Drawing.Point(9, 21);
            this.contrastLight.Name = "contrastLight";
            this.contrastLight.Size = new System.Drawing.Size(2, 6);
            this.contrastLight.TabIndex = 4;
            // 
            // contrastValue
            // 
            this.contrastValue.ContextMenuStrip = this.colorDialogMenu;
            this.contrastValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contrastValue.Location = new System.Drawing.Point(277, 5);
            this.contrastValue.Name = "contrastValue";
            this.contrastValue.Size = new System.Drawing.Size(44, 37);
            this.contrastValue.TabIndex = 2;
            this.contrastValue.Text = "0.00";
            this.contrastValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // contrastLabel
            // 
            this.contrastLabel.ContextMenuStrip = this.colorDialogMenu;
            this.contrastLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contrastLabel.Location = new System.Drawing.Point(16, 15);
            this.contrastLabel.Name = "contrastLabel";
            this.contrastLabel.Size = new System.Drawing.Size(72, 19);
            this.contrastLabel.TabIndex = 0;
            this.contrastLabel.Text = "Contrast";
            // 
            // contrastSlider
            // 
            this.contrastSlider.AutoSize = false;
            this.contrastSlider.ContextMenuStrip = this.colorDialogMenu;
            this.contrastSlider.LargeChange = 10;
            this.contrastSlider.Location = new System.Drawing.Point(84, 4);
            this.contrastSlider.Maximum = 100;
            this.contrastSlider.Minimum = -100;
            this.contrastSlider.Name = "contrastSlider";
            this.contrastSlider.Size = new System.Drawing.Size(200, 45);
            this.contrastSlider.TabIndex = 1;
            this.contrastSlider.TickFrequency = 10;
            this.contrastSlider.TickStyle = System.Windows.Forms.TickStyle.Both;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.hueLight);
            this.panel3.Controls.Add(this.hueValue);
            this.panel3.Controls.Add(this.hueLabel);
            this.panel3.Controls.Add(this.hueSlider);
            this.panel3.Location = new System.Drawing.Point(0, 100);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(323, 51);
            this.panel3.TabIndex = 2;
            // 
            // hueLight
            // 
            this.hueLight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.hueLight.Location = new System.Drawing.Point(9, 21);
            this.hueLight.Name = "hueLight";
            this.hueLight.Size = new System.Drawing.Size(2, 6);
            this.hueLight.TabIndex = 4;
            // 
            // hueValue
            // 
            this.hueValue.ContextMenuStrip = this.colorDialogMenu;
            this.hueValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hueValue.Location = new System.Drawing.Point(277, 5);
            this.hueValue.Name = "hueValue";
            this.hueValue.Size = new System.Drawing.Size(44, 37);
            this.hueValue.TabIndex = 2;
            this.hueValue.Text = "0.00";
            this.hueValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // hueLabel
            // 
            this.hueLabel.ContextMenuStrip = this.colorDialogMenu;
            this.hueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hueLabel.Location = new System.Drawing.Point(16, 15);
            this.hueLabel.Name = "hueLabel";
            this.hueLabel.Size = new System.Drawing.Size(72, 19);
            this.hueLabel.TabIndex = 0;
            this.hueLabel.Text = "Hue";
            // 
            // hueSlider
            // 
            this.hueSlider.AutoSize = false;
            this.hueSlider.ContextMenuStrip = this.colorDialogMenu;
            this.hueSlider.LargeChange = 10;
            this.hueSlider.Location = new System.Drawing.Point(84, 4);
            this.hueSlider.Maximum = 100;
            this.hueSlider.Minimum = -100;
            this.hueSlider.Name = "hueSlider";
            this.hueSlider.Size = new System.Drawing.Size(200, 45);
            this.hueSlider.TabIndex = 1;
            this.hueSlider.TickFrequency = 10;
            this.hueSlider.TickStyle = System.Windows.Forms.TickStyle.Both;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.saturationLight);
            this.panel4.Controls.Add(this.saturationValue);
            this.panel4.Controls.Add(this.saturationLabel);
            this.panel4.Controls.Add(this.saturationSlider);
            this.panel4.Location = new System.Drawing.Point(0, 150);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(323, 51);
            this.panel4.TabIndex = 3;
            // 
            // saturationLight
            // 
            this.saturationLight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.saturationLight.Location = new System.Drawing.Point(9, 21);
            this.saturationLight.Name = "saturationLight";
            this.saturationLight.Size = new System.Drawing.Size(2, 6);
            this.saturationLight.TabIndex = 4;
            // 
            // saturationValue
            // 
            this.saturationValue.ContextMenuStrip = this.colorDialogMenu;
            this.saturationValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saturationValue.Location = new System.Drawing.Point(277, 5);
            this.saturationValue.Name = "saturationValue";
            this.saturationValue.Size = new System.Drawing.Size(44, 37);
            this.saturationValue.TabIndex = 2;
            this.saturationValue.Text = "0.00";
            this.saturationValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // saturationLabel
            // 
            this.saturationLabel.ContextMenuStrip = this.colorDialogMenu;
            this.saturationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saturationLabel.Location = new System.Drawing.Point(16, 15);
            this.saturationLabel.Name = "saturationLabel";
            this.saturationLabel.Size = new System.Drawing.Size(72, 19);
            this.saturationLabel.TabIndex = 0;
            this.saturationLabel.Text = "Saturation";
            // 
            // saturationSlider
            // 
            this.saturationSlider.AutoSize = false;
            this.saturationSlider.ContextMenuStrip = this.colorDialogMenu;
            this.saturationSlider.LargeChange = 10;
            this.saturationSlider.Location = new System.Drawing.Point(84, 4);
            this.saturationSlider.Maximum = 100;
            this.saturationSlider.Minimum = -100;
            this.saturationSlider.Name = "saturationSlider";
            this.saturationSlider.Size = new System.Drawing.Size(200, 45);
            this.saturationSlider.TabIndex = 1;
            this.saturationSlider.TickFrequency = 10;
            this.saturationSlider.TickStyle = System.Windows.Forms.TickStyle.Both;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Controls.Add(this.cancelButton);
            this.panel5.Controls.Add(this.OKButton);
            this.panel5.Location = new System.Drawing.Point(0, 200);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(323, 50);
            this.panel5.TabIndex = 4;
            // 
            // panel6
            // 
            this.panel6.Location = new System.Drawing.Point(10, 9);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(42, 33);
            this.panel6.TabIndex = 2;
            this.panel6.Paint += new System.Windows.Forms.PaintEventHandler(this.PVSLogo_Paint);
            // 
            // cancelButton
            // 
            this.cancelButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FocusBorder = true;
            this.cancelButton.Location = new System.Drawing.Point(224, 13);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(84, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // OKButton
            // 
            this.OKButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKButton.FocusBorder = true;
            this.OKButton.Location = new System.Drawing.Point(131, 13);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(84, 23);
            this.OKButton.TabIndex = 0;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = false;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // VideoColorDialog
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(323, 250);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VideoColorDialog";
            this.Opacity = 0.95D;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Video Color";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.VideoColorDialog_FormClosed);
            this.Shown += new System.EventHandler(this.VideoColorDialog_Shown);
            this.panel1.ResumeLayout(false);
            this.colorDialogMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.brightnessSlider)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.contrastSlider)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.hueSlider)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.saturationSlider)).EndInit();
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label brightnessLabel;
        private System.Windows.Forms.Label brightnessValue;
        private CustomSlider2 brightnessSlider;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label contrastValue;
        private System.Windows.Forms.Label contrastLabel;
        private CustomSlider2 contrastSlider;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label hueValue;
        private System.Windows.Forms.Label hueLabel;
        private CustomSlider2 hueSlider;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label saturationValue;
        private System.Windows.Forms.Label saturationLabel;
        private CustomSlider2 saturationSlider;
        private LightPanel brightnessLight;
        private LightPanel contrastLight;
        private LightPanel hueLight;
        private LightPanel saturationLight;
        private System.Windows.Forms.Panel panel5;
        private CustomButton OKButton;
        private CustomButton cancelButton;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.ContextMenuStrip colorDialogMenu;
        private System.Windows.Forms.ToolStripMenuItem clearAllMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetAllMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetItemMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearItemMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}