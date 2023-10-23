using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using Itmo.ObjectOrientedProgramming.Lab1.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Bios
{
    private string _type;
    private string _version;
    private IList<string> _supportedCpuList;

    public Bios(string type, string version, IList<string> supportedCpuList)
    {
        if (supportedCpuList == null)
        {
            throw new ArgumentNullException(nameof(supportedCpuList));
        }

        if (supportedCpuList.Count == 0)
        {
            throw new NegativeValueException("There are no one supported CPU!");
        }

        _type = type;
        _version = version;
        _supportedCpuList = supportedCpuList;
    }

    public string Type => _type;
    public string Version => _version;
    public ImmutableList<string> SupportedCpuList => _supportedCpuList.ToImmutableList();
}