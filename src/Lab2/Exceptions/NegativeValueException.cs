using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class NegativeValueException : ArgumentException
{
    public NegativeValueException() { }
    public NegativeValueException(string? valueName)
        : base($"{valueName}: value is less than 0!") { }

    public NegativeValueException(string? valueName, Exception? innerException)
        : base($"{valueName}: value is less than 0!", innerException) { }
}