using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public class FuelShop
{
    private Price _activePlasmaPrice;
    private Price _gravitonMatterPrice;
    public FuelShop(int activePlasmaPrice, int gravitonMatterPrice)
    {
        _activePlasmaPrice = new Price(activePlasmaPrice);
        _gravitonMatterPrice = new Price(gravitonMatterPrice);
    }

    public Price ActivePlasmaPrice => _activePlasmaPrice;
    public Price GravitonMatterPrice => _gravitonMatterPrice;

    public void ChangeActivePlasmaPrice(int newValue)
    {
        _activePlasmaPrice.ChangePrice(newValue);
    }

    public void ChangeGravitonMatterPrice(int newValue)
    {
        _gravitonMatterPrice.ChangePrice(newValue);
    }

    public int GetPriceForEngine(EngineBase engine)
    {
        if (engine == null)
        {
            throw new ArgumentNullException(nameof(engine));
        }

        return engine is ImpulseEngineBase ? ActivePlasmaPrice.Value : GravitonMatterPrice.Value;
    }
}