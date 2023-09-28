using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;
public class GasTank
{
    public GasTank(int value)
    {
        if (value <= 0)
        {
            throw new ArgumentException("Gas tank reserve is less or equal than 0!", nameof(value));
        }

        TankReserve = value;
    }

    public int TankReserve { get; private set; }
    public bool Empty => TankReserve == 0;

    public void DecreaseTank(int value)
    {
        if (value <= 0)
        {
            throw new ArgumentException("Trying to decrease tank reserve by negative or null number!", nameof(value));
        }

        TankReserve = Math.Max(0, TankReserve - value);
    }

    public void AddTank(int value)
    {
        if (value <= 0)
        {
            throw new ArgumentException("Trying to add tank reserve by negative or null number!", nameof(value));
        }

        TankReserve += value;
    }
}
