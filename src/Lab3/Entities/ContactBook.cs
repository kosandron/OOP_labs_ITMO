using System;
using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class ContactBook
{
    private ICollection<Topic> _contacts;

    public ContactBook(ICollection<Topic> contacts)
    {
        _contacts = contacts ?? new List<Topic>();
        if (_contacts.Any(topic => topic is null))
        {
            throw new ArgumentNullException(nameof(contacts));
        }
    }

    public Topic? FindByName(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentNullException(nameof(name));
        }

        return _contacts.FirstOrDefault(contact => contact.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }

    public void SendMessageByName(string name, Message message)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentNullException(nameof(name));
        }

        if (message is null)
        {
            throw new ArgumentNullException(nameof(message));
        }

        FindByName(name)?.SendMessage(message);
    }
}