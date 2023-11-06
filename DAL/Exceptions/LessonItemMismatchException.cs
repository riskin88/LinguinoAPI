namespace DAL.Exceptions;

public class LessonItemMismatchException : Exception
{
    public LessonItemMismatchException(string? message) : base(SetMessage(message))
    { }

    private static string SetMessage(string message)
    {
        if (message == null) return "The learning step and the exercise belong to different lesson item.";
        else return message;
    }
}
