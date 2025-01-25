using System.Collections;

namespace FindClosest.Console.Tests
{
    public class FindClosest_Should_Match_Closest
    {
        [Fact]
        public void Is_Closest_Point_Of_Grid()
        {
            //Arrange
            string result = string.Empty;
            List<Point> points =  new() {
                new Point(6,45),
                new Point(100,222),
                new Point(200,10),
                new Point(200,25)
            };

            //Act
            points.Sort((a, b) => a.X.CompareTo(b.X));
            Result? r = FindClosest.FindClosestPair(points.ToArray());

            if (r is not null) 
            {
                result = $"Closest Pair: ({r.P1.X}, {r.P1.Y}) and ({r.P2.X}, {r.P2.Y}) with distance: {r.Distance:F2}";
            }

            //Assert
            Assert.Equal("Closest Pair: (200, 10) and (200, 10) with distance: 15.00", result);
        }

        [Fact]
        public void Has_Invalid_Inputs()
        {   
            //Arrange
            string result = string.Empty;
            List<Point> points = new() {};

            //Act
            Result? r = FindClosest.FindClosestPair(points.ToArray());

            //Assert
            Assert.Equal(string.Empty, result);
        }
    }

}
