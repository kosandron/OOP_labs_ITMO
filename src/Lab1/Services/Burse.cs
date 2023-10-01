using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public class Burse
{
    public Burse(int activePlasmaPrice, int gravitonMatterPrice)
    {
        ActivePlasmaPrice = new Price(activePlasmaPrice);
        GravitonMatterPrice = new Price(gravitonMatterPrice);
    }

    public Price ActivePlasmaPrice { get; private set; }
    public Price GravitonMatterPrice { get; private set; }

    public void ChangeActivePlasmaPrice(int newValue)
    {
        ActivePlasmaPrice.ChangePrice(newValue);
    }

    public void ChangeGravitonMatterPrice(int newValue)
    {
        GravitonMatterPrice.ChangePrice(newValue);
    }

    public int GetPriceForEngine(in EngineBase engine)
    {
        if (engine is ImpulsEngineBase)
        {
            return ActivePlasmaPrice.Value;
        }
        else
        {
            return GravitonMatterPrice.Value;
        }
    }
}