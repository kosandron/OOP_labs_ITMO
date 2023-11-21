using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public class CopyCommand : ICommand
{
    private readonly string _from;
    private readonly string _to;

    public CopyCommand(string from, string to)
    {
        if (string.IsNullOrEmpty(from))
        {
            throw new ArgumentNullException(nameof(from));
        }

        if (string.IsNullOrEmpty(to))
        {
            throw new ArgumentNullException(nameof(to));
        }

        _from = from;
        _to = to;
    }

    public string FromPath => _from;
    public string ToPath => _to;

    public void Execute(FileSystemState fileSystemState)
    {
        if (fileSystemState is null)
        {
            throw new ArgumentNullException(nameof(fileSystemState));
        }

        fileSystemState.FileSystem
            .Copy(
                fileSystemState.FileSystem.GetAbsolutePath(fileSystemState.CurrentPath(), _from),
                fileSystemState.FileSystem.GetAbsolutePath(fileSystemState.CurrentPath(), _to));
    }
}