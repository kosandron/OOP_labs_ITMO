using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Enums;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;

public class MotherBoardBuilder
{
    private string? _name;
    private Socket? _cpuSocket;
    private XMP? _chipset;
    private IList<PCIETypes>? _pciLines;
    private int _sataPorts;
    private DDRStandarts _ddrStandart;
    private int _memorySlotsCount;
    private MemoryFormFactorTypes _memoryFormFactor = MemoryFormFactorTypes.None;
    private MotherBoardFormFactorTypes _motherBoardFormFactor = MotherBoardFormFactorTypes.None;
    private Bios? _bios;

    public MotherBoardBuilder() { }

    public MotherBoardBuilder(MotherBoard otherMotherBoard)
    {
        if (otherMotherBoard == null)
        {
            throw new ArgumentNullException(nameof(otherMotherBoard));
        }

        _name = otherMotherBoard.Name;
        _cpuSocket = otherMotherBoard.CpuSocket;
        _pciLines = otherMotherBoard.PcieList;
        _sataPorts = otherMotherBoard.SataPorts;
        _chipset = otherMotherBoard.Chipset;
        _ddrStandart = otherMotherBoard.DdrStandart;
        _memoryFormFactor = otherMotherBoard.MemoryFormFactor;
        _motherBoardFormFactor = otherMotherBoard.MotherBoardFormFactor;
        _memorySlotsCount = otherMotherBoard.MemorySlotsCount;
        _bios = otherMotherBoard.Bios;
    }

    public MotherBoardBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public MotherBoardBuilder WithCpuSocket(Socket cpuSocket)
    {
        _cpuSocket = cpuSocket;
        return this;
    }

    public MotherBoardBuilder WithPcieList(IList<PCIETypes> pcieList)
    {
        _pciLines = pcieList;
        return this;
    }

    public MotherBoardBuilder WithSataPorts(int count)
    {
        _sataPorts = count;
        return this;
    }

    public MotherBoardBuilder WithChipset(XMP chipset)
    {
        _chipset = chipset;
        return this;
    }

    public MotherBoardBuilder WithMemoryFormFactor(MemoryFormFactorTypes type)
    {
        _memoryFormFactor = type;
        return this;
    }

    public MotherBoardBuilder WithMotherBoardFormFactor(MotherBoardFormFactorTypes type)
    {
        _motherBoardFormFactor = type;
        return this;
    }

    public MotherBoardBuilder WithMemorySlotsCount(int count)
    {
        _memorySlotsCount = count;
        return this;
    }

    public MotherBoardBuilder WithDdr(DDRStandarts standart)
    {
        _ddrStandart = standart;
        return this;
    }

    public MotherBoardBuilder WithBios(Bios bios)
    {
        _bios = bios;
        return this;
    }

    public MotherBoard Build()
    {
        return new MotherBoard(
            _name,
            _cpuSocket,
            _pciLines,
            _sataPorts,
            _chipset,
            _ddrStandart,
            _memorySlotsCount,
            _memoryFormFactor,
            _motherBoardFormFactor,
            _bios);
    }
}