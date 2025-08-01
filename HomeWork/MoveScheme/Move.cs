using HomeWork.Extensions;

namespace HomeWork.MoveScheme
{
    public class Move
    {
        private readonly IMoveableObject _moveableObject;

        public Move(IMoveableObject moveableObject)
        {
            _moveableObject = moveableObject ?? throw new ArgumentNullException(nameof(moveableObject));
        }

        public void Execute()
        {
            _moveableObject.SetLocation(_moveableObject.GetLocation().Plus(_moveableObject.GetVelocity()));
        }
    }
}
