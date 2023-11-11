using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.ComputerValidator;

public class NoDdrConnectivityProblem : IComputerBuildProblem
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

        return computer.Ram.DdrStandart.Equals(computer.MotherBoard.DdrStandart);
    }
}