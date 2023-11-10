using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class ReadMessageTests
{
    private User _userVova;
    private ContactBook _contactBook;

    public ReadMessageTests()
    {
        _userVova = new User("Vova");
        _contactBook = new ContactBook(new List<Topic>()
        {
            new Topic("Vova", _userVova),
            new Topic(
                "Petya",
                new User("Petya")),
            new Topic(
                "M3203",
                new Group(
                    "My group",
                    new List<IAdressee>()
                    {
                        new User("Masha"),
                        new User("Misha"),
                        new User("Gosha"),
                    })),
        });
    }

    [Fact]
    public void GetAndNotReadMessage()
    {
        // Arrange
        var message = new Message("Song", "Skibidi dop", 6);

        // Act
        _contactBook.SendMessageByName("Vova", message);

        // Assert
        Assert.False(_userVova.SendMessageStatus(message));
    }

    [Fact]
    public void MarkNotReadMessageAsRead()
    {
        // Arrange
        var message = new Message("Song", "Skibidi dop", 6);

        // Act
        _contactBook.SendMessageByName("Vova", message);

        // Assert
        Assert.False(_userVova.SendMessageStatus(message));
        _userVova.MarkReadMessage(message);
        Assert.True(_userVova.SendMessageStatus(message));
    }

    [Fact]
    public void MarkReadMessageAsRead()
    {
        // Arrange
        var message = new Message("Song", "Skibidi dop", 6);

        // Act
        _contactBook.SendMessageByName("Vova", message);

        // Assert
        Assert.False(_userVova.SendMessageStatus(message));
        _userVova.MarkReadMessage(message);
        Assert.True(_userVova.SendMessageStatus(message));
        Assert.Throws<JustReadException>(() => _userVova.MarkReadMessage(message));
    }
}