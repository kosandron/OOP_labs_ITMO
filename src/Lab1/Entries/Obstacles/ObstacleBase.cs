using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public abstract class ObstacleBase
{
    protected ObstacleBase(int damage)
    {
        if (damage <= 0)
        {
            throw new ArgumentException("Damage is less or equal null!", nameof(damage));
        }

        Damage = damage;
    }

    public int Damage { get; init; }
    public abstract void MakeDamage(ref ShipBase ship);
}