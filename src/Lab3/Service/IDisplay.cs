using System.Drawing;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Service;

public interface IDisplay
{
    void ClearOutput();
    void SetColor(Color color);
    void Print(Message message);
}