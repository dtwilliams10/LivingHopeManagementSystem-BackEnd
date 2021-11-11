FROM mcr.microsoft.com/dotnet/sdk:5.0.403-alpine3.14 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:5.0.12-alpine3.14
WORKDIR /app
COPY --from=build-env /app/out .
RUN apk update
RUN apk add vim
ENTRYPOINT ["dotnet", "SystemReports.dll"]
EXPOSE 5000
