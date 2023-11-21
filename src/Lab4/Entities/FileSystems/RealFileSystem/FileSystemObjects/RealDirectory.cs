using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems.RealFileSystem.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems.RealFileSystem.FileSystemObjects;

public class RealDirectory : RealFileObject
{
    private IList<RealFileObject> _subObjects;

    public RealDirectory(string name)
        : base(name)
    {
        _subObjects = new List<RealFileObject>();
    }

    public ImmutableList<RealFileObject> SubObjects => _subObjects.ToImmutableList();

    public void Add(RealFileObject fileObject)
    {
        if (fileObject is null)
        {
            throw new ArgumentNullException(nameof(fileObject));
        }

        _subObjects.Add(fileObject);
    }

    public override string Accept(RealFilePrintVisitor printVisitor)
    {
        if (printVisitor is null)
        {
            throw new ArgumentNullException(nameof(printVisitor));
        }

        return printVisitor.Visit(this);
    }
}