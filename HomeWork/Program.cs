public static class Program
{
    public static void Main() { }

    public static IEnumerable<double> Solve(double a, double b, double c)
    {
        if (a.CompareTo(0) <= 0)
            throw new ArgumentNullException("a con not be 0");


        if (double.IsInfinity(a) || double.IsNegativeInfinity(a) || double.IsNaN(a))
            throw new ArgumentNullException("a is incorrect");

        if (double.IsInfinity(b) || double.IsNegativeInfinity(b) || double.IsNaN(b))
            throw new ArgumentNullException("a is incorrect");

        if (double.IsInfinity(c) || double.IsNegativeInfinity(c) || double.IsNaN(c))
            throw new ArgumentNullException("a is incorrect");


        //ax^2+bx+c=0
        var D = (b * b) - 4 * a * c;

        if (D.CompareTo(0) < 0)
            return Enumerable.Empty<double>();

        if (D.CompareTo(0) == 0)
        {
            var x = (-b + Math.Sqrt(D)) / 2 * a;
            return new double[] { x };
        }

        var x1 = (-b + Math.Sqrt(D)) / 2 * a;
        var x2 = (-b - Math.Sqrt(D)) / 2 * a;

        return new double[] { x1, x2 };
    }
}