using System;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class ImprovedMessage
{
    private Message _message;
    private bool _isReadStatus;

    public ImprovedMessage(Message message)
    {
        if (message is null)
        {
            throw new ArgumentNullException(nameof(message));
        }

        _message = message;
        _isReadStatus = false;
    }

    public ImprovedMessage(string header, string text, int rating)
    {
        if (string.IsNullOrEmpty(header))
        {
            throw new ArgumentNullException(nameof(header));
        }

        if (string.IsNullOrEmpty(text))
        {
            throw new ArgumentNullException(nameof(text));
        }

        if (rating < 0)
        {
            throw new NegativeValueException(nameof(rating));
        }

        _message = new Message(header, text, rating);
        _isReadStatus = false;
    }

    public Message Message => _message;
    public string Header => _message.Header;
    public string Text => _message.Text;
    public int Rating => _message.Rating;
    public bool IsRead => _isReadStatus;

    public void ChangeReadStatus()
    {
        if (_isReadStatus)
        {
            throw new JustReadException(nameof(_isReadStatus));
        }

        _isReadStatus = true;
    }
}