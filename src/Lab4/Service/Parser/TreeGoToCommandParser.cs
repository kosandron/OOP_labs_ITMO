using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Service.Parser;

public class TreeGoToCommandParser : CommandParserBase
{
    public override ICommand? TryParse(string data)
    {
        if (string.IsNullOrEmpty(data))
        {
            return null;
        }

        string[] words = data.Split();

        if (words.Length != 3 || !data.StartsWith("tree goto", StringComparison.Ordinal))
        {
            return ParseNext(data);
        }

        return new GoToCommand(words[2]);
    }
}