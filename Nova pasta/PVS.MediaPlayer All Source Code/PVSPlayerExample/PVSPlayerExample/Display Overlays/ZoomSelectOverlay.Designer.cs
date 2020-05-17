using System.ComponentModel;
using System.Windows.Forms;

namespace PVSPlayerExample
{
    partial class ZoomSelectOverlay
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
            this.zoomPanel = new System.Windows.Forms.Panel();
            this.moveLight = new PVSPlayerExample.LightPanel();
            this.zoomOutLight = new PVSPlayerExample.LightPanel();
            this.zoomInLight = new PVSPlayerExample.LightPanel();
            this.ratioLight = new PVSPlayerExample.LightPanel();
            this.resetButton = new PVSPlayerExample.CustomButton();
            this.undoButton = new PVSPlayerExample.CustomButton();
            this.moveButton = new PVSPlayerExample.CustomButton();
            this.zoomOutButton = new PVSPlayerExample.CustomButton();
            this.zoomInButton = new PVSPlayerExample.CustomButton();
            this.ratioButton = new PVSPlayerExample.CustomButton();
            this.zoomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // zoomPanel
            // 
            this.zoomPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.zoomPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.zoomPanel.Controls.Add(this.moveLight);
            this.zoomPanel.Controls.Add(this.zoomOutLight);
            this.zoomPanel.Controls.Add(this.zoomInLight);
            this.zoomPanel.Controls.Add(this.ratioLight);
            this.zoomPanel.Controls.Add(this.resetButton);
            this.zoomPanel.Controls.Add(this.undoButton);
            this.zoomPanel.Controls.Add(this.moveButton);
            this.zoomPanel.Controls.Add(this.zoomOutButton);
            this.zoomPanel.Controls.Add(this.zoomInButton);
            this.zoomPanel.Controls.Add(this.ratioButton);
            this.zoomPanel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.zoomPanel.Location = new System.Drawing.Point(12, 12);
            this.zoomPanel.Name = "zoomPanel";
            this.zoomPanel.Size = new System.Drawing.Size(504, 27);
            this.zoomPanel.TabIndex = 0;
            this.zoomPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.ZoomPanel_Paint);
            // 
            // moveLight
            // 
            this.moveLight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.moveLight.Location = new System.Drawing.Point(278, 9);
            this.moveLight.Name = "moveLight";
            this.moveLight.Size = new System.Drawing.Size(2, 6);
            this.moveLight.TabIndex = 7;
            // 
            // zoomOutLight
            // 
            this.zoomOutLight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.zoomOutLight.Location = new System.Drawing.Point(203, 9);
            this.zoomOutLight.Name = "zoomOutLight";
            this.zoomOutLight.Size = new System.Drawing.Size(2, 6);
            this.zoomOutLight.TabIndex = 5;
            // 
            // zoomInLight
            // 
            this.zoomInLight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.zoomInLight.LightOn = true;
            this.zoomInLight.Location = new System.Drawing.Point(128, 9);
            this.zoomInLight.Name = "zoomInLight";
            this.zoomInLight.Size = new System.Drawing.Size(2, 6);
            this.zoomInLight.TabIndex = 3;
            // 
            // ratioLight
            // 
            this.ratioLight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ratioLight.LightOn = true;
            this.ratioLight.Location = new System.Drawing.Point(8, 9);
            this.ratioLight.Name = "ratioLight";
            this.ratioLight.Size = new System.Drawing.Size(2, 6);
            this.ratioLight.TabIndex = 1;
            // 
            // resetButton
            // 
            this.resetButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.resetButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.resetButton.Location = new System.Drawing.Point(427, 2);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(73, 21);
            this.resetButton.TabIndex = 9;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // undoButton
            // 
            this.undoButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.undoButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.undoButton.Location = new System.Drawing.Point(352, 2);
            this.undoButton.Name = "undoButton";
            this.undoButton.Size = new System.Drawing.Size(73, 21);
            this.undoButton.TabIndex = 8;
            this.undoButton.Text = "Undo";
            this.undoButton.UseVisualStyleBackColor = true;
            this.undoButton.Click += new System.EventHandler(this.UndoButton_Click);
            // 
            // moveButton
            // 
            this.moveButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.moveButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.moveButton.Location = new System.Drawing.Point(272, 2);
            this.moveButton.Name = "moveButton";
            this.moveButton.Size = new System.Drawing.Size(73, 21);
            this.moveButton.TabIndex = 6;
            this.moveButton.Text = " Move";
            this.moveButton.UseVisualStyleBackColor = true;
            this.moveButton.Click += new System.EventHandler(this.MoveButton_Click);
            // 
            // zoomOutButton
            // 
            this.zoomOutButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.zoomOutButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.zoomOutButton.Location = new System.Drawing.Point(197, 2);
            this.zoomOutButton.Name = "zoomOutButton";
            this.zoomOutButton.Size = new System.Drawing.Size(73, 21);
            this.zoomOutButton.TabIndex = 4;
            this.zoomOutButton.Text = "   Zoom Out";
            this.zoomOutButton.UseVisualStyleBackColor = true;
            this.zoomOutButton.Click += new System.EventHandler(this.ZoomOutButton_Click);
            // 
            // zoomInButton
            // 
            this.zoomInButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.zoomInButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.zoomInButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.zoomInButton.Location = new System.Drawing.Point(122, 2);
            this.zoomInButton.Name = "zoomInButton";
            this.zoomInButton.Size = new System.Drawing.Size(73, 21);
            this.zoomInButton.TabIndex = 2;
            this.zoomInButton.Text = "  Zoom In";
            this.zoomInButton.UseVisualStyleBackColor = true;
            this.zoomInButton.Click += new System.EventHandler(this.ZoomInButton_Click);
            // 
            // ratioButton
            // 
            this.ratioButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.ratioButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.ratioButton.Location = new System.Drawing.Point(2, 2);
            this.ratioButton.Name = "ratioButton";
            this.ratioButton.Size = new System.Drawing.Size(113, 21);
            this.ratioButton.TabIndex = 0;
            this.ratioButton.Text = "   Keep Aspect Ratio";
            this.ratioButton.UseVisualStyleBackColor = true;
            this.ratioButton.Click += new System.EventHandler(this.RatioButton_Click);
            // 
            // ZoomSelectOverlay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RosyBrown;
            this.ClientSize = new System.Drawing.Size(583, 297);
            this.Controls.Add(this.zoomPanel);
            this.DoubleBuffered = true;
            this.Name = "ZoomSelectOverlay";
            this.Text = "ZoomSelect";
            this.VisibleChanged += new System.EventHandler(this.ZoomSelectOverlay_VisibleChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ZoomSelectOverlay_Paint);
            this.zoomPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel zoomPanel;
        private CustomButton ratioButton;
        private CustomButton resetButton;
        private CustomButton undoButton;
        private CustomButton moveButton;
        private CustomButton zoomOutButton;
        private CustomButton zoomInButton;
        private LightPanel ratioLight;
        private LightPanel moveLight;
        private LightPanel zoomOutLight;
        private LightPanel zoomInLight;

    }
}