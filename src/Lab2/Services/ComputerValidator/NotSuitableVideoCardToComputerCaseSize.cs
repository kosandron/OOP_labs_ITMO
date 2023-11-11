using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.ComputerValidator;

public class NotSuitableVideoCardToComputerCaseSize : IComputerBuildProblem
{
    public string GetProblemDescription()
    {
        return "Videocard is too big for computer case!";
    }

    public bool IsValid(Computer computer)
    {
        if (computer is null)
        {
            throw new ArgumentNullException(nameof(computer));
        }

        if (computer.VideoCard is not null)
        {
            return computer.VideoCard.Width <= computer.ComputerCase.MaxVideoCardWidth &&
                   computer.VideoCard.Height <= computer.ComputerCase.MaxVideoCardHeight;
        }

        return true;
    }
}