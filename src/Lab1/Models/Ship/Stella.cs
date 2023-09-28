using Itmo.ObjectOrientedProgramming.Lab1.Models.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Hull;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public class Stella : ShipBase
{
    public Stella()
        : base(new ImpulsEngineC(), new JumpEngineOmega(), new Hull1(), new Deflector1()) { }
}