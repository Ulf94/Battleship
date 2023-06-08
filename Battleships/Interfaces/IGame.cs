namespace Battleships.Interfaces;

using Battleships.Constants;
using Battleships.Models;

public interface IGame
{
    public ShootResult ComputerTurn(Point point);
    public bool GameIsFinished();
    public ShootResult UserTurn(Point point);
}
