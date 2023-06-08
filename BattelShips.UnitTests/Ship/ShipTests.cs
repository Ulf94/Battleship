namespace BattleShips.UnitTests.Ship;

using System.Collections.Generic;
using Battleships.Constants;
using Battleships.Exceptions;
using Battleships.Interfaces;
using Battleships.Models;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

[TestClass]
public sealed class ShipTests
{
    private const int SHIP_SIZE = 5;
    private readonly List<Point> allCollectedPoints = new();
    private readonly Mock<IConsoleIO> consoleIO = new();
    private readonly Mock<IPointsProvidersFactory> pointsProvidersFactoryMock = new();

    private readonly List<Point> providedPointsOne = new List<Point>
    {
        new(1, 1),
        new(2, 1),
        new(3, 1),
        new(4, 1),
        new(5, 1),
    };

    private readonly List<Point> providedPointsThree = new List<Point>
    {
        new(1, 1),
        new(1, 2),
        new(1, 3),
        new(1, 4),
        new(1, 7),
    };

    private readonly List<Point> providedPointsTwo = new List<Point>
    {
        new(1, 1),
        new(2, 1),
        new(3, 1),
        new(4, 1),
        new(7, 1),
    };

    [TestMethod]
    public void OnGivenIncorrectPoints_ShouldNotCreateHorizontalShip()
    {
        //GIVEN
        this.pointsProvidersFactoryMock.Setup(provider => provider.GetInstance(OwnerType.USER).GetPoints(ShipSizes.BATTLESHIP))
            .Returns(this.providedPointsThree);

        //WHEN
        var action = () => new Ship(this.allCollectedPoints, this.pointsProvidersFactoryMock.Object, OwnerType.USER, ShipSizes.BATTLESHIP);

        //THEN
        action.Should()
            .Throw<InvalidPointsException>()
            ;
    }

    [TestMethod]
    public void OnGivenIncorrectPoints_ShouldNotCreateVerticalShip()
    {
        //GIVEN
        this.pointsProvidersFactoryMock.Setup(provider => provider.GetInstance(OwnerType.USER).GetPoints(ShipSizes.BATTLESHIP))
            .Returns(this.providedPointsTwo);

        //WHEN
        var action = () => new Ship(this.allCollectedPoints, this.pointsProvidersFactoryMock.Object, OwnerType.USER, ShipSizes.BATTLESHIP);

        //THEN
        action.Should()
            .Throw<InvalidPointsException>()
            ;
    }

    [TestMethod]
    public void ShouldCreateBattleship()
    {
        //GIVEN
        this.pointsProvidersFactoryMock.Setup(provider => provider.GetInstance(OwnerType.USER).GetPoints(ShipSizes.BATTLESHIP))
            .Returns(this.providedPointsOne);

        //WHEN
        var battleship = new Ship(this.allCollectedPoints, this.pointsProvidersFactoryMock.Object, OwnerType.USER, ShipSizes.BATTLESHIP);

        //THEN

        battleship.Should()
            .NotBeNull()
            ;

        battleship.Points
            .Should()
            .HaveCount(SHIP_SIZE)
            ;
    }

    [TestMethod]
    public void ShouldCreateDestroyer()
    {
        //GIVEN
        var destroyerPoints = new List<Point>
        {
            new(1, 1),
            new(1, 2),
            new(1, 3),
            new(1, 4),
        };

        this.pointsProvidersFactoryMock.Setup(provider => provider.GetInstance(OwnerType.USER).GetPoints(ShipSizes.DESTROYER))
            .Returns(destroyerPoints);

        //WHEN
        var battleship = new Ship(this.allCollectedPoints, this.pointsProvidersFactoryMock.Object, OwnerType.USER, ShipSizes.DESTROYER);

        //THEN

        battleship.Should()
            .NotBeNull()
            ;

        battleship.Points
            .Should()
            .HaveCount(ShipSizes.DESTROYER)
            ;
    }

    [TestMethod]
    public void WhenHitsAreGreaterOrEqualThanSize_IsSunkShouldBeTrue()
    {
        //GIVEN
        this.pointsProvidersFactoryMock.Setup(provider => provider.GetInstance(OwnerType.USER).GetPoints(SHIP_SIZE))
            .Returns(this.providedPointsOne);

        //WHEN
        var battleship = new Ship(this.allCollectedPoints, this.pointsProvidersFactoryMock.Object, OwnerType.USER, SHIP_SIZE)
        {
            Hits = 5,
        };

        //THEN}
        battleship.Should()
            .NotBeNull()
            ;

        battleship.isSunk.Should()
            .BeTrue()
            ;
    }
}
