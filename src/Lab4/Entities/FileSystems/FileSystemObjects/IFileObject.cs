using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems.FileSystemObjects;

public interface IFileObject
{
    string Name { get; init; }

    void Accept(PrintVisitor printVisitor);
}