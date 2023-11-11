using System;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Cpu : IComponent, ICloneable<Cpu>, ICopyable<Cpu>
{
    private int _cerrCount;
    private Frequency _cerrFrequency;
    private Socket _socket;
    private bool _hasVideoCerr;
    private Frequency _baseFrequency;
    private Frequency _maxFrequency;
    private TDP _tdp;
    private PowerConsumption _powerConsumption;

    public Cpu(
        string? name,
        int cerrCount,
        Frequency? cerrFrequency,
        Socket? socket,
        bool hasVideoCerr,
        Frequency? baseFrequency,
        Frequency? maxFrequency,
        TDP? tdp,
        PowerConsumption? powerConsumption)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentNullException(nameof(name));
        }

        if (cerrCount < 1)
        {
            throw new ArgumentException("Less than 1 cerr!");
        }

        if (cerrFrequency is null)
        {
            throw new ArgumentNullException(nameof(cerrFrequency));
        }

        if (socket is null)
        {
            throw new ArgumentNullException(nameof(socket));
        }

        if (baseFrequency is null)
        {
            throw new ArgumentNullException(nameof(baseFrequency));
        }

        if (maxFrequency is null)
        {
            throw new ArgumentNullException(nameof(maxFrequency));
        }

        if (tdp is null)
        {
            throw new ArgumentNullException(nameof(tdp));
        }

        if (powerConsumption is null)
        {
            throw new ArgumentNullException(nameof(powerConsumption));
        }

        Name = name;
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
        if (other is null)
        {
            throw new ArgumentNullException(nameof(other));
        }

        Name = other.Name;
        _cerrCount = other._cerrCount;
        _cerrFrequency = other._cerrFrequency;
        _socket = other._socket;
        _hasVideoCerr = other._hasVideoCerr;
        _baseFrequency = other._baseFrequency;
        _maxFrequency = other._maxFrequency;
        _tdp = other._tdp;
        _powerConsumption = other._powerConsumption;
    }

    public string Name { get; init; }
    public int CerrCount => _cerrCount;
    public Frequency CerrFrequency => _cerrFrequency;
    public Socket CpuSocket => _socket;
    public bool HasVideoCerr => _hasVideoCerr;
    public Frequency BaseFrequency => _baseFrequency;
    public Frequency MaxFrequency => _baseFrequency;
    public TDP CpuTDP => _tdp;
    public PowerConsumption CpuPowerConsumption => _powerConsumption;

    public Cpu Clone() => new Cpu(this);
    public Cpu DeepCopy()
    {
        return new Cpu(
            Name,
            CerrCount,
            CerrFrequency.DeepCopy(),
            CpuSocket.DeepCopy(),
            _hasVideoCerr,
            BaseFrequency.DeepCopy(),
            MaxFrequency.DeepCopy(),
            CpuTDP.DeepCopy(),
            CpuPowerConsumption.DeepCopy());
    }
}