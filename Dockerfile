FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /App

# # Copy everything
COPY . ./

# # Restore as distinct layers
RUN dotnet restore "Cod3rsGrowth.web/Cod3rsGrowth.web.csproj"

RUN dotnet build "Cod3rsGrowth.web/Cod3rsGrowth.web.csproj" -c Release
# Build and publish a release
RUN dotnet publish -c Release "Cod3rsGrowth.web/Cod3rsGrowth.web.csproj"

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /App
COPY --from=build-env /App/ .
EXPOSE  7118
ENTRYPOINT ["dotnet", "Cod3rsGrowth.web/bin/Release/net7.0/Cod3rsGrowth.web.dll"]

