namespace PacmanGaneWF
{
    partial class frmPlayGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPlayGame));
            this.bnsStart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bnsStart
            // 
            this.bnsStart.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.bnsStart.BackColor = System.Drawing.Color.Cyan;
            this.bnsStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnsStart.ForeColor = System.Drawing.Color.Black;
            this.bnsStart.Location = new System.Drawing.Point(214, 274);
            this.bnsStart.Margin = new System.Windows.Forms.Padding(4);
            this.bnsStart.Name = "bnsStart";
            this.bnsStart.Size = new System.Drawing.Size(189, 55);
            this.bnsStart.TabIndex = 3;
            this.bnsStart.Text = "Start Game";
            this.bnsStart.UseVisualStyleBackColor = false;
            this.bnsStart.Click += new System.EventHandler(this.bnsStart_Click);
            // 
            // frmPlayGame
            // 
            this.AcceptButton = this.bnsStart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::PacmanGaneWF.Properties.Resources.interfacePM;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(603, 404);
            this.Controls.Add(this.bnsStart);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(621, 451);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(621, 451);
            this.Name = "frmPlayGame";
            this.Text = "Pacman";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bnsStart;
    }
}

