using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class SupportedComponentBase<T>
    where T : IComponent
{
    private IList<T> _components;

    public SupportedComponentBase(IList<T> components)
    {
        if (components is null)
        {
            throw new ArgumentNullException(nameof(components));
        }

        _components = components;
    }

    public ImmutableList<T> ComponentList => _components.ToImmutableList();

    public void AddComponent(T newComponent)
    {
        if (newComponent is null)
        {
            throw new ArgumentNullException(nameof(newComponent));
        }

        if (!_components.Any(c => c.Name.Equals(newComponent.Name, StringComparison.OrdinalIgnoreCase)))
        {
            _components.Add(newComponent);
        }
    }
}