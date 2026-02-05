using System.CommandLine;
using Todo.CLI.Commands;
using Todo.CLI.Tests.Handlers;
using Todo.Core;
using Xunit;

namespace Todo.CLI.Tests.Commands;

public class AddCommandTests
{
    private readonly ServiceProvider _serviceProvider;

    public AddCommandTests()
    {
        _serviceProvider = new ServiceCollection()
            .AddSingleton<TodoCliConfiguration>()
            .AddTodoRepositories()
            .AddSingleton<IUserInteraction>(new MockUserInteraction())
            .BuildServiceProvider();
    }

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
    public void AddCommand_ShouldAcceptTitleArgument()
    {
        // Arrange
        var command = new AddCommand(_serviceProvider);

        // Act
        var titleArgument = command.Children.OfType<Argument>().FirstOrDefault(a => a.Name == "title");

        // Assert
        Assert.NotNull(titleArgument);
    }

    [Fact]
    public void AddCommand_ShouldAcceptFlags()
    {
        // Arrange
        var command = new AddCommand(_serviceProvider);

        // Act
        var importanceOption = command.Children.OfType<Option>().FirstOrDefault(o => o.Name == "importance");
        var listOption = command.Children.OfType<Option>().FirstOrDefault(o => o.Name == "list");

        // Assert
        Assert.NotNull(importanceOption);
        Assert.NotNull(listOption);
    }
}

public class ListCommandTests
{
    private readonly ServiceProvider _serviceProvider;

    public ListCommandTests()
    {
        _serviceProvider = new ServiceCollection()
            .AddSingleton<TodoCliConfiguration>()
            .AddTodoRepositories()
            .AddSingleton<IUserInteraction>(new MockUserInteraction())
            .BuildServiceProvider();
    }

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

public class CompleteCommandTests
{
    private readonly ServiceProvider _serviceProvider;

    public CompleteCommandTests()
    {
        _serviceProvider = new ServiceCollection()
            .AddSingleton<TodoCliConfiguration>()
            .AddTodoRepositories()
            .AddSingleton<IUserInteraction>(new MockUserInteraction())
            .BuildServiceProvider();
    }

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

public class RemoveCommandTests
{
    private readonly ServiceProvider _serviceProvider;

    public RemoveCommandTests()
    {
        _serviceProvider = new ServiceCollection()
            .AddSingleton<TodoCliConfiguration>()
            .AddTodoRepositories()
            .AddSingleton<IUserInteraction>(new MockUserInteraction())
            .BuildServiceProvider();
    }

    [Fact]
    public void RemoveCommand_ShouldHaveCorrectName()
    {
        // Arrange & Act
        var command = new RemoveCommand(_serviceProvider);

        // Assert
        Assert.Equal("remove", command.Name);
    }

    [Fact]
    public void RemoveCommand_ShouldRequireIdArgument()
    {
        // Arrange
        var command = new RemoveCommand(_serviceProvider);

        // Act
        var idArgument = command.Children.OfType<Argument>().FirstOrDefault(a => a.Name == "id");

        // Assert
        Assert.NotNull(idArgument);
    }
}
