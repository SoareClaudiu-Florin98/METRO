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

FROM mcr.microsoft.com/mssql/server:2019-latest AS sqlserver
ENV ACCEPT_EULA=Y
ENV SA_PASSWORD="S3cur3P@ssW0rd!"
ENV MSSQL_PID=Express

FROM sqlserver AS sqlserver-final
WORKDIR /db-scripts
COPY ["db-scripts/init.sql", "/docker-entrypoint-initdb.d/"]

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "METROAssignment.API.dll"]
