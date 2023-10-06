using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public class HitPoints
{
    public HitPoints(int value)
    {
        if (value < 0)
        {
            throw new NegativeValueException(nameof(value));
        }

        Value = value;
    }

    public int Value { get; private set; }
    public bool IsDead => Value == 0;

    public void DecreaseHitPoints(int value)
    {
        if (value <= 0)
        {
            throw new NegativeValueException(nameof(value));
        }

        Value = Math.Max(0, Value - value);
    }
}