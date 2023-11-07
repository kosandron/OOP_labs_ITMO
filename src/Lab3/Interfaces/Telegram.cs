using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Interfaces;

public class Telegram : ITelegram
{
    public void SendMessage(string apiKey, long userId, string message)
    {
        Console.WriteLine("[Telegram] " + message);
    }
}