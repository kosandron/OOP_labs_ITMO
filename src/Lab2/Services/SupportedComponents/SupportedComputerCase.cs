using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Enums;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class SupportedComputerCase : SupportedComponentBase<ComputerCase>
{
    public SupportedComputerCase()
        : base(new List<ComputerCase>()
        {
            new ComputerCase(
                "Cougar Pro",
                200,
                200,
                new List<MotherBoardFormFactorTypes>()
                {
                    MotherBoardFormFactorTypes.MicroATX,
                    MotherBoardFormFactorTypes.StandartATX,
                },
                CaseSize.Middle),
            new ComputerCase(
                "Cougar Standart",
                100,
                100,
                new List<MotherBoardFormFactorTypes>()
                {
                    MotherBoardFormFactorTypes.MiniITX,
                },
                CaseSize.Small),
            new ComputerCase(
                "Cougar Big",
                300,
                300,
                new List<MotherBoardFormFactorTypes>()
                {
                    MotherBoardFormFactorTypes.EATX,
                    MotherBoardFormFactorTypes.XLATX,
                },
                CaseSize.Big),
        }) { }
}