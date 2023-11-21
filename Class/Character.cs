
using PacmanWinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Pacman_Game.Class
{
    public class Character
    {
        protected Point Point { get; set; }
        protected Direction Direction { get; set; }
        protected Point[] Perimeter { set; get; } = new Point[12];
        protected Point[] Core { set; get; } = new Point[4];

        protected int _delay = 70;

        public Character(Point point, Direction direction)
        {
            this.Point = point;
            this.Direction = direction;
        }

        public Point[] perimeter(Point p)
        {
            /*phương thức này trả về một mảng các điểm tạo thành 'vùng biên' của đối tượng
             pacman, vùng biên là các điểm tạo thành các cạnh của hình vuông bao quanh pacman*/
            Perimeter[0] = p;
            Perimeter[1] = new Point(p.X + 1, p.Y);
            Perimeter[2] = new Point(p.X + 2, p.Y);

            Perimeter[3] = new Point(p.X + 3, p.Y);
            Perimeter[4] = new Point(p.X + 3, p.Y + 1);
            Perimeter[5] = new Point(p.X + 3, p.Y + 2);

            Perimeter[6] = new Point(p.X + 3, p.Y + 3);
            Perimeter[7] = new Point(p.X + 2, p.Y + 3);
            Perimeter[8] = new Point(p.X + 1, p.Y + 3);

            Perimeter[9] = new Point(p.X, p.Y + 3);
            Perimeter[10] = new Point(p.X, p.Y + 2);
            Perimeter[11] = new Point(p.X, p.Y + 1);
            return Perimeter;
        }

        public Point[] core(Point p)
        {
            Core[0] = new Point(p.X + 2, p.Y + 2);
            Core[1] = new Point(p.X + 2, p.Y + 3);
            Core[2] = new Point(p.X + 3, p.Y + 3);
            Core[3] = new Point(p.X + 3, p.Y + 2);
            return Core;

        }


    }
}
