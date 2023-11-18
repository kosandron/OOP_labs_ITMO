using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Parser;

public class ConnectParser : CommandParserBase
{
    private List<string> _modes;

    public ConnectParser()
    {
        _modes = new List<string>() { "local" };
    }

    public override ICommand? TryParse(string data)
    {
        if (string.IsNullOrEmpty(data))
        {
            return null;
        }

        string[] words = data.Split();

        if (!data.StartsWith("connect", StringComparison.Ordinal))
        {
            return ParseNext(data);
        }

        if (!(words.Length == 2 || words.Length == 4))
        {
            throw new NessesaryArgumentsCountException();
        }

        if (words.Length == 4)
        {
            if (words[2].Equals("-m", StringComparison.Ordinal))
            {
                return new ConnectCommand(words[1], words[3]);
            }
            else
            {
                throw new FlagErrorException();
            }
        }

        return new ConnectCommand(words[1]);
    }

    public void AddMode(string mode)
    {
        if (string.IsNullOrEmpty(mode))
        {
            throw new ArgumentNullException(nameof(mode));
        }

        _modes.Add(mode);
    }
}