namespace DAL.Exceptions;

public class SubscriptionErrorException : Exception
{
    public SubscriptionErrorException(string? message) : base(message) { }
}
