using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Services;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class MissionControlCenterTests
{
    public static IEnumerable<object[]> RouteInSpaceIncreasedDensityNebulaeTest()
    {
        yield return new object[] { new WalkShip(), new SpaceIncreasedDensityNebulae(2000), Results.ShipLost };
        yield return new object[] { new Avgur(), new SpaceIncreasedDensityNebulae(2000), Results.ShipLost };
    }

    public static IEnumerable<object[]> RouteInAntiMatterFlaresTest()
    {
        yield return new object[] { new Vaklas(), new SpaceIncreasedDensityNebulae(new List<ObstacleBase>() { new AntimatterFlares() }), Results.CrewDeath };
        yield return new object[] { new Vaklas(new FotonicDeflectorBase()), new SpaceIncreasedDensityNebulae(new List<ObstacleBase>() { new AntimatterFlares() }), Results.Success };
    }

    public static IEnumerable<object[]> HitByCosmoWhaleTest()
    {
        yield return new object[] { new Vaklas(), new List<GalacticBase>() { new NitrineParticleNebulae(new List<ObstacleBase>() { new CosmoWhales() }) }, Results.ShipDestroying, 0 };
        yield return new object[] { new Avgur(), new List<GalacticBase>() { new NitrineParticleNebulae(new List<ObstacleBase>() { new CosmoWhales() }) }, Results.Success, 0 };
        yield return new object[] { new Meredian(), new List<GalacticBase>() { new NitrineParticleNebulae(new List<ObstacleBase>() { new CosmoWhales() }) }, Results.Success, 950 };
    }

    public static IEnumerable<object[]> ChooseOptimalShipTest()
    {
        yield return new object[] { new List<ShipBase>() { new WalkShip(), new Vaklas() }, new List<GalacticBase>() { new Cosmos(2000) }, new WalkShip() };
        yield return new object[] { new List<ShipBase>() { new Avgur(), new Stella() }, new List<GalacticBase>() { new SpaceIncreasedDensityNebulae(2000) }, new Stella() };
        yield return new object[] { new List<ShipBase>() { new WalkShip(), new Vaklas() }, new List<GalacticBase>() { new NitrineParticleNebulae(2000) }, new Vaklas() };
    }

    public static IEnumerable<object[]> DificultPathTest()
    {
        yield return new object[] { new Vaklas(), new List<GalacticBase>() { new Cosmos(), new NitrineParticleNebulae(new List<ObstacleBase>() { new CosmoWhales() }), new SpaceIncreasedDensityNebulae() }, Results.ShipLost };
        yield return new object[] { new Vaklas(), new List<GalacticBase>() { new NitrineParticleNebulae(new List<ObstacleBase>() { new CosmoWhales() }), new Cosmos(), new SpaceIncreasedDensityNebulae() }, Results.ShipDestroying };
        yield return new object[] { new Stella(new FotonicDeflectorBase()), new List<GalacticBase>() { new Cosmos(new List<ObstacleBase>() { new Asteroid() }), new SpaceIncreasedDensityNebulae(new List<ObstacleBase>() { new AntimatterFlares() }), new Cosmos(), new SpaceIncreasedDensityNebulae(new List<ObstacleBase>() { new AntimatterFlares() }) }, Results.Success };
        yield return new object[] { new Stella(new FotonicDeflectorBase()), new List<GalacticBase>() { new Cosmos(new List<ObstacleBase>() { new Asteroid() }), new SpaceIncreasedDensityNebulae(new List<ObstacleBase>() { new AntimatterFlares() }), new Cosmos(), new SpaceIncreasedDensityNebulae(new List<ObstacleBase>() { new AntimatterFlares() }), new Cosmos(new List<ObstacleBase>() { new Asteroid() }) }, Results.Success };
        yield return new object[] { new Stella(new FotonicDeflectorBase()), new List<GalacticBase>() { new Cosmos(new List<ObstacleBase>() { new Asteroid(), new Meteorite() }), new SpaceIncreasedDensityNebulae(new List<ObstacleBase>() { new AntimatterFlares() }), new Cosmos(), new SpaceIncreasedDensityNebulae(new List<ObstacleBase>() { new AntimatterFlares() }) }, Results.CrewDeath };
        yield return new object[] { new Stella(new FotonicDeflectorBase()), new List<GalacticBase>() { new Cosmos(new List<ObstacleBase>() { new Asteroid() }), new SpaceIncreasedDensityNebulae(new List<ObstacleBase>() { new AntimatterFlares() }), new Cosmos(), new SpaceIncreasedDensityNebulae(new List<ObstacleBase>() { new AntimatterFlares() }), new Cosmos(new List<ObstacleBase>() { new Asteroid(), new Meteorite(), new Asteroid() }) }, Results.ShipDestroying };
        yield return new object[] { new Stella(new FotonicDeflectorBase()), new List<GalacticBase>() { new Cosmos(new List<ObstacleBase>() { new Asteroid() }), new SpaceIncreasedDensityNebulae(new List<ObstacleBase>() { new AntimatterFlares() }), new Cosmos(), new SpaceIncreasedDensityNebulae(new List<ObstacleBase>() { new AntimatterFlares() }), new Cosmos(), new SpaceIncreasedDensityNebulae(new List<ObstacleBase>() { new AntimatterFlares() }) }, Results.Success };
        yield return new object[] { new Stella(new FotonicDeflectorBase()), new List<GalacticBase>() { new Cosmos(new List<ObstacleBase>() { new Asteroid() }), new SpaceIncreasedDensityNebulae(new List<ObstacleBase>() { new AntimatterFlares() }), new Cosmos(), new SpaceIncreasedDensityNebulae(new List<ObstacleBase>() { new AntimatterFlares() }), new Cosmos(), new SpaceIncreasedDensityNebulae(new List<ObstacleBase>() { new AntimatterFlares(), new AntimatterFlares() }) }, Results.CrewDeath };
        yield return new object[] { new Avgur(new FotonicDeflectorBase()), new List<GalacticBase>() { new SpaceIncreasedDensityNebulae(new List<ObstacleBase>() { new AntimatterFlares() }), new SpaceIncreasedDensityNebulae(new List<ObstacleBase>() { new AntimatterFlares() }), new SpaceIncreasedDensityNebulae(new List<ObstacleBase>() { new AntimatterFlares() }), new NitrineParticleNebulae(new List<ObstacleBase>() { new CosmoWhales() }) }, Results.Success };
        yield return new object[] { new Avgur(new FotonicDeflectorBase()), new List<GalacticBase>() { new SpaceIncreasedDensityNebulae(new List<ObstacleBase>() { new AntimatterFlares() }), new SpaceIncreasedDensityNebulae(new List<ObstacleBase>() { new AntimatterFlares() }), new SpaceIncreasedDensityNebulae(new List<ObstacleBase>() { new AntimatterFlares() }), new NitrineParticleNebulae(new List<ObstacleBase>() { new CosmoWhales(), new CosmoWhales() }) }, Results.ShipDestroying };
        yield return new object[] { new Stella(), new List<GalacticBase>() { new SpaceIncreasedDensityNebulae(1000), new SpaceIncreasedDensityNebulae(2000), new SpaceIncreasedDensityNebulae(1000), new SpaceIncreasedDensityNebulae(3000) }, Results.ShipLost };
        yield return new object[] { new Meredian(), new List<GalacticBase>() { new NitrineParticleNebulae(new List<ObstacleBase>() { new CosmoWhales(), new CosmoWhales(), new CosmoWhales() }) }, Results.Success };
        yield return new object[] { new Meredian(), new List<GalacticBase>() { new NitrineParticleNebulae(new List<ObstacleBase>() { new CosmoWhales(), new CosmoWhales(), new CosmoWhales() }), new Cosmos() }, Results.ShipLost };
        yield return new object[] { new WalkShip(), new List<GalacticBase>() { new Cosmos(), new Cosmos() }, Results.Success };
        yield return new object[] { new WalkShip(), new List<GalacticBase>() { new Cosmos(), new Cosmos(new List<ObstacleBase>() { new Asteroid() }) }, Results.ShipDestroying };
        yield return new object[] { new WalkShip(), new List<GalacticBase>() { new Cosmos(), new Cosmos(new List<ObstacleBase>() { new Meteorite() }) }, Results.ShipDestroying };
        yield return new object[] { new WalkShip(), new List<GalacticBase>() { new Cosmos(), new Cosmos(), new NitrineParticleNebulae() }, Results.ShipLost };
    }

    public static ShipType GetType(ShipBase? ship) =>
        ship switch
        {
            null => ShipType.None,
            Avgur => ShipType.Avgur,
            Meredian => ShipType.Meredian,
            Stella => ShipType.Stella,
            Vaklas => ShipType.Vaklas,
            WalkShip => ShipType.WalkShip,
            _ => ShipType.Another,
        }; // создан, так как сравнение типов (is, typeof, equals) не работает в тестах

    [Theory]
    [MemberData(nameof(RouteInSpaceIncreasedDensityNebulaeTest))]
    [MemberData(nameof(RouteInAntiMatterFlaresTest))]
    public void RouteInSomeNebulae(ShipBase ship, GalacticBase galactic, Results result)
    {
        var center = new MissionControlCenter();
        var burse = new Burse(100, 100);

        RequestResult currentResult = center.TryToFlyGalactic(ref ship, galactic, burse);

        Assert.Equal(result, currentResult.Result);
    }

    [Theory]
    [MemberData(nameof(HitByCosmoWhaleTest))]
    public void HitByCosmoWhale(ShipBase ship, IList<GalacticBase> way, Results result, int newDeflictorDensity)
    {
        if (ship == null)
        {
            throw new ArgumentNullException(nameof(ship));
        }

        var center = new MissionControlCenter();
        var burse = new Burse(100, 100);

        RequestResult shipCurrentResult = center.TryToFlyWay(ship, way, burse);

        Assert.Equal(result, shipCurrentResult.Result);
        Assert.Equal(ship.Deflector.State.Value, newDeflictorDensity);
    }

    [Theory]
    [MemberData(nameof(ChooseOptimalShipTest))]
    public void ChooseOptimalShip(IList<ShipBase> ships, IList<GalacticBase> way, ShipBase? result)
    {
        var center = new MissionControlCenter();
        var burse = new Burse(100, 100);

        ShipBase? currentShip = center.FindOptimalShip(ships, way, burse);

        Assert.Equal(GetType(result), GetType(currentShip));
    }

    [Theory]
    [MemberData(nameof(DificultPathTest))]
    public void LongPath(ShipBase ship, IList<GalacticBase> way, Results result)
    {
        var center = new MissionControlCenter();
        var burse = new Burse(100, 100);

        RequestResult currentResult = center.TryToFlyWay(ship, way, burse);

        Assert.Equal(result, currentResult.Result);
    }
}