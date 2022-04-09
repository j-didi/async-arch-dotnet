FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/AsyncArch.API/AsyncArch.API.csproj", "AsyncArch.API/"]
COPY ["src/AsyncArch.Infra/AsyncArch.Infra.csproj", "AsyncArch.Infra/"]
COPY ["src/AsyncArch.Core/AsyncArch.Core.csproj", "AsyncArch.Core/"]
RUN dotnet restore "/src/AsyncArch.API/AsyncArch.API.csproj"
COPY . .
WORKDIR "src/AsyncArch.API"
RUN dotnet build "AsyncArch.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AsyncArch.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AsyncArch.API.dll"]
