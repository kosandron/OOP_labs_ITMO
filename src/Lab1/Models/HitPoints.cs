using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public class HitPoints
{
    public HitPoints(int value)
    {
        if (value < 0)
        {
            throw new ArgumentException("Value is less than 0!", nameof(value));
        }

        this.Value = value;
    }

    public int Value { get; private set; }

    public void DecreaseHitPoints(int value)
    {
        this.Value = Math.Max(0, this.Value - value);
    }
}