using HomeWork.CommonMethod;

namespace HomeWork.Handlers.RepeatTwice
{
    public class RepeatTwiceCommand : ICommand
    {
        private static readonly Dictionary<Type, int> _commandCounter;
        private readonly ICommand _command;

        public RepeatTwiceCommand(ICommand command)
        {
            _command = command ?? throw new ArgumentNullException(nameof(command));
        }

        static RepeatTwiceCommand()
        {
            _commandCounter = new Dictionary<Type, int>();
        }

        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
