using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using Itmo.ObjectOrientedProgramming.Lab2.Enums;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class MotherBoard : IComponent, ICloneable<MotherBoard>, ICopyable<MotherBoard>
{
    private readonly Socket _cpuSocket;
    private readonly XMP _chipset;
    private IList<PCIETypes> _pciLines;
    private int _sataPorts;
    private DDRStandarts _ddrStandart;
    private int _memorySlotsCount;
    private MemoryFormFactorTypes _memoryFormFactor;
    private MotherBoardFormFactorTypes _motherBoardFormFactor;
    private Bios _bios;

    public MotherBoard(
        string? name,
        Socket? cpuSocket,
        IList<PCIETypes>? pciLines,
        int sataPorts,
        XMP? chipset,
        DDRStandarts ddrStandart,
        int memorySlotsCount,
        MemoryFormFactorTypes memoryFormFactor,
        MotherBoardFormFactorTypes motherBoardFormFactor,
        Bios? bios)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentNullException(nameof(name));
        }

        if (cpuSocket is null)
        {
            throw new ArgumentNullException(nameof(cpuSocket));
        }

        if (memoryFormFactor == MemoryFormFactorTypes.None)
        {
            throw new ArgumentNullException(nameof(memoryFormFactor));
        }

        if (motherBoardFormFactor == MotherBoardFormFactorTypes.None)
        {
            throw new ArgumentNullException(nameof(motherBoardFormFactor));
        }

        if (ddrStandart == DDRStandarts.None)
        {
            throw new ArgumentNullException(nameof(ddrStandart));
        }

        if (chipset is null)
        {
            throw new ArgumentNullException(nameof(chipset));
        }

        if (bios is null)
        {
            throw new ArgumentNullException(nameof(bios));
        }

        if (sataPorts < 0)
        {
            throw new NegativeValueException("SATA ports count is less than 0!");
        }

        if (memorySlotsCount < 1)
        {
            throw new ArgumentException("Memory slots count is less than 1!");
        }

        Name = name;
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

    private MotherBoard(MotherBoard other)
    {
        if (other is null)
        {
            throw new ArgumentNullException(nameof(other));
        }

        Name = other.Name;
        _cpuSocket = other._cpuSocket;
        _pciLines = other._pciLines ?? new List<PCIETypes>();
        _sataPorts = other._sataPorts;
        _chipset = other._chipset;
        _ddrStandart = other._ddrStandart;
        _memoryFormFactor = other._memoryFormFactor;
        _motherBoardFormFactor = other._motherBoardFormFactor;
        _memorySlotsCount = other._memorySlotsCount;
        _bios = other._bios;
    }

    public string Name { get; init; }
    public Socket CpuSocket => _cpuSocket;
    public ImmutableList<PCIETypes> PcieList => _pciLines.ToImmutableList();
    public int SataPorts => _sataPorts;
    public XMP Chipset => _chipset;
    public DDRStandarts DdrStandart => _ddrStandart;
    public MemoryFormFactorTypes MemoryFormFactor => _memoryFormFactor;
    public MotherBoardFormFactorTypes MotherBoardFormFactor => _motherBoardFormFactor;
    public int MemorySlotsCount => _memorySlotsCount;
    public Bios Bios => _bios;
    public MotherBoard Clone() => new MotherBoard(this);

    public void UpdateBIOS(Bios newBIOS)
    {
        if (newBIOS == null)
        {
            throw new ArgumentNullException(nameof(newBIOS));
        }

        _bios = newBIOS;
    }

    public MotherBoard DeepCopy()
    {
        return new MotherBoard(
            Name,
            CpuSocket.DeepCopy(),
            new List<PCIETypes>(PcieList),
            SataPorts,
            Chipset.DeepCopy(),
            DdrStandart,
            MemorySlotsCount,
            MemoryFormFactor,
            MotherBoardFormFactor,
            Bios.DeepCopy());
    }
}