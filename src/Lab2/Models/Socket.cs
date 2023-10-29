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
        if (string.IsNullOrEmpty(version))
        {
            throw new ArgumentNullException(nameof(version));
        }

        if (!new SupportedSocket().SocketVersionsList.Any(socket => socket.Equals(version, StringComparison.OrdinalIgnoreCase)))
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