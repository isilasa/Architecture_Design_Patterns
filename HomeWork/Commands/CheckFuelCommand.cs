using HomeWork.CommonMethod;
using HomeWork.CustomExceptions;
using HomeWork.MoveScheme;

namespace HomeWork.Commands
{
    public class CheckFuelCommand : ICommand
    {
        private readonly IFuelableObject _fuelableObject;
        private readonly int _needForMove;

        public CheckFuelCommand(IFuelableObject fuelableObject, int needForMove)
        {
            _fuelableObject = fuelableObject;
            _needForMove = needForMove;
        }

        public void Execute()
        {
            if (_fuelableObject.Fuel < _needForMove)
                throw new CheckFuelCommandException("Недостаточно топлива");
        }
    }
}
