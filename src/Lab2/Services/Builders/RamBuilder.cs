using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Enums;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;

public class RamBuilder
{
    private string? _name;
    private XMP? _xmp;
    private MemoryFormFactorTypes _formFactor = MemoryFormFactorTypes.None;
    private DDRStandarts _ddrStandart = DDRStandarts.None;
    private PowerConsumption? _powerConsumption;

    public RamBuilder() { }

    public RamBuilder(Ram otherRam)
    {
        if (otherRam == null)
        {
            throw new ArgumentNullException(nameof(otherRam));
        }

        _name = otherRam.Name;
        _xmp = otherRam.XMP;
        _formFactor = otherRam.FormFactor;
        _ddrStandart = otherRam.DdrStandart;
        _powerConsumption = otherRam.PowerConsumption;
    }

    public RamBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public RamBuilder WithXMP(XMP xmp)
    {
        _xmp = xmp;
        return this;
    }

    public RamBuilder WithFormFactor(MemoryFormFactorTypes type)
    {
        _formFactor = type;
        return this;
    }

    public RamBuilder WithDdrFactor(DDRStandarts standart)
    {
        _ddrStandart = standart;
        return this;
    }

    public RamBuilder WithPowerConsumption(PowerConsumption powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public Ram Build()
    {
        if (_name == null)
        {
            throw new ArgumentNullException(nameof(_name));
        }

        if (_xmp == null)
        {
            throw new ArgumentNullException(nameof(_xmp));
        }

        if (_formFactor == MemoryFormFactorTypes.None)
        {
            throw new ArgumentNullException(nameof(_formFactor));
        }

        if (_ddrStandart == DDRStandarts.None)
        {
            throw new ArgumentNullException(nameof(_ddrStandart));
        }

        if (_powerConsumption == null)
        {
            throw new ArgumentNullException(nameof(_powerConsumption));
        }

        return new Ram(_name, _xmp, _formFactor, _ddrStandart, _powerConsumption);
    }
}