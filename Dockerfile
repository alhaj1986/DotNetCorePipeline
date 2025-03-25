# Use the official .NET SDK image as a build environment
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.sln .
COPY ./ConsoleApp/*.csproj ./ConsoleApp/
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish ./ConsoleApp/ConsoleApp.csproj -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out .

ENTRYPOINT ["dotnet", "ConsoleApp.dll"]
