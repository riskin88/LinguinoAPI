namespace BLL.Exceptions.Auth
{
    public class EmailErrorException : Exception
    {
        public EmailErrorException(string? message) : base(message)
        { }
    }
}
