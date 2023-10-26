using System.Collections.Generic;
using System.Collections.Immutable;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class SupportedComponents
{
    private IList<Bios> _biosList;
    private IList<ComputerCase> _computerCaseList;
    private IList<Cpu> _cpuList;
    private IList<CpuCooler> _cpuCoolerList;
    private IList<Hdd> _hhdList;
    private IList<Ssd> _ssdList;
    private IList<MotherBoard> _motherBoardList;
    private IList<PowerSupply> _powerSupplyList;
    private IList<Ram> _ramList;
    private IList<VideoCard> _videoCardList;
    private IList<WiFiAdapter> _wiFiAdapterList;

    public SupportedComponents()
    {
        _biosList = new SupportedBios().ComponentList;
        _cpuCoolerList = new SupportedCpuCooler().ComponentList;
        _hhdList = new SupportedHdd().ComponentList;
        _ssdList = new SupportedSsd().ComponentList;
        _computerCaseList = new SupportedComputerCase().ComponentList;
        _cpuList = new SupportedCpu().ComponentList;
        _motherBoardList = new SupportedMotherBoard().ComponentList;
        _powerSupplyList = new SupportedPowerSupply().ComponentList;
        _ramList = new SupportedRam().ComponentList;
        _videoCardList = new SupportedVideoCard().ComponentList;
        _wiFiAdapterList = new SupportedWiFiAdapter().ComponentList;
    }

    public ImmutableList<Bios> SupportedBiosList => _biosList.ToImmutableList();
    public ImmutableList<ComputerCase> SupportedComputerCaseList => _computerCaseList.ToImmutableList();
    public ImmutableList<Cpu> SupportedCpuList => _cpuList.ToImmutableList();
    public ImmutableList<CpuCooler> SupportedCpuCoolerList => _cpuCoolerList.ToImmutableList();
    public ImmutableList<Hdd> SupportedHddList => _hhdList.ToImmutableList();
    public ImmutableList<Ssd> SupportedSsdList => _ssdList.ToImmutableList();
    public ImmutableList<MotherBoard> SupportedMotherBoardList => _motherBoardList.ToImmutableList();
    public ImmutableList<PowerSupply> SupportedPowerSupplyList => _powerSupplyList.ToImmutableList();
    public ImmutableList<Ram> SupportedRamList => _ramList.ToImmutableList();
    public ImmutableList<VideoCard> SupportedVideoCardList => _videoCardList.ToImmutableList();
    public ImmutableList<WiFiAdapter> SupportedWiFiAdapterList => _wiFiAdapterList.ToImmutableList();
}