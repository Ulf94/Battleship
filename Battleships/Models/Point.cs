namespace Battleships.Models;

public sealed record Point
{
    public int X { get; init; } = -1;
    public int Y { get; init; } = -1;

    public Point()
    {
    }

    public Point(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }
}
