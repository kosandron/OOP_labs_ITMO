namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.AbstractFileSystem;

public interface ICopyable<out T>
{
    T Copy();
}