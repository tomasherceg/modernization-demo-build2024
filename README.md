# Microsoft Build 2024 Demo: Modernization of legacy .NET web apps

This is a demo for the Microsoft Build session [Modernize old web applications to .NET 8](https://build.microsoft.com/en-US/sessions/c7052569-5d05-416d-908b-0c21f075d108?source=/speakers/7e24fd79-8a71-4118-ac19-0e9e137d3957).

[Slides](resources/slides.pdf)

## Running the sample

1. Clone the repository and open the `src/Modernization.sln` in Visual Studio.

2. Open the `Modernization.BackendApi/appsettings.json` file and update the connection string to the SQL Server database to match your environment. The database does not need to exist, the application will create it itself.

3. Right click on the `Modernization.BackendApi` in the _Solution Explorer_ window and select __View in browser__.

4. To run the __Side by side modernization example__, run the `Modernization.SideBySide` and `Modernization.SideBySide.New` projects by right-clicking on the solution and choosing __Set startup projects__. Configure both projects to start at the same time.

5. To run the __In-place modernization example__, just run the `Modernization.InPlace` project.

## Useful resources

* [Side-by-side migration - official docs](https://learn.microsoft.com/en-us/aspnet/core/migration/inc/start?view=aspnetcore-8.0)

* [In-place migration using DotVVM](https://www.dotvvm.com/modernize)

* [DotVVM for Visual Studio extension](https://marketplace.visualstudio.com/items?itemName=TomasHerceg.DotVVM-VSExtension2022)

* [ASPX to DotVVM Converter](https://www.dotvvm.com/webforms/convert)

* [DotVVM GitHub repo](https://github.com/riganti/dotvvm)

