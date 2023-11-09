using System;
using System.Drawing;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Service;

public class Display : IDisplay
{
    private readonly DisplayDriver _displayDriver;

    public Display(DisplayDriver displayDriver)
    {
        if (displayDriver is null)
        {
            throw new ArgumentNullException(nameof(displayDriver));
        }

        _displayDriver = displayDriver;
    }

    public void ClearOutput()
    {
        _displayDriver.ClearOutput();
    }

    public void SetColor(Color color)
    {
        _displayDriver.SetColor(color);
    }

    public void Print(Message message)
    {
        if (message is null)
        {
            throw new ArgumentNullException(nameof(message));
        }

        ClearOutput();
        _displayDriver.Print(message);
    }
}