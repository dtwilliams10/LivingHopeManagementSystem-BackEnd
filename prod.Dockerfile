FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine3.17 AS build
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.sln .
COPY tests/*.csproj ./tests/
COPY src/*.csproj ./src/
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine3.17
WORKDIR /app
COPY --from=build /app/out .
ENV ASPNETCORE_URLS=http://*:5002
EXPOSE 5002
ENTRYPOINT ["dotnet", "SystemReports.dll"]
