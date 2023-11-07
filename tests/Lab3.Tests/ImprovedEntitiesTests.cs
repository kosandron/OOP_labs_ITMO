using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class ImprovedEntitiesTests
{
    [Theory]
    [InlineData(25, 1)]
    [InlineData(50, 1)]
    [InlineData(51, 0)]
    [InlineData(75, 0)]
    public void CheckGetMessage(int rating, int methodWorkCount)
    {
        // Arrange
        IAdressee user = Substitute.For<IAdressee>();
        var userProxy = new AdresseeProxy(user);
        var message = new Message("Lunch", "Borsh, Kotlet, Pure, Kompot", 50);

        // Act
        userProxy.TrySendMessage(message, rating);

        // Assert
        user.Received(methodWorkCount).GetMessage(message);
    }

    [Fact]
    public void CheckLogging()
    {
        // Arrange
        ILogger logger = Substitute.For<ILogger>();
        IAdressee user = new User("Fedor");
        var loggedUser = new LoggedAdressee(user, logger);
        var message = new Message("Lunch", "Borsh, Kotlet, Pure, Kompot", 50);

        // Act
        loggedUser.GetMessage(message);

        // Assert
        logger.Received(1).Log(message);
    }

    [Fact]
    public void CheckTelegramMessenger()
    {
        // Arrange
        ITelegram telegram = Substitute.For<ITelegram>();
        var telegramAdapter = new TelegramAdapter(telegram);
        var message = new Message("Lunch", "Borsh, Kotlet, Pure, Kompot", 50);

        // Act
        telegramAdapter.GetMessage(message);

        // Assert
        telegram.Received(1).SendMessage("1f31g3h4j12j", 12345, message.BuildMessage());
    }
}