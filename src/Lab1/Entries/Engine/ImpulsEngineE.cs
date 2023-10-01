using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;
public class ImpulsEngineE : ImpulsEngineBase
{
    private GalacticBase _possibleGalacticType;

    public ImpulsEngineE(GalacticBase? possibleGalactic, int speed = BasicStartSpeed, int gasTankReserve = 0, int startPain = BasicStartPain)
        : base(speed, gasTankReserve, startPain)
    {
        _possibleGalacticType = possibleGalactic ?? new NitrineParticleNebulae();
    }

    public override int GetTimeForPath(int pathLength)
    {
        if (pathLength < 0)
        {
            throw new ArgumentException("Length of path is less 0!", nameof(pathLength));
        }

        return (int)Math.Log2(pathLength * Math.Log(2));
    }

    public override int GetPathForTime(int time)
    {
        if (time <= 0)
        {
            throw new ArgumentException("Time is less or equal 0!", nameof(time));
        }

        return (int)(Math.Pow(2, time) / Math.Log(2));
    }

    public override bool IsSupportedSpace(GalacticBase galactic)
    {
        if (galactic == null)
        {
            return false;
        }

        return galactic.Type == _possibleGalacticType.Type;
    }

    public override int GetOilForPath(int pathLength)
    {
        if (pathLength < 0)
        {
            throw new ArgumentException("Time is less 0!", nameof(pathLength));
        }

        return GetTimeForPath(pathLength) + StartPain;
    }
}
