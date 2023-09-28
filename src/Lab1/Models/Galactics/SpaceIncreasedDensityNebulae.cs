using System;
using System.Collections.ObjectModel;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public class SpaceIncreasedDensityNebulae : GalacticBase
{
    public SpaceIncreasedDensityNebulae(in Collection<ObstacleBase> obstacles, int size)
        : base(obstacles, size)
    {
        if (!obstacles.All(it => (it is AntimatterFlares)))
        {
            throw new ArgumentException("Strange obstacle for SpaceIncreasedDensityNebulae!", nameof(obstacles));
        }
    }
}