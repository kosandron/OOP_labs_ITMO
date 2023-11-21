using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Service.Parser;

public class ConnectCommandParser : CommandParserBase
{
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
            throw new NecessaryArgumentsCountException();
        }

        if (words.Length == 4)
        {
            if (!words[2].Equals("-m", StringComparison.Ordinal))
            {
                throw new FlagErrorException("ModeFlag");
            }

            if (!new SupportedFileSystems().FileSystemsList.Any(filSystem =>
                    filSystem.Mode.Equals(words[3], StringComparison.Ordinal)))
            {
                throw new NotFoundException($"Filesystem {words[2]}");
            }

            return new ConnectCommand(words[1], words[3]);
        }

        return new ConnectCommand(words[1]);
    }
}