namespace Presentation;

public interface IScenarioProvider
{
    Task<IScenario?> TryGetScenario();
}