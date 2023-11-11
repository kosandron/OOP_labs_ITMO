using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class SupportedSocket
{
    private IList<string> _socketVersions;

    public SupportedSocket()
    {
        _socketVersions = new List<string>() { "AM1", "AM2", "AM3", "AM4", "AM5", "AM6" };
    }

    public ImmutableList<string> SocketVersionsList => _socketVersions.ToImmutableList();

    public void AddVersion(string newVersion)
    {
        if (string.IsNullOrEmpty(newVersion))
        {
            throw new ArgumentNullException(nameof(newVersion));
        }

        if (!_socketVersions.Any(version => version.Equals(newVersion, StringComparison.OrdinalIgnoreCase)))
        {
            _socketVersions.Add(newVersion);
        }
    }
}