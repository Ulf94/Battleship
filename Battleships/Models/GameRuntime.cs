namespace Battleships.Models;

using Battleships.Interfaces;

internal sealed class GameRuntime
{
    private readonly IGame game;

    public GameRuntime(IGame game)
    {
        this.game = game;

        do
        {
            var userResult = this.game.UserTurn();
            Console.WriteLine($"You {userResult}\n");
            var computerResult = this.game.ComputerTurn();
            Console.WriteLine($"Computer {computerResult}\n");
        } while (this.game.GameIsFinished() is false);
    }
}
