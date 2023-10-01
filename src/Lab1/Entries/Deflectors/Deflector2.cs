namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Deflectors;
public class Deflector2 : DeflectorBase
{
    private const int BasicDeflectorDensity = 950;
    public Deflector2(int deflectorDensity = BasicDeflectorDensity, FotonicDeflectorBase? fotonicDeflector = null)
        : base(deflectorDensity, fotonicDeflector) { }
}
