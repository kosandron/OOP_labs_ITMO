using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Parser;

public class DeleteCommandParser : CommandParserBase
{
    public override ICommand? TryParse(string data)
    {
        if (string.IsNullOrEmpty(data))
        {
            return null;
        }

        string[] words = data.Split();

        if (words.Length != 3 || !data.StartsWith("file delete", StringComparison.Ordinal))
        {
            return ParseNext(data);
        }

        return new DeleteCommand(words[2]);
    }
}