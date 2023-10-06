using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Galactics;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;

public abstract class ShipBase
{
    protected ShipBase(ImpulseEngineBase? shipImpulsEngine, JumpEngineBase? shipJumpEngine, Hull.HullBase hull, DeflectorBase? deflector, bool antiNitrineEmitterEnabled = false)
    {
        if (hull == null)
        {
            throw new ArgumentNullException(nameof(hull));
        }

        ShipImpulseEngine = shipImpulsEngine ?? new NullImpulseEngine();
        ShipJumpEngine = shipJumpEngine ?? new NullJumpEngine();
        Hull = hull;
        Deflector = deflector ?? new NullDeflector();
        AntiNitrineEmitter = antiNitrineEmitterEnabled;
    }

    public bool AntiNitrineEmitter { get; private init; }
    public bool IsAlive { get; private set; } = true;
    public bool PeopleAreAlive { get; private set; } = true;
    public ImpulseEngineBase ShipImpulseEngine { get; private init; }
    public JumpEngineBase ShipJumpEngine { get; private init; }
    public DeflectorBase Deflector { get; private set; }
    public Hull.HullBase Hull { get; private set; }
    public void Kill()
    {
        IsAlive = false;
    }

    public void KillPeople()
    {
        PeopleAreAlive = false;
    }

    public void UpdateDefense()
    {
        if (Deflector.IsDead)
        {
            Deflector = new NullDeflector();
        }
    }

    public void TakeDamage(int damage)
    {
        if (damage <= 0)
        {
            throw new NegativeValueException(nameof(damage));
        }

        if (Deflector is not NullDeflector)
        {
            Deflector.TakeDamage(damage);
            UpdateDefense();
        }
        else
        {
            Hull.TakeDamage(damage);
        }

        if (Hull.IsDead)
        {
            IsAlive = false;
        }
    }

    public bool IsSupportedSpace(GalacticBase galactic) =>
        ShipImpulseEngine.IsSupportedSpace(galactic) || ShipJumpEngine.IsSupportedSpace(galactic);

    public EngineBase GetOptimalEngine(GalacticBase galactic)
    {
        if (ShipImpulseEngine.IsSupportedSpace(galactic))
        {
            return ShipImpulseEngine;
        }
        else
        {
            return ShipJumpEngine;
        }
    }
}