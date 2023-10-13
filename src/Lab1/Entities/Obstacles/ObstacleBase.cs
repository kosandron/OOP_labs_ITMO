using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;
using Itmo.ObjectOrientedProgramming.Lab1.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

public abstract class ObstacleBase
{
    protected ObstacleBase(int damage)
    {
        if (damage <= 0)
        {
            throw new NegativeValueException(nameof(damage));
        }

        Damage = damage;
    }

    public int Damage { get; init; }
    public abstract void MakeDamage(ShipBase ship);
}