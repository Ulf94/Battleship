namespace BattleShips.UnitTests;

using System;
using System.Collections.Generic;
using Battleships.Interfaces;

internal class ConsoleIOTest : IConsoleIO
{
    private readonly List<string> listOfPoints = new()
    {
        "A1",
        "A2",
        "A3",
        "A4",
        "A5",
    };

    public string ReadLine()
    {
        var result = this.listOfPoints[0];
        this.listOfPoints.RemoveAt(0);

        return result;
    }

    public void Write(string message)
    {
        Console.Write(message);
    }

    public void WriteLine(string message)
    {
        Console.WriteLine(message);
    }
}
