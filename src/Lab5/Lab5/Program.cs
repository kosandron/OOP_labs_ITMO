using Application.Extensions;
using DataAccess.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Presentation;
using Presentation.Extensions;
using Spectre.Console;

var collection = new ServiceCollection();

collection
    .AddApplication()
    .AddInfrastructureDataAccess(configuration =>
    {
        configuration.Host = "localhost";
        configuration.Port = 5432;
        configuration.Username = "postgres";
        configuration.Password = "1703111";
        configuration.Database = "postgres";
        configuration.SslMode = "Prefer";
    })
    .AddPresentationConsole();

ServiceProvider provider = collection.BuildServiceProvider();
using IServiceScope scope = provider.CreateScope();

scope.UseInfrastructureDataAccess();

ScenarioRunner scenarioRunner = scope.ServiceProvider
    .GetRequiredService<ScenarioRunner>();

while (true)
{
    await scenarioRunner.Run();
    AnsiConsole.Clear();
}