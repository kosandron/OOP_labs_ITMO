using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Factories;

public class FactoryBase<T> : IComponentFactory<T>
    where T : class, IComponent, ICopyable<T>
{
    private readonly ICollection<T> _components;

    public FactoryBase()
    {
        _components = new Collection<T>();
    }

    public FactoryBase(ICollection<T> components)
    {
        _components = components;
    }

    public T? CreateByName(string name)
    {
        return _components.FirstOrDefault(component => component.Name.Equals(name, StringComparison.OrdinalIgnoreCase))?.DeepCopy();
    }
}