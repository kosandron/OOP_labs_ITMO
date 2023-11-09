using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class Topic
{
    private readonly string _name;
    private readonly IAdressee _adressee;

    public Topic(string name, IAdressee adressee)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentNullException(nameof(name));
        }

        if (adressee is null)
        {
            throw new ArgumentNullException(nameof(adressee));
        }

        _name = name;
        _adressee = adressee;
    }

    public string Name => _name;
    public IAdressee Adressee => _adressee;

    public void SendMessage(Message message)
    {
        if (message is null)
        {
            throw new ArgumentNullException(nameof(message));
        }

        _adressee.SendMessage(message);
    }
}