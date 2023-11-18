using System.Windows.Forms;
using System.Drawing;
using System;
using PacmanWinForms;

public delegate void GhostPaint(Point point, Direction D, GhostColor color, bool sprite1, GhostState state);

namespace PacmanWinForms
{
    public class PacmanBoard
    {
        public int Rows;
        public int Cols;
        public Color BgColor;

        private Panel pnl;
        private Graphics g;
        private Control.ControlCollection c;
        private float cellHeight;
        private float cellWidth;
        private int state = 1;

        PictureBox picRedGhost;
        PictureBox picBlueGhost;
        PictureBox picPinkGhost;
        PictureBox picYellowGhost;

        public PacmanBoard(Panel pnl, int rows = 62, int cols = 56, Color? bgColor = null)
        {
            this.Rows = rows;
            this.Cols = cols;
            this.BgColor = bgColor ?? Color.Black;
            this.pnl = pnl;
        }

        public void Resize()
        {
            cellHeight = pnl.Height / (float)Rows;
            cellWidth = pnl.Width / (float)Cols;

            g = pnl.CreateGraphics();
            c = pnl.Controls;
        }

        public void Clear()
        {
            // Empty function body
        }

        public void DrawRect(Point p, Color col)
        {
            // Empty function body
        }

        public void DrawDoor(Point p, Color col)
        {
            // Empty function body
        }

        public void DrawDot(Point p, Color col)
        {
            // Empty function body
        }

        public void DrawBonus(Point p, Color col, int bonusState)
        {
            // Empty function body
        }

        public void ClearBonus(Point p)
        {
            // Empty function body
        }

        public void GhostMove(Point P, Direction D, GhostColor color, bool sprite1, GhostState state)
        {
            pnl.Invoke(new GhostPaint(changePic), P, D, color, sprite1, state);
        }

        private Bitmap findImage(Direction D, GhostColor color, bool sprite1, GhostState state)
        {
            // Empty function body
            return null;
        }

        private void changePic(Point P, Direction D, GhostColor color, bool sprite1, GhostState state)
        {
            // Empty function body
        }

        public void DrawPacMan(int x, int y, Color color, Direction dir)
        {
            // Empty function body
        }

        public void DrawPacMan(Point p, Color color, Direction dir)
        {
            // Empty function body
        }

        public void ClearPacMan(Point p)
        {
            // Empty function body
        }
    }
}
