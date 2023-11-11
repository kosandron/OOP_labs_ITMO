using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class PowerConsumption : ICopyable<PowerConsumption>
{
    private int _value;

    public PowerConsumption(int value)
    {
        if (value <= 0)
        {
            throw new NegativeValueException("Power consumption is less than null!");
        }

        _value = value;
    }

    public int Value => _value;

    public PowerConsumption DeepCopy()
    {
        return new PowerConsumption(_value);
    }
}