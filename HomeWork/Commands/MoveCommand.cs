using HomeWork.CommonMethod;
using HomeWork.MoveScheme;
namespace HomeWork.Commands
{
    public class MoveCommand : ICommand
    {
        private readonly Move _move;

        public MoveCommand(Move move)
        {
            _move = move;
        }

        public void Execute()
        {
            _move.Execute();
        }
    }
}
