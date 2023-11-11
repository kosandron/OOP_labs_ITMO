using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class XMP : ICopyable<XMP>
{
    private readonly Frequency _frequency;
    private int _voltage;
    private string _timings;

    public XMP(Frequency frequency, int voltage, string timings)
    {
        if (frequency is null)
        {
            throw new ArgumentNullException(nameof(frequency));
        }

        if (timings is null)
        {
            throw new ArgumentNullException(nameof(timings));
        }

        if (voltage <= 0)
        {
            throw new NegativeValueException("Voltage is less than null!");
        }

        _frequency = frequency;
        _voltage = voltage;
        _timings = timings;
    }

    public Frequency XmpFrequency => _frequency;
    public int Voltage => _voltage;
    public string Timings => _timings;

    public XMP DeepCopy()
    {
        return new XMP(XmpFrequency.DeepCopy(), Voltage, Timings);
    }
}