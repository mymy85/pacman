using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacmanWinForms
{
    public static class PointLists
    {
        private static List<Point> dotList = new List<Point>();
        public static List<Point> DotPointList()
        {
            DotListInit();
            dotList = dotList.OrderBy(p => p.Y).ThenBy(p => p.X).ToList();
            return dotList;
        }

        private static List<Point> bonusList = new List<Point>();
        public static List<Point> BonusPointList()
        {
            BonusListInit();
            bonusList = bonusList.OrderBy(p => p.Y).ThenBy(p => p.X).ToList();
            return bonusList;
        }

        private static List<Point> banList = new List<Point>();
        public static List<Point> BanPointList()
        {
            BanListInit();
            banList = banList.OrderBy(p => p.Y).ThenBy(p => p.X).ToList();
            return banList;
        }

        private static List<Point> boxList = new List<Point>();
        public static List<Point> BoxPointList()
        {
            BoxListInit();
            boxList = boxList.OrderBy(p => p.Y).ThenBy(p => p.X).ToList();
            return boxList;
        }

        private static List<Point> boxDoorList = new List<Point>();
        public static List<Point> BoxDoorPointList()
        {
            BoxDoorInit();
            boxDoorList = boxDoorList.OrderBy(p => p.Y).ThenBy(p => p.X).ToList();
            return boxDoorList;
        }

        private static List<Point> BonusListInit()
        {
            // Implement this function
            return new List<Point>();
        }

        private static void BoxListInit()
        {
            // Implement this function
        }

        private static void BoxDoorInit()
        {
            // Implement this function
        }

        private static void DotListInit()
        {
            // Implement this function
        }

        private static void BanListInit()
        {
            // Implement this function
        }
    }
}