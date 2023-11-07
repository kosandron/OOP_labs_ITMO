using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Exceptions;

public class NotFoundException : ArgumentException
{
    public NotFoundException() { }
    public NotFoundException(string? valueName)
        : base($"{valueName}: element is not found!") { }

    public NotFoundException(string? valueName, Exception? innerException)
        : base($"{valueName}: element is not found!", innerException) { }
}