using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public class NitrineParticleNebulae : GalacticBase
{
    private const int BasicSize = 1000;
    public NitrineParticleNebulae(IList<ObstacleBase> obstacles, int size = BasicSize)
        : base(obstacles, size, GalacticTypes.NitrineParticleNebulae)
    {
        if (obstacles == null)
        {
            obstacles = new Collection<ObstacleBase>();
        }

        if (!obstacles.All(it => (it is CosmoWhales)))
        {
            throw new ArgumentException("Strange obstacle for NitrineParticleNebulae!", nameof(obstacles));
        }
    }

    public NitrineParticleNebulae()
        : base(new List<ObstacleBase>(), BasicSize, GalacticTypes.NitrineParticleNebulae) { }

    public NitrineParticleNebulae(int size)
        : base(new List<ObstacleBase>(), size, GalacticTypes.NitrineParticleNebulae) { }
}