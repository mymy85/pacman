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
        //private Point[] Perimeter = new Point[12];
        //private Point[] Core = new Point[4];

        public Pacman(Point point, Direction direction) : base(point, direction)
        {
            Point = point;
            this.Direction = direction;
            perimeter(point);
            core(point);
        }
    }
    public class PacmanRun : CharacterRun
    {
        //public Point Point = new Point();
        public Direction pacmanDirection = Direction.STOP;
        private Direction pacmanNextDirection = Direction.STOP;

        /*Task là một lớp trong .NET framework được sử dụng để đại diện cho một công
        việc được thực hiện bất đồng bộ => tạo đối tượng PacmanRunner Task*/
        Task PacmanRunner;
        //private int _delay = 70;

        Pacman pacman;

        public GameState State = GameState.GAMEOVER;

        List<Point> wallList = new List<Point>();
        List<Point> boxDoorList = new List<Point>();

        //private Direction[] directions = new Direction[4];
        //private frmPacmanGame parentForm;
        //private PacmanBoard board;

        public PacmanRun(frmPacmanGame frm, PacmanBoard b) : base(frm, b)
        {
            parentForm = frm;
            board = b;
            this.Init();
        }

        //public int Delay
        //{
        //    get { return _delay; }
        //    set { _delay = (value < 10) ? 10 : value; }
        //}

        public override Point[] perimeter()
        {
            return pacman.perimeter(pacman.Point);
        }

        public override Point[] core()
        {
            return pacman.core(pacman.Point);
        }

        public override void Run()
        {
            State = GameState.GAMERUN;
            PacmanRunner = new Task(runPacman);
            /*để bắt đầu thực hiện một Task, gọi phương thức Start()*/
            PacmanRunner.Start();   
        }

        protected override void Init()
        {
            boxDoorList = PointLists.BoxDoorPointList();
            wallList = PointLists.BanPointList();
            /*Phương thức OrderBy trả về một chuỗi mới chứa các phần tử được sắp xếp theo thứ tự tăng dần của X, 
             và phương thức ThenBy sắp xếp các phần tử có cùng giá trị X theo thứ tự tăng dần của Y.*/
            wallList.OrderBy(p => p.X).ThenBy(p => p.Y);
            /*khởi tạo đối tượng pacman mới để được đặt lại vị trí ban đầu (26, 39) và với 
             hướng di chuyển được xác định bởi biến 'pacmanDirection'*/
            pacman = new Pacman(new Point(26, 39), pacmanDirection);
        }

        public override void reset() //khởi động lại trò chơi
        {
            
            board.ClearPacMan(pacman.Point);
            pacman = new Pacman(new Point(26, 39), Direction.STOP);
        }

        private  void runPacman()
        {
            
            while(State != GameState.GAMEOVER)
            {
                try
                {
                    this.Point = pacman.Point;
                    board.ClearPacMan(pacman.Point);
                    pacman = pacmanMove(pacman.Point, pacmanDirection);
                    board.DrawPacMan(pacman.Point, Color.Yellow, pacman.Direction);
                    PacmanRunner.Wait(_delay);
                }
                catch(Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private Pacman pacmanMove(Point StartPoint, Direction d)
        {
            bool pass = false;
            Point nextP;
            bool conflictCheck;
            if(State != GameState.GAMERUN)
            {
                return new Pacman(StartPoint, d);
            }
            foreach(Direction direction in directions){
                nextP = nextPoint(StartPoint, direction);
                conflictCheck = collisionCheck(nextP);

                if(conflictCheck && direction == pacmanNextDirection)
                {
                    pacmanDirection = pacmanNextDirection;
                    pacmanNextDirection = Direction.STOP;
                    return new Pacman(nextP, pacmanNextDirection);
                }
                else if(conflictCheck && direction == d)
                {
                    pass = true;
                }
            }
            if (pass) return new Pacman(nextPoint(StartPoint, d), d);
            else return new Pacman(StartPoint, d);
        }
        //kiểm tra có sự va chạm giữa Pacman và Ghost và các điểm boxDoorList và wallList
        //trả về true nếu không có va chạm, ngược lại trả về false
        private bool collisionCheck(Point P)
        {
            Pacman Ghost = new Pacman(P, Direction.STOP);
            List<Point> mergedList = new List<Point>();
            mergedList = boxDoorList.Union(wallList).ToList(); //tạo danh sách mới bằng cách hợp nhất boxDoorList và wallList, tạp ra một danh sách chứa tất cả các điểm đại diện cho cửa và tường

            //kiểm tra va chạm
            //gọi phương thức perimeter của Ghost để lấy danh sách các điểm tạo thành vùng biên của Ghost.
            //Sử dụng phương thức Intersect để lấy danh sách các điểm chung giữa vùng biên của Ghost và danh sách hợp nhất mergedList.
            //Nếu danh sách commonPoints có ít nhất một điểm chung, có nghĩa là có va chạm, và phương thức trả về false.
            List<Point> commonPoints = Ghost.perimeter(P).Intersect(mergedList.Select(u => u)).ToList();
            return (commonPoints.Count == 0);
        }

        public void setDirection(Direction d)
        {
            if (collisionCheck(nextPoint((pacman.Point), d)))
            {
                pacmanDirection = d;
                pacman.Direction = d;
                Debug.WriteLine("Passed : " + d);
            }
            else
            {
                pacmanNextDirection = d;
                Debug.WriteLine("Wait : " + d);
            }
        }
    }
}
