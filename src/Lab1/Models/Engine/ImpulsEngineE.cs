using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;
public class ImpulsEngineE : ImpulsEngineBase
{
    public ImpulsEngineE(int speed = BasicStartSpeed, int gasTankReserve = 0, int startPain = BasicStartPain)
        : base(speed, gasTankReserve, startPain) { }
    public override int GetTimeForPath(int pathLength)
    {
        if (pathLength <= 0)
        {
            throw new ArgumentException("Length of path is less or equal 0!", nameof(pathLength));
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
}
