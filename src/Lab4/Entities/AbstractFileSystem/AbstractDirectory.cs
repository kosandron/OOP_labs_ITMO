using System;
using System.Collections.Generic;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.AbstractFileSystem;

public class AbstractDirectory : FileObject
{
    private ICollection<FileObject> _files;

    public AbstractDirectory(string name)
        : base(name)
    {
        _files = new List<FileObject>();
    }

    public AbstractDirectory(string name, ICollection<FileObject> objects)
        : this(name)
    {
        _files = objects ?? new List<FileObject>();
        if (_files.Any(x => x is null))
        {
            throw new ArgumentNullException(nameof(objects));
        }
    }
}