using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Galactics;

public class NitrineParticleNebulae : GalacticBase
{
    private const int BasicSize = 1000;
    public NitrineParticleNebulae(IList<ObstacleBase> obstacles, int size = BasicSize)
        : base(obstacles, size)
    {
        if (!obstacles.All(it => it is CosmoWhales))
        {
            throw new ArgumentException("Strange obstacle for NitrineParticleNebulae!", nameof(obstacles));
        }
    }

    public NitrineParticleNebulae(int size = BasicSize)
        : base(new List<ObstacleBase>(), size) { }
}