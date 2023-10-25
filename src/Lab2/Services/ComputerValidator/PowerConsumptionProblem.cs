using System;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.ComputerValidator;

public class PowerConsumptionProblem : IComputerBuildProblem
{
    public string GetProblemDescription()
    {
        return "Alarm: the peak load of the power supply has been exceeded!";
    }

    public bool IsValid(Computer computer)
    {
        if (computer == null)
        {
            throw new ArgumentNullException(nameof(computer));
        }

        int summaryPowerConsumption = computer.Cpu.CpuPowerConsumption.Value + computer.Ram.PowerConsumption.Value;
        if (computer.VideoCard != null)
        {
            summaryPowerConsumption += computer.VideoCard.PowerConsumption.Value;
        }

        if (computer.WiFiAdapter != null)
        {
            summaryPowerConsumption += computer.WiFiAdapter.PowerConsumption.Value;
        }

        summaryPowerConsumption += computer.SsdList.Sum(ssd => ssd.PowerConsumption.Value);
        summaryPowerConsumption += computer.HddList.Sum(hdd => hdd.PowerConsumption.Value);

        return summaryPowerConsumption <= computer.PowerSupply.PowerConsumption.Value;
    }
}