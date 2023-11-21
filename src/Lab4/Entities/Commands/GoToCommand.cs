using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public class GoToCommand : ICommand
{
    private readonly string _path;

    public GoToCommand(string path)
    {
        if (string.IsNullOrEmpty(path))
        {
            throw new ArgumentNullException(nameof(path));
        }

        _path = path;
    }

    public string Path => _path;

    public void Execute(FileSystemState fileSystemState)
    {
        if (fileSystemState is null)
        {
            throw new ArgumentNullException(nameof(fileSystemState));
        }

        fileSystemState.GoToCommand(fileSystemState.FileSystem.GetAbsolutePath(fileSystemState.CurrentPath(), _path));
    }
}