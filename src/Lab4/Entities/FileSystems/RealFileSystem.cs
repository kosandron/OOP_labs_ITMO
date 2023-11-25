using System;
using System.IO;
using System.Text;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems.FileSystemObjects;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using File = System.IO.File;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;

public class RealFileSystem : IFileSystem
{
    public string Mode { get; init; } = "local";

    public void Copy(string fromPath, string toPath)
    {
        if (fromPath is null)
        {
            throw new ArgumentNullException(nameof(fromPath));
        }

        if (toPath is null)
        {
            throw new ArgumentNullException(nameof(toPath));
        }

        File.Copy(fromPath, toPath);
    }

    public void Delete(string path)
    {
        if (path is null)
        {
            throw new ArgumentNullException(nameof(path));
        }

        File.Delete(path);
    }

    public void Move(string fromPath, string toPath)
    {
        if (fromPath is null)
        {
            throw new ArgumentNullException(nameof(fromPath));
        }

        if (toPath is null)
        {
            throw new ArgumentNullException(nameof(toPath));
        }

        File.Move(fromPath, toPath);
    }

    public void Rename(string path, string newName)
    {
        if (path is null)
        {
            throw new ArgumentNullException(nameof(path));
        }

        if (newName is null)
        {
            throw new ArgumentNullException(nameof(newName));
        }

        File.Move(path, string.Concat(Path.GetDirectoryName(path), newName));
    }

    public string GetFileContent(string path)
    {
        if (string.IsNullOrEmpty(path))
        {
            throw new ArgumentNullException(nameof(path));
        }

        var streamReader = new StreamReader(path);
        var stringBuilder = new StringBuilder();
        string? line = streamReader.ReadLine();
        while (line != null)
        {
            stringBuilder.Append(line);
            line = streamReader.ReadLine();
        }

        streamReader.Close();

        return stringBuilder.ToString();
    }

    public IFileObject GetFileTree(string path, int depth)
    {
        if (string.IsNullOrEmpty(path))
        {
            throw new ArgumentNullException(nameof(path));
        }

        if (depth < 1)
        {
            throw new NegativeValueException("Depth < 1");
        }

        IFileObject? fileTreeRoot = new FileTreeCreator()
            .GetTree(path, path.Substring(path.LastIndexOf("/", StringComparison.Ordinal)), depth);
        if (fileTreeRoot is null)
        {
            throw new NotFoundException(path);
        }

        return fileTreeRoot;
    }

    public bool IsAbsolutePath(string path)
    {
        if (string.IsNullOrEmpty(path))
        {
            return false;
        }

        return Path.IsPathFullyQualified(path);
    }

    public string GetAbsolutePath(string nowDirectory, string path)
    {
        if (string.IsNullOrEmpty(path))
        {
            throw new ArgumentNullException(nameof(path));
        }

        if (string.IsNullOrEmpty(nowDirectory))
        {
            throw new ArgumentNullException(nameof(nowDirectory));
        }

        if (IsAbsolutePath(path))
        {
            return path;
        }

        return Path.Combine(nowDirectory, path);
    }
}