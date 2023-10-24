using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Factories;

public class ComputerCaseFactory : FactoryBase<ComputerCase>
{
    public ComputerCaseFactory(ICollection<ComputerCase> components)
        : base(components)
    {
    }
}