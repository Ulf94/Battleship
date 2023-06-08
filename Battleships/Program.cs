using Battleships.Interfaces;
using Battleships.Models;
using Battleships.Services;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

services.AddScoped<ICustomRandom, CustomRandom>();
services.AddScoped<IConsoleIO, ConsoleIO>();
services.AddScoped<IPointsProvider, UserPointsProvider>();
services.AddScoped<IPointsProvider, ComputerPointsProvider>();
services.AddTransient<IPointsProvidersFactory, PointsProvidersFactory>();
services.AddSingleton<IGame, Game>();
services.AddScoped<IUserService, UserService>();
services.AddScoped<IShipService, ShipService>();

var pointsProviderFactory = services.BuildServiceProvider().GetRequiredService<IPointsProvidersFactory>();
var consoleService = services.BuildServiceProvider().GetRequiredService<IConsoleIO>();
var game = services.BuildServiceProvider().GetRequiredService<IGame>();

var gameRuntime = new GameRuntime(game);

//var game = new Game(consoleService, OwnerType.COMPUTER, OwnerType.USER, pointsProviderFactory);
