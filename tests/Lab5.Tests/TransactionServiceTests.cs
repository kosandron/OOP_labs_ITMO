using System.Threading.Tasks;
using Abstractions.Repositories;
using Application.Transaction;
using Application.User;
using Contracts.Transaction;
using Models.Users;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class TransactionServiceTests
{
    [Fact]
    public async Task PutMoneyTest()
    {
        var user = new User(1, "abcd", UserStatus.User);
        ITransactionRepository transactionRepository = Substitute.For<ITransactionRepository>();
        IUserRepository userRepository = Substitute.For<IUserRepository>();
        var userManager = new CurrentUserManager();
        userManager.Login(user);
        var transactionService = new TransactionService(transactionRepository, userRepository);
        var userService = new UserService(userRepository, userManager);

        await userService.CreateUser("abcd", UserStatus.User);
        userService.GetUser(1, "abcd").Returns(user);
        userService.GetUserBalance(user).Returns(0);

        MoneyOperationResult status = await transactionService.PutMoney(user, 100);
        userService.GetUserBalance(user).Returns(100);
        Assert.Equal(MoneyOperationResult.Success, status);
    }

    [Fact]
    public async Task TakeMoreMoneyThanAreOnAccountTest()
    {
        var user = new User(1, "abcd", UserStatus.User);
        ITransactionRepository transactionRepository = Substitute.For<ITransactionRepository>();
        IUserRepository userRepository = Substitute.For<IUserRepository>();
        var userManager = new CurrentUserManager();
        userManager.Login(user);
        var transactionService = new TransactionService(transactionRepository, userRepository);
        var userService = new UserService(userRepository, userManager);

        await userService.CreateUser("abcd", UserStatus.User);
        userService.GetUser(1, "abcd").Returns(user);
        userService.GetUserBalance(user).Returns(0);

        MoneyOperationResult putMoneyStatus = await transactionService.PutMoney(user, 100);
        userService.GetUserBalance(user).Returns(100);
        Assert.Equal(MoneyOperationResult.Success, putMoneyStatus);

        MoneyOperationResult takeMoneyStatus = await transactionService.TakeMoney(user, 150);
        userService.GetUserBalance(user).Returns(100);
        Assert.Equal(MoneyOperationResult.Fail, takeMoneyStatus);
    }

    [Fact]
    public async Task TakeLessMoneyThanAreOnAccountTest()
    {
        var user = new User(1, "abcd", UserStatus.User);
        ITransactionRepository transactionRepository = Substitute.For<ITransactionRepository>();
        IUserRepository userRepository = Substitute.For<IUserRepository>();
        var userManager = new CurrentUserManager();
        userManager.Login(user);
        var transactionService = new TransactionService(transactionRepository, userRepository);
        var userService = new UserService(userRepository, userManager);

        await userService.CreateUser("abcd", UserStatus.User);
        userService.GetUser(1, "abcd").Returns(user);
        userService.GetUserBalance(user).Returns(0);

        MoneyOperationResult putMoneyStatus = await transactionService.PutMoney(user, 100);
        userService.GetUserBalance(user).Returns(100);
        Assert.Equal(MoneyOperationResult.Success, putMoneyStatus);

        MoneyOperationResult takeMoneyStatus = await transactionService.TakeMoney(user, 55);
        userService.GetUserBalance(user).Returns(45);
        Assert.Equal(MoneyOperationResult.Success, takeMoneyStatus);
    }
}