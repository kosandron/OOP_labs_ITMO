using System;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public abstract class ShipBase
{
    protected ShipBase(ImpulsEngineBase? shipImpulsEngine, JumpEngineBase? shipJumpEngine, Hull.HullBase hull, DeflectorBase? deflector, bool antiNitrineEmitterEnabled = false)
    {
        if (hull == null)
        {
            throw new ArgumentNullException(nameof(hull));
        }

        ShipImpulsEngine = shipImpulsEngine ?? new NullImpulsEngine();
        ShipJumpEngine = shipJumpEngine ?? new NullJumpEngine();
        Hull = hull;
        Deflector = deflector ?? new NullDeflector();
        AntiNitrineEmitter = antiNitrineEmitterEnabled;
    }

    public bool AntiNitrineEmitter { get; private init; }
    public bool IsAlive { get; private set; } = true;
    public bool PeopleAreAlive { get; private set; } = true;
    public ImpulsEngineBase ShipImpulsEngine { get; private init; }
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
            throw new ArgumentException("Damage is equal or less 0!", nameof(damage));
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
        ShipImpulsEngine.IsSupportedSpace(galactic) || ShipJumpEngine.IsSupportedSpace(galactic);

    public EngineBase GetOptimalEngine(GalacticBase galactic)
    {
        if (ShipImpulsEngine.IsSupportedSpace(galactic))
        {
            return ShipImpulsEngine;
        }
        else
        {
            return ShipJumpEngine;
        }
    }
}