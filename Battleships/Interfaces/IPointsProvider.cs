﻿namespace Battleships.Interfaces;

using Battleships.Models;

public interface IPointsProvider
{
    public List<Point> GetPoints(int shipSize);
    public Point Shoot();
}
