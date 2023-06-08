namespace BattleShips.UnitTests.UserBoard;

using System.Collections.Generic;
using Battleships.Constants;
using Battleships.Interfaces;
using Battleships.Models;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

[TestClass]
public sealed class UserBoardTests
{
    private readonly Mock<IPointsProvidersFactory> pointsProviderFactory = new();

    [TestMethod]
    public void OnGivenShipsAndEmptyPosition_ShouldReturnMiss()
    {
        //GIVEN
        var allPoints = new List<Point>();

        var shipPoints = new List<Point>
        {
            new(1, 1),
            new(1, 2),
            new(1, 3),
            new(1, 4),
            new(1, 5),
        };

        this.pointsProviderFactory.Setup(provider => provider.GetInstance(PlayerNames.USER).GetPoints(ShipSizes.BATTLESHIP)).Returns(shipPoints);

        var ships = new List<Ship>
        {
            new Ship(shipPoints, PlayerNames.USER, ShipSizes.BATTLESHIP),
        };

        var userBoard = new Board(ships);

        //WHEN
        var fireAtPoint = new Point(2, 1);
        var result = userBoard.FireAt(fireAtPoint);

        //THEN
        result.Should()
            .Be(ShootResult.Miss)
            ;
    }

    [TestMethod]
    public void OnGivenShipsAndShipPosition_ShouldReturnHit()
    {
        //GIVEN
        var allPoints = new List<Point>();

        var shipPoints = new List<Point>
        {
            new(1, 1),
            new(1, 2),
            new(1, 3),
            new(1, 4),
            new(1, 5),
        };

        this.pointsProviderFactory.Setup(provider => provider.GetInstance(PlayerNames.USER).GetPoints(ShipSizes.BATTLESHIP)).Returns(shipPoints);

        var ships = new List<Ship>
        {
            new Ship(shipPoints, PlayerNames.USER, ShipSizes.BATTLESHIP),
        };

        var userBoard = new Board(ships);

        //WHEN
        var fireAtPoint = new Point(1, 1);
        var result = userBoard.FireAt(fireAtPoint);

        //THEN
        result.Should()
            .Be(ShootResult.Hit)
            ;
    }
}
