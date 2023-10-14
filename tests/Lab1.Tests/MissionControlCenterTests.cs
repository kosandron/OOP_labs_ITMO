using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Galactics;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;
using Itmo.ObjectOrientedProgramming.Lab1.Services;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class MissionControlCenterTests
{
    [Theory]
    [MemberData(nameof(TestData.RouteInSpaceIncreasedDensityNebulaeTest), MemberType = typeof(TestData))] // test 1
    [MemberData(nameof(TestData.RouteInAntiMatterFlaresTest), MemberType = typeof(TestData))] // test 2
    public void RouteInSomeNebulae(ShipBase ship, GalacticBase galactic, Results result)
    {
        // Arrange
        var center = new MissionControlCenter();
        var shop = new FuelShop(100, 100);

        // Act
        RequestResult currentResult = center.TryToFlyGalactic(ship, galactic, shop);

        // Assert
        Assert.Equal(result, currentResult.Result);
    }

    [Theory]
    [MemberData(nameof(TestData.HitByCosmoWhaleTest), MemberType = typeof(TestData))] // test 3
    public void HitByCosmoWhale(ShipBase ship, IList<GalacticBase> way, Results result, int newDeflictorDensity)
    {
        // Arrange
        var center = new MissionControlCenter();
        var shop = new FuelShop(100, 100);

        // Act
        RequestResult shipCurrentResult = center.TryToFlyWay(ship, way, shop);

        // Assert
        Assert.Equal(result, shipCurrentResult.Result);
        Assert.Equal(ship?.Deflector.State.Value, newDeflictorDensity);
    }

    [Fact]
    public void ChooseShortPathShip()
    {
        // Arrange
        var ships = new List<ShipBase>() { new WalkShip(), new Vaklas() };
        var way = new List<GalacticBase>() { new Cosmos(2000) };
        var center = new MissionControlCenter();
        var shop = new FuelShop(100, 100);

        // Act
        ShipBase? currentShip = center.FindOptimalShip(ships, way, shop);

        // Assert
        Assert.IsType<WalkShip>(currentShip);
    }

    [Fact]
    public void ChooseShipMiddlePathIn()
    {
        // Arrange
        var ships = new List<ShipBase>() { new Avgur(), new Stella() };
        var way = new List<GalacticBase>() { new SpaceIncreasedDensityNebulae(2000) };
        var center = new MissionControlCenter();
        var shop = new FuelShop(100, 100);

        // Act
        ShipBase? currentShip = center.FindOptimalShip(ships, way, shop);

        // Assert
        Assert.IsType<Stella>(currentShip);
    }

    [Fact]
    public void ChooseShipInNitrineParticleNebulae()
    {
        // Arrange
        var ships = new List<ShipBase>() { new WalkShip(), new Vaklas() };
        var way = new List<GalacticBase>() { new NitrineParticleNebulae(2000) };
        var center = new MissionControlCenter();
        var shop = new FuelShop(100, 100);

        // Act
        ShipBase? currentShip = center.FindOptimalShip(ships, way, shop);

        // Assert
        Assert.IsType<Vaklas>(currentShip);
    }

    [Theory]
    [MemberData(nameof(TestData.DificultPathTest), MemberType = typeof(TestData))]
    public void LongPath(ShipBase ship, IList<GalacticBase> way, Results result)
    {
        // Arrange
        var center = new MissionControlCenter();
        var shop = new FuelShop(100, 100);

        // Act
        RequestResult currentResult = center.TryToFlyWay(ship, way, shop);

        // Assert
        Assert.Equal(result, currentResult.Result);
    }
}