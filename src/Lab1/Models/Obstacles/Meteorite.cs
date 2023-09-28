using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models;
public class Meteorite : ObstacleBase
{
    public Meteorite(int damage)
        : base(damage) { }
    public override void MakeDamage(ref ShipBase ship)
    {
        if (ship == null)
        {
            throw new ArgumentNullException(nameof(ship));
        }

        ship.TakeDamage(Damage);
    }
}
