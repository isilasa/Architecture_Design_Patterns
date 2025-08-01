using HomeWork.Models;

namespace HomeWork.MoveScheme
{
    public interface IMoveableObject
    {
        Point GetLocation();
        void SetLocation(Point point);
        Point GetVelocity();
    }
}
