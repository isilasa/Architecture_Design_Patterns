using HomeWork.CommonMethod;
using HomeWork.Handlers.WriteMessageToLog;

namespace HomeWork.ExceptionHandler
{
    public static class ExceptionDispatcher
    {
        private static readonly Dictionary<(Type, Type), IExceptionHandler> _handlers;

        static ExceptionDispatcher()
        {
            _handlers = new Dictionary<(Type, Type), IExceptionHandler>();
        }

        public static ICommand Dispatch(Exception exception, ICommand command)
        {
            if (_handlers.TryGetValue((exception.GetType(), command.GetType()), out var handler))
            {
                handler.Handle(exception, command);
            }
            else
            {
                if (_handlers.TryGetValue((typeof(Exception), typeof(WriteExceptionMessageToLogCommand)), out handler))
                    handler.Handle(exception, new WriteExceptionMessageToLogCommand(exception));
            }

            return command;
        }

        public static void RegisterHandler(Type exceptionType, Type commandType, IExceptionHandler exceptionHandler)
        {
            _handlers.TryAdd((exceptionType, commandType), exceptionHandler);
        }
    }
}
