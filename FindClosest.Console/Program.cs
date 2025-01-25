using FindClosest.Console.interfaces;

namespace FindClosest.Console
{
    public class Point : IPoint
    {
        private readonly int _X;
        public int X 
        {
            get { return _X;  }
        }
        private readonly int _Y;
        public int Y 
        {
            get { return _Y; }
        }

        public Point(int X, int Y)
        {
            _X = X;
            _Y = Y;
        }
        public float GetDistanceTo(Point p) 
            => (float)Math.Sqrt(Math.Pow(X - p.X, y:2 ) + Math.Pow(Y - p.Y, y: 2 ));
    }
    public class Result
    {
        private readonly Point _P1;
        public Point P1 { 
            get { return _P1; }
        }
        private readonly Point _P2;
        public Point P2 { 
            get { return _P1; }
        }
        private readonly double _Distance; 

        public double Distance { 
            get { return _Distance; }
        }
        public Result(Point P1, Point P2, double Distance)
        {
            _P1 = P1;
            _P2 = P2;
            _Distance = Distance;
        }
    }

    public class FindClosest
    {
        internal static Result Closest(Point[] points)
        {
            Result result = new(points[0], points[0], double.MaxValue);
            for (int i = 0; i < points.Length; i++)
            {
                for (int j = i + 1; j < points.Length; j++)
                {
                    double distance = points[i].GetDistanceTo(points[j]);
                    if (distance < result.Distance)
                    {
                        result = new(points[i], points[j], distance);
                    }
                }
            }
            return result;
        }

        internal static Result? FindClosestPair(Point[] points)
        {
            if (points.Length <= 1) return null;
            if (points.Length <= 3) return Closest(points);

            int m = points.Length / 2;
            Result r = Closer(
                FindClosestPair(points.Take(m).ToArray())!,
                FindClosestPair(points.Skip(m).ToArray())!
            );
            Point[] strip = points.Where(p => Math.Abs(p.X - points[m].X) < r.Distance).ToArray();
            return Closer(r, Closest(strip)!);
        }

        internal static Result Closer(Result r1, Result r2) => r1.Distance < r2.Distance ? r1 : r2;
    }

    
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Point> points = new() 
            {
                new Point(6, 45),  //A,
                new Point(12, 8),  //B,
                new Point(14, 31), //C,
                new Point(24, 18), //D,
                new Point(32, 26), //E,
                new Point(40, 41), //F,
                new Point(44, 6),  //G,
                new Point(57, 20), //H,
                new Point(60, 35), //I
                new Point(72, 9),  //J
                new Point(73, 41), //K
                new Point(85, 25), //L
                new Point(92, 8),  //M
                new Point(93, 43), //N
            };

            points.Sort((a, b) => a.X.CompareTo(b.X));
            Result? closestPair = FindClosest.FindClosestPair(points.ToArray());
            if (closestPair != null)
            {
                WriteLine(
                    "Closest Pair: ({0}, {1}) and ({2}, {3}) with distance: {4:F2}",
                    closestPair.P1.X,
                    closestPair.P1.Y,
                    closestPair.P2.X,
                    closestPair.P2.Y,
                    closestPair.Distance);
            }
        }
    }
}
