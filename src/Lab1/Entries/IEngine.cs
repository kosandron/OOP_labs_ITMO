namespace Itmo.ObjectOrientedProgramming.Lab1.Entries;

public interface IEngine
{
    public int GetTimeForPath(int pathLength);
    public int GetPathForTime(int time);
}