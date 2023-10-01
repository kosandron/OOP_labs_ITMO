using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;

public abstract class EngineBase
{
    protected const int BasicStartSpeed = 2;
    protected EngineBase(int speed, int gasTankReserve)
    {
        if (speed < 0)
        {
            throw new ArgumentException("Speed is less or equal 0!", nameof(speed));
        }

        Speed = speed;
        GasTankReserve = new GasTank(gasTankReserve);
    }

    public int StartPain { get; init; }
    public GasTank GasTankReserve { get; init; }
    public int Speed { get; init; }
    public abstract int GetTimeForPath(int pathLength);
    public abstract int GetPathForTime(int time);
    public abstract int GetOilForPath(int pathLength);
    public abstract bool IsSupportedSpace(GalacticBase galactic);
}