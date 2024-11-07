# build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src/HabitTracker

# restore
COPY "App.csproj" .
RUN dotnet restore "App.csproj"

# build
COPY . .
RUN dotnet publish "App.csproj" -c Release -o /app/publish

# run stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0
ENV ASPNETCORE_HTTP_PORTS=5000
EXPOSE 5000
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "App.dll"]
