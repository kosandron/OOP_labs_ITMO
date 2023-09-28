using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public class Price
{
    public Price(int priceValue)
    {
        if (priceValue < 0)
        {
            throw new ArgumentException("Price value is less or equal 0!", nameof(priceValue));
        }

        Value = priceValue;
    }

    public int Value { get; private set; }

    public void ChangePrice(int newPrice)
    {
        if (newPrice <= 0)
        {
            throw new ArgumentException("New price value is less or equal 0!", nameof(newPrice));
        }

        Value = newPrice;
    }
}