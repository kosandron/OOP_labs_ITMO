using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models;
public class Meteorite : ObstacleBase
{
    private const int BasicDamage = 350;
    public Meteorite(int damage = BasicDamage)
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
