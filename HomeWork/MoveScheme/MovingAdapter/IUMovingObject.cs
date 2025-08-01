namespace HomeWork.MoveScheme.MovingAdapter
{
    public interface IUMovingObject
    {
        object? GetProperty(string propertyName);
        void SetProperty(string propertyName, object newValue);
    }
}
