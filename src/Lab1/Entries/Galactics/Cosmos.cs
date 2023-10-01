using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public class Cosmos : GalacticBase
{
    private const int BasicSize = 1000;
    public Cosmos(IList<ObstacleBase> obstacles, int size = BasicSize)
        : base(obstacles, size, GalacticTypes.Cosmos)
    {
        if (obstacles == null)
        {
            obstacles = new Collection<ObstacleBase>();
        }

        if (obstacles.Any(it => ((it is CosmoWhales) || (it is AntimatterFlares))))
        {
            throw new ArgumentException("Strange obstacle for cosmos!", nameof(obstacles));
        }
    }

    public Cosmos()
        : base(new List<ObstacleBase>(), BasicSize, GalacticTypes.Cosmos) { }

    public Cosmos(int size)
        : base(new List<ObstacleBase>(), size, GalacticTypes.Cosmos) { }
}