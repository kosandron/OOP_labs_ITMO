using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems.FileSystemObjects;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;

public class NotConnectedFileSystem : IFileSystem
{
    public NotConnectedFileSystem()
    {
        Mode = "none";
    }

    public string Mode { get; init; }

    public void Copy(string fromPath, string toPath)
    {
        throw new NotConnectedFileSystemException();
    }

    public void Delete(string path)
    {
        throw new NotConnectedFileSystemException();
    }

    public void Move(string fromPath, string toPath)
    {
        throw new NotConnectedFileSystemException();
    }

    public void Rename(string path, string newName)
    {
        throw new NotConnectedFileSystemException();
    }

    public string GetFileContent(string path)
    {
        throw new NotConnectedFileSystemException();
    }

    public IFileObject GetFileTree(string path, int depth)
    {
        throw new NotConnectedFileSystemException();
    }

    public bool IsAbsolutePath(string path)
    {
        throw new NotConnectedFileSystemException();
    }

    public string GetAbsolutePath(string nowDirectory, string path)
    {
        throw new NotConnectedFileSystemException();
    }
}