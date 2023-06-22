namespace Battleships.Models;

using Battleships.Constants;

public class Ship
{
    public bool IsSunk => this.Hits >= this.size;

    public readonly List<Point> Points;

    public int Hits { get; set; } = 0;

    public OccupationType OccupationType { get; init; }
    private int size { get; init; } = 0;

    public Ship(List<Point> shipPoints, string owner, int size)
    {
        this.size = size;

        if (this.size == ShipSizes.DESTROYER)
            this.OccupationType = OccupationType.D;

        if (this.size == ShipSizes.BATTLESHIP)
            this.OccupationType = OccupationType.B;

        this.Points = shipPoints;
    }
}
