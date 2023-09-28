namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;

public class NullJumpEngine : JumpEngineBase
{
    public NullJumpEngine()
        : base(0,  0) { }

    public override int GetTimeForPath(int pathLength)
    {
        return int.MaxValue;
    }

    public override int GetPathForTime(int time)
    {
        return 0;
    }
}