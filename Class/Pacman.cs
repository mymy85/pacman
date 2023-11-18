using Pacman_Game;
using Pacman_Game.Class;
//using PacmanGaneWF.Class;
using PacmanGaneWF;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PacmanWinForms
{
    public class Pacman : Character
    {
        public Point Point { get; set; }
        public Direction Direction { get; set; }
        private Point[] Perimeter = new Point[12];
        private Point[] Core = new Point[4];

        public Pacman(Point point, Direction direction) : base(point, direction)
        {
            this.Point = point;
            this.Direction = direction;
            perimeter(point);
            core(point);
        }
    }
    public class PacmanRun : CharacterRun
    {
        public Point Point = new Point();
        public Direction pacmanDirection = Direction.STOP;
        private Direction pacmanNextDirection = Direction.STOP;
        Task PacmanRunner;
        private int _delay = 70;

        Pacman pacman;

        public GameState State = GameState.GAMEOVER;

        List<Point> wallList = new List<Point>();
        List<Point> boxDoorList = new List<Point>();

        private Direction[] directions = new Direction[4];
        private frmPacmanGame parentForm;
        private PacmanBoard board;

        public PacmanRun(frmPacmanGame frm, PacmanBoard b) : base(frm, b)
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

        public Point[] perimeter()
        {
            // Leave this function blank
            return null;
        }

        public Point[] core()
        {
            // Leave this function blank
            return null;
        }

        public void Run()
        {
            // Leave this function blank
        }

        private void Init()
        {
            // Leave this function blank
        }

        public void reset()
        {
            // Leave this function blank
        }

        private void runPacman()
        {
            // Leave this function blank
        }

        private Pacman pacmanMove(Point StartPoint, Direction d)
        {
            // Leave this function blank
            return null;
        }

        private bool collisionCheck(Point P)
        {
            // Leave this function blank
            return false;
        }

        public void setDirection(Direction d)
        {
            // Leave this function blank
        }

        private Point nextPoint(Point P, Direction D)
        {
            // Leave this function blank
            return new Point();
        }

        private void directionsInit()
        {
            // Leave this function blank
        }
    }
}
