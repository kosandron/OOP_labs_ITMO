namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;
public abstract class JumpEngineBase : EngineBase
{
    protected JumpEngineBase(int speed, int gasTankReserve)
        : base(speed, gasTankReserve)
    {
        StartPain = 0;
    }
}
