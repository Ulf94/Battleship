namespace Battleships.Models;

public sealed class User
{
    public List<Point> AllPoints { get; init; } = new();
    public string Name { get; init; } = string.Empty;
    public List<Ship> Ships { get; init; } = new();
}
