using System;
using Itmo.ObjectOrientedProgramming.Lab1.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;

public class HddBuilder
{
    private string? _name;
    private int _memory = -1;
    private int _spindleSpeed = -1;
    private PowerConsumption? _powerConsumption;

    public HddBuilder() { }

    public HddBuilder(Hdd otherHdd)
    {
        if (otherHdd == null)
        {
            throw new ArgumentNullException(nameof(otherHdd));
        }

        _name = otherHdd.Name;
        _memory = otherHdd.Memory;
        _spindleSpeed = otherHdd.SpindleSpeed;
        _powerConsumption = otherHdd.PowerConsumption;
    }

    public HddBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public HddBuilder WithMemory(int memory)
    {
        _memory = memory;
        return this;
    }

    public HddBuilder WithSpindleSpeed(int speed)
    {
        _spindleSpeed = speed;
        return this;
    }

    public HddBuilder WithPowerConsumption(PowerConsumption powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public Hdd Build()
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

        if (_spindleSpeed <= 0)
        {
            throw new NegativeValueException("Spindle speed is less than 0 or not declared!");
        }

        return new Hdd(_name, _memory, _spindleSpeed, _powerConsumption);
    }
}