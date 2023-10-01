using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;
public abstract class JumpEngineBase : EngineBase
{
    protected JumpEngineBase(int maxJumpDistanse, int speed, int gasTankReserve)
        : base(speed, gasTankReserve)
    {
        if (maxJumpDistanse < 0)
        {
            throw new ArgumentException("Max length of jump distanse is negative!");
        }

        StartPain = 0;
        MaxJumpDistanse = maxJumpDistanse;
    }

    public int MaxJumpDistanse { get; init; }
}
