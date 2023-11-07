using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class Logger : ILogger
{
    public void Log(Message message)
    {
        if (message is null)
        {
            throw new ArgumentNullException(nameof(message));
        }

        Console.WriteLine($"[Logger] {message.Header} received.");
    }
}