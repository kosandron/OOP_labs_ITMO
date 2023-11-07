using System;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class Message
{
    private readonly string _header;
    private readonly string _text;
    private readonly int _rating;

    public Message(string header, string text, int rating)
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

        _header = header;
        _text = text;
        _rating = rating;
    }

    public string Header => _header;
    public string Text => _text;
    public int Rating => _rating;

    public string BuildMessage()
    {
        return _header + '\n' + _text + '\n';
    }

    public bool Equals(Message message)
    {
        if (message is null)
        {
            return false;
        }

        if (this == message)
        {
            return true;
        }

        if (this.GetType() != message.GetType())
        {
            return false;
        }

        return this.Header.Equals(message.Header, StringComparison.Ordinal) && this.Text.Equals(message.Text, StringComparison.Ordinal) && this.Rating == message.Rating;
    }

    public override int GetHashCode()
    {
        return (_header, _text, _rating).GetHashCode();
    }
}