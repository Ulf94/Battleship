namespace Battleships.Services;

using Battleships.Constants;
using Battleships.Exceptions;
using Battleships.Helpers;
using Battleships.Interfaces;
using Battleships.Models;

internal class UserPointsProvider : IPointsProvider
{
    private readonly List<Point> allUserPoints = new();
    private readonly IConsoleIO console;
    private bool horizontalOrientation = default;
    private bool verticalOrientation = default;

    public UserPointsProvider(IConsoleIO console)
        => this.console = console;

    public List<Point> GetPoints(int shipSize)
    {
        var i = 0;
        var points = new List<Point>();

        switch (shipSize)
        {
            case ShipSizes.DESTROYER:
                this.console.WriteLine("Place your destroyer");

                break;

            case ShipSizes.BATTLESHIP:
                this.console.WriteLine("Place your battleship");

                break;
        }

        bool pointsAreValid = false;

        do
        {
            while (i < shipSize)
            {
                this.console.Write("Provide point: ");
                var pointAsString = this.console.ReadLine();
                var point = pointAsString.StringToPoint();

                if (point is not null)
                {
                    var availablePoint = points.Contains(point);

                    if (availablePoint is false)
                    {
                        points.Add(point!);
                        i++;
                    }
                    else
                    {
                        Console.WriteLine("The ship already contains this point.");
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect point");
                }
            }

            if (this.ValidPoints(points, shipSize) is false)
            {
                i = 0;
                points.Clear();
                pointsAreValid = false;
            }
            else
            {
                pointsAreValid = true;
            }
        } while (pointsAreValid is false);

        this.allUserPoints.AddRange(points);

        return points;
    }

    public Point Shoot()
    {
        this.console.Write("Fire: ");
        var point = this.console.ReadLine().StringToPoint();

        return point;
    }

    private bool ValidPoints(List<Point> providedPoints, int shipSize)
    {
        //Check if any provided point is already taken
        foreach (var point in providedPoints)
        {
            if (this.allUserPoints.Contains(point))
            {
                Console.WriteLine("At least one provided point is already taken.");

                providedPoints.Clear();

                return false;
            }
        }

        //Horizontal
        if (providedPoints.Select(point => point.X).Distinct().Count() == 1)
        {
            this.horizontalOrientation = true;
        }

        //Vertical
        if (providedPoints.Select(point => point.Y).Distinct().Count() == 1)
        {
            this.verticalOrientation = true;
        }

        if (this.horizontalOrientation)
        {
            var max = providedPoints.Select(point => point.Y).Max();
            var min = providedPoints.Select(point => point.Y).Min();

            if (max - min > shipSize - 1)
                throw new InvalidPointsException();
        }

        if (this.verticalOrientation)
        {
            var max = providedPoints.Select(point => point.X).Max();
            var min = providedPoints.Select(point => point.X).Min();

            if (max - min > shipSize - 1)
                throw new InvalidPointsException();
        }

        if (this.horizontalOrientation && this.verticalOrientation || this.horizontalOrientation is false && this.verticalOrientation is false)
        {
            Console.WriteLine("Some point was incorrect. Please try again to create the ship");
            this.verticalOrientation = false;
            this.horizontalOrientation = false;
            providedPoints.Clear();

            return false;
        }

        return true;
    }
}
