using System;
using System.Globalization;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Parser;

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

        if (!(words.Length == 2 || words.Length == 4))
        {
            throw new NessesaryArgumentsCountException();
        }

        if (words.Length == 4)
        {
            if (words[2].Equals("-d", StringComparison.Ordinal))
            {
                return new TreeListCommand(int.Parse(words[3], NumberStyles.Integer, new NumberFormatInfo()));
            }
            else
            {
                throw new FlagErrorException();
            }
        }

        return new TreeListCommand();
    }
}