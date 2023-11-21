using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Service.Parser;

public interface IParser
{
    public ICommand? Parse(string line);
    void AddParserToChain(CommandParserBase newParser);
}