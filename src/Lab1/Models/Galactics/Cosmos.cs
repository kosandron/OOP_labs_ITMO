using System;
using System.Collections.ObjectModel;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public class Cosmos : GalacticBase
{
    public Cosmos(in Collection<ObstacleBase> obstacles, int size)
        : base(obstacles, size)
    {
        if (obstacles.Any(it => ((it is CosmoWhales) || (it is AntimatterFlares))))
        {
            throw new ArgumentException("Strange obstacle for cosmos!", nameof(obstacles));
        }
    }
}