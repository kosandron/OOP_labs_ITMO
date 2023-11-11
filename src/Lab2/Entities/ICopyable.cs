namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public interface ICopyable<out T>
{
    T DeepCopy();
}