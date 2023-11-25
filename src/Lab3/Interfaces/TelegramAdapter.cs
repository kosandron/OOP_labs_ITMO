using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Interfaces;

public class TelegramAdapter : IMessanger
{
    private readonly ITelegram _messenger;

    public TelegramAdapter(ITelegram messenger)
    {
        if (messenger is null)
        {
            throw new ArgumentNullException(nameof(messenger));
        }

        _messenger = messenger;
    }

    public void WriteMessage(Message message)
    {
        if (message is null)
        {
            throw new ArgumentNullException(nameof(message));
        }

        _messenger.SendMessage("1f31g3h4j12j", 12345, message.BuildMessage());
    }
}