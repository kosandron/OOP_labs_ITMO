using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Interfaces;

public class AdreseeMessanger : IAdressee
{
    private readonly IMessanger _messanger;

    public AdreseeMessanger(IMessanger messanger)
    {
        if (messanger is null)
        {
            throw new ArgumentNullException(nameof(messanger));
        }

        _messanger = messanger;
    }

    public void SendMessage(Message message)
    {
        if (message is null)
        {
            throw new ArgumentNullException(nameof(message));
        }

        _messanger.WriteMessage(message);
    }
}