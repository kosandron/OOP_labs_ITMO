using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;

public class CpuBuilder
{
    private string? _name;
    private int _cerrCount;
    private Frequency? _cerrFrequency;
    private Socket? _socket;
    private bool _hasVideoCerr;
    private Frequency? _baseFrequency;
    private Frequency? _maxFrequency;
    private TDP? _tdp;
    private PowerConsumption? _powerConsumption;

    public CpuBuilder() { }
    public CpuBuilder(Cpu otherCpu)
    {
        if (otherCpu == null)
        {
            throw new ArgumentNullException(nameof(otherCpu));
        }

        _name = otherCpu.Name;
        _cerrCount = otherCpu.CerrCount;
        _cerrFrequency = otherCpu.CerrFrequency;
        _socket = otherCpu.CpuSocket;
        _hasVideoCerr = otherCpu.HasVideoCerr;
        _baseFrequency = otherCpu.BaseFrequency;
        _maxFrequency = otherCpu.MaxFrequency;
        _tdp = otherCpu.CpuTDP;
        _powerConsumption = otherCpu.CpuPowerConsumption;
    }

    public CpuBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public CpuBuilder WithCerrCount(int cerrCount)
    {
        _cerrCount = cerrCount;
        return this;
    }

    public CpuBuilder WithCerrFrequency(Frequency frequency)
    {
        _cerrFrequency = frequency;
        return this;
    }

    public CpuBuilder WithCpuSocket(Socket cpuSocket)
    {
        _socket = cpuSocket;
        return this;
    }

    public CpuBuilder WithVideoCerr()
    {
        _hasVideoCerr = true;
        return this;
    }

    public CpuBuilder WithoutCerr()
    {
        _hasVideoCerr = false;
        return this;
    }

    public CpuBuilder WithBaseFrequency(Frequency frequency)
    {
        _baseFrequency = frequency;
        return this;
    }

    public CpuBuilder WithMaxBaseFrequency(Frequency frequency)
    {
        _maxFrequency = frequency;
        return this;
    }

    public CpuBuilder WithTdp(TDP tdp)
    {
        _tdp = tdp;
        return this;
    }

    public CpuBuilder WithPowerConsumption(PowerConsumption powerConsumption)
    {
        _powerConsumption = powerConsumption;
        return this;
    }

    public Cpu Build()
    {
        return new Cpu(
            _name,
            _cerrCount,
            _cerrFrequency,
            _socket,
            _hasVideoCerr,
            _baseFrequency,
            _maxFrequency,
            _tdp,
            _powerConsumption);
    }
}