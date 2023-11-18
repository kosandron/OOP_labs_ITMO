using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public class RenameCommand : ICommand
{
    private string _path;
    private string _name;

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

    public void Execute()
    {
        throw new System.NotImplementedException();
    }
}