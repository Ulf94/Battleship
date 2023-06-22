namespace Battleships.Services;

using Battleships.Interfaces;
using Battleships.Models;

internal sealed class UserService : IUserService
{
    private readonly IPointsProvidersFactory pointsProvidersFactory;

    private readonly IShipService shipService;

    public UserService(IPointsProvidersFactory pointsProvidersFactory, IShipService shipService)
    {
        this.pointsProvidersFactory = pointsProvidersFactory;
        this.shipService = shipService;
    }

    public User CreateUser(string userType)
    {
        var ships = this.shipService.CreateShips(userType);

        var allUserPoints = ships.SelectMany(ship => ship.Points).ToList();

        var user = new User
        {
            Ships = ships,
            AllPoints = allUserPoints,
            Name = userType,
        };

        return user;
    }

    public Point Shoot(string user)
    {
        return this.pointsProvidersFactory.GetInstance(user).Shoot();
    }
}
