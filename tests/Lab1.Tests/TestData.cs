using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Galactics;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;
using Itmo.ObjectOrientedProgramming.Lab1.Services;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public static class TestData
{
    public static IEnumerable<object[]> RouteInSpaceIncreasedDensityNebulaeTest()
    {
        yield return new object[]
        {
            new WalkShip(),
            new SpaceIncreasedDensityNebulae(2000),
            Results.ShipLost,
        };
        yield return new object[]
        {
            new Avgur(),
            new SpaceIncreasedDensityNebulae(2000),
            Results.ShipLost,
        };
    }

    public static IEnumerable<object[]> RouteInAntiMatterFlaresTest()
    {
        yield return new object[]
        {
            new Vaklas(),
            new SpaceIncreasedDensityNebulae(new List<ObstacleBase>() { new AntimatterFlares() }),
            Results.CrewDeath,
        };
        yield return new object[]
        {
            new Vaklas(new PhotonDeflectorBase()),
            new SpaceIncreasedDensityNebulae(new List<ObstacleBase>() { new AntimatterFlares() }),
            Results.Success,
        };
    }

    public static IEnumerable<object[]> HitByCosmoWhaleTest()
    {
        yield return new object[]
        {
            new Vaklas(),
            new List<GalacticBase>() { new NitrineParticleNebulae(new List<ObstacleBase>() { new CosmoWhales() }) },
            Results.ShipDestroying,
            0,
        };
        yield return new object[]
        {
            new Avgur(),
            new List<GalacticBase>() { new NitrineParticleNebulae(new List<ObstacleBase>() { new CosmoWhales() }) },
            Results.Success,
            0,
        };
        yield return new object[]
            {
                new Meredian(),
                new List<GalacticBase>() { new NitrineParticleNebulae(new List<ObstacleBase>() { new CosmoWhales() }) },
                Results.Success,
                950,
            };
    }

    public static IEnumerable<object[]> DificultPathTest()
    {
        yield return new object[]
        {
            new Vaklas(),
            new List<GalacticBase>()
            {
                new Cosmos(),
                new NitrineParticleNebulae(new List<ObstacleBase>() { new CosmoWhales() }),
                new SpaceIncreasedDensityNebulae(),
            },
            Results.ShipLost,
        };

        yield return new object[]
        {
            new Vaklas(),
            new List<GalacticBase>()
            {
                new NitrineParticleNebulae(new List<ObstacleBase>() { new CosmoWhales() }),
                new Cosmos(),
                new SpaceIncreasedDensityNebulae(),
            },
            Results.ShipDestroying,
        };

        yield return new object[]
        {
            new Stella(new PhotonDeflectorBase()),
            new List<GalacticBase>()
            {
                new Cosmos(new List<ObstacleBase>() { new Asteroid() }),
                new SpaceIncreasedDensityNebulae(new List<ObstacleBase>() { new AntimatterFlares() }),
                new Cosmos(),
                new SpaceIncreasedDensityNebulae(new List<ObstacleBase>() { new AntimatterFlares() }),
            },
            Results.Success,
        };

        yield return new object[]
        {
            new Stella(new PhotonDeflectorBase()),
            new List<GalacticBase>()
            {
                new Cosmos(new List<ObstacleBase>() { new Asteroid() }),
                new SpaceIncreasedDensityNebulae(new List<ObstacleBase>() { new AntimatterFlares() }),
                new Cosmos(),
                new SpaceIncreasedDensityNebulae(new List<ObstacleBase>() { new AntimatterFlares() }),
                new Cosmos(new List<ObstacleBase>() { new Asteroid() }),
            },
            Results.Success,
        };

        yield return new object[]
        {
            new Stella(new PhotonDeflectorBase()),
            new List<GalacticBase>()
            {
                new Cosmos(new List<ObstacleBase>()
                {
                    new Asteroid(),
                    new Meteorite(),
                }),
                new SpaceIncreasedDensityNebulae(new List<ObstacleBase>()
                {
                    new AntimatterFlares(),
                }),
                new Cosmos(),
                new SpaceIncreasedDensityNebulae(new List<ObstacleBase>()
                {
                    new AntimatterFlares(),
                }),
            },
            Results.CrewDeath,
        };

        yield return new object[]
        {
            new Stella(new PhotonDeflectorBase()),
            new List<GalacticBase>()
            {
                new Cosmos(new List<ObstacleBase>()
                {
                    new Asteroid(),
                }),
                new SpaceIncreasedDensityNebulae(new List<ObstacleBase>()
                {
                    new AntimatterFlares(),
                }),
                new Cosmos(),
                new SpaceIncreasedDensityNebulae(new List<ObstacleBase>()
                {
                    new AntimatterFlares(),
                }),
                new Cosmos(new List<ObstacleBase>()
                {
                    new Asteroid(),
                    new Meteorite(),
                    new Asteroid(),
                }),
            },
            Results.ShipDestroying,
        };

        yield return new object[]
        {
            new Stella(new PhotonDeflectorBase()),
            new List<GalacticBase>()
            {
                new Cosmos(new List<ObstacleBase>() { new Asteroid() }),
                new SpaceIncreasedDensityNebulae(new List<ObstacleBase>() { new AntimatterFlares() }),
                new Cosmos(),
                new SpaceIncreasedDensityNebulae(new List<ObstacleBase>() { new AntimatterFlares() }),
                new Cosmos(),
                new SpaceIncreasedDensityNebulae(new List<ObstacleBase>() { new AntimatterFlares() }),
            },
            Results.Success,
        };

        yield return new object[]
        {
            new Stella(new PhotonDeflectorBase()),
            new List<GalacticBase>()
            {
                new Cosmos(new List<ObstacleBase>()
                {
                    new Asteroid(),
                }),
                new SpaceIncreasedDensityNebulae(new List<ObstacleBase>()
                {
                    new AntimatterFlares(),
                }),
                new Cosmos(),
                new SpaceIncreasedDensityNebulae(new List<ObstacleBase>()
                {
                    new AntimatterFlares(),
                }),
                new Cosmos(),
                new SpaceIncreasedDensityNebulae(new List<ObstacleBase>()
                {
                    new AntimatterFlares(),
                    new AntimatterFlares(),
                }),
            },
            Results.CrewDeath,
        };

        yield return new object[]
        {
            new Avgur(new PhotonDeflectorBase()),
            new List<GalacticBase>()
            {
                new SpaceIncreasedDensityNebulae(new List<ObstacleBase>()
                {
                    new AntimatterFlares(),
                }),
                new SpaceIncreasedDensityNebulae(new List<ObstacleBase>()
                {
                    new AntimatterFlares(),
                }),
                new SpaceIncreasedDensityNebulae(new List<ObstacleBase>()
                {
                    new AntimatterFlares(),
                }),
                new NitrineParticleNebulae(new List<ObstacleBase>()
                {
                    new CosmoWhales(),
                }),
            },
            Results.Success,
        };

        yield return new object[]
        {
            new Avgur(new PhotonDeflectorBase()),
            new List<GalacticBase>()
            {
                new SpaceIncreasedDensityNebulae(new List<ObstacleBase>()
                {
                    new AntimatterFlares(),
                }),
                new SpaceIncreasedDensityNebulae(new List<ObstacleBase>()
                {
                    new AntimatterFlares(),
                }),
                new SpaceIncreasedDensityNebulae(new List<ObstacleBase>()
                {
                    new AntimatterFlares(),
                }),
                new NitrineParticleNebulae(new List<ObstacleBase>()
                {
                    new CosmoWhales(),
                    new CosmoWhales(),
                }),
            },
            Results.ShipDestroying,
        };

        yield return new object[]
        {
            new Stella(),
            new List<GalacticBase>()
            {
                new SpaceIncreasedDensityNebulae(1000),
                new SpaceIncreasedDensityNebulae(2000),
                new SpaceIncreasedDensityNebulae(1000),
                new SpaceIncreasedDensityNebulae(3000),
            },
            Results.ShipLost,
        };

        yield return new object[]
        {
            new Meredian(),
            new List<GalacticBase>()
            {
                new NitrineParticleNebulae(new List<ObstacleBase>()
                {
                    new CosmoWhales(),
                    new CosmoWhales(),
                    new CosmoWhales(),
                }),
            },
            Results.Success,
        };

        yield return new object[]
        {
            new Meredian(),
            new List<GalacticBase>()
            {
                new NitrineParticleNebulae(new List<ObstacleBase>()
                {
                    new CosmoWhales(),
                    new CosmoWhales(),
                    new CosmoWhales(),
                }),
                new Cosmos(),
            },
            Results.ShipLost,
        };

        yield return new object[]
        {
            new WalkShip(),
            new List<GalacticBase>()
            {
                new Cosmos(),
                new Cosmos(),
            },
            Results.Success,
        };

        yield return new object[]
        {
            new WalkShip(),
            new List<GalacticBase>()
            {
                new Cosmos(),
                new Cosmos(new List<ObstacleBase>() { new Asteroid() }),
            },
            Results.ShipDestroying,
        };

        yield return new object[]
        {
            new WalkShip(),
            new List<GalacticBase>()
            {
                new Cosmos(),
                new Cosmos(new List<ObstacleBase>() { new Meteorite() }),
            },
            Results.ShipDestroying,
        };

        yield return new object[]
        {
            new WalkShip(),
            new List<GalacticBase>()
            {
                new Cosmos(),
                new Cosmos(),
                new NitrineParticleNebulae(),
            },
            Results.ShipLost,
        };
    }
}