namespace FolderView
{
    partial class ItemView
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Display = new System.Windows.Forms.Panel();
            this.FileName = new System.Windows.Forms.Label();
            this.customSlider1 = new FolderView.CustomSlider1();
            ((System.ComponentModel.ISupportInitialize)(this.customSlider1)).BeginInit();
            this.SuspendLayout();
            // 
            // Display
            // 
            this.Display.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Display.Location = new System.Drawing.Point(0, 0);
            this.Display.Name = "Display";
            this.Display.Size = new System.Drawing.Size(151, 90);
            this.Display.TabIndex = 0;
            // 
            // FileName
            // 
            this.FileName.AutoEllipsis = true;
            this.FileName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.FileName.Location = new System.Drawing.Point(0, 102);
            this.FileName.Name = "FileName";
            this.FileName.Size = new System.Drawing.Size(151, 40);
            this.FileName.TabIndex = 1;
            this.FileName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // customSlider1
            // 
            this.customSlider1.AutoSize = false;
            this.customSlider1.Location = new System.Drawing.Point(-8, 88);
            this.customSlider1.Name = "customSlider1";
            this.customSlider1.Size = new System.Drawing.Size(166, 26);
            this.customSlider1.TabIndex = 2;
            this.customSlider1.Scroll += new System.EventHandler(this.CustomSlider1_Scroll);
            this.customSlider1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CustomSlider1_MouseUp);
            // 
            // ItemView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.Controls.Add(this.FileName);
            this.Controls.Add(this.Display);
            this.Controls.Add(this.customSlider1);
            this.Margin = new System.Windows.Forms.Padding(20, 20, 0, 0);
            this.Name = "ItemView";
            this.Size = new System.Drawing.Size(151, 143);
            ((System.ComponentModel.ISupportInitialize)(this.customSlider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Label FileName;
        internal System.Windows.Forms.Panel Display;
        internal CustomSlider1 customSlider1;
    }
}
