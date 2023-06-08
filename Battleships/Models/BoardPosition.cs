namespace Battleships.Models;

using Battleships.Constants;

public class BoardPosition
{
    public OccupationType OccupationType { get; set; }
    public Point Point { get; set; }

    public BoardPosition(int x, int y)
    {
        this.Point = new Point(x, y);
        this.OccupationType = OccupationType.O;
    }
}
