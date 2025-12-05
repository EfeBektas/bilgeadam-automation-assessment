namespace TestAutomation.Core.Exceptions
{
    public class WaitTimeoutException : Exception
    {
        public WaitTimeoutException(string message)
            : base(message)
        {
        }
    }
}
