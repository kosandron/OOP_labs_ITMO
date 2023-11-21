using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab4.Service.Writers;

public class WriterFactory
{
    private readonly ICollection<WriterBase> _writers;

    public WriterFactory()
    {
        _writers = new Collection<WriterBase>() { new ConsoleWriter(), new FileWriter() };
    }

    public WriterFactory(ICollection<WriterBase> components)
    {
        _writers = components;
    }

    public WriterBase? CreateByMode(string mode)
    {
        return _writers.FirstOrDefault(component => component.Mode.Equals(mode, StringComparison.OrdinalIgnoreCase));
    }
}