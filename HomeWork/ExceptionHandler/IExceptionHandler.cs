using HomeWork.CommonMethod;

namespace HomeWork.ExceptionHandler
{
    public interface IExceptionHandler
    {
        ICommand Handle(Exception exception, ICommand command);
    }
}
