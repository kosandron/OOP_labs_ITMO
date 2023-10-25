using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public interface IComputerBuilder
{
    IComputerBuilder WithVideoCard(VideoCard? videoCard);
    IComputerBuilder WithSsd(Ssd? ssd);
    IComputerBuilder WithHdd(Hdd? hdd);
    IComputerBuilder WithWifiAdapter(WiFiAdapter? wiFiAdapter);
    Computer Build();
}