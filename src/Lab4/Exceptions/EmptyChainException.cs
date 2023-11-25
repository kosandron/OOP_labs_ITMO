using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

public class EmptyChainException : ArgumentNullException
{
    public EmptyChainException()
    : base("Chain is empty") { }
    public EmptyChainException(string? valueName)
        : base($"{valueName}: chain is empty!") { }

    public EmptyChainException(string? valueName, Exception? innerException)
        : base($"{valueName}: chain is empty", innerException) { }
}