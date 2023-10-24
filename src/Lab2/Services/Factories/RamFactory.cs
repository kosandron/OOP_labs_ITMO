using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Factories;

public class RamFactory : FactoryBase<Ram>
{
    public RamFactory(ICollection<Ram> components)
        : base(components)
    {
    }
}