namespace Itmo.ObjectOrientedProgramming.Lab3.Interfaces;

public interface ITelegram
{
    void SendMessage(string apiKey, long userId, string message);
}