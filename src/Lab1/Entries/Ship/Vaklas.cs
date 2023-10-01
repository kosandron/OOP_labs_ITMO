using Itmo.ObjectOrientedProgramming.Lab1.Models.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Hull;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public class Vaklas : ShipBase
{
    public Vaklas(bool antiNitrineEmitterEnabled = false)
        : base(new ImpulsEngineE(null), new JumpEngineGamma(null), new Hull2(), new Deflector1(), antiNitrineEmitterEnabled) { }
    public Vaklas(FotonicDeflectorBase? fotonicDeflector, bool antiNitrineEmitterEnabled = false)
        : base(new ImpulsEngineE(null), new JumpEngineGamma(null), new Hull2(), new Deflector1(fotonicDeflector: fotonicDeflector), antiNitrineEmitterEnabled) { }
}