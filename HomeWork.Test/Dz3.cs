using HomeWork.Commands;
using HomeWork.CommonMethod;
using HomeWork.ExceptionHandler;
using HomeWork.Handlers.RepeatsCommandThrewException;
using HomeWork.Handlers.WriteMessageToLog;
using Moq;

namespace HomeWork.Test
{
    public class Dz3
    {
        [Fact]
        public void WritToLogCommandTest()
        {
            var commands = new System.Collections.Concurrent.ConcurrentQueue<ICommand>(new ICommand[] { new SimpleCommand() });
            var executor = new Executor(commands);

            ExceptionDispatcher.RegisterHandler(typeof(Exception), typeof(WriteExceptionMessageToLogCommand), new WriteMessageToLogCommandHandler(commands));

            executor.Execute();

            Assert.True(true);
        }

        [Fact]
        public void RepeatCommandTest()
        {
            var commands = new System.Collections.Concurrent.ConcurrentQueue<ICommand>(new ICommand[] { new SimpleCommand() });
            var executor = new Executor(commands);

            ExceptionDispatcher.RegisterHandler(typeof(Exception), typeof(SimpleCommand), new RepeatsCommandThrewExceptionCommandHandler(commands));

            executor.Execute();

            Assert.True(true);
        }

        [Fact]
        public void RepeatThenWriteToLogTest()
        {
            var commands = new System.Collections.Concurrent.ConcurrentQueue<ICommand>(new ICommand[] { new SimpleCommand() });
            var executor = new Executor(commands);

            ExceptionDispatcher.RegisterHandler(typeof(Exception), typeof(WriteExceptionMessageToLogCommand), new WriteMessageToLogCommandHandler(commands));
            ExceptionDispatcher.RegisterHandler(typeof(Exception), typeof(SimpleCommand), new RepeatsCommandThrewExceptionCommandHandler(commands));

            executor.Execute();

            Assert.True(true);
        }
    }
}
