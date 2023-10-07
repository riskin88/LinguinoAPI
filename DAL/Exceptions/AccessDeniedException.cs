namespace DAL.Exceptions;

public class AccessDeniedException : Exception
{
    public AccessDeniedException(string? message = null) : base(SetMessage(message))
    { }

    private static string SetMessage(string message)
    {
        if (message == null) return "You are not authorized to do this.";
        else return message;
    }
}
