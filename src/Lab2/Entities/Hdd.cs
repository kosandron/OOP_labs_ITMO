using System;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Hdd : IComponent, ICloneable<Hdd>, ICopyable<Hdd>
{
    private readonly int _memory;
    private readonly int _spindleSpeed;
    private readonly PowerConsumption _powerConsumption;

    public Hdd(string? name, int memory, int spindleSpeed, PowerConsumption? powerConsumption)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentNullException(nameof(name));
        }

        if (powerConsumption is null)
        {
            throw new ArgumentNullException(nameof(powerConsumption));
        }

        if (memory <= 0)
        {
            throw new NegativeValueException("Memory is less than 0!");
        }

        if (spindleSpeed <= 0)
        {
            throw new NegativeValueException("Spindle speed is less than 0!");
        }

        Name = name;
        _memory = memory;
        _spindleSpeed = spindleSpeed;
        _powerConsumption = powerConsumption;
    }

    public Hdd(Hdd other)
    {
        if (other is null)
        {
            throw new ArgumentNullException(nameof(other));
        }

        Name = other.Name;
        _memory = other._memory;
        _spindleSpeed = other._spindleSpeed;
        _powerConsumption = other._powerConsumption;
    }

    public string Name { get; init; }
    public int Memory => _memory;
    public int SpindleSpeed => _spindleSpeed;
    public PowerConsumption PowerConsumption => _powerConsumption;

    public Hdd Clone() => new Hdd(this);
    public Hdd DeepCopy()
    {
        return new Hdd(Name, Memory, SpindleSpeed, PowerConsumption.DeepCopy());
    }
}