using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public class NitrineParticleNebulae : GalacticBase
{
    public NitrineParticleNebulae(in Collection<ObstacleBase> obstacles, int size)
        : base(obstacles, size)
    {
        if (!obstacles.All(it => (it is CosmoWhales)))
        {
            throw new ArgumentException("Strange obstacle for NitrineParticleNebulae!", nameof(obstacles));
        }
    }
}