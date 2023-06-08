namespace Battleships.Models;

using Battleships.Constants;
using Battleships.Helpers;
using Battleships.Interfaces;

internal sealed class Game : IGame
{
    private string computerName { get; } = PlayerNames.COMPUTER;
    private string userName { get; } = PlayerNames.USER;
    private readonly IConsoleIO console;
    private readonly IPointsProvidersFactory pointsProvidersFactory;
    private readonly IUserService userService;
    private User computer { get; set; }
    private Board computerBoard { get; set; }
    public bool gameIsFinished { get; set; } = default;
    private User user1 { get; set; }
    private Board userBoard { get; set; }

    public Game(IConsoleIO console, IUserService userService, IPointsProvidersFactory pointsProvidersFactory)
    {
        this.console = console;
        this.pointsProvidersFactory = pointsProvidersFactory;
        this.userService = userService;

        this.user1 = userService.CreateUser(PlayerNames.USER);
        this.userBoard = new Board(this.user1.Ships);

        this.computer = userService.CreateUser(PlayerNames.COMPUTER);
        this.computerBoard = new Board(this.computer.Ships);

        this.console.WriteLine("Field is prepared. Let's start the battle!");
        DrawBoard.OutputBoards(this.userBoard, this.computerBoard);
    }

    public ShootResult ComputerTurn()
    {
        var fireAt = this.userService.Shoot(PlayerNames.COMPUTER);
        var computerShootResult = this.userBoard.FireAt(fireAt);
        this.AllShipsSunk(this.user1);
        DrawBoard.OutputBoards(this.userBoard, this.computerBoard);

        return computerShootResult;
    }

    public bool GameIsFinished()
        => this.gameIsFinished;

    public ShootResult UserTurn()
    {
        var fireAt = this.userService.Shoot(PlayerNames.USER);
        var userShootResult = this.computerBoard.FireAt(fireAt);
        this.AllShipsSunk(this.computer);
        DrawBoard.OutputBoards(this.userBoard, this.computerBoard);

        return userShootResult;
    }

    private void AllShipsSunk(User player)
    {
        var shipsStatuses = player.Ships.Select(ship => ship.isSunk);

        if (shipsStatuses.All(status => status))
            this.gameIsFinished = true;
    }
}
