using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Enums;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class SupportedMotherBoard : SupportedComponentBase<MotherBoard>
{
    public SupportedMotherBoard()
        : base(new List<MotherBoard>()
        {
            new MotherBoard(
                "MSI MAG",
                new Socket("AM1"),
                new List<PCIETypes>()
                {
                    PCIETypes.X1,
                    PCIETypes.X16,
                },
                3,
                new XMP(
                    new Frequency(4900),
                    120,
                    "18-18-36-54"),
                DDRStandarts.DDR3,
                2,
                MemoryFormFactorTypes.DIMM,
                MotherBoardFormFactorTypes.MiniITX,
                new Bios(
                    "Bios 1.0",
                    "type 1",
                    "SuperPower",
                    new List<string>()
                    {
                        "Intel i-123",
                        "Intel i-239",
                    })),
            new MotherBoard(
                "MSI MAG 2",
                new Socket("AM3"),
                new List<PCIETypes>()
                {
                    PCIETypes.X1,
                    PCIETypes.X16,
                    PCIETypes.X16,
                },
                4,
                new XMP(
                    new Frequency(5200),
                    130,
                    "18-18-42-54"),
                DDRStandarts.DDR4,
                4,
                MemoryFormFactorTypes.DIMM,
                MotherBoardFormFactorTypes.StandartATX,
                new Bios(
                    "Bios 2.0",
                    "type 2",
                    "SuperPower",
                    new List<string>()
                    {
                        "Intel i-321",
                        "Intel i-239",
                        "Intel i-40",
                    })),
        })
    {
    }
}