using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class Socket : ICopyable<Socket>
{
    private string _version;

    public Socket(string version)
    {
        if (version is null)
        {
            throw new ArgumentNullException(nameof(version));
        }

        if (!new SupportedSocket().ComponentList.Any(socketVersion => socketVersion.Equals(version, StringComparison.OrdinalIgnoreCase)))
        {
            throw new ArgumentException("This socket has not ever exist!");
        }

        _version = version;
    }

    public string Version => _version;
    public Socket DeepCopy()
    {
        return new Socket(Version);
    }
}