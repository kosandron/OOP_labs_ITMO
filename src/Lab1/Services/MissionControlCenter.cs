using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;
#pragma warning disable CA1822 // ну тут выбирать надо, либо отключать ошибку ВРУЧНУЮ! (на занятии говорили, что статик - плохо), либо писать static
namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public class MissionControlCenter
{
    public RequestResult TryToFlyGalactic(ref ShipBase ship, GalacticBase galactic, in Burse burse)
    {
        if (ship == null)
        {
            throw new ArgumentNullException(nameof(ship));
        }

        if (galactic == null)
        {
            throw new ArgumentNullException(nameof(galactic));
        }

        if (burse == null)
        {
            throw new ArgumentNullException(nameof(burse));
        }

        if (!ship.IsSupportedSpace(galactic))
        {
            return new RequestResult(new Price(0), 0, Results.ShipLost);
        }

        EngineBase currentEngine = ship.GetOptimalEngine(galactic);
        int time = currentEngine.GetTimeForPath(galactic.Size);
        int cost = burse.GetPriceForEngine(currentEngine) * currentEngine.GetOilForPath(galactic.Size);

        foreach (ObstacleBase obstacle in galactic.Obstacles)
        {
            obstacle.MakeDamage(ref ship);
        }

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

    public RequestResult TryToFlyWay(ShipBase ship, IList<GalacticBase> way, in Burse burse)
    {
        if (way == null)
        {
            throw new ArgumentNullException(nameof(way));
        }

        if (ship == null)
        {
            throw new ArgumentNullException(nameof(ship));
        }

        if (burse == null)
        {
            throw new ArgumentNullException(nameof(burse));
        }

        int cost = 0;
        int time = 0;
        foreach (GalacticBase galactic in way)
        {
            if (ship.IsSupportedSpace(galactic))
            {
                RequestResult result = TryToFlyGalactic(ref ship, galactic, in burse);
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

    public ShipBase? FindOptimalShip(IList<ShipBase> ships, IList<GalacticBase> way, Burse burse)
    {
        if (way == null)
        {
            throw new ArgumentNullException(nameof(way));
        }

        if (ships == null)
        {
            throw new ArgumentNullException(nameof(ships));
        }

        if (burse == null)
        {
            throw new ArgumentNullException(nameof(burse));
        }

        ShipBase? optimalShip = null;
        int minPrice = int.MaxValue;
        foreach (ShipBase ship in ships)
        {
            RequestResult result = TryToFlyWay(ship, way, burse);
            if (result.Result == Results.Success && result.Cost.Value < minPrice)
            {
                optimalShip = ship;
                minPrice = result.Cost.Value;
            }
        }

        return optimalShip;
    }
}