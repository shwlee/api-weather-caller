FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Weather-caller/Weather-caller.csproj", "Weather-caller/"]
RUN dotnet restore "Weather-caller/Weather-caller.csproj"
COPY . .
WORKDIR "/src/Weather-caller"
RUN dotnet build "Weather-caller.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Weather-caller.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Weather-caller.dll"]
