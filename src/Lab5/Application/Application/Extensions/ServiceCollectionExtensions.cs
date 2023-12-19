using Application.Transaction;
using Application.User;
using Contracts.Transaction;
using Contracts.User;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection.AddScoped<IUserService, UserService>();
        collection.AddScoped<ITransactionService, TransactionService>();

        collection.AddScoped<ICurrentUserService, CurrentUserManager>();
        return collection;
    }
}