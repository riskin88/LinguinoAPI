namespace DAL.Exceptions;

public class CourseMismatchException : Exception
{
    public CourseMismatchException(string? message) : base(SetMessage(message))
    { }

    private static string SetMessage(string message)
    {
        if (message == null) return "The topic and lesson belong to different course.";
        else return message;
    }
}
