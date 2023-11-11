using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class Computer : ICopyable<Computer>
{
    private MotherBoard _motherBoard;
    private Cpu _cpu;
    private Ram _ram;
    private CpuCooler _cpuCooler;
    private ComputerCase _computerCase;
    private PowerSupply _powerSupply;
    private VideoCard? _videoCard;
    private IList<Ssd> _ssdList;
    private IList<Hdd> _hddList;
    private WiFiAdapter? _wiFiAdapter;

    public Computer(
        MotherBoard motherBoard,
        Cpu cpu,
        Ram ram,
        CpuCooler cpuCooler,
        ComputerCase computerCase,
        PowerSupply powerSupply,
        VideoCard? videoCard,
        IList<Ssd>? ssdList,
        IList<Hdd>? hddList,
        WiFiAdapter? wiFiAdapter)
    {
        if (motherBoard == null)
        {
            throw new ArgumentNullException(nameof(motherBoard));
        }

        if (cpu == null)
        {
            throw new ArgumentNullException(nameof(cpu));
        }

        if (ram == null)
        {
            throw new ArgumentNullException(nameof(ram));
        }

        if (cpuCooler == null)
        {
            throw new ArgumentNullException(nameof(cpuCooler));
        }

        if (powerSupply == null)
        {
            throw new ArgumentNullException(nameof(powerSupply));
        }

        _motherBoard = motherBoard;
        _cpu = cpu;
        _ram = ram;
        _cpuCooler = cpuCooler;
        _computerCase = computerCase;
        _powerSupply = powerSupply;
        _videoCard = videoCard;
        _ssdList = ssdList ?? new List<Ssd>();
        _hddList = hddList ?? new List<Hdd>();
        _wiFiAdapter = wiFiAdapter;
    }

    public MotherBoard MotherBoard => _motherBoard;
    public Cpu Cpu => _cpu;
    public Ram Ram => _ram;
    public CpuCooler CpuCooler => _cpuCooler;
    public ComputerCase ComputerCase => _computerCase;
    public PowerSupply PowerSupply => _powerSupply;
    public VideoCard? VideoCard => _videoCard;
    public IList<Ssd> SsdList => _ssdList;
    public IList<Hdd> HddList => _hddList;
    public WiFiAdapter? WiFiAdapter => _wiFiAdapter;

    public Computer DeepCopy()
    {
        return new Computer(
            _motherBoard.DeepCopy(),
            _cpu.DeepCopy(),
            _ram.DeepCopy(),
            _cpuCooler.DeepCopy(),
            _computerCase.DeepCopy(),
            _powerSupply.DeepCopy(),
            _videoCard?.DeepCopy(),
            new List<Ssd>(_ssdList),
            new List<Hdd>(_hddList),
            _wiFiAdapter?.DeepCopy());
    }
}