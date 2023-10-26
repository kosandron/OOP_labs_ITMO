using System;
using Itmo.ObjectOrientedProgramming.Lab2.Enums;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Ram : IComponent, ICloneable<Ram>, ICopyable<Ram>
{
    private readonly Frequency _frequency;
    private readonly XMP? _xmp;
    private readonly MemoryFormFactorTypes _formFactor;
    private readonly DDRStandarts _ddrStandart;
    private readonly PowerConsumption _powerConsumption;

    public Ram(string? name, Frequency? frequency, XMP? xmp, MemoryFormFactorTypes formFactor, DDRStandarts ddrStandart, PowerConsumption? powerConsumption)
    {
        if (name is null)
        {
            throw new ArgumentNullException(nameof(name));
        }

        if (frequency is null)
        {
            throw new ArgumentNullException(nameof(frequency));
        }

        if (formFactor == MemoryFormFactorTypes.None)
        {
            throw new ArgumentNullException(nameof(formFactor));
        }

        if (ddrStandart is DDRStandarts.None)
        {
            throw new ArgumentNullException(nameof(ddrStandart));
        }

        if (powerConsumption is null)
        {
            throw new ArgumentNullException(nameof(powerConsumption));
        }

        Name = name;
        _frequency = frequency;
        _xmp = xmp;
        _formFactor = formFactor;
        _ddrStandart = ddrStandart;
        _powerConsumption = powerConsumption;
    }

    private Ram(Ram other)
    {
        if (other == null)
        {
            throw new ArgumentNullException(nameof(other));
        }

        Name = other.Name;
        _xmp = other._xmp;
        _frequency = other._frequency;
        _formFactor = other._formFactor;
        _ddrStandart = other._ddrStandart;
        _powerConsumption = other._powerConsumption;
    }

    public string Name { get; init; }
    public XMP? XMP => _xmp;
    public Frequency Frequency => _frequency;
    public MemoryFormFactorTypes FormFactor => _formFactor;
    public DDRStandarts DdrStandart => _ddrStandart;
    public PowerConsumption PowerConsumption => _powerConsumption;

    public Ram Clone() => new Ram(this);
    public Ram DeepCopy()
    {
        return new Ram(Name, _frequency.DeepCopy(), XMP?.DeepCopy(), FormFactor, DdrStandart, PowerConsumption.DeepCopy());
    }
}