using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

public class EmptyChainException : NullReferenceException
{
    public EmptyChainException() { }
    public EmptyChainException(string? valueName)
        : base($"{valueName}: chain is empty!") { }

    public EmptyChainException(string? valueName, Exception? innerException)
        : base($"{valueName}: chain is empty", innerException) { }
}