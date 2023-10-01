namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;

public class NullJumpEngine : JumpEngineBase
{
    public NullJumpEngine()
        : base(0, 0,  0) { }

    public override int GetTimeForPath(int pathLength) // в нашей программе его никогда не вызовут, но надо поддерживать (метод абстрактного класса)
    {
        return int.MaxValue;
    }

    public override int GetPathForTime(int time) => 0;
    public override int GetOilForPath(int pathLength) => 0;

    public override bool IsSupportedSpace(GalacticBase galactic) => false;
}