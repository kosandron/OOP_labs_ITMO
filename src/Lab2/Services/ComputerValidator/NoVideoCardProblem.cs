using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.ComputerValidator;

public class NoVideoCardProblem : IComputerBuildProblem
{
    public string GetProblemDescription()
    {
        return "There is no videocard!";
    }

    public bool IsValid(Computer computer)
    {
        if (computer == null)
        {
            throw new ArgumentNullException(nameof(computer));
        }

        return computer.Cpu.HasVideoCerr || computer.VideoCard != null;
    }
}