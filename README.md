# Student Course Registration System (ASP.NET Core MVC, .NET 10)

## Requirements
- Visual Studio 2026 with the **ASP.NET and web development** workload
- .NET 10 SDK (install from https://dotnet.microsoft.com/download/dotnet/10.0)

## Run in Visual Studio 2026
1. Extract the ZIP file.
2. Open `StudentRegistration.csproj` in Visual Studio 2026.
3. Set `StudentRegistration` as the startup project if prompted.
4. Press `Ctrl+F5` to run.

## Run from a terminal
```bash
dotnet restore
dotnet build
dotnet run
```
Then open the localhost URL shown in the terminal.

## Pages
- Home: `/`
- Student List: `/Student`
- Register: `/Student/Create`
- Details: `/Student/Details/1`

The project currently uses an in-memory data store. Student records are cleared when the application stops.
