using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems.RealFileSystem.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems.RealFileSystem.FileSystemObjects;

public class RealFile : RealFileObject
{
    public RealFile(string name)
        : base(name)
    {
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