using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class SupportedPowerSupply : SupportedComponentBase<PowerSupply>
{
    public SupportedPowerSupply()
    : base(new List<PowerSupply>()
        {
            new PowerSupply("Supply small", new PowerConsumption(300)),
            new PowerSupply("Supply big", new PowerConsumption(600)),
        }) { }
}