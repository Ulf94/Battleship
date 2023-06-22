namespace BattleShips.UnitTests.Services;

using System.Collections.Generic;
using Battleships.Constants;
using Battleships.Interfaces;
using Battleships.Models;
using Battleships.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

[TestClass]
public sealed class ShipServiceTests
{
    private readonly Mock<IPointsProvidersFactory> pointsProvidersFactory = new();
    [TestMethod]
    public void ShouldReturnListOfShips()
    {
        //GIVEN
        this.pointsProvidersFactory.SetupSequence(service => service.GetInstance(PlayerNames.USER).GetPoints(It.IsAny<int>(), new List<Point>()))
        var shipService = new ShipService(this.pointsProvidersFactory.Object);
        
        //WHEN
        var ships = shipService.CreateShips(PlayerNames.USER);
    }
}