namespace Battleships.Interfaces;

using Battleships.Models;

public interface IShipService
{
    public Ship CreateShip(List<Point> shiPoints, string owner, int shipSize);
}
