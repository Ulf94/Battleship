namespace Battleships.Models;

using Battleships.Constants;

public class Ship
{
    public bool isSunk
    {
        get { return this.Hits >= this.size; }
    }

    private readonly string owner;
    public readonly List<Point> Points;

    private bool horizontalOrientation = false;
    private bool verticalOrientation = false;

    public int Hits { get; set; } = 0;

    public OccupationType occupationType { get; init; }
    private int size { get; init; } = 0;

    public Ship(List<Point> shipPoints, string owner, int size)
    {
        this.owner = owner;
        this.size = size;

        if (this.size == ShipSizes.DESTROYER)
            this.occupationType = OccupationType.D;

        if (this.size == ShipSizes.BATTLESHIP)
            this.occupationType = OccupationType.B;

        this.Points = shipPoints;
    }
}
