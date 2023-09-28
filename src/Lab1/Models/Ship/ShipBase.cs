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

    public bool AntiNitrineEmitter { get; init; }
    public bool IsAlive { get; private set; }
    public int PeopleCount { get; private set; }
    public bool ArePeopleDead => PeopleCount == 0;
    public ImpulsEngineBase ShipImpulsEngine { get; init; }
    public JumpEngineBase ShipJumpEngine { get; init; }
    public DeflectorBase Deflector { get; private set; }
    public Hull.HullBase Hull { get; private set; }
    public void Kill()
    {
        IsAlive = false;
    }

    public void KillPeople()
    {
        PeopleCount = 0;
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
    }
}