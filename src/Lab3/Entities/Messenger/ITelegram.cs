namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Messenger;

public interface ITelegram
{
    void SendMessage(string apiKey, long userId, string message);
}