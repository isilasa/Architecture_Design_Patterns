using HomeWork.Commands;
using HomeWork.CommonMethod;
using HomeWork.Models;
using HomeWork.MoveScheme;
using HomeWork.Resolvers;
using Moq;

namespace HomeWork.Test
{
    public class Dz5
    {
        [Fact]
        public void IoCTest()
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

            IoC.Resolve<ICommand>("IoC.Register", "MacroComamnd", (object[] args) => new MacroComamnd(new ICommand[] { checkCommand, moveCommand, burnCommand }));

            IoC.Resolve<string>("Scopes.New", "scope1");

            IoC.Resolve<string>("Scopes.Current", "scope1");

            IoC.Resolve<ICommand>("IoC.Register", "CheckFuelCommand", (object[] args) => new CheckFuelCommand(mockFuelableObject.Object, needToMove));

            var macroComamndInstance = IoC.Resolve<ICommand>("MacroComamnd");
            var checkFuelCommandInstance = IoC.Resolve<ICommand>("CheckFuelCommand");

            Assert.Equal(typeof(MacroComamnd), macroComamndInstance.GetType());
            Assert.Equal(typeof(CheckFuelCommand), checkFuelCommandInstance.GetType());
        }
    }
}
