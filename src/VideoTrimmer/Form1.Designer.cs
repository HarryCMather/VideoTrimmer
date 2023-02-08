namespace VideoTrimmer
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.videoPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.chooseVideoButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.endButton = new System.Windows.Forms.Button();
            this.startDurationLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.endDurationLabel = new System.Windows.Forms.Label();
            this.compressAndTrimButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.videoPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // videoPlayer
            // 
            this.videoPlayer.Enabled = true;
            this.videoPlayer.Location = new System.Drawing.Point(12, 41);
            this.videoPlayer.Name = "videoPlayer";
            this.videoPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("videoPlayer.OcxState")));
            this.videoPlayer.Size = new System.Drawing.Size(1178, 642);
            this.videoPlayer.TabIndex = 0;
            // 
            // chooseVideoButton
            // 
            this.chooseVideoButton.Location = new System.Drawing.Point(12, 12);
            this.chooseVideoButton.Name = "chooseVideoButton";
            this.chooseVideoButton.Size = new System.Drawing.Size(1178, 23);
            this.chooseVideoButton.TabIndex = 1;
            this.chooseVideoButton.Text = "Choose Video";
            this.chooseVideoButton.UseVisualStyleBackColor = true;
            this.chooseVideoButton.Click += new System.EventHandler(this.chooseVideoButton_Click);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(12, 689);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(114, 23);
            this.startButton.TabIndex = 2;
            this.startButton.Text = "Start of Trimmed Clip";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 715);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Selected Start Duration:";
            // 
            // endButton
            // 
            this.endButton.Location = new System.Drawing.Point(1076, 689);
            this.endButton.Name = "endButton";
            this.endButton.Size = new System.Drawing.Size(114, 23);
            this.endButton.TabIndex = 4;
            this.endButton.Text = "End of Trimmed Clip";
            this.endButton.UseVisualStyleBackColor = true;
            this.endButton.Click += new System.EventHandler(this.endButton_Click);
            // 
            // startDurationLabel
            // 
            this.startDurationLabel.AutoSize = true;
            this.startDurationLabel.Location = new System.Drawing.Point(147, 715);
            this.startDurationLabel.Name = "startDurationLabel";
            this.startDurationLabel.Size = new System.Drawing.Size(0, 13);
            this.startDurationLabel.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(988, 715);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Selected End Duration:";
            // 
            // endDurationLabel
            // 
            this.endDurationLabel.AutoSize = true;
            this.endDurationLabel.Location = new System.Drawing.Point(1123, 715);
            this.endDurationLabel.Name = "endDurationLabel";
            this.endDurationLabel.Size = new System.Drawing.Size(0, 13);
            this.endDurationLabel.TabIndex = 7;
            // 
            // compressAndTrimButton
            // 
            this.compressAndTrimButton.Location = new System.Drawing.Point(12, 733);
            this.compressAndTrimButton.Name = "compressAndTrimButton";
            this.compressAndTrimButton.Size = new System.Drawing.Size(1178, 23);
            this.compressAndTrimButton.TabIndex = 8;
            this.compressAndTrimButton.Text = "Compress and Trim Clip";
            this.compressAndTrimButton.UseVisualStyleBackColor = true;
            this.compressAndTrimButton.Click += new System.EventHandler(this.compressAndTrimButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1202, 769);
            this.Controls.Add(this.compressAndTrimButton);
            this.Controls.Add(this.endDurationLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.startDurationLabel);
            this.Controls.Add(this.endButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.chooseVideoButton);
            this.Controls.Add(this.videoPlayer);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.videoPlayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer videoPlayer;
        private System.Windows.Forms.Button chooseVideoButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button endButton;
        private System.Windows.Forms.Label startDurationLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label endDurationLabel;
        private System.Windows.Forms.Button compressAndTrimButton;
    }
}

