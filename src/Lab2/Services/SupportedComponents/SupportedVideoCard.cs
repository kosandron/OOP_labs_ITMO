using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Enums;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class SupportedVideoCard : SupportedComponentBase<VideoCard>
{
    public SupportedVideoCard()
        : base(new List<VideoCard>()
        {
            new VideoCard(
                "KFA2 GeForce",
                100,
                100,
                12,
                PCIETypes.X1,
                new Frequency(1320),
                new PowerConsumption(70)),
            new VideoCard(
                "KFA3 GeForce",
                200,
                200,
                24,
                PCIETypes.X16,
                new Frequency(1400),
                new PowerConsumption(80)),
        }) { }
}