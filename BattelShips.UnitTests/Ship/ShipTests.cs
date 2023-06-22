namespace BattleShips.UnitTests.Ship;

using System.Collections.Generic;
using System.Threading.Tasks;
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

    private readonly List<Point> providedPointBattleship = new List<Point>
    {
        new(1, 1),
        new(2, 1),
        new(3, 1),
        new(4, 1),
        new(5, 1),
    };

    private readonly List<Point> providedPointDestroyer = new List<Point>
    {
        new(1, 1),
        new(2, 1),
        new(3, 1),
        new(4, 1),
    };

    [TestMethod]
    public async Task OnGivenInvalidShipSize_ThrowsInvalidOccupationTypeException()
    {
        //GIVEN
        var invalidShipSize = 6;

        //WHEN
        var action = () => new Ship(new List<Point>(), It.IsAny<string>(), invalidShipSize);

        //THEN
        action.Should()
            .Throw<InvalidOccupationTypeException>()
            ;
    }

    [TestMethod]
    public void ShouldCreateBattleship()
    {
        //GIVEN
        this.pointsProvidersFactoryMock.Setup(provider => provider.GetInstance(PlayerNames.USER).GetPoints(ShipSizes.BATTLESHIP, new List<Point>()))
            .Returns(this.providedPointBattleship);

        //WHEN
        var battleship = new Ship(this.providedPointBattleship, PlayerNames.USER, ShipSizes.BATTLESHIP);

        //THEN

        battleship.Should()
            .NotBeNull()
            ;

        battleship.Points
            .Should()
            .HaveCount(ShipSizes.BATTLESHIP)
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

        this.pointsProvidersFactoryMock.Setup(provider => provider.GetInstance(PlayerNames.COMPUTER).GetPoints(ShipSizes.DESTROYER, new List<Point>()))
            .Returns(destroyerPoints);

        //WHEN
        var destroyer = new Ship(this.providedPointDestroyer, PlayerNames.COMPUTER, ShipSizes.DESTROYER);

        //THEN

        destroyer.Should()
            .NotBeNull()
            ;

        destroyer.Points
            .Should()
            .HaveCount(ShipSizes.DESTROYER)
            ;

        destroyer.OccupationType.Should()
            .Be(OccupationType.D)
            ;
    }

    [TestMethod]
    public void WhenHitsAreGreaterOrEqualThanSize_IsSunkShouldBeTrue()
    {
        //GIVEN
        this.pointsProvidersFactoryMock.Setup(provider => provider.GetInstance(PlayerNames.USER).GetPoints(ShipSizes.BATTLESHIP, new List<Point>()))
            .Returns(this.providedPointBattleship);

        //WHEN
        var battleship = new Ship(this.providedPointBattleship, PlayerNames.USER, SHIP_SIZE)
        {
            Hits = 5,
        };

        //THEN}
        battleship.Should()
            .NotBeNull()
            ;

        battleship.IsSunk.Should()
            .BeTrue()
            ;
    }
}
