using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Factories;

public class WiFiAdapterFactory : FactoryBase<WiFiAdapter>
{
    public WiFiAdapterFactory(ICollection<WiFiAdapter> components)
        : base(components)
    {
    }
}