namespace Battleships.Interfaces;

public interface ICustomRandom
{
    public int GetRandomOrientation(int start, int end);
    public int GetRandomX(int start, int end);
    public int GetRandomY(int start, int end);
}
