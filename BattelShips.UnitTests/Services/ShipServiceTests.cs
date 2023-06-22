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
    private readonly List<Point> pointsOne = new()
    {
        new(1, 1),
        new(1, 2),
        new(1, 3),
        new(1, 4),
        new(1, 5),
    };

    private readonly Mock<IPointsProvidersFactory> pointsProvidersFactory = new();

    private readonly List<Point> pointsThree = new()
    {
        new(3, 1),
        new(3, 2),
        new(3, 3),
        new(3, 4),
    };

    private readonly List<Point> pointsTwo = new()
    {
        new(2, 1),
        new(2, 2),
        new(2, 3),
        new(2, 4),
        new(2, 5),
    };

    [TestMethod]
    public void ShouldReturnListOfShips()
    {
        //GIVEN
        this.pointsProvidersFactory.SetupSequence(service =>
                service.GetInstance(PlayerNames.USER).GetPoints(It.IsAny<int>(), new List<Point>()))
            .Returns(this.pointsOne)
            .Returns(this.pointsTwo)
            .Returns(this.pointsThree);

        var shipService = new ShipService(this.pointsProvidersFactory.Object);

        //WHEN
        var ships = shipService.CreateShips(PlayerNames.USER);

        //THEN
        ships.Should()
            .NotBeNull()
            ;
    }
}
