using System;
using System.Globalization;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Service.Parser;

public class TreeListCommandParser : CommandParserBase
{
    public override ICommand? TryParse(string data)
    {
        if (string.IsNullOrEmpty(data))
        {
            return null;
        }

        string[] words = data.Split();

        if (!data.StartsWith("tree list", StringComparison.Ordinal))
        {
            return ParseNext(data);
        }

        string previousWord = string.Empty;
        int depth = 1;
        string? mode = null;
        if (words.Length < 3)
        {
            throw new NecessaryArgumentsCountException();
        }

        string path = words[2];
        for (int i = 3; i < words.Length; i++)
        {
            if (words[i].StartsWith("-", StringComparison.Ordinal))
            {
                previousWord = words[i];
                continue;
            }

            switch (previousWord)
            {
                case "-d":
                    depth = int.Parse(words[i], NumberStyles.Integer, new NumberFormatInfo());
                    break;
                case "-m":
                    mode = words[i];
                    break;
                default:
                    throw new FlagErrorException();
            }
        }

        if (depth < 1)
        {
            throw new NegativeValueException("Depth < 1");
        }

        if (mode is null)
        {
            throw new NecessaryArgumentsCountException("Mode");
        }

        return new TreeListCommand(path, mode, depth);
    }
}