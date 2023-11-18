//using PacmanGaneWF.Class;
using PacmanGaneWF;
using PacmanWinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman_Game.Class
{
    public class CharacterRun
    {
        private Point Point = new Point();
        private int _delay = 70;
        Pacman pacman;
        private GameState State = GameState.GAMEOVER;
        List<Point> wallList = new List<Point>();
        List<Point> boxDoorList = new List<Point>();
        private Direction[] directions = new Direction[4];
        protected frmPacmanGame parentForm;
        protected PacmanBoard board;
        public CharacterRun(frmPacmanGame frm, PacmanBoard b)
        {
            parentForm = frm;
            board = b;
            this.Init();
        }
        public int Delay
        {
            get { return _delay; }
            set { _delay = (value < 10) ? 10 : value; }
        }

        public virtual void Run()
        {
            State = GameState.GAMERUN;
        }
        private void Init()
        {
            boxDoorList = PointLists.BoxDoorPointList();
            wallList = PointLists.BanPointList();
            wallList.OrderBy(p => p.X).ThenBy(p => p.Y);
        }
        private Point nextPoint(Point P, Direction D)
        {
            Point nextP = new Point();
            nextP = P;
            switch (D)
            {
                case Direction.UP:
                    nextP.Y--;
                    break;
                case Direction.DOWN:
                    nextP.Y++;
                    break;
                case Direction.RIGHT:
                    nextP.X++;
                    break;
                case Direction.LEFT:
                    nextP.X--;
                    break;
                case Direction.STOP:

                    break;
            }
            return nextP;
        }
        private void directionsInit()
        {
            directions[0] = Direction.UP;
            directions[1] = Direction.RIGHT;
            directions[2] = Direction.DOWN;
            directions[3] = Direction.LEFT;
        }
    }
}
