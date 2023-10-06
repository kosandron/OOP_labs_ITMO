using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;
public abstract class JumpEngineBase : EngineBase
{
    protected JumpEngineBase(int maxJumpDistance, int speed, int gasTankReserve)
        : base(speed, gasTankReserve)
    {
        if (maxJumpDistance < 0)
        {
            throw new NegativeValueException(nameof(maxJumpDistance));
        }

        StartSpentOil = 0;
        MaxJumpDistance = maxJumpDistance;
    }

    protected int MaxJumpDistance { get; init; }
}
