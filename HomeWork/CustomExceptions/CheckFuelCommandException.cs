namespace HomeWork.CustomExceptions
{
    public class CheckFuelCommandException : Exception
    {
        public CheckFuelCommandException() : base() { }
        public CheckFuelCommandException(string message) : base(message) { }
        public CheckFuelCommandException(string message, Exception innerException) : base(message, innerException) { }
    }
}
