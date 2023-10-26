using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.ComputerValidator;

public class NotSupportedRamFrequency : IComputerBuildProblem
{
    public string GetProblemDescription()
    {
        return "RAM XMP-Profile is not supported by mother board!";
    }

    public bool IsValid(Computer computer)
    {
        if (computer == null)
        {
            throw new ArgumentNullException(nameof(computer));
        }

        return computer.Ram.Frequency.Value <= computer.MotherBoard.Chipset.XmpFrequency.Value;
    }
}