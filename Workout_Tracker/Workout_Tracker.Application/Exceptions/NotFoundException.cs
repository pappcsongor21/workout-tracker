namespace Workout_Tracker.Application.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string message) : base(message)
    {
    }

    public NotFoundException(string entityName, object key)
        : base($"Item ({entityName}) with the given id ({key}) is not found")
    {
    }
}
