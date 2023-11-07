using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Messenger;

public class Telegram : ITelegram
{
    public void SendMessage(string apiKey, long userId, string message)
    {
        Console.WriteLine("[Telegram] " + message);
    }
}