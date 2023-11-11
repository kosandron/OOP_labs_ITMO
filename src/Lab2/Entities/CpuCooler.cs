using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class CpuCooler : IComponent, ICloneable<CpuCooler>, ICopyable<CpuCooler>
{
    private int _size;
    private IList<Socket> _supportedSockedList;
    private TDP _powerDissipation;

    public CpuCooler(string? name, int size, IList<Socket>? supportedSockedList, TDP? powerDissipation)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentNullException(nameof(name));
        }

        if (size <= 0)
        {
            throw new NegativeValueException("Size is less than null!");
        }

        if (supportedSockedList?.Count < 1)
        {
            throw new EmptyCollectionException("Cooler doesn`t support any socket");
        }

        if (powerDissipation is null)
        {
            throw new ArgumentNullException(nameof(powerDissipation));
        }

        Name = name;
        _size = size;
        _supportedSockedList = supportedSockedList ?? throw new ArgumentNullException(nameof(supportedSockedList));
        _powerDissipation = powerDissipation;
    }

    private CpuCooler(CpuCooler other)
    {
        if (other is null)
        {
            throw new ArgumentNullException(nameof(other));
        }

        Name = other.Name;
        _size = other._size;
        _supportedSockedList = other._supportedSockedList;
        _powerDissipation = other._powerDissipation;
    }

    public string Name { get; init; }
    public int Size => _size;
    public IImmutableList<Socket> SupportedSockedList => _supportedSockedList.ToImmutableList();
    public TDP PowerDissipation => _powerDissipation;

    public CpuCooler Clone() => new CpuCooler(this);
    public CpuCooler DeepCopy()
    {
        return new CpuCooler(Name, Size, new List<Socket>(SupportedSockedList), PowerDissipation.DeepCopy());
    }
}