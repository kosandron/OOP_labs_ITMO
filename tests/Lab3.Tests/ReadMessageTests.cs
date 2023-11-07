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
        user.GetMessage(message);

        // Assert
        Assert.False(user.GetMessageStatus(message));
    }

    [Fact]
    public void MarkNotReadMessageAsRead()
    {
        // Arrange
        var user = new User("Vova");
        var message = new Message("Song", "Skibidi dop", 6);

        // Act
        user.GetMessage(message);

        // Assert
        Assert.False(user.GetMessageStatus(message));
        user.MarkReadMessage(message);
        Assert.True(user.GetMessageStatus(message));
    }

    [Fact]
    public void MarkReadMessageAsRead()
    {
        // Arrange
        var user = new User("Vova");
        var message = new Message("Song", "Skibidi dop", 6);

        // Act
        user.GetMessage(message);

        // Assert
        Assert.False(user.GetMessageStatus(message));
        user.MarkReadMessage(message);
        Assert.True(user.GetMessageStatus(message));
        Assert.Throws<JustReadException>(() => user.MarkReadMessage(message));
    }
}