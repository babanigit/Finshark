# Use the official .NET SDK image to build and publish the app
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copy everything and publish the app
COPY . ./
RUN dotnet publish -c Release -o out

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app

# Copy published output
COPY --from=build /app/out ./

# load the fronted production files
COPY ./frontend/dist ./frontend/dist

# Expose necessary ports
EXPOSE 5222

# # Run the application
# CMD ["dotnet", "out/Finshark.dll"]

# for railways
CMD ["dotnet", "Finshark.dll"]


