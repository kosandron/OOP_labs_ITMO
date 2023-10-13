using Itmo.ObjectOrientedProgramming.Lab1.Entities.Galactics;
using Itmo.ObjectOrientedProgramming.Lab1.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;

public abstract class EngineBase
{
    protected const int BasicStartSpeed = 2;
    protected EngineBase(int speed, int gasTankReserve)
    {
        if (speed < 0)
        {
            throw new NegativeValueException(nameof(speed));
        }

        if (gasTankReserve < 0)
        {
            throw new NegativeValueException(nameof(gasTankReserve));
        }

        Speed = speed;
        GasTankReserve = new GasTank(gasTankReserve);
    }

    public int StartSpentOil { get; init; }
    public GasTank GasTankReserve { get; init; }
    public int Speed { get; init; }
    public abstract int GetTimeForPath(int pathLength);
    public abstract int GetPathForTime(int time);
    public abstract int GetOilForPath(int pathLength);
    public abstract bool IsSupportedSpace(GalacticBase galactic);
}