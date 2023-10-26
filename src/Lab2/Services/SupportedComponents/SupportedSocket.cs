using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class SupportedSocket : SupportedComponentBase<string>
{
    public SupportedSocket()
    : base(new List<string>() { "AM1", "AM2", "AM3", "AM4", "AM5", "AM6" }) { }
}