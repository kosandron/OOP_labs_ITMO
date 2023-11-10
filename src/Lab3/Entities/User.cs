using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class User : IAdressee
{
    private readonly List<ImprovedMessage> _messages;

    public User()
    {
        _messages = new List<ImprovedMessage>();
    }

    public ImmutableList<ImprovedMessage> Messages => _messages.ToImmutableList();

    public void SendMessage(Message message)
    {
        if (message is null)
        {
            throw new ArgumentNullException(nameof(message));
        }

        _messages.Add(new ImprovedMessage(message));
    }

    public void MarkReadMessage(Message message)
    {
        if (message is null)
        {
            throw new ArgumentNullException(nameof(message));
        }

        _messages.FirstOrDefault(x => x.Message == message)?.ChangeReadStatus();
    }

    public bool SendMessageStatus(Message message)
    {
        if (message is null)
        {
            throw new ArgumentNullException(nameof(message));
        }

        return _messages.FirstOrDefault(x => x.Message == message)?.IsRead ?? throw new NotFoundException();
    }
}