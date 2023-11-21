using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems.RealFileSystem.FileSystemObjects;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems.RealFileSystem.Visitors;

public class RealFilePrintVisitor : IPrintVisitor<RealFile>, IPrintVisitor<RealDirectory>
{
    private int _depth;

    public RealFilePrintVisitor()
    {
        _depth = 0;
    }

    public string DirectoryChar { get; set; } = "#";
    public string FileChar { get; set; } = "-";

    public string Visit(RealFile fileObject)
    {
        if (fileObject is null)
        {
            throw new ArgumentNullException(nameof(fileObject));
        }

        return string.Concat(Enumerable.Repeat('\t', _depth)) + FileChar + fileObject.Name + '\n';
    }

    public string Visit(RealDirectory fileObject)
    {
        if (fileObject is null)
        {
            throw new ArgumentNullException(nameof(fileObject));
        }

        string str = string.Concat(Enumerable.Repeat('\t', _depth)) + DirectoryChar + fileObject.Name + '\n';

        _depth++;

        foreach (RealFileObject c in fileObject.SubObjects)
        {
            str += c.Accept(this);
        }

        _depth--;

        return str;
    }
}