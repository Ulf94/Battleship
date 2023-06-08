namespace Battleships.Models;

using Battleships.Constants;
using Battleships.Helpers;
using Battleships.Interfaces;

internal sealed class Game : IGame
{
    private string computerName { get; } = OwnerType.COMPUTER;
    private string userName { get; } = OwnerType.USER;
    private readonly IConsoleIO console;
    private readonly IPointsProvidersFactory pointsProvidersFactory;
    private readonly IUserService user;
    private User computer { get; set; }
    private Board computerBoard { get; set; }
    public bool gameIsFinished { get; set; } = default;
    private User user1 { get; set; }
    private Board userBoard { get; set; }

    public Game(IConsoleIO console, IUserService user, IPointsProvidersFactory pointsProvidersFactory)
    {
        this.console = console;
        this.pointsProvidersFactory = pointsProvidersFactory;
        this.user = user;

        this.user1 = user.CreateUser(OwnerType.USER);
        this.userBoard = new Board(this.user1.Ships);

        this.computer = user.CreateUser(OwnerType.COMPUTER);
        this.computerBoard = new Board(this.computer.Ships);

        this.console.WriteLine("Field is prepared. Let's start the battle!");
        DrawBoard.OutputBoards(this.userBoard, this.computerBoard);
    }

    public ShootResult ComputerTurn(Point shootAt)
    {
        //var fireAt = this.computer.Shoot();
        //var computerShootResult = this.userBoard.FireAt(fireAt);
        //this.AllShipsSunk(this.user1);
        //DrawBoard.OutputBoards(this.userBoard, this.computerBoard);

        //return computerShootResult;
        return ShootResult.Miss;
    }

    public bool GameIsFinished()
        => this.gameIsFinished;

    public ShootResult UserTurn(Point shootAt)
    {
        //var fireAt = this.user1.Shoot();
        //var userShootResult = this.computerBoard.FireAt(fireAt);
        //this.AllShipsSunk(this.computer);
        //DrawBoard.OutputBoards(this.userBoard, this.computerBoard);

        //return userShootResult;
        return ShootResult.Miss;
    }

    private void AllShipsSunk(User player)
    {
        var shipsStatuses = player.Ships.Select(ship => ship.isSunk);

        if (shipsStatuses.All(status => status))
            this.gameIsFinished = true;
    }
}
