using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Cpu
{
    private string _name;
    private int _cerrCount;
    private Frequency _cerrFrequency;
    private Socket _socket;
    private bool _hasVideoCerr;
    private Frequency _baseFrequency;
    private Frequency _maxFrequency;
    private TDP _tdp;
    private PowerConsumption _powerConsumption;

    public Cpu(
        string name,
        int cerrCount,
        Frequency cerrFrequency,
        Socket socket,
        bool hasVideoCerr,
        Frequency baseFrequency,
        Frequency maxFrequency,
        TDP tdp,
        PowerConsumption powerConsumption)
    {
        if (cerrCount < 1)
        {
            throw new ArgumentException("Less than 1 cerr!");
        }

        _name = name;
        _cerrCount = cerrCount;
        _cerrFrequency = cerrFrequency;
        _socket = socket;
        _hasVideoCerr = hasVideoCerr;
        _baseFrequency = baseFrequency;
        _maxFrequency = maxFrequency;
        _tdp = tdp;
        _powerConsumption = powerConsumption;
    }

    private Cpu(Cpu other)
    {
        if (other == null)
        {
            throw new ArgumentNullException(nameof(other));
        }

        _name = other.Name;
        _cerrCount = other.CerrCount;
        _cerrFrequency = other.CerrFrequency;
        _socket = other.CpuSocket;
        _hasVideoCerr = other.HasVideoCerr;
        _baseFrequency = other.BaseFrequency;
        _maxFrequency = other.MaxFrequency;
        _tdp = other.CpuTDP;
        _powerConsumption = other.CpuPowerConsumption;
    }

    public string Name => _name;
    public int CerrCount => _cerrCount;
    public Frequency CerrFrequency => _cerrFrequency;
    public Socket CpuSocket => _socket;
    public bool HasVideoCerr => _hasVideoCerr;
    public Frequency BaseFrequency => _baseFrequency;
    public Frequency MaxFrequency => _baseFrequency;
    public TDP CpuTDP => _tdp;
    public PowerConsumption CpuPowerConsumption => _powerConsumption;

    public Cpu Clone() => new Cpu(this);
}