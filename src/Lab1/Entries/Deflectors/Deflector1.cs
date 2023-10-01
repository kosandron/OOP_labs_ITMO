namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Deflectors;
public class Deflector1 : DeflectorBase
{
    private const int BasicDeflectorDensity = 200;
    public Deflector1(int deflectorDensity = BasicDeflectorDensity, FotonicDeflectorBase? fotonicDeflector = null)
        : base(deflectorDensity, fotonicDeflector) { }
}
