namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public interface IComponentFactory<T>
{
    T? CreateByName(string name);
}