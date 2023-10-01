using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public abstract class GalacticBase
{
    protected GalacticBase(IList<ObstacleBase> obstacles, int size, GalacticTypes galacticType)
    {
            ArgumentNullException.ThrowIfNull("List of obstascles is Null!", nameof(obstacles));
            if (size <= 0)
            {
                throw new ArgumentException("Size of Galactic is less or equal 0!", nameof(size));
            }

            if (obstacles == null)
            {
                obstacles = new Collection<ObstacleBase>();
            }

            Obstacles = obstacles;
            Size = size;
            Type = galacticType;
    }

    public IList<ObstacleBase> Obstacles { get; private set;  }
    public int Size { get; private set; }
    public GalacticTypes Type { get; init; }
}