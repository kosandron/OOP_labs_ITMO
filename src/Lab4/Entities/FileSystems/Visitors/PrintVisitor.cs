using System;
using System.Linq;
using System.Text;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems.FileSystemObjects;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems.Visitors;

public class PrintVisitor : IPrintVisitor<File>, IPrintVisitor<Directory>
{
    private int _depth;
    private StringBuilder _stringBuilder;

    public PrintVisitor()
    {
        _depth = 0;
        _stringBuilder = new StringBuilder();
    }

    public string Result => _stringBuilder.ToString();
    public string DirectoryChar { get; set; } = "#";
    public string FileChar { get; set; } = "-";

    public void Visit(File fileObject)
    {
        if (fileObject is null)
        {
            throw new ArgumentNullException(nameof(fileObject));
        }

        _stringBuilder.Append(Enumerable.Repeat('\t', _depth));
        _stringBuilder.Append(FileChar);
        _stringBuilder.Append(fileObject.Name);
        _stringBuilder.Append('\n');
    }

    public void Visit(Directory fileObject)
    {
        if (fileObject is null)
        {
            throw new ArgumentNullException(nameof(fileObject));
        }

        _stringBuilder.Append(Enumerable.Repeat('\t', _depth));
        _stringBuilder.Append(DirectoryChar);
        _stringBuilder.Append(fileObject.Name);
        _stringBuilder.Append('\n');

        _depth++;

        foreach (IFileObject c in fileObject.SubObjects)
        {
            c.Accept(this);
        }

        _depth--;
    }
}