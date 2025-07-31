using HomeWork.Models;

namespace HomeWork.RotateScheme
{
    public interface IRotateable
    {
        Point GetLocation();
        void SetLocation(Point point);
        Angle GetAngle();
    }
}
