using System;
using Itmo.ObjectOrientedProgramming.Lab2.Enums;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Ram : IComponent, ICloneable<Ram>, ICopyable<Ram>
{
    private readonly XMP _xmp;
    private readonly MemoryFormFactorTypes _formFactor;
    private readonly DDRStandarts _ddrStandart;
    private readonly PowerConsumption _powerConsumption;

    public Ram(string name, XMP xmp, MemoryFormFactorTypes formFactor, DDRStandarts ddrStandart, PowerConsumption powerConsumption)
    {
        if (xmp == null)
        {
            throw new ArgumentNullException(nameof(xmp));
        }

        if (formFactor == MemoryFormFactorTypes.None)
        {
            throw new ArgumentNullException(nameof(formFactor));
        }

        if (ddrStandart == DDRStandarts.None)
        {
            throw new ArgumentNullException(nameof(ddrStandart));
        }

        if (powerConsumption == null)
        {
            throw new ArgumentNullException(nameof(powerConsumption));
        }

        Name = name;
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
        _formFactor = other._formFactor;
        _ddrStandart = other._ddrStandart;
        _powerConsumption = other._powerConsumption;
    }

    public string Name { get; init; }
    public XMP XMP => _xmp;
    public MemoryFormFactorTypes FormFactor => _formFactor;
    public DDRStandarts DdrStandart => _ddrStandart;
    public PowerConsumption PowerConsumption => _powerConsumption;

    public Ram Clone() => new Ram(this);
    public Ram DeepCopy()
    {
        return new Ram(Name, XMP.DeepCopy(), FormFactor, DdrStandart, PowerConsumption.DeepCopy());
    }
}