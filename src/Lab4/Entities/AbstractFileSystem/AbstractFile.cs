namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.AbstractFileSystem;

public class AbstractFile : FileObject
{
    private byte[] body;

    public AbstractFile(string name, byte[] body)
        : base(name)
    {
        this.body = body;
    }
}