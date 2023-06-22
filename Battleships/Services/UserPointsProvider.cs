namespace Battleships.Services;

using Battleships.Constants;
using Battleships.Exceptions;
using Battleships.Helpers;
using Battleships.Interfaces;
using Battleships.Models;

internal class UserPointsProvider : IPointsProvider
{
    private readonly IConsoleIO console;
    private bool horizontalOrientation = default;
    private bool verticalOrientation = default;

    public UserPointsProvider(IConsoleIO console)
        => this.console = console;

    public List<Point> GetPoints(int shipSize, List<Point> allUserPoints)
    {
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

        bool pointsAreValid;
        var i = 0;

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
                        points.Add(point);
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

            if (this.ValidPoints(points, shipSize, allUserPoints) is false)
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

        allUserPoints.AddRange(points);

        return points;
    }

    public Point Shoot()
    {
        var point = new Point();

        do
        {
            this.console.Write("Fire: ");
            point = this.console.ReadLine().StringToPoint();
        } while (point is null);

        return point;
    }

    private bool ValidPoints(List<Point> providedPoints, int shipSize, ICollection<Point> allUserPoints)
    {
        //Check if any provided point is already taken by another ship
        foreach (var point in providedPoints)
        {
            if (allUserPoints.Contains(point))
            {
                Console.WriteLine("At least one provided point is already taken. Provide all five points again");

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
