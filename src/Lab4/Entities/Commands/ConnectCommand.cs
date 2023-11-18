using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public class ConnectCommand : ICommand
{
    private string _path;
    private string _mode;

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

    public void Execute()
    {
        throw new System.NotImplementedException();
    }
}