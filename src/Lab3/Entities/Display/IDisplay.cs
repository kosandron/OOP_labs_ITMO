using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Display;

public interface IDisplay
{
    void ClearOutput();
    void SetColor(Color color);
    void Print(Message message);
}