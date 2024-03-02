namespace DAL.Exceptions;

public class LessonTypeMismatchException : Exception
{
    public LessonTypeMismatchException(string? message = null) : base(SetMessage(message))
    { }

    private static string SetMessage(string? message)
    {
        if (message == null) return "The lesson item has a different type than the lesson.";
        else return message;
    }
}
