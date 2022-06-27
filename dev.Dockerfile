﻿FROM mcr.microsoft.com/dotnet/sdk:6.0.301-alpine3.15 AS build-env
WORKDIR /app

# Copy Test csproj and restore as distinct layers
COPY *.sln .
COPY tests/*.csproj ./tests/
COPY src/*.csproj ./src/
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Debug -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0.4-alpine3.15
WORKDIR /app
COPY --from=build-env /app/out .
EXPOSE 5002
ENTRYPOINT ["dotnet", "SystemReports.dll"]