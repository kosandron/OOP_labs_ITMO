using System;
using Itmo.ObjectOrientedProgramming.Lab2.Enums;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class WiFiAdapter : IComponent, ICloneable<WiFiAdapter>, ICopyable<WiFiAdapter>
{
    private readonly PCIETypes _pcieType;
    private readonly PowerConsumption _powerConsumption;
    private string _version;
    private bool _hasBuiltInModule;

    public WiFiAdapter(string? name, string? version, bool hasBuiltInModule, PCIETypes pcieType, PowerConsumption? powerConsumption)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentNullException(nameof(name));
        }

        if (string.IsNullOrEmpty(version))
        {
            throw new ArgumentNullException(nameof(version));
        }

        if (powerConsumption is null)
        {
            throw new ArgumentNullException(nameof(powerConsumption));
        }

        if (pcieType == PCIETypes.None)
        {
            throw new ArgumentNullException(nameof(pcieType));
        }

        Name = name;
        _version = version;
        _hasBuiltInModule = hasBuiltInModule;
        _pcieType = pcieType;
        _powerConsumption = powerConsumption;
    }

    private WiFiAdapter(WiFiAdapter other)
    {
        if (other is null)
        {
            throw new ArgumentNullException(nameof(other));
        }

        Name = other.Name;
        _version = other._version;
        _hasBuiltInModule = other._hasBuiltInModule;
        _pcieType = other._pcieType;
        _powerConsumption = other._powerConsumption;
    }

    public string Name { get; init; }
    public string Version => _version;
    public bool HasBuiltInModule => _hasBuiltInModule;
    public PCIETypes PcieType => _pcieType;
    public PowerConsumption PowerConsumption => _powerConsumption;

    public WiFiAdapter Clone() => new WiFiAdapter(this);
    public WiFiAdapter DeepCopy()
    {
        return new WiFiAdapter(Name, Version, HasBuiltInModule, PcieType, PowerConsumption.DeepCopy());
    }
}