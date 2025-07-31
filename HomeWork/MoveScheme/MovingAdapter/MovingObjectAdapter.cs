using HomeWork.Models;

namespace HomeWork.MoveScheme.MovingAdapter
{
    public class MovingObjectAdapter : IMoveableObject
    {
        private readonly IUMovingObject _uMovingObject;

        public MovingObjectAdapter(IUMovingObject uMovingObject)
        {
            _uMovingObject = uMovingObject ?? throw new ArgumentNullException(nameof(uMovingObject));
        }

        public Point GetLocation()
        {
            var location = _uMovingObject.GetProperty("location");

            return location == null
                ? throw new ArgumentNullException("Move error .Location is null.")
                : (Point)location;
        }

        public Point GetVelocity()
        {
            var velocity = _uMovingObject.GetProperty("velocity");

            return velocity == null
                ? throw new ArgumentNullException("Move error. Velocity is null.")
                : (Point)velocity;
        }

        public void SetLocation(Point point)
        {
            GetLocation();
            GetVelocity();
            
            _uMovingObject.SetProperty("location", point);
        }
    }
}
