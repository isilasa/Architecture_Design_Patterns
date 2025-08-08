using HomeWork.Commands;
using HomeWork.CommonMethod;
using HomeWork.CustomExceptions;
using HomeWork.Models;
using HomeWork.MoveScheme;
using Moq;

namespace HomeWork.Test
{
    public class Dz4
    {
        [Fact]
        public void CheckFuelCommandSuccessTest()
        {
            Mock<IFuelableObject> mockFuelableObject = new Mock<IFuelableObject>();
            mockFuelableObject.Setup(x => x.Fuel).Returns(5);
            var needToMove = 5;

            var command = new CheckFuelCommand(mockFuelableObject.Object, needToMove);

            command.Execute();

            Assert.True(true);
        }

        [Fact]
        public void CheckFuelCommandErrorTest()
        {
            Mock<IFuelableObject> mockFuelableObject = new Mock<IFuelableObject>();
            mockFuelableObject.Setup(x => x.Fuel).Returns(5);
            var needToMove = 6;

            var command = new CheckFuelCommand(mockFuelableObject.Object, needToMove);
            try
            {
                command.Execute();
            }

            catch (CheckFuelCommandException ex)
            {
                Assert.True(true);
            }
            catch (Exception ex)
            {
                Assert.True(false);
            }
        }

        [Fact]
        public void BurnFuelCommandSuccessTest()
        {
            Mock<IFuelableObject> mockFuelableObject = new Mock<IFuelableObject>();
            mockFuelableObject.Setup(x => x.Fuel).Returns(5);
            int needToMove = 5;

            var command = new BurnFuelCommand(mockFuelableObject.Object, needToMove);

            command.Execute();

            Assert.True(true);
        }

        [Fact]
        public void BurnFuelCommandErrorTest()
        {
            Mock<IFuelableObject> mockFuelableObject = new Mock<IFuelableObject>();
            mockFuelableObject.Setup(x => x.Fuel).Returns(5);
            int needToMove = 6;

            var command = new BurnFuelCommand(mockFuelableObject.Object, needToMove);
            try
            {
                command.Execute();
            }
            catch (CheckFuelCommandException ex)
            {
                Assert.True(true);
            }
        }

        [Fact]
        public void MacroComamndSuccessTest()
        {
            Mock<IFuelableObject> mockFuelableObject = new Mock<IFuelableObject>();
            mockFuelableObject.Setup(x => x.Fuel).Returns(5);
            int needToMove = 2;

            Mock<IMoveableObject> mockMoveableObject = new Mock<IMoveableObject>();
            mockMoveableObject.Setup(x => x.GetVelocity()).Returns(new Point { X = 5, Y = 5 });
            mockMoveableObject.Setup(x => x.GetLocation()).Returns(new Point { X = 5, Y = 5 });

            var checkCommand = new CheckFuelCommand(mockFuelableObject.Object, needToMove);
            var burnCommand = new BurnFuelCommand(mockFuelableObject.Object, needToMove);
            var moveCommand = new MoveCommand(new Move(mockMoveableObject.Object));

            var macroCommand = new MacroComamnd(new List<ICommand>() { checkCommand, moveCommand, burnCommand });

            macroCommand.Execute();

            Assert.True(true);
        }

        [Fact]
        public void MacroComamndErrorCheckTest()
        {
            Mock<IFuelableObject> mockFuelableObject = new Mock<IFuelableObject>();
            mockFuelableObject.Setup(x => x.Fuel).Returns(5);
            int needToMove = 6;

            Mock<IMoveableObject> mockMoveableObject = new Mock<IMoveableObject>();
            mockMoveableObject.Setup(x => x.GetVelocity()).Returns(new Point { X = 5, Y = 5 });
            mockMoveableObject.Setup(x => x.GetLocation()).Returns(new Point { X = 5, Y = 5 });

            var checkCommand = new CheckFuelCommand(mockFuelableObject.Object, needToMove);
            var burnCommand = new BurnFuelCommand(mockFuelableObject.Object, needToMove);
            var moveCommand = new MoveCommand(new Move(mockMoveableObject.Object));

            var macroCommand = new MacroComamnd(new List<ICommand>() { checkCommand, moveCommand, burnCommand });

            try
            {
                macroCommand.Execute();
            }
            catch (CheckFuelCommandException ex)
            {
                Assert.True(true);
            }
        }
    }
}
