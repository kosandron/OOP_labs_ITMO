using System;
using Itmo.ObjectOrientedProgramming.Lab1.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Enums;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Ssd
{
    private readonly PCIETypes? _pcieType;
    private readonly int _memory;
    private readonly int _maxSpeed;
    private readonly PowerConsumption _powerConsumption;

    public Ssd(PCIETypes? pcieType, int memory, int maxSpeed, PowerConsumption powerConsumption)
    {
        if (powerConsumption == null)
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

        _pcieType = pcieType;
        _memory = memory;
        _maxSpeed = maxSpeed;
        _powerConsumption = powerConsumption;
    }

    public PCIETypes? PcieType => _pcieType;
    public int Memory => _memory;
    public int MaxSpeed => _maxSpeed;
    public PowerConsumption PowerConsumption => _powerConsumption;
}