namespace Battleships.Services;

using Battleships.Constants;
using Battleships.Interfaces;
using Battleships.Models;

internal sealed class UserService : IUserService
{
    private readonly IPointsProvidersFactory pointsProvidersFactory;

    private readonly IShipService shipService;
    private List<Point> allPoints { get; set; } = new();
    private string name { get; set; } = string.Empty;

    public UserService(IPointsProvidersFactory pointsProvidersFactory, IShipService shipService)
    {
        this.pointsProvidersFactory = pointsProvidersFactory;
        this.shipService = shipService;
    }

    public User CreateUser(string userType)
    {
        this.name = userType;
        //var userBattleShip1 = new Ship(this.allPoints, this.pointsProvidersFactory, this.name, ShipSizes.BATTLESHIP);
        var userBattleShip1Points = this.pointsProvidersFactory.GetInstance(userType).GetPoints(ShipSizes.BATTLESHIP);
        var userBattleShip1 = this.shipService.CreateShip(userBattleShip1Points, userType, ShipSizes.BATTLESHIP);

        var userBattleShip2Points = this.pointsProvidersFactory.GetInstance(userType).GetPoints(ShipSizes.BATTLESHIP);
        var userBattleShip2 = this.shipService.CreateShip(userBattleShip2Points, userType, ShipSizes.BATTLESHIP);

        var userDestroyerPoints = this.pointsProvidersFactory.GetInstance(userType).GetPoints(ShipSizes.DESTROYER);
        var userDestroyer = this.shipService.CreateShip(userDestroyerPoints, userType, ShipSizes.DESTROYER);

        var userShips = new List<Ship>
        {
            userBattleShip1,
            userBattleShip2,
            userDestroyer,
        };

        var user = new User()
        {
            Ships = userShips,
            allPoints = new List<Point>(),
            name = this.name,
        };

        return user;
    }

    public Point Shoot(string user)
    {
        return this.pointsProvidersFactory.GetInstance(user).Shoot();
    }
}
