using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Enums;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class SupportedWiFiAdapter : SupportedComponentBase<WiFiAdapter>
{
    public SupportedWiFiAdapter()
    : base(new List<WiFiAdapter>()
        {
            new WiFiAdapter(
                "Mercusys 1",
                "v1",
                false,
                PCIETypes.X1,
                new PowerConsumption(30)),
            new WiFiAdapter(
                "Mercusys 2",
                "v2",
                true,
                PCIETypes.X1,
                new PowerConsumption(30)),
            new WiFiAdapter(
                "Mercusys 3",
                "v3",
                true,
                PCIETypes.X16,
                new PowerConsumption(50)),
        }) { }
}