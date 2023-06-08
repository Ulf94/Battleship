namespace BattleShips.UnitTests.Helpers.Extensions;

using System.Collections.Generic;
using Battleships.Helpers;
using Battleships.Models;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class ExtensionTests
{
    [TestMethod]
    public void OnGivenColumnCharOutOfRange_ShouldThrowReturnUnderscore()
    {
        //GIVEN
        var point = new Point(11, 1);
        //WHEN
        var result = point.PointToString();

        //THEN
        result.Should()
            .NotBeNull()
            .And
            .Be("_1")
            ;
    }

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
    public void OnGivenPoint_ShouldReturnString()
    {
        //GIVEN
        var listOfPoints = new List<Point>
        {
            new(1, 1),
            new(2, 2),
            new(3, 3),
            new(4, 4),
            new(5, 5),
            new(6, 6),
            new(7, 7),
            new(8, 8),
            new(9, 9),
            new(10, 10),
        };

        var expectedStrings = new List<string>
        {
            "A1",
            "B2",
            "C3",
            "D4",
            "E5",
            "F6",
            "G7",
            "H8",
            "I9",
            "J10",
        };

        var givenPoint = new Point(1, 1);
        //WHEN
        var results = new List<string>();

        foreach (var point in listOfPoints)
        {
            results.Add(point.PointToString());
        }

        //THEN
        results.Should()
            .BeEquivalentTo(expectedStrings)
            ;
    }

    [TestMethod]
    public void OnGivenPoint110_ShouldReturnStringA10()
    {
        //GIVEN
        var givenPoint = new Point(1, 10);
        //WHEN
        var result = givenPoint.PointToString();

        //THEN
        result.Should()
            .Be("A10")
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
    public void OnGivenThreeCharsStringWithSecondAndThirIncorrect_ShouldReturnNull()
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
