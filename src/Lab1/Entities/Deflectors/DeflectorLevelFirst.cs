namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
public class DeflectorLevelFirst : DeflectorBase
{
    private const int BasicDeflectorDensity = 200;
    public DeflectorLevelFirst(int deflectorDensity = BasicDeflectorDensity, PhotonDeflectorBase? photonDeflector = null)
        : base(deflectorDensity, photonDeflector) { }
}
