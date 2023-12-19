using FluentMigrator;
using Itmo.Dev.Platform.Postgres.Migrations;

namespace DataAccess.Migrations;

[Migration(1, "Initial")]
public class InitialMigration : SqlMigration
{
    protected override string GetUpSql(IServiceProvider serviceProvider)
    {
        return """
               CREATE TABLE IF NOT EXISTS Users
               (
                   Id serial PRIMARY KEY,
                   Password text NOT NULL,
                   AdminStatus boolean,
                   Balance bigint
               );
               CREATE Table IF NOT EXISTS Transactions
               (
                    Id serial REFERENCES Users(Id),
                    Time timestamp,
                    BalanceChange bigint 
               );
               """;
    }

    protected override string GetDownSql(IServiceProvider serviceProvider)
    {
        return """
               DROP TABLE Users;
               DROP TABLE Transactions;
               """;
    }
}