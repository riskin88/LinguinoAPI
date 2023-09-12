namespace DAL.Exceptions;

public class InvalidIDException : Exception
{
    public InvalidIDException(string? message) : base(message)
    { }
}
