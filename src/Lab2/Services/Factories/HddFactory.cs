using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Factories;

public class HddFactory : FactoryBase<Hdd>
{
    public HddFactory(ICollection<Hdd> components)
        : base(components) { }
}
