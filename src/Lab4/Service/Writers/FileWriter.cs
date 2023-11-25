using System;
using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.Service.Writers;

public class FileWriter : WriterBase
{
    private readonly string _path;

    public FileWriter()
        : base("file")
    {
        _path = "resultCommandFile.txt";
    }

    public FileWriter(string path)
        : base("file")
    {
        if (string.IsNullOrEmpty(path))
        {
            throw new ArgumentNullException(nameof(path));
        }

        _path = path;
    }

    public override void WriteLine(string line)
    {
        File.WriteAllText(_path, line);
    }
}