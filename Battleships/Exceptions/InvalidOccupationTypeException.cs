namespace Battleships.Exceptions;

public class InvalidOccupationTypeException : Exception
{
    public InvalidOccupationTypeException() : base("Invalid occupation type")
    {
    }
}
