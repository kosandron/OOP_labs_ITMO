using Core.Entities;

namespace DataBaseConnector.Service;

public interface IDataBaseWriter
{
    Task CreateUser(User user);
    Task CreateTransaction(Transaction transaction);
}