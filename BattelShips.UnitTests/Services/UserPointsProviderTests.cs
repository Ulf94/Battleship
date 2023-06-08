namespace BattleShips.UnitTests.Services;

using Battleships.Interfaces;
using Battleships.Services;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

[TestClass]
public class UserPointsProviderTests
{
    private const int SHIP_SIZE = 5;
    private readonly Mock<IConsoleIO> console = new();

    [TestMethod]
    public void OnGivenPoints_ShouldReturnListOfPoints()
    {
        //GIVEN

        var userPointsProvider = new UserPointsProvider(new ConsoleIOTest());

        //WHEN
        var result = userPointsProvider.GetPoints(SHIP_SIZE);

        //THEN
        result.Should()
            .HaveCount(SHIP_SIZE)
            ;
    }
}
