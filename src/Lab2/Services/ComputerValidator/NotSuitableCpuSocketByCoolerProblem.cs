using System;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.ComputerValidator;

public class NotSuitableCpuSocketByCoolerProblem : IComputerBuildProblem
{
    public string GetProblemDescription()
    {
        return "CPU socket is not suitable to cooler socket!";
    }

    public bool IsValid(Computer computer)
    {
        if (computer == null)
        {
            throw new ArgumentNullException(nameof(computer));
        }

        return computer.CpuCooler.SupportedSockedList.Any(socket => socket.Version.Equals(computer.Cpu.CpuSocket.Version, StringComparison.OrdinalIgnoreCase));
    }
}