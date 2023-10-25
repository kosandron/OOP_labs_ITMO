namespace Itmo.ObjectOrientedProgramming.Lab2.Services.ComputerValidator;

public interface IComputerBuildProblem
{
    string GetProblemDescription();
    bool IsValid(Computer computer);
}