using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.ComputerValidator;

public class RamXmpAndStandartFrequencyValidator : IComputerBuildProblem
{
    public string GetProblemDescription()
    {
        return "XMP frequency is less than standart frequency!";
    }

    public bool IsValid(Computer computer)
    {
        if (computer is null)
        {
            throw new ArgumentNullException(nameof(computer));
        }

        if (computer.Ram.XMP is not null)
        {
            return computer.Ram.XMP.XmpFrequency.Value >= computer.Ram.Frequency.Value;
        }

        return true;
    }
}