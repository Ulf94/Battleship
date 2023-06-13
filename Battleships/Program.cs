using Battleships.Interfaces;
using Battleships.Models;
using Battleships.Services;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

services.AddSingleton<ICustomRandom, CustomRandom>();
services.AddSingleton<IConsoleIO, ConsoleIO>();
services.AddSingleton<IPointsProvider, UserPointsProvider>();
services.AddSingleton<IPointsProvider, ComputerPointsProvider>();
services.AddSingleton<IPointsProvidersFactory, PointsProvidersFactory>();
services.AddSingleton<IGame, Game>();
services.AddSingleton<IUserService, UserService>();
services.AddSingleton<IShipService, ShipService>();

var game = services.BuildServiceProvider().GetRequiredService<IGame>();

var gameRuntime = new GameRuntime(game);
