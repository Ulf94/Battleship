namespace BattleShips.UnitTests.Ship;

using System.Collections.Generic;
using Battleships.Helpers;
using Battleships.Models;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class ParsePointFromConsoleTests
{
    private readonly List<Point> expectedPoints = new()
    {
        new Point(1, 3),
        new Point(2, 3),
        new Point(3, 3),
        new Point(4, 3),
        new Point(5, 3),
        new Point(6, 3),
        new Point(7, 3),
        new Point(8, 3),
        new Point(9, 3),
        new Point(10, 3),
    };

    private readonly List<string> givenInputs = new List<string>()
    {
        "A3",
        "B3",
        "C3",
        "D3",
        "E3",
        "F3",
        "G3",
        "H3",
        "I3",
        "J3",
    };

    [TestMethod]
    public void OnGivenString_ParseIntoColumnAndRowNumber()
    {
        //GIVEN
        var listOfParsedInputs = new List<Point>();

        //WHEN
        foreach (var givenInput in this.givenInputs)
        {
            var parsedPoint = givenInput.StringToPoint();

            if (parsedPoint is not null)
            {
                listOfParsedInputs.Add(parsedPoint);
            }
        }

        //THEN
        listOfParsedInputs.Should()
            .BeEquivalentTo(this.expectedPoints)
            ;
    }
}
