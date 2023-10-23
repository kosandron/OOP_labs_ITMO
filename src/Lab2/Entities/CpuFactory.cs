using System;
using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class CpuFactory : IComponentFactory<Cpu>
{
    private readonly ICollection<Cpu> _cpuList;

    public CpuFactory(ICollection<Cpu> cpuList)
    {
        _cpuList = cpuList;
    }

    public Cpu? CreateByName(string name)
    {
        return _cpuList
            .FirstOrDefault(cpu => cpu.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
            ?.Clone();
    }
}