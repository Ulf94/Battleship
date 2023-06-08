namespace Battleships.Helpers;

using Battleships.Constants;
using Battleships.Models;

internal static class DrawBoard
{
    public static void OutputBoards(Board userBoard, Board computerBoard)
    {
        Console.WriteLine("        Your Board                            Computer's Board");
        Console.WriteLine("    A B C D E F G H I J                      A B C D E F G H I J");

        for (int row = 1; row <= 10; row++)
        {
            if (row < 10)
                Console.Write(" " + row + "  ");
            else
                Console.Write(row + "  ");

            for (int column = 1; column <= 10; column++)
            {
                Console.Write(userBoard.GeOccupationTypeOfPosition(column, row) + " ");
            }

            Console.Write("                 ");

            if (row < 10)
                Console.Write(" " + row + "  ");
            else
                Console.Write(row + "  ");

            for (int column = 1; column <= 10; column++)
            {
                var computerOccupation = computerBoard.GeOccupationTypeOfPosition(column, row);

                if (computerOccupation == OccupationType.B || computerOccupation == OccupationType.D)
                    computerOccupation = OccupationType.O;

                Console.Write(computerOccupation + " ");
            }

            Console.WriteLine();
        }

        Console.WriteLine(Environment.NewLine);
    }
}
