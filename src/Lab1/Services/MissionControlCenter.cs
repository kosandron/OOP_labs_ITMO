using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Galactics;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public class MissionControlCenter : IOvercomePathTester, IOptimalShipChoosing
{
    public RequestResult TryToFlyGalactic(ShipBase ship, GalacticBase galactic, in FuelShop fuelShop)
    {
        if (ship == null)
        {
            throw new ArgumentNullException(nameof(ship));
        }

        if (galactic == null)
        {
            throw new ArgumentNullException(nameof(galactic));
        }

        if (fuelShop == null)
        {
            throw new ArgumentNullException(nameof(fuelShop));
        }

        if (!ship.IsSupportedSpace(galactic))
        {
            return new RequestResult(new Price(0), 0, Results.ShipLost);
        }

        EngineBase currentEngine = ship.GetOptimalEngine(galactic);
        int time = currentEngine.GetTimeForPath(galactic.Size);
        int cost = fuelShop.GetPriceForEngine(currentEngine) * currentEngine.GetOilForPath(galactic.Size);

        galactic.Obstacles.ToImmutableList().ForEach(it => it.MakeDamage(ship));

        if (!ship.IsAlive)
        {
            return new RequestResult(new Price(cost), time, Results.ShipDestroying);
        }
        else if (!ship.PeopleAreAlive)
        {
            return new RequestResult(new Price(cost), time, Results.CrewDeath);
        }
        else
        {
            return new RequestResult(new Price(cost), time, Results.Success);
        }
    }

    public RequestResult TryToFlyWay(ShipBase ship, IList<GalacticBase> way, in FuelShop fuelShop)
    {
        if (way == null)
        {
            throw new ArgumentNullException(nameof(way));
        }

        if (ship == null)
        {
            throw new ArgumentNullException(nameof(ship));
        }

        if (fuelShop == null)
        {
            throw new ArgumentNullException(nameof(fuelShop));
        }

        int cost = 0;
        int time = 0;
        foreach (GalacticBase galactic in way)
        {
            if (ship.IsSupportedSpace(galactic))
            {
                RequestResult result = TryToFlyGalactic(ship, galactic, in fuelShop);
                cost += result.Cost.Value;
                time += result.Time;
                if (result.Result != Results.Success)
                {
                    return new RequestResult(new Price(cost), time, result.Result);
                }
            }
            else
            {
                return new RequestResult(new Price(cost), time, Results.ShipLost);
            }
        }

        return new RequestResult(new Price(cost), time, Results.Success);
    }

    public ShipBase? FindOptimalShip(IList<ShipBase> ships, IList<GalacticBase> way, FuelShop fuelShop)
    {
        if (way == null)
        {
            throw new ArgumentNullException(nameof(way));
        }

        if (ships == null)
        {
            throw new ArgumentNullException(nameof(ships));
        }

        if (fuelShop == null)
        {
            throw new ArgumentNullException(nameof(fuelShop));
        }

        ShipBase? optimalShip = null;
        int minPrice = int.MaxValue;
        foreach (ShipBase ship in ships)
        {
            RequestResult result = TryToFlyWay(ship, way, fuelShop);
            if (result.Result == Results.Success && result.Cost.Value < minPrice)
            {
                optimalShip = ship;
                minPrice = result.Cost.Value;
            }
        }

        return optimalShip;
    }
}