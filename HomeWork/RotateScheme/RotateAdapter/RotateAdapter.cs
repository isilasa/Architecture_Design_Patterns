using HomeWork.Models;

namespace HomeWork.RotateScheme.RotateAdapter
{
    public class RotateAdapter : IRotateable
    {
        private readonly IURotatbleObject _uRotatbleObject;
        public RotateAdapter(IURotatbleObject uRotatbleObject)
        {
            _uRotatbleObject = uRotatbleObject ?? throw new ArgumentNullException(nameof(uRotatbleObject));
        }

        public Angle GetAngle()
        {
            var angle = _uRotatbleObject.GetProperty("angle");

            if (angle == null)
                throw new ArgumentNullException("Angle property not found");

            return (Angle)angle;
        }

        public Point GetLocation()
        {
            var location = _uRotatbleObject.GetProperty("location");

            if (location == null)
                throw new ArgumentNullException("Location property not found");

            return (Point)location;
        }

        public void SetLocation(Point point)
        {
            GetLocation();
            GetAngle();

            _uRotatbleObject.SetProperty("location", point);
        }
    }
}
