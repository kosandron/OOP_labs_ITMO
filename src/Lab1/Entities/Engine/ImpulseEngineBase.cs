using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;
public abstract class ImpulseEngineBase : EngineBase
{
    protected const int BasicstartSpentOil = 100;
    protected ImpulseEngineBase(int speed, int gasTankReserve, int startSpentOil = BasicstartSpentOil)
        : base(speed, gasTankReserve)
    {
        if (startSpentOil < 0)
        {
            throw new NegativeValueException(nameof(startSpentOil));
        }

        StartSpentOil = startSpentOil;
    }
}
