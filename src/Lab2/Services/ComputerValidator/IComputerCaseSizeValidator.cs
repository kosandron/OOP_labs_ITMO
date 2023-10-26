using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Enums;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.ComputerValidator;

public interface IComputerCaseSizeValidator
{
    bool IsValidSize(IList<MotherBoardFormFactorTypes> supportedFormFactorTypes, CaseSize size);
}