using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

public class NotFoundException : ArgumentNullException
{
    public NotFoundException()
        : base("Object was not found!") { }
    public NotFoundException(string? valueName)
        : base($"{valueName}: object was not found!") { }

    public NotFoundException(string? valueName, Exception? innerException)
        : base($"{valueName}: object was not found!", innerException) { }
}