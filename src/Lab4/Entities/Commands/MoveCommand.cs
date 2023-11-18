using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public class MoveCommand : ICommand
{
    private string _from;
    private string _to;

    public MoveCommand(string from, string to)
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

    public void Execute()
    {
        throw new System.NotImplementedException();
    }
}