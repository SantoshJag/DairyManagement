# Use official .NET 6 SDK image
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Copy everything from solution root into the container
COPY ../ ./

# Go to API project
WORKDIR /src/DairyManagement.API

# Restore, build, publish
RUN dotnet restore
RUN dotnet publish -c Release -o /app/publish

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "DairyManagement.API.dll"]
