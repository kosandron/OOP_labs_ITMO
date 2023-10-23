using System;
using Itmo.ObjectOrientedProgramming.Lab2.Enums;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Ram
{
    private readonly XMP _xmp;
    private readonly MemoryFormFactorTypes _formFactor;
    private readonly DDRStandarts _ddrStandart;
    private readonly PowerConsumption _powerConsumption;

    public Ram(XMP xmp, MemoryFormFactorTypes formFactor, DDRStandarts ddrStandart, PowerConsumption powerConsumption)
    {
        if (xmp == null)
        {
            throw new ArgumentNullException(nameof(xmp));
        }

        if (powerConsumption == null)
        {
            throw new ArgumentNullException(nameof(powerConsumption));
        }

        _xmp = xmp;
        _formFactor = formFactor;
        _ddrStandart = ddrStandart;
        _powerConsumption = powerConsumption;
    }

    public XMP XMP => _xmp;
    public MemoryFormFactorTypes FormFactor => _formFactor;
    public DDRStandarts DdrStandart => _ddrStandart;
    public PowerConsumption PowerConsumption => _powerConsumption;
}