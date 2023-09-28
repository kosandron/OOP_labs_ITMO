using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;
public abstract class ImpulsEngineBase : EngineBase
{
    protected const int BasicStartPain = 100;
    protected ImpulsEngineBase(int speed, int gasTankReserve, int startPain = BasicStartPain)
        : base(speed, gasTankReserve)
    {
        if (startPain <= 0)
        {
            throw new ArgumentException("Fuel costs at start are less or equal 0!", nameof(startPain));
        }

        StartPain = startPain;
    }
}
