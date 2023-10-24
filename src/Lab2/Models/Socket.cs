using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class Socket : ICopyable<Socket>
{
    private string _version;

    public Socket(string version)
    {
        _version = version;
    }

    public string Version => _version;
    public Socket DeepCopy()
    {
        return new Socket(Version);
    }
}