using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public class DeleteCommand : ICommand
{
    private string _path;

    public DeleteCommand(string path)
    {
        if (string.IsNullOrEmpty(path))
        {
            throw new ArgumentNullException(nameof(path));
        }

        _path = path;
    }

    public void Execute()
    {
        throw new System.NotImplementedException();
    }
}