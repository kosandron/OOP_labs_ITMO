using System;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public abstract class GalacticBase
{
    protected GalacticBase(in Collection<ObstacleBase> obstacles, int size)
    {
            ArgumentNullException.ThrowIfNull("List of obstascles is Null!", nameof(obstacles));
            if (size <= 0)
            {
                throw new ArgumentException("Size of Galactic is less or equal 0!", nameof(size));
            }

            Obstacles = obstacles;
            Size = size;
    }

    public Collection<ObstacleBase> Obstacles { get; private set;  }
    public int Size { get; private set; }
}