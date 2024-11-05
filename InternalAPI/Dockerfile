# Use the official .NET SDK image to build and publish the app
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copy project files and restore dependencies
COPY *.csproj .
RUN dotnet restore

# Copy the entire project and build it
COPY . .
RUN dotnet publish -c Release -o out

# Use the runtime image to run the app
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app/out .

# Expose the port your API will run on
EXPOSE 8080

# Start the application
ENTRYPOINT ["dotnet", "InternalAPI.dll"]
