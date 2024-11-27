namespace Flappy_Bird
{
    partial class Form1
    {
        /// <summary>
        /// </summary>
        private System.ComponentModel.IContainer components = null;

      
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
      
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.scoreLabel = new System.Windows.Forms.Label();
            this.scoreText = new System.Windows.Forms.Label();
            this.birdPlayer = new System.Windows.Forms.PictureBox();
            this.ground = new System.Windows.Forms.PictureBox();
            this.obstacleBottom = new System.Windows.Forms.PictureBox();
            this.obstacleTop = new System.Windows.Forms.PictureBox();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.birdPlayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ground)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.obstacleBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.obstacleTop)).BeginInit();
            this.SuspendLayout();
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.scoreLabel.Location = new System.Drawing.Point(32, 66);
            this.scoreLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(57, 24);
            this.scoreLabel.TabIndex = 0;
            this.scoreLabel.Text = "Score:";
            // 
            // scoreText
            // 
            this.scoreText.AutoSize = true;
            this.scoreText.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.scoreText.Location = new System.Drawing.Point(188, 66);
            this.scoreText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.scoreText.Name = "scoreText";
            this.scoreText.Size = new System.Drawing.Size(19, 24);
            this.scoreText.TabIndex = 1;
            this.scoreText.Text = "0";
            // 
            // birdPlayer
            // 
            this.birdPlayer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("birdPlayer.BackgroundImage")));
            this.birdPlayer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.birdPlayer.Location = new System.Drawing.Point(84, 246);
            this.birdPlayer.Margin = new System.Windows.Forms.Padding(4);
            this.birdPlayer.Name = "birdPlayer";
            this.birdPlayer.Size = new System.Drawing.Size(60, 50);
            this.birdPlayer.TabIndex = 2;
            this.birdPlayer.TabStop = false;
            // 
            // ground
            // 
            this.ground.Location = new System.Drawing.Point(-8, 514);
            this.ground.Margin = new System.Windows.Forms.Padding(4);
            this.ground.Name = "ground";
            this.ground.Size = new System.Drawing.Size(1085, 47);
            this.ground.TabIndex = 3;
            this.ground.TabStop = false;
            // 
            // obstacleBottom
            // 
            this.obstacleBottom.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("obstacleBottom.BackgroundImage")));
            this.obstacleBottom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.obstacleBottom.Location = new System.Drawing.Point(459, 378);
            this.obstacleBottom.Margin = new System.Windows.Forms.Padding(4);
            this.obstacleBottom.Name = "obstacleBottom";
            this.obstacleBottom.Size = new System.Drawing.Size(88, 183);
            this.obstacleBottom.TabIndex = 5;
            this.obstacleBottom.TabStop = false;
            // 
            // obstacleTop
            // 
            this.obstacleTop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("obstacleTop.BackgroundImage")));
            this.obstacleTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.obstacleTop.Location = new System.Drawing.Point(456, -3);
            this.obstacleTop.Margin = new System.Windows.Forms.Padding(4);
            this.obstacleTop.Name = "obstacleTop";
            this.obstacleTop.Size = new System.Drawing.Size(91, 167);
            this.obstacleTop.TabIndex = 6;
            this.obstacleTop.TabStop = false;
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 10;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(32, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 24);
            this.label1.TabIndex = 7;
            this.label1.Text = "En yüksek skor";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(188, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 24);
            this.label2.TabIndex = 8;
            this.label2.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(660, 554);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.obstacleBottom);
            this.Controls.Add(this.ground);
            this.Controls.Add(this.birdPlayer);
            this.Controls.Add(this.scoreText);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.obstacleTop);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Flappy Bird";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.birdPlayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ground)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.obstacleBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.obstacleTop)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Label scoreText; 
        private System.Windows.Forms.PictureBox birdPlayer;
        private System.Windows.Forms.PictureBox ground; 
        private System.Windows.Forms.PictureBox obstacleBottom;
        private System.Windows.Forms.PictureBox obstacleTop;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
