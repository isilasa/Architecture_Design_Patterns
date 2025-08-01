using HomeWork.Extensions;

namespace HomeWork.RotateScheme
{
    public class Rotate
    {
        private readonly IRotateable _rotateableObject;

        public Rotate(IRotateable rotateableObject)
        {
            _rotateableObject = rotateableObject ?? throw new ArgumentNullException(nameof(rotateableObject));
        }

        public void Execute()
        {
            _rotateableObject.SetLocation(_rotateableObject.GetLocation().Rotate(_rotateableObject.GetAngle()));
        }
    }
}
