using System;
using Itmo.ObjectOrientedProgramming.Lab1.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
public abstract class DeflectorBase
{
    private HitPoints _state;
    private PhotonDeflectorBase _photonDeflector;
    protected DeflectorBase(int deflectorDensity, PhotonDeflectorBase? photonDeflector = null)
    {
        if (deflectorDensity < 0)
        {
            throw new NegativeValueException(nameof(deflectorDensity));
        }

        _state = new HitPoints(deflectorDensity);
        _photonDeflector = photonDeflector ?? new NullPhotonDeflector();
    }

    public HitPoints State => _state;
    public PhotonDeflectorBase PhotonDeflector => _photonDeflector;
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
