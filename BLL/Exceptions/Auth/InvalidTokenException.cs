namespace BLL.Exceptions.Auth
{
    public class InvalidTokenException : Exception
    {
        public InvalidTokenException(string? message) : base(message)
        { }
    }
}
