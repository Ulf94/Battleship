namespace BattleShips.UnitTests.Services;

using System;
using System.Collections.Generic;
using Battleships.Constants;
using Battleships.Interfaces;
using Battleships.Services;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

[TestClass]
public sealed class PointsProviderFactoryTests
{
    private readonly Mock<IConsoleIO> console = new();
    private readonly Mock<ICustomRandom> random = new();

    [TestMethod]
    public void OnGivenInvalidString_ShouldThrowException()
    {
        //GIVEN
        var providers = new List<IPointsProvider>()
        {
            new UserPointsProvider(this.console.Object),
            new ComputerPointsProvider(this.console.Object, this.random.Object),
        };

        //WHEN
        var action = () => new PointsProvidersFactory(providers).GetInstance("test");

        //THEN
        action.Should()
            .Throw<InvalidOperationException>()
            ;
    }

    [TestMethod]
    public void OnGivenString_ShouldReturnComputerImplementationOfIPointsProvider()
    {
        //GIVEN
        var providers = new List<IPointsProvider>()
        {
            new UserPointsProvider(this.console.Object),
            new ComputerPointsProvider(this.console.Object, this.random.Object),
        };

        //WHEN
        var providerImplementations = new PointsProvidersFactory(providers).GetInstance(PlayerNames.COMPUTER);

        //THEN
        providerImplementations.Should()
            .BeOfType(typeof(ComputerPointsProvider));
    }

    [TestMethod]
    public void OnGivenString_ShouldReturnUserImplementationOfIPointsProvider()
    {
        //GIVEN
        var providers = new List<IPointsProvider>()
        {
            new UserPointsProvider(this.console.Object),
            new ComputerPointsProvider(this.console.Object, this.random.Object),
        };

        //WHEN
        var providerImplementations = new PointsProvidersFactory(providers).GetInstance(PlayerNames.USER);

        //THEN
        providerImplementations.Should()
            .BeOfType(typeof(UserPointsProvider));
    }
}
