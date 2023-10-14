using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Galactics;

public class SpaceIncreasedDensityNebulae : GalacticBase
{
    private const int BasicSize = 1000;
    public SpaceIncreasedDensityNebulae(IList<ObstacleBase> obstacles, int size = BasicSize)
        : base(obstacles, size)
    {
        if (!obstacles.All(it => it is AntimatterFlares))
        {
            throw new ArgumentException("Strange obstacle for SpaceIncreasedDensityNebulae!", nameof(obstacles));
        }
    }

    public SpaceIncreasedDensityNebulae(int size = BasicSize)
        : base(new List<ObstacleBase>(), size) { }
}