using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Factories;

public class VideoCardFactory : FactoryBase<VideoCard>
{
    public VideoCardFactory(ICollection<VideoCard> components)
        : base(components) { }
}