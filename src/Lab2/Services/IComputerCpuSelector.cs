using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public interface IComputerCpuSelector
{
    IComputerCpuCoolerSelector WithCpu(Cpu? cpu);
}