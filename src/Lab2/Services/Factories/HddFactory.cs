using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Factories;

public class HddFactory : FactoryBase<Hdd>
{
    public HddFactory(ICollection<Hdd> components)
        : base(components) { }

    public HddFactory()
        : base(new List<Hdd>()
        {
            new Hdd(
                "WD Blue",
                4,
                7200,
                new PowerConsumption(68)),
            new Hdd(
                "WD Black",
                256,
                7200,
                new PowerConsumption(53)),
        }) { }
}
