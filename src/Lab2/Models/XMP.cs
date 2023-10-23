using Itmo.ObjectOrientedProgramming.Lab1.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class XMP
{
    private readonly Frequency _frequency;
    private int _voltage;
    private string _timings;

    public XMP(Frequency frequency, int voltage, string timings)
    {
        if (voltage <= 0)
        {
            throw new NegativeValueException("Voltage is less than null!");
        }

        _frequency = frequency;
        _voltage = voltage;
        _timings = timings;
    }

    public Frequency Frequency => _frequency;
    public int Voltage => _voltage;
    public string Timings => _timings;
}