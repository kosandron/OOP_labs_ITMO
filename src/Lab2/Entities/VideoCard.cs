using System;
using Itmo.ObjectOrientedProgramming.Lab1.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Enums;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class VideoCard : IComponent, ICloneable<VideoCard>, ICopyable<VideoCard>
{
    private readonly int _width;
    private readonly int _height;
    private readonly int _memory;
    private readonly PCIETypes _pcieType;
    private readonly Frequency _chipFrequency;
    private readonly PowerConsumption _powerConsumption;

    public VideoCard(string name, int width, int height, int memory, PCIETypes pcieType, Frequency chipFrequency, PowerConsumption powerConsumption)
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

        Name = name;
        _width = width;
        _height = height;
        _memory = memory;
        _pcieType = pcieType;
        _chipFrequency = chipFrequency;
        _powerConsumption = powerConsumption;
    }

    private VideoCard(VideoCard other)
    {
        if (other == null)
        {
            throw new ArgumentNullException(nameof(other));
        }

        Name = other.Name;
        _width = other._width;
        _height = other._height;
        _memory = other._memory;
        _pcieType = other._pcieType;
        _chipFrequency = other._chipFrequency;
        _powerConsumption = other._powerConsumption;
    }

    public string Name { get; init; }
    public int Width => _width;
    public int Height => _height;
    public int Memory => _memory;
    public PCIETypes PcieType => _pcieType;
    public Frequency ChipFrequency => _chipFrequency;
    public PowerConsumption PowerConsumption => _powerConsumption;

    public VideoCard Clone() => new VideoCard(this);
    public VideoCard DeepCopy()
    {
        return new VideoCard(Name, Width, Height, Memory, PcieType, ChipFrequency.DeepCopy(), PowerConsumption.DeepCopy());
    }
}