using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class SupportedBios : SupportedComponentBase<Bios>
{
    public SupportedBios()
    : base(new List<Bios>()
    {
        new Bios("Bios 1.0", "type 1", "SuperPower", new List<string>() { "Intel i-123", "Intel i-239" }),
        new Bios("Bios 2.0", "type 2", "SuperPower", new List<string>() { "Intel i-321", "Intel i-239", "Intel i-40" }),
        new Bios("Bios 3.0", "type 3", "MegaFlexible", new List<string>() { "Intel i-123", "Intel i-40", "Intel i-75" }),
    }) { }
}