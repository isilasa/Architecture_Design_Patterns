using HomeWork.CommonMethod;
using HomeWork.ExceptionHandler;
using System.Collections.Concurrent;

namespace HomeWork.Handlers.WriteMessageToLog
{
    public class WriteMessageToLogCommandHandler : IExceptionHandler
    {
        private readonly ConcurrentQueue<ICommand> _commands;

        public WriteMessageToLogCommandHandler(ConcurrentQueue<ICommand> commands)
        {
            _commands = commands ?? throw new ArgumentNullException(nameof(commands));
        }


        public ICommand Handle(Exception exception, ICommand command)
        {
            _commands.Enqueue(command);

            return command;
        }
    }
}
