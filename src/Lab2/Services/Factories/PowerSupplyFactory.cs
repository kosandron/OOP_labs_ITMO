using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Factories;

public class PowerSupplyFactory : FactoryBase<PowerSupply>
{
    public PowerSupplyFactory(ICollection<PowerSupply> components)
        : base(components) { }

    public PowerSupplyFactory()
        : base(new List<PowerSupply>()
        {
            new PowerSupply("Supply small", new PowerConsumption(300)),
            new PowerSupply("Supply big", new PowerConsumption(600)),
        }) { }
}