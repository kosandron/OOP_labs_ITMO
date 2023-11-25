using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems.FileSystemObjects;

public class File : IFileObject
{
    public File(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentNullException(nameof(name));
        }

        Name = name;
    }

    public string Name { get; init; }

    public void Accept(PrintVisitor printVisitor)
    {
        if (printVisitor is null)
        {
            throw new ArgumentNullException(nameof(printVisitor));
        }

        printVisitor.Visit(this);
    }
}