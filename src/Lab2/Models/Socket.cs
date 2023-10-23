namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class Socket
{
    private string _version;

    public Socket(string version)
    {
        _version = version;
    }

    public string Version => _version;
}