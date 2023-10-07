namespace DAL.Exceptions;

public class UserNotInCourseException : Exception
{
    public UserNotInCourseException(string? message = null) : base(SetMessage(message))
    { }

    private static string SetMessage(string message)
    {
        if (message == null) return "There is no such course registered for this user.";
        else return message;
    }
}
