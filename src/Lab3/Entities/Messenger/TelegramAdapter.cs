using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Messenger;

public class TelegramAdapter : IAdressee
{
    private readonly Telegram _messenger;

    public TelegramAdapter(Telegram messenger)
    {
        if (messenger is null)
        {
            throw new ArgumentNullException(nameof(messenger));
        }

        _messenger = messenger;
    }

    public void GetMessage(Message message)
    {
        if (message is null)
        {
            throw new ArgumentNullException(nameof(message));
        }

        _messenger.SendMessage("1f31g3h4j12j", 12345, message.BuildMessage());
    }
}