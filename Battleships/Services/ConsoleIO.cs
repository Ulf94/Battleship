namespace Battleships.Services;

using Battleships.Interfaces;

internal class ConsoleIO : IConsoleIO
{
    public string ReadLine()
    {
        bool correctInput = false;
        string? input;

        do
        {
            input = Console.ReadLine();

            if (input is null || string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Incorrect input!");
            }
            else
            {
                correctInput = true;
            }
        } while (correctInput is false);

        return input!;
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
