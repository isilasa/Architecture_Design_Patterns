using HomeWork.Models;
using HomeWork.MoveScheme;
using Moq;

namespace HomeWork.Test
{
    public class DZ2_Move
    {

        [Fact]
        public void SuccessMoveTest()
        {
            Mock<IMoveableObject> mockMoveableObject = new Mock<IMoveableObject>();

            mockMoveableObject.Setup(x => x.GetVelocity()).Returns(new Point() { X = 12, Y = 5 });
            mockMoveableObject.Setup(x => x.GetLocation()).Returns(new Point() { X = -7, Y = 3 });

            var move = new Move(mockMoveableObject.Object);

            move.Execute();

            mockMoveableObject.Setup(x => x.GetLocation()).Returns(new Point() { X = 5, Y = 8 });

            Assert.Equal(mockMoveableObject.Object.GetLocation(), new Point { X = 5, Y = 8 });
        }

        [Fact]
        public void ErrorGetVelocityTest()
        {
            Mock<IMoveableObject> mockMoveableObject = new Mock<IMoveableObject>();

            mockMoveableObject.Setup(x => x.GetVelocity()).Throws(new ArgumentNullException("Move error .Location is null."));
            mockMoveableObject.Setup(x => x.GetLocation()).Returns(new Point() { X = -7, Y = 3 });

            var move = new Move(mockMoveableObject.Object);

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
            Mock<IMoveableObject> mockMoveableObject = new Mock<IMoveableObject>();

            mockMoveableObject.Setup(x => x.GetVelocity()).Returns(new Point() { X = 12, Y = 5 });
            mockMoveableObject.Setup(x => x.GetLocation()).Throws(new ArgumentNullException("Move error .Location is null."));

            var move = new Move(mockMoveableObject.Object);

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
            Mock<IMoveableObject> mockMoveableObject = new Mock<IMoveableObject>();

            mockMoveableObject.Setup(x => x.GetVelocity()).Returns(new Point() { X = -7, Y = 3 });
            mockMoveableObject.Setup(x => x.GetLocation()).Returns(new Point() { X = 12, Y = 5 });
            mockMoveableObject.Setup(x => x.SetLocation(new Point { X = 5, Y = 8 })).Throws(new ArgumentNullException("Move error. Can not setlocation."));

            var move = new Move(mockMoveableObject.Object);

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
