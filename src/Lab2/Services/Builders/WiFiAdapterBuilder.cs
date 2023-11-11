using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Enums;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;

public class WiFiAdapterBuilder
{
    private string? _name;
    private PCIETypes _pcieType = PCIETypes.None;
    private PowerConsumption? _powerConsumption;
    private string? _version;
    private bool _hasBuiltInModule;

    public WiFiAdapterBuilder() { }

    public WiFiAdapterBuilder(WiFiAdapter otherWiFiAdapter)
    {
        if (otherWiFiAdapter == null)
        {
            throw new ArgumentNullException(nameof(otherWiFiAdapter));
        }

        _name = otherWiFiAdapter.Name;
        _pcieType = otherWiFiAdapter.PcieType;
        _powerConsumption = otherWiFiAdapter.PowerConsumption;
        _version = otherWiFiAdapter.Version;
        _hasBuiltInModule = otherWiFiAdapter.HasBuiltInModule;
    }

    public WiFiAdapterBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public WiFiAdapterBuilder WithVersion(string version)
    {
        _version = version;
        return this;
    }

    public WiFiAdapterBuilder WithBuiltInModule()
    {
        _hasBuiltInModule = true;
        return this;
    }

    public WiFiAdapterBuilder WithoutBuiltInModule()
    {
        _hasBuiltInModule = false;
        return this;
    }

    public WiFiAdapterBuilder WithPCIE(PCIETypes type)
    {
        _pcieType = type;
        return this;
    }

    public WiFiAdapterBuilder WithPowerConsumption(PowerConsumption powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public WiFiAdapter Build()
    {
        return new WiFiAdapter(_name, _version, _hasBuiltInModule, _pcieType, _powerConsumption);
    }
}