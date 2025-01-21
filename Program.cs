using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace PublicProgram
{
    public class Program
    {
        public record Result(Point p1, Point p2, double Distance);

        public record Point(int X, int Y)
        {
            public float GetDistanceTo(Point p) => (float)Math.Sqrt(Math.Pow(X - p.X, 2) + Math.Pow(Y - p.Y, 2));
        }

        public Result? Closest(Point[] points)
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

        public Result? FindClosestPair(Point[] points)
        {
            if (points.Length <= 1) return null;
            if (points.Length <= 3) return Closest(points);

            int m = points.Length / 2;
            Result r = Closer(
                FindClosestPair(points.Take(m).ToArray())!,
                FindClosestPair(points.Skip(m).ToArray()!)
            );
            Point[] strip = points.Where(p => Math.Abs(p.X - points[m].X) < r.Distance).ToArray();
            return Closer(r, Closest(strip));
        }

        public Result Closer(Result r1, Result r2) => r1.Distance < r2.Distance ? r1 : r2;

        public static void Main(string[] args)
        {
            Program p = new Program();
            List<Point> points = new List<Point>() 
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
            Result? closestPair = p.FindClosestPair(points.ToArray());
            if (closestPair != null)
            {
                WriteLine(
                    "Closest Pair: ({0}, {1}) and ({2}, {3}) with distance: {4:F2}",
                    closestPair.p1.X,
                    closestPair.p1.Y,
                    closestPair.p2.X,
                    closestPair.p2.Y,
                    closestPair.Distance);
            }
        }
    }
}
