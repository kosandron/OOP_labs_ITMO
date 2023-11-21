using System;
using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

public class NotConnectedFileSystemException : IOException
{
    public NotConnectedFileSystemException()
    : base("Filesystem is not connected!") { }
    public NotConnectedFileSystemException(string? valueName)
        : base($"{valueName}: filesystem is not connected!") { }

    public NotConnectedFileSystemException(string? valueName, Exception? innerException)
        : base($"{valueName}: filesystem is not connected!", innerException) { }
}