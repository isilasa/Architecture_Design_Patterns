using HomeWork.Models;

namespace HomeWork.Extensions
{
    public static class StructExtensions
    {
        public static Point Plus(this Point currentLocation, Point vector)
        {
            return new Point
            {
                X = currentLocation.X + vector.X,
                Y = currentLocation.Y + vector.Y
            };
        }

        public static Point Rotate(this Point currentLocation, Angle angle)
        {
            double radians = 2 * Math.PI * angle.Part / angle.TotalParts;

            // Учитываем направление
            double alpha = angle.CounterClockwise ? radians : -radians;

            double cosA = Math.Cos(alpha);
            double sinA = Math.Sin(alpha);

            return new Point
            {
                X = (int)(currentLocation.X * cosA - currentLocation.Y * sinA),
                Y = (int)(currentLocation.X * sinA + currentLocation.Y * cosA)
            };
        }
    }
}
