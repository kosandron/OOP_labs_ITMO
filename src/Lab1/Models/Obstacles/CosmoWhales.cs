using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models;
public class CosmoWhales : ObstacleBase
{
    public CosmoWhales(int damage)
        : base(damage) { }

    public override void MakeDamage(ref ShipBase ship)
    {
        if (ship == null)
        {
            throw new ArgumentNullException(nameof(ship));
        }

        if (ship.AntiNitrineEmitter != null)
        {
            return;
        }

        if (ship.Deflector is not Deflectors.Deflector3)
        {
            ship.Kill();
            return;
        }
        else
        {
            ship.TakeDamage(Damage);
        }
    }
}
