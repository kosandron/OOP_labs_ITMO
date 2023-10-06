using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
public class Meteorite : ObstacleBase
{
    private const int BasicDamage = 350;
    public Meteorite(int damage = BasicDamage)
        : base(damage) { }
    public override void MakeDamage(ShipBase ship)
    {
        if (ship == null)
        {
            throw new ArgumentNullException(nameof(ship));
        }

        ship.TakeDamage(Damage);
    }
}
