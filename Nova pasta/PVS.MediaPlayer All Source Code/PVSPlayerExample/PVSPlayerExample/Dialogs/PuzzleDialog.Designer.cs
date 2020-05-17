namespace PVSPlayerExample
{
    partial class PuzzleDialog
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
            this.messageLabel = new System.Windows.Forms.Label();
            this.yesButton = new PVSPlayerExample.CustomButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.noButton = new PVSPlayerExample.CustomButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // messageLabel
            // 
            this.messageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.messageLabel.Location = new System.Drawing.Point(9, 3);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(544, 108);
            this.messageLabel.TabIndex = 0;
            this.messageLabel.Paint += new System.Windows.Forms.PaintEventHandler(this.MessageLabel_Paint);
            // 
            // yesButton
            // 
            this.yesButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.yesButton.FocusBorder = true;
            this.yesButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.yesButton.Location = new System.Drawing.Point(2, 2);
            this.yesButton.Name = "yesButton";
            this.yesButton.Size = new System.Drawing.Size(100, 21);
            this.yesButton.TabIndex = 1;
            this.yesButton.Text = "Play Again";
            this.yesButton.UseVisualStyleBackColor = true;
            this.yesButton.Click += new System.EventHandler(this.YesButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.noButton);
            this.panel1.Controls.Add(this.yesButton);
            this.panel1.Location = new System.Drawing.Point(177, 135);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(208, 27);
            this.panel1.TabIndex = 2;
            // 
            // noButton
            // 
            this.noButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.noButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.noButton.FocusBorder = true;
            this.noButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.noButton.Location = new System.Drawing.Point(104, 2);
            this.noButton.Name = "noButton";
            this.noButton.Size = new System.Drawing.Size(100, 21);
            this.noButton.TabIndex = 2;
            this.noButton.Text = "Stop Playing";
            this.noButton.UseVisualStyleBackColor = true;
            this.noButton.Click += new System.EventHandler(this.NoButton_Click);
            // 
            // PuzzleDialog
            // 
            this.AcceptButton = this.yesButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.CancelButton = this.noButton;
            this.ClientSize = new System.Drawing.Size(562, 171);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.messageLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PuzzleDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "PuzzleDialog";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Shown += new System.EventHandler(this.PuzzleDialog_Shown);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label messageLabel;
        private CustomButton yesButton;
        private System.Windows.Forms.Panel panel1;
        private CustomButton noButton;
    }
}