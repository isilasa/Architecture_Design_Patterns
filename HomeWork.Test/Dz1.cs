namespace HomeWork.Test
{
    public class Dz1
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

        [Fact]
        public void OneRootTest()
        {
            var roots = Program.Solve(1, 4, 4);

            Assert.NotEmpty(roots);
            Assert.Single(roots);
            Assert.Equal(0, (roots.First() % 2));
        }

        [Fact]
        public void IncorrecrFirstArgTest()
        {
            try
            {
                var roots = Program.Solve(0, 2, 1);
            }
            catch (ArgumentNullException)
            {
                Assert.True(true);
                return;
            }

            Assert.True(false);
        }

        [Theory]
        [InlineData((1.0 / 0.0), 1, 1)]
        [InlineData((-1.0 / 0.0), 1, 1)]
        [InlineData((0.0 / 0.0), 1, 1)]
        [InlineData(1, (1.0 / 0.0), 1)]
        [InlineData(1, (-1.0 / 0.0), 1)]
        [InlineData(1, (0.0 / 0.0), 1)]
        [InlineData(1, 1, (1.0 / 0.0))]
        [InlineData(1, 1, (-1.0 / 0.0))]
        [InlineData(1, 1, (0.0 / 0.0))]
        public void IncorrecrArgsTest(double a, double b, double c)
        {
            try
            {
                var roots = Program.Solve(a, b, c);
            }
            catch (ArgumentNullException)
            {
                Assert.True(true);
                return;
            }

            Assert.True(false);
        }
    }
}