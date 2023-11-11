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
        var components = new SupportedComponents();
        _biosFactory = new BiosFactory(components.SupportedBiosList);
        _computerCaseFactory = new ComputerCaseFactory(components.SupportedComputerCaseList);
        _cpuCoolerFactory = new CpuCoolerFactory(components.SupportedCpuCoolerList);
        _cpuFactory = new CpuFactory(components.SupportedCpuList);
        _hddFactory = new HddFactory(components.SupportedHddList);
        _motherBoardFactory = new MotherBoardFactory(components.SupportedMotherBoardList);
        _powerSupplyFactory = new PowerSupplyFactory(components.SupportedPowerSupplyList);
        _ramFactory = new RamFactory(components.SupportedRamList);
        _ssdFactory = new SsdFactory(components.SupportedSsdList);
        _videoCardFactory = new VideoCardFactory(components.SupportedVideoCardList);
        _wiFiAdapterFactory = new WiFiAdapterFactory(components.SupportedWiFiAdapterList);
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