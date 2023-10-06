namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
public class DeflectorLevelSecond : DeflectorBase
{
    private const int BasicDeflectorDensity = 950;
    public DeflectorLevelSecond(int deflectorDensity = BasicDeflectorDensity, PhotonDeflectorBase? photonDeflector = null)
        : base(deflectorDensity, photonDeflector) { }
}
