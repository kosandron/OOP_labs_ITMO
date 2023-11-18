using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

public class FlagErrorException : ArgumentException
{
    public FlagErrorException() { }
    public FlagErrorException(string? valueName)
        : base($"{valueName}: flag is not valid!") { }

    public FlagErrorException(string? valueName, Exception? innerException)
        : base($"{valueName}: flag is not valid!", innerException) { }
}