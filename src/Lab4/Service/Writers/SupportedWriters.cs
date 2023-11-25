using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab4.Service.Writers;

public class SupportedWriters
{
    private List<WriterBase> _writers;

    public SupportedWriters()
    {
        _writers = new List<WriterBase>() { new ConsoleWriter(), new FileWriter() };
    }

    public ImmutableList<WriterBase> WritersList => _writers.ToImmutableList();

    public void AddComponent(WriterBase newWriter)
    {
        if (newWriter is null)
        {
            throw new ArgumentNullException(nameof(newWriter));
        }

        if (!_writers.Any(writer => writer.Mode.Equals(newWriter.Mode, StringComparison.OrdinalIgnoreCase)))
        {
            _writers.Add(newWriter);
        }
    }
}