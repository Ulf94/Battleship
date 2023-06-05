namespace Battleships.Services;

using Battleships.Interfaces;

internal sealed class CustomRandom : ICustomRandom
{
    private readonly Random rand = new Random();

    public int GetRandomOrientation(int start, int end)
    {
        return this.rand.Next(start, end);
    }

    public int GetRandomX(int start, int end)
    {
        return this.rand.Next(start, end);
    }

    public int GetRandomY(int start, int end)
    {
        return this.rand.Next(start, end);
    }
}
