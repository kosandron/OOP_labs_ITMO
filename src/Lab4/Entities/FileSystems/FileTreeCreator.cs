using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems.FileSystemObjects;
using Directory = Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems.FileSystemObjects.Directory;
using File = Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems.FileSystemObjects.File;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;

public class FileTreeCreator
{
    public IFileObject? GetTree(string path, string name, int depth)
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

        var currentDirectory = new Directory(name);

        foreach (string subFileName in System.IO.Directory.GetFiles(path))
        {
            currentDirectory.Add(new File(subFileName));
        }

        foreach (string subDirectoryName in System.IO.Directory.GetDirectories(path))
        {
            IFileObject? subDirectory = GetTree(path + subDirectoryName + '/', subDirectoryName, depth - 1);
            if (subDirectory is not null)
            {
                currentDirectory.Add(subDirectory);
            }
        }

        return currentDirectory;
    }
}