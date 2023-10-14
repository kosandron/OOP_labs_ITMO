﻿using Itmo.ObjectOrientedProgramming.Lab1.Entities.Galactics;
using Itmo.ObjectOrientedProgramming.Lab1.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;
public class JumpEngineAlpha : JumpEngineBase
{
    public JumpEngineAlpha(int maxJumpDistance = 1000, int speed = BasicStartSpeed, int gasTankReserve = 0)
        : base(maxJumpDistance, speed, gasTankReserve) { }

    public override int GetTimeForPath(int pathLength)
    {
        if (pathLength < 0)
        {
            throw new NegativeValueException(nameof(pathLength));
        }

        return pathLength / Speed;
    }

    public override int GetPathForTime(int time)
    {
        if (time < 0)
        {
            throw new NegativeValueException(nameof(time));
        }

        return time * Speed;
    }

    public override bool IsSupportedSpace(GalacticBase galactic)
    {
        if (galactic == null)
        {
            return false;
        }

        return galactic is SpaceIncreasedDensityNebulae && galactic.Size <= MaxJumpDistance;
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
