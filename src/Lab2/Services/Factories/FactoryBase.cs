using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Factories;

public class FactoryBase<T> : IComponentFactory<T>
    where T : class, IComponent, ICopyable<T>
{
    private readonly ICollection<T> _components;

    public FactoryBase(ICollection<T> components)
    {
        _components = components;
    }

    public T? CreateByName(string name)
    {
        return _components.FirstOrDefault(component => component.Name.Equals(name, StringComparison.OrdinalIgnoreCase))?.DeepCopy();

        // return _components.FirstOrDefault(component => component.Name.Equals(name, StringComparison.OrdinalIgnoreCase))?.DeepCopy();

        // error: Unable to lift conditional access expression type 'T?' to nullable type if ?.
    }
}