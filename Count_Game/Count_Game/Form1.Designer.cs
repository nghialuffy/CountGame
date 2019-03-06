namespace Count_Game
{
    partial class Count_game
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Count_game));
            this.Label_day = new System.Windows.Forms.Label();
            this.label_hour = new System.Windows.Forms.Label();
            this.label_min = new System.Windows.Forms.Label();
            this.label_sec = new System.Windows.Forms.Label();
            this.Label_note = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.PBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Label_day
            // 
            resources.ApplyResources(this.Label_day, "Label_day");
            this.Label_day.Name = "Label_day";
            // 
            // label_hour
            // 
            resources.ApplyResources(this.label_hour, "label_hour");
            this.label_hour.Name = "label_hour";
            // 
            // label_min
            // 
            resources.ApplyResources(this.label_min, "label_min");
            this.label_min.Name = "label_min";
            // 
            // label_sec
            // 
            resources.ApplyResources(this.label_sec, "label_sec");
            this.label_sec.Name = "label_sec";
            // 
            // Label_note
            // 
            resources.ApplyResources(this.Label_note, "Label_note");
            this.Label_note.Name = "Label_note";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // PBox1
            // 
            resources.ApplyResources(this.PBox1, "PBox1");
            this.PBox1.Name = "PBox1";
            this.PBox1.TabStop = false;
            // 
            // Count_game
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PBox1);
            this.Controls.Add(this.Label_note);
            this.Controls.Add(this.label_sec);
            this.Controls.Add(this.label_min);
            this.Controls.Add(this.label_hour);
            this.Controls.Add(this.Label_day);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Count_game";
            this.ShowInTaskbar = false;
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Count_game_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.PBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Label_day;
        private System.Windows.Forms.Label label_hour;
        private System.Windows.Forms.Label label_min;
        private System.Windows.Forms.Label label_sec;
        private System.Windows.Forms.Label Label_note;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox PBox1;
    }
}

