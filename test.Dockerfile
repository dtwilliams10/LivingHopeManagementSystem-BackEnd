FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine3.18 AS build
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
FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine3.18
WORKDIR /app
COPY --from=build /app/out .
ENV ASPNETCORE_URLS=http://+:5002
ENTRYPOINT ["dotnet", "SystemReports.dll"]
