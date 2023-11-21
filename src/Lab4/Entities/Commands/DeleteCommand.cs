using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public class DeleteCommand : ICommand
{
    private readonly string _path;

    public DeleteCommand(string path)
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

        fileSystemState.FileSystem.Delete(
            fileSystemState.FileSystem.GetAbsolutePath(fileSystemState.CurrentPath(), _path));
    }
}