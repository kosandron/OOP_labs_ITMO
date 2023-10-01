using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Hull;
public abstract class HullBase
{
    protected HullBase(int deflectorDensity)
    {
        if (deflectorDensity <= 0)
        {
            throw new ArgumentException("Deflector density is less or equal than 0!", nameof(deflectorDensity));
        }

        State = new HitPoints(deflectorDensity);
    }

    public HitPoints State { get; init; }
    public bool IsDead => State.IsDead;
    public void TakeDamage(int damage)
    {
        if (damage <= 0)
        {
            throw new ArgumentException("Damage is less or equal null!", nameof(damage));
        }

        State.DecreaseHitPoints(damage);
    }
}
