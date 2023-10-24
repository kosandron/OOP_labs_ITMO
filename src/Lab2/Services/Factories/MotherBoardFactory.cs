using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Factories;

public class MotherBoardFactory : FactoryBase<MotherBoard>
{
    public MotherBoardFactory(ICollection<MotherBoard> components)
        : base(components)
    {
    }
}