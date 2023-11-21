using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Service.Writers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Service.Parser;

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
            throw new NecessaryArgumentsCountException();
        }

        if (words.Length == 5)
        {
            if (!words[3].Equals("-m", StringComparison.Ordinal))
            {
                throw new FlagErrorException("ModeFlag");
            }

            if (!new SupportedWriters().WritersList.Any(
                    writer => writer.Mode.Equals(words[4], StringComparison.Ordinal)))
            {
                throw new NotFoundException($"Writer {words[2]}");
            }

            return new ShowCommand(words[2], words[4]);
        }

        return new ShowCommand(words[2]);
    }
}