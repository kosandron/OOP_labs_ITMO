using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Hull;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;

public class Vaklas : ShipBase
{
    public Vaklas(bool antiNitrineEmitterEnabled = false)
        : base(new ImpulseEngineE(), new JumpEngineGamma(), new HullLevelSecond(), new DeflectorLevelFirst(), antiNitrineEmitterEnabled) { }
    public Vaklas(PhotonDeflectorBase? photonDeflector, bool antiNitrineEmitterEnabled = false)
        : base(new ImpulseEngineE(), new JumpEngineGamma(), new HullLevelSecond(), new DeflectorLevelFirst(photonDeflector: photonDeflector), antiNitrineEmitterEnabled) { }
}