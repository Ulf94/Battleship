namespace Battleships.Services;

using Battleships.Constants;
using Battleships.Exceptions;
using Battleships.Helpers;
using Battleships.Interfaces;
using Battleships.Models;

internal class ComputerPointsProvider : IPointsProvider
{
    private readonly IConsoleIO console;
    private readonly ICustomRandom random;
    private bool horizontalOrientation = default;
    private bool verticalOrientation = default;

    public ComputerPointsProvider(IConsoleIO console, ICustomRandom random)
        => (this.console, this.random) = (console, random);

    public List<Point> GetPoints(int shipSize, List<Point> allComputerPoints)
    {
        var points = new List<Point>();

        do
        {
            var startX = this.random.GetRandomX(1, 10);
            var startY = this.random.GetRandomY(1, 10);
            var orientation = this.random.GetRandomOrientation(1, 10);

            if (orientation % 2 == 0)
            {
                if (startY - shipSize >= 0)
                {
                    for (var i = 0; i < shipSize; i++)
                    {
                        points.Add(new Point(startX, startY - i));
                    }
                }
                else
                {
                    for (var i = 0; i < shipSize; i++)
                    {
                        points.Add(new Point(startX, startY + i));
                    }
                }
            }
            else
            {
                if (startX - shipSize >= 0)
                {
                    for (var i = 0; i < shipSize; i++)
                    {
                        points.Add(new Point(startX - i, startY));
                    }
                }
                else
                {
                    for (var i = 0; i < shipSize; i++)
                    {
                        points.Add(new Point(startX + i, startY));
                    }
                }
            }
        } while (this.ValidPoints(points, shipSize, allComputerPoints) is false);

        allComputerPoints.AddRange(points);

        return points;
    }

    public Point Shoot()
    {
        var targetX = this.random.GetRandomX(1, BoardSize.COLUMNS);
        var targetY = this.random.GetRandomY(1, BoardSize.ROWS);
        var computerShootAt = new Point(targetX, targetY);
        this.console.WriteLine($"Computer is shooting at: {computerShootAt.PointToString()}");

        return computerShootAt;
    }

    private bool ValidPoints(List<Point> providedPoints, int shipSize, ICollection<Point> allComputerPoints)
    {
        //Check if any provided point is already taken
        foreach (var point in providedPoints)
        {
            if (allComputerPoints.Contains(point))
            {
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
            this.verticalOrientation = false;
            this.horizontalOrientation = false;
            providedPoints.Clear();

            return false;
        }

        return true;
    }
}
