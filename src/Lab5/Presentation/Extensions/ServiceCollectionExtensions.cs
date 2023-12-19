using Microsoft.Extensions.DependencyInjection;
using Presentation.Scenarios.Create;
using Presentation.Scenarios.Login;
using Presentation.Scenarios.Operations;
using Presentation.Scenarios.UserData;

namespace Presentation.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentationConsole(this IServiceCollection collection)
    {
        collection.AddScoped<ScenarioRunner>();

        collection.AddScoped<IScenarioProvider, LoginScenarioProvider>();
        collection.AddScoped<IScenarioProvider, LogoutScenarioProvider>();
        collection.AddScoped<IScenarioProvider, CreateUserScenarioProvider>();
        collection.AddScoped<IScenarioProvider, PutMoneyScenarioProvider>();
        collection.AddScoped<IScenarioProvider, TakeMoneyScenarioProvider>();
        collection.AddScoped<IScenarioProvider, GetBalanceScenarioProvider>();
        collection.AddScoped<IScenarioProvider, GetTransactionsHistoryScenarioProvider>();

        return collection;
    }
}