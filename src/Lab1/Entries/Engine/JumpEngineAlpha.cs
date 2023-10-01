﻿using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;
public class JumpEngineAlpha : JumpEngineBase
{
    private GalacticBase _possibleGalacticType;
    public JumpEngineAlpha(GalacticBase? possibleGalactic, int maxJumpDistanse = 1000, int speed = BasicStartSpeed, int gasTankReserve = 0)
        : base(maxJumpDistanse, speed, gasTankReserve)
    {
        _possibleGalacticType = possibleGalactic ?? new SpaceIncreasedDensityNebulae();
    }

    public override int GetTimeForPath(int pathLength)
    {
        if (pathLength <= 0)
        {
            throw new ArgumentException("Length of path is less or equal 0!", nameof(pathLength));
        }

        return pathLength / Speed;
    }

    public override int GetPathForTime(int time)
    {
        if (time <= 0)
        {
            throw new ArgumentException("Time is less or equal 0!", nameof(time));
        }

        return time * Speed;
    }

    public override bool IsSupportedSpace(GalacticBase galactic)
    {
        if (galactic == null)
        {
            return false;
        }

        return galactic.Type == _possibleGalacticType.Type && galactic.Size <= MaxJumpDistanse;
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
