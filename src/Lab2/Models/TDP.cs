using Itmo.ObjectOrientedProgramming.Lab1.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class TDP
{
    private int _value;

    public TDP(int value)
    {
        if (value <= 0)
        {
            throw new NegativeValueException("TDP is less or equal than null!");
        }

        _value = value;
    }

    public int Value => _value;
}