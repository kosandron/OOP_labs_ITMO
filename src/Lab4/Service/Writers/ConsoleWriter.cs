using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Service.Writers;

public class ConsoleWriter : WriterBase
{
    public ConsoleWriter()
        : base("console")
    {
    }

    public override void WriteLine(string line)
    {
        Console.WriteLine(line);
    }
}