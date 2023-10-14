using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Galactics;
using Itmo.ObjectOrientedProgramming.Lab1.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;
public class ImpulseEngineE : ImpulseEngineBase
{
    public ImpulseEngineE(int speed = BasicStartSpeed, int gasTankReserve = 0, int startSpentOil = BasicstartSpentOil)
        : base(speed, gasTankReserve, startSpentOil) { }

    public override int GetTimeForPath(int pathLength)
    {
        if (pathLength < 0)
        {
            throw new NegativeValueException(nameof(pathLength));
        }

        return (int)Math.Log2(pathLength * Math.Log(2));
    }

    public override int GetPathForTime(int time)
    {
        if (time <= 0)
        {
            throw new NegativeValueException(nameof(time));
        }

        return (int)(Math.Pow(2, time) / Math.Log(2));
    }

    public override bool IsSupportedSpace(GalacticBase galactic)
    {
        if (galactic == null)
        {
            return false;
        }

        return galactic is NitrineParticleNebulae;
    }

    public override int GetOilForPath(int pathLength)
    {
        if (pathLength < 0)
        {
            throw new NegativeValueException(nameof(pathLength));
        }

        return GetTimeForPath(pathLength) + StartSpentOil;
    }
}
