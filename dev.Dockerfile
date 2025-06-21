FROM mcr.microsoft.com/dotnet/sdk:9.0-alpine3.18 AS build-env
WORKDIR /app

# Copy Test csproj and restore as distinct layers
COPY *.sln .
COPY tests/*.csproj ./tests/
COPY src/*.csproj ./src/
COPY src/health-checks.css ./src/
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Debug -o out src/SystemReports.csproj

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:9.0-alpine3.18
WORKDIR /app
COPY --from=build-env /app/out .
COPY --from=build-env /app/src/health-checks.css .
ENV ASPNETCORE_URLS=http://*:5002/
EXPOSE 5002
ENTRYPOINT ["dotnet", "SystemReports.dll"]