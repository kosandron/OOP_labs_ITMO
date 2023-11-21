namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems.RealFileSystem.Visitors;

public interface IPrintVisitor<in T> : IPrintVisitor
{
    string Visit(T fileObject);
}

public interface IPrintVisitor
{
    public string DirectoryChar { get; set; }
    public string FileChar { get; set; }
}