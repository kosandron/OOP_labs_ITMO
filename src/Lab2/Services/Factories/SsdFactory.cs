using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Factories;

public class SsdFactory : FactoryBase<Ssd>
{
    public SsdFactory(ICollection<Ssd> components)
        : base(components)
    {
    }
}