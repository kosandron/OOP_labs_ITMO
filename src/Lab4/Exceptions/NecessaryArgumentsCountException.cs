using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

public class NecessaryArgumentsCountException : ArgumentException
{
    public NecessaryArgumentsCountException()
        : base("Not all necessary are arguments in line!") { }
    public NecessaryArgumentsCountException(string? valueName)
        : base($"{valueName}: not all necessary are arguments in line!") { }

    public NecessaryArgumentsCountException(string? valueName, Exception? innerException)
        : base($"{valueName}: not all necessary are arguments in line!", innerException) { }
}