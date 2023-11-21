using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Service.Parser;

public class CopyCommandParser : CommandParserBase
{
    public override ICommand? TryParse(string data)
    {
        if (string.IsNullOrEmpty(data))
        {
            return null;
        }

        string[] words = data.Split();

        if (words.Length != 4 || !data.StartsWith("file copy", StringComparison.Ordinal))
        {
            return ParseNext(data);
        }

        return new CopyCommand(words[2], words[3]);
    }
}