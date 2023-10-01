namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Deflectors;
public class Deflector3 : DeflectorBase
{
    private const int BasicDeflectorDensity = 2000;
    public Deflector3(int deflectorDensity = BasicDeflectorDensity, FotonicDeflectorBase? fotonicDeflector = null)
        : base(deflectorDensity, fotonicDeflector) { }
}
