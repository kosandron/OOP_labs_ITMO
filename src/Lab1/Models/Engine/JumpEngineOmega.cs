﻿using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;

public class JumpEngineOmega : JumpEngineBase
{
    public JumpEngineOmega(int speed = BasicStartSpeed, int gasTankReserve = 0)
        : base(speed, gasTankReserve) { }

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
}