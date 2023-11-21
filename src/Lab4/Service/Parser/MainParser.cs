using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Service.Parser;

public class MainParser : IParser
{
    private CommandParserBase _firstChain;
    private CommandParserBase _lastChain;

    public MainParser()
        : this(new List<CommandParserBase>()
    {
        new ConnectCommandParser(),
        new DisconnectCommandParser(),
        new CopyCommandParser(),
        new MoveCommandParser(),
        new DeleteCommandParser(),
        new RenameCommandParser(),
        new ShowFileCommandParser(),
        new TreeListCommandParser(),
        new TreeGoToCommandParser(),
    }) { }
    public MainParser(IList<CommandParserBase> parsers)
    {
        if (parsers is null || parsers.Count == 0)
        {
            throw new EmptyChainException("Parser command chain");
        }

        if (parsers.Any(parser => parser is null))
        {
            throw new ArgumentNullException(nameof(parsers));
        }

        CommandParserBase head = parsers.First();
        for (int i = 1; i < parsers.Count; i++)
        {
            head.SetNext(parsers[i]);
            head = parsers[i];
        }

        _firstChain = parsers.First();
        _lastChain = parsers.Last();
    }

    public void AddParserToChain(CommandParserBase newParser)
    {
        if (newParser is null)
        {
            throw new ArgumentNullException(nameof(newParser));
        }

        _lastChain.SetNext(newParser);
        _lastChain = newParser;
    }

    public ICommand? Parse(string line)
    {
        return _firstChain.TryParse(line);
    }
}