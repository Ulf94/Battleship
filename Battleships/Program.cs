using Battleships.Constants;
using Battleships.Interfaces;
using Battleships.Models;
using Battleships.Services;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

var userAllPoints = new List<Point>();
var computerAllPoints = new List<Point>();

services.AddScoped<ICustomRandom, CustomRandom>();
services.AddScoped<IConsoleIO, ConsoleIO>();
services.AddScoped<IPointsProvider, UserPointsProvider>();
services.AddScoped<IPointsProvider, ComputerPointsProvider>();
services.AddTransient<IPointsProvidersFactory, PointsProvidersFactory>();

var pointsProviderFactory = services.BuildServiceProvider().GetRequiredService<IPointsProvidersFactory>();
var consoleService = services.BuildServiceProvider().GetRequiredService<IConsoleIO>();

//Console.WriteLine("Place your first battleship");
//var userBattleShip1 = new Ship(userAllPoints, pointsProviderFactory, OwnerType.USER, ShipSizes.BATTLESHIP);
//userAllPoints.AddRange(userBattleShip1.Points);

//Console.WriteLine("Place your second battleship");
//var userBattleShip2 = new Ship(userAllPoints, pointsProviderFactory, OwnerType.USER, ShipSizes.BATTLESHIP);
//userAllPoints.AddRange(userBattleShip2.Points);

var computerBattleShip1 = new Ship(computerAllPoints, pointsProviderFactory, OwnerType.COMPUTER, ShipSizes.BATTLESHIP);
computerAllPoints.AddRange(computerBattleShip1.Points);

Console.WriteLine();

var computerBattleShip2 = new Ship(computerAllPoints, pointsProviderFactory, OwnerType.COMPUTER, ShipSizes.BATTLESHIP);
computerAllPoints.AddRange(computerBattleShip2.Points);

Console.WriteLine("Field is prepared. Let's start the battle!");

var board =
    @"  A B C D E F G H
 1
 2
 3
 4
 5
 6
 7
 8
 9
10";

Console.WriteLine(board);
