using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public class ShowCommand : ICommand
{
    private string _path;
    private string _mode;

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

    public void Execute()
    {
        throw new System.NotImplementedException();
    }
}