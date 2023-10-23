using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class PowerSupply
{
    private readonly PowerConsumption _powerConsumption;

    public PowerSupply(PowerConsumption powerConsumption)
    {
        if (powerConsumption == null)
        {
            throw new ArgumentNullException(nameof(powerConsumption));
        }

        _powerConsumption = powerConsumption;
    }

    public PowerConsumption PowerConsumption => _powerConsumption;
}