# ModSharp Module Template

A .NET template for creating ModSharp modules.

## Installation

Install the template globally:

```bash
dotnet new install ModSharp.Module.Template
```

Or install from [NuGet](https://www.nuget.org/packages/ModSharp.Module.Template)

## Usage

Create a new ModSharp module:

```bash
dotnet new modsharp-module -n MyModule --DisplayName "My Module" --DisplayAuthor "Your Name"
```

### Parameters

- `-n|--name`: The name of the module (required)
- `--DisplayName`: The display name shown in the module (default: "Project")
- `--DisplayAuthor`: The author name shown in the module (default: "Author")

## Generated Structure

The template creates:
- `ModuleName.cs` - Main module class implementing `IModSharpModule`
- `ModuleName.csproj` - Project file targeting .NET 10.0

## Example

```bash
dotnet new modsharp-module -n MyAwesomeModule --DisplayName "My Awesome Module" --DisplayAuthor "John Doe"
cd MyAwesomeModule
dotnet build
```

## Requirements

- .NET 10.0 SDK
- Sharp.Shared package (referenced automatically)

## License

This template is provided as-is for creating ModSharp modules.