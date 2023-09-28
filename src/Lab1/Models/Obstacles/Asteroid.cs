using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;
public class Asteroid : ObstacleBase
{
    public Asteroid(int damage)
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
