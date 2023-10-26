using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class Frequency : ICopyable<Frequency>
{
    private int _value;

    public Frequency(int value)
    {
        if (value <= 0)
        {
            throw new NegativeValueException("Frequency is less than null!");
        }

        _value = value;
    }

    public int Value => _value;

    public Frequency DeepCopy()
    {
        return new Frequency(_value);
    }
}