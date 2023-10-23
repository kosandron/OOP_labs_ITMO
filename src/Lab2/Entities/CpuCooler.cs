using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using Itmo.ObjectOrientedProgramming.Lab1.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class CpuCooler
{
    private string _name;
    private int _size;
    private IList<Socket> _supportedSockedList;
    private TDP _powerDissipation;

    public CpuCooler(string name, int size, IList<Socket> supportedSockedList, TDP powerDissipation)
    {
        if (size <= 0)
        {
            throw new NegativeValueException("Sixe is less than null!");
        }

        if (supportedSockedList == null)
        {
            throw new ArgumentNullException(nameof(supportedSockedList));
        }

        if (supportedSockedList.Count < 1)
        {
            throw new ArgumentException("Cooler doesn`t support any socket");
        }

        if (powerDissipation == null)
        {
            throw new ArgumentNullException(nameof(powerDissipation));
        }

        _name = name;
        _size = size;
        _supportedSockedList = supportedSockedList;
        _powerDissipation = powerDissipation;
    }

    private CpuCooler(CpuCooler other)
    {
        if (other == null)
        {
            throw new ArgumentNullException(nameof(other));
        }

        _name = other._name;
        _size = other._size;
        _supportedSockedList = other._supportedSockedList;
        _powerDissipation = other._powerDissipation;
    }

    public string Name => _name;
    public int Size => _size;
    public IImmutableList<Socket> SupportedSockedList => _supportedSockedList.ToImmutableList();
    public TDP PowerDissipation => _powerDissipation;

    public CpuCooler Clone => new CpuCooler(this);
}