using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public class ShowCommand : ICommand
{
    private readonly string _path;
    private readonly string _mode;

    public ShowCommand(string path, string mode)
    {
        if (string.IsNullOrEmpty(path))
        {
            throw new ArgumentNullException(nameof(path));
        }

        if (string.IsNullOrEmpty(mode))
        {
            throw new ArgumentNullException(nameof(mode));
        }

        _path = path;
        _mode = mode;
    }

    public ShowCommand(string path)
        : this(path, "local")
    {
    }

    public string Path => _path;
    public string Mode => _mode;

    public void Execute(FileSystemState fileSystemState)
    {
        if (fileSystemState is null)
        {
            throw new ArgumentNullException(nameof(fileSystemState));
        }

        fileSystemState.Show(
            fileSystemState.FileSystem.GetAbsolutePath(fileSystemState.CurrentPath(), _path),
            _mode);
    }
}