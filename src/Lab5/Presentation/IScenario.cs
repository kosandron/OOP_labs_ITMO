namespace Presentation;

public interface IScenario
{
    string Name { get; }

    Task Run();
}