using System;
using Itmo.ObjectOrientedProgramming.Lab1.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class HDD
{
    private readonly int _memory;
    private readonly int _spindleSpeed;
    private readonly PowerConsumption _powerConsumption;

    public HDD(int memory, int spindleSpeed, PowerConsumption powerConsumption)
    {
        if (powerConsumption == null)
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

        _memory = memory;
        _spindleSpeed = spindleSpeed;
        _powerConsumption = powerConsumption;
    }

    public int Memory => _memory;
    public int SpindleSpeed => _spindleSpeed;
    public PowerConsumption PowerConsumption => _powerConsumption;
}