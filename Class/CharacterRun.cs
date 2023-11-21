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
    public abstract class CharacterRun
    {
        protected Point Point = new Point();
        protected int _delay = 70;
        Pacman pacman;
        private GameState State = GameState.GAMEOVER;
        List<Point> wallList = new List<Point>();
        List<Point> boxDoorList = new List<Point>();
        protected Direction[] directions = new Direction[4];
        protected frmPacmanGame parentForm;
        protected PacmanBoard board;
        
        public int Delay
        {
            get { return _delay; }
            set { _delay = (value < 10) ? 10 : value; }
        }
        public CharacterRun(frmPacmanGame frm, PacmanBoard b)
        {
            parentForm = frm;
            board = b;
            this.Init();
        }

        public abstract Point[] perimeter();

        public abstract Point[] core();

        public virtual void Run()
        {
            State = GameState.GAMERUN;
        }
        //public void setDirection(Direction d)
        //{
            
        //}
        public abstract void reset();
        protected virtual void Init()
        {
            boxDoorList = PointLists.BoxDoorPointList();
            wallList = PointLists.BanPointList();
            /*Phương thức OrderBy trả về một chuỗi mới chứa các phần tử được sắp xếp theo thứ tự tăng dần của X, 
             và phương thức ThenBy sắp xếp các phần tử có cùng giá trị X theo thứ tự tăng dần của Y.*/
            wallList.OrderBy(p => p.X).ThenBy(p => p.Y);
        }
        protected Point nextPoint(Point P, Direction D)
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
        protected void directionsInit()
        {
            directions[0] = Direction.UP;
            directions[1] = Direction.RIGHT;
            directions[2] = Direction.DOWN;
            directions[3] = Direction.LEFT;
        }
    }
}
