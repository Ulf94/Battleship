namespace Battleships.Services;

using Battleships.Constants;
using Battleships.Interfaces;

internal class PointsProvidersFactory : IPointsProvidersFactory
{
    private readonly IEnumerable<IPointsProvider> providers;

    public PointsProvidersFactory(IEnumerable<IPointsProvider> providers)
        => this.providers = providers;

    public IPointsProvider GetInstance(string typeOfProvider)
        => typeOfProvider switch
        {
            PlayerNames.COMPUTER => this.GetService(typeof(ComputerPointsProvider)),
            PlayerNames.USER => this.GetService(typeof(UserPointsProvider)),
            _ => throw new InvalidOperationException(),
        };

    private IPointsProvider GetService(Type type)
    {
        return this.providers.FirstOrDefault(provider => provider.GetType() == type)!;
    }
}
