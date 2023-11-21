using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;

public class FileSystemFactory
{
    private readonly ICollection<IFileSystem> _fileSystems;

    public FileSystemFactory()
    {
        _fileSystems = new Collection<IFileSystem>() { new RealFileSystem.RealFileSystem() };
    }

    public FileSystemFactory(ICollection<IFileSystem> fileSystems)
    {
        _fileSystems = fileSystems ?? new List<IFileSystem>();
        if (_fileSystems.Any(fileSystem => fileSystem is null))
        {
            throw new ArgumentNullException(nameof(fileSystems));
        }
    }

    public IFileSystem? CreateByMode(string mode)
    {
        return _fileSystems.FirstOrDefault(fileSystem => fileSystem.Mode.Equals(mode, StringComparison.OrdinalIgnoreCase));
    }
}