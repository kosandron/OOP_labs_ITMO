namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;

public class NullImpulsEngine : ImpulsEngineBase
{
    public NullImpulsEngine()
        : base(0, 0, 0) { }

    public override int GetTimeForPath(int pathLength)
    {
        return int.MaxValue;
    }

    public override int GetPathForTime(int time)
    {
        return 0;
    }
}