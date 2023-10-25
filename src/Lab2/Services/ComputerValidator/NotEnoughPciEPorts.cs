using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Enums;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.ComputerValidator;

public class NotEnoughPciEPorts : IComputerBuildProblem
{
    public string GetProblemDescription()
    {
        return "Not enough PCI-E ports!";
    }

    public bool IsValid(Computer computer)
    {
        if (computer == null)
        {
            throw new ArgumentNullException(nameof(computer));
        }

        int x1PortsCount = computer.MotherBoard.PcieList.Count(port => port.Equals(PCIETypes.X1));
        int x16PortsCount = computer.MotherBoard.PcieList.Count(port => port.Equals(PCIETypes.X16));

        if (computer.VideoCard != null)
        {
            if (computer.VideoCard.PcieType.Equals(PCIETypes.X1) && x1PortsCount > 0)
            {
                x1PortsCount--;
            }
            else
            {
                x16PortsCount--;
            }
        }

        foreach (Ssd ssd in computer.SsdList)
        {
            if (ssd.PcieType.Equals(PCIETypes.X1) && x1PortsCount > 0)
            {
                x1PortsCount--;
            }
            else
            {
                x16PortsCount--;
            }
        }

        if (computer.WiFiAdapter != null)
        {
            if (computer.WiFiAdapter.PcieType.Equals(PCIETypes.X1) && x1PortsCount > 0)
            {
                x1PortsCount--;
            }
            else
            {
                x16PortsCount--;
            }
        }

        return x16PortsCount >= 0;
    }
}