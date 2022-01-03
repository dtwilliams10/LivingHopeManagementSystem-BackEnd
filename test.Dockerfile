FROM mcr.microsoft.com/dotnet/sdk:5.0.403-alpine3.14 AS build-env
WORKDIR /app

# Copy Test csproj and restore as distinct layers
COPY *.sln .
COPY Tests/*.csproj ./Tests/
COPY src/*.csproj ./src/
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Debug -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:5.0.12-alpine3.14
WORKDIR /app
COPY --from=build-env /app/out .
EXPOSE 5000
ENTRYPOINT ["dotnet", "SystemReports.dll"]