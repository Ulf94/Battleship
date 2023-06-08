namespace Battleships.Services;

using Battleships.Constants;
using Battleships.Helpers;
using Battleships.Interfaces;
using Battleships.Models;

internal class ComputerPointsProvider : IPointsProvider
{
    private readonly IConsoleIO console;
    private readonly ICustomRandom random;

    public ComputerPointsProvider(IConsoleIO console, ICustomRandom random)
        => (this.console, this.random) = (console, random);

    public List<Point> GetPoints(int shipSize)
    {
        var points = new List<Point>();

        var startX = this.random.GetRandomX(1, 10);
        var startY = this.random.GetRandomY(1, 10);
        var orientation = this.random.GetRandomOrientation(1, 10);

        if (orientation % 2 == 0)
        {
            if (startY - shipSize >= 0)
            {
                for (int i = 0; i < shipSize; i++)
                {
                    points.Add(new Point(startX, startY - i));
                }
            }
            else
            {
                for (int i = 0; i < shipSize; i++)
                {
                    points.Add(new Point(startX, startY + i));
                }
            }
        }
        else
        {
            if (startX - shipSize >= 0)
            {
                for (int i = 0; i < shipSize; i++)
                {
                    points.Add(new Point(startX - i, startY));
                }
            }
            else
            {
                for (int i = 0; i < shipSize; i++)
                {
                    points.Add(new Point(startX + i, startY));
                }
            }
        }

        return points;
    }

    public Point Shoot()
    {
        var computerShootAt = new Point(this.random.GetRandomX(1, BoardSize.COLUMNS), this.random.GetRandomY(1, BoardSize.ROWS));
        this.console.WriteLine($"Computer is shooting at: {computerShootAt.PointToString()}");

        return computerShootAt;
    }
}
