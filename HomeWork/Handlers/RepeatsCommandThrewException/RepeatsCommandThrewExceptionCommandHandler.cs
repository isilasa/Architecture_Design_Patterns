using HomeWork.CommonMethod;
using HomeWork.ExceptionHandler;
using System.Collections.Concurrent;

namespace HomeWork.Handlers.RepeatsCommandThrewException
{
    public class RepeatsCommandThrewExceptionCommandHandler : IExceptionHandler
    {
        private readonly ConcurrentQueue<ICommand> _commands;

        public RepeatsCommandThrewExceptionCommandHandler(ConcurrentQueue<ICommand> commands)
        {
            _commands = commands ?? throw new ArgumentNullException(nameof(commands));
        }

        public ICommand Handle(Exception exception, ICommand command)
        {
            _commands.Enqueue(new RepeatsCommandThrewExceptionCommand(command));

            return command;
        }
    }
}
