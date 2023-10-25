using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Enums;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Services;
using Itmo.ObjectOrientedProgramming.Lab2.Services.ComputerValidator;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Factories;
using Xunit;
using Computer = Itmo.ObjectOrientedProgramming.Lab2.Services.Computer;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class ComputerBuildTests
{
    private BiosFactory _biosFactory;
    private ComputerCaseFactory _computerCaseFactory;
    private CpuCoolerFactory _cpuCoolerFactory;
    private CpuFactory _cpuFactory;
    private HddFactory _hddFactory;
    private MotherBoardFactory _motherBoardFactory;
    private PowerSupplyFactory _powerSupplyFactory;
    private RamFactory _ramFactory;
    private SsdFactory _ssdFactory;
    private VideoCardFactory _videoCardFactory;
    private WiFiAdapterFactory _wiFiAdapterFactory;
    private Computer _computer;

    public ComputerBuildTests()
    {
        _biosFactory = new BiosFactory(new List<Bios>()
        {
            new Bios("Bios 1.0", "type 1", "SuperPower", new List<string>() { "Intel i-123", "Intel i-239" }),
            new Bios("Bios 2.0", "type 2", "SuperPower", new List<string>() { "Intel i-321", "Intel i-239", "Intel i-40" }),
            new Bios("Bios 3.0", "type 3", "MegaFlexible", new List<string>() { "Intel i-123", "Intel i-40", "Intel i-75" }),
        });
        _computerCaseFactory = new ComputerCaseFactory(new List<ComputerCase>()
        {
            new ComputerCase(
                "Cougar Pro",
                200,
                200,
                new List<MotherBoardFormFactorTypes>()
                {
                    MotherBoardFormFactorTypes.MicroATX,
                    MotherBoardFormFactorTypes.StandartATX,
                },
                CaseSize.Middle),
            new ComputerCase(
                "Cougar Standart",
                100,
                100,
                new List<MotherBoardFormFactorTypes>()
                {
                    MotherBoardFormFactorTypes.MiniITX,
                },
                CaseSize.Small),
            new ComputerCase(
                "Cougar Big",
                300,
                300,
                new List<MotherBoardFormFactorTypes>()
                {
                    MotherBoardFormFactorTypes.EATX,
                    MotherBoardFormFactorTypes.XLATX,
                },
                CaseSize.Big),
        });
        _cpuCoolerFactory = new CpuCoolerFactory(new List<CpuCooler>()
        {
            new CpuCooler(
                "Fly small",
                100,
                new List<Socket>()
                {
                    new Socket("AM1"),
                    new Socket("AM2"),
                },
                new TDP(150)),
            new CpuCooler(
                "Fly medium",
                200,
                new List<Socket>()
                {
                    new Socket("AM3"),
                    new Socket("AM4"),
                },
                new TDP(250)),
            new CpuCooler(
                "Fly big",
                200,
                new List<Socket>()
                {
                    new Socket("AM5"),
                    new Socket("AM6"),
                },
                new TDP(400)),
        });
        _cpuFactory = new CpuFactory(new List<Cpu>()
        {
            new Cpu(
                "Intel i-123",
                4,
                new Frequency(900),
                new Socket("AM1"),
                false,
                new Frequency(3600),
                new Frequency(4600),
                new TDP(200),
                new PowerConsumption(100)),
            new Cpu(
                "Intel i-239",
                8,
                new Frequency(1500),
                new Socket("AM3"),
                true,
                new Frequency(3400),
                new Frequency(5400),
                new TDP(200),
                new PowerConsumption(150)),
            new Cpu(
                "Intel i-321",
                8,
                new Frequency(1400),
                new Socket("AM5"),
                true,
                new Frequency(3200),
                new Frequency(5600),
                new TDP(300),
                new PowerConsumption(200)),
            new Cpu(
                "Intel i-40",
                2,
                new Frequency(600),
                new Socket("AM1"),
                false,
                new Frequency(3600),
                new Frequency(4400),
                new TDP(200),
                new PowerConsumption(100)),
            new Cpu(
                "Intel i-75",
                4,
                new Frequency(1000),
                new Socket("AM2"),
                false,
                new Frequency(3500),
                new Frequency(4500),
                new TDP(200),
                new PowerConsumption(100)),
        });
        _hddFactory = new HddFactory(new List<Hdd>()
        {
            new Hdd(
                "WD Blue",
                4,
                7200,
                new PowerConsumption(68)),
            new Hdd(
                "WD Black",
                256,
                7200,
                new PowerConsumption(53)),
        });
        _motherBoardFactory = new MotherBoardFactory(new List<MotherBoard>()
        {
            new MotherBoard(
                "MSI MAG",
                new Socket("AM1"),
                new List<PCIETypes>()
                {
                    PCIETypes.X1,
                    PCIETypes.X16,
                },
                3,
                new XMP(
                    new Frequency(4900),
                    120,
                    "18-18-36-54"),
                DDRStandarts.DDR3,
                2,
                MemoryFormFactorTypes.DIMM,
                MotherBoardFormFactorTypes.MiniITX,
                new Bios(
                    "Bios 1.0",
                    "type 1",
                    "SuperPower",
                    new List<string>()
                    {
                        "Intel i-123",
                        "Intel i-239",
                    })),
            new MotherBoard(
                "MSI MAG 2",
                new Socket("AM3"),
                new List<PCIETypes>()
                {
                    PCIETypes.X1,
                    PCIETypes.X16,
                    PCIETypes.X16,
                },
                4,
                new XMP(
                    new Frequency(5200),
                    130,
                    "18-18-42-54"),
                DDRStandarts.DDR4,
                4,
                MemoryFormFactorTypes.DIMM,
                MotherBoardFormFactorTypes.StandartATX,
                new Bios(
                    "Bios 2.0",
                    "type 2",
                    "SuperPower",
                    new List<string>()
                    {
                        "Intel i-321",
                        "Intel i-239",
                        "Intel i-40",
                    })),
        });
        _powerSupplyFactory = new PowerSupplyFactory(new List<PowerSupply>()
        {
            new PowerSupply("Supply small", new PowerConsumption(300)),
            new PowerSupply("Supply big", new PowerConsumption(600)),
        });
        _ramFactory = new RamFactory(new List<Ram>()
        {
            new Ram(
                "Adata small",
                new XMP(
                    new Frequency(4000),
                    120,
                    "18-18-36-54"),
                MemoryFormFactorTypes.DIMM,
                DDRStandarts.DDR4,
                new PowerConsumption(100)),
            new Ram(
                "Adata medium",
                new XMP(
                    new Frequency(4200),
                    120,
                    "18-18-42-54"),
                MemoryFormFactorTypes.DIMM,
                DDRStandarts.DDR4,
                new PowerConsumption(110)),
            new Ram(
                "Adata big",
                new XMP(
                    new Frequency(4400),
                    120,
                    "18-18-46-54"),
                MemoryFormFactorTypes.DIMM,
                DDRStandarts.DDR5,
                new PowerConsumption(120)),
        });
        _ssdFactory = new SsdFactory(new List<Ssd>()
        {
            new Ssd(
                "Kingston A400",
                PCIETypes.None,
                420,
                450,
                new PowerConsumption(100)),
            new Ssd(
                "Kingston A500",
                PCIETypes.X1,
                500,
                450,
                new PowerConsumption(100)),
            new Ssd(
                "Kingston A600",
                PCIETypes.X16,
                600,
                450,
                new PowerConsumption(100)),
        });
        _videoCardFactory = new VideoCardFactory(new List<VideoCard>()
        {
            new VideoCard(
                "KFA2 GeForce",
                100,
                100,
                12,
                PCIETypes.X1,
                new Frequency(1320),
                new PowerConsumption(70)),
            new VideoCard(
                "KFA3 GeForce",
                200,
                200,
                24,
                PCIETypes.X16,
                new Frequency(1400),
                new PowerConsumption(80)),
        });
        _wiFiAdapterFactory = new WiFiAdapterFactory(new List<WiFiAdapter>()
        {
            new WiFiAdapter(
                "Mercusys 1",
                "v1",
                false,
                PCIETypes.X1,
                new PowerConsumption(30)),
            new WiFiAdapter(
                "Mercusys 2",
                "v2",
                true,
                PCIETypes.X1,
                new PowerConsumption(30)),
            new WiFiAdapter(
                "Mercusys 3",
                "v3",
                true,
                PCIETypes.X16,
                new PowerConsumption(50)),
        });
        var builder = new ComputerBuilder();
        _computer = builder
            .WithComputerCase(_computerCaseFactory.CreateByName("Cougar Pro"))
            .WithPowerSupply(_powerSupplyFactory.CreateByName("Supply big"))
            .WithMotherBoard(_motherBoardFactory.CreateByName("MSI MAG 2"))
            .WithCpu(_cpuFactory.CreateByName("Intel i-239"))
            .WithCpuCooler(_cpuCoolerFactory.CreateByName("Fly medium"))
            .WithRam(_ramFactory.CreateByName("Adata small")).Build();
    }

    [Fact]
    public void SuccessfullBuild()
    {
        // Arrange
        Computer computer = _computer;
        var validator = new ComputerValidator();

        // Act
        DiagnosticResult result = validator.GetDiagnosticResult(computer);

        // Assert
        Assert.Equal("OK!", result.ResultDescription);
    }

    [Fact]
    public void NoGarancyBuild()
    {
        // Arrange
        Computer computer = _computer.DeepCopy();
        var builder = new ComputerBuilder(computer);
        computer = builder.WithCpuCooler(_cpuCoolerFactory.CreateByName("Fly small")).WithRam(computer.Ram).Build();
        var validator = new ComputerValidator();

        // Act
        DiagnosticResult result = validator.GetDiagnosticResult(computer);

        // Assert
        Assert.Equal("Comment: no garancy!", result.ResultDescription);
    }

    [Fact]
    public void PowerAlarmBuild()
    {
        // Arrange
        Computer computer = _computer.DeepCopy();
        var builder = new ComputerBuilder(computer);
        computer = builder
            .WithPowerSupply(_powerSupplyFactory.CreateByName("Supply small"))
            .WithMotherBoard(computer.MotherBoard)
            .WithCpu(computer.Cpu)
            .WithCpuCooler(computer.CpuCooler)
            .WithRam(computer.Ram)
            .WithHdd(_hddFactory.CreateByName("WD Blue"))
            .Build();
        var validator = new ComputerValidator();

        // Act
        DiagnosticResult result = validator.GetDiagnosticResult(computer);

        // Assert
        Assert.Equal("Alarm: power consumption is increased!", result.ResultDescription);
        Assert.IsType<PowerConsumptionProblem>(result.ProblemsList[0]);
    }

    [Fact]
    public void ProblemTypeBuildTest()
    {
        // Arrange
        Computer computer = _computer.DeepCopy();
        var builder = new ComputerBuilder(computer);
        computer = builder
            .WithPowerSupply(_powerSupplyFactory.CreateByName("Supply small"))
            .WithMotherBoard(computer.MotherBoard)
            .WithCpu(computer.Cpu)
            .WithCpuCooler(computer.CpuCooler)
            .WithRam(_ramFactory.CreateByName("Adata big"))
            .Build();
        var validator = new ComputerValidator();

        // Act
        DiagnosticResult result = validator.GetDiagnosticResult(computer);

        // Assert
        Assert.Equal("Some problems!", result.ResultDescription);
        Assert.IsType<NoDdrConnectivityProblem>(result.ProblemsList[0]);
    }
}