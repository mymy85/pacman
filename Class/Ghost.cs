//using PacmanGaneWF.Class;
using PacmanGaneWF;
using PacmanWinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman_Game.Class
{
    public class Ghost : Character
    {
        public Point Point { get; set; }
        public Direction Direction { get; set; }
        //private Point[] Perimeter = new Point[12];
        //private Point[] Core = new Point[4];
        public Ghost(Point point, Direction direction) : base(point, direction)
        {
            this.Point = point;
            this.Direction = direction;
        }
    }
    public class GhostRun : CharacterRun
    {
        private Direction ghostDirection { get; set; }
        Task ghostRunner;
        private GhostState gState { set; get; }
        private bool collision { get; set; }
        private GhostColor color;
        Ghost ghost;

        List<Point> wallList = new List<Point>();
        List<Point> boxDoorList = new List<Point>();
        List<Point> boxList = new List<Point>();

        public GameState State = GameState.GAMEOVER;
        public GhostRun(frmPacmanGame frm, PacmanBoard b, GhostColor color) : base(frm, b)
        {
            // Initialization specific to GhostRun
            this.color = color;
            parentForm = frm;
            board = b;
            this.Init();
        }

        // Override necessary methods from Character class
        public override Point[] perimeter()
        {
            return ghost.perimeter(ghost.Point);
        }

        public override Point[] core()
        {
            //kiểm tra trạng thái của ghost, nếu ghost bị ăn nó sẽ được đặt ở 1 vị trí đặc biệt
            if (gState == GhostState.EATEN) return ghost.core(new Point(-10, -10));
            //nếu không bị ăn, ghost sẽ sử dụng vị trí khác được xác định bởi 'ghost.Point'
            else return ghost.core(ghost.Point);
        }

        public override void Run()
        {
            State = GameState.GAMERUN;
            ghostRunner = new Task(runghost);
            ghostRunner.Start();
        }
        //thiết lập đối tượng ghost
        protected override void Init()
        {
            boxDoorList = PointLists.BoxDoorPointList();
            wallList = PointLists.BanPointList();
            //dùng OrderBy sắp xếp các điểm (wallList) theo trục X tăng dần(các điểm có giá trị X nhỏ hơn sẽ xuất hiện trước trong danh sách)
            //dùng ThenBy sắp xếp theo trục Y tăng dần(trường hợp này xảy ra khi các điểm X có giá trị giống nhau, thí sẽ sắp xếp theo trục Y)
            wallList.OrderBy(p => p.X).ThenBy(p => p.Y);
            boxList = PointLists.BoxPointList();
            directionsInit();
            gState = GhostState.NORMAL;
            switch (color)
            {
                case GhostColor.BLUE:
                    ghost = new Ghost(new Point(30, 28), Direction.UP);
                    break;
                case GhostColor.PINK:
                    ghost = new Ghost(new Point(26, 28), Direction.DOWN);
                    break;
                case GhostColor.RED:
                    ghost = new Ghost(new Point(26, 21), Direction.RIGHT);
                    break;
                case GhostColor.YELLOW:
                    ghost = new Ghost(new Point(22, 28), Direction.UP);
                    break;
            }
            State = GameState.GAMEOVER;
        }

        public override void reset()
        {
            gState = GhostState.NORMAL;
            switch(color)
            {
                case GhostColor.BLUE:
                    ghost = new Ghost(new Point(30, 28), Direction.UP);
                    break;
                case GhostColor.PINK:
                    ghost = new Ghost(new Point(26, 28), Direction.DOWN);
                    break;
                case GhostColor.RED:
                    ghost = new Ghost(new Point(26, 21), Direction.RIGHT);
                    break;
                case GhostColor.YELLOW:
                    ghost = new Ghost(new Point(22, 28), Direction.UP);
                    break;
            }
        }

        public void setTarget()
        {
            
        }

        bool sprite1 = true;
        private void runghost()
        {
            while(State != GameState.GAMEOVER)
            {
                try
                {
                    this.Point = ghost.Point;
                    ghost = ghostMove(ghost.Point, ghost.Direction);
                    board.GhostMove(ghost.Point, ghost.Direction, color, sprite1, gState);
                    sprite1 = !sprite1;

                    changeWait();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void changeWait()
        {
            if(gState == GhostState.NORMAL)
            {
                ghostRunner.Wait(_delay + 5);
            }
            else if(gState == GhostState.BONUS || gState == GhostState.BONUSEND){
                int tempDelay = _delay + 50;
                ghostRunner.Wait(tempDelay);
            }
            else
            {
                ghostRunner.Wait(25);
            }
        }

        private Ghost ghostMove(Point StartPoint, Direction d)
        {
            Ghost Ghost = new Ghost(StartPoint, d);
            if(State != GameState.GAMERUN)
            {
                return Ghost;
            }
            int randomIntValue, i;
            //tạo số ngẫu nhiên để sử dụng hướng đi tiếp theo
            //sử dụng 'RNGCryptoServiceProvider' để tạo 1 số ngẫu nhiên an toàn với 'byte[] rno = new byte[5]'
            //và sau đó chuyển nó thành số nguyên 32 bit
            using (RNGCryptoServiceProvider rg = new RNGCryptoServiceProvider())
            {
                byte[] rno = new byte[5];
                rg.GetBytes(rno);
                randomIntValue = BitConverter.ToInt32(rno, 0);
            }
            Random rnd = new Random(randomIntValue);
            //gọi một phương thức 'possibleDirections' để xác định những hướng di chuyển có thể của Ghost tử StartPoint đến d
            //kết quả được lưu trong nextPossibleDir
            List<Direction> nextPossibleDir = possibleDirections(StartPoint, d);

            if(nextPossibleDir.Count != 0)
            {
                //nếu có ít nhất một hướng di chuyển -> chọn 1 hướng ngẫu nhiên từ list nextPossibleDir và sd obj Random
                i = rnd.Next(0, nextPossibleDir.Count);
                d = nextPossibleDir[i];
            }
            //sau đó cập nhật hướng đi mới của Ghost
            Ghost = new Ghost(nextPoint(StartPoint, d), d);
            return Ghost;
        }
        //tìm đường có thể đi
        private List<Direction> possibleDirections(Point P, Direction curDir)
        {
            //Khởi tạo một danh sách (List) chứa các hướng di chuyển có thể.
            List<Direction> dList = new List<Direction>();
            //Vòng lặp qua mỗi hướng có thể từ tập hướng directions.
            foreach (Direction d in directions)
            {
                //kiểm tra xem có xung đột giữa vị trí hiện tại và vị trí tiếp theo hay không, nếu không, hướng 'd' được xem xét là một hướng di chuyển có thể
                //kiểm tra d - curDir có khác 2 không. Để loại bỏ những hướng ngược lại
                if(checkForConflict(nextPoint(P, d), P) && Math.Abs(d - curDir) != 2) dList.Add(d); //nếu không có xung đột, thêm hướng d vào danh sách
            }
            return dList;
        }
        //kiểm tra điểm P có nằm ngoài hộp hay không
        private bool outOfBox(Point P)
        {
            Ghost Ghost = new Ghost(P, Direction.STOP);
            List<Point> commonPoint = Ghost.perimeter(P).Intersect(boxList.Select(u => u)).ToList();
            //Ghost.perimeter: để lấy các điểm tạo thành đường viền của hộp tại vị trí P
            //boxList.Select(u => u): chuyển đổi danh sách boxList thành một danh sách mới
            //Intersect(boxList.Select(u => u)).ToList(); : lấy giao điểm giữa danh sách điểm đường viền của hộp và danh sách điểm của 'boxList'

            return (commonPoint.Count == 0);
        }

        private bool checkForConflict(Point P, Point PrevP)
        {
            Ghost Ghost = new Ghost(P, Direction.STOP);
            List<Point> mergedList = new List<Point>();
            if(outOfBox(PrevP)) //kiểm tra PrevP có nằm ngoài hộp không
            {
                //nếu có kết hợp boxDoorList và wallList thành q danh sách mới
                mergedList = boxDoorList.Union(wallList).ToList();
            }
            else
            {
                //nếu không mergedList chỉ là wallList
                mergedList = wallList;
            }
            List<Point> commonPoint = Ghost.perimeter(P).Intersect(mergedList.Select(u => u)).ToList();
            
            return (commonPoint.Count == 0);
        }

        public void RePaint() //method này được dùng để làm mới giao diện của 1 form
        {
           parentForm.SuspendLayout();//ngưng việc vẽ giao diện
            parentForm.ResumeLayout(false);//kết hợp lại việc vẽ gia diện
        }
    }
}
