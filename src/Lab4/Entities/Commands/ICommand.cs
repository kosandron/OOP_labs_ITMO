using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public interface ICommand
{
    void Execute(FileSystemState fileSystemState);
}