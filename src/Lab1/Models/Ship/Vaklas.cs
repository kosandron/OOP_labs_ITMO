using Itmo.ObjectOrientedProgramming.Lab1.Models.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Engine;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Hull;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public class Vaklas : ShipBase
{
    public Vaklas()
        : base(new ImpulsEngineE(), new JumpEngineGamma(), new Hull2(), new Deflector1()) { }
}