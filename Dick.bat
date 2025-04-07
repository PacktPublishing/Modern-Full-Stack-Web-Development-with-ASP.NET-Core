REM starting script for F:\Dev\Modern-Full-Stack-Web-Development-with-ASP.NET-Core
cd /D "F:\Dev\Modern-Full-Stack-Web-Development-with-ASP.NET-Core"
dotnet new sln -n Dick
dotnet sln Dick.sln add "Chapter02\Chapter2.csproj"
dotnet sln Dick.sln add "Chapter03\Chapter03.csproj"
dotnet sln Dick.sln add "Chapter04\Authentication\Authentication.csproj"
dotnet sln Dick.sln add "Chapter04\Configuration\Chapter4.csproj"
dotnet sln Dick.sln add "Chapter05\Chapter05\Chapter05.Client\Chapter05.Client.csproj"
dotnet sln Dick.sln add "Chapter05\Chapter05\Chapter05\Chapter05.csproj"
dotnet sln Dick.sln add "Chapter06\Chapter6.Client\Chapter6.Client.csproj"
dotnet sln Dick.sln add "Chapter06\Chapter6\Chapter6.csproj"
dotnet sln Dick.sln add "Chapter07\Chapter7.Client\Chapter7.Client.csproj"
dotnet sln Dick.sln add "Chapter07\Chapter7\Chapter7.csproj"
dotnet sln Dick.sln add "Chapter08\Chapter8.csproj"
dotnet sln Dick.sln add "Chapter09\Chapter9.csproj"
dotnet sln Dick.sln add "Chapter12\Chapter12.csproj"
dotnet sln Dick.sln add "Chapter13\Chapter13.csproj"
dotnet sln Dick.sln add "Chapter14\Chapter14.csproj"
dotnet sln dick.sln list
dotnet build dick.sln
