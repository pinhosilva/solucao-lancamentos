FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Web.Api/Web.Api.csproj", "src/Web.Api/"]
COPY ["src/Domain/Domain.csproj", "src/Domain/"]
COPY ["src/Infrastructure/Infrastructure.csproj", "src/Infrastructure/"]
COPY ["src/CrossCutting/CrossCutting.csproj", "src/CrossCutting/"]
COPY ["src/Infra.EF/Infra.EF.csproj", "src/Infra.EF/"]
COPY ["src/Services/Services.csproj", "src/Services/"]
RUN dotnet restore "src/Web.Api/Web.Api.csproj"
COPY . .

#WORKDIR /scripts
#COPY ["scripts/create-database.sql", "/scripts/create-database.sql"]
#COPY ["scripts/entrypoint-sql-server.sh", "/scripts/entrypoint-sql-server.sh"]

WORKDIR "/src/src/Web.Api"
RUN dotnet build "Web.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Web.Api.csproj" -c Release -o /app/publish
#RUN ["chmod", "+x", "/scripts/entrypoint-sql-server.sh"]

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Web.Api.dll"]