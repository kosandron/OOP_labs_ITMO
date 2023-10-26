using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class SupportedComponentBase<T>
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
}