using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.ComputerValidator;

public interface INotSupportedCpuValidator
{
    public void Validate(IList<string>? supportedCpuList);
}