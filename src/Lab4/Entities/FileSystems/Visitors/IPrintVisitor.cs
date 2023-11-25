namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems.Visitors;

public interface IPrintVisitor<in T> : IPrintVisitor
{
    void Visit(T fileObject);
}

public interface IPrintVisitor
{
    public string DirectoryChar { get; set; }
    public string FileChar { get; set; }
}