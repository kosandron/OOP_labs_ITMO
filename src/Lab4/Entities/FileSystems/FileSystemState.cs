using System;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;

public class FileSystemState
{
    private IFileSystem _fileSystem;
    private string? _currentPath;

    public FileSystemState()
    {
        _fileSystem = new NotConnectedFileSystem();
    }

    public IFileSystem FileSystem => _fileSystem;

    public string CurrentPath()
    {
        if (_currentPath is null)
        {
            throw new NotConnectedFileSystemException();
        }

        return _currentPath;
    }

    public void Connect(string mode, string path)
    {
        if (string.IsNullOrEmpty(mode))
        {
            throw new ArgumentNullException(nameof(mode));
        }

        if (string.IsNullOrEmpty(path))
        {
            throw new ArgumentNullException(nameof(path));
        }

        IFileSystem? fileSystem = new FileSystemFactory().CreateByMode(mode);
        if (fileSystem is null)
        {
            throw new NotFoundException($"Filesystem {mode}");
        }

        if (!fileSystem.IsAbsolutePath(path))
        {
            throw new ArgumentException("Path is not absolute!");
        }

        _fileSystem = fileSystem;
        _currentPath = path;
    }

    public void Disconnect()
    {
        _fileSystem = new NotConnectedFileSystem();
    }

    public void GoToCommand(string path)
    {
        if (string.IsNullOrEmpty(path))
        {
            throw new ArgumentNullException(nameof(path));
        }

        _currentPath = path;
    }
}