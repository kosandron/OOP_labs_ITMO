using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public interface IComputerPowerSupplySelector
{
    IComputerMotherBoardSelector WithPowerSupply(PowerSupply? powerSupply);
}