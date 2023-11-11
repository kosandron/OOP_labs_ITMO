using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.ComputerValidator;

public class NotSupportedCpu : INotSupportedCpuValidator
{
    public void Validate(IList<string>? supportedCpuList)
    {
        if (supportedCpuList is null)
        {
            throw new ArgumentNullException(nameof(supportedCpuList));
        }

        var ds = new SupportedCpu();
        ImmutableList<Cpu> cpuList = new SupportedCpu().ComponentList;
        foreach (string cpu in supportedCpuList)
        {
            if (cpu is null)
            {
                throw new ArgumentNullException(nameof(supportedCpuList), "Element of list is null!");
            }

            if (!cpuList.Any(supportedCpu => supportedCpu.Name.Equals(cpu, StringComparison.OrdinalIgnoreCase)))
            {
                throw new ArgumentException("Not supported CPU!");
            }
        }
    }
}