﻿using System;
using System.Drawing;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Service;

public class DisplayDriver : IDisplay
{
    private Color _color;
    public void ClearOutput()
    {
        try
        {
            Console.Clear();
            Console.ResetColor();
        }
        catch (System.IO.IOException)
        {
        }
    }

    public void SetColor(Color color)
    {
        _color = color;
    }

    public void Print(Message message)
    {
        if (message is null)
        {
            throw new ArgumentNullException(nameof(message));
        }

        Console.Write(Crayon.Output.Rgb(_color.R, _color.G, _color.B).Text(message.BuildMessage()));
    }
}