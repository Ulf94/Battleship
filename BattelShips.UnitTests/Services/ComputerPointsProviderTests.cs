namespace BattleShips.UnitTests.Services;

using System.Collections.Generic;
using Battleships.Interfaces;
using Battleships.Models;
using Battleships.Services;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

[TestClass]
public sealed class ComputerPointsProviderTests
{
    private const int SHIP_SIZE = 5;

    private readonly Mock<IConsoleIO> console = new();

    private readonly List<Point> expectedPointsFour = new()
    {
        new(5, 5),
        new(5, 4),
        new(5, 3),
        new(5, 2),
        new(5, 1),
    };

    private readonly List<Point> expectedPointsOne = new()
    {
        new(3, 3),
        new(3, 4),
        new(3, 5),
        new(3, 6),
        new(3, 7),
    };

    private readonly List<Point> expectedPointsThree = new()
    {
        new(3, 3),
        new(4, 3),
        new(5, 3),
        new(6, 3),
        new(7, 3),
    };

    private readonly List<Point> expectedPointsTwo = new()
    {
        new(5, 5),
        new(4, 5),
        new(3, 5),
        new(2, 5),
        new(1, 5),
    };

    private readonly Mock<ICustomRandom> randomMock = new();

    [TestMethod]
    public void OnGivenPointsFour_ShouldReturnListOfCorrectPoints()
    {
        //GIVEN
        this.randomMock.Setup(service => service.GetRandomX(1, 10)).Returns(5);
        this.randomMock.Setup(service => service.GetRandomY(1, 10)).Returns(5);
        this.randomMock.Setup(service => service.GetRandomOrientation(1, 10)).Returns(2);
        var provider = new ComputerPointsProvider(this.console.Object, this.randomMock.Object);

        //WHEN
        var result = provider.GetPoints(SHIP_SIZE);

        //THEN
        result.Should()
            .BeEquivalentTo(this.expectedPointsFour)
            ;
    }

    [TestMethod]
    public void OnGivenPointsOne_ShouldReturnListOfCorrectPoints()
    {
        //GIVEN
        this.randomMock.Setup(service => service.GetRandomX(1, 10)).Returns(3);
        this.randomMock.Setup(service => service.GetRandomY(1, 10)).Returns(3);
        this.randomMock.Setup(service => service.GetRandomOrientation(1, 10)).Returns(2);
        var provider = new ComputerPointsProvider(this.console.Object, this.randomMock.Object);

        //WHEN
        var result = provider.GetPoints(SHIP_SIZE);

        //THEN
        result.Should()
            .BeEquivalentTo(this.expectedPointsOne)
            ;
    }

    [TestMethod]
    public void OnGivenPointsThree_ShouldReturnListOfCorrectPoints()
    {
        //GIVEN
        this.randomMock.Setup(service => service.GetRandomX(1, 10)).Returns(3);
        this.randomMock.Setup(service => service.GetRandomY(1, 10)).Returns(3);
        this.randomMock.Setup(service => service.GetRandomOrientation(1, 10)).Returns(3);
        var provider = new ComputerPointsProvider(this.console.Object, this.randomMock.Object);

        //WHEN
        var result = provider.GetPoints(SHIP_SIZE);

        //THEN
        result.Should()
            .BeEquivalentTo(this.expectedPointsThree)
            ;
    }

    [TestMethod]
    public void OnGivenPointsTwo_ShouldReturnListOfCorrectPoints()
    {
        //GIVEN
        this.randomMock.Setup(service => service.GetRandomX(1, 10)).Returns(5);
        this.randomMock.Setup(service => service.GetRandomY(1, 10)).Returns(5);
        this.randomMock.Setup(service => service.GetRandomOrientation(1, 10)).Returns(3);
        var provider = new ComputerPointsProvider(this.console.Object, this.randomMock.Object);

        //WHEN
        var result = provider.GetPoints(SHIP_SIZE);

        //THEN
        result.Should()
            .BeEquivalentTo(this.expectedPointsTwo)
            ;
    }
}
