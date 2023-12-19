using Spectre.Console;

namespace Presentation;

public class ScenarioRunner
{
    private readonly IEnumerable<IScenarioProvider> _providers;

    public ScenarioRunner(IEnumerable<IScenarioProvider> providers)
    {
        _providers = providers;
    }

    public async Task Run()
    {
        IEnumerable<IScenario> scenarios = await GetScenarios();

        SelectionPrompt<IScenario> selector = new SelectionPrompt<IScenario>()
            .Title("Select action")
            .AddChoices(scenarios)
            .UseConverter(x => x.Name);

        IScenario scenario = AnsiConsole.Prompt(selector);
        await scenario.Run();
    }

    private async Task<IEnumerable<IScenario>> GetScenarios()
    {
        var scenarios = new List<IScenario>();
        foreach (IScenarioProvider provider in _providers)
        {
            IScenario? scenario = await provider.TryGetScenario();
            if (scenario is not null)
                scenarios.Add(scenario);
        }

        return scenarios;
    }
}