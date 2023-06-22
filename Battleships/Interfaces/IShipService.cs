namespace Battleships.Interfaces;

using Battleships.Models;

public interface IShipService
{
    public List<Ship> CreateShips(string owner);
}
