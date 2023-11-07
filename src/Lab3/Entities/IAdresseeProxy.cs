using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public interface IAdresseeProxy
{
    public bool IsValidMessage(Message message, int minRating);
    public IEnumerable<Message> FilterByRating(IEnumerable<Message> messages, int minRating);
    public void TrySendMessage(Message message, int minRating);
}