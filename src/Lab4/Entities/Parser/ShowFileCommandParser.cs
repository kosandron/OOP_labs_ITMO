using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Parser;

public class ShowFileCommandParser : CommandParserBase
{
    public override ICommand? TryParse(string data)
    {
        if (string.IsNullOrEmpty(data))
        {
            return null;
        }

        string[] words = data.Split();

        if (!data.StartsWith("file show", StringComparison.Ordinal))
        {
            return ParseNext(data);
        }

        if (!(words.Length == 3 || words.Length == 5))
        {
            throw new NessesaryArgumentsCountException();
        }

        if (words.Length == 5)
        {
            if (words[3].Equals("-d", StringComparison.Ordinal))
            {
                return new ShowCommand(words[2], words[4]);
            }

            throw new FlagErrorException();
        }

        return new ShowCommand(words[2]);
    }
}