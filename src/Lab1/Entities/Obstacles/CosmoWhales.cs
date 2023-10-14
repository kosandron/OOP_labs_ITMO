using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
public class CosmoWhales : ObstacleBase
{
    private const int BasicDamage = 2000;
    public CosmoWhales(int damage = BasicDamage)
        : base(damage) { }

    public override void MakeDamage(ShipBase ship)
    {
        if (ship == null)
        {
            throw new ArgumentNullException(nameof(ship));
        }

        if (ship.AntiNitrineEmitter)
        {
            return;
        }

        if (ship.Deflector is not DeflectorLevelThird)
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
