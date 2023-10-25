using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.ComputerValidator;

public class NotSuitableCpuSocketByMotherBoardProblem : IComputerBuildProblem
{
    public string GetProblemDescription()
    {
        return "CPU socket is not suitable to mother board socket!";
    }

    public bool IsValid(Computer computer)
    {
        if (computer == null)
        {
            throw new ArgumentNullException(nameof(computer));
        }

        return computer.Cpu.CpuSocket.Version.Equals(computer.MotherBoard.CpuSocket.Version, StringComparison.OrdinalIgnoreCase);
    }
}