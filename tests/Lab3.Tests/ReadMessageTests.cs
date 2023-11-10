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
        _userVova = new User();
        _contactBook = new ContactBook(new List<Topic>()
        {
            new Topic("Vova", _userVova),
            new Topic(
                "Petya",
                new User()),
            new Topic(
                "M3203",
                new Group(
                    new List<IAdressee>()
                    {
                        new User(),
                        new User(),
                        new User(),
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