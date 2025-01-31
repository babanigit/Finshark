# Use official .NET SDK image for building the application
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

# Set the working directory
WORKDIR /app

# Copy project files and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy the rest of the application
COPY . .
RUN dotnet publish -c Release -o out

# Use ASP.NET runtime image to run the app
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/out .

# Expose the API port
EXPOSE 5222

# Run the API
CMD ["dotnet", "YourApi.dll"]
