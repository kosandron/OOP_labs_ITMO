using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Enums;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class SupportedRam : SupportedComponentBase<Ram>
{
    public SupportedRam()
    : base(new List<Ram>()
        {
            new Ram(
                "Adata small",
                new Frequency(4000),
                new XMP(
                    new Frequency(4000),
                    120,
                    "18-18-36-54"),
                MemoryFormFactorTypes.DIMM,
                DDRStandarts.DDR4,
                new PowerConsumption(100)),
            new Ram(
                "Adata medium",
                new Frequency(4200),
                new XMP(
                    new Frequency(4200),
                    120,
                    "18-18-42-54"),
                MemoryFormFactorTypes.DIMM,
                DDRStandarts.DDR4,
                new PowerConsumption(110)),
            new Ram(
                "Adata big",
                new Frequency(4400),
                new XMP(
                    new Frequency(4400),
                    120,
                    "18-18-46-54"),
                MemoryFormFactorTypes.DIMM,
                DDRStandarts.DDR5,
                new PowerConsumption(120)),
        }) { }
}