namespace Battleships.Services;

using Battleships.Constants;
using Battleships.Interfaces;
using Battleships.Models;

internal sealed class UserService : IUserService
{
    private readonly IPointsProvidersFactory pointsProvidersFactory;
    private List<Point> allPoints { get; set; } = new();
    private string name { get; set; } = string.Empty;

    public UserService(IPointsProvidersFactory pointsProvidersFactory)
    {
        this.pointsProvidersFactory = pointsProvidersFactory;
    }

    public User CreateUser(string userType)
    {
        this.name = userType;
        var userBattleShip1 = new Ship(this.allPoints, this.pointsProvidersFactory, this.name, ShipSizes.BATTLESHIP);

        var userShips = new List<Ship>
        {
            userBattleShip1,
        };

        var user = new User()
        {
            Ships = userShips,
            allPoints = new List<Point>(),
            name = this.name,
        };

        return user;
    }

    public Point Shoot()
    {
        return this.pointsProvidersFactory.GetInstance(this.name).Shoot();
    }
}
