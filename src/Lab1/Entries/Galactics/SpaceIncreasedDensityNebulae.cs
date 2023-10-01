using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public class SpaceIncreasedDensityNebulae : GalacticBase
{
    private const int BasicSize = 1000;
    public SpaceIncreasedDensityNebulae(IList<ObstacleBase> obstacles, int size = BasicSize)
        : base(obstacles, size, GalacticTypes.SpaceIncreasedDensityNebulae)
    {
        if (obstacles == null)
        {
            obstacles = new Collection<ObstacleBase>();
        }

        if (!obstacles.All(it => (it is AntimatterFlares)))
        {
            throw new ArgumentException("Strange obstacle for SpaceIncreasedDensityNebulae!", nameof(obstacles));
        }
    }

    public SpaceIncreasedDensityNebulae()
        : base(new List<ObstacleBase>(), BasicSize, GalacticTypes.SpaceIncreasedDensityNebulae) { }

    public SpaceIncreasedDensityNebulae(int size)
        : base(new List<ObstacleBase>(), size, GalacticTypes.SpaceIncreasedDensityNebulae) { }
}