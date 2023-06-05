namespace BattleShips.UnitTests.Helpers.Extensions;

using Battleships.Helpers;
using Battleships.Models;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class ExtensionTests
{
    [TestMethod]
    public void OnGivenCorrectString_ShouldReturnPoint()
    {
        //GIVEN
        var input = "A1";

        //WHEN
        var point = input.StringToPoint();

        //THEN
        point.Should()
            .NotBeNull()
            .And
            .BeEquivalentTo(new Point(1, 1))
            ;
    }

    [TestMethod]
    public void OnGivenFirstCharOutOfBound_ShouldReturnNull()
    {
        //GIVEN
        var input = "O1";

        //WHEN
        var point = input.StringToPoint();

        //THEN
        point.Should()
            .BeNull()
            ;
    }

    [TestMethod]
    public void OnGivenOneCharString_ShouldReturnNull()
    {
        //GIVEN
        var input = "A";

        //WHEN
        var point = input.StringToPoint();

        //THEN
        point.Should()
            .BeNull()
            ;
    }

    [TestMethod]
    public void OnGivenSecondCharOutOfBound_ShouldReturnNull()
    {
        //GIVEN
        var input = "A0";

        //WHEN
        var point = input.StringToPoint();

        //THEN
        point.Should()
            .BeNull()
            ;
    }

    [TestMethod]
    public void OnGivenThreeCharsString_ShouldReturnNull()
    {
        //GIVEN
        var input = "A11";

        //WHEN
        var point = input.StringToPoint();

        //THEN
        point.Should()
            .BeNull()
            ;
    }
}
