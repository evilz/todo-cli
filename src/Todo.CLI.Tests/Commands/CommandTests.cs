using System.CommandLine;
using Todo.CLI.Commands;
using Todo.CLI.Tests.Handlers;
using Todo.Core;
using Xunit;

namespace Todo.CLI.Tests.Commands;

public abstract class CommandTestsBase
{
    protected readonly ServiceProvider _serviceProvider;

    protected CommandTestsBase()
    {
        _serviceProvider = new ServiceCollection()
            .AddSingleton<TodoCliConfiguration>()
            .AddTodoRepositories()
            .AddSingleton<IUserInteraction>(new MockUserInteraction())
            .BuildServiceProvider();
    }
}

public class AddCommandTests : CommandTestsBase
{

    [Fact]
    public void AddCommand_ShouldHaveCorrectName()
    {
        // Arrange & Act
        var command = new AddCommand(_serviceProvider);

        // Assert
        Assert.Equal("add", command.Name);
    }

    [Fact]
    public void AddCommand_ShouldHaveDescription()
    {
        // Arrange & Act
        var command = new AddCommand(_serviceProvider);

        // Assert
        Assert.False(string.IsNullOrEmpty(command.Description));
    }

    [Fact]
    public void AddItemCommand_ShouldAcceptSubjectArgument()
    {
        // Arrange
        var command = new AddCommand(_serviceProvider);
        var itemSubCommand = command.Subcommands.Single(c => c.Name == "item");

        // Act
        var subjectArgument = itemSubCommand.Arguments.SingleOrDefault(a => a.Name == "subject");

        // Assert
        Assert.NotNull(subjectArgument);
    }

    [Fact]
    public void AddItemCommand_ShouldAcceptListAndStarOptions()
    {
        // Arrange
        var command = new AddCommand(_serviceProvider);
        var itemSubCommand = command.Subcommands.Single(c => c.Name == "item");

        // Act
        var listOption = itemSubCommand.Options.SingleOrDefault(o => o.Name == "list");
        var starOption = itemSubCommand.Options.SingleOrDefault(o => o.Name == "star");

        // Assert
        Assert.NotNull(listOption);
        Assert.NotNull(starOption);
    }
}

public class ListCommandTests : CommandTestsBase
{

    [Fact]
    public void ListCommand_ShouldHaveCorrectName()
    {
        // Arrange & Act
        var command = new ListCommand(_serviceProvider);

        // Assert
        Assert.Equal("list", command.Name);
    }

    [Fact]
    public void ListCommand_ShouldAcceptAllFlag()
    {
        // Arrange
        var command = new ListCommand(_serviceProvider);

        // Act
        var allOption = command.Children.OfType<Option>().FirstOrDefault(o => o.Name == "all");

        // Assert
        Assert.NotNull(allOption);
    }
}

public class CompleteCommandTests : CommandTestsBase
{

    [Fact]
    public void CompleteCommand_ShouldHaveCorrectName()
    {
        // Arrange & Act
        var command = new CompleteCommand(_serviceProvider);

        // Assert
        Assert.Equal("complete", command.Name);
    }

    [Fact]
    public void CompleteCommand_ShouldRequireIdArgument()
    {
        // Arrange
        var command = new CompleteCommand(_serviceProvider);

        // Act
        var idArgument = command.Children.OfType<Argument>().FirstOrDefault(a => a.Name == "id");

        // Assert
        Assert.NotNull(idArgument);
    }
}

public class RemoveCommandTests : CommandTestsBase
{
    [Fact]
    public void RemoveCommand_ShouldHaveCorrectName()
    {
        // Arrange & Act
        var command = new RemoveCommand(_serviceProvider);

        // Assert
        Assert.Equal("remove", command.Name);
    }

    [Fact]
    public void RemoveItemCommand_ShouldRequireIdArgument()
    {
        // Arrange
        var command = new RemoveCommand(_serviceProvider);
        var itemSubCommand = command.Subcommands.Single(c => c.Name == "item");

        // Act
        var idArgument = itemSubCommand.Arguments.SingleOrDefault(a => a.Name == "id");

        // Assert
        Assert.NotNull(idArgument);
    }
}
