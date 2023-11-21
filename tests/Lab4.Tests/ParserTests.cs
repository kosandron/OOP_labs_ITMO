using Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Service.Parser;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class ParserTests
{
    [Fact]
    public void ConnectCommandTest()
    {
        // Arrange
        var parser = new MainParser();
        string input = "connect src/files -m local";

        // Act
        ICommand? command = parser.Parse(input);

        // Assert
        Assert.NotNull(command);
        Assert.IsType<ConnectCommand>(command);
        if (command is ConnectCommand connectCommand)
        {
            Assert.Equal("src/files", connectCommand.Path);
            Assert.Equal("local", connectCommand.Mode);
        }
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
        if (command is GoToCommand goToCommand)
        {
            Assert.Equal("src/entities", goToCommand.Path);
        }
    }

    [Fact]
    public void TreeListCommandTest()
    {
        // Arrange
        var parser = new MainParser();
        string input = "tree list src/files -m console -d 5";

        // Act
        ICommand? command = parser.Parse(input);

        // Assert
        Assert.NotNull(command);
        Assert.IsType<TreeListCommand>(command);
        if (command is TreeListCommand treeListCommand)
        {
            Assert.Equal("src/files", treeListCommand.Path);
            Assert.Equal("console", treeListCommand.Mode);
            Assert.Equal(5, treeListCommand.Depth);
        }
    }

    [Fact]
    public void ShowCommandTest()
    {
        // Arrange
        var parser = new MainParser();
        string input = "file show src/models/OutputFormat.cs -m console";

        // Act
        ICommand? command = parser.Parse(input);

        // Assert
        Assert.NotNull(command);
        Assert.IsType<ShowCommand>(command);
        if (command is ShowCommand showCommand)
        {
            Assert.Equal("src/models/OutputFormat.cs", showCommand.Path);
            Assert.Equal("console", showCommand.Mode);
        }
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
        if (command is MoveCommand moveCommand)
        {
            Assert.Equal("src/models/OutputFormat.cs", moveCommand.FromPath);
            Assert.Equal("src/entities/OutputFormat.cs", moveCommand.ToPath);
        }
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
        if (command is CopyCommand copyCommand)
        {
            Assert.Equal("src/models/OutputFormat.cs", copyCommand.FromPath);
            Assert.Equal("src/entities/OutputFormat.cs", copyCommand.ToPath);
        }
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
        if (command is DeleteCommand deleteCommandCommand)
        {
            Assert.Equal("src/models/OutputFormat.cs", deleteCommandCommand.Path);
        }
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
        if (command is RenameCommand renameCommand)
        {
            Assert.Equal("src/models/autputFarmat.cs", renameCommand.Path);
            Assert.Equal("OutputFormat.cs", renameCommand.NewName);
        }
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