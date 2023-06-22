namespace BattleShips.UnitTests.Services;

using System.Collections.Generic;
using Battleships.Constants;
using Battleships.Interfaces;
using Battleships.Models;
using Battleships.Services;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

[TestClass]
public sealed class UserServiceTests
{
    private static readonly List<Point> pointsBattleship1 = new List<Point>
    {
        new(1, 1),
        new(1, 2),
        new(1, 3),
        new(1, 4),
        new(1, 5),
    };

    private readonly Mock<IPointsProvidersFactory> pointsProviderFactory = new();
    private readonly Mock<IShipService> shipService = new();

    [TestMethod]
    public void OnGivenShips_ShouldCreateUser()
    {
        //GIVEN
        this.pointsProviderFactory.Setup(service => service.GetInstance(PlayerNames.USER).GetPoints(ShipSizes.BATTLESHIP, new List<Point>()))
            .Returns(pointsBattleship1);

        var battleship = new Ship(pointsBattleship1, PlayerNames.USER, ShipSizes.BATTLESHIP);

        this.shipService.Setup(service => service.CreateShips(PlayerNames.USER))
            .Returns(new List<Ship>
            {
                battleship,
            });

        var userService = new UserService(this.pointsProviderFactory.Object, this.shipService.Object);

        var expectedUser = new User()
        {
            AllPoints = pointsBattleship1,
            Name = PlayerNames.USER,
            Ships = new List<Ship>
            {
                battleship,
            },
        };

        //WHEN
        var result = userService.CreateUser(PlayerNames.USER);

        //THEN
        result.Should()
            .BeEquivalentTo(expectedUser)
            ;
    }
}
