namespace HomeWork.Test
{
    public class UnitTest1
    {
        [Fact]
        public void NoRootsTest()
        {
            var roots = Program.Solve(1, 0, 1);

            Assert.Empty(roots);
        }

        [Fact]
        public void TwoRootsTest()
        {
            var roots = Program.Solve(1, 0, -1);

            Assert.NotEmpty(roots);
            Assert.Equal(2, roots.Count());
            Assert.Equal(0, (roots.First() % 1));
            Assert.Equal(0, (roots.Last() % 1));
        }
    }
}