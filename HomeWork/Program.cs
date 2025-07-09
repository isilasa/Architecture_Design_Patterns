public static class Program
{
    public static void Main() { }

    public static IEnumerable<double> Solve(double a, double b, double c)
    {
        //ax^2+bx+c=0
        var D = (b * b) - 4 * a * c;

        if (D < 0)
            return Enumerable.Empty<double>();

        if (D == 0)
        {
            var x = (-b + Math.Sqrt(D)) / 2 * a;
            return new double[] { x };
        }

        var x1 = (-b + Math.Sqrt(D)) / 2 * a;
        var x2 = (-b - Math.Sqrt(D)) / 2 * a;

        return new double[] { x1, x2 };
    }
}