using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;

public class SupportedFileSystems
{
    private List<IFileSystem> _fileSystems;

    public SupportedFileSystems()
    {
        _fileSystems = new List<IFileSystem>() { new RealFileSystem() };
    }

    public ImmutableList<IFileSystem> FileSystemsList => _fileSystems.ToImmutableList();

    public void AddFileSystem(IFileSystem newFileSystem)
    {
        if (newFileSystem is null)
        {
            throw new ArgumentNullException(nameof(newFileSystem));
        }

        if (!_fileSystems.Any(filesystem => filesystem.Mode.Equals(newFileSystem.Mode, StringComparison.OrdinalIgnoreCase)))
        {
            _fileSystems.Add(newFileSystem);
        }
    }
}