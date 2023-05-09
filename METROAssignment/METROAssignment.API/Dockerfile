FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["METROAssignment.API/METROAssignment.API.csproj", "METROAssignment.API/"]
RUN dotnet restore "METROAssignment.API/METROAssignment.API.csproj"
COPY . .
WORKDIR "/src/METROAssignment.API"
RUN dotnet build "METROAssignment.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "METROAssignment.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "METROAssignment.API.dll"]
