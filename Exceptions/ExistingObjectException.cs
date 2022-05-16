namespace Exceptions
{
    public class ExistingObjectException : Exception
    {
        public ExistingObjectException(string message) : base(message) { }
    }
}
