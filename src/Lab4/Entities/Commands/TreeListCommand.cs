using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public class TreeListCommand : ICommand
{
    private int _depth;

    public TreeListCommand()
        : this(1) { }
    public TreeListCommand(int depth)
    {
        if (depth < 1)
        {
            throw new NegativeValueException(nameof(depth));
        }

        _depth = depth;
    }

    public void Execute()
    {
        throw new System.NotImplementedException();
    }
}