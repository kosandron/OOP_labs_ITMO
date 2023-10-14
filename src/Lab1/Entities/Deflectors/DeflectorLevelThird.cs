namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
public class DeflectorLevelThird : DeflectorBase
{
    private const int BasicDeflectorDensity = 2000;
    public DeflectorLevelThird(int deflectorDensity = BasicDeflectorDensity, PhotonDeflectorBase? photonDeflector = null)
        : base(deflectorDensity, photonDeflector) { }
}
