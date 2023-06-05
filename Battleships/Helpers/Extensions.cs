namespace Battleships.Helpers;

using Battleships.Models;
using static System.Char;

public static class Extensions
{
    public static Point? StringToPoint(this string givenPoint)
    {
        var chars = givenPoint.ToCharArray();

        if (chars.Length != 2)
        {
            return null;
        }

        var column = chars[0].ColumnParser();

        if (column < 1 || column > 10)
        {
            return null;
        }

        var row = (int)GetNumericValue(chars[1]);

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

    private static int ColumnParser(this char columnSign) =>
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
}
