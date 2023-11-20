using PacmanGaneWF;
using PacmanWinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Pacman_Game.Class
{
    public class Ghost : Character
    {
        public Point Point { get; set; }
        public Direction Direction { get; set; }
        private Point[] Perimeter = new Point[12];
        private Point[] Core = new Point[4];
        public Ghost(Point point, Direction direction) : base(point, direction)
        {
            Point = point;
            Direction = direction;
        }
    }
    public class GhostRun : CharacterRun
    {
        public Direction ghostDirection { get; set; }
        Task ghostRunner;
        public GhostState ghostState { set; get; }
        public bool collision { get; set; }
        private GhostColor color;
        Ghost ghost;

        List<Point> boxList = new List<Point>();
        public GhostRun(frmPacmanGame frm, PacmanBoard b, GhostColor color) : base(frm, b)
        {
            // Initialization specific to GhostRun
            this.color = color;
            parentForm = frm;
            board = b;
            //this.Init();
        }

        // Override necessary methods from Character class
        public Point[] Perimeter()
        {
            return ghost.perimeter(ghost.Point);
        }

        public Point[] Core()
        {
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

        public void setTarget()
        {
            // Leave this function blank
        }

        bool sprite1 = true;
        private void runghost()
        {
            // Leave this function blank
        }

        private void changeWait()
        {
            // Leave this function blank
        }

        private Ghost ghostMove(Point StartPoint, Direction d)
        {
            // Leave this function blank
            return null;
        }

        private List<Direction> possibleDirections(Point P, Direction curDir)
        {
            // Leave this function blank
            return null;
        }

        private bool outOfBox(Point P)
        {
            // Leave this function blank
            return false;
        }

        private bool checkForConflict(Point P, Point PrevP)
        {
            // Leave this function blank
            return false;
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

        public void RePaint()
        {
            // Leave this function blank
        }
    }
}
