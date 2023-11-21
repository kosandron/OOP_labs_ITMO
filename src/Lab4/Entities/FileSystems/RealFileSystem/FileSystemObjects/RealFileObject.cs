using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems.RealFileSystem.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems.RealFileSystem.FileSystemObjects;

public abstract class RealFileObject
{
    private readonly string _name;

    protected RealFileObject(string name)
    {
        _name = name;
    }

    public string Name => _name;

    public abstract string Accept(RealFilePrintVisitor printVisitor);
}