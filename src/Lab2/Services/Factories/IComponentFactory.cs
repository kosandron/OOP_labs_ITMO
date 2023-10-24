namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Factories;

public interface IComponentFactory<out T>
{
    T? CreateByName(string name);
}