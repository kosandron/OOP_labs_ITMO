using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Hull;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;

public class Avgur : ShipBase
{
    public Avgur(bool antiNitrineEmitterEnabled = false)
        : base(new ImpulseEngineE(), new JumpEngineAlpha(), new HullLevelThird(), new DeflectorLevelThird(), antiNitrineEmitterEnabled) { }
    public Avgur(PhotonDeflectorBase? photonDeflector, bool antiNitrineEmitterEnabled = false)
        : base(new ImpulseEngineE(), new JumpEngineGamma(), new HullLevelThird(), new DeflectorLevelThird(photonDeflector: photonDeflector), antiNitrineEmitterEnabled) { }
}