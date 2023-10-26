using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Services.ComputerValidator;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Bios : IComponent, ICloneable<Bios>, ICopyable<Bios>
{
    private string _type;
    private string _version;
    private IList<string> _supportedCpuList;

    public Bios(string? name, string? type, string? version, IList<string>? supportedCpuList)
    {
        if (name is null)
        {
            throw new ArgumentNullException(nameof(name));
        }

        if (type is null)
        {
            throw new ArgumentNullException(nameof(type));
        }

        if (version is null)
        {
            throw new ArgumentNullException(nameof(version));
        }

        if (supportedCpuList?.Count == 0)
        {
            throw new EmptyCollectionException("There are no one supported CPU!");
        }

        var notSupportedCpuValidator = new NotSupportedCpu();
        notSupportedCpuValidator.Validate(supportedCpuList);

        Name = name;
        _type = type;
        _version = version;
        _supportedCpuList = supportedCpuList ?? throw new ArgumentNullException(nameof(supportedCpuList));
    }

    private Bios(Bios other)
    {
        if (other == null)
        {
            throw new ArgumentNullException(nameof(other));
        }

        Name = other.Name;
        _type = other._type;
        _version = other._version;
        _supportedCpuList = other._supportedCpuList;
    }

    public string Name { get; init; }
    public string Type => _type;
    public string Version => _version;
    public ImmutableList<string> SupportedCpuList => _supportedCpuList.ToImmutableList();
    public Bios Clone() => new Bios(this);

    public Bios DeepCopy()
    {
        return new Bios(Name, Type, Version, new List<string>(_supportedCpuList));
    }
}