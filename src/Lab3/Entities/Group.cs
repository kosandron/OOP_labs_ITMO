using System;
using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class Group : IAdressee
{
    private string _name;
    private IList<User> _users;

    public Group(string name, IList<User> users)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentNullException(nameof(name));
        }

        _name = name;
        _users = users ?? new List<User>();

        if (_users.Any(message => message is null))
        {
            throw new ArgumentNullException(nameof(users));
        }
    }

    public string Name => _name;

    public void GetMessage(Message message)
    {
        if (message is null)
        {
            throw new ArgumentNullException(nameof(message));
        }

        _users.ToList().ForEach(user => user.GetMessage(message));
    }
}