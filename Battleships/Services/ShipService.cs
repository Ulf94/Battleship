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

        var battleShip1Points = this.pointsProvidersFactory.GetInstance(userType).GetPoints(ShipSizes.BATTLESHIP, allPoints);
        var battleShip1 = new Ship(battleShip1Points, userType, ShipSizes.BATTLESHIP);

        var battleShip2Points = this.pointsProvidersFactory.GetInstance(userType).GetPoints(ShipSizes.BATTLESHIP, allPoints);
        var battleShip2 = new Ship(battleShip2Points, userType, ShipSizes.BATTLESHIP);

        var destroyerPoints = this.pointsProvidersFactory.GetInstance(userType).GetPoints(ShipSizes.DESTROYER, allPoints);
        var destroyer = new Ship(destroyerPoints, userType, ShipSizes.DESTROYER);

        var ships = new List<Ship>
        {
            battleShip1,
            battleShip2,
            destroyer,
        };

        return ships;
    }
}
