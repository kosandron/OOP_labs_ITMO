using System;
using Itmo.ObjectOrientedProgramming.Lab1.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Enums;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;

public class VideoCardBuilder
{
    private string? _name;
    private int _width;
    private int _height;
    private int _memory;
    private PCIETypes _pcieType = PCIETypes.None;
    private Frequency? _chipFrequency;
    private PowerConsumption? _powerConsumption;

    public VideoCardBuilder() { }

    public VideoCardBuilder(VideoCard otherVideoCard)
    {
        if (otherVideoCard == null)
        {
            throw new ArgumentNullException(nameof(otherVideoCard));
        }

        _name = otherVideoCard.Name;
        _width = otherVideoCard.Width;
        _height = otherVideoCard.Height;
        _memory = otherVideoCard.Memory;
        _pcieType = otherVideoCard.PcieType;
        _chipFrequency = otherVideoCard.ChipFrequency;
        _powerConsumption = otherVideoCard.PowerConsumption;
    }

    public VideoCardBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public VideoCardBuilder WithWidth(int width)
    {
        _width = width;
        return this;
    }

    public VideoCardBuilder WithHeight(int height)
    {
        _height = height;
        return this;
    }

    public VideoCardBuilder WithPCIE(PCIETypes pcieType)
    {
        _pcieType = pcieType;
        return this;
    }

    public VideoCardBuilder WithMemory(int memory)
    {
        _memory = memory;
        return this;
    }

    public VideoCardBuilder WithPowerConsumption(PowerConsumption powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public VideoCardBuilder WithChipFrequency(Frequency chipFrequency)
    {
        _chipFrequency = chipFrequency;
        return this;
    }

    public VideoCard Build()
    {
        if (_name == null)
        {
            throw new ArgumentNullException(nameof(_name));
        }

        if (_width <= 0)
        {
            throw new NegativeValueException("Width is less than 0!");
        }

        if (_height <= 0)
        {
            throw new NegativeValueException("Height is less than 0!");
        }

        if (_pcieType == PCIETypes.None)
        {
            throw new ArgumentNullException(nameof(_pcieType));
        }

        if (_chipFrequency == null)
        {
            throw new ArgumentNullException(nameof(_chipFrequency));
        }

        if (_powerConsumption == null)
        {
            throw new ArgumentNullException(nameof(_powerConsumption));
        }

        return new VideoCard(_name, _width, _height, _memory, _pcieType, _chipFrequency, _powerConsumption);
    }
}