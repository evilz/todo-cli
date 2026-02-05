<p align="center">
    <img 
        src="./assets/logo.png"
        width="200"
        height="200"
    />
</p>

# Todo CLI

A cross-platform command-line interface to interact with Microsoft To Do, built using .NET 10.

## Build Status

| Platform | Status |
| ------ | ------------ |
| CI | ![CI](https://github.com/evilz/todo-cli/actions/workflows/ci.yml/badge.svg) |
| Release | ![Release](https://github.com/evilz/todo-cli/actions/workflows/ci.yml/badge.svg?event=release) |

## Features

- ✅ Cross-platform (Linux, macOS, Windows)
- ✅ Self-contained binaries (no .NET runtime required)
- ✅ Microsoft To Do integration
- ✅ Interactive mode with Inquirer
- ✅ Command-line mode for scripting
- ✅ CI/CD with GitHub Actions

## Quick Install

### Linux/macOS (curl)

```bash
# Download the latest Linux x64 binary
curl -L https://github.com/evilz/todo-cli/releases/latest/download/todo-linux-x64.tar.gz -o todo.tar.gz
tar -xzf todo.tar.gz
chmod +x todo
sudo mv todo /usr/local/bin/
todo --help
```

### Windows (PowerShell)

```powershell
# Download the latest Windows x64 zip
Invoke-WebRequest -Uri https://github.com/evilz/todo-cli/releases/latest/download/todo-win-x64.zip -OutFile todo.zip
Expand-Archive -Path todo.zip -DestinationPath todo
.\todo\todo.exe --help
```

### Via .NET CLI

```bash
dotnet tool install -g Todo.CLI --source https://www.nuget.org
todo --help
```

## Build from Source

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- Linux, macOS, or Windows

### Build

```bash
# Clone the repository
git clone https://github.com/evilz/todo-cli.git
cd todo-cli

# Build the solution
dotnet build src/Todo.CLI.sln --configuration Release

# Run tests
dotnet test src/Todo.CLI.sln --configuration Release

# Publish self-contained for your platform
dotnet publish src/Todo.CLI/Todo.CLI.csproj \
  --configuration Release \
  --runtime linux-x64 \
  --self-contained true \
  --output ./publish
```

## Usage

First run will prompt you to sign in with your Microsoft account.

```bash
# Show help
todo --help

# Add a task
todo add "Buy milk"

# List tasks
todo list
todo list --all

# Complete a task
todo complete <task-id>

# Remove a task
todo remove <task-id>
```

## Authentication

The application uses Microsoft OAuth 2.0 for authentication. On first run, it will:
1. Open your default browser
2. Ask you to sign in with your Microsoft account
3. Request consent to access Microsoft To Do
4. Store tokens securely in your system's keyring

## CI/CD

GitHub Actions workflows handle:
- Building and testing on multiple platforms
- Creating self-contained binaries for Linux, macOS, and Windows
- Publishing releases automatically on tag

## Contributing

1. Fork the repository
2. Create a feature branch
3. Add tests for your changes
4. Ensure all tests pass
5. Submit a pull request

## License

MIT License

## Acknowledgments

Built with:
- [.NET 10](https://github.com/dotnet/core)
- [System.CommandLine](https://github.com/dotnet/command-line-api)
- [Microsoft Graph SDK](https://github.com/microsoftgraph/msgraph-beta-sdk-dotnet)
- [Inquirer.cs](https://github.com/hayer/Inquirer.cs)
