using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Factories;

public class BiosFactory : FactoryBase<Bios>
{
    public BiosFactory(ICollection<Bios> components)
        : base(components)
    {
    }
}