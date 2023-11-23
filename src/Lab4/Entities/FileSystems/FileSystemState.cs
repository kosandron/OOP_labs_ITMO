using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems.Visitors;
using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab4.Service.Writers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;

public class FileSystemState
{
    private IFileSystem _fileSystem;
    private string? _currentPath;
    private FileSystemFactory _fileSystemFactory;
    private WriterFactory _writerFactory;

    public FileSystemState(FileSystemFactory fileSystemFactory, WriterFactory writerFactory)
    {
        if (fileSystemFactory is null)
        {
            throw new ArgumentNullException(nameof(fileSystemFactory));
        }

        if (writerFactory is null)
        {
            throw new ArgumentNullException(nameof(writerFactory));
        }

        _fileSystem = new NotConnectedFileSystem();
        _currentPath = null;
        _fileSystemFactory = fileSystemFactory;
        _writerFactory = writerFactory;
    }

    public IFileSystem FileSystem => _fileSystem;

    public string CurrentPath()
    {
        if (_currentPath is null)
        {
            throw new NotConnectedFileSystemException();
        }

        return _currentPath;
    }

    public void Connect(string mode, string path)
    {
        if (string.IsNullOrEmpty(mode))
        {
            throw new ArgumentNullException(nameof(mode));
        }

        if (string.IsNullOrEmpty(path))
        {
            throw new ArgumentNullException(nameof(path));
        }

        IFileSystem? fileSystem = new FileSystemFactory().CreateByMode(mode);
        if (fileSystem is null)
        {
            throw new NotFoundException($"Filesystem {mode}");
        }

        if (!fileSystem.IsAbsolutePath(path))
        {
            throw new ArgumentException("Path is not absolute!");
        }

        _fileSystem = fileSystem;
        _currentPath = path;
    }

    public void Disconnect()
    {
        _fileSystem = new NotConnectedFileSystem();
        _currentPath = null;
    }

    public void GoToCommand(string path)
    {
        if (string.IsNullOrEmpty(path))
        {
            throw new ArgumentNullException(nameof(path));
        }

        if (!_fileSystem.IsAbsolutePath(path))
        {
            throw new ArgumentException("Path is not absolute!");
        }

        _currentPath = path;
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
            throw new NotFoundException("Writer $mode");
        }

        writer.WriteLine(_fileSystem.GetFileContent(path));
    }

    public void TreeList(string path, string mode, int depth)
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

        var printVisitor = new PrintVisitor();
        _fileSystem.GetFileTree(path, depth).Accept(printVisitor);

        writer.WriteLine(printVisitor.Result);
    }
}