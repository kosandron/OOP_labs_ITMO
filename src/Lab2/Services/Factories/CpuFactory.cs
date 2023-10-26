using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Factories;

public class CpuFactory : FactoryBase<Cpu>
{
    public CpuFactory(ICollection<Cpu> components)
        : base(components)
    {
    }
}