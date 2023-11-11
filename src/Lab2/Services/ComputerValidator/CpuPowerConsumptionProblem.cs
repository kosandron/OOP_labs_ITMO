using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.ComputerValidator;

public class CpuPowerConsumptionProblem : IComputerBuildProblem
{
    public string GetProblemDescription()
    {
        return "Powerconsumption of CPU is more tham cooler powerdissipation!";
    }

    public bool IsValid(Computer computer)
    {
        if (computer == null)
        {
            throw new ArgumentNullException(nameof(computer));
        }

        return computer.Cpu.CpuTDP.Value <= computer.CpuCooler.PowerDissipation.Value;
    }
}