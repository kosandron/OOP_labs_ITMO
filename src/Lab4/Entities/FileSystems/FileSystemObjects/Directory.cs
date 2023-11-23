using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems.FileSystemObjects;

public class Directory : IFileObject
{
    private IList<IFileObject> _subObjects;

    public Directory(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentNullException(nameof(name));
        }

        Name = name;
        _subObjects = new List<IFileObject>();
    }

    public string Name { get; init; }
    public ImmutableList<IFileObject> SubObjects => _subObjects.ToImmutableList();

    public void Add(IFileObject fileObject)
    {
        if (fileObject is null)
        {
            throw new ArgumentNullException(nameof(fileObject));
        }

        _subObjects.Add(fileObject);
    }

    public void Accept(PrintVisitor printVisitor)
    {
        if (printVisitor is null)
        {
            throw new ArgumentNullException(nameof(printVisitor));
        }

        printVisitor.Visit(this);
    }
}