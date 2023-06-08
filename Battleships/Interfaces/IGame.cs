namespace Battleships.Interfaces;

using Battleships.Constants;

public interface IGame
{
    public ShootResult ComputerTurn();
    public bool GameIsFinished();
    public ShootResult UserTurn();
}
