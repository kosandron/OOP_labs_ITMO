using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Builders;

public interface IBiosBuilder
{
    IBiosBuilder WithName(string name);
    IBiosBuilder WithType(string type);
    IBiosBuilder WithVersion(string version);
    IBiosBuilder WithSupportedCpuList(IList<string> supportedCpuList);
    public Bios Build();
}