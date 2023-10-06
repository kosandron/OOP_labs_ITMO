namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public class Price
{
    public Price(int priceValue)
    {
        if (priceValue < 0)
        {
            throw new NegativeValueException(nameof(priceValue));
        }

        Value = priceValue;
    }

    public int Value { get; private set; }

    public void ChangePrice(int newPrice)
    {
        if (newPrice < 0)
        {
            throw new NegativeValueException(nameof(newPrice));
        }

        Value = newPrice;
    }
}