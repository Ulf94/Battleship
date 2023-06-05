namespace Battleships.Interfaces;

public interface IPointsProvidersFactory
{
    public IPointsProvider GetInstance(string typeOfProvider);
}
