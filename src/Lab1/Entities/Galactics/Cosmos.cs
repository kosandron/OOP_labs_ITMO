using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Galactics;

public class Cosmos : GalacticBase
{
    private const int BasicSize = 1000;
    public Cosmos(IList<ObstacleBase> obstacles, int size = BasicSize)
        : base(obstacles, size)
    {
        if (obstacles.Any(it => it is AntimatterFlares or CosmoWhales))
        {
            throw new ArgumentException("Strange obstacle for cosmos!", nameof(obstacles));
        }
    }

    public Cosmos(int size = BasicSize)
        : base(new List<ObstacleBase>(), size) { }
}