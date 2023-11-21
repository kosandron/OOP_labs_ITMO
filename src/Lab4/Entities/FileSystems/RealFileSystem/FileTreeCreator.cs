using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems.RealFileSystem.FileSystemObjects;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems.RealFileSystem;

public class FileTreeCreator
{
    public RealFileObject? GetTree(string path, string name, int depth)
    {
        if (depth < 1)
        {
            return null;
        }

        if (string.IsNullOrEmpty(path))
        {
            throw new ArgumentNullException(nameof(path));
        }

        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentNullException(nameof(name));
        }

        var currentDirectory = new RealDirectory(name);

        foreach (string subFileName in Directory.GetFiles(path))
        {
            currentDirectory.Add(new RealFile(subFileName));
        }

        foreach (string subDirectoryName in Directory.GetDirectories(path))
        {
            RealFileObject? subDirectory = GetTree(path + subDirectoryName + '/', subDirectoryName, depth - 1);
            if (subDirectory is not null)
            {
                currentDirectory.Add(subDirectory);
            }
        }

        return currentDirectory;
    }
}