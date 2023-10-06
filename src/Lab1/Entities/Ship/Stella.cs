using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Hull;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;

public class Stella : ShipBase
{
    public Stella(bool antiNitrineEmitterEnabled = false)
        : base(new ImpulseEngineC(), new JumpEngineOmega(), new HullLevelFirst(), new DeflectorLevelFirst(), antiNitrineEmitterEnabled) { }
    public Stella(PhotonDeflectorBase? photonDeflector, bool antiNitrineEmitterEnabled = false)
        : base(new ImpulseEngineC(), new JumpEngineOmega(), new HullLevelFirst(), new DeflectorLevelFirst(photonDeflector: photonDeflector), antiNitrineEmitterEnabled) { }
}