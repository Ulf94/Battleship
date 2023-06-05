namespace Battleships.Interfaces;

public interface IConsoleIO
{
    string ReadLine();
    void Write(string message);
    void WriteLine(string message);
}
