using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public class ConnectCommand : ICommand
{
    private readonly string _path;
    private readonly string _mode;

    public ConnectCommand(string path, string mode)
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

    public ConnectCommand(string path)
        : this(path, "local")
    {
    }

    public string Mode => _mode;
    public string Path => _path;

    public void Execute(FileSystemState fileSystemState)
    {
        if (fileSystemState is null)
        {
            throw new ArgumentNullException(nameof(fileSystemState));
        }

        fileSystemState.Connect(_mode, _path);
    }
}