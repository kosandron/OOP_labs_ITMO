using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class ReadMessageTests
{
    [Fact]
    public void GetAndNotReadMessage()
    {
        // Arrange
        var user = new User("Vova");
        var message = new Message("Song", "Skibidi dop", 6);

        // Act
        user.SendMessage(message);

        // Assert
        Assert.False(user.SendMessageStatus(message));
    }

    [Fact]
    public void MarkNotReadMessageAsRead()
    {
        // Arrange
        var user = new User("Vova");
        var message = new Message("Song", "Skibidi dop", 6);

        // Act
        user.SendMessage(message);

        // Assert
        Assert.False(user.SendMessageStatus(message));
        user.MarkReadMessage(message);
        Assert.True(user.SendMessageStatus(message));
    }

    [Fact]
    public void MarkReadMessageAsRead()
    {
        // Arrange
        var user = new User("Vova");
        var message = new Message("Song", "Skibidi dop", 6);

        // Act
        user.SendMessage(message);

        // Assert
        Assert.False(user.SendMessageStatus(message));
        user.MarkReadMessage(message);
        Assert.True(user.SendMessageStatus(message));
        Assert.Throws<JustReadException>(() => user.MarkReadMessage(message));
    }
}