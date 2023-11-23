using PacmanWinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PacmanGaneWF
{
    public partial class frmPacmanGame : Form
    {
        PacmanGame game = null;
        public frmPacmanGame()
        {
            InitializeComponent();
        }
        private void frmPacmanGame_Load(object sender, EventArgs e)
        {
            game = new PacmanGame(this, pnlBoard);
            playSound(Properties.Resources.Pacman_Opening_Song);
            //posSizeInit()
            game.State = GameState.GAMEPAUSE;
            
        }
        private void frmPacmanGame_KeyDown(object sender, KeyEventArgs e)
        {
            if (game == null) return;
            if(e.KeyCode == Keys.Left)
            {
                game.setDirection(Direction.LEFT);
            }
            else if(e.KeyCode == Keys.Right)
            {
                game.setDirection(Direction.RIGHT);
            }
            else if(e.KeyCode == Keys.Up)
            {
                game.setDirection(Direction.UP);
            }
            else if(e.KeyCode == Keys.Down)
            {
                game.setDirection(Direction.DOWN);
            }
            else if(e.KeyCode == Keys.F1) { game.cheat(); }
            else if(e.KeyCode == Keys.Subtract)
            {
                game.PacmanDelay += 5;
                game.GhostDelay += 5;
            }
            else if(e.KeyCode == Keys.Add)
            {
                game.PacmanDelay -= 5;
                game.GhostDelay -= 5;
            }
            else if(e.KeyCode == Keys.P || e.KeyCode == Keys.Space)
            {
                if(game.State == GameState.GAMERUN)
                {
                    game.Pause();
                }
                else if(game.State == GameState.GAMEPAUSE)
                {
                    game.Continue();
                }
            }

        }
        private void posSizeInit()
        {
            pnlLvl.Location = new Point((pnlDisplay.Width - pnlLvl.Width) / 2, 0);
            pnlHighScore.Location = new Point(pnlLvl.Location.X + 78 + 50, 0);
            pnlSc.Location = new Point(pnlLvl.Location.X - 78 - 50, 0);
            lblScore.Location = new Point((pnlSc.Width - lblScore.Width) / 2, lblLVL.Height + 20);
            lblLVLValue.Location = new Point((pnlSc.Width - lblLVLValue.Width) / 2, lblLVL.Height + 20);
            lblHScoreValue.Location = new Point((pnlSc.Width - lblHScoreValue.Width) / 2, lblLVL.Height + 20);
            pnlDisplay.Location = new Point((this.ClientRectangle.Width - pnlDisplay.Width) / 2, 0);
        }
        public void playSound(Stream stream)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<Stream>(playSound), new object[] { stream });
                return;
            }
            //SoundPlayer là đối tượng được cung cấp sẵn trong namespace .NET media
            SoundPlayer player = new SoundPlayer();
            player.Play();
        }
        //private async void frmPacmanGame_FormClosing
        private async void frmPacmanGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (game == null) return;
            game.Stop();
            if (!game.Runner.IsCompleted)//check the task of game.Runner is completed or not
            {
                //có nên bỏ if RELESE không
#if RELESE
                this.Hide();
#endif
                e.Cancel = true;
                await game.Runner;
                this.Close();
            }
        }
        private void frmPacmanGame_Activated(object sender, EventArgs e)
        {
            if(game == null) return;
            game.RePaint(); //làm mới giao diện trò chơi
            game.Continue();//tiếp tục chơi sau khi form được kích hoạt
        }
        private void frmPacmanGame_Deactivate(object sender, EventArgs e)
        {
            if(game == null) return;
            game.Pause(); //tạm dừng khi form mất trạng thái kích hoạt
        }
        //frmPacmanGame_Paint was use when Form need to draw back again
        private void frmPacmanGame_Paint(object sender, PaintEventArgs e)
        {
            game.RePaint();
        }
        private void frmPacmanGame_Resize(object sender, EventArgs e)
        {
            this.Height = (int)(1.25 * this.Width);
            if(game == null) return;
            game.RePaint();
            posSizeInit();
        }
        public void Write()
        {

        }
        private void frmPacmanGame_Shown(object sender, EventArgs e)
        {
            if(game == null) return;
            game.Run();
            game.State = GameState.GAMEPAUSE;
        }
    }
}
