namespace Battleships.Models;

using Battleships.Constants;

internal class Board
{
    private List<Point> BoardPositions { get; }
    private List<Ship> UserShips { get; } = new();

    public Board(List<Ship> ships)
    {
        this.BoardPositions = new List<Point>();

        for (var i = 1; i <= BoardSize.COLUMNS; i++)
        {
            for (var j = 1; j <= BoardSize.ROWS; j++)
            {
                this.BoardPositions.Add(new Point(i, j));
            }
        }

        this.UserShips = ships;

        foreach (var ship in this.UserShips)
        {
            var shipPositions = ship.Points;

            foreach (var shipPosition in shipPositions)
            {
                this.BoardPositions.First(boardPosition => boardPosition.X == shipPosition.X
                                                           && boardPosition.Y == shipPosition.Y).OccupationType = ship.OccupationType;
            }
        }
    }

    public ShootResult FireAt(Point fireAtPoint)
    {
        foreach (var ship in this.UserShips)
        {
            foreach (var shipPoint in ship.Points)
            {
                if ((shipPoint.X == fireAtPoint.X) && (shipPoint.Y == fireAtPoint.Y))
                {
                    shipPoint.OccupationType = OccupationType.X;
                    ship.Hits++;
                    this.BoardPositions.Single(position => position.X == fireAtPoint.X && position.Y == fireAtPoint.Y).OccupationType = OccupationType.X;

                    return ShootResult.Hit;
                }
                else
                {
                    this.BoardPositions.Single(position => position.X == fireAtPoint.X && position.Y == fireAtPoint.Y).OccupationType = OccupationType.M;

                    continue;
                }
            }
        }

        return ShootResult.Miss;
    }

    public OccupationType GeOccupationTypeOfPosition(int x, int y)
    {
        return this.BoardPositions.Single(position => position.X == x && position.Y == y).OccupationType;
    }
}
