using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Galactics;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public interface IOptimalShipChoosing
{
    public ShipBase? FindOptimalShip(IList<ShipBase> ships, IList<GalacticBase> way, FuelShop fuelShop);
}