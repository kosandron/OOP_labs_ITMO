using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Hull;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;

public class WalkShip : ShipBase
{
    public WalkShip(bool antiNitrineEmitterEnabled = false)
        : base(new ImpulseEngineC(), null, new HullLevelFirst(), null, antiNitrineEmitterEnabled) { }
}