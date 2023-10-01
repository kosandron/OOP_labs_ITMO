using Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Hull;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public class WalkShip : ShipBase
{
    public WalkShip(bool antiNitrineEmitterEnabled = false)
        : base(new ImpulsEngineC(null), null, new Hull1(), null, antiNitrineEmitterEnabled) { }
}