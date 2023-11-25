using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

public class FlagErrorException : ArgumentException
{
    public FlagErrorException()
    : base("Some flags are not presented/have error!") { }
    public FlagErrorException(string? valueName)
        : base($"{valueName}: flag is not valid/not presented!") { }

    public FlagErrorException(string? valueName, Exception? innerException)
        : base($"{valueName}: flag is not valid/not presented!", innerException) { }
}