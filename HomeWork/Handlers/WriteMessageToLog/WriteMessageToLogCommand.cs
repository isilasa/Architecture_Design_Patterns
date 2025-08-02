using HomeWork.CommonMethod;

namespace HomeWork.Handlers.WriteMessageToLog
{
    public class WriteExceptionMessageToLogCommand : ICommand
    {
        private readonly Exception _exception;

        public WriteExceptionMessageToLogCommand(Exception exception)
        {
            _exception = exception ?? throw new ArgumentNullException(nameof(exception));
        }

        public void Execute()
        {
            Console.WriteLine($"Write to log. Message: {_exception.Message}");
        }
    }
}
