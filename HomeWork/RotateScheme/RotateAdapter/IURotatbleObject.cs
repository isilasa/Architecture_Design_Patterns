namespace HomeWork.RotateScheme.RotateAdapter
{
    public interface IURotatbleObject
    {
        object? GetProperty(string name);
        void SetProperty(string name, object newProperty);
    }
}
