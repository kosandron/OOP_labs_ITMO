using System;
using Itmo.ObjectOrientedProgramming.Lab1.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Enums;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class VideoCard
{
    private readonly int _width;
    private readonly int _height;
    private readonly int _memory;
    private readonly PCIETypes _pcieType;
    private readonly Frequency _chipFrequency;
    private readonly PowerConsumption _powerConsumption;

    public VideoCard(int width, int height, int memory, PCIETypes pcieType, Frequency chipFrequency, PowerConsumption powerConsumption)
    {
        if (width <= 0)
        {
            throw new NegativeValueException("Width is less than 0!");
        }

        if (height <= 0)
        {
            throw new NegativeValueException("Height is less than 0!");
        }

        if (chipFrequency == null)
        {
            throw new ArgumentNullException(nameof(chipFrequency));
        }

        if (powerConsumption == null)
        {
            throw new ArgumentNullException(nameof(powerConsumption));
        }

        _width = width;
        _height = height;
        _memory = memory;
        _pcieType = pcieType;
        _chipFrequency = chipFrequency;
        _powerConsumption = powerConsumption;
    }

    public int Width => _width;
    public int Height => _height;
    public int Memory => _memory;
    public PCIETypes PcieType => _pcieType;
    public Frequency ChipFrequency => _chipFrequency;
    public PowerConsumption PowerConsumption => _powerConsumption;
}