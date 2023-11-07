using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class User : IAdressee
{
    private string _name;
    private List<ImprovedMessage> _messages;

    public User(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentNullException(nameof(name));
        }

        _name = name;
        _messages = new List<ImprovedMessage>();
    }

    public string Name => _name;

    public void GetMessage(Message message)
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

    public bool GetMessageStatus(Message message)
    {
        if (message is null)
        {
            throw new ArgumentNullException(nameof(message));
        }

        return _messages.FirstOrDefault(x => x.Message == message)?.IsRead ?? throw new NotFoundException();
    }
}