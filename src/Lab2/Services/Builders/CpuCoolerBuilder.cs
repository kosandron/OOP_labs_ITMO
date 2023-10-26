using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;

public class CpuCoolerBuilder
{
    private string? _name;
    private int _size = -1;
    private IList<Socket>? _supportedSockedList;
    private TDP? _powerDissipation;

    public CpuCoolerBuilder() { }

    public CpuCoolerBuilder(CpuCooler otherCpuCooler)
    {
        if (otherCpuCooler == null)
        {
            throw new ArgumentNullException(nameof(otherCpuCooler));
        }

        _name = otherCpuCooler.Name;
        _size = otherCpuCooler.Size;
        _supportedSockedList = new List<Socket>(otherCpuCooler.SupportedSockedList);
        _powerDissipation = otherCpuCooler.PowerDissipation;
    }

    public CpuCoolerBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public CpuCoolerBuilder WithSize(int size)
    {
        _size = size;
        return this;
    }

    public CpuCoolerBuilder WithSupportedSockedList(IList<Socket> list)
    {
        _supportedSockedList = list;
        return this;
    }

    public CpuCoolerBuilder WithPowerDissipation(TDP powerDissipation)
    {
        _powerDissipation = powerDissipation;
        return this;
    }

    public CpuCooler Build()
    {
        return new CpuCooler(_name, _size, _supportedSockedList, _powerDissipation);
    }
}