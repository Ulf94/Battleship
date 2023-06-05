namespace BattleShips.UnitTests.Services;

using System;
using System.Collections.Generic;
using Battleships.Constants;
using Battleships.Interfaces;
using Battleships.Services;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public sealed class PointsProviderFactoryTests
{
    [TestMethod]
    public void OnGivenInvalidString_ShouldThrowException()
    {
        //GIVEN
        var providers = new List<IPointsProvider>()
        {
            new UserPointsProvider(new ConsoleIO()),
            new ComputerPointsProvider(new CustomRandom()),
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
            new UserPointsProvider(new ConsoleIO()),
            new ComputerPointsProvider(new CustomRandom()),
        };

        //WHEN
        var providerImplementations = new PointsProvidersFactory(providers).GetInstance(OwnerType.COMPUTER);

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
            new UserPointsProvider(new ConsoleIO()),
            new ComputerPointsProvider(new CustomRandom()),
        };

        //WHEN
        var providerImplementations = new PointsProvidersFactory(providers).GetInstance(OwnerType.USER);

        //THEN
        providerImplementations.Should()
            .BeOfType(typeof(UserPointsProvider));
    }
}
