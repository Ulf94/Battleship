namespace Battleships.Services;

using Battleships.Constants;
using Battleships.Interfaces;
using Battleships.Models;

internal sealed class ShipService : IShipService
{
    private readonly IPointsProvidersFactory pointsProvidersFactory;

    public ShipService(IPointsProvidersFactory pointsProvidersFactory)
    {
        this.pointsProvidersFactory = pointsProvidersFactory;
    }

    public List<Ship> CreateShips(string userType)
    {
        var allPoints = new List<Point>();
        var ships = new List<Ship>();

        var battleShip1Points = this.pointsProvidersFactory.GetInstance(userType).GetPoints(ShipSizes.BATTLESHIP, allPoints);
        var battleShip1 = new Ship(battleShip1Points, userType, ShipSizes.BATTLESHIP);

        ships.Add(battleShip1);

        var battleShip2Points = this.pointsProvidersFactory.GetInstance(userType).GetPoints(ShipSizes.BATTLESHIP, allPoints);
        var battleShip2 = new Ship(battleShip2Points, userType, ShipSizes.BATTLESHIP);

        ships.Add(battleShip2);

        var destroyerPoints = this.pointsProvidersFactory.GetInstance(userType).GetPoints(ShipSizes.DESTROYER, allPoints);
        var userDestroyer = new Ship(destroyerPoints, userType, ShipSizes.DESTROYER);

        ships.Add(userDestroyer);

        return ships;
    }
}
