using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.ComputerValidator;

public class ComputerValidator : IComputerValidator
{
    private Collection<IComputerBuildProblem> _problems;

    public ComputerValidator()
    {
        _problems = new Collection<IComputerBuildProblem>();
        _problems.Add(new CpuPowerConsumptionProblem());
        _problems.Add(new NoDdrConnectivityProblem());
        _problems.Add(new NotEnoughSataPorts());
        _problems.Add(new NotEnoughPciEPorts());
        _problems.Add(new NotSuitableCpuSocketByCoolerProblem());
        _problems.Add(new NotSuitableCpuSocketByMotherBoardProblem());
        _problems.Add(new NotSupportedCpuProblem());
        _problems.Add(new NotSupportedMotherBoardFormFactorProblem());
        _problems.Add(new NotSupportedRamFrequency());
        _problems.Add(new NoVideoCardProblem());
        _problems.Add(new PowerConsumptionProblem());
    }

    public IList<IComputerBuildProblem> Validate(Computer computer)
    {
        if (computer == null)
        {
            throw new ArgumentNullException(nameof(computer));
        }

        return new List<IComputerBuildProblem>(_problems.Where(problem => !problem.IsValid(computer)));
    }

    public DiagnosticResult GetDiagnosticResult(Computer computer)
    {
        if (computer == null)
        {
            throw new ArgumentNullException(nameof(computer));
        }

        IList<IComputerBuildProblem> problems = Validate(computer);
        string resultDescription;
        if (problems.Count == 0)
        {
            resultDescription = "OK!";
        }
        else
        {
            resultDescription = "Some problems!";
        }

        if (problems.Any(problem => problem is PowerConsumptionProblem))
        {
            resultDescription = "Alarm: power consumption is increased!";
        }

        if (problems.Any(problem => problem is CpuPowerConsumptionProblem))
        {
            resultDescription = "Comment: no garancy!";
        }

        return new DiagnosticResult(resultDescription, problems);
    }
}