using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Hull;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;

public class Meredian : ShipBase
{
    public Meredian()
        : base(new ImpulseEngineE(), null, new HullLevelSecond(), new DeflectorLevelSecond(), true) { }
    public Meredian(PhotonDeflectorBase? photonDeflector)
        : base(new ImpulseEngineE(), null, new HullLevelSecond(), new DeflectorLevelSecond(photonDeflector: photonDeflector), true) { }
}