using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class PowerSupply : IComponent, ICloneable<PowerSupply>, ICopyable<PowerSupply>
{
    private readonly PowerConsumption _powerConsumption;

    public PowerSupply(string? name, PowerConsumption? powerConsumption)
    {
        if (name is null)
        {
            throw new ArgumentNullException(nameof(name));
        }

        if (powerConsumption is null)
        {
            throw new ArgumentNullException(nameof(powerConsumption));
        }

        Name = name;
        _powerConsumption = powerConsumption;
    }

    private PowerSupply(PowerSupply other)
    {
        if (other == null)
        {
            throw new ArgumentNullException(nameof(other));
        }

        Name = other.Name;
        _powerConsumption = other._powerConsumption;
    }

    public string Name { get; init; }
    public PowerConsumption PowerConsumption => _powerConsumption;

    public PowerSupply Clone() => new PowerSupply(this);
    public PowerSupply DeepCopy()
    {
        return new PowerSupply(Name, PowerConsumption.DeepCopy());
    }
}