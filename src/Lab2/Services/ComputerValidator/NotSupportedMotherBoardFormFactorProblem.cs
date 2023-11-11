using System;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.ComputerValidator;

public class NotSupportedMotherBoardFormFactorProblem : IComputerBuildProblem
{
    public string GetProblemDescription()
    {
        return "Mother board form factor is not supported by computer case!";
    }

    public bool IsValid(Computer computer)
    {
        if (computer == null)
        {
            throw new ArgumentNullException(nameof(computer));
        }

        return computer.ComputerCase.SupportedFormFactorTypes.Any(formFactor => formFactor.Equals(computer.MotherBoard.MotherBoardFormFactor));
    }
}