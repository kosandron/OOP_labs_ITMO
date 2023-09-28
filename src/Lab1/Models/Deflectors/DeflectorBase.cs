using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Deflectors;
public abstract class DeflectorBase
{
    protected DeflectorBase(int deflectorDensity, FotonicDeflectorBase? fotonicDeflector = null)
    {
        if (deflectorDensity <= 0)
        {
            throw new ArgumentException("Deflector density is less or equal than 0!", nameof(deflectorDensity));
        }

        State = new HitPoints(deflectorDensity);
        FotonicDeflector = fotonicDeflector ?? new NullFotonicDeflector();
    }

    public HitPoints State { get; init; }
    public FotonicDeflectorBase FotonicDeflector { get; init; }
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
