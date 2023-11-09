using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Interfaces;

public class AdreseeMessanger : IAdressee
{
    private readonly IMessanger _messanger;
    private readonly List<Message> _messages;

    public AdreseeMessanger(IMessanger messanger)
    {
        if (messanger is null)
        {
            throw new ArgumentNullException(nameof(messanger));
        }

        _messanger = messanger;
        _messages = new List<Message>();
    }

    public IMessanger Messanger => _messanger;
    public ImmutableList<Message> Messages => _messages.ToImmutableList();

    public void SendMessage(Message message)
    {
        if (message is null)
        {
            throw new ArgumentNullException(nameof(message));
        }

        _messages.Add(message);
        _messanger.WriteMessage(message);
    }
}