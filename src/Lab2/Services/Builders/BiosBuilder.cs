using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;

public class BiosBuilder : IBiosBuilder
{
    private string? _name;
    private string? _type;
    private string? _version;
    private IList<string>? _supportedCpuList;

    public BiosBuilder() { }
    public BiosBuilder(Bios otherBios)
    {
        if (otherBios == null)
        {
            throw new ArgumentNullException(nameof(otherBios));
        }

        _name = otherBios.Name;
        _version = otherBios.Version;
        _type = otherBios.Type;
        _supportedCpuList = otherBios.SupportedCpuList;
    }

    public IBiosBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public IBiosBuilder WithType(string type)
    {
        _type = type;
        return this;
    }

    public IBiosBuilder WithVersion(string version)
    {
        _version = version;
        return this;
    }

    public IBiosBuilder WithSupportedCpuList(IList<string> supportedCpuList)
    {
        _supportedCpuList = supportedCpuList;
        return this;
    }

    public Bios Build()
    {
        if (_name == null)
        {
            throw new ArgumentNullException(nameof(_name));
        }

        if (_type == null)
        {
            throw new ArgumentNullException(nameof(_type));
        }

        if (_version == null)
        {
            throw new ArgumentNullException(nameof(_version));
        }

        if (_supportedCpuList == null)
        {
            throw new ArgumentNullException(nameof(_supportedCpuList));
        }

        return new Bios(_name, _type, _version, _supportedCpuList);
    }
}