using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.ComputerValidator;

public interface IComputerValidator
{
    IList<IComputerBuildProblem> Validate(Computer computer);
}