using Itmo.ObjectOrientedProgramming.Lab1.Models.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Hull;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public class Avgur : ShipBase
{
    public Avgur(bool antiNitrineEmitterEnabled = false)
        : base(new ImpulsEngineE(null), new JumpEngineAlpha(null), new Hull3(), new Deflector3(), antiNitrineEmitterEnabled) { }
    public Avgur(FotonicDeflectorBase? fotonicDeflector, bool antiNitrineEmitterEnabled = false)
        : base(new ImpulsEngineE(null), new JumpEngineGamma(null), new Hull3(), new Deflector3(fotonicDeflector: fotonicDeflector), antiNitrineEmitterEnabled) { }
}