using System;
using Itmo.ObjectOrientedProgramming.Lab2.Enums;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class WiFiAdapter
{
    private readonly PCIETypes _pcieType;
    private readonly PowerConsumption _powerConsumption;
    private string _version;
    private bool _hasBuiltInModule;

    public WiFiAdapter(string version, bool hasBuiltInModule, PCIETypes pcieType, PowerConsumption powerConsumption)
    {
        if (powerConsumption == null)
        {
            throw new ArgumentNullException(nameof(powerConsumption));
        }

        _version = version;
        _hasBuiltInModule = hasBuiltInModule;
        _pcieType = pcieType;
        _powerConsumption = powerConsumption;
    }

    public string Version => _version;
    public bool HasBuiltInModule => _hasBuiltInModule;
    public PCIETypes PcieType => _pcieType;
    public PowerConsumption PowerConsumption => _powerConsumption;
}