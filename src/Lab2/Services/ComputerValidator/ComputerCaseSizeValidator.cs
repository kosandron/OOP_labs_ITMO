using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Enums;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.ComputerValidator;

public class ComputerCaseSizeValidator : IComputerCaseSizeValidator
{
    public bool IsValidSize(IList<MotherBoardFormFactorTypes>? supportedFormFactorTypes, CaseSize size)
    {
        if (supportedFormFactorTypes is null)
        {
            throw new ArgumentNullException(nameof(supportedFormFactorTypes));
        }

        int mediumMotherBoardFormFactorCount = supportedFormFactorTypes.Count(factor => factor.Equals(MotherBoardFormFactorTypes.MicroATX) || factor.Equals(MotherBoardFormFactorTypes.StandartATX));
        int bigMotherBoardFormFactorCount = supportedFormFactorTypes.Count(factor => factor.Equals(MotherBoardFormFactorTypes.EATX) || factor.Equals(MotherBoardFormFactorTypes.XLATX));
        return size switch
        {
            CaseSize.Small => mediumMotherBoardFormFactorCount + bigMotherBoardFormFactorCount == 0,
            CaseSize.Middle => bigMotherBoardFormFactorCount == 0,
            CaseSize.None => false,
            CaseSize.Big => true,
            _ => false,
        };
    }
}