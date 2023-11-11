using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class SupportedCpuCooler : SupportedComponentBase<CpuCooler>
{
    public SupportedCpuCooler()
    : base(new List<CpuCooler>()
        {
            new CpuCooler(
                "Fly small",
                100,
                new List<Socket>()
                {
                    new Socket("AM1"),
                    new Socket("AM2"),
                },
                new TDP(150)),
            new CpuCooler(
                "Fly medium",
                200,
                new List<Socket>()
                {
                    new Socket("AM3"),
                    new Socket("AM4"),
                },
                new TDP(250)),
            new CpuCooler(
                "Fly big",
                200,
                new List<Socket>()
                {
                    new Socket("AM5"),
                    new Socket("AM6"),
                },
                new TDP(400)),
        }) { }
}