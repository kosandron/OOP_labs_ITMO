using System;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.ComputerValidator;

public class NotSupportedCpuProblem : IComputerBuildProblem
{
    public string GetProblemDescription()
    {
        return "CPU is not supported by BIOS!";
    }

    public bool IsValid(Computer computer)
    {
        if (computer == null)
        {
            throw new ArgumentNullException(nameof(computer));
        }

        return computer.MotherBoard.Bios.SupportedCpuList.Any(cpu => cpu.Equals(computer.Cpu.Name, StringComparison.OrdinalIgnoreCase));
    }
}