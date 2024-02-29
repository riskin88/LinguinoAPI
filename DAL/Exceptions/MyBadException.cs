namespace DAL.Exceptions;

public class MyBadException : Exception
{
    public MyBadException(string? message) : base(SetMessage(message))
        { }

        private static string SetMessage(string? message)
    {
        if (message == null) return "Oops, something went wrong.";
        else return message;
    }
}
