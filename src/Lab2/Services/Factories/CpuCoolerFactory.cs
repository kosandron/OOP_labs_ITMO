using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Factories;

public class CpuCoolerFactory : FactoryBase<CpuCooler>
{
    public CpuCoolerFactory(ICollection<CpuCooler> components)
        : base(components)
    {
    }
}