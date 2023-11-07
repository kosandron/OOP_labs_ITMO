using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class Topic
{
    private string _name;
    private IAdressee _adressee;

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
}