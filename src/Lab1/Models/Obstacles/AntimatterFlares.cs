using System;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Deflectors;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;
public class AntimatterFlares : ObstacleBase
{
    public AntimatterFlares(int damage)
        : base(damage) { }

    public override void MakeDamage(ref ShipBase ship)
    {
        if (ship == null)
        {
            throw new ArgumentNullException(nameof(ship));
        }

        if ((ship.Deflector.FotonicDeflector is NullFotonicDeflector) || ship.Deflector.FotonicDeflector.IsDead)
        {
            ship.KillPeople();
            return;
        }

        ship.Deflector.FotonicDeflector.TakeDamage();
    }
}
