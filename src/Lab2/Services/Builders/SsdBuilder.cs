using System;
using Itmo.ObjectOrientedProgramming.Lab1.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Enums;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;

public class SsdBuilder
{
    private string? _name;
    private PCIETypes _pcieType = PCIETypes.None;
    private int _memory;
    private int _maxSpeed;
    private PowerConsumption? _powerConsumption;

    public SsdBuilder() { }
    public SsdBuilder(Ssd otherHdd)
    {
        if (otherHdd == null)
        {
            throw new ArgumentNullException(nameof(otherHdd));
        }

        _name = otherHdd.Name;
        _memory = otherHdd.Memory;
        _maxSpeed = otherHdd.MaxSpeed;
        _powerConsumption = otherHdd.PowerConsumption;
    }

    public SsdBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public SsdBuilder WithMemory(int memory)
    {
        _memory = memory;
        return this;
    }

    public SsdBuilder WithPCIEType(PCIETypes type)
    {
        _pcieType = type;
        return this;
    }

    public SsdBuilder WithSpindleSpeed(int speed)
    {
        _maxSpeed = speed;
        return this;
    }

    public SsdBuilder WithPowerConsumption(PowerConsumption powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public Ssd Build()
    {
        if (_name == null)
        {
            throw new ArgumentNullException(nameof(_name));
        }

        if (_powerConsumption == null)
        {
            throw new ArgumentNullException(nameof(_powerConsumption));
        }

        if (_memory <= 0)
        {
            throw new NegativeValueException("Memory is less than or not declared!");
        }

        if (_maxSpeed <= 0)
        {
            throw new NegativeValueException("Maximal speed is less than 0 or not declared!");
        }

        return new Ssd(_name, _pcieType, _memory, _maxSpeed, _powerConsumption);
    }
}