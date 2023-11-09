using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class ImprovedEntitiesTests
{
    [Theory]
    [InlineData(25, 0)]
    [InlineData(99, 0)]
    [InlineData(100, 1)]
    [InlineData(101, 1)]
    public void CheckSendMessage(int messageRating, int methodWorkCount)
    {
        // Arrange
        IAdressee user = Substitute.For<IAdressee>();
        var userProxy = new AdresseeProxy(user);
        var message = new Message("Lunch", "Borsh, Kotlet, Pure, Kompot", messageRating);

        // Act
        userProxy.SendMessage(message);

        // Assert
        user.Received(methodWorkCount).SendMessage(message);
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
        loggedUser.SendMessage(message);

        // Assert
        logger.Received(1).Log(message);
    }

    [Fact]
    public void CheckTelegramMessenger()
    {
        // Arrange
        ITelegram telegram = Substitute.For<ITelegram>();
        var messanger = new AdreseeMessanger(new TelegramAdapter(telegram));
        var message = new Message("Lunch", "Borsh, Kotlet, Pure, Kompot", 50);

        // Act
        messanger.SendMessage(message);

        // Assert
        telegram.Received(1).SendMessage("1f31g3h4j12j", 12345, message.BuildMessage());
    }
}