using Itmo.ObjectOrientedProgramming.Lab1.Models.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Hull;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public class Meredian : ShipBase
{
    public Meredian()
        : base(new ImpulsEngineE(null), null, new Hull2(), new Deflector2(), true) { }
    public Meredian(FotonicDeflectorBase? fotonicDeflector)
        : base(new ImpulsEngineE(null), null, new Hull2(), new Deflector2(fotonicDeflector: fotonicDeflector), true) { }
}