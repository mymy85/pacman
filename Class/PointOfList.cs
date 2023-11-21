
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace PacmanWinForms
{
    public class PointListsWrapper
    {
        public class PointLists
        {
            private List<Point> points = new List<Point>();
            public void Add(Point point)
            {
                points.Add(point);
            }
            public void Remove(Point point)
            {
                points.Remove(point);
            }
            public List<Point> GetPoints()
            {
                points = points.OrderBy(p => p.Y).ThenBy(p => p.X).ToList();
                return points;
            }
            public void Clean()
            {
                points.Clear();
            }
        }
        public enum PointListType
        {
            Wall,
            Dot,
            Box,
            BoxDoor,
            Bonus,
            Invalid
        }
        private Dictionary<PointListType, PointLists> pointListsMap = new Dictionary<PointListType, PointLists>();
        private PointListsWrapper() { }
        private static PointListsWrapper instance = null;
        public static PointListsWrapper Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PointListsWrapper();
                }
                return instance;
            }
        }
        public void Add(PointListType pointListType)
        {
            if (!pointListsMap.ContainsKey(pointListType))
            {
                pointListsMap.Add(pointListType, new PointLists());
            }
        }
        public void Remove(PointListType pointListType)
        {
            pointListsMap.Remove(pointListType);
        }
        public PointLists GetPointList(PointListType pointListType)
        {
            return pointListsMap.TryGetValue(pointListType, out PointLists list) ? list : null;
        }
        public void CleanAll()
        {
            foreach (var entry in pointListsMap)
            {
                entry.Value.Clean();
            }
        }
    }

    public class MapHandler
    {
        private MapHandler() { }

        private static MapHandler instance = null;

        public static MapHandler Instance
        {
            get
            {
                instance = new MapHandler();
                PointListsWrapper pointListsWrapper = PointListsWrapper.Instance;
                pointListsWrapper.Add(PointListsWrapper.PointListType.Wall);
                pointListsWrapper.Add(PointListsWrapper.PointListType.Dot);
                pointListsWrapper.Add(PointListsWrapper.PointListType.Box);
                pointListsWrapper.Add(PointListsWrapper.PointListType.BoxDoor);
                pointListsWrapper.Add(PointListsWrapper.PointListType.Bonus);
                return instance;
            }
        }

        private PointListsWrapper.PointListType GetPointListType(char c)
        {
            switch (c)
            {
                case '0':
                    return PointListsWrapper.PointListType.Wall;
                case '1':
                    return PointListsWrapper.PointListType.Dot;
                case '2':
                    return PointListsWrapper.PointListType.Box;
                case '3':
                    return PointListsWrapper.PointListType.BoxDoor;
                case '4':
                    return PointListsWrapper.PointListType.Bonus;
                default:
                    return PointListsWrapper.PointListType.Invalid;
            }
        }

        public List<Point> GetList(PointListsWrapper.PointListType listType)
        {
            if (listType == PointListsWrapper.PointListType.Invalid)
            {
                return new List<Point>();
            }
            var pointList = PointListsWrapper.Instance.GetPointList(listType);
            return (pointList == null) ? new List<Point>() : pointList.GetPoints();
        }

        public void CleanUp()
        {
            PointListsWrapper.Instance.CleanAll();
        }

        public void LoadMap(string mapPath)
        {
            // Clean up the lists before loading new map
            CleanUp();

            string[] lines = File.ReadAllLines(mapPath);
            for (int y = 0; y < lines.Length; y++)
            {
                string line = lines[y];
                for (int x = 0; x < line.Length; x++)
                {
                    char c = line[x];
                    var pointList = PointListsWrapper.Instance.GetPointList(GetPointListType(c));
                    if (pointList != null)
                    {
                        pointList.Add(new Point(x, y));
                    }
                }
            }
        }
    }
}