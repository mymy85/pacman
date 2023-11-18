namespace PacmanGaneWF
{
    partial class frmPacmanGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPacmanGame));
            this.pnlSc = new System.Windows.Forms.Panel();
            this.lblLScore = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.pnlLvl = new System.Windows.Forms.Panel();
            this.lblLVL = new System.Windows.Forms.Label();
            this.lblLVLValue = new System.Windows.Forms.Label();
            this.pnlHighScore = new System.Windows.Forms.Panel();
            this.lblHightScore = new System.Windows.Forms.Label();
            this.lblHScoreValue = new System.Windows.Forms.Label();
            this.pnlBoard = new System.Windows.Forms.Panel();
            this.lblPosition = new System.Windows.Forms.Label();
            this.lblGhostDelay = new System.Windows.Forms.Label();
            this.lblDelay = new System.Windows.Forms.Label();
            this.tmrClock = new System.Windows.Forms.Timer(this.components);
            this.pnlSc.SuspendLayout();
            this.pnlLvl.SuspendLayout();
            this.pnlHighScore.SuspendLayout();
            this.pnlBoard.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSc
            // 
            this.pnlSc.Controls.Add(this.lblLScore);
            this.pnlSc.Controls.Add(this.lblScore);
            this.pnlSc.Location = new System.Drawing.Point(103, 1);
            this.pnlSc.Margin = new System.Windows.Forms.Padding(4);
            this.pnlSc.Name = "pnlSc";
            this.pnlSc.Size = new System.Drawing.Size(109, 71);
            this.pnlSc.TabIndex = 17;
            // 
            // lblLScore
            // 
            this.lblLScore.AutoSize = true;
            this.lblLScore.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblLScore.ForeColor = System.Drawing.Color.White;
            this.lblLScore.Location = new System.Drawing.Point(16, 25);
            this.lblLScore.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLScore.Name = "lblLScore";
            this.lblLScore.Size = new System.Drawing.Size(70, 23);
            this.lblLScore.TabIndex = 2;
            this.lblLScore.Text = "Score";
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblScore.ForeColor = System.Drawing.Color.White;
            this.lblScore.Location = new System.Drawing.Point(43, 48);
            this.lblScore.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(22, 23);
            this.lblScore.TabIndex = 3;
            this.lblScore.Text = "0";
            this.lblScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlLvl
            // 
            this.pnlLvl.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pnlLvl.Controls.Add(this.lblLVL);
            this.pnlLvl.Controls.Add(this.lblLVLValue);
            this.pnlLvl.Location = new System.Drawing.Point(293, 1);
            this.pnlLvl.Margin = new System.Windows.Forms.Padding(4);
            this.pnlLvl.Name = "pnlLvl";
            this.pnlLvl.Size = new System.Drawing.Size(109, 71);
            this.pnlLvl.TabIndex = 18;
            // 
            // lblLVL
            // 
            this.lblLVL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLVL.AutoSize = true;
            this.lblLVL.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblLVL.ForeColor = System.Drawing.Color.White;
            this.lblLVL.Location = new System.Drawing.Point(16, 25);
            this.lblLVL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLVL.Name = "lblLVL";
            this.lblLVL.Size = new System.Drawing.Size(70, 23);
            this.lblLVL.TabIndex = 4;
            this.lblLVL.Text = "Level";
            // 
            // lblLVLValue
            // 
            this.lblLVLValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLVLValue.AutoSize = true;
            this.lblLVLValue.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblLVLValue.ForeColor = System.Drawing.Color.White;
            this.lblLVLValue.Location = new System.Drawing.Point(39, 48);
            this.lblLVLValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLVLValue.Name = "lblLVLValue";
            this.lblLVLValue.Size = new System.Drawing.Size(22, 23);
            this.lblLVLValue.TabIndex = 5;
            this.lblLVLValue.Text = "1";
            // 
            // pnlHighScore
            // 
            this.pnlHighScore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlHighScore.Controls.Add(this.lblHightScore);
            this.pnlHighScore.Controls.Add(this.lblHScoreValue);
            this.pnlHighScore.Location = new System.Drawing.Point(489, 1);
            this.pnlHighScore.Margin = new System.Windows.Forms.Padding(4);
            this.pnlHighScore.Name = "pnlHighScore";
            this.pnlHighScore.Size = new System.Drawing.Size(109, 71);
            this.pnlHighScore.TabIndex = 19;
            // 
            // lblHightScore
            // 
            this.lblHightScore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHightScore.AutoSize = true;
            this.lblHightScore.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblHightScore.ForeColor = System.Drawing.Color.White;
            this.lblHightScore.Location = new System.Drawing.Point(16, 25);
            this.lblHightScore.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHightScore.Name = "lblHightScore";
            this.lblHightScore.Size = new System.Drawing.Size(70, 23);
            this.lblHightScore.TabIndex = 6;
            this.lblHightScore.Text = "Lives";
            // 
            // lblHScoreValue
            // 
            this.lblHScoreValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHScoreValue.AutoSize = true;
            this.lblHScoreValue.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblHScoreValue.ForeColor = System.Drawing.Color.White;
            this.lblHScoreValue.Location = new System.Drawing.Point(43, 48);
            this.lblHScoreValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHScoreValue.Name = "lblHScoreValue";
            this.lblHScoreValue.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblHScoreValue.Size = new System.Drawing.Size(22, 23);
            this.lblHScoreValue.TabIndex = 7;
            this.lblHScoreValue.Text = "3";
            // 
            // pnlBoard
            // 
            this.pnlBoard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBoard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlBoard.Controls.Add(this.lblPosition);
            this.pnlBoard.Controls.Add(this.lblGhostDelay);
            this.pnlBoard.Controls.Add(this.lblDelay);
            this.pnlBoard.Location = new System.Drawing.Point(10, 76);
            this.pnlBoard.Margin = new System.Windows.Forms.Padding(4);
            this.pnlBoard.Name = "pnlBoard";
            this.pnlBoard.Size = new System.Drawing.Size(696, 709);
            this.pnlBoard.TabIndex = 20;
            // 
            // lblPosition
            // 
            this.lblPosition.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblPosition.AutoSize = true;
            this.lblPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblPosition.ForeColor = System.Drawing.Color.White;
            this.lblPosition.Location = new System.Drawing.Point(277, 695);
            this.lblPosition.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(14, 13);
            this.lblPosition.TabIndex = 1;
            this.lblPosition.Text = "0";
            // 
            // lblGhostDelay
            // 
            this.lblGhostDelay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGhostDelay.AutoSize = true;
            this.lblGhostDelay.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblGhostDelay.ForeColor = System.Drawing.Color.White;
            this.lblGhostDelay.Location = new System.Drawing.Point(544, 695);
            this.lblGhostDelay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGhostDelay.Name = "lblGhostDelay";
            this.lblGhostDelay.Size = new System.Drawing.Size(14, 13);
            this.lblGhostDelay.TabIndex = 15;
            this.lblGhostDelay.Text = "0";
            // 
            // lblDelay
            // 
            this.lblDelay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDelay.AutoSize = true;
            this.lblDelay.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.lblDelay.ForeColor = System.Drawing.Color.White;
            this.lblDelay.Location = new System.Drawing.Point(13, 695);
            this.lblDelay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDelay.Name = "lblDelay";
            this.lblDelay.Size = new System.Drawing.Size(14, 13);
            this.lblDelay.TabIndex = 14;
            this.lblDelay.Text = "0";
            // 
            // tmrClock
            // 
            this.tmrClock.Enabled = true;
            // 
            // frmPacmanGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(719, 815);
            this.Controls.Add(this.pnlBoard);
            this.Controls.Add(this.pnlHighScore);
            this.Controls.Add(this.pnlLvl);
            this.Controls.Add(this.pnlSc);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(394, 451);
            this.Name = "frmPacmanGame";
            this.Text = "Pacman";
            this.Activated += new System.EventHandler(this.frmPacmanGame_Activated);
            this.Deactivate += new System.EventHandler(this.frmPacmanGame_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPacmanGame_FormClosing);
            this.Load += new System.EventHandler(this.frmPacmanGame_Load);
            this.Shown += new System.EventHandler(this.frmPacmanGame_Shown);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmPacmanGame_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPacmanGame_KeyDown);
            this.Resize += new System.EventHandler(this.frmPacmanGame_Resize);
            this.pnlSc.ResumeLayout(false);
            this.pnlSc.PerformLayout();
            this.pnlLvl.ResumeLayout(false);
            this.pnlLvl.PerformLayout();
            this.pnlHighScore.ResumeLayout(false);
            this.pnlHighScore.PerformLayout();
            this.pnlBoard.ResumeLayout(false);
            this.pnlBoard.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSc;
        private System.Windows.Forms.Label lblLScore;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Panel pnlLvl;
        private System.Windows.Forms.Label lblLVL;
        private System.Windows.Forms.Label lblLVLValue;
        private System.Windows.Forms.Panel pnlHighScore;
        private System.Windows.Forms.Label lblHightScore;
        private System.Windows.Forms.Label lblHScoreValue;
        private System.Windows.Forms.Panel pnlBoard;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.Label lblGhostDelay;
        private System.Windows.Forms.Label lblDelay;
        private System.Windows.Forms.Timer tmrClock;
    }
}