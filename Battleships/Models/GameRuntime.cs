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
            var x = Console.ReadLine();
            //this.game.UserTurn()
        } while (this.game.GameIsFinished() is false);
    }
}
