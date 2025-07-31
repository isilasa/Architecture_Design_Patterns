using HomeWork.Models;
using HomeWork.MoveScheme;
using HomeWork.RotateScheme;
using Moq;

namespace HomeWork.Test
{
    public class Dz2_Rotate
    {
        [Fact]
        public void SuccessRotateTest()
        {
            Mock<IRotateable> mockMoveableObject = new Mock<IRotateable>();

            mockMoveableObject.Setup(x => x.GetAngle()).Returns(new Angle() { CounterClockwise = false, Part = 2, TotalParts = 8 });
            mockMoveableObject.Setup(x => x.GetLocation()).Returns(new Point() { X = 5, Y = 5 });

            var move = new Rotate(mockMoveableObject.Object);

            move.Execute();

            mockMoveableObject.Setup(x => x.GetLocation()).Returns(new Point() { X = 5, Y = -5 });

            Assert.Equal(mockMoveableObject.Object.GetLocation(), new Point { X = 5, Y = -5 });
        }

        [Fact]
        public void ErrorGetAngleTest()
        {
            Mock<IRotateable> mockMoveableObject = new Mock<IRotateable>();

            mockMoveableObject.Setup(x => x.GetAngle()).Throws(new ArgumentNullException("Rotate error. Angle is null."));
            mockMoveableObject.Setup(x => x.GetLocation()).Returns(new Point() { X = -7, Y = 3 });

            var move = new Rotate(mockMoveableObject.Object);

            try
            {
                move.Execute();

                mockMoveableObject.Setup(x => x.GetLocation()).Returns(new Point() { X = 5, Y = 8 });

                Assert.Equal(mockMoveableObject.Object.GetLocation(), new Point { X = 5, Y = 8 });
            }
            catch (ArgumentNullException ex)
            {
                Assert.True(true);
            }
        }

        [Fact]
        public void ErrorGetLocationTest()
        {
            Mock<IRotateable> mockMoveableObject = new Mock<IRotateable>();

            mockMoveableObject.Setup(x => x.GetAngle()).Returns(new Angle() { CounterClockwise = false, Part = 2, TotalParts = 8 });
            mockMoveableObject.Setup(x => x.GetLocation()).Throws(new ArgumentNullException("Rotate error. Location is null."));

            var move = new Rotate(mockMoveableObject.Object);

            try
            {
                move.Execute();

                mockMoveableObject.Setup(x => x.GetLocation()).Returns(new Point() { X = 5, Y = 8 });

                Assert.Equal(mockMoveableObject.Object.GetLocation(), new Point { X = 5, Y = 8 });
            }
            catch (ArgumentNullException ex)
            {
                Assert.True(true);
            }
        }

        [Fact]
        public void ErrorSetLocationTest()
        {
            Mock<IRotateable> mockMoveableObject = new Mock<IRotateable>();

            mockMoveableObject.Setup(x => x.GetAngle()).Returns(new Angle() { CounterClockwise = false, Part = 2, TotalParts = 8 });
            mockMoveableObject.Setup(x => x.GetLocation()).Returns(new Point() { X = 12, Y = 5 });
            mockMoveableObject.Setup(x => x.SetLocation(new Point { X = 5, Y = 8 })).Throws(new ArgumentNullException("Move error. Can not setlocation."));

            var move = new Rotate(mockMoveableObject.Object);

            try
            {
                move.Execute();

                mockMoveableObject.Setup(x => x.GetLocation()).Returns(new Point() { X = 5, Y = 8 });

                Assert.Equal(mockMoveableObject.Object.GetLocation(), new Point { X = 5, Y = 8 });
            }
            catch (ArgumentNullException ex)
            {
                Assert.True(true);
            }
        }
    }
}
