using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Service.Writers;

public abstract class WriterBase
{
    private string _mode;

    protected WriterBase(string mode)
    {
        if (string.IsNullOrEmpty(mode))
        {
            throw new ArgumentNullException(nameof(mode));
        }

        _mode = mode;
    }

    public string Mode => _mode;

    public abstract void WriteLine(string line);
}