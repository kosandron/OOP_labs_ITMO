using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models;
public class CosmoWhales : ObstacleBase
{
    private const int BasicDamage = 2000;
    public CosmoWhales(int damage = BasicDamage)
        : base(damage) { }

    public override void MakeDamage(ref ShipBase ship)
    {
        if (ship == null)
        {
            throw new ArgumentNullException(nameof(ship));
        }

        if (ship.AntiNitrineEmitter)
        {
            return;
        }

        if (ship.Deflector is not Deflectors.Deflector3)
        {
            ship.TakeDamage(Damage);
            ship.Kill();
        }
        else
        {
            ship.TakeDamage(Damage);
        }
    }
}
