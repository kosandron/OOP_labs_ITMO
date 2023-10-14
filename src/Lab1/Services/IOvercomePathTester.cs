using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Galactics;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public interface IOvercomePathTester
{
    public RequestResult TryToFlyGalactic(ShipBase ship, GalacticBase galactic, in FuelShop fuelShop);
    public RequestResult TryToFlyWay(ShipBase ship, IList<GalacticBase> way, in FuelShop fuelShop);
}