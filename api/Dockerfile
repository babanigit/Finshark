FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Print debug information
RUN pwd
RUN ls -la

# Copy project files with verbose output
COPY *.csproj ./
RUN echo "Project files:" && ls -la

# Restore dependencies
RUN dotnet restore

# Copy entire context
COPY . .
RUN echo "All files after copy:" && ls -la

# Publish with verbose output
RUN dotnet publish -c Release -o out -v n

# Print published files
RUN echo "Published files:" && ls -la /app/out

FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app

# Copy published files
COPY --from=build /app/out .

# Print final files
RUN ls -la

EXPOSE 5222
# Use the actual name from published output
CMD ["sh", "-c", "ls /app && dotnet $(ls api.dll | grep -v Test)"]
# CMD ["dotnet", "/app/api.dll"]
