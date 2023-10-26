using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.ComputerValidator;

public class NotSuitableXMPChipset : IComputerBuildProblem
{
    public string GetProblemDescription()
    {
        return "XMP is not suitable to chipset";
    }

    public bool IsValid(Computer computer)
    {
        if (computer is null)
        {
            throw new ArgumentNullException(nameof(computer));
        }

        if (computer.Ram.XMP is not null)
        {
            return computer.Ram.XMP.XmpFrequency.Value <= computer.MotherBoard.Chipset.XmpFrequency.Value;
        }

        return true;
    }
}