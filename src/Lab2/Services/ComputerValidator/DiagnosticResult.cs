using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.ComputerValidator;

public record DiagnosticResult(string ResultDescription, IList<IComputerBuildProblem> ProblemsList);