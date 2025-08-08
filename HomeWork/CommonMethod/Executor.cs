using HomeWork.ExceptionHandler;
using System.Collections.Concurrent;

namespace HomeWork.CommonMethod
{
    public class Executor : IExecutor
    {
        private readonly ConcurrentQueue<ICommand> _commands;

        public Executor(ConcurrentQueue<ICommand> commands)
        {
            _commands = commands ?? throw new ArgumentNullException(nameof(commands));
        }

        public void Execute()
        {
            while (_commands.Any())
            {
                if (_commands.TryDequeue(out var command))
                {
                    try
                    {
                        command.Execute();
                    }
                    catch (Exception ex)
                    {
                        ExceptionDispatcher.Dispatch(ex, command);
                    }
                }
            }
        }
    }
}
