namespace Battleships.Services;

using Battleships.Helpers;
using Battleships.Interfaces;
using Battleships.Models;

internal class UserPointsProvider : IPointsProvider
{
    private readonly IConsoleIO console;

    public UserPointsProvider(IConsoleIO console)
        => this.console = console;

    public List<Point> GetPoints(int shipSize)
    {
        var i = 0;
        var listOfUserPoints = new List<Point>();

        while (i < shipSize)
        {
            this.console.Write("Provide point: ");
            var pointAsString = this.console.ReadLine();
            var point = pointAsString.StringToPoint();

            if (point is not null)
            {
                var availablePoint = listOfUserPoints.Contains(point);

                if (availablePoint is false)
                {
                    listOfUserPoints.Add(point!);
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

        return listOfUserPoints;
    }
}
