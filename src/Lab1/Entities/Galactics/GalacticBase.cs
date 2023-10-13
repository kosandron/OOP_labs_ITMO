using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Galactics;

public abstract class GalacticBase
{
    private IList<ObstacleBase> _obstacles;
    protected GalacticBase(IList<ObstacleBase> obstacles, int size)
    {
            if (size <= 0)
            {
                throw new NegativeValueException(nameof(size));
            }

            obstacles ??= new Collection<ObstacleBase>();
            if (obstacles.Any(it => it is null))
            {
                throw new ArgumentNullException(nameof(obstacles));
            }

            _obstacles = obstacles;
            Size = size;
    }

    public IImmutableList<ObstacleBase> Obstacles => _obstacles.ToImmutableList();
    public int Size { get; private set; }
}