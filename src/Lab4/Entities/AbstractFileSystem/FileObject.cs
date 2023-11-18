using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.AbstractFileSystem;

public class FileObject
{
    private string _name;

    public FileObject(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentNullException(name);
        }

        _name = name;
    }

    public string Name => _name;

    public void Rename(string newName)
    {
        if (string.IsNullOrEmpty(newName))
        {
            throw new ArgumentNullException(newName);
        }

        _name = newName;
    }
}