using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

public class NegativeValueException : ArgumentException
{
    public NegativeValueException()
        : base("Value is less than minimal valid value!") { }
    public NegativeValueException(string? valueName)
        : base($"{valueName}: value is less than minimal valid value!") { }

    public NegativeValueException(string? valueName, Exception? innerException)
        : base($"{valueName}: value is less than minimal valid value!", innerException) { }
}