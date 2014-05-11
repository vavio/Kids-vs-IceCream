namespace Kids_vs_IceCream
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timerMouseDown = new System.Windows.Forms.Timer(this.components);
            this.timerNextKid = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.levelLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.kidsKilledLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnHowToPlay = new Kids_vs_IceCream.RoundButton();
            this.btnHighScore = new Kids_vs_IceCream.RoundButton();
            this.btnNewGame = new Kids_vs_IceCream.RoundButton();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timerMouseDown
            // 
            this.timerMouseDown.Interval = 1000;
            this.timerMouseDown.Tick += new System.EventHandler(this.timerMouseDown_Tick);
            // 
            // timerNextKid
            // 
            this.timerNextKid.Tick += new System.EventHandler(this.timerNextKid_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.levelLabel,
            this.statusLabel,
            this.kidsKilledLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 391);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(698, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // levelLabel
            // 
            this.levelLabel.Name = "levelLabel";
            this.levelLabel.Size = new System.Drawing.Size(54, 17);
            this.levelLabel.Text = "levelLabel";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(62, 17);
            this.statusLabel.Text = "statusLabel";
            // 
            // kidsKilledLabel
            // 
            this.kidsKilledLabel.Name = "kidsKilledLabel";
            this.kidsKilledLabel.Size = new System.Drawing.Size(74, 17);
            this.kidsKilledLabel.Text = "kidsKilledLabel";
            // 
            // btnHowToPlay
            // 
            this.btnHowToPlay.BackColor = System.Drawing.Color.Wheat;
            this.btnHowToPlay.Location = new System.Drawing.Point(611, 318);
            this.btnHowToPlay.Name = "btnHowToPlay";
            this.btnHowToPlay.Size = new System.Drawing.Size(83, 74);
            this.btnHowToPlay.TabIndex = 2;
            this.btnHowToPlay.Text = "How to play";
            this.btnHowToPlay.UseVisualStyleBackColor = false;
            this.btnHowToPlay.Click += new System.EventHandler(this.btnHowToPlay_Click);
            this.btnHowToPlay.MouseEnter += new System.EventHandler(this.btnHowToPlay_MouseHover);
            this.btnHowToPlay.MouseLeave += new System.EventHandler(this.btnHowToPlay_MouseLeave);
            // 
            // btnHighScore
            // 
            this.btnHighScore.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.btnHighScore.Location = new System.Drawing.Point(553, 317);
            this.btnHighScore.Name = "btnHighScore";
            this.btnHighScore.Size = new System.Drawing.Size(86, 79);
            this.btnHighScore.TabIndex = 1;
            this.btnHighScore.Text = "HighScore";
            this.btnHighScore.UseVisualStyleBackColor = false;
            this.btnHighScore.Click += new System.EventHandler(this.btnHighScore_Click);
            this.btnHighScore.MouseEnter += new System.EventHandler(this.btnUpgrade_MouseHover);
            this.btnHighScore.MouseLeave += new System.EventHandler(this.btnUpgrade_MouseLeave);
            // 
            // btnNewGame
            // 
            this.btnNewGame.BackColor = System.Drawing.Color.Turquoise;
            this.btnNewGame.Location = new System.Drawing.Point(583, 266);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(82, 82);
            this.btnNewGame.TabIndex = 0;
            this.btnNewGame.Text = "New game";
            this.btnNewGame.UseVisualStyleBackColor = false;
            this.btnNewGame.Click += new System.EventHandler(this.btnNewGame_Click);
            this.btnNewGame.MouseEnter += new System.EventHandler(this.btnNewGame_MouseHover);
            this.btnNewGame.MouseLeave += new System.EventHandler(this.btnNewGame_MouseLeave);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(698, 413);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnHowToPlay);
            this.Controls.Add(this.btnHighScore);
            this.Controls.Add(this.btnNewGame);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Kids VS Ice cream";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public RoundButton btnNewGame;
        public RoundButton btnHighScore;
        public RoundButton btnHowToPlay;
        private System.Windows.Forms.Timer timerMouseDown;
        private System.Windows.Forms.Timer timerNextKid;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolStripStatusLabel kidsKilledLabel;
        private System.Windows.Forms.ToolStripStatusLabel levelLabel;



    }
}

