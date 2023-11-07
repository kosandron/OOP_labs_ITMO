using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class AdresseeProxy : IAdresseeProxy
{
    private IAdressee _adressee;

    public AdresseeProxy(IAdressee adressee)
    {
        if (adressee is null)
        {
            throw new ArgumentNullException(nameof(adressee));
        }

        _adressee = adressee;
    }

    public bool IsValidMessage(Message message, int minRating)
    {
        if (message is null)
        {
            throw new ArgumentNullException(nameof(message));
        }

        if (minRating < 0)
        {
            throw new NegativeValueException(nameof(minRating));
        }

        return message.Rating >= minRating;
    }

    public IEnumerable<Message> FilterByRating(IEnumerable<Message> messages, int minRating)
    {
        if (messages is null)
        {
            throw new ArgumentNullException(nameof(messages));
        }

        if (messages.Any(message => message is null))
        {
            throw new ArgumentNullException(nameof(messages));
        }

        if (minRating < 0)
        {
            throw new NegativeValueException(nameof(minRating));
        }

        return messages.Where(message => IsValidMessage(message, minRating));
    }

    public void TrySendMessage(Message message, int minRating)
    {
        if (IsValidMessage(message, minRating))
        {
            _adressee.GetMessage(message);
        }
    }
}