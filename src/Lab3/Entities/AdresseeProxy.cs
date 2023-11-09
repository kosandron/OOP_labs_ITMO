using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class AdresseeProxy : IAdressee
{
    private readonly int _minRating = 100;
    private IAdressee _adressee;

    public AdresseeProxy(IAdressee adressee)
    {
        if (adressee is null)
        {
            throw new ArgumentNullException(nameof(adressee));
        }

        _adressee = adressee;
    }

    public bool IsValidMessage(Message message)
    {
        if (message is null)
        {
            throw new ArgumentNullException(nameof(message));
        }

        return message.Rating >= _minRating;
    }

    public void SendMessage(Message message)
    {
        if (IsValidMessage(message))
        {
            _adressee.SendMessage(message);
        }
    }
}