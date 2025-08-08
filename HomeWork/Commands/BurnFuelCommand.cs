using HomeWork.CommonMethod;
using HomeWork.CustomExceptions;
using HomeWork.MoveScheme;

namespace HomeWork.Commands
{
    public class BurnFuelCommand : ICommand
    {
        private readonly IFuelableObject _fuelableObject;
        private readonly int _burnVelocity;

        public BurnFuelCommand(IFuelableObject fuelableObject, int burnVelocity)
        {
            _fuelableObject = fuelableObject;
            _burnVelocity = burnVelocity;
        }

        public void Execute()
        {
            var dif = _fuelableObject.Fuel - _burnVelocity;
            _fuelableObject.Fuel = dif < 0 ? throw new CheckFuelCommandException() : dif;
        }
    }
}
