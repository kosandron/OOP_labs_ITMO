using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public class TreeListCommand : ICommand
{
    private readonly int _depth;
    private readonly string _path;
    private readonly string _mode;

    public TreeListCommand(string path, string mode, int depth)
    {
        if (string.IsNullOrEmpty(path))
        {
            throw new ArgumentNullException(nameof(path));
        }

        if (string.IsNullOrEmpty(mode))
        {
            throw new ArgumentNullException(nameof(mode));
        }

        if (depth < 1)
        {
            throw new NegativeValueException("Depth < 1");
        }

        _path = path;
        _mode = mode;
        _depth = depth;
    }

    public TreeListCommand(string path, string mode)
        : this(path, mode, 1) { }

    public string Path => _path;
    public string Mode => _mode;
    public int Depth => _depth;

    public void Execute(FileSystemState fileSystemState)
    {
        if (fileSystemState is null)
        {
            throw new ArgumentNullException(nameof(fileSystemState));
        }

        fileSystemState.TreeList(
            fileSystemState.FileSystem.GetAbsolutePath(fileSystemState.CurrentPath(), _path),
            _mode,
            _depth);
    }
}