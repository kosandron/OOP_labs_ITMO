using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public class RenameCommand : ICommand
{
    private readonly string _path;
    private readonly string _name;

    public RenameCommand(string path, string name)
    {
        if (string.IsNullOrEmpty(path))
        {
            throw new ArgumentNullException(nameof(path));
        }

        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentNullException(nameof(name));
        }

        _path = path;
        _name = name;
    }

    public string Path => _path;
    public string NewName => _name;

    public void Execute(FileSystemState fileSystemState)
    {
        if (fileSystemState is null)
        {
            throw new ArgumentNullException(nameof(fileSystemState));
        }

        fileSystemState.FileSystem.Rename(
            fileSystemState.FileSystem.GetAbsolutePath(fileSystemState.CurrentPath(), _path),
            _name);
    }
}