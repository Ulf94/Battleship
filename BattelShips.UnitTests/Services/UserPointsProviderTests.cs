namespace BattleShips.UnitTests.Services;

using Battleships.Interfaces;
using Battleships.Services;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

[TestClass]
public class UserPointsProviderTests
{
    private const int SHIP_SIZE = 1;
    private readonly Mock<IConsoleIO> console = new();

    [TestMethod]
    public void OnGivenPoints_ShouldReturnListOfPoints()
    {
        //GIVEN
        this.console.Setup(service => service.ReadLine()).Returns("A1");
        var userPointsProvider = new UserPointsProvider(this.console.Object);

        //WHEN
        var result = userPointsProvider.GetPoints(SHIP_SIZE);

        //THEN
        result.Should()
            .HaveCount(SHIP_SIZE)
            ;
    }
}
