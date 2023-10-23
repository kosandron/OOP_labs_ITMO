using Itmo.ObjectOrientedProgramming.Lab1.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class PowerConsumption
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
}