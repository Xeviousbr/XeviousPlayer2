using System.ComponentModel;
using System.Windows.Forms;

namespace PVSPlayerExample
{
    partial class StatusInfoOverlay
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
            this.label2 = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.mediaLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.durationLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.startLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.endLabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.repeatLabel = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.videoLabel = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.videoEnabledLabel = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.originalSizeLabel = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.audioLabel = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.versionLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.currentSizeLabel = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.audioEnabledLabel = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.speedLabel = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.volumeLabel = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.balanceLabel = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.displayModeLabel = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.displaySizeLabel = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.displayLabel = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.fullScreenLabel = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.frameRateLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.label2.Location = new System.Drawing.Point(25, 74);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Status:";
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.statusLabel.Location = new System.Drawing.Point(127, 74);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(12, 16);
            this.statusLabel.TabIndex = 4;
            this.statusLabel.Text = "-";
            this.statusLabel.UseMnemonic = false;
            // 
            // mediaLabel
            // 
            this.mediaLabel.AutoEllipsis = true;
            this.mediaLabel.AutoSize = true;
            this.mediaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mediaLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.mediaLabel.Location = new System.Drawing.Point(127, 102);
            this.mediaLabel.Name = "mediaLabel";
            this.mediaLabel.Size = new System.Drawing.Size(12, 16);
            this.mediaLabel.TabIndex = 8;
            this.mediaLabel.Text = "-";
            this.mediaLabel.UseMnemonic = false;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.label5.Location = new System.Drawing.Point(25, 102);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "Media:";
            // 
            // durationLabel
            // 
            this.durationLabel.AutoSize = true;
            this.durationLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.durationLabel.Location = new System.Drawing.Point(127, 118);
            this.durationLabel.Name = "durationLabel";
            this.durationLabel.Size = new System.Drawing.Size(12, 16);
            this.durationLabel.TabIndex = 10;
            this.durationLabel.Text = "-";
            // 
            // label6
            // 
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.label6.Location = new System.Drawing.Point(25, 118);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 16);
            this.label6.TabIndex = 9;
            this.label6.Text = "- Duration:";
            // 
            // startLabel
            // 
            this.startLabel.AutoSize = true;
            this.startLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.startLabel.Location = new System.Drawing.Point(127, 134);
            this.startLabel.Name = "startLabel";
            this.startLabel.Size = new System.Drawing.Size(12, 16);
            this.startLabel.TabIndex = 12;
            this.startLabel.Text = "-";
            // 
            // label7
            // 
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.label7.Location = new System.Drawing.Point(25, 134);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 16);
            this.label7.TabIndex = 11;
            this.label7.Text = "- Start Time:";
            // 
            // endLabel
            // 
            this.endLabel.AutoSize = true;
            this.endLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.endLabel.Location = new System.Drawing.Point(127, 150);
            this.endLabel.Name = "endLabel";
            this.endLabel.Size = new System.Drawing.Size(12, 16);
            this.endLabel.TabIndex = 14;
            this.endLabel.Text = "-";
            // 
            // label8
            // 
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.label8.Location = new System.Drawing.Point(25, 150);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 16);
            this.label8.TabIndex = 13;
            this.label8.Text = "- Stop Time:";
            // 
            // repeatLabel
            // 
            this.repeatLabel.AutoSize = true;
            this.repeatLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.repeatLabel.Location = new System.Drawing.Point(127, 166);
            this.repeatLabel.Name = "repeatLabel";
            this.repeatLabel.Size = new System.Drawing.Size(12, 16);
            this.repeatLabel.TabIndex = 16;
            this.repeatLabel.Text = "-";
            // 
            // label9
            // 
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.label9.Location = new System.Drawing.Point(25, 166);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 16);
            this.label9.TabIndex = 15;
            this.label9.Text = "- Repeat:";
            // 
            // videoLabel
            // 
            this.videoLabel.AutoSize = true;
            this.videoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.videoLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.videoLabel.Location = new System.Drawing.Point(127, 208);
            this.videoLabel.Name = "videoLabel";
            this.videoLabel.Size = new System.Drawing.Size(12, 16);
            this.videoLabel.TabIndex = 20;
            this.videoLabel.Text = "-";
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.label11.Location = new System.Drawing.Point(25, 208);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 16);
            this.label11.TabIndex = 19;
            this.label11.Text = "Video:";
            // 
            // videoEnabledLabel
            // 
            this.videoEnabledLabel.AutoSize = true;
            this.videoEnabledLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.videoEnabledLabel.Location = new System.Drawing.Point(127, 224);
            this.videoEnabledLabel.Name = "videoEnabledLabel";
            this.videoEnabledLabel.Size = new System.Drawing.Size(12, 16);
            this.videoEnabledLabel.TabIndex = 22;
            this.videoEnabledLabel.Text = "-";
            // 
            // label12
            // 
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.label12.Location = new System.Drawing.Point(25, 224);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 16);
            this.label12.TabIndex = 21;
            this.label12.Text = "- Enabled:";
            // 
            // originalSizeLabel
            // 
            this.originalSizeLabel.AutoSize = true;
            this.originalSizeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.originalSizeLabel.Location = new System.Drawing.Point(127, 240);
            this.originalSizeLabel.Name = "originalSizeLabel";
            this.originalSizeLabel.Size = new System.Drawing.Size(12, 16);
            this.originalSizeLabel.TabIndex = 24;
            this.originalSizeLabel.Text = "-";
            // 
            // label13
            // 
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.label13.Location = new System.Drawing.Point(25, 240);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(93, 16);
            this.label13.TabIndex = 23;
            this.label13.Text = "- Original Size:";
            // 
            // audioLabel
            // 
            this.audioLabel.AutoSize = true;
            this.audioLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.audioLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.audioLabel.Location = new System.Drawing.Point(127, 298);
            this.audioLabel.Name = "audioLabel";
            this.audioLabel.Size = new System.Drawing.Size(12, 16);
            this.audioLabel.TabIndex = 30;
            this.audioLabel.Text = "-";
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.label15.Location = new System.Drawing.Point(25, 298);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(52, 16);
            this.label15.TabIndex = 29;
            this.label15.Text = "Audio:";
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.versionLabel.Location = new System.Drawing.Point(127, 36);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(12, 16);
            this.versionLabel.TabIndex = 2;
            this.versionLabel.Text = "-";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.label4.Location = new System.Drawing.Point(25, 36);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "Player Version:";
            // 
            // currentSizeLabel
            // 
            this.currentSizeLabel.AutoSize = true;
            this.currentSizeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.currentSizeLabel.Location = new System.Drawing.Point(127, 256);
            this.currentSizeLabel.Name = "currentSizeLabel";
            this.currentSizeLabel.Size = new System.Drawing.Size(12, 16);
            this.currentSizeLabel.TabIndex = 26;
            this.currentSizeLabel.Text = "-";
            // 
            // label14
            // 
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.label14.Location = new System.Drawing.Point(25, 256);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(89, 16);
            this.label14.TabIndex = 25;
            this.label14.Text = "- Current Size:";
            // 
            // audioEnabledLabel
            // 
            this.audioEnabledLabel.AutoSize = true;
            this.audioEnabledLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.audioEnabledLabel.Location = new System.Drawing.Point(127, 314);
            this.audioEnabledLabel.Name = "audioEnabledLabel";
            this.audioEnabledLabel.Size = new System.Drawing.Size(12, 16);
            this.audioEnabledLabel.TabIndex = 32;
            this.audioEnabledLabel.Text = "-";
            // 
            // label16
            // 
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.label16.Location = new System.Drawing.Point(25, 314);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(69, 16);
            this.label16.TabIndex = 31;
            this.label16.Text = "- Enabled:";
            // 
            // speedLabel
            // 
            this.speedLabel.AutoSize = true;
            this.speedLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.speedLabel.Location = new System.Drawing.Point(127, 182);
            this.speedLabel.Name = "speedLabel";
            this.speedLabel.Size = new System.Drawing.Size(12, 16);
            this.speedLabel.TabIndex = 18;
            this.speedLabel.Text = "-";
            // 
            // label10
            // 
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.label10.Location = new System.Drawing.Point(25, 182);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 16);
            this.label10.TabIndex = 17;
            this.label10.Text = "- Speed:";
            // 
            // volumeLabel
            // 
            this.volumeLabel.AutoSize = true;
            this.volumeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.volumeLabel.Location = new System.Drawing.Point(127, 330);
            this.volumeLabel.Name = "volumeLabel";
            this.volumeLabel.Size = new System.Drawing.Size(12, 16);
            this.volumeLabel.TabIndex = 34;
            this.volumeLabel.Text = "-";
            // 
            // label17
            // 
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.label17.Location = new System.Drawing.Point(25, 330);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(64, 16);
            this.label17.TabIndex = 33;
            this.label17.Text = "- Volume:";
            // 
            // balanceLabel
            // 
            this.balanceLabel.AutoSize = true;
            this.balanceLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.balanceLabel.Location = new System.Drawing.Point(127, 346);
            this.balanceLabel.Name = "balanceLabel";
            this.balanceLabel.Size = new System.Drawing.Size(12, 16);
            this.balanceLabel.TabIndex = 36;
            this.balanceLabel.Text = "-";
            // 
            // label18
            // 
            this.label18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.label18.Location = new System.Drawing.Point(25, 346);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(68, 16);
            this.label18.TabIndex = 35;
            this.label18.Text = "- Balance:";
            // 
            // displayModeLabel
            // 
            this.displayModeLabel.AutoSize = true;
            this.displayModeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.displayModeLabel.Location = new System.Drawing.Point(127, 404);
            this.displayModeLabel.Name = "displayModeLabel";
            this.displayModeLabel.Size = new System.Drawing.Size(12, 16);
            this.displayModeLabel.TabIndex = 42;
            this.displayModeLabel.Text = "-";
            // 
            // label21
            // 
            this.label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.label21.Location = new System.Drawing.Point(25, 404);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(92, 16);
            this.label21.TabIndex = 41;
            this.label21.Text = "- Video Mode:";
            // 
            // displaySizeLabel
            // 
            this.displaySizeLabel.AutoSize = true;
            this.displaySizeLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.displaySizeLabel.Location = new System.Drawing.Point(127, 388);
            this.displaySizeLabel.Name = "displaySizeLabel";
            this.displaySizeLabel.Size = new System.Drawing.Size(12, 16);
            this.displaySizeLabel.TabIndex = 40;
            this.displaySizeLabel.Text = "-";
            // 
            // label20
            // 
            this.label20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.label20.Location = new System.Drawing.Point(25, 388);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(44, 16);
            this.label20.TabIndex = 39;
            this.label20.Text = "- Size:";
            // 
            // displayLabel
            // 
            this.displayLabel.AutoSize = true;
            this.displayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displayLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.displayLabel.Location = new System.Drawing.Point(127, 372);
            this.displayLabel.Name = "displayLabel";
            this.displayLabel.Size = new System.Drawing.Size(12, 16);
            this.displayLabel.TabIndex = 38;
            this.displayLabel.Text = "-";
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.label19.Location = new System.Drawing.Point(25, 372);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(65, 16);
            this.label19.TabIndex = 37;
            this.label19.Text = "Display:";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.label1.Location = new System.Drawing.Point(24, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Player Status Information";
            // 
            // label22
            // 
            this.label22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.label22.Location = new System.Drawing.Point(25, 420);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(99, 16);
            this.label22.TabIndex = 43;
            this.label22.Text = "- Screen Mode:";
            // 
            // fullScreenLabel
            // 
            this.fullScreenLabel.AutoSize = true;
            this.fullScreenLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.fullScreenLabel.Location = new System.Drawing.Point(127, 420);
            this.fullScreenLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.fullScreenLabel.Name = "fullScreenLabel";
            this.fullScreenLabel.Size = new System.Drawing.Size(12, 16);
            this.fullScreenLabel.TabIndex = 44;
            this.fullScreenLabel.Text = "-";
            // 
            // label23
            // 
            this.label23.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.label23.Location = new System.Drawing.Point(25, 272);
            this.label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(89, 16);
            this.label23.TabIndex = 27;
            this.label23.Text = "- Frame Rate:";
            // 
            // frameRateLabel
            // 
            this.frameRateLabel.AutoSize = true;
            this.frameRateLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(173)))), ((int)(((byte)(146)))));
            this.frameRateLabel.Location = new System.Drawing.Point(127, 272);
            this.frameRateLabel.Name = "frameRateLabel";
            this.frameRateLabel.Size = new System.Drawing.Size(12, 16);
            this.frameRateLabel.TabIndex = 28;
            this.frameRateLabel.Text = "-";
            // 
            // StatusInfoOverlay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.ClientSize = new System.Drawing.Size(551, 466);
            this.Controls.Add(this.frameRateLabel);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.fullScreenLabel);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.displayModeLabel);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.displaySizeLabel);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.displayLabel);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.balanceLabel);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.volumeLabel);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.speedLabel);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.audioEnabledLabel);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.currentSizeLabel);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.versionLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.audioLabel);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.originalSizeLabel);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.videoEnabledLabel);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.videoLabel);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.repeatLabel);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.endLabel);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.startLabel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.durationLabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.mediaLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "StatusInfoOverlay";
            this.Opacity = 0.6D;
            this.Text = "StatusInfoOverlay";
            this.TransparencyKey = System.Drawing.Color.RosyBrown;
            this.VisibleChanged += new System.EventHandler(this.StatusInfoOverlay_VisibleChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label2;
        private Label statusLabel;
        private Label mediaLabel;
        private Label label5;
        private Label durationLabel;
        private Label label6;
        private Label startLabel;
        private Label label7;
        private Label endLabel;
        private Label label8;
        private Label repeatLabel;
        private Label label9;
        private Label videoLabel;
        private Label label11;
        private Label videoEnabledLabel;
        private Label label12;
        private Label originalSizeLabel;
        private Label label13;
        private Label audioLabel;
        private Label label15;
        private Label versionLabel;
        private Label label4;
        private Label currentSizeLabel;
        private Label label14;
        private Label audioEnabledLabel;
        private Label label16;
        private Label speedLabel;
        private Label label10;
        private Label volumeLabel;
        private Label label17;
        private Label balanceLabel;
        private Label label18;
        private Label displayModeLabel;
        private Label label21;
        private Label displaySizeLabel;
        private Label label20;
        private Label displayLabel;
        private Label label19;
        private Label label1;
        private Label label22;
        private Label fullScreenLabel;
        private Label label23;
        private Label frameRateLabel;
    }
}