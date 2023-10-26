using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Enums;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class SupportedSsd : SupportedComponentBase<Ssd>
{
    public SupportedSsd()
        : base(new List<Ssd>()
        {
            new Ssd(
                "Kingston A400",
                PCIETypes.None,
                420,
                450,
                new PowerConsumption(100)),
            new Ssd(
                "Kingston A500",
                PCIETypes.X1,
                500,
                450,
                new PowerConsumption(100)),
            new Ssd(
                "Kingston A600",
                PCIETypes.X16,
                600,
                450,
                new PowerConsumption(100)),
        })
    {
    }
}