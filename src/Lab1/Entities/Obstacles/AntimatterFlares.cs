using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
public class AntimatterFlares : ObstacleBase
{
    public AntimatterFlares(int damage = 1)
        : base(damage) { }

    public override void MakeDamage(ShipBase ship)
    {
        if (ship == null)
        {
            throw new ArgumentNullException(nameof(ship));
        }

        if ((ship.Deflector.PhotonDeflector is NullPhotonDeflector) || ship.Deflector.PhotonDeflector.IsDead)
        {
            ship.KillPeople();
            return;
        }

        ship.Deflector.PhotonDeflector.TakeDamage();
    }
}
