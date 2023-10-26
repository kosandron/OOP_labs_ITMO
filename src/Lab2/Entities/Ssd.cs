using System;
using Itmo.ObjectOrientedProgramming.Lab2.Enums;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Ssd : IComponent, ICloneable<Ssd>, ICopyable<Ssd>
{
    private readonly PCIETypes _pcieType;
    private readonly int _memory;
    private readonly int _maxSpeed;
    private readonly PowerConsumption _powerConsumption;

    public Ssd(string? name, PCIETypes? pcieType, int memory, int maxSpeed, PowerConsumption? powerConsumption)
    {
        if (name is null)
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

        if (maxSpeed <= 0)
        {
            throw new NegativeValueException("Maximal speed is less than 0!");
        }

        Name = name;
        _pcieType = pcieType ?? PCIETypes.None;
        _memory = memory;
        _maxSpeed = maxSpeed;
        _powerConsumption = powerConsumption;
    }

    private Ssd(Ssd other)
    {
        if (other == null)
        {
            throw new ArgumentNullException(nameof(other));
        }

        Name = other.Name;
        _pcieType = other._pcieType;
        _memory = other._memory;
        _maxSpeed = other._maxSpeed;
        _powerConsumption = other._powerConsumption;
    }

    public string Name { get; init; }

    public PCIETypes PcieType => _pcieType;
    public int Memory => _memory;
    public int MaxSpeed => _maxSpeed;
    public PowerConsumption PowerConsumption => _powerConsumption;

    public Ssd Clone() => new Ssd(this);
    public Ssd DeepCopy()
    {
        return new Ssd(Name, PcieType, Memory, MaxSpeed, PowerConsumption.DeepCopy());
    }
}