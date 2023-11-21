using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Service.Parser;

public abstract class CommandParserBase
{
    private CommandParserBase? _next;

    public abstract ICommand? TryParse(string data);

    public void SetNext(CommandParserBase? next)
    {
        _next = next;
    }

    protected ICommand? ParseNext(string data)
    {
        if (_next is null)
        {
            return null;
        }

        return _next.TryParse(data);
    }
}