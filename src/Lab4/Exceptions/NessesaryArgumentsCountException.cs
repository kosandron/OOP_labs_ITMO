using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

public class NessesaryArgumentsCountException : ArgumentException
{
    public NessesaryArgumentsCountException() { }
    public NessesaryArgumentsCountException(string? valueName)
        : base($"{valueName}: not all nessasary are arguments in line!") { }

    public NessesaryArgumentsCountException(string? valueName, Exception? innerException)
        : base($"{valueName}: not all nessasary are arguments in line!", innerException) { }
}