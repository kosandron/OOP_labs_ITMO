using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class SupportedCpu : SupportedComponentBase<Cpu>
{
    public SupportedCpu()
    : base(new List<Cpu>()
        {
            new Cpu(
                "Intel i-123",
                4,
                new Frequency(900),
                new Socket("AM1"),
                false,
                new Frequency(3600),
                new Frequency(4600),
                new TDP(200),
                new PowerConsumption(100)),
            new Cpu(
                "Intel i-239",
                8,
                new Frequency(1500),
                new Socket("AM3"),
                true,
                new Frequency(3400),
                new Frequency(5400),
                new TDP(200),
                new PowerConsumption(150)),
            new Cpu(
                "Intel i-321",
                8,
                new Frequency(1400),
                new Socket("AM5"),
                true,
                new Frequency(3200),
                new Frequency(5600),
                new TDP(300),
                new PowerConsumption(200)),
            new Cpu(
                "Intel i-40",
                2,
                new Frequency(600),
                new Socket("AM1"),
                false,
                new Frequency(3600),
                new Frequency(4400),
                new TDP(200),
                new PowerConsumption(100)),
            new Cpu(
                "Intel i-75",
                4,
                new Frequency(1000),
                new Socket("AM2"),
                false,
                new Frequency(3500),
                new Frequency(4500),
                new TDP(200),
                new PowerConsumption(100)),
        }) { }
}