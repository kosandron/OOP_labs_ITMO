using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Parser;

public class DisconnectCommandParser : CommandParserBase
{
    public override ICommand? TryParse(string data)
    {
        if (string.IsNullOrEmpty(data))
        {
            return null;
        }

        if (data.Equals("disconnect", System.StringComparison.Ordinal))
        {
            return new DisconnectCommand();
        }
        else
        {
            return ParseNext(data);
        }
    }
}