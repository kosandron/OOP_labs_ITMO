using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Exceptions;

public class JustReadException : Exception
{
    public JustReadException() { }
    public JustReadException(string? valueName)
        : base($"{valueName}: message was read!") { }

    public JustReadException(string? valueName, Exception? innerException)
        : base($"{valueName}: message was read!", innerException) { }
}