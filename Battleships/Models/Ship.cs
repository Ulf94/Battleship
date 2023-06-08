namespace Battleships.Models;

using Battleships.Constants;
using Battleships.Exceptions;
using Battleships.Interfaces;

public class Ship
{
    public bool isSunk
    {
        get { return this.Hits >= this.Size; }
    }

    private readonly List<Point> allPoints;
    private readonly string owner;
    private readonly IPointsProvidersFactory pointsProvidersFactory;

    private bool horizontalOrientation = false;
    public List<Point> Points = new();
    private bool verticalOrientation = false;

    public int Hits { get; set; }

    public OccupationType OccupationType { get; init; }
    private int Size { get; init; } = 0;

    public Ship(List<Point> allPoints, IPointsProvidersFactory pointsProvidersFactory, string owner, int size)
    {
        this.owner = owner;
        this.pointsProvidersFactory = pointsProvidersFactory;
        this.Size = size;
        this.allPoints = allPoints;

        if (this.Size == ShipSizes.DESTROYER)
            this.OccupationType = OccupationType.D;

        if (this.Size == ShipSizes.BATTLESHIP)
            this.OccupationType = OccupationType.B;

        var provider = this.pointsProvidersFactory.GetInstance(this.owner);

        do
        {
            this.Points = provider.GetPoints(this.Size);
        } while (this.ValidPoints(this.Points, this.allPoints) is false);

        foreach (var point in this.Points)
        {
            point.OccupationType = this.OccupationType;
        }
    }

    private bool ValidPoints(List<Point> providedPoints, List<Point> allCollectedPoints)
    {
        //Check if any provided point is already taken
        foreach (var point in providedPoints)
        {
            if (allCollectedPoints.Contains(point))
            {
                if (this.owner == OwnerType.USER)
                {
                    Console.WriteLine("At least one provided point is already taken.");
                }

                this.Points.Clear();

                return false;
            }
        }

        //Horizontal
        if (this.Points.Select(point => point.X).Distinct().Count() == 1)
        {
            this.horizontalOrientation = true;
        }

        //Vertical
        if (this.Points.Select(point => point.Y).Distinct().Count() == 1)
        {
            this.verticalOrientation = true;
        }

        if (this.horizontalOrientation)
        {
            var max = this.Points.Select(point => point.Y).Max();
            var min = this.Points.Select(point => point.Y).Min();

            if (max - min > this.Size - 1)
                throw new InvalidPointsException();
        }

        if (this.verticalOrientation)
        {
            var max = this.Points.Select(point => point.X).Max();
            var min = this.Points.Select(point => point.X).Min();

            if (max - min > this.Size - 1)
                throw new InvalidPointsException();
        }

        if (this.horizontalOrientation && this.verticalOrientation || this.horizontalOrientation is false && this.verticalOrientation is false)
        {
            Console.WriteLine("Some point was incorrect. Please try again to create the ship");
            this.verticalOrientation = false;
            this.horizontalOrientation = false;
            this.Points.Clear();

            return false;
        }

        return true;
    }
}
