namespace Battleships.Services;

using Battleships.Interfaces;
using Battleships.Models;

internal sealed class ShipService : IShipService
{
    public Ship CreateShip(List<Point> shiPoints, string owner, int shipSize)
    {
        var newShip = new Ship(shiPoints, owner, shipSize);

        return newShip;
    }
}
