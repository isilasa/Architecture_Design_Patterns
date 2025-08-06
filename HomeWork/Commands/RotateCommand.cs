using HomeWork.CommonMethod;
using HomeWork.RotateScheme;
namespace HomeWork.Commands
{
    public class RotateCommand : ICommand
    {
        private readonly Rotate _rotate;

        public RotateCommand(Rotate rotate)
        {
            _rotate = rotate;
        }

        public void Execute()
        {
            _rotate.Execute();
        }
    }
}
