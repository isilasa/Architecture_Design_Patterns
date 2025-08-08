using HomeWork.CommonMethod;

namespace HomeWork.Handlers.RepeatTwice
{
    public class RepeatTwiceCommand : ICommand
    {
        private static readonly Dictionary<Type, int> _commandCounter;
        private readonly ICommand _command;

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
