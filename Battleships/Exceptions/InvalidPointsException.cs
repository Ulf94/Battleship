namespace Battleships.Exceptions;

internal sealed class InvalidPointsException : Exception
{
    public InvalidPointsException() : base("Provided points for ship are invalid")
    {
    }
}
