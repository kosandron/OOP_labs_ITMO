using System;
using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems.RealFileSystem.FileSystemObjects;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems.RealFileSystem.Visitors;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Service.Writers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems.RealFileSystem;

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

    public void Show(string path, string mode)
    {
        if (string.IsNullOrEmpty(path))
        {
            throw new ArgumentNullException(nameof(path));
        }

        if (string.IsNullOrEmpty(mode))
        {
            throw new ArgumentNullException(nameof(mode));
        }

        WriterBase? writer = new WriterFactory().CreateByMode(mode);
        if (writer is null)
        {
            throw new NotFoundException("Writer mode");
        }

        var streamReader = new StreamReader(path);
        string? line = streamReader.ReadLine();
        while (line != null)
        {
            writer.WriteLine(line);
            line = streamReader.ReadLine();
        }

        streamReader.Close();
    }

    public void TreeList(string path, int depth, string mode)
    {
        if (string.IsNullOrEmpty(path))
        {
            throw new ArgumentNullException(nameof(path));
        }

        if (string.IsNullOrEmpty(mode))
        {
            throw new ArgumentNullException(nameof(mode));
        }

        if (depth < 1)
        {
            throw new NegativeValueException("Depth < 1");
        }

        WriterBase? writer = new WriterFactory().CreateByMode(mode);
        if (writer is null)
        {
            throw new NotFoundException("Writer $mode");
        }

        RealFileObject? fileTree = new FileTreeCreator()
            .GetTree(path, path.Substring(path.LastIndexOf("/", StringComparison.Ordinal)), depth);
        if (fileTree is null)
        {
            throw new NotFoundException(path);
        }

        var visitor = new RealFilePrintVisitor();
        writer.WriteLine(fileTree.Accept(visitor));
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