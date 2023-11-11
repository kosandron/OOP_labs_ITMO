using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class SupportedHdd : SupportedComponentBase<Hdd>
{
    public SupportedHdd()
        : base(new List<Hdd>()
        {
            new Hdd(
                "WD Blue",
                4,
                7200,
                new PowerConsumption(68)),
            new Hdd(
                "WD Black",
                256,
                7200,
                new PowerConsumption(53)),
        })
    {
    }
}