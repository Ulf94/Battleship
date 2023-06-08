namespace Battleships.Helpers;

using Battleships.Models;
using static System.Char;

public static class Extensions
{
    public static string PointToString(this Point givenPoint)
    {
        var column = givenPoint.X.IntToStringColumnParser();
        var row = givenPoint.Y.ToString();

        return $"{column}{row}";
    }

    public static Point? StringToPoint(this string givenPoint)
    {
        var chars = givenPoint.ToCharArray();

        var column = chars[0].CharToIntColumnParser();
        int row = 0;

        if (column < 1 || column > 10)
        {
            return null;
        }

        if (chars.Length == 2)
        {
            row = (int)GetNumericValue(chars[1]);
        }
        else if (chars.Length == 3)
        {
            var rowString = $"{chars[1]}{chars[2]}";
            Int32.TryParse(rowString, out row);
        }

        if (row < 1 || row > 10)
        {
            return null;
        }

        var point = new Point()
        {
            X = column,
            Y = row,
        };

        return point;
    }

    private static int CharToIntColumnParser(this char columnSign) =>
        columnSign switch
        {
            'A' => 1,
            'B' => 2,
            'C' => 3,
            'D' => 4,
            'E' => 5,
            'F' => 6,
            'G' => 7,
            'H' => 8,
            'I' => 9,
            'J' => 10,
            _ => -1,
        };

    private static string IntToStringColumnParser(this int columnValue) =>
        columnValue switch
        {
            1 => "A",
            2 => "B",
            3 => "C",
            4 => "D",
            5 => "E",
            6 => "F",
            7 => "G",
            8 => "H",
            9 => "I",
            10 => "J",
            _ => "_",
        };
}
