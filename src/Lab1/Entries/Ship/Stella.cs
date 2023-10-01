using Itmo.ObjectOrientedProgramming.Lab1.Models.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Hull;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public class Stella : ShipBase
{
    public Stella(bool antiNitrineEmitterEnabled = false)
        : base(new ImpulsEngineC(null), new JumpEngineOmega(null), new Hull1(), new Deflector1(), antiNitrineEmitterEnabled) { }
    public Stella(FotonicDeflectorBase? fotonicDeflector, bool antiNitrineEmitterEnabled = false)
        : base(new ImpulsEngineC(null), new JumpEngineOmega(null), new Hull1(), new Deflector1(fotonicDeflector: fotonicDeflector), antiNitrineEmitterEnabled) { }
}