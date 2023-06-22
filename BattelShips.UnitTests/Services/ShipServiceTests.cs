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
public sealed class ShipServiceTests
{
    private static readonly List<Point> pointsOne = new()
    {
        new(1, 1),
        new(1, 2),
        new(1, 3),
        new(1, 4),
        new(1, 5),
    };

    private static readonly List<Point> pointsThree = new()
    {
        new(3, 1),
        new(3, 2),
        new(3, 3),
        new(3, 4),
    };

    private static readonly List<Point> pointsTwo = new()
    {
        new(2, 1),
        new(2, 2),
        new(2, 3),
        new(2, 4),
        new(2, 5),
    };

    private readonly List<Ship> expectedShips = new()
    {
        new(pointsOne, PlayerNames.USER, ShipSizes.BATTLESHIP),
        new(pointsTwo, PlayerNames.USER, ShipSizes.BATTLESHIP),
        new(pointsThree, PlayerNames.USER, ShipSizes.DESTROYER),
    };

    private readonly Mock<IPointsProvidersFactory> pointsProvidersFactory = new();

    [TestMethod]
    public void ShouldReturnListOfShips()
    {
        //GIVEN
        this.pointsProvidersFactory.SetupSequence(service =>
                service.GetInstance(PlayerNames.USER).GetPoints(It.IsAny<int>(), new List<Point>()))
            .Returns(pointsOne)
            .Returns(pointsTwo)
            .Returns(pointsThree);

        var shipService = new ShipService(this.pointsProvidersFactory.Object);

        //WHEN
        var ships = shipService.CreateShips(PlayerNames.USER);

        //THEN
        ships.Should()
            .NotBeNull()
            .And
            .BeEquivalentTo(this.expectedShips)
            ;
    }
}
