using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Parser;

public class MoveCommandParser : CommandParserBase
{
    public override ICommand? TryParse(string data)
    {
        if (string.IsNullOrEmpty(data))
        {
            return null;
        }

        string[] words = data.Split();

        if (words.Length != 4 || !data.StartsWith("file move", StringComparison.Ordinal))
        {
            return ParseNext(data);
        }

        return new MoveCommand(words[2], words[3]);
    }
}