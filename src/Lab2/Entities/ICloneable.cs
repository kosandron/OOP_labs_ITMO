namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public interface ICloneable<out T>
    where T : IComponent
{
    T Clone();
}