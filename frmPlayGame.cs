using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PacmanGaneWF
{
    public partial class frmPlayGame : Form
    {
        public frmPlayGame()
        {
            InitializeComponent();
        }

        private void bnsStart_Click(object sender, EventArgs e)
        {
            frmPacmanGame frgame = new frmPacmanGame();
            //đặt form ra chính giữa màn hình
            frgame.StartPosition = FormStartPosition.CenterScreen;
            //đặt chiều cao của form bằng chiều cao của màn hình chính
            frgame.Height = Screen.PrimaryScreen.Bounds.Height;
            frgame.Show();
        }
    }
}
