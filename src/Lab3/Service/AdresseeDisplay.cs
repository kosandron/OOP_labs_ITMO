using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Service;

public class AdresseeDisplay
{
    private readonly Display _display;

    public AdresseeDisplay(Display display)
    {
        if (display is null)
        {
            throw new ArgumentNullException(nameof(display));
        }

        _display = display;
    }

    public void SendMessage(Message message)
    {
        if (message is null)
        {
            throw new ArgumentNullException(nameof(message));
        }

        _display.Write(message);
    }
}