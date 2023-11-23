using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems.FileSystemObjects;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;

public interface IFileSystem
{
    public string Mode { get; init; }
    void Copy(string fromPath, string toPath);
    void Delete(string path);
    void Move(string fromPath, string toPath);
    void Rename(string path, string newName);
    string GetFileContent(string path);
    IFileObject GetFileTree(string path, int depth);
    bool IsAbsolutePath(string path);
    string GetAbsolutePath(string nowDirectory, string path);
}