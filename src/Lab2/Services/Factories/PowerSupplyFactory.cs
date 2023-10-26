using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Factories;

public class PowerSupplyFactory : FactoryBase<PowerSupply>
{
    public PowerSupplyFactory(ICollection<PowerSupply> components)
        : base(components) { }
}