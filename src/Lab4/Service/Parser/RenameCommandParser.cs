using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Service.Parser;

public class RenameCommandParser : CommandParserBase
{
    public override ICommand? TryParse(string data)
    {
        if (string.IsNullOrEmpty(data))
        {
            return null;
        }

        string[] words = data.Split();

        if (words.Length != 4 || !data.StartsWith("file rename", StringComparison.Ordinal))
        {
            return ParseNext(data);
        }

        return new RenameCommand(words[2], words[3]);
    }
}