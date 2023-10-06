namespace Itmo.ObjectOrientedProgramming.Lab1.Models;
public class GasTank
{
    public GasTank(int value)
    {
        if (value < 0)
        {
            throw new NegativeValueException(nameof(value));
        }

        TankReserve = value;
    }

    public int TankReserve { get; private set; }
}
