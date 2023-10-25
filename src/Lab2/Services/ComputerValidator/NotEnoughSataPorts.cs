using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Enums;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.ComputerValidator;

public class NotEnoughSataPorts : IComputerBuildProblem
{
    public string GetProblemDescription()
    {
        return "Not enough SATA ports!";
    }

    public bool IsValid(Computer computer)
    {
        if (computer == null)
        {
            throw new ArgumentNullException(nameof(computer));
        }

        return computer.MotherBoard.SataPorts >= computer.HddList.Count + computer.SsdList.Count(ssd => ssd.PcieType.Equals(PCIETypes.None));
    }
}