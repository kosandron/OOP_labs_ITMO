using Itmo.ObjectOrientedProgramming.Lab1.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Hull;
public abstract class HullBase
{
    private HitPoints _state;
    protected HullBase(int deflectorDensity)
    {
        if (deflectorDensity <= 0)
        {
            throw new NegativeValueException(nameof(deflectorDensity));
        }

        _state = new HitPoints(deflectorDensity);
    }

    public HitPoints State => _state;
    public bool IsDead => State.IsDead;
    public void TakeDamage(int damage)
    {
        if (damage <= 0)
        {
            throw new NegativeValueException(nameof(damage));
        }

        State.DecreaseHitPoints(damage);
    }
}
