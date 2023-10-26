using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class EmptyCollectionException : ArgumentException
{
    public EmptyCollectionException() { }
    public EmptyCollectionException(string? valueName)
        : base($"{valueName}: collection is empty, but should have some elements!") { }

    public EmptyCollectionException(string? valueName, Exception? innerException)
        : base($"{valueName}: collection is empty, but should have some elements!", innerException) { }
}