FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["ITHelpdesk.Domain/*.csproj", "ITHelpdesk.Domain/"]
COPY ["ITHelpdesk.Application/*.csproj", "ITHelpdesk.Application/"]
COPY ["ITHelpdesk.Infrastructure/*.csproj", "ITHelpdesk.Infrastructure/"]
COPY ["ITHelpdesk.API/*.csproj", "ITHelpdesk.API/"]
COPY ["ITHelpdesk.Test/*.csproj", "ITHelpdesk.Test/"]
COPY ["ITHelpdesk.sln", "."]
RUN dotnet restore

COPY . .
RUN dotnet build -c Release --no-restore

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish --no-build

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
EXPOSE 8080
EXPOSE 8081
ENTRYPOINT ["dotnet", "ITHelpdesk.API.dll"]
