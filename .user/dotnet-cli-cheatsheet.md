# .NET CLI Cheatsheet

A comprehensive reference for dotnet CLI commands for solution and project management.

## Table of Contents

- [Solution Commands](#solution-commands)
- [Project Commands](#project-commands)
- [Build & Run](#build--run)
- [Package Management](#package-management)
- [Testing](#testing)
- [Publishing](#publishing)
- [Common Project Templates](#common-project-templates)
- [Useful Flags](#useful-flags)

---

## Solution Commands

### Create a New Solution

```bash
# Create a solution in current directory
dotnet new sln

# Create a solution with a specific name
dotnet new sln -n MySolution

# Create a solution in a specific directory
dotnet new sln -o MyDirectory
```

### Add Projects to Solution

```bash
# Add a single project
dotnet sln add MyProject/MyProject.csproj

# Add multiple projects
dotnet sln add Project1/Project1.csproj Project2/Project2.csproj

# Add all projects in a directory
dotnet sln add **/*.csproj

# Add all projects in current directory and subdirectories
dotnet sln add **/**/*.csproj
```

### Remove Projects from Solution

```bash
# Remove a project
dotnet sln remove MyProject/MyProject.csproj

# Remove multiple projects
dotnet sln remove Project1/Project1.csproj Project2/Project2.csproj
```

### List Projects in Solution

```bash
# List all projects
dotnet sln list
```

---

## Project Commands

### Create a New Project

```bash
# Create a project in current directory
dotnet new console

# Create a project with a specific name
dotnet new console -n MyApp

# Create a project in a specific directory
dotnet new console -o MyApp

# Create a project with specific framework
dotnet new console -f net8.0

# Create a project with specific language
dotnet new console -lang C#
dotnet new console -lang F#
```

### Add Project References

```bash
# Add a reference to another project
dotnet add reference ../OtherProject/OtherProject.csproj

# Add multiple references
dotnet add reference ../Project1/Project1.csproj ../Project2/Project2.csproj

# Add reference from specific project
dotnet add MyProject/MyProject.csproj reference OtherProject/OtherProject.csproj
```

### Remove Project References

```bash
# Remove a reference
dotnet remove reference ../OtherProject/OtherProject.csproj
```

### List Project References

```bash
# List all references
dotnet list reference

# List references for specific project
dotnet list MyProject/MyProject.csproj reference
```

### Restore Project Dependencies

```bash
# Restore dependencies for current project
dotnet restore

# Restore dependencies for specific project
dotnet restore MyProject/MyProject.csproj

# Restore dependencies for solution
dotnet restore MySolution.sln
```

---

## Build & Run

### Build

```bash
# Build current project/solution
dotnet build

# Build specific project
dotnet build MyProject/MyProject.csproj

# Build with configuration
dotnet build -c Release
dotnet build -c Debug

# Build without restoring
dotnet build --no-restore

# Build with specific framework
dotnet build -f net8.0

# Build with verbose output
dotnet build -v detailed
```

### Run

```bash
# Run current project
dotnet run

# Run specific project
dotnet run --project MyProject/MyProject.csproj

# Run with configuration
dotnet run -c Release

# Run without building
dotnet run --no-build

# Pass arguments to the application
dotnet run -- arg1 arg2 arg3

# Run with specific framework
dotnet run -f net8.0
```

### Clean

```bash
# Clean build outputs
dotnet clean

# Clean specific project
dotnet clean MyProject/MyProject.csproj

# Clean with configuration
dotnet clean -c Release
```

---

## Package Management

### Add NuGet Package

```bash
# Add latest version
dotnet add package Newtonsoft.Json

# Add specific version
dotnet add package Newtonsoft.Json --version 13.0.3

# Add prerelease version
dotnet add package SomePackage --prerelease

# Add to specific project
dotnet add MyProject/MyProject.csproj package Newtonsoft.Json
```

### Remove NuGet Package

```bash
# Remove package
dotnet remove package Newtonsoft.Json

# Remove from specific project
dotnet remove MyProject/MyProject.csproj package Newtonsoft.Json
```

### List NuGet Packages

```bash
# List packages in current project
dotnet list package

# List packages including transitive dependencies
dotnet list package --include-transitive

# List outdated packages
dotnet list package --outdated

# List vulnerable packages
dotnet list package --vulnerable

# List deprecated packages
dotnet list package --deprecated
```

### Update NuGet Packages

```bash
# Update package to latest version
dotnet add package Newtonsoft.Json

# Restore packages
dotnet restore
```

---

## Testing

### Run Tests

```bash
# Run all tests in solution
dotnet test

# Run tests in specific project
dotnet test MyTests/MyTests.csproj

# Run with verbose output
dotnet test -v detailed

# Run without building
dotnet test --no-build

# Run with code coverage
dotnet test --collect:"XPlat Code Coverage"

# Filter tests
dotnet test --filter "FullyQualifiedName~MyNamespace"
dotnet test --filter "Category=Unit"

# Run tests with logger
dotnet test --logger "console;verbosity=detailed"
dotnet test --logger "trx"
```

### Create Test Project

```bash
# Create xUnit test project
dotnet new xunit -n MyTests

# Create NUnit test project
dotnet new nunit -n MyTests

# Create MSTest project
dotnet new mstest -n MyTests
```

---

## Publishing

### Publish Application

```bash
# Publish current project
dotnet publish

# Publish with configuration
dotnet publish -c Release

# Publish to specific directory
dotnet publish -o ./publish

# Publish for specific runtime (self-contained)
dotnet publish -r win-x64
dotnet publish -r linux-x64
dotnet publish -r osx-x64

# Publish as self-contained
dotnet publish -r win-x64 --self-contained true

# Publish as framework-dependent
dotnet publish --self-contained false

# Publish single file
dotnet publish -r win-x64 -p:PublishSingleFile=true

# Publish trimmed
dotnet publish -c Release -p:PublishTrimmed=true

# Publish ReadyToRun
dotnet publish -c Release -p:PublishReadyToRun=true
```

---

## Common Project Templates

### List Available Templates

```bash
# List all installed templates
dotnet new list
dotnet new --list

# Search for templates
dotnet new search web
```

### Web Templates

```bash
# ASP.NET Core Web API
dotnet new webapi -n MyApi

# ASP.NET Core Web App (MVC)
dotnet new mvc -n MyWebApp

# ASP.NET Core Web App (Razor Pages)
dotnet new webapp -n MyWebApp

# ASP.NET Core Empty
dotnet new web -n MyWebApp

# Blazor Server App
dotnet new blazorserver -n MyBlazorApp

# Blazor WebAssembly App
dotnet new blazorwasm -n MyBlazorApp
```

### Console & Library Templates

```bash
# Console Application
dotnet new console -n MyConsoleApp

# Class Library
dotnet new classlib -n MyLibrary

# Worker Service
dotnet new worker -n MyWorker
```

### Test Templates

```bash
# xUnit Test Project
dotnet new xunit -n MyTests

# NUnit Test Project
dotnet new nunit -n MyTests

# MSTest Test Project
dotnet new mstest -n MyTests
```

### Other Templates

```bash
# ASP.NET Core gRPC Service
dotnet new grpc -n MyGrpcService

# Razor Class Library
dotnet new razorclasslib -n MyRazorLib

# Windows Forms App
dotnet new winforms -n MyWinFormsApp

# WPF Application
dotnet new wpf -n MyWpfApp

# .gitignore file
dotnet new gitignore

# global.json file
dotnet new globaljson

# EditorConfig file
dotnet new editorconfig
```

---

## Useful Flags

### Global Flags

```bash
-h, --help              # Show help
-n, --name              # Name for the output
-o, --output            # Output directory
-f, --framework         # Target framework (e.g., net8.0, net7.0)
-c, --configuration     # Build configuration (Debug/Release)
-v, --verbosity         # Verbosity level (q[uiet], m[inimal], n[ormal], d[etailed], diag[nostic])
--no-restore            # Don't restore dependencies
--no-build              # Don't build the project
```

### Project/Solution Flags

```bash
-s, --solution          # Specify solution file
-p, --project           # Specify project file
```

---

## Common Workflows

### Create a New Solution with Multiple Projects

```bash
# Create solution
dotnet new sln -n MySolution

# Create web API project
dotnet new webapi -o src/MySolution.Api

# Create class library
dotnet new classlib -o src/MySolution.Core

# Create test project
dotnet new xunit -o tests/MySolution.Tests

# Add projects to solution
dotnet sln add src/MySolution.Api/MySolution.Api.csproj
dotnet sln add src/MySolution.Core/MySolution.Core.csproj
dotnet sln add tests/MySolution.Tests/MySolution.Tests.csproj

# Add project references
dotnet add src/MySolution.Api/MySolution.Api.csproj reference src/MySolution.Core/MySolution.Core.csproj
dotnet add tests/MySolution.Tests/MySolution.Tests.csproj reference src/MySolution.Api/MySolution.Api.csproj
```

### Build and Run Workflow

```bash
# Restore dependencies
dotnet restore

# Build solution
dotnet build

# Run tests
dotnet test

# Run application
dotnet run --project src/MySolution.Api
```

### Clean Build

```bash
# Clean, restore, and build
dotnet clean && dotnet restore && dotnet build
```

---

## Additional Commands

### Version Information

```bash
# Check .NET version
dotnet --version

# List installed SDKs
dotnet --list-sdks

# List installed runtimes
dotnet --list-runtimes

# Show SDK info
dotnet --info
```

### Tool Management

```bash
# Install global tool
dotnet tool install -g <tool-name>

# Update global tool
dotnet tool update -g <tool-name>

# Uninstall global tool
dotnet tool uninstall -g <tool-name>

# List global tools
dotnet tool list -g
```

### Format Code

```bash
# Format code
dotnet format

# Format and verify (don't format)
dotnet format --verify-no-changes
```

---

## Tips

1. **Use Solution Filters**: For large solutions, use `.slnf` files to work with subsets of projects
2. **Watch Mode**: Use `dotnet watch run` for automatic rebuilds during development
3. **Multiple Frameworks**: Specify `<TargetFrameworks>` (plural) in `.csproj` to target multiple frameworks
4. **Local Tools**: Use `dotnet tool install --local` to install tools per-project (requires tool manifest)
5. **Environment Variables**: Use `DOTNET_*` environment variables for configuration

---

## References

- [Official .NET CLI Documentation](https://docs.microsoft.com/en-us/dotnet/core/tools/)
- [.NET Project Templates](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-new)
- [dotnet build](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-build)
- [dotnet run](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-run)
- [dotnet test](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-test)
