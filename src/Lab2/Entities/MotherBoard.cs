using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using Itmo.ObjectOrientedProgramming.Lab1.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Enums;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class MotherBoard
{
    private readonly Socket _cpuSocket;
    private readonly XMP _chipset;
    private IList<PCIETypes> _pciLines;
    private int _sataPorts;
    private DDRStandarts _ddrStandart;
    private int _memorySlotsCount;
    private MemoryFormFactorTypes _memoryFormFactor;
    private MotherBoardFormFactorTypes _motherBoardFormFactor;
    private Bios? _bios;

    public MotherBoard(
        Socket cpuSocket,
        IList<PCIETypes>? pciLines,
        int sataPorts,
        XMP chipset,
        DDRStandarts ddrStandart,
        int memorySlotsCount,
        MemoryFormFactorTypes memoryFormFactor,
        MotherBoardFormFactorTypes motherBoardFormFactor,
        Bios? bios)
    {
        if (cpuSocket == null)
        {
            throw new ArgumentNullException(nameof(cpuSocket));
        }

        if (chipset == null)
        {
            throw new ArgumentNullException(nameof(chipset));
        }

        if (sataPorts < 0)
        {
            throw new NegativeValueException("SATA ports count is less than 0!");
        }

        if (memorySlotsCount < 1)
        {
            throw new ArgumentException("Memory slots count is less than 1!");
        }

        _cpuSocket = cpuSocket;
        _pciLines = pciLines ?? new List<PCIETypes>();
        _sataPorts = sataPorts;
        _chipset = chipset;
        _ddrStandart = ddrStandart;
        _memoryFormFactor = memoryFormFactor;
        _motherBoardFormFactor = motherBoardFormFactor;
        _memorySlotsCount = memorySlotsCount;
        _bios = bios;
    }

    public Socket CpuSocket => _cpuSocket;
    public ImmutableList<PCIETypes> PcieList => _pciLines.ToImmutableList();
    public int SataPorts => _sataPorts;
    public XMP Chipset => _chipset;
    public DDRStandarts DdrStandart => _ddrStandart;
    public MemoryFormFactorTypes MemoryFormFactor => _memoryFormFactor;
    public MotherBoardFormFactorTypes MotherBoardFormFactor => _motherBoardFormFactor;
    public int MemorySlotsCount => _memorySlotsCount;
    public Bios? Bios => _bios;

    public void UpdateBIOS(Bios newBIOS)
    {
        if (newBIOS == null)
        {
            throw new ArgumentNullException(nameof(newBIOS));
        }

        _bios = newBIOS;
    }
}