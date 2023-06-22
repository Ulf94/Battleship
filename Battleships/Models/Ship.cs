namespace Battleships.Models;

using Battleships.Constants;
using Battleships.Exceptions;

public class Ship
{
    public bool IsSunk => this.Hits >= this.size;

    public OccupationType OccupationType { get; }

    public readonly List<Point> Points;

    public int Hits { get; set; } = 0;
    private int size { get; init; } = 0;

    public Ship(List<Point> shipPoints, string owner, int size)
    {
        this.size = size;

        this.OccupationType = this.size switch
        {
            ShipSizes.DESTROYER => OccupationType.D,
            ShipSizes.BATTLESHIP => OccupationType.B,
            _ => throw new InvalidOccupationTypeException(),
        };

        this.Points = shipPoints;
    }
}
