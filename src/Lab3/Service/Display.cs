using System;
using System.Drawing;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Service;

public class Display : IDisplay
{
    private readonly DisplayDriver _displayDriver;
    private readonly Color _color;

    public Display(DisplayDriver displayDriver, Color color)
    {
        if (displayDriver is null)
        {
            throw new ArgumentNullException(nameof(displayDriver));
        }

        _displayDriver = displayDriver;
        _color = color;
    }

    public void Write(Message message)
    {
        if (message is null)
        {
            throw new ArgumentNullException(nameof(message));
        }

        _displayDriver.ClearOutput();
        _displayDriver.Print(message, _color);
    }
}