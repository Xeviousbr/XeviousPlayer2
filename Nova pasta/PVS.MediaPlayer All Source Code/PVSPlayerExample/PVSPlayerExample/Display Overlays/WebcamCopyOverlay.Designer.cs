namespace PVSPlayerExample
{
    partial class WebcamCopyOverlay
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
            this.copyMessagePanel = new System.Windows.Forms.Panel();
            this.destinationLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.copyMessagePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // copyMessagePanel
            // 
            this.copyMessagePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.copyMessagePanel.Controls.Add(this.destinationLabel);
            this.copyMessagePanel.Controls.Add(this.label1);
            this.copyMessagePanel.Location = new System.Drawing.Point(179, 160);
            this.copyMessagePanel.Name = "copyMessagePanel";
            this.copyMessagePanel.Size = new System.Drawing.Size(200, 92);
            this.copyMessagePanel.TabIndex = 1;
            this.copyMessagePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.CopyMessagePanel_Paint);
            // 
            // destinationLabel
            // 
            this.destinationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.destinationLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.destinationLabel.Location = new System.Drawing.Point(4, 55);
            this.destinationLabel.Name = "destinationLabel";
            this.destinationLabel.Size = new System.Drawing.Size(193, 23);
            this.destinationLabel.TabIndex = 1;
            this.destinationLabel.Text = "Clipboard";
            this.destinationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.label1.Location = new System.Drawing.Point(49, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "COPY";
            // 
            // WebcamCopyOverlay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lime;
            this.ClientSize = new System.Drawing.Size(558, 413);
            this.Controls.Add(this.copyMessagePanel);
            this.DoubleBuffered = true;
            this.Name = "WebcamCopyOverlay";
            this.Opacity = 0.9D;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "WebcamCopyOverlay";
            this.SizeChanged += new System.EventHandler(this.WebcamCopyOverlay_SizeChanged);
            this.copyMessagePanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel copyMessagePanel;
        private System.Windows.Forms.Label destinationLabel;
        private System.Windows.Forms.Label label1;
    }
}