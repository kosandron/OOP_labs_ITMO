using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class Group : IAdressee
{
    private readonly string _name;
    private readonly IList<IAdressee> _adressees;
    private readonly IList<Message> _messages;

    public Group(string name, IList<IAdressee> adressees)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentNullException(nameof(name));
        }

        _name = name;
        _adressees = adressees ?? new List<IAdressee>();
        _messages = new List<Message>();

        if (_adressees.Any(adressee => adressee is null))
        {
            throw new ArgumentNullException(nameof(adressees));
        }
    }

    public string Name => _name;
    public ImmutableList<Message> Messages => _messages.ToImmutableList();

    public void SendMessage(Message message)
    {
        if (message is null)
        {
            throw new ArgumentNullException(nameof(message));
        }

        _messages.Add(message);
        foreach (IAdressee adressee in _adressees)
        {
            adressee.SendMessage(message);
        }
    }
}