namespace Doom
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
            this.txtFood = new System.Windows.Forms.Label();
            this.txtScore = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.healthBar = new System.Windows.Forms.ProgressBar();
            this.player = new System.Windows.Forms.PictureBox();
            this.GameTimer = new System.Timers.Timer();
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GameTimer)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFood
            // 
            this.txtFood.Font = new System.Drawing.Font("Consolas", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtFood.ForeColor = System.Drawing.Color.Black;
            this.txtFood.Location = new System.Drawing.Point(20, 18);
            this.txtFood.Name = "txtFood";
            this.txtFood.Size = new System.Drawing.Size(151, 36);
            this.txtFood.TabIndex = 0;
            this.txtFood.Text = "Еда: 0";
            // 
            // txtScore
            // 
            this.txtScore.Font = new System.Drawing.Font("Consolas", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtScore.ForeColor = System.Drawing.Color.Black;
            this.txtScore.Location = new System.Drawing.Point(232, 18);
            this.txtScore.Name = "txtScore";
            this.txtScore.Size = new System.Drawing.Size(212, 36);
            this.txtScore.TabIndex = 1;
            this.txtScore.Text = "Убийства: 0";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Consolas", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(495, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 36);
            this.label1.TabIndex = 2;
            this.label1.Text = "Здоровье:";
            // 
            // healthBar
            // 
            this.healthBar.Location = new System.Drawing.Point(657, 21);
            this.healthBar.Name = "healthBar";
            this.healthBar.Size = new System.Drawing.Size(250, 32);
            this.healthBar.TabIndex = 3;
            this.healthBar.Value = 100;
            // 
            // player
            // 
            this.player.Image = global::Doom.Properties.Resources.right;
            this.player.Location = new System.Drawing.Point(470, 564);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(60, 60);
            this.player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.player.TabIndex = 4;
            this.player.TabStop = false;
            // 
            // GameTimer
            // 
            this.GameTimer.Enabled = true;
            this.GameTimer.Interval = 20D;
            this.GameTimer.SynchronizingObject = this;
            this.GameTimer.Elapsed += new System.Timers.ElapsedEventHandler(this.MainTimerEvent);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.player);
            this.Controls.Add(this.healthBar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtScore);
            this.Controls.Add(this.txtFood);
            this.Name = "Form1";
            this.Text = "HTML Shooter";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyIsDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyIsUp);
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GameTimer)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Timers.Timer GameTimer;

        private System.Windows.Forms.PictureBox player;

        private System.Windows.Forms.ProgressBar healthBar;

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.Label txtFood;

        private System.Windows.Forms.Label txtScore;

        #endregion
    }
}