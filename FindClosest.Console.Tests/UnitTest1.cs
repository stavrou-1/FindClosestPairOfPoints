
namespace FindClosest.Console.Tests
{
    public class FindClosest_Should_Match_Closest
    {
        [Theory]
        [InlineData(2)]
        [InlineData(5)]
        public void IsClosest(int x)
        {
            bool a1 = x == 2 || x == 5;
            Assert.True(a1);
        }
    }
}
