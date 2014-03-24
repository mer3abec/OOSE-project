namespace VSAudioPlayer
{
    partial class PlayerInterface
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerInterface));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileToPlayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.showPanel = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.random = new System.Windows.Forms.CheckBox();
            this.repeat = new System.Windows.Forms.CheckBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.next = new System.Windows.Forms.Button();
            this.play = new System.Windows.Forms.Button();
            this.stop = new System.Windows.Forms.Button();
            this.previous = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(514, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileToPlayToolStripMenuItem,
            this.openFolderToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuItem1.Text = "File";
            // 
            // openFileToPlayToolStripMenuItem
            // 
            this.openFileToPlayToolStripMenuItem.Name = "openFileToPlayToolStripMenuItem";
            this.openFileToPlayToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.openFileToPlayToolStripMenuItem.Text = "Open File to play";
            // 
            // openFolderToolStripMenuItem
            // 
            this.openFolderToolStripMenuItem.Name = "openFolderToolStripMenuItem";
            this.openFolderToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.openFolderToolStripMenuItem.Text = "Open Folder";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox1.Controls.Add(this.showPanel);
            this.groupBox1.Location = new System.Drawing.Point(2, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(508, 100);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Media Info: ";
            // 
            // showPanel
            // 
            this.showPanel.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.showPanel.Font = new System.Drawing.Font("Calibri", 27.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.showPanel.ForeColor = System.Drawing.SystemColors.MenuText;
            this.showPanel.Location = new System.Drawing.Point(11, 20);
            this.showPanel.Name = "showPanel";
            this.showPanel.Size = new System.Drawing.Size(489, 74);
            this.showPanel.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Controls.Add(this.trackBar2);
            this.groupBox2.Controls.Add(this.random);
            this.groupBox2.Controls.Add(this.repeat);
            this.groupBox2.Controls.Add(this.next);
            this.groupBox2.Controls.Add(this.play);
            this.groupBox2.Controls.Add(this.stop);
            this.groupBox2.Controls.Add(this.previous);
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Location = new System.Drawing.Point(2, 181);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(508, 67);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Controls: ";
            // 
            // trackBar2
            // 
            this.trackBar2.LargeChange = 1;
            this.trackBar2.Location = new System.Drawing.Point(388, 20);
            this.trackBar2.Maximum = 100;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(112, 45);
            this.trackBar2.TabIndex = 6;
            // 
            // random
            // 
            this.random.AutoSize = true;
            this.random.Location = new System.Drawing.Point(6, 46);
            this.random.Name = "random";
            this.random.Size = new System.Drawing.Size(49, 17);
            this.random.TabIndex = 3;
            this.random.Text = "Rnd.";
            this.random.UseVisualStyleBackColor = true;
            // 
            // repeat
            // 
            this.repeat.AutoSize = true;
            this.repeat.Location = new System.Drawing.Point(110, 46);
            this.repeat.Name = "repeat";
            this.repeat.Size = new System.Drawing.Size(49, 17);
            this.repeat.TabIndex = 5;
            this.repeat.Text = "Rep.";
            this.repeat.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(6, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(153, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.Text = "Current File";
            // 
            // trackBar1
            // 
            this.trackBar1.LargeChange = 1;
            this.trackBar1.Location = new System.Drawing.Point(2, 130);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(508, 45);
            this.trackBar1.TabIndex = 100;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::VSAudioPlayer.Properties.Resources.vol_icon;
            this.pictureBox1.Location = new System.Drawing.Point(361, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // next
            // 
            this.next.BackgroundImage = global::VSAudioPlayer.Properties.Resources.next_icon;
            this.next.Location = new System.Drawing.Point(312, 20);
            this.next.Name = "next";
            this.next.Size = new System.Drawing.Size(31, 31);
            this.next.TabIndex = 4;
            this.next.UseVisualStyleBackColor = true;
            // 
            // play
            // 
            this.play.BackgroundImage = global::VSAudioPlayer.Properties.Resources.play_icon;
            this.play.Location = new System.Drawing.Point(265, 20);
            this.play.Name = "play";
            this.play.Size = new System.Drawing.Size(31, 31);
            this.play.TabIndex = 3;
            this.play.UseVisualStyleBackColor = true;
            // 
            // stop
            // 
            this.stop.BackgroundImage = global::VSAudioPlayer.Properties.Resources.stop_icon;
            this.stop.Location = new System.Drawing.Point(220, 20);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(30, 31);
            this.stop.TabIndex = 2;
            this.stop.UseVisualStyleBackColor = true;
            // 
            // previous
            // 
            this.previous.BackgroundImage = global::VSAudioPlayer.Properties.Resources.prev_icon;
            this.previous.Location = new System.Drawing.Point(175, 19);
            this.previous.Name = "previous";
            this.previous.Size = new System.Drawing.Size(30, 32);
            this.previous.TabIndex = 1;
            this.previous.UseVisualStyleBackColor = true;
            // 
            // PlayerInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 250);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "PlayerInterface";
            this.Text = "Best Ever Player";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem openFileToPlayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox random;
        private System.Windows.Forms.CheckBox repeat;
        private System.Windows.Forms.Button next;
        private System.Windows.Forms.Button play;
        private System.Windows.Forms.Button stop;
        private System.Windows.Forms.Button previous;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.Panel showPanel;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

