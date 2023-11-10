using System;
using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class Group : IAdressee
{
    private readonly IList<IAdressee> _adressees;

    public Group(IList<IAdressee> adressees)
    {
        _adressees = adressees ?? new List<IAdressee>();

        if (_adressees.Any(adressee => adressee is null))
        {
            throw new ArgumentNullException(nameof(adressees));
        }
    }

    public void SendMessage(Message message)
    {
        if (message is null)
        {
            throw new ArgumentNullException(nameof(message));
        }

        foreach (IAdressee adressee in _adressees)
        {
            adressee.SendMessage(message);
        }
    }
}