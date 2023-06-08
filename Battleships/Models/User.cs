namespace Battleships.Models;

public sealed class User
{
    public List<Point> allPoints { get; set; } = new();
    public string name { get; init; } = string.Empty;
    public List<Ship> Ships { get; init; } = new();
}
