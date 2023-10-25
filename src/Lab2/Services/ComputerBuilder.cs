using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class ComputerBuilder : IComputerCaseSelector, IComputerPowerSupplySelector, IComputerMotherBoardSelector, IComputerCpuSelector, IComputerCpuCoolerSelector, IComputerRamSelector, IComputerBuilder
{
    private MotherBoard? _motherBoard;
    private Cpu? _cpu;
    private Ram? _ram;
    private CpuCooler? _cpuCooler;
    private ComputerCase? _computerCase;
    private PowerSupply? _powerSupply;
    private VideoCard? _videoCard;
    private IList<Ssd> _ssdList = new List<Ssd>();
    private IList<Hdd> _hddList = new List<Hdd>();
    private WiFiAdapter? _wiFiAdapter;

    public ComputerBuilder() { }

    public ComputerBuilder(Computer otherComputer)
    {
        if (otherComputer == null)
        {
            throw new ArgumentNullException(nameof(otherComputer));
        }

        _motherBoard = otherComputer.MotherBoard;
        _cpu = otherComputer.Cpu;
        _ram = otherComputer.Ram;
        _cpuCooler = otherComputer.CpuCooler;
        _computerCase = otherComputer.ComputerCase;
        _powerSupply = otherComputer.PowerSupply;
        _videoCard = otherComputer.VideoCard;
        _ssdList = otherComputer.SsdList;
        _hddList = otherComputer.HddList;
        _wiFiAdapter = otherComputer.WiFiAdapter;
    }

    public Computer Build()
    {
        if (_motherBoard == null)
        {
            throw new ArgumentNullException(nameof(_motherBoard));
        }

        if (_cpu == null)
        {
            throw new ArgumentNullException(nameof(_cpu));
        }

        if (_ram == null)
        {
            throw new ArgumentNullException(nameof(_ram));
        }

        if (_cpuCooler == null)
        {
            throw new ArgumentNullException(nameof(_cpuCooler));
        }

        if (_computerCase == null)
        {
            throw new ArgumentNullException(nameof(_computerCase));
        }

        if (_powerSupply == null)
        {
            throw new ArgumentNullException(nameof(_powerSupply));
        }

        return new Computer(
            _motherBoard,
            _cpu,
            _ram,
            _cpuCooler,
            _computerCase,
            _powerSupply,
            _videoCard,
            _ssdList,
            _hddList,
            _wiFiAdapter);
    }

    public IComputerPowerSupplySelector WithComputerCase(ComputerCase? computerCase)
    {
        _computerCase = computerCase;
        return this;
    }

    public IComputerMotherBoardSelector WithPowerSupply(PowerSupply? powerSupply)
    {
        _powerSupply = powerSupply;
        return this;
    }

    public IComputerCpuSelector WithMotherBoard(MotherBoard? motherBoard)
    {
        _motherBoard = motherBoard;
        return this;
    }

    public IComputerCpuCoolerSelector WithCpu(Cpu? cpu)
    {
        _cpu = cpu;
        return this;
    }

    public IComputerRamSelector WithCpuCooler(CpuCooler? cpuCooler)
    {
        _cpuCooler = cpuCooler;
        return this;
    }

    public IComputerBuilder WithRam(Ram? ram)
    {
        _ram = ram;
        return this;
    }

    public IComputerBuilder WithVideoCard(VideoCard? videoCard)
    {
        _videoCard = videoCard;
        return this;
    }

    public IComputerBuilder WithSsd(Ssd? ssd)
    {
        if (ssd != null)
        {
            _ssdList.Add(ssd);
        }

        return this;
    }

    public IComputerBuilder WithHdd(Hdd? hdd)
    {
        if (hdd != null)
        {
            _hddList.Add(hdd);
        }

        return this;
    }

    public IComputerBuilder WithWifiAdapter(WiFiAdapter? wiFiAdapter)
    {
        _wiFiAdapter = wiFiAdapter;
        return this;
    }
}