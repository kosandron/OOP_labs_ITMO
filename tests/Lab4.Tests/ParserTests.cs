using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Parser;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class ParserTests
{
    [Fact]
    public void ConnectCommandTest()
    {
        // Arrange
        var parser = new MainParser();
        string input = "connect src/files -m standart";

        // Act
        ICommand? command = parser.Parse(input);

        // Assert
        Assert.NotNull(command);
        Assert.IsType<ConnectCommand>(command);
    }

    [Fact]
    public void DisconnectCommandTest()
    {
        // Arrange
        var parser = new MainParser();
        string input = "disconnect";

        // Act
        ICommand? command = parser.Parse(input);

        // Assert
        Assert.NotNull(command);
        Assert.IsType<DisconnectCommand>(command);
    }

    [Fact]
    public void GoToCommandTest()
    {
        // Arrange
        var parser = new MainParser();
        string input = "tree goto src/entities";

        // Act
        ICommand? command = parser.Parse(input);

        // Assert
        Assert.NotNull(command);
        Assert.IsType<GoToCommand>(command);
    }

    [Fact]
    public void TreeListCommandTest()
    {
        // Arrange
        var parser = new MainParser();
        string input = "tree list -d 5";

        // Act
        ICommand? command = parser.Parse(input);

        // Assert
        Assert.NotNull(command);
        Assert.IsType<TreeListCommand>(command);
    }

    [Fact]
    public void ShowCommandTest()
    {
        // Arrange
        var parser = new MainParser();
        string input = "file show src/models/OutputFormat.cs -d 5";

        // Act
        ICommand? command = parser.Parse(input);

        // Assert
        Assert.NotNull(command);
        Assert.IsType<ShowCommand>(command);
    }

    [Fact]
    public void MoveCommandTest()
    {
        // Arrange
        var parser = new MainParser();
        string input = "file move src/models/OutputFormat.cs src/entities/OutputFormat.cs";

        // Act
        ICommand? command = parser.Parse(input);

        // Assert
        Assert.NotNull(command);
        Assert.IsType<MoveCommand>(command);
    }

    [Fact]
    public void CopyCommandTest()
    {
        // Arrange
        var parser = new MainParser();
        string input = "file copy src/models/OutputFormat.cs src/entities/OutputFormat.cs";

        // Act
        ICommand? command = parser.Parse(input);

        // Assert
        Assert.NotNull(command);
        Assert.IsType<CopyCommand>(command);
    }

    [Fact]
    public void DeleteCommandTest()
    {
        // Arrange
        var parser = new MainParser();
        string input = "file delete src/models/OutputFormat.cs";

        // Act
        ICommand? command = parser.Parse(input);

        // Assert
        Assert.NotNull(command);
        Assert.IsType<DeleteCommand>(command);
    }

    [Fact]
    public void RenameCommandTest()
    {
        // Arrange
        var parser = new MainParser();
        string input = "file rename src/models/autputFarmat.cs OutputFormat.cs";

        // Act
        ICommand? command = parser.Parse(input);

        // Assert
        Assert.NotNull(command);
        Assert.IsType<RenameCommand>(command);
    }

    [Fact]
    public void UnknownCommandTest()
    {
        // Arrange
        var parser = new MainParser();
        string input = "file rollback src/models/autputFarmat.cs";

        // Act
        ICommand? command = parser.Parse(input);

        // Assert
        Assert.Null(command);
    }
}